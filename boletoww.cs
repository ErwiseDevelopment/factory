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
   public class boletoww : GXDataArea
   {
      public boletoww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public boletoww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_CarteiraDeCobrancaId )
      {
         this.AV91CarteiraDeCobrancaId = aP0_CarteiraDeCobrancaId;
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
         cmbBoletosStatus = new GXCombobox();
         cmbBoletosSacadoTipoDocumento = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "CarteiraDeCobrancaId");
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
               gxfirstwebparm = GetFirstPar( "CarteiraDeCobrancaId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "CarteiraDeCobrancaId");
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
         AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV15FilterFullText = GetPar( "FilterFullText");
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV16DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV18BoletosNossoNumero1 = GetPar( "BoletosNossoNumero1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV20DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV22BoletosNossoNumero2 = GetPar( "BoletosNossoNumero2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV26BoletosNossoNumero3 = GetPar( "BoletosNossoNumero3");
         AV34ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV92Pgmname = GetPar( "Pgmname");
         AV91CarteiraDeCobrancaId = (int)(Math.Round(NumberUtil.Val( GetPar( "CarteiraDeCobrancaId"), "."), 18, MidpointRounding.ToEven));
         AV19DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV23DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV35TFBoletosNossoNumero = GetPar( "TFBoletosNossoNumero");
         AV36TFBoletosNossoNumero_Sel = GetPar( "TFBoletosNossoNumero_Sel");
         AV37TFBoletosSeuNumero = GetPar( "TFBoletosSeuNumero");
         AV38TFBoletosSeuNumero_Sel = GetPar( "TFBoletosSeuNumero_Sel");
         AV39TFBoletosNumero = GetPar( "TFBoletosNumero");
         AV40TFBoletosNumero_Sel = GetPar( "TFBoletosNumero_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV42TFBoletosStatus_Sels);
         AV43TFBoletosDataEmissao = context.localUtil.ParseDateParm( GetPar( "TFBoletosDataEmissao"));
         AV44TFBoletosDataEmissao_To = context.localUtil.ParseDateParm( GetPar( "TFBoletosDataEmissao_To"));
         AV48TFBoletosDataVencimento = context.localUtil.ParseDateParm( GetPar( "TFBoletosDataVencimento"));
         AV49TFBoletosDataVencimento_To = context.localUtil.ParseDateParm( GetPar( "TFBoletosDataVencimento_To"));
         AV53TFBoletosDataRegistro = context.localUtil.ParseDTimeParm( GetPar( "TFBoletosDataRegistro"));
         AV54TFBoletosDataRegistro_To = context.localUtil.ParseDTimeParm( GetPar( "TFBoletosDataRegistro_To"));
         AV58TFBoletosDataPagamento = context.localUtil.ParseDateParm( GetPar( "TFBoletosDataPagamento"));
         AV59TFBoletosDataPagamento_To = context.localUtil.ParseDateParm( GetPar( "TFBoletosDataPagamento_To"));
         AV63TFBoletosDataBaixa = context.localUtil.ParseDateParm( GetPar( "TFBoletosDataBaixa"));
         AV64TFBoletosDataBaixa_To = context.localUtil.ParseDateParm( GetPar( "TFBoletosDataBaixa_To"));
         AV68TFBoletosValorNominal = NumberUtil.Val( GetPar( "TFBoletosValorNominal"), ".");
         AV69TFBoletosValorNominal_To = NumberUtil.Val( GetPar( "TFBoletosValorNominal_To"), ".");
         AV70TFBoletosValorPago = NumberUtil.Val( GetPar( "TFBoletosValorPago"), ".");
         AV71TFBoletosValorPago_To = NumberUtil.Val( GetPar( "TFBoletosValorPago_To"), ".");
         AV72TFBoletosValorDesconto = NumberUtil.Val( GetPar( "TFBoletosValorDesconto"), ".");
         AV73TFBoletosValorDesconto_To = NumberUtil.Val( GetPar( "TFBoletosValorDesconto_To"), ".");
         AV74TFBoletosValorJuros = NumberUtil.Val( GetPar( "TFBoletosValorJuros"), ".");
         AV75TFBoletosValorJuros_To = NumberUtil.Val( GetPar( "TFBoletosValorJuros_To"), ".");
         AV76TFBoletosValorMulta = NumberUtil.Val( GetPar( "TFBoletosValorMulta"), ".");
         AV77TFBoletosValorMulta_To = NumberUtil.Val( GetPar( "TFBoletosValorMulta_To"), ".");
         AV78TFBoletosSacadoNome = GetPar( "TFBoletosSacadoNome");
         AV79TFBoletosSacadoNome_Sel = GetPar( "TFBoletosSacadoNome_Sel");
         AV80TFBoletosSacadoDocumento = GetPar( "TFBoletosSacadoDocumento");
         AV81TFBoletosSacadoDocumento_Sel = GetPar( "TFBoletosSacadoDocumento_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV83TFBoletosSacadoTipoDocumento_Sels);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV28DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV27DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18BoletosNossoNumero1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22BoletosNossoNumero2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26BoletosNossoNumero3, AV34ManageFiltersExecutionStep, AV92Pgmname, AV91CarteiraDeCobrancaId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFBoletosNossoNumero, AV36TFBoletosNossoNumero_Sel, AV37TFBoletosSeuNumero, AV38TFBoletosSeuNumero_Sel, AV39TFBoletosNumero, AV40TFBoletosNumero_Sel, AV42TFBoletosStatus_Sels, AV43TFBoletosDataEmissao, AV44TFBoletosDataEmissao_To, AV48TFBoletosDataVencimento, AV49TFBoletosDataVencimento_To, AV53TFBoletosDataRegistro, AV54TFBoletosDataRegistro_To, AV58TFBoletosDataPagamento, AV59TFBoletosDataPagamento_To, AV63TFBoletosDataBaixa, AV64TFBoletosDataBaixa_To, AV68TFBoletosValorNominal, AV69TFBoletosValorNominal_To, AV70TFBoletosValorPago, AV71TFBoletosValorPago_To, AV72TFBoletosValorDesconto, AV73TFBoletosValorDesconto_To, AV74TFBoletosValorJuros, AV75TFBoletosValorJuros_To, AV76TFBoletosValorMulta, AV77TFBoletosValorMulta_To, AV78TFBoletosSacadoNome, AV79TFBoletosSacadoNome_Sel, AV80TFBoletosSacadoDocumento, AV81TFBoletosSacadoDocumento_Sel, AV83TFBoletosSacadoTipoDocumento_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
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
         PAA82( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTA82( ) ;
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
         GXEncryptionTmp = "boletoww"+UrlEncode(StringUtil.LTrimStr(AV91CarteiraDeCobrancaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("boletoww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV92Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV92Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vCARTEIRADECOBRANCAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV91CarteiraDeCobrancaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCARTEIRADECOBRANCAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV91CarteiraDeCobrancaId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV15FilterFullText);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV16DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vBOLETOSNOSSONUMERO1", AV18BoletosNossoNumero1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV20DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vBOLETOSNOSSONUMERO2", AV22BoletosNossoNumero2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV24DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vBOLETOSNOSSONUMERO3", AV26BoletosNossoNumero3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_107", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_107), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV32ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV32ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV86GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV87GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV88GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV84DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV84DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_BOLETOSDATAEMISSAOAUXDATE", context.localUtil.DToC( AV45DDO_BoletosDataEmissaoAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_BOLETOSDATAEMISSAOAUXDATETO", context.localUtil.DToC( AV46DDO_BoletosDataEmissaoAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_BOLETOSDATAVENCIMENTOAUXDATE", context.localUtil.DToC( AV50DDO_BoletosDataVencimentoAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_BOLETOSDATAVENCIMENTOAUXDATETO", context.localUtil.DToC( AV51DDO_BoletosDataVencimentoAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_BOLETOSDATAREGISTROAUXDATE", context.localUtil.DToC( AV55DDO_BoletosDataRegistroAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_BOLETOSDATAREGISTROAUXDATETO", context.localUtil.DToC( AV56DDO_BoletosDataRegistroAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_BOLETOSDATAPAGAMENTOAUXDATE", context.localUtil.DToC( AV60DDO_BoletosDataPagamentoAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_BOLETOSDATAPAGAMENTOAUXDATETO", context.localUtil.DToC( AV61DDO_BoletosDataPagamentoAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_BOLETOSDATABAIXAAUXDATE", context.localUtil.DToC( AV65DDO_BoletosDataBaixaAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_BOLETOSDATABAIXAAUXDATETO", context.localUtil.DToC( AV66DDO_BoletosDataBaixaAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV92Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV92Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vCARTEIRADECOBRANCAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV91CarteiraDeCobrancaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCARTEIRADECOBRANCAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV91CarteiraDeCobrancaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV19DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV23DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSNOSSONUMERO", AV35TFBoletosNossoNumero);
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSNOSSONUMERO_SEL", AV36TFBoletosNossoNumero_Sel);
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSSEUNUMERO", AV37TFBoletosSeuNumero);
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSSEUNUMERO_SEL", AV38TFBoletosSeuNumero_Sel);
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSNUMERO", AV39TFBoletosNumero);
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSNUMERO_SEL", AV40TFBoletosNumero_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFBOLETOSSTATUS_SELS", AV42TFBoletosStatus_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFBOLETOSSTATUS_SELS", AV42TFBoletosStatus_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSDATAEMISSAO", context.localUtil.DToC( AV43TFBoletosDataEmissao, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSDATAEMISSAO_TO", context.localUtil.DToC( AV44TFBoletosDataEmissao_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSDATAVENCIMENTO", context.localUtil.DToC( AV48TFBoletosDataVencimento, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSDATAVENCIMENTO_TO", context.localUtil.DToC( AV49TFBoletosDataVencimento_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSDATAREGISTRO", context.localUtil.TToC( AV53TFBoletosDataRegistro, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSDATAREGISTRO_TO", context.localUtil.TToC( AV54TFBoletosDataRegistro_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSDATAPAGAMENTO", context.localUtil.DToC( AV58TFBoletosDataPagamento, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSDATAPAGAMENTO_TO", context.localUtil.DToC( AV59TFBoletosDataPagamento_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSDATABAIXA", context.localUtil.DToC( AV63TFBoletosDataBaixa, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSDATABAIXA_TO", context.localUtil.DToC( AV64TFBoletosDataBaixa_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSVALORNOMINAL", StringUtil.LTrim( StringUtil.NToC( AV68TFBoletosValorNominal, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSVALORNOMINAL_TO", StringUtil.LTrim( StringUtil.NToC( AV69TFBoletosValorNominal_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSVALORPAGO", StringUtil.LTrim( StringUtil.NToC( AV70TFBoletosValorPago, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSVALORPAGO_TO", StringUtil.LTrim( StringUtil.NToC( AV71TFBoletosValorPago_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSVALORDESCONTO", StringUtil.LTrim( StringUtil.NToC( AV72TFBoletosValorDesconto, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSVALORDESCONTO_TO", StringUtil.LTrim( StringUtil.NToC( AV73TFBoletosValorDesconto_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSVALORJUROS", StringUtil.LTrim( StringUtil.NToC( AV74TFBoletosValorJuros, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSVALORJUROS_TO", StringUtil.LTrim( StringUtil.NToC( AV75TFBoletosValorJuros_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSVALORMULTA", StringUtil.LTrim( StringUtil.NToC( AV76TFBoletosValorMulta, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSVALORMULTA_TO", StringUtil.LTrim( StringUtil.NToC( AV77TFBoletosValorMulta_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSSACADONOME", AV78TFBoletosSacadoNome);
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSSACADONOME_SEL", AV79TFBoletosSacadoNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSSACADODOCUMENTO", AV80TFBoletosSacadoDocumento);
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSSACADODOCUMENTO_SEL", AV81TFBoletosSacadoDocumento_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFBOLETOSSACADOTIPODOCUMENTO_SELS", AV83TFBoletosSacadoTipoDocumento_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFBOLETOSSACADOTIPODOCUMENTO_SELS", AV83TFBoletosSacadoTipoDocumento_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV28DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV27DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSSTATUS_SELSJSON", AV41TFBoletosStatus_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFBOLETOSSACADOTIPODOCUMENTO_SELSJSON", AV82TFBoletosSacadoTipoDocumento_SelsJson);
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
            WEA82( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTA82( ) ;
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
         GXEncryptionTmp = "boletoww"+UrlEncode(StringUtil.LTrimStr(AV91CarteiraDeCobrancaId,9,0));
         return formatLink("boletoww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "BoletoWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Boleto" ;
      }

      protected void WBA80( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(107), 3, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_BoletoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(107), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_BoletoWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV32ManageFiltersData);
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_BoletoWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_BoletoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_BoletoWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_BoletoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_45_A82( true) ;
         }
         else
         {
            wb_table1_45_A82( false) ;
         }
         return  ;
      }

      protected void wb_table1_45_A82e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_BoletoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV20DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "", true, 0, "HLP_BoletoWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_BoletoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_67_A82( true) ;
         }
         else
         {
            wb_table2_67_A82( false) ;
         }
         return  ;
      }

      protected void wb_table2_67_A82e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_BoletoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV24DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "", true, 0, "HLP_BoletoWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_BoletoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_89_A82( true) ;
         }
         else
         {
            wb_table3_89_A82( false) ;
         }
         return  ;
      }

      protected void wb_table3_89_A82e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV86GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV87GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV88GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_BoletoWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV84DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_boletosdataemissaoauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_boletosdataemissaoauxdatetext_Internalname, AV47DDO_BoletosDataEmissaoAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV47DDO_BoletosDataEmissaoAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,141);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_boletosdataemissaoauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_BoletoWW.htm");
            /* User Defined Control */
            ucTfboletosdataemissao_rangepicker.SetProperty("Start Date", AV45DDO_BoletosDataEmissaoAuxDate);
            ucTfboletosdataemissao_rangepicker.SetProperty("End Date", AV46DDO_BoletosDataEmissaoAuxDateTo);
            ucTfboletosdataemissao_rangepicker.Render(context, "wwp.daterangepicker", Tfboletosdataemissao_rangepicker_Internalname, "TFBOLETOSDATAEMISSAO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_boletosdatavencimentoauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_boletosdatavencimentoauxdatetext_Internalname, AV52DDO_BoletosDataVencimentoAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV52DDO_BoletosDataVencimentoAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,144);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_boletosdatavencimentoauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_BoletoWW.htm");
            /* User Defined Control */
            ucTfboletosdatavencimento_rangepicker.SetProperty("Start Date", AV50DDO_BoletosDataVencimentoAuxDate);
            ucTfboletosdatavencimento_rangepicker.SetProperty("End Date", AV51DDO_BoletosDataVencimentoAuxDateTo);
            ucTfboletosdatavencimento_rangepicker.Render(context, "wwp.daterangepicker", Tfboletosdatavencimento_rangepicker_Internalname, "TFBOLETOSDATAVENCIMENTO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_boletosdataregistroauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_boletosdataregistroauxdatetext_Internalname, AV57DDO_BoletosDataRegistroAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV57DDO_BoletosDataRegistroAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,147);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_boletosdataregistroauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_BoletoWW.htm");
            /* User Defined Control */
            ucTfboletosdataregistro_rangepicker.SetProperty("Start Date", AV55DDO_BoletosDataRegistroAuxDate);
            ucTfboletosdataregistro_rangepicker.SetProperty("End Date", AV56DDO_BoletosDataRegistroAuxDateTo);
            ucTfboletosdataregistro_rangepicker.Render(context, "wwp.daterangepicker", Tfboletosdataregistro_rangepicker_Internalname, "TFBOLETOSDATAREGISTRO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_boletosdatapagamentoauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 150,'',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_boletosdatapagamentoauxdatetext_Internalname, AV62DDO_BoletosDataPagamentoAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV62DDO_BoletosDataPagamentoAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,150);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_boletosdatapagamentoauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_BoletoWW.htm");
            /* User Defined Control */
            ucTfboletosdatapagamento_rangepicker.SetProperty("Start Date", AV60DDO_BoletosDataPagamentoAuxDate);
            ucTfboletosdatapagamento_rangepicker.SetProperty("End Date", AV61DDO_BoletosDataPagamentoAuxDateTo);
            ucTfboletosdatapagamento_rangepicker.Render(context, "wwp.daterangepicker", Tfboletosdatapagamento_rangepicker_Internalname, "TFBOLETOSDATAPAGAMENTO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_boletosdatabaixaauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_boletosdatabaixaauxdatetext_Internalname, AV67DDO_BoletosDataBaixaAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV67DDO_BoletosDataBaixaAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,153);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_boletosdatabaixaauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_BoletoWW.htm");
            /* User Defined Control */
            ucTfboletosdatabaixa_rangepicker.SetProperty("Start Date", AV65DDO_BoletosDataBaixaAuxDate);
            ucTfboletosdatabaixa_rangepicker.SetProperty("End Date", AV66DDO_BoletosDataBaixaAuxDateTo);
            ucTfboletosdatabaixa_rangepicker.Render(context, "wwp.daterangepicker", Tfboletosdatabaixa_rangepicker_Internalname, "TFBOLETOSDATABAIXA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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

      protected void STARTA82( )
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
         Form.Meta.addItem("description", " Boleto", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPA80( ) ;
      }

      protected void WSA82( )
      {
         STARTA82( ) ;
         EVTA82( ) ;
      }

      protected void EVTA82( )
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
                              E11A82 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12A82 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13A82 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E14A82 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E15A82 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E16A82 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E17A82 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E18A82 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E19A82 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E20A82 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E21A82 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E22A82 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E23A82 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E24A82 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) )
                           {
                              nGXsfl_107_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
                              SubsflControlProps_1072( ) ;
                              cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
                              cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
                              AV89GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV89GridActionGroup1), 4, 0));
                              A1077BoletosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtBoletosId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A1069CarteiraDeCobrancaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCarteiraDeCobrancaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n1069CarteiraDeCobrancaId = false;
                              A261TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n261TituloId = false;
                              A1078BoletosNossoNumero = cgiGet( edtBoletosNossoNumero_Internalname);
                              n1078BoletosNossoNumero = false;
                              A1079BoletosSeuNumero = cgiGet( edtBoletosSeuNumero_Internalname);
                              n1079BoletosSeuNumero = false;
                              A1080BoletosNumero = cgiGet( edtBoletosNumero_Internalname);
                              n1080BoletosNumero = false;
                              A1081BoletosLinhaDigitavel = cgiGet( edtBoletosLinhaDigitavel_Internalname);
                              n1081BoletosLinhaDigitavel = false;
                              A1082BoletosCodigoDeBarras = cgiGet( edtBoletosCodigoDeBarras_Internalname);
                              n1082BoletosCodigoDeBarras = false;
                              cmbBoletosStatus.Name = cmbBoletosStatus_Internalname;
                              cmbBoletosStatus.CurrentValue = cgiGet( cmbBoletosStatus_Internalname);
                              A1083BoletosStatus = cgiGet( cmbBoletosStatus_Internalname);
                              n1083BoletosStatus = false;
                              A1084BoletosDataEmissao = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtBoletosDataEmissao_Internalname), 0));
                              n1084BoletosDataEmissao = false;
                              A1085BoletosDataVencimento = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtBoletosDataVencimento_Internalname), 0));
                              n1085BoletosDataVencimento = false;
                              A1086BoletosDataRegistro = context.localUtil.CToT( cgiGet( edtBoletosDataRegistro_Internalname), 0);
                              n1086BoletosDataRegistro = false;
                              A1087BoletosDataPagamento = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtBoletosDataPagamento_Internalname), 0));
                              n1087BoletosDataPagamento = false;
                              A1088BoletosDataBaixa = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtBoletosDataBaixa_Internalname), 0));
                              n1088BoletosDataBaixa = false;
                              A1089BoletosValorNominal = context.localUtil.CToN( cgiGet( edtBoletosValorNominal_Internalname), ",", ".");
                              n1089BoletosValorNominal = false;
                              A1090BoletosValorPago = context.localUtil.CToN( cgiGet( edtBoletosValorPago_Internalname), ",", ".");
                              n1090BoletosValorPago = false;
                              A1091BoletosValorDesconto = context.localUtil.CToN( cgiGet( edtBoletosValorDesconto_Internalname), ",", ".");
                              n1091BoletosValorDesconto = false;
                              A1092BoletosValorJuros = context.localUtil.CToN( cgiGet( edtBoletosValorJuros_Internalname), ",", ".");
                              n1092BoletosValorJuros = false;
                              A1093BoletosValorMulta = context.localUtil.CToN( cgiGet( edtBoletosValorMulta_Internalname), ",", ".");
                              n1093BoletosValorMulta = false;
                              A1094BoletosSacadoNome = cgiGet( edtBoletosSacadoNome_Internalname);
                              n1094BoletosSacadoNome = false;
                              A1095BoletosSacadoDocumento = cgiGet( edtBoletosSacadoDocumento_Internalname);
                              n1095BoletosSacadoDocumento = false;
                              cmbBoletosSacadoTipoDocumento.Name = cmbBoletosSacadoTipoDocumento_Internalname;
                              cmbBoletosSacadoTipoDocumento.CurrentValue = cgiGet( cmbBoletosSacadoTipoDocumento_Internalname);
                              A1096BoletosSacadoTipoDocumento = cgiGet( cmbBoletosSacadoTipoDocumento_Internalname);
                              n1096BoletosSacadoTipoDocumento = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E25A82 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E26A82 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E27A82 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONGROUP1.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E28A82 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV13OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV16DynamicFiltersSelector1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV17DynamicFiltersOperator1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Boletosnossonumero1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vBOLETOSNOSSONUMERO1"), AV18BoletosNossoNumero1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV20DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV21DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Boletosnossonumero2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vBOLETOSNOSSONUMERO2"), AV22BoletosNossoNumero2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV24DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV25DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Boletosnossonumero3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vBOLETOSNOSSONUMERO3"), AV26BoletosNossoNumero3) != 0 )
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

      protected void WEA82( )
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

      protected void PAA82( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "boletoww")), "boletoww") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "boletoww")))) ;
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
                  gxfirstwebparm = GetFirstPar( "CarteiraDeCobrancaId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV91CarteiraDeCobrancaId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV91CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(AV91CarteiraDeCobrancaId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vCARTEIRADECOBRANCAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV91CarteiraDeCobrancaId), "ZZZZZZZZ9"), context));
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
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       string AV15FilterFullText ,
                                       string AV16DynamicFiltersSelector1 ,
                                       short AV17DynamicFiltersOperator1 ,
                                       string AV18BoletosNossoNumero1 ,
                                       string AV20DynamicFiltersSelector2 ,
                                       short AV21DynamicFiltersOperator2 ,
                                       string AV22BoletosNossoNumero2 ,
                                       string AV24DynamicFiltersSelector3 ,
                                       short AV25DynamicFiltersOperator3 ,
                                       string AV26BoletosNossoNumero3 ,
                                       short AV34ManageFiltersExecutionStep ,
                                       string AV92Pgmname ,
                                       int AV91CarteiraDeCobrancaId ,
                                       bool AV19DynamicFiltersEnabled2 ,
                                       bool AV23DynamicFiltersEnabled3 ,
                                       string AV35TFBoletosNossoNumero ,
                                       string AV36TFBoletosNossoNumero_Sel ,
                                       string AV37TFBoletosSeuNumero ,
                                       string AV38TFBoletosSeuNumero_Sel ,
                                       string AV39TFBoletosNumero ,
                                       string AV40TFBoletosNumero_Sel ,
                                       GxSimpleCollection<string> AV42TFBoletosStatus_Sels ,
                                       DateTime AV43TFBoletosDataEmissao ,
                                       DateTime AV44TFBoletosDataEmissao_To ,
                                       DateTime AV48TFBoletosDataVencimento ,
                                       DateTime AV49TFBoletosDataVencimento_To ,
                                       DateTime AV53TFBoletosDataRegistro ,
                                       DateTime AV54TFBoletosDataRegistro_To ,
                                       DateTime AV58TFBoletosDataPagamento ,
                                       DateTime AV59TFBoletosDataPagamento_To ,
                                       DateTime AV63TFBoletosDataBaixa ,
                                       DateTime AV64TFBoletosDataBaixa_To ,
                                       decimal AV68TFBoletosValorNominal ,
                                       decimal AV69TFBoletosValorNominal_To ,
                                       decimal AV70TFBoletosValorPago ,
                                       decimal AV71TFBoletosValorPago_To ,
                                       decimal AV72TFBoletosValorDesconto ,
                                       decimal AV73TFBoletosValorDesconto_To ,
                                       decimal AV74TFBoletosValorJuros ,
                                       decimal AV75TFBoletosValorJuros_To ,
                                       decimal AV76TFBoletosValorMulta ,
                                       decimal AV77TFBoletosValorMulta_To ,
                                       string AV78TFBoletosSacadoNome ,
                                       string AV79TFBoletosSacadoNome_Sel ,
                                       string AV80TFBoletosSacadoDocumento ,
                                       string AV81TFBoletosSacadoDocumento_Sel ,
                                       GxSimpleCollection<string> AV83TFBoletosSacadoTipoDocumento_Sels ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV28DynamicFiltersIgnoreFirst ,
                                       bool AV27DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFA82( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_BOLETOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A1077BoletosId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "BOLETOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1077BoletosId), 9, 0, ".", "")));
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
            AV16DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV16DynamicFiltersSelector1);
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV20DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV20DynamicFiltersSelector2);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV24DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV24DynamicFiltersSelector3);
            AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFA82( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV92Pgmname = "BoletoWW";
      }

      protected void RFA82( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 107;
         /* Execute user event: Refresh */
         E26A82 ();
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
                                                 A1083BoletosStatus ,
                                                 AV112Boletowwds_20_tfboletosstatus_sels ,
                                                 A1096BoletosSacadoTipoDocumento ,
                                                 AV137Boletowwds_45_tfboletossacadotipodocumento_sels ,
                                                 AV94Boletowwds_2_filterfulltext ,
                                                 AV95Boletowwds_3_dynamicfiltersselector1 ,
                                                 AV96Boletowwds_4_dynamicfiltersoperator1 ,
                                                 AV97Boletowwds_5_boletosnossonumero1 ,
                                                 AV98Boletowwds_6_dynamicfiltersenabled2 ,
                                                 AV99Boletowwds_7_dynamicfiltersselector2 ,
                                                 AV100Boletowwds_8_dynamicfiltersoperator2 ,
                                                 AV101Boletowwds_9_boletosnossonumero2 ,
                                                 AV102Boletowwds_10_dynamicfiltersenabled3 ,
                                                 AV103Boletowwds_11_dynamicfiltersselector3 ,
                                                 AV104Boletowwds_12_dynamicfiltersoperator3 ,
                                                 AV105Boletowwds_13_boletosnossonumero3 ,
                                                 AV107Boletowwds_15_tfboletosnossonumero_sel ,
                                                 AV106Boletowwds_14_tfboletosnossonumero ,
                                                 AV109Boletowwds_17_tfboletosseunumero_sel ,
                                                 AV108Boletowwds_16_tfboletosseunumero ,
                                                 AV111Boletowwds_19_tfboletosnumero_sel ,
                                                 AV110Boletowwds_18_tfboletosnumero ,
                                                 AV112Boletowwds_20_tfboletosstatus_sels.Count ,
                                                 AV113Boletowwds_21_tfboletosdataemissao ,
                                                 AV114Boletowwds_22_tfboletosdataemissao_to ,
                                                 AV115Boletowwds_23_tfboletosdatavencimento ,
                                                 AV116Boletowwds_24_tfboletosdatavencimento_to ,
                                                 AV117Boletowwds_25_tfboletosdataregistro ,
                                                 AV118Boletowwds_26_tfboletosdataregistro_to ,
                                                 AV119Boletowwds_27_tfboletosdatapagamento ,
                                                 AV120Boletowwds_28_tfboletosdatapagamento_to ,
                                                 AV121Boletowwds_29_tfboletosdatabaixa ,
                                                 AV122Boletowwds_30_tfboletosdatabaixa_to ,
                                                 AV123Boletowwds_31_tfboletosvalornominal ,
                                                 AV124Boletowwds_32_tfboletosvalornominal_to ,
                                                 AV125Boletowwds_33_tfboletosvalorpago ,
                                                 AV126Boletowwds_34_tfboletosvalorpago_to ,
                                                 AV127Boletowwds_35_tfboletosvalordesconto ,
                                                 AV128Boletowwds_36_tfboletosvalordesconto_to ,
                                                 AV129Boletowwds_37_tfboletosvalorjuros ,
                                                 AV130Boletowwds_38_tfboletosvalorjuros_to ,
                                                 AV131Boletowwds_39_tfboletosvalormulta ,
                                                 AV132Boletowwds_40_tfboletosvalormulta_to ,
                                                 AV134Boletowwds_42_tfboletossacadonome_sel ,
                                                 AV133Boletowwds_41_tfboletossacadonome ,
                                                 AV136Boletowwds_44_tfboletossacadodocumento_sel ,
                                                 AV135Boletowwds_43_tfboletossacadodocumento ,
                                                 AV137Boletowwds_45_tfboletossacadotipodocumento_sels.Count ,
                                                 A1078BoletosNossoNumero ,
                                                 A1079BoletosSeuNumero ,
                                                 A1080BoletosNumero ,
                                                 A1089BoletosValorNominal ,
                                                 A1090BoletosValorPago ,
                                                 A1091BoletosValorDesconto ,
                                                 A1092BoletosValorJuros ,
                                                 A1093BoletosValorMulta ,
                                                 A1094BoletosSacadoNome ,
                                                 A1095BoletosSacadoDocumento ,
                                                 A1084BoletosDataEmissao ,
                                                 A1085BoletosDataVencimento ,
                                                 A1086BoletosDataRegistro ,
                                                 A1087BoletosDataPagamento ,
                                                 A1088BoletosDataBaixa ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 A1069CarteiraDeCobrancaId ,
                                                 AV93Boletowwds_1_carteiradecobrancaid } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                                 TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                                 TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
            lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
            lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
            lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
            lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
            lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
            lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
            lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
            lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
            lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
            lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
            lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
            lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
            lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
            lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
            lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
            lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
            lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
            lV97Boletowwds_5_boletosnossonumero1 = StringUtil.Concat( StringUtil.RTrim( AV97Boletowwds_5_boletosnossonumero1), "%", "");
            lV97Boletowwds_5_boletosnossonumero1 = StringUtil.Concat( StringUtil.RTrim( AV97Boletowwds_5_boletosnossonumero1), "%", "");
            lV101Boletowwds_9_boletosnossonumero2 = StringUtil.Concat( StringUtil.RTrim( AV101Boletowwds_9_boletosnossonumero2), "%", "");
            lV101Boletowwds_9_boletosnossonumero2 = StringUtil.Concat( StringUtil.RTrim( AV101Boletowwds_9_boletosnossonumero2), "%", "");
            lV105Boletowwds_13_boletosnossonumero3 = StringUtil.Concat( StringUtil.RTrim( AV105Boletowwds_13_boletosnossonumero3), "%", "");
            lV105Boletowwds_13_boletosnossonumero3 = StringUtil.Concat( StringUtil.RTrim( AV105Boletowwds_13_boletosnossonumero3), "%", "");
            lV106Boletowwds_14_tfboletosnossonumero = StringUtil.Concat( StringUtil.RTrim( AV106Boletowwds_14_tfboletosnossonumero), "%", "");
            lV108Boletowwds_16_tfboletosseunumero = StringUtil.Concat( StringUtil.RTrim( AV108Boletowwds_16_tfboletosseunumero), "%", "");
            lV110Boletowwds_18_tfboletosnumero = StringUtil.Concat( StringUtil.RTrim( AV110Boletowwds_18_tfboletosnumero), "%", "");
            lV133Boletowwds_41_tfboletossacadonome = StringUtil.Concat( StringUtil.RTrim( AV133Boletowwds_41_tfboletossacadonome), "%", "");
            lV135Boletowwds_43_tfboletossacadodocumento = StringUtil.Concat( StringUtil.RTrim( AV135Boletowwds_43_tfboletossacadodocumento), "%", "");
            /* Using cursor H00A82 */
            pr_default.execute(0, new Object[] {AV93Boletowwds_1_carteiradecobrancaid, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV97Boletowwds_5_boletosnossonumero1, lV97Boletowwds_5_boletosnossonumero1, lV101Boletowwds_9_boletosnossonumero2, lV101Boletowwds_9_boletosnossonumero2, lV105Boletowwds_13_boletosnossonumero3, lV105Boletowwds_13_boletosnossonumero3, lV106Boletowwds_14_tfboletosnossonumero, AV107Boletowwds_15_tfboletosnossonumero_sel, lV108Boletowwds_16_tfboletosseunumero, AV109Boletowwds_17_tfboletosseunumero_sel, lV110Boletowwds_18_tfboletosnumero, AV111Boletowwds_19_tfboletosnumero_sel, AV113Boletowwds_21_tfboletosdataemissao, AV114Boletowwds_22_tfboletosdataemissao_to, AV115Boletowwds_23_tfboletosdatavencimento, AV116Boletowwds_24_tfboletosdatavencimento_to, AV117Boletowwds_25_tfboletosdataregistro, AV118Boletowwds_26_tfboletosdataregistro_to, AV119Boletowwds_27_tfboletosdatapagamento, AV120Boletowwds_28_tfboletosdatapagamento_to, AV121Boletowwds_29_tfboletosdatabaixa, AV122Boletowwds_30_tfboletosdatabaixa_to, AV123Boletowwds_31_tfboletosvalornominal, AV124Boletowwds_32_tfboletosvalornominal_to, AV125Boletowwds_33_tfboletosvalorpago, AV126Boletowwds_34_tfboletosvalorpago_to, AV127Boletowwds_35_tfboletosvalordesconto, AV128Boletowwds_36_tfboletosvalordesconto_to, AV129Boletowwds_37_tfboletosvalorjuros, AV130Boletowwds_38_tfboletosvalorjuros_to, AV131Boletowwds_39_tfboletosvalormulta, AV132Boletowwds_40_tfboletosvalormulta_to, lV133Boletowwds_41_tfboletossacadonome, AV134Boletowwds_42_tfboletossacadonome_sel, lV135Boletowwds_43_tfboletossacadodocumento, AV136Boletowwds_44_tfboletossacadodocumento_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_107_idx = 1;
            sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
            SubsflControlProps_1072( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A1096BoletosSacadoTipoDocumento = H00A82_A1096BoletosSacadoTipoDocumento[0];
               n1096BoletosSacadoTipoDocumento = H00A82_n1096BoletosSacadoTipoDocumento[0];
               A1095BoletosSacadoDocumento = H00A82_A1095BoletosSacadoDocumento[0];
               n1095BoletosSacadoDocumento = H00A82_n1095BoletosSacadoDocumento[0];
               A1094BoletosSacadoNome = H00A82_A1094BoletosSacadoNome[0];
               n1094BoletosSacadoNome = H00A82_n1094BoletosSacadoNome[0];
               A1093BoletosValorMulta = H00A82_A1093BoletosValorMulta[0];
               n1093BoletosValorMulta = H00A82_n1093BoletosValorMulta[0];
               A1092BoletosValorJuros = H00A82_A1092BoletosValorJuros[0];
               n1092BoletosValorJuros = H00A82_n1092BoletosValorJuros[0];
               A1091BoletosValorDesconto = H00A82_A1091BoletosValorDesconto[0];
               n1091BoletosValorDesconto = H00A82_n1091BoletosValorDesconto[0];
               A1090BoletosValorPago = H00A82_A1090BoletosValorPago[0];
               n1090BoletosValorPago = H00A82_n1090BoletosValorPago[0];
               A1089BoletosValorNominal = H00A82_A1089BoletosValorNominal[0];
               n1089BoletosValorNominal = H00A82_n1089BoletosValorNominal[0];
               A1088BoletosDataBaixa = H00A82_A1088BoletosDataBaixa[0];
               n1088BoletosDataBaixa = H00A82_n1088BoletosDataBaixa[0];
               A1087BoletosDataPagamento = H00A82_A1087BoletosDataPagamento[0];
               n1087BoletosDataPagamento = H00A82_n1087BoletosDataPagamento[0];
               A1086BoletosDataRegistro = H00A82_A1086BoletosDataRegistro[0];
               n1086BoletosDataRegistro = H00A82_n1086BoletosDataRegistro[0];
               A1085BoletosDataVencimento = H00A82_A1085BoletosDataVencimento[0];
               n1085BoletosDataVencimento = H00A82_n1085BoletosDataVencimento[0];
               A1084BoletosDataEmissao = H00A82_A1084BoletosDataEmissao[0];
               n1084BoletosDataEmissao = H00A82_n1084BoletosDataEmissao[0];
               A1083BoletosStatus = H00A82_A1083BoletosStatus[0];
               n1083BoletosStatus = H00A82_n1083BoletosStatus[0];
               A1082BoletosCodigoDeBarras = H00A82_A1082BoletosCodigoDeBarras[0];
               n1082BoletosCodigoDeBarras = H00A82_n1082BoletosCodigoDeBarras[0];
               A1081BoletosLinhaDigitavel = H00A82_A1081BoletosLinhaDigitavel[0];
               n1081BoletosLinhaDigitavel = H00A82_n1081BoletosLinhaDigitavel[0];
               A1080BoletosNumero = H00A82_A1080BoletosNumero[0];
               n1080BoletosNumero = H00A82_n1080BoletosNumero[0];
               A1079BoletosSeuNumero = H00A82_A1079BoletosSeuNumero[0];
               n1079BoletosSeuNumero = H00A82_n1079BoletosSeuNumero[0];
               A1078BoletosNossoNumero = H00A82_A1078BoletosNossoNumero[0];
               n1078BoletosNossoNumero = H00A82_n1078BoletosNossoNumero[0];
               A261TituloId = H00A82_A261TituloId[0];
               n261TituloId = H00A82_n261TituloId[0];
               A1069CarteiraDeCobrancaId = H00A82_A1069CarteiraDeCobrancaId[0];
               n1069CarteiraDeCobrancaId = H00A82_n1069CarteiraDeCobrancaId[0];
               A1077BoletosId = H00A82_A1077BoletosId[0];
               /* Execute user event: Grid.Load */
               E27A82 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 107;
            WBA80( ) ;
         }
         bGXsfl_107_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesA82( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV92Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV92Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_BOLETOSID"+"_"+sGXsfl_107_idx, GetSecureSignedToken( sGXsfl_107_idx, context.localUtil.Format( (decimal)(A1077BoletosId), "ZZZZZZZZ9"), context));
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
         AV93Boletowwds_1_carteiradecobrancaid = AV91CarteiraDeCobrancaId;
         AV94Boletowwds_2_filterfulltext = AV15FilterFullText;
         AV95Boletowwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV96Boletowwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV97Boletowwds_5_boletosnossonumero1 = AV18BoletosNossoNumero1;
         AV98Boletowwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV99Boletowwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV100Boletowwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV101Boletowwds_9_boletosnossonumero2 = AV22BoletosNossoNumero2;
         AV102Boletowwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV103Boletowwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV104Boletowwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV105Boletowwds_13_boletosnossonumero3 = AV26BoletosNossoNumero3;
         AV106Boletowwds_14_tfboletosnossonumero = AV35TFBoletosNossoNumero;
         AV107Boletowwds_15_tfboletosnossonumero_sel = AV36TFBoletosNossoNumero_Sel;
         AV108Boletowwds_16_tfboletosseunumero = AV37TFBoletosSeuNumero;
         AV109Boletowwds_17_tfboletosseunumero_sel = AV38TFBoletosSeuNumero_Sel;
         AV110Boletowwds_18_tfboletosnumero = AV39TFBoletosNumero;
         AV111Boletowwds_19_tfboletosnumero_sel = AV40TFBoletosNumero_Sel;
         AV112Boletowwds_20_tfboletosstatus_sels = AV42TFBoletosStatus_Sels;
         AV113Boletowwds_21_tfboletosdataemissao = AV43TFBoletosDataEmissao;
         AV114Boletowwds_22_tfboletosdataemissao_to = AV44TFBoletosDataEmissao_To;
         AV115Boletowwds_23_tfboletosdatavencimento = AV48TFBoletosDataVencimento;
         AV116Boletowwds_24_tfboletosdatavencimento_to = AV49TFBoletosDataVencimento_To;
         AV117Boletowwds_25_tfboletosdataregistro = AV53TFBoletosDataRegistro;
         AV118Boletowwds_26_tfboletosdataregistro_to = AV54TFBoletosDataRegistro_To;
         AV119Boletowwds_27_tfboletosdatapagamento = AV58TFBoletosDataPagamento;
         AV120Boletowwds_28_tfboletosdatapagamento_to = AV59TFBoletosDataPagamento_To;
         AV121Boletowwds_29_tfboletosdatabaixa = AV63TFBoletosDataBaixa;
         AV122Boletowwds_30_tfboletosdatabaixa_to = AV64TFBoletosDataBaixa_To;
         AV123Boletowwds_31_tfboletosvalornominal = AV68TFBoletosValorNominal;
         AV124Boletowwds_32_tfboletosvalornominal_to = AV69TFBoletosValorNominal_To;
         AV125Boletowwds_33_tfboletosvalorpago = AV70TFBoletosValorPago;
         AV126Boletowwds_34_tfboletosvalorpago_to = AV71TFBoletosValorPago_To;
         AV127Boletowwds_35_tfboletosvalordesconto = AV72TFBoletosValorDesconto;
         AV128Boletowwds_36_tfboletosvalordesconto_to = AV73TFBoletosValorDesconto_To;
         AV129Boletowwds_37_tfboletosvalorjuros = AV74TFBoletosValorJuros;
         AV130Boletowwds_38_tfboletosvalorjuros_to = AV75TFBoletosValorJuros_To;
         AV131Boletowwds_39_tfboletosvalormulta = AV76TFBoletosValorMulta;
         AV132Boletowwds_40_tfboletosvalormulta_to = AV77TFBoletosValorMulta_To;
         AV133Boletowwds_41_tfboletossacadonome = AV78TFBoletosSacadoNome;
         AV134Boletowwds_42_tfboletossacadonome_sel = AV79TFBoletosSacadoNome_Sel;
         AV135Boletowwds_43_tfboletossacadodocumento = AV80TFBoletosSacadoDocumento;
         AV136Boletowwds_44_tfboletossacadodocumento_sel = AV81TFBoletosSacadoDocumento_Sel;
         AV137Boletowwds_45_tfboletossacadotipodocumento_sels = AV83TFBoletosSacadoTipoDocumento_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1083BoletosStatus ,
                                              AV112Boletowwds_20_tfboletosstatus_sels ,
                                              A1096BoletosSacadoTipoDocumento ,
                                              AV137Boletowwds_45_tfboletossacadotipodocumento_sels ,
                                              AV94Boletowwds_2_filterfulltext ,
                                              AV95Boletowwds_3_dynamicfiltersselector1 ,
                                              AV96Boletowwds_4_dynamicfiltersoperator1 ,
                                              AV97Boletowwds_5_boletosnossonumero1 ,
                                              AV98Boletowwds_6_dynamicfiltersenabled2 ,
                                              AV99Boletowwds_7_dynamicfiltersselector2 ,
                                              AV100Boletowwds_8_dynamicfiltersoperator2 ,
                                              AV101Boletowwds_9_boletosnossonumero2 ,
                                              AV102Boletowwds_10_dynamicfiltersenabled3 ,
                                              AV103Boletowwds_11_dynamicfiltersselector3 ,
                                              AV104Boletowwds_12_dynamicfiltersoperator3 ,
                                              AV105Boletowwds_13_boletosnossonumero3 ,
                                              AV107Boletowwds_15_tfboletosnossonumero_sel ,
                                              AV106Boletowwds_14_tfboletosnossonumero ,
                                              AV109Boletowwds_17_tfboletosseunumero_sel ,
                                              AV108Boletowwds_16_tfboletosseunumero ,
                                              AV111Boletowwds_19_tfboletosnumero_sel ,
                                              AV110Boletowwds_18_tfboletosnumero ,
                                              AV112Boletowwds_20_tfboletosstatus_sels.Count ,
                                              AV113Boletowwds_21_tfboletosdataemissao ,
                                              AV114Boletowwds_22_tfboletosdataemissao_to ,
                                              AV115Boletowwds_23_tfboletosdatavencimento ,
                                              AV116Boletowwds_24_tfboletosdatavencimento_to ,
                                              AV117Boletowwds_25_tfboletosdataregistro ,
                                              AV118Boletowwds_26_tfboletosdataregistro_to ,
                                              AV119Boletowwds_27_tfboletosdatapagamento ,
                                              AV120Boletowwds_28_tfboletosdatapagamento_to ,
                                              AV121Boletowwds_29_tfboletosdatabaixa ,
                                              AV122Boletowwds_30_tfboletosdatabaixa_to ,
                                              AV123Boletowwds_31_tfboletosvalornominal ,
                                              AV124Boletowwds_32_tfboletosvalornominal_to ,
                                              AV125Boletowwds_33_tfboletosvalorpago ,
                                              AV126Boletowwds_34_tfboletosvalorpago_to ,
                                              AV127Boletowwds_35_tfboletosvalordesconto ,
                                              AV128Boletowwds_36_tfboletosvalordesconto_to ,
                                              AV129Boletowwds_37_tfboletosvalorjuros ,
                                              AV130Boletowwds_38_tfboletosvalorjuros_to ,
                                              AV131Boletowwds_39_tfboletosvalormulta ,
                                              AV132Boletowwds_40_tfboletosvalormulta_to ,
                                              AV134Boletowwds_42_tfboletossacadonome_sel ,
                                              AV133Boletowwds_41_tfboletossacadonome ,
                                              AV136Boletowwds_44_tfboletossacadodocumento_sel ,
                                              AV135Boletowwds_43_tfboletossacadodocumento ,
                                              AV137Boletowwds_45_tfboletossacadotipodocumento_sels.Count ,
                                              A1078BoletosNossoNumero ,
                                              A1079BoletosSeuNumero ,
                                              A1080BoletosNumero ,
                                              A1089BoletosValorNominal ,
                                              A1090BoletosValorPago ,
                                              A1091BoletosValorDesconto ,
                                              A1092BoletosValorJuros ,
                                              A1093BoletosValorMulta ,
                                              A1094BoletosSacadoNome ,
                                              A1095BoletosSacadoDocumento ,
                                              A1084BoletosDataEmissao ,
                                              A1085BoletosDataVencimento ,
                                              A1086BoletosDataRegistro ,
                                              A1087BoletosDataPagamento ,
                                              A1088BoletosDataBaixa ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              A1069CarteiraDeCobrancaId ,
                                              AV93Boletowwds_1_carteiradecobrancaid } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
         lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
         lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
         lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
         lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
         lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
         lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
         lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
         lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
         lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
         lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
         lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
         lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
         lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
         lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
         lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
         lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
         lV94Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV94Boletowwds_2_filterfulltext), "%", "");
         lV97Boletowwds_5_boletosnossonumero1 = StringUtil.Concat( StringUtil.RTrim( AV97Boletowwds_5_boletosnossonumero1), "%", "");
         lV97Boletowwds_5_boletosnossonumero1 = StringUtil.Concat( StringUtil.RTrim( AV97Boletowwds_5_boletosnossonumero1), "%", "");
         lV101Boletowwds_9_boletosnossonumero2 = StringUtil.Concat( StringUtil.RTrim( AV101Boletowwds_9_boletosnossonumero2), "%", "");
         lV101Boletowwds_9_boletosnossonumero2 = StringUtil.Concat( StringUtil.RTrim( AV101Boletowwds_9_boletosnossonumero2), "%", "");
         lV105Boletowwds_13_boletosnossonumero3 = StringUtil.Concat( StringUtil.RTrim( AV105Boletowwds_13_boletosnossonumero3), "%", "");
         lV105Boletowwds_13_boletosnossonumero3 = StringUtil.Concat( StringUtil.RTrim( AV105Boletowwds_13_boletosnossonumero3), "%", "");
         lV106Boletowwds_14_tfboletosnossonumero = StringUtil.Concat( StringUtil.RTrim( AV106Boletowwds_14_tfboletosnossonumero), "%", "");
         lV108Boletowwds_16_tfboletosseunumero = StringUtil.Concat( StringUtil.RTrim( AV108Boletowwds_16_tfboletosseunumero), "%", "");
         lV110Boletowwds_18_tfboletosnumero = StringUtil.Concat( StringUtil.RTrim( AV110Boletowwds_18_tfboletosnumero), "%", "");
         lV133Boletowwds_41_tfboletossacadonome = StringUtil.Concat( StringUtil.RTrim( AV133Boletowwds_41_tfboletossacadonome), "%", "");
         lV135Boletowwds_43_tfboletossacadodocumento = StringUtil.Concat( StringUtil.RTrim( AV135Boletowwds_43_tfboletossacadodocumento), "%", "");
         /* Using cursor H00A83 */
         pr_default.execute(1, new Object[] {AV93Boletowwds_1_carteiradecobrancaid, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV94Boletowwds_2_filterfulltext, lV97Boletowwds_5_boletosnossonumero1, lV97Boletowwds_5_boletosnossonumero1, lV101Boletowwds_9_boletosnossonumero2, lV101Boletowwds_9_boletosnossonumero2, lV105Boletowwds_13_boletosnossonumero3, lV105Boletowwds_13_boletosnossonumero3, lV106Boletowwds_14_tfboletosnossonumero, AV107Boletowwds_15_tfboletosnossonumero_sel, lV108Boletowwds_16_tfboletosseunumero, AV109Boletowwds_17_tfboletosseunumero_sel, lV110Boletowwds_18_tfboletosnumero, AV111Boletowwds_19_tfboletosnumero_sel, AV113Boletowwds_21_tfboletosdataemissao, AV114Boletowwds_22_tfboletosdataemissao_to, AV115Boletowwds_23_tfboletosdatavencimento, AV116Boletowwds_24_tfboletosdatavencimento_to, AV117Boletowwds_25_tfboletosdataregistro, AV118Boletowwds_26_tfboletosdataregistro_to, AV119Boletowwds_27_tfboletosdatapagamento, AV120Boletowwds_28_tfboletosdatapagamento_to, AV121Boletowwds_29_tfboletosdatabaixa, AV122Boletowwds_30_tfboletosdatabaixa_to, AV123Boletowwds_31_tfboletosvalornominal, AV124Boletowwds_32_tfboletosvalornominal_to, AV125Boletowwds_33_tfboletosvalorpago, AV126Boletowwds_34_tfboletosvalorpago_to, AV127Boletowwds_35_tfboletosvalordesconto, AV128Boletowwds_36_tfboletosvalordesconto_to, AV129Boletowwds_37_tfboletosvalorjuros, AV130Boletowwds_38_tfboletosvalorjuros_to, AV131Boletowwds_39_tfboletosvalormulta, AV132Boletowwds_40_tfboletosvalormulta_to, lV133Boletowwds_41_tfboletossacadonome, AV134Boletowwds_42_tfboletossacadonome_sel, lV135Boletowwds_43_tfboletossacadodocumento, AV136Boletowwds_44_tfboletossacadodocumento_sel});
         GRID_nRecordCount = H00A83_AGRID_nRecordCount[0];
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
         AV93Boletowwds_1_carteiradecobrancaid = AV91CarteiraDeCobrancaId;
         AV94Boletowwds_2_filterfulltext = AV15FilterFullText;
         AV95Boletowwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV96Boletowwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV97Boletowwds_5_boletosnossonumero1 = AV18BoletosNossoNumero1;
         AV98Boletowwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV99Boletowwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV100Boletowwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV101Boletowwds_9_boletosnossonumero2 = AV22BoletosNossoNumero2;
         AV102Boletowwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV103Boletowwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV104Boletowwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV105Boletowwds_13_boletosnossonumero3 = AV26BoletosNossoNumero3;
         AV106Boletowwds_14_tfboletosnossonumero = AV35TFBoletosNossoNumero;
         AV107Boletowwds_15_tfboletosnossonumero_sel = AV36TFBoletosNossoNumero_Sel;
         AV108Boletowwds_16_tfboletosseunumero = AV37TFBoletosSeuNumero;
         AV109Boletowwds_17_tfboletosseunumero_sel = AV38TFBoletosSeuNumero_Sel;
         AV110Boletowwds_18_tfboletosnumero = AV39TFBoletosNumero;
         AV111Boletowwds_19_tfboletosnumero_sel = AV40TFBoletosNumero_Sel;
         AV112Boletowwds_20_tfboletosstatus_sels = AV42TFBoletosStatus_Sels;
         AV113Boletowwds_21_tfboletosdataemissao = AV43TFBoletosDataEmissao;
         AV114Boletowwds_22_tfboletosdataemissao_to = AV44TFBoletosDataEmissao_To;
         AV115Boletowwds_23_tfboletosdatavencimento = AV48TFBoletosDataVencimento;
         AV116Boletowwds_24_tfboletosdatavencimento_to = AV49TFBoletosDataVencimento_To;
         AV117Boletowwds_25_tfboletosdataregistro = AV53TFBoletosDataRegistro;
         AV118Boletowwds_26_tfboletosdataregistro_to = AV54TFBoletosDataRegistro_To;
         AV119Boletowwds_27_tfboletosdatapagamento = AV58TFBoletosDataPagamento;
         AV120Boletowwds_28_tfboletosdatapagamento_to = AV59TFBoletosDataPagamento_To;
         AV121Boletowwds_29_tfboletosdatabaixa = AV63TFBoletosDataBaixa;
         AV122Boletowwds_30_tfboletosdatabaixa_to = AV64TFBoletosDataBaixa_To;
         AV123Boletowwds_31_tfboletosvalornominal = AV68TFBoletosValorNominal;
         AV124Boletowwds_32_tfboletosvalornominal_to = AV69TFBoletosValorNominal_To;
         AV125Boletowwds_33_tfboletosvalorpago = AV70TFBoletosValorPago;
         AV126Boletowwds_34_tfboletosvalorpago_to = AV71TFBoletosValorPago_To;
         AV127Boletowwds_35_tfboletosvalordesconto = AV72TFBoletosValorDesconto;
         AV128Boletowwds_36_tfboletosvalordesconto_to = AV73TFBoletosValorDesconto_To;
         AV129Boletowwds_37_tfboletosvalorjuros = AV74TFBoletosValorJuros;
         AV130Boletowwds_38_tfboletosvalorjuros_to = AV75TFBoletosValorJuros_To;
         AV131Boletowwds_39_tfboletosvalormulta = AV76TFBoletosValorMulta;
         AV132Boletowwds_40_tfboletosvalormulta_to = AV77TFBoletosValorMulta_To;
         AV133Boletowwds_41_tfboletossacadonome = AV78TFBoletosSacadoNome;
         AV134Boletowwds_42_tfboletossacadonome_sel = AV79TFBoletosSacadoNome_Sel;
         AV135Boletowwds_43_tfboletossacadodocumento = AV80TFBoletosSacadoDocumento;
         AV136Boletowwds_44_tfboletossacadodocumento_sel = AV81TFBoletosSacadoDocumento_Sel;
         AV137Boletowwds_45_tfboletossacadotipodocumento_sels = AV83TFBoletosSacadoTipoDocumento_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18BoletosNossoNumero1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22BoletosNossoNumero2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26BoletosNossoNumero3, AV34ManageFiltersExecutionStep, AV92Pgmname, AV91CarteiraDeCobrancaId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFBoletosNossoNumero, AV36TFBoletosNossoNumero_Sel, AV37TFBoletosSeuNumero, AV38TFBoletosSeuNumero_Sel, AV39TFBoletosNumero, AV40TFBoletosNumero_Sel, AV42TFBoletosStatus_Sels, AV43TFBoletosDataEmissao, AV44TFBoletosDataEmissao_To, AV48TFBoletosDataVencimento, AV49TFBoletosDataVencimento_To, AV53TFBoletosDataRegistro, AV54TFBoletosDataRegistro_To, AV58TFBoletosDataPagamento, AV59TFBoletosDataPagamento_To, AV63TFBoletosDataBaixa, AV64TFBoletosDataBaixa_To, AV68TFBoletosValorNominal, AV69TFBoletosValorNominal_To, AV70TFBoletosValorPago, AV71TFBoletosValorPago_To, AV72TFBoletosValorDesconto, AV73TFBoletosValorDesconto_To, AV74TFBoletosValorJuros, AV75TFBoletosValorJuros_To, AV76TFBoletosValorMulta, AV77TFBoletosValorMulta_To, AV78TFBoletosSacadoNome, AV79TFBoletosSacadoNome_Sel, AV80TFBoletosSacadoDocumento, AV81TFBoletosSacadoDocumento_Sel, AV83TFBoletosSacadoTipoDocumento_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV93Boletowwds_1_carteiradecobrancaid = AV91CarteiraDeCobrancaId;
         AV94Boletowwds_2_filterfulltext = AV15FilterFullText;
         AV95Boletowwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV96Boletowwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV97Boletowwds_5_boletosnossonumero1 = AV18BoletosNossoNumero1;
         AV98Boletowwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV99Boletowwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV100Boletowwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV101Boletowwds_9_boletosnossonumero2 = AV22BoletosNossoNumero2;
         AV102Boletowwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV103Boletowwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV104Boletowwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV105Boletowwds_13_boletosnossonumero3 = AV26BoletosNossoNumero3;
         AV106Boletowwds_14_tfboletosnossonumero = AV35TFBoletosNossoNumero;
         AV107Boletowwds_15_tfboletosnossonumero_sel = AV36TFBoletosNossoNumero_Sel;
         AV108Boletowwds_16_tfboletosseunumero = AV37TFBoletosSeuNumero;
         AV109Boletowwds_17_tfboletosseunumero_sel = AV38TFBoletosSeuNumero_Sel;
         AV110Boletowwds_18_tfboletosnumero = AV39TFBoletosNumero;
         AV111Boletowwds_19_tfboletosnumero_sel = AV40TFBoletosNumero_Sel;
         AV112Boletowwds_20_tfboletosstatus_sels = AV42TFBoletosStatus_Sels;
         AV113Boletowwds_21_tfboletosdataemissao = AV43TFBoletosDataEmissao;
         AV114Boletowwds_22_tfboletosdataemissao_to = AV44TFBoletosDataEmissao_To;
         AV115Boletowwds_23_tfboletosdatavencimento = AV48TFBoletosDataVencimento;
         AV116Boletowwds_24_tfboletosdatavencimento_to = AV49TFBoletosDataVencimento_To;
         AV117Boletowwds_25_tfboletosdataregistro = AV53TFBoletosDataRegistro;
         AV118Boletowwds_26_tfboletosdataregistro_to = AV54TFBoletosDataRegistro_To;
         AV119Boletowwds_27_tfboletosdatapagamento = AV58TFBoletosDataPagamento;
         AV120Boletowwds_28_tfboletosdatapagamento_to = AV59TFBoletosDataPagamento_To;
         AV121Boletowwds_29_tfboletosdatabaixa = AV63TFBoletosDataBaixa;
         AV122Boletowwds_30_tfboletosdatabaixa_to = AV64TFBoletosDataBaixa_To;
         AV123Boletowwds_31_tfboletosvalornominal = AV68TFBoletosValorNominal;
         AV124Boletowwds_32_tfboletosvalornominal_to = AV69TFBoletosValorNominal_To;
         AV125Boletowwds_33_tfboletosvalorpago = AV70TFBoletosValorPago;
         AV126Boletowwds_34_tfboletosvalorpago_to = AV71TFBoletosValorPago_To;
         AV127Boletowwds_35_tfboletosvalordesconto = AV72TFBoletosValorDesconto;
         AV128Boletowwds_36_tfboletosvalordesconto_to = AV73TFBoletosValorDesconto_To;
         AV129Boletowwds_37_tfboletosvalorjuros = AV74TFBoletosValorJuros;
         AV130Boletowwds_38_tfboletosvalorjuros_to = AV75TFBoletosValorJuros_To;
         AV131Boletowwds_39_tfboletosvalormulta = AV76TFBoletosValorMulta;
         AV132Boletowwds_40_tfboletosvalormulta_to = AV77TFBoletosValorMulta_To;
         AV133Boletowwds_41_tfboletossacadonome = AV78TFBoletosSacadoNome;
         AV134Boletowwds_42_tfboletossacadonome_sel = AV79TFBoletosSacadoNome_Sel;
         AV135Boletowwds_43_tfboletossacadodocumento = AV80TFBoletosSacadoDocumento;
         AV136Boletowwds_44_tfboletossacadodocumento_sel = AV81TFBoletosSacadoDocumento_Sel;
         AV137Boletowwds_45_tfboletossacadotipodocumento_sels = AV83TFBoletosSacadoTipoDocumento_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18BoletosNossoNumero1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22BoletosNossoNumero2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26BoletosNossoNumero3, AV34ManageFiltersExecutionStep, AV92Pgmname, AV91CarteiraDeCobrancaId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFBoletosNossoNumero, AV36TFBoletosNossoNumero_Sel, AV37TFBoletosSeuNumero, AV38TFBoletosSeuNumero_Sel, AV39TFBoletosNumero, AV40TFBoletosNumero_Sel, AV42TFBoletosStatus_Sels, AV43TFBoletosDataEmissao, AV44TFBoletosDataEmissao_To, AV48TFBoletosDataVencimento, AV49TFBoletosDataVencimento_To, AV53TFBoletosDataRegistro, AV54TFBoletosDataRegistro_To, AV58TFBoletosDataPagamento, AV59TFBoletosDataPagamento_To, AV63TFBoletosDataBaixa, AV64TFBoletosDataBaixa_To, AV68TFBoletosValorNominal, AV69TFBoletosValorNominal_To, AV70TFBoletosValorPago, AV71TFBoletosValorPago_To, AV72TFBoletosValorDesconto, AV73TFBoletosValorDesconto_To, AV74TFBoletosValorJuros, AV75TFBoletosValorJuros_To, AV76TFBoletosValorMulta, AV77TFBoletosValorMulta_To, AV78TFBoletosSacadoNome, AV79TFBoletosSacadoNome_Sel, AV80TFBoletosSacadoDocumento, AV81TFBoletosSacadoDocumento_Sel, AV83TFBoletosSacadoTipoDocumento_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV93Boletowwds_1_carteiradecobrancaid = AV91CarteiraDeCobrancaId;
         AV94Boletowwds_2_filterfulltext = AV15FilterFullText;
         AV95Boletowwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV96Boletowwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV97Boletowwds_5_boletosnossonumero1 = AV18BoletosNossoNumero1;
         AV98Boletowwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV99Boletowwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV100Boletowwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV101Boletowwds_9_boletosnossonumero2 = AV22BoletosNossoNumero2;
         AV102Boletowwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV103Boletowwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV104Boletowwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV105Boletowwds_13_boletosnossonumero3 = AV26BoletosNossoNumero3;
         AV106Boletowwds_14_tfboletosnossonumero = AV35TFBoletosNossoNumero;
         AV107Boletowwds_15_tfboletosnossonumero_sel = AV36TFBoletosNossoNumero_Sel;
         AV108Boletowwds_16_tfboletosseunumero = AV37TFBoletosSeuNumero;
         AV109Boletowwds_17_tfboletosseunumero_sel = AV38TFBoletosSeuNumero_Sel;
         AV110Boletowwds_18_tfboletosnumero = AV39TFBoletosNumero;
         AV111Boletowwds_19_tfboletosnumero_sel = AV40TFBoletosNumero_Sel;
         AV112Boletowwds_20_tfboletosstatus_sels = AV42TFBoletosStatus_Sels;
         AV113Boletowwds_21_tfboletosdataemissao = AV43TFBoletosDataEmissao;
         AV114Boletowwds_22_tfboletosdataemissao_to = AV44TFBoletosDataEmissao_To;
         AV115Boletowwds_23_tfboletosdatavencimento = AV48TFBoletosDataVencimento;
         AV116Boletowwds_24_tfboletosdatavencimento_to = AV49TFBoletosDataVencimento_To;
         AV117Boletowwds_25_tfboletosdataregistro = AV53TFBoletosDataRegistro;
         AV118Boletowwds_26_tfboletosdataregistro_to = AV54TFBoletosDataRegistro_To;
         AV119Boletowwds_27_tfboletosdatapagamento = AV58TFBoletosDataPagamento;
         AV120Boletowwds_28_tfboletosdatapagamento_to = AV59TFBoletosDataPagamento_To;
         AV121Boletowwds_29_tfboletosdatabaixa = AV63TFBoletosDataBaixa;
         AV122Boletowwds_30_tfboletosdatabaixa_to = AV64TFBoletosDataBaixa_To;
         AV123Boletowwds_31_tfboletosvalornominal = AV68TFBoletosValorNominal;
         AV124Boletowwds_32_tfboletosvalornominal_to = AV69TFBoletosValorNominal_To;
         AV125Boletowwds_33_tfboletosvalorpago = AV70TFBoletosValorPago;
         AV126Boletowwds_34_tfboletosvalorpago_to = AV71TFBoletosValorPago_To;
         AV127Boletowwds_35_tfboletosvalordesconto = AV72TFBoletosValorDesconto;
         AV128Boletowwds_36_tfboletosvalordesconto_to = AV73TFBoletosValorDesconto_To;
         AV129Boletowwds_37_tfboletosvalorjuros = AV74TFBoletosValorJuros;
         AV130Boletowwds_38_tfboletosvalorjuros_to = AV75TFBoletosValorJuros_To;
         AV131Boletowwds_39_tfboletosvalormulta = AV76TFBoletosValorMulta;
         AV132Boletowwds_40_tfboletosvalormulta_to = AV77TFBoletosValorMulta_To;
         AV133Boletowwds_41_tfboletossacadonome = AV78TFBoletosSacadoNome;
         AV134Boletowwds_42_tfboletossacadonome_sel = AV79TFBoletosSacadoNome_Sel;
         AV135Boletowwds_43_tfboletossacadodocumento = AV80TFBoletosSacadoDocumento;
         AV136Boletowwds_44_tfboletossacadodocumento_sel = AV81TFBoletosSacadoDocumento_Sel;
         AV137Boletowwds_45_tfboletossacadotipodocumento_sels = AV83TFBoletosSacadoTipoDocumento_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18BoletosNossoNumero1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22BoletosNossoNumero2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26BoletosNossoNumero3, AV34ManageFiltersExecutionStep, AV92Pgmname, AV91CarteiraDeCobrancaId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFBoletosNossoNumero, AV36TFBoletosNossoNumero_Sel, AV37TFBoletosSeuNumero, AV38TFBoletosSeuNumero_Sel, AV39TFBoletosNumero, AV40TFBoletosNumero_Sel, AV42TFBoletosStatus_Sels, AV43TFBoletosDataEmissao, AV44TFBoletosDataEmissao_To, AV48TFBoletosDataVencimento, AV49TFBoletosDataVencimento_To, AV53TFBoletosDataRegistro, AV54TFBoletosDataRegistro_To, AV58TFBoletosDataPagamento, AV59TFBoletosDataPagamento_To, AV63TFBoletosDataBaixa, AV64TFBoletosDataBaixa_To, AV68TFBoletosValorNominal, AV69TFBoletosValorNominal_To, AV70TFBoletosValorPago, AV71TFBoletosValorPago_To, AV72TFBoletosValorDesconto, AV73TFBoletosValorDesconto_To, AV74TFBoletosValorJuros, AV75TFBoletosValorJuros_To, AV76TFBoletosValorMulta, AV77TFBoletosValorMulta_To, AV78TFBoletosSacadoNome, AV79TFBoletosSacadoNome_Sel, AV80TFBoletosSacadoDocumento, AV81TFBoletosSacadoDocumento_Sel, AV83TFBoletosSacadoTipoDocumento_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV93Boletowwds_1_carteiradecobrancaid = AV91CarteiraDeCobrancaId;
         AV94Boletowwds_2_filterfulltext = AV15FilterFullText;
         AV95Boletowwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV96Boletowwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV97Boletowwds_5_boletosnossonumero1 = AV18BoletosNossoNumero1;
         AV98Boletowwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV99Boletowwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV100Boletowwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV101Boletowwds_9_boletosnossonumero2 = AV22BoletosNossoNumero2;
         AV102Boletowwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV103Boletowwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV104Boletowwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV105Boletowwds_13_boletosnossonumero3 = AV26BoletosNossoNumero3;
         AV106Boletowwds_14_tfboletosnossonumero = AV35TFBoletosNossoNumero;
         AV107Boletowwds_15_tfboletosnossonumero_sel = AV36TFBoletosNossoNumero_Sel;
         AV108Boletowwds_16_tfboletosseunumero = AV37TFBoletosSeuNumero;
         AV109Boletowwds_17_tfboletosseunumero_sel = AV38TFBoletosSeuNumero_Sel;
         AV110Boletowwds_18_tfboletosnumero = AV39TFBoletosNumero;
         AV111Boletowwds_19_tfboletosnumero_sel = AV40TFBoletosNumero_Sel;
         AV112Boletowwds_20_tfboletosstatus_sels = AV42TFBoletosStatus_Sels;
         AV113Boletowwds_21_tfboletosdataemissao = AV43TFBoletosDataEmissao;
         AV114Boletowwds_22_tfboletosdataemissao_to = AV44TFBoletosDataEmissao_To;
         AV115Boletowwds_23_tfboletosdatavencimento = AV48TFBoletosDataVencimento;
         AV116Boletowwds_24_tfboletosdatavencimento_to = AV49TFBoletosDataVencimento_To;
         AV117Boletowwds_25_tfboletosdataregistro = AV53TFBoletosDataRegistro;
         AV118Boletowwds_26_tfboletosdataregistro_to = AV54TFBoletosDataRegistro_To;
         AV119Boletowwds_27_tfboletosdatapagamento = AV58TFBoletosDataPagamento;
         AV120Boletowwds_28_tfboletosdatapagamento_to = AV59TFBoletosDataPagamento_To;
         AV121Boletowwds_29_tfboletosdatabaixa = AV63TFBoletosDataBaixa;
         AV122Boletowwds_30_tfboletosdatabaixa_to = AV64TFBoletosDataBaixa_To;
         AV123Boletowwds_31_tfboletosvalornominal = AV68TFBoletosValorNominal;
         AV124Boletowwds_32_tfboletosvalornominal_to = AV69TFBoletosValorNominal_To;
         AV125Boletowwds_33_tfboletosvalorpago = AV70TFBoletosValorPago;
         AV126Boletowwds_34_tfboletosvalorpago_to = AV71TFBoletosValorPago_To;
         AV127Boletowwds_35_tfboletosvalordesconto = AV72TFBoletosValorDesconto;
         AV128Boletowwds_36_tfboletosvalordesconto_to = AV73TFBoletosValorDesconto_To;
         AV129Boletowwds_37_tfboletosvalorjuros = AV74TFBoletosValorJuros;
         AV130Boletowwds_38_tfboletosvalorjuros_to = AV75TFBoletosValorJuros_To;
         AV131Boletowwds_39_tfboletosvalormulta = AV76TFBoletosValorMulta;
         AV132Boletowwds_40_tfboletosvalormulta_to = AV77TFBoletosValorMulta_To;
         AV133Boletowwds_41_tfboletossacadonome = AV78TFBoletosSacadoNome;
         AV134Boletowwds_42_tfboletossacadonome_sel = AV79TFBoletosSacadoNome_Sel;
         AV135Boletowwds_43_tfboletossacadodocumento = AV80TFBoletosSacadoDocumento;
         AV136Boletowwds_44_tfboletossacadodocumento_sel = AV81TFBoletosSacadoDocumento_Sel;
         AV137Boletowwds_45_tfboletossacadotipodocumento_sels = AV83TFBoletosSacadoTipoDocumento_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18BoletosNossoNumero1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22BoletosNossoNumero2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26BoletosNossoNumero3, AV34ManageFiltersExecutionStep, AV92Pgmname, AV91CarteiraDeCobrancaId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFBoletosNossoNumero, AV36TFBoletosNossoNumero_Sel, AV37TFBoletosSeuNumero, AV38TFBoletosSeuNumero_Sel, AV39TFBoletosNumero, AV40TFBoletosNumero_Sel, AV42TFBoletosStatus_Sels, AV43TFBoletosDataEmissao, AV44TFBoletosDataEmissao_To, AV48TFBoletosDataVencimento, AV49TFBoletosDataVencimento_To, AV53TFBoletosDataRegistro, AV54TFBoletosDataRegistro_To, AV58TFBoletosDataPagamento, AV59TFBoletosDataPagamento_To, AV63TFBoletosDataBaixa, AV64TFBoletosDataBaixa_To, AV68TFBoletosValorNominal, AV69TFBoletosValorNominal_To, AV70TFBoletosValorPago, AV71TFBoletosValorPago_To, AV72TFBoletosValorDesconto, AV73TFBoletosValorDesconto_To, AV74TFBoletosValorJuros, AV75TFBoletosValorJuros_To, AV76TFBoletosValorMulta, AV77TFBoletosValorMulta_To, AV78TFBoletosSacadoNome, AV79TFBoletosSacadoNome_Sel, AV80TFBoletosSacadoDocumento, AV81TFBoletosSacadoDocumento_Sel, AV83TFBoletosSacadoTipoDocumento_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV93Boletowwds_1_carteiradecobrancaid = AV91CarteiraDeCobrancaId;
         AV94Boletowwds_2_filterfulltext = AV15FilterFullText;
         AV95Boletowwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV96Boletowwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV97Boletowwds_5_boletosnossonumero1 = AV18BoletosNossoNumero1;
         AV98Boletowwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV99Boletowwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV100Boletowwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV101Boletowwds_9_boletosnossonumero2 = AV22BoletosNossoNumero2;
         AV102Boletowwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV103Boletowwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV104Boletowwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV105Boletowwds_13_boletosnossonumero3 = AV26BoletosNossoNumero3;
         AV106Boletowwds_14_tfboletosnossonumero = AV35TFBoletosNossoNumero;
         AV107Boletowwds_15_tfboletosnossonumero_sel = AV36TFBoletosNossoNumero_Sel;
         AV108Boletowwds_16_tfboletosseunumero = AV37TFBoletosSeuNumero;
         AV109Boletowwds_17_tfboletosseunumero_sel = AV38TFBoletosSeuNumero_Sel;
         AV110Boletowwds_18_tfboletosnumero = AV39TFBoletosNumero;
         AV111Boletowwds_19_tfboletosnumero_sel = AV40TFBoletosNumero_Sel;
         AV112Boletowwds_20_tfboletosstatus_sels = AV42TFBoletosStatus_Sels;
         AV113Boletowwds_21_tfboletosdataemissao = AV43TFBoletosDataEmissao;
         AV114Boletowwds_22_tfboletosdataemissao_to = AV44TFBoletosDataEmissao_To;
         AV115Boletowwds_23_tfboletosdatavencimento = AV48TFBoletosDataVencimento;
         AV116Boletowwds_24_tfboletosdatavencimento_to = AV49TFBoletosDataVencimento_To;
         AV117Boletowwds_25_tfboletosdataregistro = AV53TFBoletosDataRegistro;
         AV118Boletowwds_26_tfboletosdataregistro_to = AV54TFBoletosDataRegistro_To;
         AV119Boletowwds_27_tfboletosdatapagamento = AV58TFBoletosDataPagamento;
         AV120Boletowwds_28_tfboletosdatapagamento_to = AV59TFBoletosDataPagamento_To;
         AV121Boletowwds_29_tfboletosdatabaixa = AV63TFBoletosDataBaixa;
         AV122Boletowwds_30_tfboletosdatabaixa_to = AV64TFBoletosDataBaixa_To;
         AV123Boletowwds_31_tfboletosvalornominal = AV68TFBoletosValorNominal;
         AV124Boletowwds_32_tfboletosvalornominal_to = AV69TFBoletosValorNominal_To;
         AV125Boletowwds_33_tfboletosvalorpago = AV70TFBoletosValorPago;
         AV126Boletowwds_34_tfboletosvalorpago_to = AV71TFBoletosValorPago_To;
         AV127Boletowwds_35_tfboletosvalordesconto = AV72TFBoletosValorDesconto;
         AV128Boletowwds_36_tfboletosvalordesconto_to = AV73TFBoletosValorDesconto_To;
         AV129Boletowwds_37_tfboletosvalorjuros = AV74TFBoletosValorJuros;
         AV130Boletowwds_38_tfboletosvalorjuros_to = AV75TFBoletosValorJuros_To;
         AV131Boletowwds_39_tfboletosvalormulta = AV76TFBoletosValorMulta;
         AV132Boletowwds_40_tfboletosvalormulta_to = AV77TFBoletosValorMulta_To;
         AV133Boletowwds_41_tfboletossacadonome = AV78TFBoletosSacadoNome;
         AV134Boletowwds_42_tfboletossacadonome_sel = AV79TFBoletosSacadoNome_Sel;
         AV135Boletowwds_43_tfboletossacadodocumento = AV80TFBoletosSacadoDocumento;
         AV136Boletowwds_44_tfboletossacadodocumento_sel = AV81TFBoletosSacadoDocumento_Sel;
         AV137Boletowwds_45_tfboletossacadotipodocumento_sels = AV83TFBoletosSacadoTipoDocumento_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18BoletosNossoNumero1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22BoletosNossoNumero2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26BoletosNossoNumero3, AV34ManageFiltersExecutionStep, AV92Pgmname, AV91CarteiraDeCobrancaId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFBoletosNossoNumero, AV36TFBoletosNossoNumero_Sel, AV37TFBoletosSeuNumero, AV38TFBoletosSeuNumero_Sel, AV39TFBoletosNumero, AV40TFBoletosNumero_Sel, AV42TFBoletosStatus_Sels, AV43TFBoletosDataEmissao, AV44TFBoletosDataEmissao_To, AV48TFBoletosDataVencimento, AV49TFBoletosDataVencimento_To, AV53TFBoletosDataRegistro, AV54TFBoletosDataRegistro_To, AV58TFBoletosDataPagamento, AV59TFBoletosDataPagamento_To, AV63TFBoletosDataBaixa, AV64TFBoletosDataBaixa_To, AV68TFBoletosValorNominal, AV69TFBoletosValorNominal_To, AV70TFBoletosValorPago, AV71TFBoletosValorPago_To, AV72TFBoletosValorDesconto, AV73TFBoletosValorDesconto_To, AV74TFBoletosValorJuros, AV75TFBoletosValorJuros_To, AV76TFBoletosValorMulta, AV77TFBoletosValorMulta_To, AV78TFBoletosSacadoNome, AV79TFBoletosSacadoNome_Sel, AV80TFBoletosSacadoDocumento, AV81TFBoletosSacadoDocumento_Sel, AV83TFBoletosSacadoTipoDocumento_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV92Pgmname = "BoletoWW";
         edtBoletosId_Enabled = 0;
         edtCarteiraDeCobrancaId_Enabled = 0;
         edtTituloId_Enabled = 0;
         edtBoletosNossoNumero_Enabled = 0;
         edtBoletosSeuNumero_Enabled = 0;
         edtBoletosNumero_Enabled = 0;
         edtBoletosLinhaDigitavel_Enabled = 0;
         edtBoletosCodigoDeBarras_Enabled = 0;
         cmbBoletosStatus.Enabled = 0;
         edtBoletosDataEmissao_Enabled = 0;
         edtBoletosDataVencimento_Enabled = 0;
         edtBoletosDataRegistro_Enabled = 0;
         edtBoletosDataPagamento_Enabled = 0;
         edtBoletosDataBaixa_Enabled = 0;
         edtBoletosValorNominal_Enabled = 0;
         edtBoletosValorPago_Enabled = 0;
         edtBoletosValorDesconto_Enabled = 0;
         edtBoletosValorJuros_Enabled = 0;
         edtBoletosValorMulta_Enabled = 0;
         edtBoletosSacadoNome_Enabled = 0;
         edtBoletosSacadoDocumento_Enabled = 0;
         cmbBoletosSacadoTipoDocumento.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPA80( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E25A82 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV32ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV84DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_107 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_107"), ",", "."), 18, MidpointRounding.ToEven));
            AV86GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV87GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV88GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV45DDO_BoletosDataEmissaoAuxDate = context.localUtil.CToD( cgiGet( "vDDO_BOLETOSDATAEMISSAOAUXDATE"), 0);
            AV46DDO_BoletosDataEmissaoAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_BOLETOSDATAEMISSAOAUXDATETO"), 0);
            AV50DDO_BoletosDataVencimentoAuxDate = context.localUtil.CToD( cgiGet( "vDDO_BOLETOSDATAVENCIMENTOAUXDATE"), 0);
            AV51DDO_BoletosDataVencimentoAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_BOLETOSDATAVENCIMENTOAUXDATETO"), 0);
            AV55DDO_BoletosDataRegistroAuxDate = context.localUtil.CToD( cgiGet( "vDDO_BOLETOSDATAREGISTROAUXDATE"), 0);
            AssignAttri("", false, "AV55DDO_BoletosDataRegistroAuxDate", context.localUtil.Format(AV55DDO_BoletosDataRegistroAuxDate, "99/99/99"));
            AV56DDO_BoletosDataRegistroAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_BOLETOSDATAREGISTROAUXDATETO"), 0);
            AssignAttri("", false, "AV56DDO_BoletosDataRegistroAuxDateTo", context.localUtil.Format(AV56DDO_BoletosDataRegistroAuxDateTo, "99/99/99"));
            AV60DDO_BoletosDataPagamentoAuxDate = context.localUtil.CToD( cgiGet( "vDDO_BOLETOSDATAPAGAMENTOAUXDATE"), 0);
            AV61DDO_BoletosDataPagamentoAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_BOLETOSDATAPAGAMENTOAUXDATETO"), 0);
            AV65DDO_BoletosDataBaixaAuxDate = context.localUtil.CToD( cgiGet( "vDDO_BOLETOSDATABAIXAAUXDATE"), 0);
            AV66DDO_BoletosDataBaixaAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_BOLETOSDATABAIXAAUXDATETO"), 0);
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
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV16DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AV18BoletosNossoNumero1 = cgiGet( edtavBoletosnossonumero1_Internalname);
            AssignAttri("", false, "AV18BoletosNossoNumero1", AV18BoletosNossoNumero1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV20DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AV22BoletosNossoNumero2 = cgiGet( edtavBoletosnossonumero2_Internalname);
            AssignAttri("", false, "AV22BoletosNossoNumero2", AV22BoletosNossoNumero2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV24DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AV26BoletosNossoNumero3 = cgiGet( edtavBoletosnossonumero3_Internalname);
            AssignAttri("", false, "AV26BoletosNossoNumero3", AV26BoletosNossoNumero3);
            AV47DDO_BoletosDataEmissaoAuxDateText = cgiGet( edtavDdo_boletosdataemissaoauxdatetext_Internalname);
            AssignAttri("", false, "AV47DDO_BoletosDataEmissaoAuxDateText", AV47DDO_BoletosDataEmissaoAuxDateText);
            AV52DDO_BoletosDataVencimentoAuxDateText = cgiGet( edtavDdo_boletosdatavencimentoauxdatetext_Internalname);
            AssignAttri("", false, "AV52DDO_BoletosDataVencimentoAuxDateText", AV52DDO_BoletosDataVencimentoAuxDateText);
            AV57DDO_BoletosDataRegistroAuxDateText = cgiGet( edtavDdo_boletosdataregistroauxdatetext_Internalname);
            AssignAttri("", false, "AV57DDO_BoletosDataRegistroAuxDateText", AV57DDO_BoletosDataRegistroAuxDateText);
            AV62DDO_BoletosDataPagamentoAuxDateText = cgiGet( edtavDdo_boletosdatapagamentoauxdatetext_Internalname);
            AssignAttri("", false, "AV62DDO_BoletosDataPagamentoAuxDateText", AV62DDO_BoletosDataPagamentoAuxDateText);
            AV67DDO_BoletosDataBaixaAuxDateText = cgiGet( edtavDdo_boletosdatabaixaauxdatetext_Internalname);
            AssignAttri("", false, "AV67DDO_BoletosDataBaixaAuxDateText", AV67DDO_BoletosDataBaixaAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV13OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV16DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV17DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vBOLETOSNOSSONUMERO1"), AV18BoletosNossoNumero1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV20DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV21DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vBOLETOSNOSSONUMERO2"), AV22BoletosNossoNumero2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV24DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV25DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vBOLETOSNOSSONUMERO3"), AV26BoletosNossoNumero3) != 0 )
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
         E25A82 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E25A82( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFBOLETOSDATABAIXA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_boletosdatabaixaauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFBOLETOSDATAPAGAMENTO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_boletosdatapagamentoauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFBOLETOSDATAREGISTRO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_boletosdataregistroauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFBOLETOSDATAVENCIMENTO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_boletosdatavencimentoauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFBOLETOSDATAEMISSAO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_boletosdataemissaoauxdatetext_Internalname});
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
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV16DynamicFiltersSelector1 = "BOLETOSNOSSONUMERO";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20DynamicFiltersSelector2 = "BOLETOSNOSSONUMERO";
         AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV24DynamicFiltersSelector3 = "BOLETOSNOSSONUMERO";
         AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
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
         Form.Caption = " Boleto";
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
         if ( AV13OrderedBy < 1 )
         {
            AV13OrderedBy = 1;
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV84DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV84DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E26A82( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
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
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV86GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV86GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV86GridCurrentPage), 10, 0));
         AV87GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV87GridPageCount", StringUtil.LTrimStr( (decimal)(AV87GridPageCount), 10, 0));
         GXt_char2 = AV88GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV92Pgmname, out  GXt_char2) ;
         AV88GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV88GridAppliedFilters", AV88GridAppliedFilters);
         AV93Boletowwds_1_carteiradecobrancaid = AV91CarteiraDeCobrancaId;
         AV94Boletowwds_2_filterfulltext = AV15FilterFullText;
         AV95Boletowwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV96Boletowwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV97Boletowwds_5_boletosnossonumero1 = AV18BoletosNossoNumero1;
         AV98Boletowwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV99Boletowwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV100Boletowwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV101Boletowwds_9_boletosnossonumero2 = AV22BoletosNossoNumero2;
         AV102Boletowwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV103Boletowwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV104Boletowwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV105Boletowwds_13_boletosnossonumero3 = AV26BoletosNossoNumero3;
         AV106Boletowwds_14_tfboletosnossonumero = AV35TFBoletosNossoNumero;
         AV107Boletowwds_15_tfboletosnossonumero_sel = AV36TFBoletosNossoNumero_Sel;
         AV108Boletowwds_16_tfboletosseunumero = AV37TFBoletosSeuNumero;
         AV109Boletowwds_17_tfboletosseunumero_sel = AV38TFBoletosSeuNumero_Sel;
         AV110Boletowwds_18_tfboletosnumero = AV39TFBoletosNumero;
         AV111Boletowwds_19_tfboletosnumero_sel = AV40TFBoletosNumero_Sel;
         AV112Boletowwds_20_tfboletosstatus_sels = AV42TFBoletosStatus_Sels;
         AV113Boletowwds_21_tfboletosdataemissao = AV43TFBoletosDataEmissao;
         AV114Boletowwds_22_tfboletosdataemissao_to = AV44TFBoletosDataEmissao_To;
         AV115Boletowwds_23_tfboletosdatavencimento = AV48TFBoletosDataVencimento;
         AV116Boletowwds_24_tfboletosdatavencimento_to = AV49TFBoletosDataVencimento_To;
         AV117Boletowwds_25_tfboletosdataregistro = AV53TFBoletosDataRegistro;
         AV118Boletowwds_26_tfboletosdataregistro_to = AV54TFBoletosDataRegistro_To;
         AV119Boletowwds_27_tfboletosdatapagamento = AV58TFBoletosDataPagamento;
         AV120Boletowwds_28_tfboletosdatapagamento_to = AV59TFBoletosDataPagamento_To;
         AV121Boletowwds_29_tfboletosdatabaixa = AV63TFBoletosDataBaixa;
         AV122Boletowwds_30_tfboletosdatabaixa_to = AV64TFBoletosDataBaixa_To;
         AV123Boletowwds_31_tfboletosvalornominal = AV68TFBoletosValorNominal;
         AV124Boletowwds_32_tfboletosvalornominal_to = AV69TFBoletosValorNominal_To;
         AV125Boletowwds_33_tfboletosvalorpago = AV70TFBoletosValorPago;
         AV126Boletowwds_34_tfboletosvalorpago_to = AV71TFBoletosValorPago_To;
         AV127Boletowwds_35_tfboletosvalordesconto = AV72TFBoletosValorDesconto;
         AV128Boletowwds_36_tfboletosvalordesconto_to = AV73TFBoletosValorDesconto_To;
         AV129Boletowwds_37_tfboletosvalorjuros = AV74TFBoletosValorJuros;
         AV130Boletowwds_38_tfboletosvalorjuros_to = AV75TFBoletosValorJuros_To;
         AV131Boletowwds_39_tfboletosvalormulta = AV76TFBoletosValorMulta;
         AV132Boletowwds_40_tfboletosvalormulta_to = AV77TFBoletosValorMulta_To;
         AV133Boletowwds_41_tfboletossacadonome = AV78TFBoletosSacadoNome;
         AV134Boletowwds_42_tfboletossacadonome_sel = AV79TFBoletosSacadoNome_Sel;
         AV135Boletowwds_43_tfboletossacadodocumento = AV80TFBoletosSacadoDocumento;
         AV136Boletowwds_44_tfboletossacadodocumento_sel = AV81TFBoletosSacadoDocumento_Sel;
         AV137Boletowwds_45_tfboletossacadotipodocumento_sels = AV83TFBoletosSacadoTipoDocumento_Sels;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E12A82( )
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
            AV85PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV85PageToGo) ;
         }
      }

      protected void E13A82( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14A82( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "BoletosNossoNumero") == 0 )
            {
               AV35TFBoletosNossoNumero = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV35TFBoletosNossoNumero", AV35TFBoletosNossoNumero);
               AV36TFBoletosNossoNumero_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV36TFBoletosNossoNumero_Sel", AV36TFBoletosNossoNumero_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "BoletosSeuNumero") == 0 )
            {
               AV37TFBoletosSeuNumero = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV37TFBoletosSeuNumero", AV37TFBoletosSeuNumero);
               AV38TFBoletosSeuNumero_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV38TFBoletosSeuNumero_Sel", AV38TFBoletosSeuNumero_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "BoletosNumero") == 0 )
            {
               AV39TFBoletosNumero = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV39TFBoletosNumero", AV39TFBoletosNumero);
               AV40TFBoletosNumero_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV40TFBoletosNumero_Sel", AV40TFBoletosNumero_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "BoletosStatus") == 0 )
            {
               AV41TFBoletosStatus_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV41TFBoletosStatus_SelsJson", AV41TFBoletosStatus_SelsJson);
               AV42TFBoletosStatus_Sels.FromJSonString(AV41TFBoletosStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "BoletosDataEmissao") == 0 )
            {
               AV43TFBoletosDataEmissao = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV43TFBoletosDataEmissao", context.localUtil.Format(AV43TFBoletosDataEmissao, "99/99/99"));
               AV44TFBoletosDataEmissao_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV44TFBoletosDataEmissao_To", context.localUtil.Format(AV44TFBoletosDataEmissao_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "BoletosDataVencimento") == 0 )
            {
               AV48TFBoletosDataVencimento = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV48TFBoletosDataVencimento", context.localUtil.Format(AV48TFBoletosDataVencimento, "99/99/99"));
               AV49TFBoletosDataVencimento_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV49TFBoletosDataVencimento_To", context.localUtil.Format(AV49TFBoletosDataVencimento_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "BoletosDataRegistro") == 0 )
            {
               AV53TFBoletosDataRegistro = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV53TFBoletosDataRegistro", context.localUtil.TToC( AV53TFBoletosDataRegistro, 8, 5, 0, 3, "/", ":", " "));
               AV54TFBoletosDataRegistro_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV54TFBoletosDataRegistro_To", context.localUtil.TToC( AV54TFBoletosDataRegistro_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV54TFBoletosDataRegistro_To) )
               {
                  AV54TFBoletosDataRegistro_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV54TFBoletosDataRegistro_To)), (short)(DateTimeUtil.Month( AV54TFBoletosDataRegistro_To)), (short)(DateTimeUtil.Day( AV54TFBoletosDataRegistro_To)), 23, 59, 59);
                  AssignAttri("", false, "AV54TFBoletosDataRegistro_To", context.localUtil.TToC( AV54TFBoletosDataRegistro_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "BoletosDataPagamento") == 0 )
            {
               AV58TFBoletosDataPagamento = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV58TFBoletosDataPagamento", context.localUtil.Format(AV58TFBoletosDataPagamento, "99/99/99"));
               AV59TFBoletosDataPagamento_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV59TFBoletosDataPagamento_To", context.localUtil.Format(AV59TFBoletosDataPagamento_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "BoletosDataBaixa") == 0 )
            {
               AV63TFBoletosDataBaixa = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV63TFBoletosDataBaixa", context.localUtil.Format(AV63TFBoletosDataBaixa, "99/99/99"));
               AV64TFBoletosDataBaixa_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV64TFBoletosDataBaixa_To", context.localUtil.Format(AV64TFBoletosDataBaixa_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "BoletosValorNominal") == 0 )
            {
               AV68TFBoletosValorNominal = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV68TFBoletosValorNominal", StringUtil.LTrimStr( AV68TFBoletosValorNominal, 18, 2));
               AV69TFBoletosValorNominal_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV69TFBoletosValorNominal_To", StringUtil.LTrimStr( AV69TFBoletosValorNominal_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "BoletosValorPago") == 0 )
            {
               AV70TFBoletosValorPago = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV70TFBoletosValorPago", StringUtil.LTrimStr( AV70TFBoletosValorPago, 18, 2));
               AV71TFBoletosValorPago_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV71TFBoletosValorPago_To", StringUtil.LTrimStr( AV71TFBoletosValorPago_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "BoletosValorDesconto") == 0 )
            {
               AV72TFBoletosValorDesconto = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV72TFBoletosValorDesconto", StringUtil.LTrimStr( AV72TFBoletosValorDesconto, 18, 2));
               AV73TFBoletosValorDesconto_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV73TFBoletosValorDesconto_To", StringUtil.LTrimStr( AV73TFBoletosValorDesconto_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "BoletosValorJuros") == 0 )
            {
               AV74TFBoletosValorJuros = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV74TFBoletosValorJuros", StringUtil.LTrimStr( AV74TFBoletosValorJuros, 18, 2));
               AV75TFBoletosValorJuros_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV75TFBoletosValorJuros_To", StringUtil.LTrimStr( AV75TFBoletosValorJuros_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "BoletosValorMulta") == 0 )
            {
               AV76TFBoletosValorMulta = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV76TFBoletosValorMulta", StringUtil.LTrimStr( AV76TFBoletosValorMulta, 18, 2));
               AV77TFBoletosValorMulta_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV77TFBoletosValorMulta_To", StringUtil.LTrimStr( AV77TFBoletosValorMulta_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "BoletosSacadoNome") == 0 )
            {
               AV78TFBoletosSacadoNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV78TFBoletosSacadoNome", AV78TFBoletosSacadoNome);
               AV79TFBoletosSacadoNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV79TFBoletosSacadoNome_Sel", AV79TFBoletosSacadoNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "BoletosSacadoDocumento") == 0 )
            {
               AV80TFBoletosSacadoDocumento = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV80TFBoletosSacadoDocumento", AV80TFBoletosSacadoDocumento);
               AV81TFBoletosSacadoDocumento_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV81TFBoletosSacadoDocumento_Sel", AV81TFBoletosSacadoDocumento_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "BoletosSacadoTipoDocumento") == 0 )
            {
               AV82TFBoletosSacadoTipoDocumento_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV82TFBoletosSacadoTipoDocumento_SelsJson", AV82TFBoletosSacadoTipoDocumento_SelsJson);
               AV83TFBoletosSacadoTipoDocumento_Sels.FromJSonString(AV82TFBoletosSacadoTipoDocumento_SelsJson, null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV83TFBoletosSacadoTipoDocumento_Sels", AV83TFBoletosSacadoTipoDocumento_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42TFBoletosStatus_Sels", AV42TFBoletosStatus_Sels);
      }

      private void E27A82( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactiongroup1.removeAllItems();
         cmbavGridactiongroup1.addItem("0", ";fas fa-bars", 0);
         cmbavGridactiongroup1.addItem("1", StringUtil.Format( "%1;%2", "Mostrar", "fa fa-search", "", "", "", "", "", "", ""), 0);
         cmbavGridactiongroup1.addItem("2", StringUtil.Format( "%1;%2", "Modifica", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         cmbavGridactiongroup1.addItem("3", StringUtil.Format( "%1;%2", "Eliminar", "fa fa-times", "", "", "", "", "", "", ""), 0);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "boleto"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A1077BoletosId,9,0));
         edtBoletosNossoNumero_Link = formatLink("boleto") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV89GridActionGroup1), 4, 0));
      }

      protected void E20A82( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E15A82( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV28DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV28DynamicFiltersIgnoreFirst", AV28DynamicFiltersIgnoreFirst);
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
         AV27DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV28DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV28DynamicFiltersIgnoreFirst", AV28DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18BoletosNossoNumero1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22BoletosNossoNumero2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26BoletosNossoNumero3, AV34ManageFiltersExecutionStep, AV92Pgmname, AV91CarteiraDeCobrancaId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFBoletosNossoNumero, AV36TFBoletosNossoNumero_Sel, AV37TFBoletosSeuNumero, AV38TFBoletosSeuNumero_Sel, AV39TFBoletosNumero, AV40TFBoletosNumero_Sel, AV42TFBoletosStatus_Sels, AV43TFBoletosDataEmissao, AV44TFBoletosDataEmissao_To, AV48TFBoletosDataVencimento, AV49TFBoletosDataVencimento_To, AV53TFBoletosDataRegistro, AV54TFBoletosDataRegistro_To, AV58TFBoletosDataPagamento, AV59TFBoletosDataPagamento_To, AV63TFBoletosDataBaixa, AV64TFBoletosDataBaixa_To, AV68TFBoletosValorNominal, AV69TFBoletosValorNominal_To, AV70TFBoletosValorPago, AV71TFBoletosValorPago_To, AV72TFBoletosValorDesconto, AV73TFBoletosValorDesconto_To, AV74TFBoletosValorJuros, AV75TFBoletosValorJuros_To, AV76TFBoletosValorMulta, AV77TFBoletosValorMulta_To, AV78TFBoletosSacadoNome, AV79TFBoletosSacadoNome_Sel, AV80TFBoletosSacadoDocumento, AV81TFBoletosSacadoDocumento_Sel, AV83TFBoletosSacadoTipoDocumento_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E21A82( )
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

      protected void E22A82( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV23DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E16A82( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV19DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
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
         AV27DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18BoletosNossoNumero1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22BoletosNossoNumero2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26BoletosNossoNumero3, AV34ManageFiltersExecutionStep, AV92Pgmname, AV91CarteiraDeCobrancaId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFBoletosNossoNumero, AV36TFBoletosNossoNumero_Sel, AV37TFBoletosSeuNumero, AV38TFBoletosSeuNumero_Sel, AV39TFBoletosNumero, AV40TFBoletosNumero_Sel, AV42TFBoletosStatus_Sels, AV43TFBoletosDataEmissao, AV44TFBoletosDataEmissao_To, AV48TFBoletosDataVencimento, AV49TFBoletosDataVencimento_To, AV53TFBoletosDataRegistro, AV54TFBoletosDataRegistro_To, AV58TFBoletosDataPagamento, AV59TFBoletosDataPagamento_To, AV63TFBoletosDataBaixa, AV64TFBoletosDataBaixa_To, AV68TFBoletosValorNominal, AV69TFBoletosValorNominal_To, AV70TFBoletosValorPago, AV71TFBoletosValorPago_To, AV72TFBoletosValorDesconto, AV73TFBoletosValorDesconto_To, AV74TFBoletosValorJuros, AV75TFBoletosValorJuros_To, AV76TFBoletosValorMulta, AV77TFBoletosValorMulta_To, AV78TFBoletosSacadoNome, AV79TFBoletosSacadoNome_Sel, AV80TFBoletosSacadoDocumento, AV81TFBoletosSacadoDocumento_Sel, AV83TFBoletosSacadoTipoDocumento_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E23A82( )
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

      protected void E17A82( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
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
         AV27DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18BoletosNossoNumero1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22BoletosNossoNumero2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26BoletosNossoNumero3, AV34ManageFiltersExecutionStep, AV92Pgmname, AV91CarteiraDeCobrancaId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFBoletosNossoNumero, AV36TFBoletosNossoNumero_Sel, AV37TFBoletosSeuNumero, AV38TFBoletosSeuNumero_Sel, AV39TFBoletosNumero, AV40TFBoletosNumero_Sel, AV42TFBoletosStatus_Sels, AV43TFBoletosDataEmissao, AV44TFBoletosDataEmissao_To, AV48TFBoletosDataVencimento, AV49TFBoletosDataVencimento_To, AV53TFBoletosDataRegistro, AV54TFBoletosDataRegistro_To, AV58TFBoletosDataPagamento, AV59TFBoletosDataPagamento_To, AV63TFBoletosDataBaixa, AV64TFBoletosDataBaixa_To, AV68TFBoletosValorNominal, AV69TFBoletosValorNominal_To, AV70TFBoletosValorPago, AV71TFBoletosValorPago_To, AV72TFBoletosValorDesconto, AV73TFBoletosValorDesconto_To, AV74TFBoletosValorJuros, AV75TFBoletosValorJuros_To, AV76TFBoletosValorMulta, AV77TFBoletosValorMulta_To, AV78TFBoletosSacadoNome, AV79TFBoletosSacadoNome_Sel, AV80TFBoletosSacadoDocumento, AV81TFBoletosSacadoDocumento_Sel, AV83TFBoletosSacadoTipoDocumento_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E24A82( )
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

      protected void E11A82( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("BoletoWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV92Pgmname+"GridState"));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("BoletoWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV34ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV33ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "BoletoWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV33ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV33ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV92Pgmname+"GridState",  AV33ManageFiltersXml) ;
               AV10GridState.FromXml(AV33ManageFiltersXml, null, "", "");
               AV13OrderedBy = AV10GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42TFBoletosStatus_Sels", AV42TFBoletosStatus_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV83TFBoletosSacadoTipoDocumento_Sels", AV83TFBoletosSacadoTipoDocumento_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E28A82( )
      {
         /* Gridactiongroup1_Click Routine */
         returnInSub = false;
         if ( AV89GridActionGroup1 == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV89GridActionGroup1 == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV89GridActionGroup1 == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV89GridActionGroup1 = 0;
         AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV89GridActionGroup1), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV89GridActionGroup1), 4, 0));
         AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", cmbavGridactiongroup1.ToJavascriptSource(), true);
      }

      protected void E18A82( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "boleto"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("boleto") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E19A82( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         new boletowwexport(context ).execute( out  AV29ExcelFilename, out  AV30ErrorMessage) ;
         if ( StringUtil.StrCmp(AV29ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV29ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV30ErrorMessage);
         }
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavBoletosnossonumero1_Visible = 0;
         AssignProp("", false, edtavBoletosnossonumero1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBoletosnossonumero1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "BOLETOSNOSSONUMERO") == 0 )
         {
            edtavBoletosnossonumero1_Visible = 1;
            AssignProp("", false, edtavBoletosnossonumero1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBoletosnossonumero1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavBoletosnossonumero2_Visible = 0;
         AssignProp("", false, edtavBoletosnossonumero2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBoletosnossonumero2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "BOLETOSNOSSONUMERO") == 0 )
         {
            edtavBoletosnossonumero2_Visible = 1;
            AssignProp("", false, edtavBoletosnossonumero2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBoletosnossonumero2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavBoletosnossonumero3_Visible = 0;
         AssignProp("", false, edtavBoletosnossonumero3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBoletosnossonumero3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "BOLETOSNOSSONUMERO") == 0 )
         {
            edtavBoletosnossonumero3_Visible = 1;
            AssignProp("", false, edtavBoletosnossonumero3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBoletosnossonumero3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         AV20DynamicFiltersSelector2 = "BOLETOSNOSSONUMERO";
         AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         AV21DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AV22BoletosNossoNumero2 = "";
         AssignAttri("", false, "AV22BoletosNossoNumero2", AV22BoletosNossoNumero2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         AV24DynamicFiltersSelector3 = "BOLETOSNOSSONUMERO";
         AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         AV25DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AV26BoletosNossoNumero3 = "";
         AssignAttri("", false, "AV26BoletosNossoNumero3", AV26BoletosNossoNumero3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV32ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "BoletoWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV32ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV35TFBoletosNossoNumero = "";
         AssignAttri("", false, "AV35TFBoletosNossoNumero", AV35TFBoletosNossoNumero);
         AV36TFBoletosNossoNumero_Sel = "";
         AssignAttri("", false, "AV36TFBoletosNossoNumero_Sel", AV36TFBoletosNossoNumero_Sel);
         AV37TFBoletosSeuNumero = "";
         AssignAttri("", false, "AV37TFBoletosSeuNumero", AV37TFBoletosSeuNumero);
         AV38TFBoletosSeuNumero_Sel = "";
         AssignAttri("", false, "AV38TFBoletosSeuNumero_Sel", AV38TFBoletosSeuNumero_Sel);
         AV39TFBoletosNumero = "";
         AssignAttri("", false, "AV39TFBoletosNumero", AV39TFBoletosNumero);
         AV40TFBoletosNumero_Sel = "";
         AssignAttri("", false, "AV40TFBoletosNumero_Sel", AV40TFBoletosNumero_Sel);
         AV42TFBoletosStatus_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV43TFBoletosDataEmissao = DateTime.MinValue;
         AssignAttri("", false, "AV43TFBoletosDataEmissao", context.localUtil.Format(AV43TFBoletosDataEmissao, "99/99/99"));
         AV44TFBoletosDataEmissao_To = DateTime.MinValue;
         AssignAttri("", false, "AV44TFBoletosDataEmissao_To", context.localUtil.Format(AV44TFBoletosDataEmissao_To, "99/99/99"));
         AV48TFBoletosDataVencimento = DateTime.MinValue;
         AssignAttri("", false, "AV48TFBoletosDataVencimento", context.localUtil.Format(AV48TFBoletosDataVencimento, "99/99/99"));
         AV49TFBoletosDataVencimento_To = DateTime.MinValue;
         AssignAttri("", false, "AV49TFBoletosDataVencimento_To", context.localUtil.Format(AV49TFBoletosDataVencimento_To, "99/99/99"));
         AV53TFBoletosDataRegistro = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV53TFBoletosDataRegistro", context.localUtil.TToC( AV53TFBoletosDataRegistro, 8, 5, 0, 3, "/", ":", " "));
         AV54TFBoletosDataRegistro_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV54TFBoletosDataRegistro_To", context.localUtil.TToC( AV54TFBoletosDataRegistro_To, 8, 5, 0, 3, "/", ":", " "));
         AV58TFBoletosDataPagamento = DateTime.MinValue;
         AssignAttri("", false, "AV58TFBoletosDataPagamento", context.localUtil.Format(AV58TFBoletosDataPagamento, "99/99/99"));
         AV59TFBoletosDataPagamento_To = DateTime.MinValue;
         AssignAttri("", false, "AV59TFBoletosDataPagamento_To", context.localUtil.Format(AV59TFBoletosDataPagamento_To, "99/99/99"));
         AV63TFBoletosDataBaixa = DateTime.MinValue;
         AssignAttri("", false, "AV63TFBoletosDataBaixa", context.localUtil.Format(AV63TFBoletosDataBaixa, "99/99/99"));
         AV64TFBoletosDataBaixa_To = DateTime.MinValue;
         AssignAttri("", false, "AV64TFBoletosDataBaixa_To", context.localUtil.Format(AV64TFBoletosDataBaixa_To, "99/99/99"));
         AV68TFBoletosValorNominal = 0;
         AssignAttri("", false, "AV68TFBoletosValorNominal", StringUtil.LTrimStr( AV68TFBoletosValorNominal, 18, 2));
         AV69TFBoletosValorNominal_To = 0;
         AssignAttri("", false, "AV69TFBoletosValorNominal_To", StringUtil.LTrimStr( AV69TFBoletosValorNominal_To, 18, 2));
         AV70TFBoletosValorPago = 0;
         AssignAttri("", false, "AV70TFBoletosValorPago", StringUtil.LTrimStr( AV70TFBoletosValorPago, 18, 2));
         AV71TFBoletosValorPago_To = 0;
         AssignAttri("", false, "AV71TFBoletosValorPago_To", StringUtil.LTrimStr( AV71TFBoletosValorPago_To, 18, 2));
         AV72TFBoletosValorDesconto = 0;
         AssignAttri("", false, "AV72TFBoletosValorDesconto", StringUtil.LTrimStr( AV72TFBoletosValorDesconto, 18, 2));
         AV73TFBoletosValorDesconto_To = 0;
         AssignAttri("", false, "AV73TFBoletosValorDesconto_To", StringUtil.LTrimStr( AV73TFBoletosValorDesconto_To, 18, 2));
         AV74TFBoletosValorJuros = 0;
         AssignAttri("", false, "AV74TFBoletosValorJuros", StringUtil.LTrimStr( AV74TFBoletosValorJuros, 18, 2));
         AV75TFBoletosValorJuros_To = 0;
         AssignAttri("", false, "AV75TFBoletosValorJuros_To", StringUtil.LTrimStr( AV75TFBoletosValorJuros_To, 18, 2));
         AV76TFBoletosValorMulta = 0;
         AssignAttri("", false, "AV76TFBoletosValorMulta", StringUtil.LTrimStr( AV76TFBoletosValorMulta, 18, 2));
         AV77TFBoletosValorMulta_To = 0;
         AssignAttri("", false, "AV77TFBoletosValorMulta_To", StringUtil.LTrimStr( AV77TFBoletosValorMulta_To, 18, 2));
         AV78TFBoletosSacadoNome = "";
         AssignAttri("", false, "AV78TFBoletosSacadoNome", AV78TFBoletosSacadoNome);
         AV79TFBoletosSacadoNome_Sel = "";
         AssignAttri("", false, "AV79TFBoletosSacadoNome_Sel", AV79TFBoletosSacadoNome_Sel);
         AV80TFBoletosSacadoDocumento = "";
         AssignAttri("", false, "AV80TFBoletosSacadoDocumento", AV80TFBoletosSacadoDocumento);
         AV81TFBoletosSacadoDocumento_Sel = "";
         AssignAttri("", false, "AV81TFBoletosSacadoDocumento_Sel", AV81TFBoletosSacadoDocumento_Sel);
         AV83TFBoletosSacadoTipoDocumento_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV16DynamicFiltersSelector1 = "BOLETOSNOSSONUMERO";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AV18BoletosNossoNumero1 = "";
         AssignAttri("", false, "AV18BoletosNossoNumero1", AV18BoletosNossoNumero1);
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
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S242( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "boleto"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A1077BoletosId,9,0));
         CallWebObject(formatLink("boleto") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
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
         GXEncryptionTmp = "boleto"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A1077BoletosId,9,0));
         CallWebObject(formatLink("boleto") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S262( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "boleto"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A1077BoletosId,9,0));
         CallWebObject(formatLink("boleto") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV31Session.Get(AV92Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV92Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV31Session.Get(AV92Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV10GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV10GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S232( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV138GXV1 = 1;
         while ( AV138GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV138GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFBOLETOSNOSSONUMERO") == 0 )
            {
               AV35TFBoletosNossoNumero = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFBoletosNossoNumero", AV35TFBoletosNossoNumero);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFBOLETOSNOSSONUMERO_SEL") == 0 )
            {
               AV36TFBoletosNossoNumero_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFBoletosNossoNumero_Sel", AV36TFBoletosNossoNumero_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFBOLETOSSEUNUMERO") == 0 )
            {
               AV37TFBoletosSeuNumero = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFBoletosSeuNumero", AV37TFBoletosSeuNumero);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFBOLETOSSEUNUMERO_SEL") == 0 )
            {
               AV38TFBoletosSeuNumero_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFBoletosSeuNumero_Sel", AV38TFBoletosSeuNumero_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFBOLETOSNUMERO") == 0 )
            {
               AV39TFBoletosNumero = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39TFBoletosNumero", AV39TFBoletosNumero);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFBOLETOSNUMERO_SEL") == 0 )
            {
               AV40TFBoletosNumero_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFBoletosNumero_Sel", AV40TFBoletosNumero_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFBOLETOSSTATUS_SEL") == 0 )
            {
               AV41TFBoletosStatus_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFBoletosStatus_SelsJson", AV41TFBoletosStatus_SelsJson);
               AV42TFBoletosStatus_Sels.FromJSonString(AV41TFBoletosStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFBOLETOSDATAEMISSAO") == 0 )
            {
               AV43TFBoletosDataEmissao = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV43TFBoletosDataEmissao", context.localUtil.Format(AV43TFBoletosDataEmissao, "99/99/99"));
               AV44TFBoletosDataEmissao_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV44TFBoletosDataEmissao_To", context.localUtil.Format(AV44TFBoletosDataEmissao_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFBOLETOSDATAVENCIMENTO") == 0 )
            {
               AV48TFBoletosDataVencimento = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV48TFBoletosDataVencimento", context.localUtil.Format(AV48TFBoletosDataVencimento, "99/99/99"));
               AV49TFBoletosDataVencimento_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV49TFBoletosDataVencimento_To", context.localUtil.Format(AV49TFBoletosDataVencimento_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFBOLETOSDATAREGISTRO") == 0 )
            {
               AV53TFBoletosDataRegistro = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV53TFBoletosDataRegistro", context.localUtil.TToC( AV53TFBoletosDataRegistro, 8, 5, 0, 3, "/", ":", " "));
               AV54TFBoletosDataRegistro_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV54TFBoletosDataRegistro_To", context.localUtil.TToC( AV54TFBoletosDataRegistro_To, 8, 5, 0, 3, "/", ":", " "));
               AV55DDO_BoletosDataRegistroAuxDate = DateTimeUtil.ResetTime(AV53TFBoletosDataRegistro);
               AssignAttri("", false, "AV55DDO_BoletosDataRegistroAuxDate", context.localUtil.Format(AV55DDO_BoletosDataRegistroAuxDate, "99/99/99"));
               AV56DDO_BoletosDataRegistroAuxDateTo = DateTimeUtil.ResetTime(AV54TFBoletosDataRegistro_To);
               AssignAttri("", false, "AV56DDO_BoletosDataRegistroAuxDateTo", context.localUtil.Format(AV56DDO_BoletosDataRegistroAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFBOLETOSDATAPAGAMENTO") == 0 )
            {
               AV58TFBoletosDataPagamento = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV58TFBoletosDataPagamento", context.localUtil.Format(AV58TFBoletosDataPagamento, "99/99/99"));
               AV59TFBoletosDataPagamento_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV59TFBoletosDataPagamento_To", context.localUtil.Format(AV59TFBoletosDataPagamento_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFBOLETOSDATABAIXA") == 0 )
            {
               AV63TFBoletosDataBaixa = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV63TFBoletosDataBaixa", context.localUtil.Format(AV63TFBoletosDataBaixa, "99/99/99"));
               AV64TFBoletosDataBaixa_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV64TFBoletosDataBaixa_To", context.localUtil.Format(AV64TFBoletosDataBaixa_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFBOLETOSVALORNOMINAL") == 0 )
            {
               AV68TFBoletosValorNominal = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV68TFBoletosValorNominal", StringUtil.LTrimStr( AV68TFBoletosValorNominal, 18, 2));
               AV69TFBoletosValorNominal_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV69TFBoletosValorNominal_To", StringUtil.LTrimStr( AV69TFBoletosValorNominal_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFBOLETOSVALORPAGO") == 0 )
            {
               AV70TFBoletosValorPago = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV70TFBoletosValorPago", StringUtil.LTrimStr( AV70TFBoletosValorPago, 18, 2));
               AV71TFBoletosValorPago_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV71TFBoletosValorPago_To", StringUtil.LTrimStr( AV71TFBoletosValorPago_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFBOLETOSVALORDESCONTO") == 0 )
            {
               AV72TFBoletosValorDesconto = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV72TFBoletosValorDesconto", StringUtil.LTrimStr( AV72TFBoletosValorDesconto, 18, 2));
               AV73TFBoletosValorDesconto_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV73TFBoletosValorDesconto_To", StringUtil.LTrimStr( AV73TFBoletosValorDesconto_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFBOLETOSVALORJUROS") == 0 )
            {
               AV74TFBoletosValorJuros = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV74TFBoletosValorJuros", StringUtil.LTrimStr( AV74TFBoletosValorJuros, 18, 2));
               AV75TFBoletosValorJuros_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV75TFBoletosValorJuros_To", StringUtil.LTrimStr( AV75TFBoletosValorJuros_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFBOLETOSVALORMULTA") == 0 )
            {
               AV76TFBoletosValorMulta = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV76TFBoletosValorMulta", StringUtil.LTrimStr( AV76TFBoletosValorMulta, 18, 2));
               AV77TFBoletosValorMulta_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV77TFBoletosValorMulta_To", StringUtil.LTrimStr( AV77TFBoletosValorMulta_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFBOLETOSSACADONOME") == 0 )
            {
               AV78TFBoletosSacadoNome = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV78TFBoletosSacadoNome", AV78TFBoletosSacadoNome);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFBOLETOSSACADONOME_SEL") == 0 )
            {
               AV79TFBoletosSacadoNome_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV79TFBoletosSacadoNome_Sel", AV79TFBoletosSacadoNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFBOLETOSSACADODOCUMENTO") == 0 )
            {
               AV80TFBoletosSacadoDocumento = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV80TFBoletosSacadoDocumento", AV80TFBoletosSacadoDocumento);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFBOLETOSSACADODOCUMENTO_SEL") == 0 )
            {
               AV81TFBoletosSacadoDocumento_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV81TFBoletosSacadoDocumento_Sel", AV81TFBoletosSacadoDocumento_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFBOLETOSSACADOTIPODOCUMENTO_SEL") == 0 )
            {
               AV82TFBoletosSacadoTipoDocumento_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV82TFBoletosSacadoTipoDocumento_SelsJson", AV82TFBoletosSacadoTipoDocumento_SelsJson);
               AV83TFBoletosSacadoTipoDocumento_Sels.FromJSonString(AV82TFBoletosSacadoTipoDocumento_SelsJson, null);
            }
            AV138GXV1 = (int)(AV138GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFBoletosNossoNumero_Sel)),  AV36TFBoletosNossoNumero_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFBoletosSeuNumero_Sel)),  AV38TFBoletosSeuNumero_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFBoletosNumero_Sel)),  AV40TFBoletosNumero_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV42TFBoletosStatus_Sels.Count==0),  AV41TFBoletosStatus_SelsJson, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV79TFBoletosSacadoNome_Sel)),  AV79TFBoletosSacadoNome_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV81TFBoletosSacadoDocumento_Sel)),  AV81TFBoletosSacadoDocumento_Sel, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV83TFBoletosSacadoTipoDocumento_Sels.Count==0),  AV82TFBoletosSacadoTipoDocumento_SelsJson, out  GXt_char9) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|"+GXt_char5+"|"+GXt_char6+"|||||||||||"+GXt_char7+"|"+GXt_char8+"|"+GXt_char9;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFBoletosNossoNumero)),  AV35TFBoletosNossoNumero, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFBoletosSeuNumero)),  AV37TFBoletosSeuNumero, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFBoletosNumero)),  AV39TFBoletosNumero, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV78TFBoletosSacadoNome)),  AV78TFBoletosSacadoNome, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV80TFBoletosSacadoDocumento)),  AV80TFBoletosSacadoDocumento, out  GXt_char5) ;
         Ddo_grid_Filteredtext_set = GXt_char9+"|"+GXt_char8+"|"+GXt_char7+"||"+((DateTime.MinValue==AV43TFBoletosDataEmissao) ? "" : context.localUtil.DToC( AV43TFBoletosDataEmissao, 4, "/"))+"|"+((DateTime.MinValue==AV48TFBoletosDataVencimento) ? "" : context.localUtil.DToC( AV48TFBoletosDataVencimento, 4, "/"))+"|"+((DateTime.MinValue==AV53TFBoletosDataRegistro) ? "" : context.localUtil.DToC( AV55DDO_BoletosDataRegistroAuxDate, 4, "/"))+"|"+((DateTime.MinValue==AV58TFBoletosDataPagamento) ? "" : context.localUtil.DToC( AV58TFBoletosDataPagamento, 4, "/"))+"|"+((DateTime.MinValue==AV63TFBoletosDataBaixa) ? "" : context.localUtil.DToC( AV63TFBoletosDataBaixa, 4, "/"))+"|"+((Convert.ToDecimal(0)==AV68TFBoletosValorNominal) ? "" : StringUtil.Str( AV68TFBoletosValorNominal, 18, 2))+"|"+((Convert.ToDecimal(0)==AV70TFBoletosValorPago) ? "" : StringUtil.Str( AV70TFBoletosValorPago, 18, 2))+"|"+((Convert.ToDecimal(0)==AV72TFBoletosValorDesconto) ? "" : StringUtil.Str( AV72TFBoletosValorDesconto, 18, 2))+"|"+((Convert.ToDecimal(0)==AV74TFBoletosValorJuros) ? "" : StringUtil.Str( AV74TFBoletosValorJuros, 18, 2))+"|"+((Convert.ToDecimal(0)==AV76TFBoletosValorMulta) ? "" : StringUtil.Str( AV76TFBoletosValorMulta, 18, 2))+"|"+GXt_char6+"|"+GXt_char5+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||||"+((DateTime.MinValue==AV44TFBoletosDataEmissao_To) ? "" : context.localUtil.DToC( AV44TFBoletosDataEmissao_To, 4, "/"))+"|"+((DateTime.MinValue==AV49TFBoletosDataVencimento_To) ? "" : context.localUtil.DToC( AV49TFBoletosDataVencimento_To, 4, "/"))+"|"+((DateTime.MinValue==AV54TFBoletosDataRegistro_To) ? "" : context.localUtil.DToC( AV56DDO_BoletosDataRegistroAuxDateTo, 4, "/"))+"|"+((DateTime.MinValue==AV59TFBoletosDataPagamento_To) ? "" : context.localUtil.DToC( AV59TFBoletosDataPagamento_To, 4, "/"))+"|"+((DateTime.MinValue==AV64TFBoletosDataBaixa_To) ? "" : context.localUtil.DToC( AV64TFBoletosDataBaixa_To, 4, "/"))+"|"+((Convert.ToDecimal(0)==AV69TFBoletosValorNominal_To) ? "" : StringUtil.Str( AV69TFBoletosValorNominal_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV71TFBoletosValorPago_To) ? "" : StringUtil.Str( AV71TFBoletosValorPago_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV73TFBoletosValorDesconto_To) ? "" : StringUtil.Str( AV73TFBoletosValorDesconto_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV75TFBoletosValorJuros_To) ? "" : StringUtil.Str( AV75TFBoletosValorJuros_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV77TFBoletosValorMulta_To) ? "" : StringUtil.Str( AV77TFBoletosValorMulta_To, 18, 2))+"|||";
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
         if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(1));
            AV16DynamicFiltersSelector1 = AV12GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "BOLETOSNOSSONUMERO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV18BoletosNossoNumero1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV18BoletosNossoNumero1", AV18BoletosNossoNumero1);
            }
            /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               lblJsdynamicfilters_Caption = "<script type=\"text/javascript\">$(document).ready(function() {";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               imgAdddynamicfilters1_Visible = 0;
               AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
               imgRemovedynamicfilters1_Visible = 1;
               AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
               AV19DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "BOLETOSNOSSONUMERO") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV22BoletosNossoNumero2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV22BoletosNossoNumero2", AV22BoletosNossoNumero2);
               }
               /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
               S132 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
                  AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV23DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "BOLETOSNOSSONUMERO") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
                     AV26BoletosNossoNumero3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV26BoletosNossoNumero3", AV26BoletosNossoNumero3);
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
         if ( AV27DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV31Session.Get(AV92Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFBOLETOSNOSSONUMERO",  "Nosso Número",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFBoletosNossoNumero)),  0,  AV35TFBoletosNossoNumero,  AV35TFBoletosNossoNumero,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFBoletosNossoNumero_Sel)),  AV36TFBoletosNossoNumero_Sel,  AV36TFBoletosNossoNumero_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFBOLETOSSEUNUMERO",  "Seu Número",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFBoletosSeuNumero)),  0,  AV37TFBoletosSeuNumero,  AV37TFBoletosSeuNumero,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFBoletosSeuNumero_Sel)),  AV38TFBoletosSeuNumero_Sel,  AV38TFBoletosSeuNumero_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFBOLETOSNUMERO",  "Número",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFBoletosNumero)),  0,  AV39TFBoletosNumero,  AV39TFBoletosNumero,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFBoletosNumero_Sel)),  AV40TFBoletosNumero_Sel,  AV40TFBoletosNumero_Sel) ;
         AV90AuxText = ((AV42TFBoletosStatus_Sels.Count==1) ? "["+((string)AV42TFBoletosStatus_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFBOLETOSSTATUS_SEL",  "Status",  !(AV42TFBoletosStatus_Sels.Count==0),  0,  AV42TFBoletosStatus_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV90AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV90AuxText, "[RASCUNHO]", "Rascunho"), "[REGISTRADO]", "Registrado"), "[LIQUIDADO]", "Liquidado"), "[BAIXADO]", "Baixado"), "[VENCIDO]", "Vencido"), "[ERRO]", "Erro")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFBOLETOSDATAEMISSAO",  "Emissão",  !((DateTime.MinValue==AV43TFBoletosDataEmissao)&&(DateTime.MinValue==AV44TFBoletosDataEmissao_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV43TFBoletosDataEmissao, 4, "/")),  ((DateTime.MinValue==AV43TFBoletosDataEmissao) ? "" : StringUtil.Trim( context.localUtil.Format( AV43TFBoletosDataEmissao, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV44TFBoletosDataEmissao_To, 4, "/")),  ((DateTime.MinValue==AV44TFBoletosDataEmissao_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV44TFBoletosDataEmissao_To, "99/99/99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFBOLETOSDATAVENCIMENTO",  "Vencimento",  !((DateTime.MinValue==AV48TFBoletosDataVencimento)&&(DateTime.MinValue==AV49TFBoletosDataVencimento_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV48TFBoletosDataVencimento, 4, "/")),  ((DateTime.MinValue==AV48TFBoletosDataVencimento) ? "" : StringUtil.Trim( context.localUtil.Format( AV48TFBoletosDataVencimento, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV49TFBoletosDataVencimento_To, 4, "/")),  ((DateTime.MinValue==AV49TFBoletosDataVencimento_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV49TFBoletosDataVencimento_To, "99/99/99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFBOLETOSDATAREGISTRO",  "Data de Registro",  !((DateTime.MinValue==AV53TFBoletosDataRegistro)&&(DateTime.MinValue==AV54TFBoletosDataRegistro_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV53TFBoletosDataRegistro, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV53TFBoletosDataRegistro) ? "" : StringUtil.Trim( context.localUtil.Format( AV53TFBoletosDataRegistro, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV54TFBoletosDataRegistro_To, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV54TFBoletosDataRegistro_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV54TFBoletosDataRegistro_To, "99/99/99 99:99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFBOLETOSDATAPAGAMENTO",  "Data do Pagamento",  !((DateTime.MinValue==AV58TFBoletosDataPagamento)&&(DateTime.MinValue==AV59TFBoletosDataPagamento_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV58TFBoletosDataPagamento, 4, "/")),  ((DateTime.MinValue==AV58TFBoletosDataPagamento) ? "" : StringUtil.Trim( context.localUtil.Format( AV58TFBoletosDataPagamento, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV59TFBoletosDataPagamento_To, 4, "/")),  ((DateTime.MinValue==AV59TFBoletosDataPagamento_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV59TFBoletosDataPagamento_To, "99/99/99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFBOLETOSDATABAIXA",  "Data da Baixa",  !((DateTime.MinValue==AV63TFBoletosDataBaixa)&&(DateTime.MinValue==AV64TFBoletosDataBaixa_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV63TFBoletosDataBaixa, 4, "/")),  ((DateTime.MinValue==AV63TFBoletosDataBaixa) ? "" : StringUtil.Trim( context.localUtil.Format( AV63TFBoletosDataBaixa, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV64TFBoletosDataBaixa_To, 4, "/")),  ((DateTime.MinValue==AV64TFBoletosDataBaixa_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV64TFBoletosDataBaixa_To, "99/99/99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFBOLETOSVALORNOMINAL",  "Valor Nominal",  !((Convert.ToDecimal(0)==AV68TFBoletosValorNominal)&&(Convert.ToDecimal(0)==AV69TFBoletosValorNominal_To)),  0,  StringUtil.Trim( StringUtil.Str( AV68TFBoletosValorNominal, 18, 2)),  ((Convert.ToDecimal(0)==AV68TFBoletosValorNominal) ? "" : StringUtil.Trim( context.localUtil.Format( AV68TFBoletosValorNominal, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV69TFBoletosValorNominal_To, 18, 2)),  ((Convert.ToDecimal(0)==AV69TFBoletosValorNominal_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV69TFBoletosValorNominal_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFBOLETOSVALORPAGO",  "Valor Pago",  !((Convert.ToDecimal(0)==AV70TFBoletosValorPago)&&(Convert.ToDecimal(0)==AV71TFBoletosValorPago_To)),  0,  StringUtil.Trim( StringUtil.Str( AV70TFBoletosValorPago, 18, 2)),  ((Convert.ToDecimal(0)==AV70TFBoletosValorPago) ? "" : StringUtil.Trim( context.localUtil.Format( AV70TFBoletosValorPago, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV71TFBoletosValorPago_To, 18, 2)),  ((Convert.ToDecimal(0)==AV71TFBoletosValorPago_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV71TFBoletosValorPago_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFBOLETOSVALORDESCONTO",  "Desconto",  !((Convert.ToDecimal(0)==AV72TFBoletosValorDesconto)&&(Convert.ToDecimal(0)==AV73TFBoletosValorDesconto_To)),  0,  StringUtil.Trim( StringUtil.Str( AV72TFBoletosValorDesconto, 18, 2)),  ((Convert.ToDecimal(0)==AV72TFBoletosValorDesconto) ? "" : StringUtil.Trim( context.localUtil.Format( AV72TFBoletosValorDesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV73TFBoletosValorDesconto_To, 18, 2)),  ((Convert.ToDecimal(0)==AV73TFBoletosValorDesconto_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV73TFBoletosValorDesconto_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFBOLETOSVALORJUROS",  "Juros",  !((Convert.ToDecimal(0)==AV74TFBoletosValorJuros)&&(Convert.ToDecimal(0)==AV75TFBoletosValorJuros_To)),  0,  StringUtil.Trim( StringUtil.Str( AV74TFBoletosValorJuros, 18, 2)),  ((Convert.ToDecimal(0)==AV74TFBoletosValorJuros) ? "" : StringUtil.Trim( context.localUtil.Format( AV74TFBoletosValorJuros, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV75TFBoletosValorJuros_To, 18, 2)),  ((Convert.ToDecimal(0)==AV75TFBoletosValorJuros_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV75TFBoletosValorJuros_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFBOLETOSVALORMULTA",  "Multa",  !((Convert.ToDecimal(0)==AV76TFBoletosValorMulta)&&(Convert.ToDecimal(0)==AV77TFBoletosValorMulta_To)),  0,  StringUtil.Trim( StringUtil.Str( AV76TFBoletosValorMulta, 18, 2)),  ((Convert.ToDecimal(0)==AV76TFBoletosValorMulta) ? "" : StringUtil.Trim( context.localUtil.Format( AV76TFBoletosValorMulta, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV77TFBoletosValorMulta_To, 18, 2)),  ((Convert.ToDecimal(0)==AV77TFBoletosValorMulta_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV77TFBoletosValorMulta_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFBOLETOSSACADONOME",  "Nome do Sacado",  !String.IsNullOrEmpty(StringUtil.RTrim( AV78TFBoletosSacadoNome)),  0,  AV78TFBoletosSacadoNome,  AV78TFBoletosSacadoNome,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV79TFBoletosSacadoNome_Sel)),  AV79TFBoletosSacadoNome_Sel,  AV79TFBoletosSacadoNome_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFBOLETOSSACADODOCUMENTO",  "Documento do Sacado",  !String.IsNullOrEmpty(StringUtil.RTrim( AV80TFBoletosSacadoDocumento)),  0,  AV80TFBoletosSacadoDocumento,  AV80TFBoletosSacadoDocumento,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV81TFBoletosSacadoDocumento_Sel)),  AV81TFBoletosSacadoDocumento_Sel,  AV81TFBoletosSacadoDocumento_Sel) ;
         AV90AuxText = ((AV83TFBoletosSacadoTipoDocumento_Sels.Count==1) ? "["+((string)AV83TFBoletosSacadoTipoDocumento_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFBOLETOSSACADOTIPODOCUMENTO_SEL",  "Tipo Documento",  !(AV83TFBoletosSacadoTipoDocumento_Sels.Count==0),  0,  AV83TFBoletosSacadoTipoDocumento_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV90AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( AV90AuxText, "[CPF]", "CPF"), "[CNPJ]", "CNPJ")),  false,  "",  "") ;
         if ( ! (0==AV91CarteiraDeCobrancaId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&CARTEIRADECOBRANCAID";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV91CarteiraDeCobrancaId), 9, 0);
            AV10GridState.gxTpr_Filtervalues.Add(AV11GridStateFilterValue, 0);
         }
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV92Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV28DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV16DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "BOLETOSNOSSONUMERO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18BoletosNossoNumero1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Nosso Número",  AV17DynamicFiltersOperator1,  AV18BoletosNossoNumero1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV18BoletosNossoNumero1, "Contém"+" "+AV18BoletosNossoNumero1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV27DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV19DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV20DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "BOLETOSNOSSONUMERO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV22BoletosNossoNumero2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Nosso Número",  AV21DynamicFiltersOperator2,  AV22BoletosNossoNumero2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV22BoletosNossoNumero2, "Contém"+" "+AV22BoletosNossoNumero2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV27DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV23DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV24DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "BOLETOSNOSSONUMERO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV26BoletosNossoNumero3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Nosso Número",  AV25DynamicFiltersOperator3,  AV26BoletosNossoNumero3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV26BoletosNossoNumero3, "Contém"+" "+AV26BoletosNossoNumero3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV27DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
      }

      protected void S152( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV92Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Boleto";
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "CarteiraDeCobrancaId";
         AV9TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV91CarteiraDeCobrancaId), 9, 0);
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV31Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_89_A82( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "", true, 0, "HLP_BoletoWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_boletosnossonumero3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBoletosnossonumero3_Internalname, "Boletos Nosso Numero3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBoletosnossonumero3_Internalname, AV26BoletosNossoNumero3, StringUtil.RTrim( context.localUtil.Format( AV26BoletosNossoNumero3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBoletosnossonumero3_Jsonclick, 0, "Attribute", "", "", "", "", edtavBoletosnossonumero3_Visible, edtavBoletosnossonumero3_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_BoletoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_BoletoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_89_A82e( true) ;
         }
         else
         {
            wb_table3_89_A82e( false) ;
         }
      }

      protected void wb_table2_67_A82( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "", true, 0, "HLP_BoletoWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_boletosnossonumero2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBoletosnossonumero2_Internalname, "Boletos Nosso Numero2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBoletosnossonumero2_Internalname, AV22BoletosNossoNumero2, StringUtil.RTrim( context.localUtil.Format( AV22BoletosNossoNumero2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBoletosnossonumero2_Jsonclick, 0, "Attribute", "", "", "", "", edtavBoletosnossonumero2_Visible, edtavBoletosnossonumero2_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_BoletoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_BoletoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_BoletoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_67_A82e( true) ;
         }
         else
         {
            wb_table2_67_A82e( false) ;
         }
      }

      protected void wb_table1_45_A82( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_BoletoWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_boletosnossonumero1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBoletosnossonumero1_Internalname, "Boletos Nosso Numero1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBoletosnossonumero1_Internalname, AV18BoletosNossoNumero1, StringUtil.RTrim( context.localUtil.Format( AV18BoletosNossoNumero1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBoletosnossonumero1_Jsonclick, 0, "Attribute", "", "", "", "", edtavBoletosnossonumero1_Visible, edtavBoletosnossonumero1_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_BoletoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_BoletoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_BoletoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_45_A82e( true) ;
         }
         else
         {
            wb_table1_45_A82e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV91CarteiraDeCobrancaId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV91CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(AV91CarteiraDeCobrancaId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vCARTEIRADECOBRANCAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV91CarteiraDeCobrancaId), "ZZZZZZZZ9"), context));
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
         PAA82( ) ;
         WSA82( ) ;
         WEA82( ) ;
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
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019293968", true, true);
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
         context.AddJavascriptSource("boletoww.js", "?202561019293968", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1072( )
      {
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_107_idx;
         edtBoletosId_Internalname = "BOLETOSID_"+sGXsfl_107_idx;
         edtCarteiraDeCobrancaId_Internalname = "CARTEIRADECOBRANCAID_"+sGXsfl_107_idx;
         edtTituloId_Internalname = "TITULOID_"+sGXsfl_107_idx;
         edtBoletosNossoNumero_Internalname = "BOLETOSNOSSONUMERO_"+sGXsfl_107_idx;
         edtBoletosSeuNumero_Internalname = "BOLETOSSEUNUMERO_"+sGXsfl_107_idx;
         edtBoletosNumero_Internalname = "BOLETOSNUMERO_"+sGXsfl_107_idx;
         edtBoletosLinhaDigitavel_Internalname = "BOLETOSLINHADIGITAVEL_"+sGXsfl_107_idx;
         edtBoletosCodigoDeBarras_Internalname = "BOLETOSCODIGODEBARRAS_"+sGXsfl_107_idx;
         cmbBoletosStatus_Internalname = "BOLETOSSTATUS_"+sGXsfl_107_idx;
         edtBoletosDataEmissao_Internalname = "BOLETOSDATAEMISSAO_"+sGXsfl_107_idx;
         edtBoletosDataVencimento_Internalname = "BOLETOSDATAVENCIMENTO_"+sGXsfl_107_idx;
         edtBoletosDataRegistro_Internalname = "BOLETOSDATAREGISTRO_"+sGXsfl_107_idx;
         edtBoletosDataPagamento_Internalname = "BOLETOSDATAPAGAMENTO_"+sGXsfl_107_idx;
         edtBoletosDataBaixa_Internalname = "BOLETOSDATABAIXA_"+sGXsfl_107_idx;
         edtBoletosValorNominal_Internalname = "BOLETOSVALORNOMINAL_"+sGXsfl_107_idx;
         edtBoletosValorPago_Internalname = "BOLETOSVALORPAGO_"+sGXsfl_107_idx;
         edtBoletosValorDesconto_Internalname = "BOLETOSVALORDESCONTO_"+sGXsfl_107_idx;
         edtBoletosValorJuros_Internalname = "BOLETOSVALORJUROS_"+sGXsfl_107_idx;
         edtBoletosValorMulta_Internalname = "BOLETOSVALORMULTA_"+sGXsfl_107_idx;
         edtBoletosSacadoNome_Internalname = "BOLETOSSACADONOME_"+sGXsfl_107_idx;
         edtBoletosSacadoDocumento_Internalname = "BOLETOSSACADODOCUMENTO_"+sGXsfl_107_idx;
         cmbBoletosSacadoTipoDocumento_Internalname = "BOLETOSSACADOTIPODOCUMENTO_"+sGXsfl_107_idx;
      }

      protected void SubsflControlProps_fel_1072( )
      {
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_107_fel_idx;
         edtBoletosId_Internalname = "BOLETOSID_"+sGXsfl_107_fel_idx;
         edtCarteiraDeCobrancaId_Internalname = "CARTEIRADECOBRANCAID_"+sGXsfl_107_fel_idx;
         edtTituloId_Internalname = "TITULOID_"+sGXsfl_107_fel_idx;
         edtBoletosNossoNumero_Internalname = "BOLETOSNOSSONUMERO_"+sGXsfl_107_fel_idx;
         edtBoletosSeuNumero_Internalname = "BOLETOSSEUNUMERO_"+sGXsfl_107_fel_idx;
         edtBoletosNumero_Internalname = "BOLETOSNUMERO_"+sGXsfl_107_fel_idx;
         edtBoletosLinhaDigitavel_Internalname = "BOLETOSLINHADIGITAVEL_"+sGXsfl_107_fel_idx;
         edtBoletosCodigoDeBarras_Internalname = "BOLETOSCODIGODEBARRAS_"+sGXsfl_107_fel_idx;
         cmbBoletosStatus_Internalname = "BOLETOSSTATUS_"+sGXsfl_107_fel_idx;
         edtBoletosDataEmissao_Internalname = "BOLETOSDATAEMISSAO_"+sGXsfl_107_fel_idx;
         edtBoletosDataVencimento_Internalname = "BOLETOSDATAVENCIMENTO_"+sGXsfl_107_fel_idx;
         edtBoletosDataRegistro_Internalname = "BOLETOSDATAREGISTRO_"+sGXsfl_107_fel_idx;
         edtBoletosDataPagamento_Internalname = "BOLETOSDATAPAGAMENTO_"+sGXsfl_107_fel_idx;
         edtBoletosDataBaixa_Internalname = "BOLETOSDATABAIXA_"+sGXsfl_107_fel_idx;
         edtBoletosValorNominal_Internalname = "BOLETOSVALORNOMINAL_"+sGXsfl_107_fel_idx;
         edtBoletosValorPago_Internalname = "BOLETOSVALORPAGO_"+sGXsfl_107_fel_idx;
         edtBoletosValorDesconto_Internalname = "BOLETOSVALORDESCONTO_"+sGXsfl_107_fel_idx;
         edtBoletosValorJuros_Internalname = "BOLETOSVALORJUROS_"+sGXsfl_107_fel_idx;
         edtBoletosValorMulta_Internalname = "BOLETOSVALORMULTA_"+sGXsfl_107_fel_idx;
         edtBoletosSacadoNome_Internalname = "BOLETOSSACADONOME_"+sGXsfl_107_fel_idx;
         edtBoletosSacadoDocumento_Internalname = "BOLETOSSACADODOCUMENTO_"+sGXsfl_107_fel_idx;
         cmbBoletosSacadoTipoDocumento_Internalname = "BOLETOSSACADOTIPODOCUMENTO_"+sGXsfl_107_fel_idx;
      }

      protected void sendrow_1072( )
      {
         sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
         SubsflControlProps_1072( ) ;
         WBA80( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'" + sGXsfl_107_idx + "',107)\"";
            if ( ( cmbavGridactiongroup1.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_107_idx;
               cmbavGridactiongroup1.Name = GXCCtl;
               cmbavGridactiongroup1.WebTags = "";
               if ( cmbavGridactiongroup1.ItemCount > 0 )
               {
                  AV89GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV89GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV89GridActionGroup1), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactiongroup1,(string)cmbavGridactiongroup1_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV89GridActionGroup1), 4, 0)),(short)1,(string)cmbavGridactiongroup1_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONGROUP1.CLICK."+sGXsfl_107_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"",(string)"",(bool)true,(short)0});
            cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV89GridActionGroup1), 4, 0));
            AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", (string)(cmbavGridactiongroup1.ToJavascriptSource()), !bGXsfl_107_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBoletosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1077BoletosId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1077BoletosId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtBoletosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCarteiraDeCobrancaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1069CarteiraDeCobrancaId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1069CarteiraDeCobrancaId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCarteiraDeCobrancaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A261TituloId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBoletosNossoNumero_Internalname,(string)A1078BoletosNossoNumero,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtBoletosNossoNumero_Link,(string)"",(string)"",(string)"",(string)edtBoletosNossoNumero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBoletosSeuNumero_Internalname,(string)A1079BoletosSeuNumero,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtBoletosSeuNumero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBoletosNumero_Internalname,(string)A1080BoletosNumero,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtBoletosNumero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBoletosLinhaDigitavel_Internalname,(string)A1081BoletosLinhaDigitavel,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtBoletosLinhaDigitavel_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)54,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBoletosCodigoDeBarras_Internalname,(string)A1082BoletosCodigoDeBarras,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtBoletosCodigoDeBarras_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)44,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbBoletosStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "BOLETOSSTATUS_" + sGXsfl_107_idx;
               cmbBoletosStatus.Name = GXCCtl;
               cmbBoletosStatus.WebTags = "";
               cmbBoletosStatus.addItem("RASCUNHO", "Rascunho", 0);
               cmbBoletosStatus.addItem("REGISTRADO", "Registrado", 0);
               cmbBoletosStatus.addItem("LIQUIDADO", "Liquidado", 0);
               cmbBoletosStatus.addItem("BAIXADO", "Baixado", 0);
               cmbBoletosStatus.addItem("VENCIDO", "Vencido", 0);
               cmbBoletosStatus.addItem("ERRO", "Erro", 0);
               if ( cmbBoletosStatus.ItemCount > 0 )
               {
                  A1083BoletosStatus = cmbBoletosStatus.getValidValue(A1083BoletosStatus);
                  n1083BoletosStatus = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbBoletosStatus,(string)cmbBoletosStatus_Internalname,StringUtil.RTrim( A1083BoletosStatus),(short)1,(string)cmbBoletosStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbBoletosStatus.CurrentValue = StringUtil.RTrim( A1083BoletosStatus);
            AssignProp("", false, cmbBoletosStatus_Internalname, "Values", (string)(cmbBoletosStatus.ToJavascriptSource()), !bGXsfl_107_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBoletosDataEmissao_Internalname,context.localUtil.Format(A1084BoletosDataEmissao, "99/99/99"),context.localUtil.Format( A1084BoletosDataEmissao, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtBoletosDataEmissao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBoletosDataVencimento_Internalname,context.localUtil.Format(A1085BoletosDataVencimento, "99/99/99"),context.localUtil.Format( A1085BoletosDataVencimento, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtBoletosDataVencimento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBoletosDataRegistro_Internalname,context.localUtil.TToC( A1086BoletosDataRegistro, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A1086BoletosDataRegistro, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtBoletosDataRegistro_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBoletosDataPagamento_Internalname,context.localUtil.Format(A1087BoletosDataPagamento, "99/99/99"),context.localUtil.Format( A1087BoletosDataPagamento, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtBoletosDataPagamento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBoletosDataBaixa_Internalname,context.localUtil.Format(A1088BoletosDataBaixa, "99/99/99"),context.localUtil.Format( A1088BoletosDataBaixa, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtBoletosDataBaixa_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBoletosValorNominal_Internalname,StringUtil.LTrim( StringUtil.NToC( A1089BoletosValorNominal, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A1089BoletosValorNominal, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtBoletosValorNominal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBoletosValorPago_Internalname,StringUtil.LTrim( StringUtil.NToC( A1090BoletosValorPago, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A1090BoletosValorPago, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtBoletosValorPago_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBoletosValorDesconto_Internalname,StringUtil.LTrim( StringUtil.NToC( A1091BoletosValorDesconto, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A1091BoletosValorDesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtBoletosValorDesconto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBoletosValorJuros_Internalname,StringUtil.LTrim( StringUtil.NToC( A1092BoletosValorJuros, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A1092BoletosValorJuros, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtBoletosValorJuros_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBoletosValorMulta_Internalname,StringUtil.LTrim( StringUtil.NToC( A1093BoletosValorMulta, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A1093BoletosValorMulta, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtBoletosValorMulta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBoletosSacadoNome_Internalname,(string)A1094BoletosSacadoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtBoletosSacadoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBoletosSacadoDocumento_Internalname,(string)A1095BoletosSacadoDocumento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtBoletosSacadoDocumento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbBoletosSacadoTipoDocumento.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "BOLETOSSACADOTIPODOCUMENTO_" + sGXsfl_107_idx;
               cmbBoletosSacadoTipoDocumento.Name = GXCCtl;
               cmbBoletosSacadoTipoDocumento.WebTags = "";
               cmbBoletosSacadoTipoDocumento.addItem("CPF", "CPF", 0);
               cmbBoletosSacadoTipoDocumento.addItem("CNPJ", "CNPJ", 0);
               if ( cmbBoletosSacadoTipoDocumento.ItemCount > 0 )
               {
                  A1096BoletosSacadoTipoDocumento = cmbBoletosSacadoTipoDocumento.getValidValue(A1096BoletosSacadoTipoDocumento);
                  n1096BoletosSacadoTipoDocumento = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbBoletosSacadoTipoDocumento,(string)cmbBoletosSacadoTipoDocumento_Internalname,StringUtil.RTrim( A1096BoletosSacadoTipoDocumento),(short)1,(string)cmbBoletosSacadoTipoDocumento_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbBoletosSacadoTipoDocumento.CurrentValue = StringUtil.RTrim( A1096BoletosSacadoTipoDocumento);
            AssignProp("", false, cmbBoletosSacadoTipoDocumento_Internalname, "Values", (string)(cmbBoletosSacadoTipoDocumento.ToJavascriptSource()), !bGXsfl_107_Refreshing);
            send_integrity_lvl_hashesA82( ) ;
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
         cmbavDynamicfiltersselector1.addItem("BOLETOSNOSSONUMERO", "Nosso Número", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV16DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV16DynamicFiltersSelector1);
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("BOLETOSNOSSONUMERO", "Nosso Número", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV20DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV20DynamicFiltersSelector2);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("BOLETOSNOSSONUMERO", "Nosso Número", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV24DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV24DynamicFiltersSelector3);
            AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_107_idx;
         cmbavGridactiongroup1.Name = GXCCtl;
         cmbavGridactiongroup1.WebTags = "";
         if ( cmbavGridactiongroup1.ItemCount > 0 )
         {
            AV89GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV89GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV89GridActionGroup1), 4, 0));
         }
         GXCCtl = "BOLETOSSTATUS_" + sGXsfl_107_idx;
         cmbBoletosStatus.Name = GXCCtl;
         cmbBoletosStatus.WebTags = "";
         cmbBoletosStatus.addItem("RASCUNHO", "Rascunho", 0);
         cmbBoletosStatus.addItem("REGISTRADO", "Registrado", 0);
         cmbBoletosStatus.addItem("LIQUIDADO", "Liquidado", 0);
         cmbBoletosStatus.addItem("BAIXADO", "Baixado", 0);
         cmbBoletosStatus.addItem("VENCIDO", "Vencido", 0);
         cmbBoletosStatus.addItem("ERRO", "Erro", 0);
         if ( cmbBoletosStatus.ItemCount > 0 )
         {
            A1083BoletosStatus = cmbBoletosStatus.getValidValue(A1083BoletosStatus);
            n1083BoletosStatus = false;
         }
         GXCCtl = "BOLETOSSACADOTIPODOCUMENTO_" + sGXsfl_107_idx;
         cmbBoletosSacadoTipoDocumento.Name = GXCCtl;
         cmbBoletosSacadoTipoDocumento.WebTags = "";
         cmbBoletosSacadoTipoDocumento.addItem("CPF", "CPF", 0);
         cmbBoletosSacadoTipoDocumento.addItem("CNPJ", "CNPJ", 0);
         if ( cmbBoletosSacadoTipoDocumento.ItemCount > 0 )
         {
            A1096BoletosSacadoTipoDocumento = cmbBoletosSacadoTipoDocumento.getValidValue(A1096BoletosSacadoTipoDocumento);
            n1096BoletosSacadoTipoDocumento = false;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Cobranca Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nosso Número") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Seu Número") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Número") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Linha Digitável") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "De Barras") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Emissão") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Vencimento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Data de Registro") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Data do Pagamento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Data da Baixa") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Valor Nominal") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Valor Pago") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Desconto") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Juros") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Multa") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nome do Sacado") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Documento do Sacado") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo Documento") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV89GridActionGroup1), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1077BoletosId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1069CarteiraDeCobrancaId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1078BoletosNossoNumero));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtBoletosNossoNumero_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1079BoletosSeuNumero));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1080BoletosNumero));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1081BoletosLinhaDigitavel));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1082BoletosCodigoDeBarras));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1083BoletosStatus));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A1084BoletosDataEmissao, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A1085BoletosDataVencimento, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A1086BoletosDataRegistro, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A1087BoletosDataPagamento, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A1088BoletosDataBaixa, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A1089BoletosValorNominal, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A1090BoletosValorPago, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A1091BoletosValorDesconto, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A1092BoletosValorJuros, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A1093BoletosValorMulta, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1094BoletosSacadoNome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1095BoletosSacadoDocumento));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1096BoletosSacadoTipoDocumento));
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
         edtavBoletosnossonumero1_Internalname = "vBOLETOSNOSSONUMERO1";
         cellFilter_boletosnossonumero1_cell_Internalname = "FILTER_BOLETOSNOSSONUMERO1_CELL";
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
         edtavBoletosnossonumero2_Internalname = "vBOLETOSNOSSONUMERO2";
         cellFilter_boletosnossonumero2_cell_Internalname = "FILTER_BOLETOSNOSSONUMERO2_CELL";
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
         edtavBoletosnossonumero3_Internalname = "vBOLETOSNOSSONUMERO3";
         cellFilter_boletosnossonumero3_cell_Internalname = "FILTER_BOLETOSNOSSONUMERO3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1";
         edtBoletosId_Internalname = "BOLETOSID";
         edtCarteiraDeCobrancaId_Internalname = "CARTEIRADECOBRANCAID";
         edtTituloId_Internalname = "TITULOID";
         edtBoletosNossoNumero_Internalname = "BOLETOSNOSSONUMERO";
         edtBoletosSeuNumero_Internalname = "BOLETOSSEUNUMERO";
         edtBoletosNumero_Internalname = "BOLETOSNUMERO";
         edtBoletosLinhaDigitavel_Internalname = "BOLETOSLINHADIGITAVEL";
         edtBoletosCodigoDeBarras_Internalname = "BOLETOSCODIGODEBARRAS";
         cmbBoletosStatus_Internalname = "BOLETOSSTATUS";
         edtBoletosDataEmissao_Internalname = "BOLETOSDATAEMISSAO";
         edtBoletosDataVencimento_Internalname = "BOLETOSDATAVENCIMENTO";
         edtBoletosDataRegistro_Internalname = "BOLETOSDATAREGISTRO";
         edtBoletosDataPagamento_Internalname = "BOLETOSDATAPAGAMENTO";
         edtBoletosDataBaixa_Internalname = "BOLETOSDATABAIXA";
         edtBoletosValorNominal_Internalname = "BOLETOSVALORNOMINAL";
         edtBoletosValorPago_Internalname = "BOLETOSVALORPAGO";
         edtBoletosValorDesconto_Internalname = "BOLETOSVALORDESCONTO";
         edtBoletosValorJuros_Internalname = "BOLETOSVALORJUROS";
         edtBoletosValorMulta_Internalname = "BOLETOSVALORMULTA";
         edtBoletosSacadoNome_Internalname = "BOLETOSSACADONOME";
         edtBoletosSacadoDocumento_Internalname = "BOLETOSSACADODOCUMENTO";
         cmbBoletosSacadoTipoDocumento_Internalname = "BOLETOSSACADOTIPODOCUMENTO";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_boletosdataemissaoauxdatetext_Internalname = "vDDO_BOLETOSDATAEMISSAOAUXDATETEXT";
         Tfboletosdataemissao_rangepicker_Internalname = "TFBOLETOSDATAEMISSAO_RANGEPICKER";
         divDdo_boletosdataemissaoauxdates_Internalname = "DDO_BOLETOSDATAEMISSAOAUXDATES";
         edtavDdo_boletosdatavencimentoauxdatetext_Internalname = "vDDO_BOLETOSDATAVENCIMENTOAUXDATETEXT";
         Tfboletosdatavencimento_rangepicker_Internalname = "TFBOLETOSDATAVENCIMENTO_RANGEPICKER";
         divDdo_boletosdatavencimentoauxdates_Internalname = "DDO_BOLETOSDATAVENCIMENTOAUXDATES";
         edtavDdo_boletosdataregistroauxdatetext_Internalname = "vDDO_BOLETOSDATAREGISTROAUXDATETEXT";
         Tfboletosdataregistro_rangepicker_Internalname = "TFBOLETOSDATAREGISTRO_RANGEPICKER";
         divDdo_boletosdataregistroauxdates_Internalname = "DDO_BOLETOSDATAREGISTROAUXDATES";
         edtavDdo_boletosdatapagamentoauxdatetext_Internalname = "vDDO_BOLETOSDATAPAGAMENTOAUXDATETEXT";
         Tfboletosdatapagamento_rangepicker_Internalname = "TFBOLETOSDATAPAGAMENTO_RANGEPICKER";
         divDdo_boletosdatapagamentoauxdates_Internalname = "DDO_BOLETOSDATAPAGAMENTOAUXDATES";
         edtavDdo_boletosdatabaixaauxdatetext_Internalname = "vDDO_BOLETOSDATABAIXAAUXDATETEXT";
         Tfboletosdatabaixa_rangepicker_Internalname = "TFBOLETOSDATABAIXA_RANGEPICKER";
         divDdo_boletosdatabaixaauxdates_Internalname = "DDO_BOLETOSDATABAIXAAUXDATES";
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
         cmbBoletosSacadoTipoDocumento_Jsonclick = "";
         edtBoletosSacadoDocumento_Jsonclick = "";
         edtBoletosSacadoNome_Jsonclick = "";
         edtBoletosValorMulta_Jsonclick = "";
         edtBoletosValorJuros_Jsonclick = "";
         edtBoletosValorDesconto_Jsonclick = "";
         edtBoletosValorPago_Jsonclick = "";
         edtBoletosValorNominal_Jsonclick = "";
         edtBoletosDataBaixa_Jsonclick = "";
         edtBoletosDataPagamento_Jsonclick = "";
         edtBoletosDataRegistro_Jsonclick = "";
         edtBoletosDataVencimento_Jsonclick = "";
         edtBoletosDataEmissao_Jsonclick = "";
         cmbBoletosStatus_Jsonclick = "";
         edtBoletosCodigoDeBarras_Jsonclick = "";
         edtBoletosLinhaDigitavel_Jsonclick = "";
         edtBoletosNumero_Jsonclick = "";
         edtBoletosSeuNumero_Jsonclick = "";
         edtBoletosNossoNumero_Jsonclick = "";
         edtBoletosNossoNumero_Link = "";
         edtTituloId_Jsonclick = "";
         edtCarteiraDeCobrancaId_Jsonclick = "";
         edtBoletosId_Jsonclick = "";
         cmbavGridactiongroup1_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavBoletosnossonumero1_Jsonclick = "";
         edtavBoletosnossonumero1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavBoletosnossonumero2_Jsonclick = "";
         edtavBoletosnossonumero2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavBoletosnossonumero3_Jsonclick = "";
         edtavBoletosnossonumero3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavBoletosnossonumero3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavBoletosnossonumero2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavBoletosnossonumero1_Visible = 1;
         cmbBoletosSacadoTipoDocumento.Enabled = 0;
         edtBoletosSacadoDocumento_Enabled = 0;
         edtBoletosSacadoNome_Enabled = 0;
         edtBoletosValorMulta_Enabled = 0;
         edtBoletosValorJuros_Enabled = 0;
         edtBoletosValorDesconto_Enabled = 0;
         edtBoletosValorPago_Enabled = 0;
         edtBoletosValorNominal_Enabled = 0;
         edtBoletosDataBaixa_Enabled = 0;
         edtBoletosDataPagamento_Enabled = 0;
         edtBoletosDataRegistro_Enabled = 0;
         edtBoletosDataVencimento_Enabled = 0;
         edtBoletosDataEmissao_Enabled = 0;
         cmbBoletosStatus.Enabled = 0;
         edtBoletosCodigoDeBarras_Enabled = 0;
         edtBoletosLinhaDigitavel_Enabled = 0;
         edtBoletosNumero_Enabled = 0;
         edtBoletosSeuNumero_Enabled = 0;
         edtBoletosNossoNumero_Enabled = 0;
         edtTituloId_Enabled = 0;
         edtCarteiraDeCobrancaId_Enabled = 0;
         edtBoletosId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_boletosdatabaixaauxdatetext_Jsonclick = "";
         edtavDdo_boletosdatapagamentoauxdatetext_Jsonclick = "";
         edtavDdo_boletosdataregistroauxdatetext_Jsonclick = "";
         edtavDdo_boletosdatavencimentoauxdatetext_Jsonclick = "";
         edtavDdo_boletosdataemissaoauxdatetext_Jsonclick = "";
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "|||||||||18.2|18.2|18.2|18.2|18.2|||";
         Ddo_grid_Datalistproc = "BoletoWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||RASCUNHO:Rascunho,REGISTRADO:Registrado,LIQUIDADO:Liquidado,BAIXADO:Baixado,VENCIDO:Vencido,ERRO:Erro|||||||||||||CPF:CPF,CNPJ:CNPJ";
         Ddo_grid_Allowmultipleselection = "|||T|||||||||||||T";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|FixedValues|||||||||||Dynamic|Dynamic|FixedValues";
         Ddo_grid_Includedatalist = "T|T|T|T|||||||||||T|T|T";
         Ddo_grid_Filterisrange = "||||P|P|P|P|P|T|T|T|T|T|||";
         Ddo_grid_Filtertype = "Character|Character|Character||Date|Date|Date|Date|Date|Numeric|Numeric|Numeric|Numeric|Numeric|Character|Character|";
         Ddo_grid_Includefilter = "T|T|T||T|T|T|T|T|T|T|T|T|T|T|T|";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17";
         Ddo_grid_Columnids = "4:BoletosNossoNumero|5:BoletosSeuNumero|6:BoletosNumero|9:BoletosStatus|10:BoletosDataEmissao|11:BoletosDataVencimento|12:BoletosDataRegistro|13:BoletosDataPagamento|14:BoletosDataBaixa|15:BoletosValorNominal|16:BoletosValorPago|17:BoletosValorDesconto|18:BoletosValorJuros|19:BoletosValorMulta|20:BoletosSacadoNome|21:BoletosSacadoDocumento|22:BoletosSacadoTipoDocumento";
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
         Form.Caption = " Boleto";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18BoletosNossoNumero1","fld":"vBOLETOSNOSSONUMERO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22BoletosNossoNumero2","fld":"vBOLETOSNOSSONUMERO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26BoletosNossoNumero3","fld":"vBOLETOSNOSSONUMERO3","type":"svchar"},{"av":"AV92Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV91CarteiraDeCobrancaId","fld":"vCARTEIRADECOBRANCAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFBoletosNossoNumero","fld":"vTFBOLETOSNOSSONUMERO","type":"svchar"},{"av":"AV36TFBoletosNossoNumero_Sel","fld":"vTFBOLETOSNOSSONUMERO_SEL","type":"svchar"},{"av":"AV37TFBoletosSeuNumero","fld":"vTFBOLETOSSEUNUMERO","type":"svchar"},{"av":"AV38TFBoletosSeuNumero_Sel","fld":"vTFBOLETOSSEUNUMERO_SEL","type":"svchar"},{"av":"AV39TFBoletosNumero","fld":"vTFBOLETOSNUMERO","type":"svchar"},{"av":"AV40TFBoletosNumero_Sel","fld":"vTFBOLETOSNUMERO_SEL","type":"svchar"},{"av":"AV42TFBoletosStatus_Sels","fld":"vTFBOLETOSSTATUS_SELS","type":""},{"av":"AV43TFBoletosDataEmissao","fld":"vTFBOLETOSDATAEMISSAO","type":"date"},{"av":"AV44TFBoletosDataEmissao_To","fld":"vTFBOLETOSDATAEMISSAO_TO","type":"date"},{"av":"AV48TFBoletosDataVencimento","fld":"vTFBOLETOSDATAVENCIMENTO","type":"date"},{"av":"AV49TFBoletosDataVencimento_To","fld":"vTFBOLETOSDATAVENCIMENTO_TO","type":"date"},{"av":"AV53TFBoletosDataRegistro","fld":"vTFBOLETOSDATAREGISTRO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV54TFBoletosDataRegistro_To","fld":"vTFBOLETOSDATAREGISTRO_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV58TFBoletosDataPagamento","fld":"vTFBOLETOSDATAPAGAMENTO","type":"date"},{"av":"AV59TFBoletosDataPagamento_To","fld":"vTFBOLETOSDATAPAGAMENTO_TO","type":"date"},{"av":"AV63TFBoletosDataBaixa","fld":"vTFBOLETOSDATABAIXA","type":"date"},{"av":"AV64TFBoletosDataBaixa_To","fld":"vTFBOLETOSDATABAIXA_TO","type":"date"},{"av":"AV68TFBoletosValorNominal","fld":"vTFBOLETOSVALORNOMINAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV69TFBoletosValorNominal_To","fld":"vTFBOLETOSVALORNOMINAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV70TFBoletosValorPago","fld":"vTFBOLETOSVALORPAGO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV71TFBoletosValorPago_To","fld":"vTFBOLETOSVALORPAGO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV72TFBoletosValorDesconto","fld":"vTFBOLETOSVALORDESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV73TFBoletosValorDesconto_To","fld":"vTFBOLETOSVALORDESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV74TFBoletosValorJuros","fld":"vTFBOLETOSVALORJUROS","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV75TFBoletosValorJuros_To","fld":"vTFBOLETOSVALORJUROS_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV76TFBoletosValorMulta","fld":"vTFBOLETOSVALORMULTA","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV77TFBoletosValorMulta_To","fld":"vTFBOLETOSVALORMULTA_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFBoletosSacadoNome","fld":"vTFBOLETOSSACADONOME","type":"svchar"},{"av":"AV79TFBoletosSacadoNome_Sel","fld":"vTFBOLETOSSACADONOME_SEL","type":"svchar"},{"av":"AV80TFBoletosSacadoDocumento","fld":"vTFBOLETOSSACADODOCUMENTO","type":"svchar"},{"av":"AV81TFBoletosSacadoDocumento_Sel","fld":"vTFBOLETOSSACADODOCUMENTO_SEL","type":"svchar"},{"av":"AV83TFBoletosSacadoTipoDocumento_Sels","fld":"vTFBOLETOSSACADOTIPODOCUMENTO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV86GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV87GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV88GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12A82","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18BoletosNossoNumero1","fld":"vBOLETOSNOSSONUMERO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22BoletosNossoNumero2","fld":"vBOLETOSNOSSONUMERO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26BoletosNossoNumero3","fld":"vBOLETOSNOSSONUMERO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV92Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV91CarteiraDeCobrancaId","fld":"vCARTEIRADECOBRANCAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFBoletosNossoNumero","fld":"vTFBOLETOSNOSSONUMERO","type":"svchar"},{"av":"AV36TFBoletosNossoNumero_Sel","fld":"vTFBOLETOSNOSSONUMERO_SEL","type":"svchar"},{"av":"AV37TFBoletosSeuNumero","fld":"vTFBOLETOSSEUNUMERO","type":"svchar"},{"av":"AV38TFBoletosSeuNumero_Sel","fld":"vTFBOLETOSSEUNUMERO_SEL","type":"svchar"},{"av":"AV39TFBoletosNumero","fld":"vTFBOLETOSNUMERO","type":"svchar"},{"av":"AV40TFBoletosNumero_Sel","fld":"vTFBOLETOSNUMERO_SEL","type":"svchar"},{"av":"AV42TFBoletosStatus_Sels","fld":"vTFBOLETOSSTATUS_SELS","type":""},{"av":"AV43TFBoletosDataEmissao","fld":"vTFBOLETOSDATAEMISSAO","type":"date"},{"av":"AV44TFBoletosDataEmissao_To","fld":"vTFBOLETOSDATAEMISSAO_TO","type":"date"},{"av":"AV48TFBoletosDataVencimento","fld":"vTFBOLETOSDATAVENCIMENTO","type":"date"},{"av":"AV49TFBoletosDataVencimento_To","fld":"vTFBOLETOSDATAVENCIMENTO_TO","type":"date"},{"av":"AV53TFBoletosDataRegistro","fld":"vTFBOLETOSDATAREGISTRO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV54TFBoletosDataRegistro_To","fld":"vTFBOLETOSDATAREGISTRO_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV58TFBoletosDataPagamento","fld":"vTFBOLETOSDATAPAGAMENTO","type":"date"},{"av":"AV59TFBoletosDataPagamento_To","fld":"vTFBOLETOSDATAPAGAMENTO_TO","type":"date"},{"av":"AV63TFBoletosDataBaixa","fld":"vTFBOLETOSDATABAIXA","type":"date"},{"av":"AV64TFBoletosDataBaixa_To","fld":"vTFBOLETOSDATABAIXA_TO","type":"date"},{"av":"AV68TFBoletosValorNominal","fld":"vTFBOLETOSVALORNOMINAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV69TFBoletosValorNominal_To","fld":"vTFBOLETOSVALORNOMINAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV70TFBoletosValorPago","fld":"vTFBOLETOSVALORPAGO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV71TFBoletosValorPago_To","fld":"vTFBOLETOSVALORPAGO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV72TFBoletosValorDesconto","fld":"vTFBOLETOSVALORDESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV73TFBoletosValorDesconto_To","fld":"vTFBOLETOSVALORDESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV74TFBoletosValorJuros","fld":"vTFBOLETOSVALORJUROS","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV75TFBoletosValorJuros_To","fld":"vTFBOLETOSVALORJUROS_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV76TFBoletosValorMulta","fld":"vTFBOLETOSVALORMULTA","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV77TFBoletosValorMulta_To","fld":"vTFBOLETOSVALORMULTA_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFBoletosSacadoNome","fld":"vTFBOLETOSSACADONOME","type":"svchar"},{"av":"AV79TFBoletosSacadoNome_Sel","fld":"vTFBOLETOSSACADONOME_SEL","type":"svchar"},{"av":"AV80TFBoletosSacadoDocumento","fld":"vTFBOLETOSSACADODOCUMENTO","type":"svchar"},{"av":"AV81TFBoletosSacadoDocumento_Sel","fld":"vTFBOLETOSSACADODOCUMENTO_SEL","type":"svchar"},{"av":"AV83TFBoletosSacadoTipoDocumento_Sels","fld":"vTFBOLETOSSACADOTIPODOCUMENTO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13A82","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18BoletosNossoNumero1","fld":"vBOLETOSNOSSONUMERO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22BoletosNossoNumero2","fld":"vBOLETOSNOSSONUMERO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26BoletosNossoNumero3","fld":"vBOLETOSNOSSONUMERO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV92Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV91CarteiraDeCobrancaId","fld":"vCARTEIRADECOBRANCAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFBoletosNossoNumero","fld":"vTFBOLETOSNOSSONUMERO","type":"svchar"},{"av":"AV36TFBoletosNossoNumero_Sel","fld":"vTFBOLETOSNOSSONUMERO_SEL","type":"svchar"},{"av":"AV37TFBoletosSeuNumero","fld":"vTFBOLETOSSEUNUMERO","type":"svchar"},{"av":"AV38TFBoletosSeuNumero_Sel","fld":"vTFBOLETOSSEUNUMERO_SEL","type":"svchar"},{"av":"AV39TFBoletosNumero","fld":"vTFBOLETOSNUMERO","type":"svchar"},{"av":"AV40TFBoletosNumero_Sel","fld":"vTFBOLETOSNUMERO_SEL","type":"svchar"},{"av":"AV42TFBoletosStatus_Sels","fld":"vTFBOLETOSSTATUS_SELS","type":""},{"av":"AV43TFBoletosDataEmissao","fld":"vTFBOLETOSDATAEMISSAO","type":"date"},{"av":"AV44TFBoletosDataEmissao_To","fld":"vTFBOLETOSDATAEMISSAO_TO","type":"date"},{"av":"AV48TFBoletosDataVencimento","fld":"vTFBOLETOSDATAVENCIMENTO","type":"date"},{"av":"AV49TFBoletosDataVencimento_To","fld":"vTFBOLETOSDATAVENCIMENTO_TO","type":"date"},{"av":"AV53TFBoletosDataRegistro","fld":"vTFBOLETOSDATAREGISTRO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV54TFBoletosDataRegistro_To","fld":"vTFBOLETOSDATAREGISTRO_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV58TFBoletosDataPagamento","fld":"vTFBOLETOSDATAPAGAMENTO","type":"date"},{"av":"AV59TFBoletosDataPagamento_To","fld":"vTFBOLETOSDATAPAGAMENTO_TO","type":"date"},{"av":"AV63TFBoletosDataBaixa","fld":"vTFBOLETOSDATABAIXA","type":"date"},{"av":"AV64TFBoletosDataBaixa_To","fld":"vTFBOLETOSDATABAIXA_TO","type":"date"},{"av":"AV68TFBoletosValorNominal","fld":"vTFBOLETOSVALORNOMINAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV69TFBoletosValorNominal_To","fld":"vTFBOLETOSVALORNOMINAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV70TFBoletosValorPago","fld":"vTFBOLETOSVALORPAGO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV71TFBoletosValorPago_To","fld":"vTFBOLETOSVALORPAGO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV72TFBoletosValorDesconto","fld":"vTFBOLETOSVALORDESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV73TFBoletosValorDesconto_To","fld":"vTFBOLETOSVALORDESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV74TFBoletosValorJuros","fld":"vTFBOLETOSVALORJUROS","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV75TFBoletosValorJuros_To","fld":"vTFBOLETOSVALORJUROS_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV76TFBoletosValorMulta","fld":"vTFBOLETOSVALORMULTA","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV77TFBoletosValorMulta_To","fld":"vTFBOLETOSVALORMULTA_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFBoletosSacadoNome","fld":"vTFBOLETOSSACADONOME","type":"svchar"},{"av":"AV79TFBoletosSacadoNome_Sel","fld":"vTFBOLETOSSACADONOME_SEL","type":"svchar"},{"av":"AV80TFBoletosSacadoDocumento","fld":"vTFBOLETOSSACADODOCUMENTO","type":"svchar"},{"av":"AV81TFBoletosSacadoDocumento_Sel","fld":"vTFBOLETOSSACADODOCUMENTO_SEL","type":"svchar"},{"av":"AV83TFBoletosSacadoTipoDocumento_Sels","fld":"vTFBOLETOSSACADOTIPODOCUMENTO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E14A82","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18BoletosNossoNumero1","fld":"vBOLETOSNOSSONUMERO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22BoletosNossoNumero2","fld":"vBOLETOSNOSSONUMERO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26BoletosNossoNumero3","fld":"vBOLETOSNOSSONUMERO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV92Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV91CarteiraDeCobrancaId","fld":"vCARTEIRADECOBRANCAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFBoletosNossoNumero","fld":"vTFBOLETOSNOSSONUMERO","type":"svchar"},{"av":"AV36TFBoletosNossoNumero_Sel","fld":"vTFBOLETOSNOSSONUMERO_SEL","type":"svchar"},{"av":"AV37TFBoletosSeuNumero","fld":"vTFBOLETOSSEUNUMERO","type":"svchar"},{"av":"AV38TFBoletosSeuNumero_Sel","fld":"vTFBOLETOSSEUNUMERO_SEL","type":"svchar"},{"av":"AV39TFBoletosNumero","fld":"vTFBOLETOSNUMERO","type":"svchar"},{"av":"AV40TFBoletosNumero_Sel","fld":"vTFBOLETOSNUMERO_SEL","type":"svchar"},{"av":"AV42TFBoletosStatus_Sels","fld":"vTFBOLETOSSTATUS_SELS","type":""},{"av":"AV43TFBoletosDataEmissao","fld":"vTFBOLETOSDATAEMISSAO","type":"date"},{"av":"AV44TFBoletosDataEmissao_To","fld":"vTFBOLETOSDATAEMISSAO_TO","type":"date"},{"av":"AV48TFBoletosDataVencimento","fld":"vTFBOLETOSDATAVENCIMENTO","type":"date"},{"av":"AV49TFBoletosDataVencimento_To","fld":"vTFBOLETOSDATAVENCIMENTO_TO","type":"date"},{"av":"AV53TFBoletosDataRegistro","fld":"vTFBOLETOSDATAREGISTRO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV54TFBoletosDataRegistro_To","fld":"vTFBOLETOSDATAREGISTRO_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV58TFBoletosDataPagamento","fld":"vTFBOLETOSDATAPAGAMENTO","type":"date"},{"av":"AV59TFBoletosDataPagamento_To","fld":"vTFBOLETOSDATAPAGAMENTO_TO","type":"date"},{"av":"AV63TFBoletosDataBaixa","fld":"vTFBOLETOSDATABAIXA","type":"date"},{"av":"AV64TFBoletosDataBaixa_To","fld":"vTFBOLETOSDATABAIXA_TO","type":"date"},{"av":"AV68TFBoletosValorNominal","fld":"vTFBOLETOSVALORNOMINAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV69TFBoletosValorNominal_To","fld":"vTFBOLETOSVALORNOMINAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV70TFBoletosValorPago","fld":"vTFBOLETOSVALORPAGO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV71TFBoletosValorPago_To","fld":"vTFBOLETOSVALORPAGO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV72TFBoletosValorDesconto","fld":"vTFBOLETOSVALORDESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV73TFBoletosValorDesconto_To","fld":"vTFBOLETOSVALORDESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV74TFBoletosValorJuros","fld":"vTFBOLETOSVALORJUROS","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV75TFBoletosValorJuros_To","fld":"vTFBOLETOSVALORJUROS_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV76TFBoletosValorMulta","fld":"vTFBOLETOSVALORMULTA","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV77TFBoletosValorMulta_To","fld":"vTFBOLETOSVALORMULTA_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFBoletosSacadoNome","fld":"vTFBOLETOSSACADONOME","type":"svchar"},{"av":"AV79TFBoletosSacadoNome_Sel","fld":"vTFBOLETOSSACADONOME_SEL","type":"svchar"},{"av":"AV80TFBoletosSacadoDocumento","fld":"vTFBOLETOSSACADODOCUMENTO","type":"svchar"},{"av":"AV81TFBoletosSacadoDocumento_Sel","fld":"vTFBOLETOSSACADODOCUMENTO_SEL","type":"svchar"},{"av":"AV83TFBoletosSacadoTipoDocumento_Sels","fld":"vTFBOLETOSSACADOTIPODOCUMENTO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV82TFBoletosSacadoTipoDocumento_SelsJson","fld":"vTFBOLETOSSACADOTIPODOCUMENTO_SELSJSON","type":"vchar"},{"av":"AV83TFBoletosSacadoTipoDocumento_Sels","fld":"vTFBOLETOSSACADOTIPODOCUMENTO_SELS","type":""},{"av":"AV80TFBoletosSacadoDocumento","fld":"vTFBOLETOSSACADODOCUMENTO","type":"svchar"},{"av":"AV81TFBoletosSacadoDocumento_Sel","fld":"vTFBOLETOSSACADODOCUMENTO_SEL","type":"svchar"},{"av":"AV78TFBoletosSacadoNome","fld":"vTFBOLETOSSACADONOME","type":"svchar"},{"av":"AV79TFBoletosSacadoNome_Sel","fld":"vTFBOLETOSSACADONOME_SEL","type":"svchar"},{"av":"AV76TFBoletosValorMulta","fld":"vTFBOLETOSVALORMULTA","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV77TFBoletosValorMulta_To","fld":"vTFBOLETOSVALORMULTA_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV74TFBoletosValorJuros","fld":"vTFBOLETOSVALORJUROS","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV75TFBoletosValorJuros_To","fld":"vTFBOLETOSVALORJUROS_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV72TFBoletosValorDesconto","fld":"vTFBOLETOSVALORDESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV73TFBoletosValorDesconto_To","fld":"vTFBOLETOSVALORDESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV70TFBoletosValorPago","fld":"vTFBOLETOSVALORPAGO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV71TFBoletosValorPago_To","fld":"vTFBOLETOSVALORPAGO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV68TFBoletosValorNominal","fld":"vTFBOLETOSVALORNOMINAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV69TFBoletosValorNominal_To","fld":"vTFBOLETOSVALORNOMINAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV63TFBoletosDataBaixa","fld":"vTFBOLETOSDATABAIXA","type":"date"},{"av":"AV64TFBoletosDataBaixa_To","fld":"vTFBOLETOSDATABAIXA_TO","type":"date"},{"av":"AV58TFBoletosDataPagamento","fld":"vTFBOLETOSDATAPAGAMENTO","type":"date"},{"av":"AV59TFBoletosDataPagamento_To","fld":"vTFBOLETOSDATAPAGAMENTO_TO","type":"date"},{"av":"AV53TFBoletosDataRegistro","fld":"vTFBOLETOSDATAREGISTRO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV54TFBoletosDataRegistro_To","fld":"vTFBOLETOSDATAREGISTRO_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV48TFBoletosDataVencimento","fld":"vTFBOLETOSDATAVENCIMENTO","type":"date"},{"av":"AV49TFBoletosDataVencimento_To","fld":"vTFBOLETOSDATAVENCIMENTO_TO","type":"date"},{"av":"AV43TFBoletosDataEmissao","fld":"vTFBOLETOSDATAEMISSAO","type":"date"},{"av":"AV44TFBoletosDataEmissao_To","fld":"vTFBOLETOSDATAEMISSAO_TO","type":"date"},{"av":"AV41TFBoletosStatus_SelsJson","fld":"vTFBOLETOSSTATUS_SELSJSON","type":"vchar"},{"av":"AV42TFBoletosStatus_Sels","fld":"vTFBOLETOSSTATUS_SELS","type":""},{"av":"AV39TFBoletosNumero","fld":"vTFBOLETOSNUMERO","type":"svchar"},{"av":"AV40TFBoletosNumero_Sel","fld":"vTFBOLETOSNUMERO_SEL","type":"svchar"},{"av":"AV37TFBoletosSeuNumero","fld":"vTFBOLETOSSEUNUMERO","type":"svchar"},{"av":"AV38TFBoletosSeuNumero_Sel","fld":"vTFBOLETOSSEUNUMERO_SEL","type":"svchar"},{"av":"AV35TFBoletosNossoNumero","fld":"vTFBOLETOSNOSSONUMERO","type":"svchar"},{"av":"AV36TFBoletosNossoNumero_Sel","fld":"vTFBOLETOSNOSSONUMERO_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E27A82","iparms":[{"av":"A1077BoletosId","fld":"BOLETOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV89GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9","type":"int"},{"av":"edtBoletosNossoNumero_Link","ctrl":"BOLETOSNOSSONUMERO","prop":"Link"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E20A82","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E15A82","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18BoletosNossoNumero1","fld":"vBOLETOSNOSSONUMERO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22BoletosNossoNumero2","fld":"vBOLETOSNOSSONUMERO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26BoletosNossoNumero3","fld":"vBOLETOSNOSSONUMERO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV92Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV91CarteiraDeCobrancaId","fld":"vCARTEIRADECOBRANCAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFBoletosNossoNumero","fld":"vTFBOLETOSNOSSONUMERO","type":"svchar"},{"av":"AV36TFBoletosNossoNumero_Sel","fld":"vTFBOLETOSNOSSONUMERO_SEL","type":"svchar"},{"av":"AV37TFBoletosSeuNumero","fld":"vTFBOLETOSSEUNUMERO","type":"svchar"},{"av":"AV38TFBoletosSeuNumero_Sel","fld":"vTFBOLETOSSEUNUMERO_SEL","type":"svchar"},{"av":"AV39TFBoletosNumero","fld":"vTFBOLETOSNUMERO","type":"svchar"},{"av":"AV40TFBoletosNumero_Sel","fld":"vTFBOLETOSNUMERO_SEL","type":"svchar"},{"av":"AV42TFBoletosStatus_Sels","fld":"vTFBOLETOSSTATUS_SELS","type":""},{"av":"AV43TFBoletosDataEmissao","fld":"vTFBOLETOSDATAEMISSAO","type":"date"},{"av":"AV44TFBoletosDataEmissao_To","fld":"vTFBOLETOSDATAEMISSAO_TO","type":"date"},{"av":"AV48TFBoletosDataVencimento","fld":"vTFBOLETOSDATAVENCIMENTO","type":"date"},{"av":"AV49TFBoletosDataVencimento_To","fld":"vTFBOLETOSDATAVENCIMENTO_TO","type":"date"},{"av":"AV53TFBoletosDataRegistro","fld":"vTFBOLETOSDATAREGISTRO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV54TFBoletosDataRegistro_To","fld":"vTFBOLETOSDATAREGISTRO_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV58TFBoletosDataPagamento","fld":"vTFBOLETOSDATAPAGAMENTO","type":"date"},{"av":"AV59TFBoletosDataPagamento_To","fld":"vTFBOLETOSDATAPAGAMENTO_TO","type":"date"},{"av":"AV63TFBoletosDataBaixa","fld":"vTFBOLETOSDATABAIXA","type":"date"},{"av":"AV64TFBoletosDataBaixa_To","fld":"vTFBOLETOSDATABAIXA_TO","type":"date"},{"av":"AV68TFBoletosValorNominal","fld":"vTFBOLETOSVALORNOMINAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV69TFBoletosValorNominal_To","fld":"vTFBOLETOSVALORNOMINAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV70TFBoletosValorPago","fld":"vTFBOLETOSVALORPAGO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV71TFBoletosValorPago_To","fld":"vTFBOLETOSVALORPAGO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV72TFBoletosValorDesconto","fld":"vTFBOLETOSVALORDESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV73TFBoletosValorDesconto_To","fld":"vTFBOLETOSVALORDESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV74TFBoletosValorJuros","fld":"vTFBOLETOSVALORJUROS","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV75TFBoletosValorJuros_To","fld":"vTFBOLETOSVALORJUROS_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV76TFBoletosValorMulta","fld":"vTFBOLETOSVALORMULTA","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV77TFBoletosValorMulta_To","fld":"vTFBOLETOSVALORMULTA_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFBoletosSacadoNome","fld":"vTFBOLETOSSACADONOME","type":"svchar"},{"av":"AV79TFBoletosSacadoNome_Sel","fld":"vTFBOLETOSSACADONOME_SEL","type":"svchar"},{"av":"AV80TFBoletosSacadoDocumento","fld":"vTFBOLETOSSACADODOCUMENTO","type":"svchar"},{"av":"AV81TFBoletosSacadoDocumento_Sel","fld":"vTFBOLETOSSACADODOCUMENTO_SEL","type":"svchar"},{"av":"AV83TFBoletosSacadoTipoDocumento_Sels","fld":"vTFBOLETOSSACADOTIPODOCUMENTO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22BoletosNossoNumero2","fld":"vBOLETOSNOSSONUMERO2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26BoletosNossoNumero3","fld":"vBOLETOSNOSSONUMERO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18BoletosNossoNumero1","fld":"vBOLETOSNOSSONUMERO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavBoletosnossonumero2_Visible","ctrl":"vBOLETOSNOSSONUMERO2","prop":"Visible"},{"av":"edtavBoletosnossonumero3_Visible","ctrl":"vBOLETOSNOSSONUMERO3","prop":"Visible"},{"av":"edtavBoletosnossonumero1_Visible","ctrl":"vBOLETOSNOSSONUMERO1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV86GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV87GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV88GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E21A82","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"edtavBoletosnossonumero1_Visible","ctrl":"vBOLETOSNOSSONUMERO1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E22A82","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E16A82","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18BoletosNossoNumero1","fld":"vBOLETOSNOSSONUMERO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22BoletosNossoNumero2","fld":"vBOLETOSNOSSONUMERO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26BoletosNossoNumero3","fld":"vBOLETOSNOSSONUMERO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV92Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV91CarteiraDeCobrancaId","fld":"vCARTEIRADECOBRANCAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFBoletosNossoNumero","fld":"vTFBOLETOSNOSSONUMERO","type":"svchar"},{"av":"AV36TFBoletosNossoNumero_Sel","fld":"vTFBOLETOSNOSSONUMERO_SEL","type":"svchar"},{"av":"AV37TFBoletosSeuNumero","fld":"vTFBOLETOSSEUNUMERO","type":"svchar"},{"av":"AV38TFBoletosSeuNumero_Sel","fld":"vTFBOLETOSSEUNUMERO_SEL","type":"svchar"},{"av":"AV39TFBoletosNumero","fld":"vTFBOLETOSNUMERO","type":"svchar"},{"av":"AV40TFBoletosNumero_Sel","fld":"vTFBOLETOSNUMERO_SEL","type":"svchar"},{"av":"AV42TFBoletosStatus_Sels","fld":"vTFBOLETOSSTATUS_SELS","type":""},{"av":"AV43TFBoletosDataEmissao","fld":"vTFBOLETOSDATAEMISSAO","type":"date"},{"av":"AV44TFBoletosDataEmissao_To","fld":"vTFBOLETOSDATAEMISSAO_TO","type":"date"},{"av":"AV48TFBoletosDataVencimento","fld":"vTFBOLETOSDATAVENCIMENTO","type":"date"},{"av":"AV49TFBoletosDataVencimento_To","fld":"vTFBOLETOSDATAVENCIMENTO_TO","type":"date"},{"av":"AV53TFBoletosDataRegistro","fld":"vTFBOLETOSDATAREGISTRO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV54TFBoletosDataRegistro_To","fld":"vTFBOLETOSDATAREGISTRO_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV58TFBoletosDataPagamento","fld":"vTFBOLETOSDATAPAGAMENTO","type":"date"},{"av":"AV59TFBoletosDataPagamento_To","fld":"vTFBOLETOSDATAPAGAMENTO_TO","type":"date"},{"av":"AV63TFBoletosDataBaixa","fld":"vTFBOLETOSDATABAIXA","type":"date"},{"av":"AV64TFBoletosDataBaixa_To","fld":"vTFBOLETOSDATABAIXA_TO","type":"date"},{"av":"AV68TFBoletosValorNominal","fld":"vTFBOLETOSVALORNOMINAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV69TFBoletosValorNominal_To","fld":"vTFBOLETOSVALORNOMINAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV70TFBoletosValorPago","fld":"vTFBOLETOSVALORPAGO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV71TFBoletosValorPago_To","fld":"vTFBOLETOSVALORPAGO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV72TFBoletosValorDesconto","fld":"vTFBOLETOSVALORDESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV73TFBoletosValorDesconto_To","fld":"vTFBOLETOSVALORDESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV74TFBoletosValorJuros","fld":"vTFBOLETOSVALORJUROS","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV75TFBoletosValorJuros_To","fld":"vTFBOLETOSVALORJUROS_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV76TFBoletosValorMulta","fld":"vTFBOLETOSVALORMULTA","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV77TFBoletosValorMulta_To","fld":"vTFBOLETOSVALORMULTA_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFBoletosSacadoNome","fld":"vTFBOLETOSSACADONOME","type":"svchar"},{"av":"AV79TFBoletosSacadoNome_Sel","fld":"vTFBOLETOSSACADONOME_SEL","type":"svchar"},{"av":"AV80TFBoletosSacadoDocumento","fld":"vTFBOLETOSSACADODOCUMENTO","type":"svchar"},{"av":"AV81TFBoletosSacadoDocumento_Sel","fld":"vTFBOLETOSSACADODOCUMENTO_SEL","type":"svchar"},{"av":"AV83TFBoletosSacadoTipoDocumento_Sels","fld":"vTFBOLETOSSACADOTIPODOCUMENTO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22BoletosNossoNumero2","fld":"vBOLETOSNOSSONUMERO2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26BoletosNossoNumero3","fld":"vBOLETOSNOSSONUMERO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18BoletosNossoNumero1","fld":"vBOLETOSNOSSONUMERO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavBoletosnossonumero2_Visible","ctrl":"vBOLETOSNOSSONUMERO2","prop":"Visible"},{"av":"edtavBoletosnossonumero3_Visible","ctrl":"vBOLETOSNOSSONUMERO3","prop":"Visible"},{"av":"edtavBoletosnossonumero1_Visible","ctrl":"vBOLETOSNOSSONUMERO1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV86GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV87GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV88GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E23A82","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"edtavBoletosnossonumero2_Visible","ctrl":"vBOLETOSNOSSONUMERO2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E17A82","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18BoletosNossoNumero1","fld":"vBOLETOSNOSSONUMERO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22BoletosNossoNumero2","fld":"vBOLETOSNOSSONUMERO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26BoletosNossoNumero3","fld":"vBOLETOSNOSSONUMERO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV92Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV91CarteiraDeCobrancaId","fld":"vCARTEIRADECOBRANCAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFBoletosNossoNumero","fld":"vTFBOLETOSNOSSONUMERO","type":"svchar"},{"av":"AV36TFBoletosNossoNumero_Sel","fld":"vTFBOLETOSNOSSONUMERO_SEL","type":"svchar"},{"av":"AV37TFBoletosSeuNumero","fld":"vTFBOLETOSSEUNUMERO","type":"svchar"},{"av":"AV38TFBoletosSeuNumero_Sel","fld":"vTFBOLETOSSEUNUMERO_SEL","type":"svchar"},{"av":"AV39TFBoletosNumero","fld":"vTFBOLETOSNUMERO","type":"svchar"},{"av":"AV40TFBoletosNumero_Sel","fld":"vTFBOLETOSNUMERO_SEL","type":"svchar"},{"av":"AV42TFBoletosStatus_Sels","fld":"vTFBOLETOSSTATUS_SELS","type":""},{"av":"AV43TFBoletosDataEmissao","fld":"vTFBOLETOSDATAEMISSAO","type":"date"},{"av":"AV44TFBoletosDataEmissao_To","fld":"vTFBOLETOSDATAEMISSAO_TO","type":"date"},{"av":"AV48TFBoletosDataVencimento","fld":"vTFBOLETOSDATAVENCIMENTO","type":"date"},{"av":"AV49TFBoletosDataVencimento_To","fld":"vTFBOLETOSDATAVENCIMENTO_TO","type":"date"},{"av":"AV53TFBoletosDataRegistro","fld":"vTFBOLETOSDATAREGISTRO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV54TFBoletosDataRegistro_To","fld":"vTFBOLETOSDATAREGISTRO_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV58TFBoletosDataPagamento","fld":"vTFBOLETOSDATAPAGAMENTO","type":"date"},{"av":"AV59TFBoletosDataPagamento_To","fld":"vTFBOLETOSDATAPAGAMENTO_TO","type":"date"},{"av":"AV63TFBoletosDataBaixa","fld":"vTFBOLETOSDATABAIXA","type":"date"},{"av":"AV64TFBoletosDataBaixa_To","fld":"vTFBOLETOSDATABAIXA_TO","type":"date"},{"av":"AV68TFBoletosValorNominal","fld":"vTFBOLETOSVALORNOMINAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV69TFBoletosValorNominal_To","fld":"vTFBOLETOSVALORNOMINAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV70TFBoletosValorPago","fld":"vTFBOLETOSVALORPAGO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV71TFBoletosValorPago_To","fld":"vTFBOLETOSVALORPAGO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV72TFBoletosValorDesconto","fld":"vTFBOLETOSVALORDESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV73TFBoletosValorDesconto_To","fld":"vTFBOLETOSVALORDESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV74TFBoletosValorJuros","fld":"vTFBOLETOSVALORJUROS","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV75TFBoletosValorJuros_To","fld":"vTFBOLETOSVALORJUROS_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV76TFBoletosValorMulta","fld":"vTFBOLETOSVALORMULTA","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV77TFBoletosValorMulta_To","fld":"vTFBOLETOSVALORMULTA_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFBoletosSacadoNome","fld":"vTFBOLETOSSACADONOME","type":"svchar"},{"av":"AV79TFBoletosSacadoNome_Sel","fld":"vTFBOLETOSSACADONOME_SEL","type":"svchar"},{"av":"AV80TFBoletosSacadoDocumento","fld":"vTFBOLETOSSACADODOCUMENTO","type":"svchar"},{"av":"AV81TFBoletosSacadoDocumento_Sel","fld":"vTFBOLETOSSACADODOCUMENTO_SEL","type":"svchar"},{"av":"AV83TFBoletosSacadoTipoDocumento_Sels","fld":"vTFBOLETOSSACADOTIPODOCUMENTO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22BoletosNossoNumero2","fld":"vBOLETOSNOSSONUMERO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26BoletosNossoNumero3","fld":"vBOLETOSNOSSONUMERO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18BoletosNossoNumero1","fld":"vBOLETOSNOSSONUMERO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavBoletosnossonumero2_Visible","ctrl":"vBOLETOSNOSSONUMERO2","prop":"Visible"},{"av":"edtavBoletosnossonumero3_Visible","ctrl":"vBOLETOSNOSSONUMERO3","prop":"Visible"},{"av":"edtavBoletosnossonumero1_Visible","ctrl":"vBOLETOSNOSSONUMERO1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV86GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV87GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV88GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E24A82","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"edtavBoletosnossonumero3_Visible","ctrl":"vBOLETOSNOSSONUMERO3","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator3"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11A82","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18BoletosNossoNumero1","fld":"vBOLETOSNOSSONUMERO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22BoletosNossoNumero2","fld":"vBOLETOSNOSSONUMERO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26BoletosNossoNumero3","fld":"vBOLETOSNOSSONUMERO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV92Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV91CarteiraDeCobrancaId","fld":"vCARTEIRADECOBRANCAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFBoletosNossoNumero","fld":"vTFBOLETOSNOSSONUMERO","type":"svchar"},{"av":"AV36TFBoletosNossoNumero_Sel","fld":"vTFBOLETOSNOSSONUMERO_SEL","type":"svchar"},{"av":"AV37TFBoletosSeuNumero","fld":"vTFBOLETOSSEUNUMERO","type":"svchar"},{"av":"AV38TFBoletosSeuNumero_Sel","fld":"vTFBOLETOSSEUNUMERO_SEL","type":"svchar"},{"av":"AV39TFBoletosNumero","fld":"vTFBOLETOSNUMERO","type":"svchar"},{"av":"AV40TFBoletosNumero_Sel","fld":"vTFBOLETOSNUMERO_SEL","type":"svchar"},{"av":"AV42TFBoletosStatus_Sels","fld":"vTFBOLETOSSTATUS_SELS","type":""},{"av":"AV43TFBoletosDataEmissao","fld":"vTFBOLETOSDATAEMISSAO","type":"date"},{"av":"AV44TFBoletosDataEmissao_To","fld":"vTFBOLETOSDATAEMISSAO_TO","type":"date"},{"av":"AV48TFBoletosDataVencimento","fld":"vTFBOLETOSDATAVENCIMENTO","type":"date"},{"av":"AV49TFBoletosDataVencimento_To","fld":"vTFBOLETOSDATAVENCIMENTO_TO","type":"date"},{"av":"AV53TFBoletosDataRegistro","fld":"vTFBOLETOSDATAREGISTRO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV54TFBoletosDataRegistro_To","fld":"vTFBOLETOSDATAREGISTRO_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV58TFBoletosDataPagamento","fld":"vTFBOLETOSDATAPAGAMENTO","type":"date"},{"av":"AV59TFBoletosDataPagamento_To","fld":"vTFBOLETOSDATAPAGAMENTO_TO","type":"date"},{"av":"AV63TFBoletosDataBaixa","fld":"vTFBOLETOSDATABAIXA","type":"date"},{"av":"AV64TFBoletosDataBaixa_To","fld":"vTFBOLETOSDATABAIXA_TO","type":"date"},{"av":"AV68TFBoletosValorNominal","fld":"vTFBOLETOSVALORNOMINAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV69TFBoletosValorNominal_To","fld":"vTFBOLETOSVALORNOMINAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV70TFBoletosValorPago","fld":"vTFBOLETOSVALORPAGO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV71TFBoletosValorPago_To","fld":"vTFBOLETOSVALORPAGO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV72TFBoletosValorDesconto","fld":"vTFBOLETOSVALORDESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV73TFBoletosValorDesconto_To","fld":"vTFBOLETOSVALORDESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV74TFBoletosValorJuros","fld":"vTFBOLETOSVALORJUROS","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV75TFBoletosValorJuros_To","fld":"vTFBOLETOSVALORJUROS_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV76TFBoletosValorMulta","fld":"vTFBOLETOSVALORMULTA","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV77TFBoletosValorMulta_To","fld":"vTFBOLETOSVALORMULTA_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFBoletosSacadoNome","fld":"vTFBOLETOSSACADONOME","type":"svchar"},{"av":"AV79TFBoletosSacadoNome_Sel","fld":"vTFBOLETOSSACADONOME_SEL","type":"svchar"},{"av":"AV80TFBoletosSacadoDocumento","fld":"vTFBOLETOSSACADODOCUMENTO","type":"svchar"},{"av":"AV81TFBoletosSacadoDocumento_Sel","fld":"vTFBOLETOSSACADODOCUMENTO_SEL","type":"svchar"},{"av":"AV83TFBoletosSacadoTipoDocumento_Sels","fld":"vTFBOLETOSSACADOTIPODOCUMENTO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV41TFBoletosStatus_SelsJson","fld":"vTFBOLETOSSTATUS_SELSJSON","type":"vchar"},{"av":"AV82TFBoletosSacadoTipoDocumento_SelsJson","fld":"vTFBOLETOSSACADOTIPODOCUMENTO_SELSJSON","type":"vchar"},{"av":"AV55DDO_BoletosDataRegistroAuxDate","fld":"vDDO_BOLETOSDATAREGISTROAUXDATE","type":"date"},{"av":"AV56DDO_BoletosDataRegistroAuxDateTo","fld":"vDDO_BOLETOSDATAREGISTROAUXDATETO","type":"date"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV35TFBoletosNossoNumero","fld":"vTFBOLETOSNOSSONUMERO","type":"svchar"},{"av":"AV36TFBoletosNossoNumero_Sel","fld":"vTFBOLETOSNOSSONUMERO_SEL","type":"svchar"},{"av":"AV37TFBoletosSeuNumero","fld":"vTFBOLETOSSEUNUMERO","type":"svchar"},{"av":"AV38TFBoletosSeuNumero_Sel","fld":"vTFBOLETOSSEUNUMERO_SEL","type":"svchar"},{"av":"AV39TFBoletosNumero","fld":"vTFBOLETOSNUMERO","type":"svchar"},{"av":"AV40TFBoletosNumero_Sel","fld":"vTFBOLETOSNUMERO_SEL","type":"svchar"},{"av":"AV42TFBoletosStatus_Sels","fld":"vTFBOLETOSSTATUS_SELS","type":""},{"av":"AV43TFBoletosDataEmissao","fld":"vTFBOLETOSDATAEMISSAO","type":"date"},{"av":"AV44TFBoletosDataEmissao_To","fld":"vTFBOLETOSDATAEMISSAO_TO","type":"date"},{"av":"AV48TFBoletosDataVencimento","fld":"vTFBOLETOSDATAVENCIMENTO","type":"date"},{"av":"AV49TFBoletosDataVencimento_To","fld":"vTFBOLETOSDATAVENCIMENTO_TO","type":"date"},{"av":"AV53TFBoletosDataRegistro","fld":"vTFBOLETOSDATAREGISTRO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV54TFBoletosDataRegistro_To","fld":"vTFBOLETOSDATAREGISTRO_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV58TFBoletosDataPagamento","fld":"vTFBOLETOSDATAPAGAMENTO","type":"date"},{"av":"AV59TFBoletosDataPagamento_To","fld":"vTFBOLETOSDATAPAGAMENTO_TO","type":"date"},{"av":"AV63TFBoletosDataBaixa","fld":"vTFBOLETOSDATABAIXA","type":"date"},{"av":"AV64TFBoletosDataBaixa_To","fld":"vTFBOLETOSDATABAIXA_TO","type":"date"},{"av":"AV68TFBoletosValorNominal","fld":"vTFBOLETOSVALORNOMINAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV69TFBoletosValorNominal_To","fld":"vTFBOLETOSVALORNOMINAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV70TFBoletosValorPago","fld":"vTFBOLETOSVALORPAGO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV71TFBoletosValorPago_To","fld":"vTFBOLETOSVALORPAGO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV72TFBoletosValorDesconto","fld":"vTFBOLETOSVALORDESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV73TFBoletosValorDesconto_To","fld":"vTFBOLETOSVALORDESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV74TFBoletosValorJuros","fld":"vTFBOLETOSVALORJUROS","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV75TFBoletosValorJuros_To","fld":"vTFBOLETOSVALORJUROS_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV76TFBoletosValorMulta","fld":"vTFBOLETOSVALORMULTA","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV77TFBoletosValorMulta_To","fld":"vTFBOLETOSVALORMULTA_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFBoletosSacadoNome","fld":"vTFBOLETOSSACADONOME","type":"svchar"},{"av":"AV79TFBoletosSacadoNome_Sel","fld":"vTFBOLETOSSACADONOME_SEL","type":"svchar"},{"av":"AV80TFBoletosSacadoDocumento","fld":"vTFBOLETOSSACADODOCUMENTO","type":"svchar"},{"av":"AV81TFBoletosSacadoDocumento_Sel","fld":"vTFBOLETOSSACADODOCUMENTO_SEL","type":"svchar"},{"av":"AV83TFBoletosSacadoTipoDocumento_Sels","fld":"vTFBOLETOSSACADOTIPODOCUMENTO_SELS","type":""},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18BoletosNossoNumero1","fld":"vBOLETOSNOSSONUMERO1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV82TFBoletosSacadoTipoDocumento_SelsJson","fld":"vTFBOLETOSSACADOTIPODOCUMENTO_SELSJSON","type":"vchar"},{"av":"AV55DDO_BoletosDataRegistroAuxDate","fld":"vDDO_BOLETOSDATAREGISTROAUXDATE","type":"date"},{"av":"AV56DDO_BoletosDataRegistroAuxDateTo","fld":"vDDO_BOLETOSDATAREGISTROAUXDATETO","type":"date"},{"av":"AV41TFBoletosStatus_SelsJson","fld":"vTFBOLETOSSTATUS_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22BoletosNossoNumero2","fld":"vBOLETOSNOSSONUMERO2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26BoletosNossoNumero3","fld":"vBOLETOSNOSSONUMERO3","type":"svchar"},{"av":"edtavBoletosnossonumero1_Visible","ctrl":"vBOLETOSNOSSONUMERO1","prop":"Visible"},{"av":"edtavBoletosnossonumero2_Visible","ctrl":"vBOLETOSNOSSONUMERO2","prop":"Visible"},{"av":"edtavBoletosnossonumero3_Visible","ctrl":"vBOLETOSNOSSONUMERO3","prop":"Visible"},{"av":"AV86GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV87GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV88GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK","""{"handler":"E28A82","iparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV89GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9","type":"int"},{"av":"A1077BoletosId","fld":"BOLETOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV89GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9","type":"int"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E18A82","iparms":[{"av":"A1077BoletosId","fld":"BOLETOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E19A82","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Boletossacadotipodocumento","iparms":[]}""");
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
         AV15FilterFullText = "";
         AV16DynamicFiltersSelector1 = "";
         AV18BoletosNossoNumero1 = "";
         AV20DynamicFiltersSelector2 = "";
         AV22BoletosNossoNumero2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26BoletosNossoNumero3 = "";
         AV92Pgmname = "";
         AV35TFBoletosNossoNumero = "";
         AV36TFBoletosNossoNumero_Sel = "";
         AV37TFBoletosSeuNumero = "";
         AV38TFBoletosSeuNumero_Sel = "";
         AV39TFBoletosNumero = "";
         AV40TFBoletosNumero_Sel = "";
         AV42TFBoletosStatus_Sels = new GxSimpleCollection<string>();
         AV43TFBoletosDataEmissao = DateTime.MinValue;
         AV44TFBoletosDataEmissao_To = DateTime.MinValue;
         AV48TFBoletosDataVencimento = DateTime.MinValue;
         AV49TFBoletosDataVencimento_To = DateTime.MinValue;
         AV53TFBoletosDataRegistro = (DateTime)(DateTime.MinValue);
         AV54TFBoletosDataRegistro_To = (DateTime)(DateTime.MinValue);
         AV58TFBoletosDataPagamento = DateTime.MinValue;
         AV59TFBoletosDataPagamento_To = DateTime.MinValue;
         AV63TFBoletosDataBaixa = DateTime.MinValue;
         AV64TFBoletosDataBaixa_To = DateTime.MinValue;
         AV78TFBoletosSacadoNome = "";
         AV79TFBoletosSacadoNome_Sel = "";
         AV80TFBoletosSacadoDocumento = "";
         AV81TFBoletosSacadoDocumento_Sel = "";
         AV83TFBoletosSacadoTipoDocumento_Sels = new GxSimpleCollection<string>();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV32ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV88GridAppliedFilters = "";
         AV84DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV45DDO_BoletosDataEmissaoAuxDate = DateTime.MinValue;
         AV46DDO_BoletosDataEmissaoAuxDateTo = DateTime.MinValue;
         AV50DDO_BoletosDataVencimentoAuxDate = DateTime.MinValue;
         AV51DDO_BoletosDataVencimentoAuxDateTo = DateTime.MinValue;
         AV55DDO_BoletosDataRegistroAuxDate = DateTime.MinValue;
         AV56DDO_BoletosDataRegistroAuxDateTo = DateTime.MinValue;
         AV60DDO_BoletosDataPagamentoAuxDate = DateTime.MinValue;
         AV61DDO_BoletosDataPagamentoAuxDateTo = DateTime.MinValue;
         AV65DDO_BoletosDataBaixaAuxDate = DateTime.MinValue;
         AV66DDO_BoletosDataBaixaAuxDateTo = DateTime.MinValue;
         AV41TFBoletosStatus_SelsJson = "";
         AV82TFBoletosSacadoTipoDocumento_SelsJson = "";
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
         AV47DDO_BoletosDataEmissaoAuxDateText = "";
         ucTfboletosdataemissao_rangepicker = new GXUserControl();
         AV52DDO_BoletosDataVencimentoAuxDateText = "";
         ucTfboletosdatavencimento_rangepicker = new GXUserControl();
         AV57DDO_BoletosDataRegistroAuxDateText = "";
         ucTfboletosdataregistro_rangepicker = new GXUserControl();
         AV62DDO_BoletosDataPagamentoAuxDateText = "";
         ucTfboletosdatapagamento_rangepicker = new GXUserControl();
         AV67DDO_BoletosDataBaixaAuxDateText = "";
         ucTfboletosdatabaixa_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A1078BoletosNossoNumero = "";
         A1079BoletosSeuNumero = "";
         A1080BoletosNumero = "";
         A1081BoletosLinhaDigitavel = "";
         A1082BoletosCodigoDeBarras = "";
         A1083BoletosStatus = "";
         A1084BoletosDataEmissao = DateTime.MinValue;
         A1085BoletosDataVencimento = DateTime.MinValue;
         A1086BoletosDataRegistro = (DateTime)(DateTime.MinValue);
         A1087BoletosDataPagamento = DateTime.MinValue;
         A1088BoletosDataBaixa = DateTime.MinValue;
         A1094BoletosSacadoNome = "";
         A1095BoletosSacadoDocumento = "";
         A1096BoletosSacadoTipoDocumento = "";
         GXDecQS = "";
         AV112Boletowwds_20_tfboletosstatus_sels = new GxSimpleCollection<string>();
         AV137Boletowwds_45_tfboletossacadotipodocumento_sels = new GxSimpleCollection<string>();
         lV94Boletowwds_2_filterfulltext = "";
         lV97Boletowwds_5_boletosnossonumero1 = "";
         lV101Boletowwds_9_boletosnossonumero2 = "";
         lV105Boletowwds_13_boletosnossonumero3 = "";
         lV106Boletowwds_14_tfboletosnossonumero = "";
         lV108Boletowwds_16_tfboletosseunumero = "";
         lV110Boletowwds_18_tfboletosnumero = "";
         lV133Boletowwds_41_tfboletossacadonome = "";
         lV135Boletowwds_43_tfboletossacadodocumento = "";
         AV94Boletowwds_2_filterfulltext = "";
         AV95Boletowwds_3_dynamicfiltersselector1 = "";
         AV97Boletowwds_5_boletosnossonumero1 = "";
         AV99Boletowwds_7_dynamicfiltersselector2 = "";
         AV101Boletowwds_9_boletosnossonumero2 = "";
         AV103Boletowwds_11_dynamicfiltersselector3 = "";
         AV105Boletowwds_13_boletosnossonumero3 = "";
         AV107Boletowwds_15_tfboletosnossonumero_sel = "";
         AV106Boletowwds_14_tfboletosnossonumero = "";
         AV109Boletowwds_17_tfboletosseunumero_sel = "";
         AV108Boletowwds_16_tfboletosseunumero = "";
         AV111Boletowwds_19_tfboletosnumero_sel = "";
         AV110Boletowwds_18_tfboletosnumero = "";
         AV113Boletowwds_21_tfboletosdataemissao = DateTime.MinValue;
         AV114Boletowwds_22_tfboletosdataemissao_to = DateTime.MinValue;
         AV115Boletowwds_23_tfboletosdatavencimento = DateTime.MinValue;
         AV116Boletowwds_24_tfboletosdatavencimento_to = DateTime.MinValue;
         AV117Boletowwds_25_tfboletosdataregistro = (DateTime)(DateTime.MinValue);
         AV118Boletowwds_26_tfboletosdataregistro_to = (DateTime)(DateTime.MinValue);
         AV119Boletowwds_27_tfboletosdatapagamento = DateTime.MinValue;
         AV120Boletowwds_28_tfboletosdatapagamento_to = DateTime.MinValue;
         AV121Boletowwds_29_tfboletosdatabaixa = DateTime.MinValue;
         AV122Boletowwds_30_tfboletosdatabaixa_to = DateTime.MinValue;
         AV134Boletowwds_42_tfboletossacadonome_sel = "";
         AV133Boletowwds_41_tfboletossacadonome = "";
         AV136Boletowwds_44_tfboletossacadodocumento_sel = "";
         AV135Boletowwds_43_tfboletossacadodocumento = "";
         H00A82_A1096BoletosSacadoTipoDocumento = new string[] {""} ;
         H00A82_n1096BoletosSacadoTipoDocumento = new bool[] {false} ;
         H00A82_A1095BoletosSacadoDocumento = new string[] {""} ;
         H00A82_n1095BoletosSacadoDocumento = new bool[] {false} ;
         H00A82_A1094BoletosSacadoNome = new string[] {""} ;
         H00A82_n1094BoletosSacadoNome = new bool[] {false} ;
         H00A82_A1093BoletosValorMulta = new decimal[1] ;
         H00A82_n1093BoletosValorMulta = new bool[] {false} ;
         H00A82_A1092BoletosValorJuros = new decimal[1] ;
         H00A82_n1092BoletosValorJuros = new bool[] {false} ;
         H00A82_A1091BoletosValorDesconto = new decimal[1] ;
         H00A82_n1091BoletosValorDesconto = new bool[] {false} ;
         H00A82_A1090BoletosValorPago = new decimal[1] ;
         H00A82_n1090BoletosValorPago = new bool[] {false} ;
         H00A82_A1089BoletosValorNominal = new decimal[1] ;
         H00A82_n1089BoletosValorNominal = new bool[] {false} ;
         H00A82_A1088BoletosDataBaixa = new DateTime[] {DateTime.MinValue} ;
         H00A82_n1088BoletosDataBaixa = new bool[] {false} ;
         H00A82_A1087BoletosDataPagamento = new DateTime[] {DateTime.MinValue} ;
         H00A82_n1087BoletosDataPagamento = new bool[] {false} ;
         H00A82_A1086BoletosDataRegistro = new DateTime[] {DateTime.MinValue} ;
         H00A82_n1086BoletosDataRegistro = new bool[] {false} ;
         H00A82_A1085BoletosDataVencimento = new DateTime[] {DateTime.MinValue} ;
         H00A82_n1085BoletosDataVencimento = new bool[] {false} ;
         H00A82_A1084BoletosDataEmissao = new DateTime[] {DateTime.MinValue} ;
         H00A82_n1084BoletosDataEmissao = new bool[] {false} ;
         H00A82_A1083BoletosStatus = new string[] {""} ;
         H00A82_n1083BoletosStatus = new bool[] {false} ;
         H00A82_A1082BoletosCodigoDeBarras = new string[] {""} ;
         H00A82_n1082BoletosCodigoDeBarras = new bool[] {false} ;
         H00A82_A1081BoletosLinhaDigitavel = new string[] {""} ;
         H00A82_n1081BoletosLinhaDigitavel = new bool[] {false} ;
         H00A82_A1080BoletosNumero = new string[] {""} ;
         H00A82_n1080BoletosNumero = new bool[] {false} ;
         H00A82_A1079BoletosSeuNumero = new string[] {""} ;
         H00A82_n1079BoletosSeuNumero = new bool[] {false} ;
         H00A82_A1078BoletosNossoNumero = new string[] {""} ;
         H00A82_n1078BoletosNossoNumero = new bool[] {false} ;
         H00A82_A261TituloId = new int[1] ;
         H00A82_n261TituloId = new bool[] {false} ;
         H00A82_A1069CarteiraDeCobrancaId = new int[1] ;
         H00A82_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         H00A82_A1077BoletosId = new int[1] ;
         H00A83_AGRID_nRecordCount = new long[1] ;
         AV7HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV33ManageFiltersXml = "";
         AV29ExcelFilename = "";
         AV30ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV31Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char4 = "";
         GXt_char9 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV90AuxText = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.boletoww__default(),
            new Object[][] {
                new Object[] {
               H00A82_A1096BoletosSacadoTipoDocumento, H00A82_n1096BoletosSacadoTipoDocumento, H00A82_A1095BoletosSacadoDocumento, H00A82_n1095BoletosSacadoDocumento, H00A82_A1094BoletosSacadoNome, H00A82_n1094BoletosSacadoNome, H00A82_A1093BoletosValorMulta, H00A82_n1093BoletosValorMulta, H00A82_A1092BoletosValorJuros, H00A82_n1092BoletosValorJuros,
               H00A82_A1091BoletosValorDesconto, H00A82_n1091BoletosValorDesconto, H00A82_A1090BoletosValorPago, H00A82_n1090BoletosValorPago, H00A82_A1089BoletosValorNominal, H00A82_n1089BoletosValorNominal, H00A82_A1088BoletosDataBaixa, H00A82_n1088BoletosDataBaixa, H00A82_A1087BoletosDataPagamento, H00A82_n1087BoletosDataPagamento,
               H00A82_A1086BoletosDataRegistro, H00A82_n1086BoletosDataRegistro, H00A82_A1085BoletosDataVencimento, H00A82_n1085BoletosDataVencimento, H00A82_A1084BoletosDataEmissao, H00A82_n1084BoletosDataEmissao, H00A82_A1083BoletosStatus, H00A82_n1083BoletosStatus, H00A82_A1082BoletosCodigoDeBarras, H00A82_n1082BoletosCodigoDeBarras,
               H00A82_A1081BoletosLinhaDigitavel, H00A82_n1081BoletosLinhaDigitavel, H00A82_A1080BoletosNumero, H00A82_n1080BoletosNumero, H00A82_A1079BoletosSeuNumero, H00A82_n1079BoletosSeuNumero, H00A82_A1078BoletosNossoNumero, H00A82_n1078BoletosNossoNumero, H00A82_A261TituloId, H00A82_n261TituloId,
               H00A82_A1069CarteiraDeCobrancaId, H00A82_n1069CarteiraDeCobrancaId, H00A82_A1077BoletosId
               }
               , new Object[] {
               H00A83_AGRID_nRecordCount
               }
            }
         );
         AV92Pgmname = "BoletoWW";
         /* GeneXus formulas. */
         AV92Pgmname = "BoletoWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV34ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV89GridActionGroup1 ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV96Boletowwds_4_dynamicfiltersoperator1 ;
      private short AV100Boletowwds_8_dynamicfiltersoperator2 ;
      private short AV104Boletowwds_12_dynamicfiltersoperator3 ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV91CarteiraDeCobrancaId ;
      private int wcpOAV91CarteiraDeCobrancaId ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_107 ;
      private int nGXsfl_107_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A1077BoletosId ;
      private int A1069CarteiraDeCobrancaId ;
      private int A261TituloId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV112Boletowwds_20_tfboletosstatus_sels_Count ;
      private int AV137Boletowwds_45_tfboletossacadotipodocumento_sels_Count ;
      private int AV93Boletowwds_1_carteiradecobrancaid ;
      private int edtBoletosId_Enabled ;
      private int edtCarteiraDeCobrancaId_Enabled ;
      private int edtTituloId_Enabled ;
      private int edtBoletosNossoNumero_Enabled ;
      private int edtBoletosSeuNumero_Enabled ;
      private int edtBoletosNumero_Enabled ;
      private int edtBoletosLinhaDigitavel_Enabled ;
      private int edtBoletosCodigoDeBarras_Enabled ;
      private int edtBoletosDataEmissao_Enabled ;
      private int edtBoletosDataVencimento_Enabled ;
      private int edtBoletosDataRegistro_Enabled ;
      private int edtBoletosDataPagamento_Enabled ;
      private int edtBoletosDataBaixa_Enabled ;
      private int edtBoletosValorNominal_Enabled ;
      private int edtBoletosValorPago_Enabled ;
      private int edtBoletosValorDesconto_Enabled ;
      private int edtBoletosValorJuros_Enabled ;
      private int edtBoletosValorMulta_Enabled ;
      private int edtBoletosSacadoNome_Enabled ;
      private int edtBoletosSacadoDocumento_Enabled ;
      private int AV85PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavBoletosnossonumero1_Visible ;
      private int edtavBoletosnossonumero2_Visible ;
      private int edtavBoletosnossonumero3_Visible ;
      private int AV138GXV1 ;
      private int edtavBoletosnossonumero3_Enabled ;
      private int edtavBoletosnossonumero2_Enabled ;
      private int edtavBoletosnossonumero1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV86GridCurrentPage ;
      private long AV87GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV68TFBoletosValorNominal ;
      private decimal AV69TFBoletosValorNominal_To ;
      private decimal AV70TFBoletosValorPago ;
      private decimal AV71TFBoletosValorPago_To ;
      private decimal AV72TFBoletosValorDesconto ;
      private decimal AV73TFBoletosValorDesconto_To ;
      private decimal AV74TFBoletosValorJuros ;
      private decimal AV75TFBoletosValorJuros_To ;
      private decimal AV76TFBoletosValorMulta ;
      private decimal AV77TFBoletosValorMulta_To ;
      private decimal A1089BoletosValorNominal ;
      private decimal A1090BoletosValorPago ;
      private decimal A1091BoletosValorDesconto ;
      private decimal A1092BoletosValorJuros ;
      private decimal A1093BoletosValorMulta ;
      private decimal AV123Boletowwds_31_tfboletosvalornominal ;
      private decimal AV124Boletowwds_32_tfboletosvalornominal_to ;
      private decimal AV125Boletowwds_33_tfboletosvalorpago ;
      private decimal AV126Boletowwds_34_tfboletosvalorpago_to ;
      private decimal AV127Boletowwds_35_tfboletosvalordesconto ;
      private decimal AV128Boletowwds_36_tfboletosvalordesconto_to ;
      private decimal AV129Boletowwds_37_tfboletosvalorjuros ;
      private decimal AV130Boletowwds_38_tfboletosvalorjuros_to ;
      private decimal AV131Boletowwds_39_tfboletosvalormulta ;
      private decimal AV132Boletowwds_40_tfboletosvalormulta_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_107_idx="0001" ;
      private string AV92Pgmname ;
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
      private string divDdo_boletosdataemissaoauxdates_Internalname ;
      private string edtavDdo_boletosdataemissaoauxdatetext_Internalname ;
      private string edtavDdo_boletosdataemissaoauxdatetext_Jsonclick ;
      private string Tfboletosdataemissao_rangepicker_Internalname ;
      private string divDdo_boletosdatavencimentoauxdates_Internalname ;
      private string edtavDdo_boletosdatavencimentoauxdatetext_Internalname ;
      private string edtavDdo_boletosdatavencimentoauxdatetext_Jsonclick ;
      private string Tfboletosdatavencimento_rangepicker_Internalname ;
      private string divDdo_boletosdataregistroauxdates_Internalname ;
      private string edtavDdo_boletosdataregistroauxdatetext_Internalname ;
      private string edtavDdo_boletosdataregistroauxdatetext_Jsonclick ;
      private string Tfboletosdataregistro_rangepicker_Internalname ;
      private string divDdo_boletosdatapagamentoauxdates_Internalname ;
      private string edtavDdo_boletosdatapagamentoauxdatetext_Internalname ;
      private string edtavDdo_boletosdatapagamentoauxdatetext_Jsonclick ;
      private string Tfboletosdatapagamento_rangepicker_Internalname ;
      private string divDdo_boletosdatabaixaauxdates_Internalname ;
      private string edtavDdo_boletosdatabaixaauxdatetext_Internalname ;
      private string edtavDdo_boletosdatabaixaauxdatetext_Jsonclick ;
      private string Tfboletosdatabaixa_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactiongroup1_Internalname ;
      private string edtBoletosId_Internalname ;
      private string edtCarteiraDeCobrancaId_Internalname ;
      private string edtTituloId_Internalname ;
      private string edtBoletosNossoNumero_Internalname ;
      private string edtBoletosSeuNumero_Internalname ;
      private string edtBoletosNumero_Internalname ;
      private string edtBoletosLinhaDigitavel_Internalname ;
      private string edtBoletosCodigoDeBarras_Internalname ;
      private string cmbBoletosStatus_Internalname ;
      private string edtBoletosDataEmissao_Internalname ;
      private string edtBoletosDataVencimento_Internalname ;
      private string edtBoletosDataRegistro_Internalname ;
      private string edtBoletosDataPagamento_Internalname ;
      private string edtBoletosDataBaixa_Internalname ;
      private string edtBoletosValorNominal_Internalname ;
      private string edtBoletosValorPago_Internalname ;
      private string edtBoletosValorDesconto_Internalname ;
      private string edtBoletosValorJuros_Internalname ;
      private string edtBoletosValorMulta_Internalname ;
      private string edtBoletosSacadoNome_Internalname ;
      private string edtBoletosSacadoDocumento_Internalname ;
      private string cmbBoletosSacadoTipoDocumento_Internalname ;
      private string GXDecQS ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavBoletosnossonumero1_Internalname ;
      private string edtavBoletosnossonumero2_Internalname ;
      private string edtavBoletosnossonumero3_Internalname ;
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
      private string edtBoletosNossoNumero_Link ;
      private string GXt_char2 ;
      private string GXt_char4 ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_boletosnossonumero3_cell_Internalname ;
      private string edtavBoletosnossonumero3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_boletosnossonumero2_cell_Internalname ;
      private string edtavBoletosnossonumero2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_boletosnossonumero1_cell_Internalname ;
      private string edtavBoletosnossonumero1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_107_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactiongroup1_Jsonclick ;
      private string ROClassString ;
      private string edtBoletosId_Jsonclick ;
      private string edtCarteiraDeCobrancaId_Jsonclick ;
      private string edtTituloId_Jsonclick ;
      private string edtBoletosNossoNumero_Jsonclick ;
      private string edtBoletosSeuNumero_Jsonclick ;
      private string edtBoletosNumero_Jsonclick ;
      private string edtBoletosLinhaDigitavel_Jsonclick ;
      private string edtBoletosCodigoDeBarras_Jsonclick ;
      private string cmbBoletosStatus_Jsonclick ;
      private string edtBoletosDataEmissao_Jsonclick ;
      private string edtBoletosDataVencimento_Jsonclick ;
      private string edtBoletosDataRegistro_Jsonclick ;
      private string edtBoletosDataPagamento_Jsonclick ;
      private string edtBoletosDataBaixa_Jsonclick ;
      private string edtBoletosValorNominal_Jsonclick ;
      private string edtBoletosValorPago_Jsonclick ;
      private string edtBoletosValorDesconto_Jsonclick ;
      private string edtBoletosValorJuros_Jsonclick ;
      private string edtBoletosValorMulta_Jsonclick ;
      private string edtBoletosSacadoNome_Jsonclick ;
      private string edtBoletosSacadoDocumento_Jsonclick ;
      private string cmbBoletosSacadoTipoDocumento_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV53TFBoletosDataRegistro ;
      private DateTime AV54TFBoletosDataRegistro_To ;
      private DateTime A1086BoletosDataRegistro ;
      private DateTime AV117Boletowwds_25_tfboletosdataregistro ;
      private DateTime AV118Boletowwds_26_tfboletosdataregistro_to ;
      private DateTime AV43TFBoletosDataEmissao ;
      private DateTime AV44TFBoletosDataEmissao_To ;
      private DateTime AV48TFBoletosDataVencimento ;
      private DateTime AV49TFBoletosDataVencimento_To ;
      private DateTime AV58TFBoletosDataPagamento ;
      private DateTime AV59TFBoletosDataPagamento_To ;
      private DateTime AV63TFBoletosDataBaixa ;
      private DateTime AV64TFBoletosDataBaixa_To ;
      private DateTime AV45DDO_BoletosDataEmissaoAuxDate ;
      private DateTime AV46DDO_BoletosDataEmissaoAuxDateTo ;
      private DateTime AV50DDO_BoletosDataVencimentoAuxDate ;
      private DateTime AV51DDO_BoletosDataVencimentoAuxDateTo ;
      private DateTime AV55DDO_BoletosDataRegistroAuxDate ;
      private DateTime AV56DDO_BoletosDataRegistroAuxDateTo ;
      private DateTime AV60DDO_BoletosDataPagamentoAuxDate ;
      private DateTime AV61DDO_BoletosDataPagamentoAuxDateTo ;
      private DateTime AV65DDO_BoletosDataBaixaAuxDate ;
      private DateTime AV66DDO_BoletosDataBaixaAuxDateTo ;
      private DateTime A1084BoletosDataEmissao ;
      private DateTime A1085BoletosDataVencimento ;
      private DateTime A1087BoletosDataPagamento ;
      private DateTime A1088BoletosDataBaixa ;
      private DateTime AV113Boletowwds_21_tfboletosdataemissao ;
      private DateTime AV114Boletowwds_22_tfboletosdataemissao_to ;
      private DateTime AV115Boletowwds_23_tfboletosdatavencimento ;
      private DateTime AV116Boletowwds_24_tfboletosdatavencimento_to ;
      private DateTime AV119Boletowwds_27_tfboletosdatapagamento ;
      private DateTime AV120Boletowwds_28_tfboletosdatapagamento_to ;
      private DateTime AV121Boletowwds_29_tfboletosdatabaixa ;
      private DateTime AV122Boletowwds_30_tfboletosdatabaixa_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV28DynamicFiltersIgnoreFirst ;
      private bool AV27DynamicFiltersRemoving ;
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
      private bool n1069CarteiraDeCobrancaId ;
      private bool n261TituloId ;
      private bool n1078BoletosNossoNumero ;
      private bool n1079BoletosSeuNumero ;
      private bool n1080BoletosNumero ;
      private bool n1081BoletosLinhaDigitavel ;
      private bool n1082BoletosCodigoDeBarras ;
      private bool n1083BoletosStatus ;
      private bool n1084BoletosDataEmissao ;
      private bool n1085BoletosDataVencimento ;
      private bool n1086BoletosDataRegistro ;
      private bool n1087BoletosDataPagamento ;
      private bool n1088BoletosDataBaixa ;
      private bool n1089BoletosValorNominal ;
      private bool n1090BoletosValorPago ;
      private bool n1091BoletosValorDesconto ;
      private bool n1092BoletosValorJuros ;
      private bool n1093BoletosValorMulta ;
      private bool n1094BoletosSacadoNome ;
      private bool n1095BoletosSacadoDocumento ;
      private bool n1096BoletosSacadoTipoDocumento ;
      private bool bGXsfl_107_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV98Boletowwds_6_dynamicfiltersenabled2 ;
      private bool AV102Boletowwds_10_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV41TFBoletosStatus_SelsJson ;
      private string AV82TFBoletosSacadoTipoDocumento_SelsJson ;
      private string AV33ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV18BoletosNossoNumero1 ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV22BoletosNossoNumero2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV26BoletosNossoNumero3 ;
      private string AV35TFBoletosNossoNumero ;
      private string AV36TFBoletosNossoNumero_Sel ;
      private string AV37TFBoletosSeuNumero ;
      private string AV38TFBoletosSeuNumero_Sel ;
      private string AV39TFBoletosNumero ;
      private string AV40TFBoletosNumero_Sel ;
      private string AV78TFBoletosSacadoNome ;
      private string AV79TFBoletosSacadoNome_Sel ;
      private string AV80TFBoletosSacadoDocumento ;
      private string AV81TFBoletosSacadoDocumento_Sel ;
      private string AV88GridAppliedFilters ;
      private string AV47DDO_BoletosDataEmissaoAuxDateText ;
      private string AV52DDO_BoletosDataVencimentoAuxDateText ;
      private string AV57DDO_BoletosDataRegistroAuxDateText ;
      private string AV62DDO_BoletosDataPagamentoAuxDateText ;
      private string AV67DDO_BoletosDataBaixaAuxDateText ;
      private string A1078BoletosNossoNumero ;
      private string A1079BoletosSeuNumero ;
      private string A1080BoletosNumero ;
      private string A1081BoletosLinhaDigitavel ;
      private string A1082BoletosCodigoDeBarras ;
      private string A1083BoletosStatus ;
      private string A1094BoletosSacadoNome ;
      private string A1095BoletosSacadoDocumento ;
      private string A1096BoletosSacadoTipoDocumento ;
      private string lV94Boletowwds_2_filterfulltext ;
      private string lV97Boletowwds_5_boletosnossonumero1 ;
      private string lV101Boletowwds_9_boletosnossonumero2 ;
      private string lV105Boletowwds_13_boletosnossonumero3 ;
      private string lV106Boletowwds_14_tfboletosnossonumero ;
      private string lV108Boletowwds_16_tfboletosseunumero ;
      private string lV110Boletowwds_18_tfboletosnumero ;
      private string lV133Boletowwds_41_tfboletossacadonome ;
      private string lV135Boletowwds_43_tfboletossacadodocumento ;
      private string AV94Boletowwds_2_filterfulltext ;
      private string AV95Boletowwds_3_dynamicfiltersselector1 ;
      private string AV97Boletowwds_5_boletosnossonumero1 ;
      private string AV99Boletowwds_7_dynamicfiltersselector2 ;
      private string AV101Boletowwds_9_boletosnossonumero2 ;
      private string AV103Boletowwds_11_dynamicfiltersselector3 ;
      private string AV105Boletowwds_13_boletosnossonumero3 ;
      private string AV107Boletowwds_15_tfboletosnossonumero_sel ;
      private string AV106Boletowwds_14_tfboletosnossonumero ;
      private string AV109Boletowwds_17_tfboletosseunumero_sel ;
      private string AV108Boletowwds_16_tfboletosseunumero ;
      private string AV111Boletowwds_19_tfboletosnumero_sel ;
      private string AV110Boletowwds_18_tfboletosnumero ;
      private string AV134Boletowwds_42_tfboletossacadonome_sel ;
      private string AV133Boletowwds_41_tfboletossacadonome ;
      private string AV136Boletowwds_44_tfboletossacadodocumento_sel ;
      private string AV135Boletowwds_43_tfboletossacadodocumento ;
      private string AV29ExcelFilename ;
      private string AV30ErrorMessage ;
      private string AV90AuxText ;
      private IGxSession AV31Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfboletosdataemissao_rangepicker ;
      private GXUserControl ucTfboletosdatavencimento_rangepicker ;
      private GXUserControl ucTfboletosdataregistro_rangepicker ;
      private GXUserControl ucTfboletosdatapagamento_rangepicker ;
      private GXUserControl ucTfboletosdatabaixa_rangepicker ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavGridactiongroup1 ;
      private GXCombobox cmbBoletosStatus ;
      private GXCombobox cmbBoletosSacadoTipoDocumento ;
      private GxSimpleCollection<string> AV42TFBoletosStatus_Sels ;
      private GxSimpleCollection<string> AV83TFBoletosSacadoTipoDocumento_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV32ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV84DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV112Boletowwds_20_tfboletosstatus_sels ;
      private GxSimpleCollection<string> AV137Boletowwds_45_tfboletossacadotipodocumento_sels ;
      private IDataStoreProvider pr_default ;
      private string[] H00A82_A1096BoletosSacadoTipoDocumento ;
      private bool[] H00A82_n1096BoletosSacadoTipoDocumento ;
      private string[] H00A82_A1095BoletosSacadoDocumento ;
      private bool[] H00A82_n1095BoletosSacadoDocumento ;
      private string[] H00A82_A1094BoletosSacadoNome ;
      private bool[] H00A82_n1094BoletosSacadoNome ;
      private decimal[] H00A82_A1093BoletosValorMulta ;
      private bool[] H00A82_n1093BoletosValorMulta ;
      private decimal[] H00A82_A1092BoletosValorJuros ;
      private bool[] H00A82_n1092BoletosValorJuros ;
      private decimal[] H00A82_A1091BoletosValorDesconto ;
      private bool[] H00A82_n1091BoletosValorDesconto ;
      private decimal[] H00A82_A1090BoletosValorPago ;
      private bool[] H00A82_n1090BoletosValorPago ;
      private decimal[] H00A82_A1089BoletosValorNominal ;
      private bool[] H00A82_n1089BoletosValorNominal ;
      private DateTime[] H00A82_A1088BoletosDataBaixa ;
      private bool[] H00A82_n1088BoletosDataBaixa ;
      private DateTime[] H00A82_A1087BoletosDataPagamento ;
      private bool[] H00A82_n1087BoletosDataPagamento ;
      private DateTime[] H00A82_A1086BoletosDataRegistro ;
      private bool[] H00A82_n1086BoletosDataRegistro ;
      private DateTime[] H00A82_A1085BoletosDataVencimento ;
      private bool[] H00A82_n1085BoletosDataVencimento ;
      private DateTime[] H00A82_A1084BoletosDataEmissao ;
      private bool[] H00A82_n1084BoletosDataEmissao ;
      private string[] H00A82_A1083BoletosStatus ;
      private bool[] H00A82_n1083BoletosStatus ;
      private string[] H00A82_A1082BoletosCodigoDeBarras ;
      private bool[] H00A82_n1082BoletosCodigoDeBarras ;
      private string[] H00A82_A1081BoletosLinhaDigitavel ;
      private bool[] H00A82_n1081BoletosLinhaDigitavel ;
      private string[] H00A82_A1080BoletosNumero ;
      private bool[] H00A82_n1080BoletosNumero ;
      private string[] H00A82_A1079BoletosSeuNumero ;
      private bool[] H00A82_n1079BoletosSeuNumero ;
      private string[] H00A82_A1078BoletosNossoNumero ;
      private bool[] H00A82_n1078BoletosNossoNumero ;
      private int[] H00A82_A261TituloId ;
      private bool[] H00A82_n261TituloId ;
      private int[] H00A82_A1069CarteiraDeCobrancaId ;
      private bool[] H00A82_n1069CarteiraDeCobrancaId ;
      private int[] H00A82_A1077BoletosId ;
      private long[] H00A83_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV9TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class boletoww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00A82( IGxContext context ,
                                             string A1083BoletosStatus ,
                                             GxSimpleCollection<string> AV112Boletowwds_20_tfboletosstatus_sels ,
                                             string A1096BoletosSacadoTipoDocumento ,
                                             GxSimpleCollection<string> AV137Boletowwds_45_tfboletossacadotipodocumento_sels ,
                                             string AV94Boletowwds_2_filterfulltext ,
                                             string AV95Boletowwds_3_dynamicfiltersselector1 ,
                                             short AV96Boletowwds_4_dynamicfiltersoperator1 ,
                                             string AV97Boletowwds_5_boletosnossonumero1 ,
                                             bool AV98Boletowwds_6_dynamicfiltersenabled2 ,
                                             string AV99Boletowwds_7_dynamicfiltersselector2 ,
                                             short AV100Boletowwds_8_dynamicfiltersoperator2 ,
                                             string AV101Boletowwds_9_boletosnossonumero2 ,
                                             bool AV102Boletowwds_10_dynamicfiltersenabled3 ,
                                             string AV103Boletowwds_11_dynamicfiltersselector3 ,
                                             short AV104Boletowwds_12_dynamicfiltersoperator3 ,
                                             string AV105Boletowwds_13_boletosnossonumero3 ,
                                             string AV107Boletowwds_15_tfboletosnossonumero_sel ,
                                             string AV106Boletowwds_14_tfboletosnossonumero ,
                                             string AV109Boletowwds_17_tfboletosseunumero_sel ,
                                             string AV108Boletowwds_16_tfboletosseunumero ,
                                             string AV111Boletowwds_19_tfboletosnumero_sel ,
                                             string AV110Boletowwds_18_tfboletosnumero ,
                                             int AV112Boletowwds_20_tfboletosstatus_sels_Count ,
                                             DateTime AV113Boletowwds_21_tfboletosdataemissao ,
                                             DateTime AV114Boletowwds_22_tfboletosdataemissao_to ,
                                             DateTime AV115Boletowwds_23_tfboletosdatavencimento ,
                                             DateTime AV116Boletowwds_24_tfboletosdatavencimento_to ,
                                             DateTime AV117Boletowwds_25_tfboletosdataregistro ,
                                             DateTime AV118Boletowwds_26_tfboletosdataregistro_to ,
                                             DateTime AV119Boletowwds_27_tfboletosdatapagamento ,
                                             DateTime AV120Boletowwds_28_tfboletosdatapagamento_to ,
                                             DateTime AV121Boletowwds_29_tfboletosdatabaixa ,
                                             DateTime AV122Boletowwds_30_tfboletosdatabaixa_to ,
                                             decimal AV123Boletowwds_31_tfboletosvalornominal ,
                                             decimal AV124Boletowwds_32_tfboletosvalornominal_to ,
                                             decimal AV125Boletowwds_33_tfboletosvalorpago ,
                                             decimal AV126Boletowwds_34_tfboletosvalorpago_to ,
                                             decimal AV127Boletowwds_35_tfboletosvalordesconto ,
                                             decimal AV128Boletowwds_36_tfboletosvalordesconto_to ,
                                             decimal AV129Boletowwds_37_tfboletosvalorjuros ,
                                             decimal AV130Boletowwds_38_tfboletosvalorjuros_to ,
                                             decimal AV131Boletowwds_39_tfboletosvalormulta ,
                                             decimal AV132Boletowwds_40_tfboletosvalormulta_to ,
                                             string AV134Boletowwds_42_tfboletossacadonome_sel ,
                                             string AV133Boletowwds_41_tfboletossacadonome ,
                                             string AV136Boletowwds_44_tfboletossacadodocumento_sel ,
                                             string AV135Boletowwds_43_tfboletossacadodocumento ,
                                             int AV137Boletowwds_45_tfboletossacadotipodocumento_sels_Count ,
                                             string A1078BoletosNossoNumero ,
                                             string A1079BoletosSeuNumero ,
                                             string A1080BoletosNumero ,
                                             decimal A1089BoletosValorNominal ,
                                             decimal A1090BoletosValorPago ,
                                             decimal A1091BoletosValorDesconto ,
                                             decimal A1092BoletosValorJuros ,
                                             decimal A1093BoletosValorMulta ,
                                             string A1094BoletosSacadoNome ,
                                             string A1095BoletosSacadoDocumento ,
                                             DateTime A1084BoletosDataEmissao ,
                                             DateTime A1085BoletosDataVencimento ,
                                             DateTime A1086BoletosDataRegistro ,
                                             DateTime A1087BoletosDataPagamento ,
                                             DateTime A1088BoletosDataBaixa ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             int A1069CarteiraDeCobrancaId ,
                                             int AV93Boletowwds_1_carteiradecobrancaid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[58];
         Object[] GXv_Object11 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " BoletosSacadoTipoDocumento, BoletosSacadoDocumento, BoletosSacadoNome, BoletosValorMulta, BoletosValorJuros, BoletosValorDesconto, BoletosValorPago, BoletosValorNominal, BoletosDataBaixa, BoletosDataPagamento, BoletosDataRegistro, BoletosDataVencimento, BoletosDataEmissao, BoletosStatus, BoletosCodigoDeBarras, BoletosLinhaDigitavel, BoletosNumero, BoletosSeuNumero, BoletosNossoNumero, TituloId, CarteiraDeCobrancaId, BoletosId";
         sFromString = " FROM Boleto";
         sOrderString = "";
         AddWhere(sWhereString, "(CarteiraDeCobrancaId = :AV93Boletowwds_1_carteiradecobrancaid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Boletowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( BoletosNossoNumero like '%' || :lV94Boletowwds_2_filterfulltext) or ( BoletosSeuNumero like '%' || :lV94Boletowwds_2_filterfulltext) or ( BoletosNumero like '%' || :lV94Boletowwds_2_filterfulltext) or ( 'rascunho' like '%' || LOWER(:lV94Boletowwds_2_filterfulltext) and BoletosStatus = ( 'RASCUNHO')) or ( 'registrado' like '%' || LOWER(:lV94Boletowwds_2_filterfulltext) and BoletosStatus = ( 'REGISTRADO')) or ( 'liquidado' like '%' || LOWER(:lV94Boletowwds_2_filterfulltext) and BoletosStatus = ( 'LIQUIDADO')) or ( 'baixado' like '%' || LOWER(:lV94Boletowwds_2_filterfulltext) and BoletosStatus = ( 'BAIXADO')) or ( 'vencido' like '%' || LOWER(:lV94Boletowwds_2_filterfulltext) and BoletosStatus = ( 'VENCIDO')) or ( 'erro' like '%' || LOWER(:lV94Boletowwds_2_filterfulltext) and BoletosStatus = ( 'ERRO')) or ( SUBSTR(TO_CHAR(BoletosValorNominal,'999999999999990.99'), 2) like '%' || :lV94Boletowwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorPago,'999999999999990.99'), 2) like '%' || :lV94Boletowwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorDesconto,'999999999999990.99'), 2) like '%' || :lV94Boletowwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorJuros,'999999999999990.99'), 2) like '%' || :lV94Boletowwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorMulta,'999999999999990.99'), 2) like '%' || :lV94Boletowwds_2_filterfulltext) or ( BoletosSacadoNome like '%' || :lV94Boletowwds_2_filterfulltext) or ( BoletosSacadoDocumento like '%' || :lV94Boletowwds_2_filterfulltext) or ( 'cpf' like '%' || LOWER(:lV94Boletowwds_2_filterfulltext) and BoletosSacadoTipoDocumento = ( 'CPF')) or ( 'cnpj' like '%' || LOWER(:lV94Boletowwds_2_filterfulltext) and BoletosSacadoTipoDocumento = ( 'CNPJ')))");
         }
         else
         {
            GXv_int10[1] = 1;
            GXv_int10[2] = 1;
            GXv_int10[3] = 1;
            GXv_int10[4] = 1;
            GXv_int10[5] = 1;
            GXv_int10[6] = 1;
            GXv_int10[7] = 1;
            GXv_int10[8] = 1;
            GXv_int10[9] = 1;
            GXv_int10[10] = 1;
            GXv_int10[11] = 1;
            GXv_int10[12] = 1;
            GXv_int10[13] = 1;
            GXv_int10[14] = 1;
            GXv_int10[15] = 1;
            GXv_int10[16] = 1;
            GXv_int10[17] = 1;
            GXv_int10[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV95Boletowwds_3_dynamicfiltersselector1, "BOLETOSNOSSONUMERO") == 0 ) && ( AV96Boletowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Boletowwds_5_boletosnossonumero1)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV97Boletowwds_5_boletosnossonumero1)");
         }
         else
         {
            GXv_int10[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV95Boletowwds_3_dynamicfiltersselector1, "BOLETOSNOSSONUMERO") == 0 ) && ( AV96Boletowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Boletowwds_5_boletosnossonumero1)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like '%' || :lV97Boletowwds_5_boletosnossonumero1)");
         }
         else
         {
            GXv_int10[20] = 1;
         }
         if ( AV98Boletowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Boletowwds_7_dynamicfiltersselector2, "BOLETOSNOSSONUMERO") == 0 ) && ( AV100Boletowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Boletowwds_9_boletosnossonumero2)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV101Boletowwds_9_boletosnossonumero2)");
         }
         else
         {
            GXv_int10[21] = 1;
         }
         if ( AV98Boletowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Boletowwds_7_dynamicfiltersselector2, "BOLETOSNOSSONUMERO") == 0 ) && ( AV100Boletowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Boletowwds_9_boletosnossonumero2)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like '%' || :lV101Boletowwds_9_boletosnossonumero2)");
         }
         else
         {
            GXv_int10[22] = 1;
         }
         if ( AV102Boletowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV103Boletowwds_11_dynamicfiltersselector3, "BOLETOSNOSSONUMERO") == 0 ) && ( AV104Boletowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Boletowwds_13_boletosnossonumero3)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV105Boletowwds_13_boletosnossonumero3)");
         }
         else
         {
            GXv_int10[23] = 1;
         }
         if ( AV102Boletowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV103Boletowwds_11_dynamicfiltersselector3, "BOLETOSNOSSONUMERO") == 0 ) && ( AV104Boletowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Boletowwds_13_boletosnossonumero3)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like '%' || :lV105Boletowwds_13_boletosnossonumero3)");
         }
         else
         {
            GXv_int10[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Boletowwds_15_tfboletosnossonumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Boletowwds_14_tfboletosnossonumero)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV106Boletowwds_14_tfboletosnossonumero)");
         }
         else
         {
            GXv_int10[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Boletowwds_15_tfboletosnossonumero_sel)) && ! ( StringUtil.StrCmp(AV107Boletowwds_15_tfboletosnossonumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero = ( :AV107Boletowwds_15_tfboletosnossonumero_sel))");
         }
         else
         {
            GXv_int10[26] = 1;
         }
         if ( StringUtil.StrCmp(AV107Boletowwds_15_tfboletosnossonumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero IS NULL or (char_length(trim(trailing ' ' from BoletosNossoNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Boletowwds_17_tfboletosseunumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Boletowwds_16_tfboletosseunumero)) ) )
         {
            AddWhere(sWhereString, "(BoletosSeuNumero like :lV108Boletowwds_16_tfboletosseunumero)");
         }
         else
         {
            GXv_int10[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Boletowwds_17_tfboletosseunumero_sel)) && ! ( StringUtil.StrCmp(AV109Boletowwds_17_tfboletosseunumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosSeuNumero = ( :AV109Boletowwds_17_tfboletosseunumero_sel))");
         }
         else
         {
            GXv_int10[28] = 1;
         }
         if ( StringUtil.StrCmp(AV109Boletowwds_17_tfboletosseunumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosSeuNumero IS NULL or (char_length(trim(trailing ' ' from BoletosSeuNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Boletowwds_19_tfboletosnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Boletowwds_18_tfboletosnumero)) ) )
         {
            AddWhere(sWhereString, "(BoletosNumero like :lV110Boletowwds_18_tfboletosnumero)");
         }
         else
         {
            GXv_int10[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Boletowwds_19_tfboletosnumero_sel)) && ! ( StringUtil.StrCmp(AV111Boletowwds_19_tfboletosnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosNumero = ( :AV111Boletowwds_19_tfboletosnumero_sel))");
         }
         else
         {
            GXv_int10[30] = 1;
         }
         if ( StringUtil.StrCmp(AV111Boletowwds_19_tfboletosnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosNumero IS NULL or (char_length(trim(trailing ' ' from BoletosNumero))=0))");
         }
         if ( AV112Boletowwds_20_tfboletosstatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV112Boletowwds_20_tfboletosstatus_sels, "BoletosStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV113Boletowwds_21_tfboletosdataemissao) )
         {
            AddWhere(sWhereString, "(BoletosDataEmissao >= :AV113Boletowwds_21_tfboletosdataemissao)");
         }
         else
         {
            GXv_int10[31] = 1;
         }
         if ( ! (DateTime.MinValue==AV114Boletowwds_22_tfboletosdataemissao_to) )
         {
            AddWhere(sWhereString, "(BoletosDataEmissao <= :AV114Boletowwds_22_tfboletosdataemissao_to)");
         }
         else
         {
            GXv_int10[32] = 1;
         }
         if ( ! (DateTime.MinValue==AV115Boletowwds_23_tfboletosdatavencimento) )
         {
            AddWhere(sWhereString, "(BoletosDataVencimento >= :AV115Boletowwds_23_tfboletosdatavencimento)");
         }
         else
         {
            GXv_int10[33] = 1;
         }
         if ( ! (DateTime.MinValue==AV116Boletowwds_24_tfboletosdatavencimento_to) )
         {
            AddWhere(sWhereString, "(BoletosDataVencimento <= :AV116Boletowwds_24_tfboletosdatavencimento_to)");
         }
         else
         {
            GXv_int10[34] = 1;
         }
         if ( ! (DateTime.MinValue==AV117Boletowwds_25_tfboletosdataregistro) )
         {
            AddWhere(sWhereString, "(BoletosDataRegistro >= :AV117Boletowwds_25_tfboletosdataregistro)");
         }
         else
         {
            GXv_int10[35] = 1;
         }
         if ( ! (DateTime.MinValue==AV118Boletowwds_26_tfboletosdataregistro_to) )
         {
            AddWhere(sWhereString, "(BoletosDataRegistro <= :AV118Boletowwds_26_tfboletosdataregistro_to)");
         }
         else
         {
            GXv_int10[36] = 1;
         }
         if ( ! (DateTime.MinValue==AV119Boletowwds_27_tfboletosdatapagamento) )
         {
            AddWhere(sWhereString, "(BoletosDataPagamento >= :AV119Boletowwds_27_tfboletosdatapagamento)");
         }
         else
         {
            GXv_int10[37] = 1;
         }
         if ( ! (DateTime.MinValue==AV120Boletowwds_28_tfboletosdatapagamento_to) )
         {
            AddWhere(sWhereString, "(BoletosDataPagamento <= :AV120Boletowwds_28_tfboletosdatapagamento_to)");
         }
         else
         {
            GXv_int10[38] = 1;
         }
         if ( ! (DateTime.MinValue==AV121Boletowwds_29_tfboletosdatabaixa) )
         {
            AddWhere(sWhereString, "(BoletosDataBaixa >= :AV121Boletowwds_29_tfboletosdatabaixa)");
         }
         else
         {
            GXv_int10[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV122Boletowwds_30_tfboletosdatabaixa_to) )
         {
            AddWhere(sWhereString, "(BoletosDataBaixa <= :AV122Boletowwds_30_tfboletosdatabaixa_to)");
         }
         else
         {
            GXv_int10[40] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV123Boletowwds_31_tfboletosvalornominal) )
         {
            AddWhere(sWhereString, "(BoletosValorNominal >= :AV123Boletowwds_31_tfboletosvalornominal)");
         }
         else
         {
            GXv_int10[41] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV124Boletowwds_32_tfboletosvalornominal_to) )
         {
            AddWhere(sWhereString, "(BoletosValorNominal <= :AV124Boletowwds_32_tfboletosvalornominal_to)");
         }
         else
         {
            GXv_int10[42] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV125Boletowwds_33_tfboletosvalorpago) )
         {
            AddWhere(sWhereString, "(BoletosValorPago >= :AV125Boletowwds_33_tfboletosvalorpago)");
         }
         else
         {
            GXv_int10[43] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV126Boletowwds_34_tfboletosvalorpago_to) )
         {
            AddWhere(sWhereString, "(BoletosValorPago <= :AV126Boletowwds_34_tfboletosvalorpago_to)");
         }
         else
         {
            GXv_int10[44] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV127Boletowwds_35_tfboletosvalordesconto) )
         {
            AddWhere(sWhereString, "(BoletosValorDesconto >= :AV127Boletowwds_35_tfboletosvalordesconto)");
         }
         else
         {
            GXv_int10[45] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV128Boletowwds_36_tfboletosvalordesconto_to) )
         {
            AddWhere(sWhereString, "(BoletosValorDesconto <= :AV128Boletowwds_36_tfboletosvalordesconto_to)");
         }
         else
         {
            GXv_int10[46] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV129Boletowwds_37_tfboletosvalorjuros) )
         {
            AddWhere(sWhereString, "(BoletosValorJuros >= :AV129Boletowwds_37_tfboletosvalorjuros)");
         }
         else
         {
            GXv_int10[47] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV130Boletowwds_38_tfboletosvalorjuros_to) )
         {
            AddWhere(sWhereString, "(BoletosValorJuros <= :AV130Boletowwds_38_tfboletosvalorjuros_to)");
         }
         else
         {
            GXv_int10[48] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV131Boletowwds_39_tfboletosvalormulta) )
         {
            AddWhere(sWhereString, "(BoletosValorMulta >= :AV131Boletowwds_39_tfboletosvalormulta)");
         }
         else
         {
            GXv_int10[49] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV132Boletowwds_40_tfboletosvalormulta_to) )
         {
            AddWhere(sWhereString, "(BoletosValorMulta <= :AV132Boletowwds_40_tfboletosvalormulta_to)");
         }
         else
         {
            GXv_int10[50] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV134Boletowwds_42_tfboletossacadonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Boletowwds_41_tfboletossacadonome)) ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoNome like :lV133Boletowwds_41_tfboletossacadonome)");
         }
         else
         {
            GXv_int10[51] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Boletowwds_42_tfboletossacadonome_sel)) && ! ( StringUtil.StrCmp(AV134Boletowwds_42_tfboletossacadonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoNome = ( :AV134Boletowwds_42_tfboletossacadonome_sel))");
         }
         else
         {
            GXv_int10[52] = 1;
         }
         if ( StringUtil.StrCmp(AV134Boletowwds_42_tfboletossacadonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosSacadoNome IS NULL or (char_length(trim(trailing ' ' from BoletosSacadoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV136Boletowwds_44_tfboletossacadodocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Boletowwds_43_tfboletossacadodocumento)) ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoDocumento like :lV135Boletowwds_43_tfboletossacadodocumento)");
         }
         else
         {
            GXv_int10[53] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Boletowwds_44_tfboletossacadodocumento_sel)) && ! ( StringUtil.StrCmp(AV136Boletowwds_44_tfboletossacadodocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoDocumento = ( :AV136Boletowwds_44_tfboletossacadodocumento_sel))");
         }
         else
         {
            GXv_int10[54] = 1;
         }
         if ( StringUtil.StrCmp(AV136Boletowwds_44_tfboletossacadodocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosSacadoDocumento IS NULL or (char_length(trim(trailing ' ' from BoletosSacadoDocumento))=0))");
         }
         if ( AV137Boletowwds_45_tfboletossacadotipodocumento_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV137Boletowwds_45_tfboletossacadotipodocumento_sels, "BoletosSacadoTipoDocumento IN (", ")")+")");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId, BoletosNossoNumero, BoletosId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId DESC, BoletosNossoNumero DESC, BoletosId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId, BoletosSeuNumero, BoletosId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId DESC, BoletosSeuNumero DESC, BoletosId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId, BoletosNumero, BoletosId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId DESC, BoletosNumero DESC, BoletosId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId, BoletosStatus, BoletosId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId DESC, BoletosStatus DESC, BoletosId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId, BoletosDataEmissao, BoletosId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId DESC, BoletosDataEmissao DESC, BoletosId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId, BoletosDataVencimento, BoletosId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId DESC, BoletosDataVencimento DESC, BoletosId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId, BoletosDataRegistro, BoletosId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId DESC, BoletosDataRegistro DESC, BoletosId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId, BoletosDataPagamento, BoletosId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId DESC, BoletosDataPagamento DESC, BoletosId";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId, BoletosDataBaixa, BoletosId";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId DESC, BoletosDataBaixa DESC, BoletosId";
         }
         else if ( ( AV13OrderedBy == 10 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId, BoletosValorNominal, BoletosId";
         }
         else if ( ( AV13OrderedBy == 10 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId DESC, BoletosValorNominal DESC, BoletosId";
         }
         else if ( ( AV13OrderedBy == 11 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId, BoletosValorPago, BoletosId";
         }
         else if ( ( AV13OrderedBy == 11 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId DESC, BoletosValorPago DESC, BoletosId";
         }
         else if ( ( AV13OrderedBy == 12 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId, BoletosValorDesconto, BoletosId";
         }
         else if ( ( AV13OrderedBy == 12 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId DESC, BoletosValorDesconto DESC, BoletosId";
         }
         else if ( ( AV13OrderedBy == 13 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId, BoletosValorJuros, BoletosId";
         }
         else if ( ( AV13OrderedBy == 13 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId DESC, BoletosValorJuros DESC, BoletosId";
         }
         else if ( ( AV13OrderedBy == 14 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId, BoletosValorMulta, BoletosId";
         }
         else if ( ( AV13OrderedBy == 14 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId DESC, BoletosValorMulta DESC, BoletosId";
         }
         else if ( ( AV13OrderedBy == 15 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId, BoletosSacadoNome, BoletosId";
         }
         else if ( ( AV13OrderedBy == 15 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId DESC, BoletosSacadoNome DESC, BoletosId";
         }
         else if ( ( AV13OrderedBy == 16 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId, BoletosSacadoDocumento, BoletosId";
         }
         else if ( ( AV13OrderedBy == 16 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId DESC, BoletosSacadoDocumento DESC, BoletosId";
         }
         else if ( ( AV13OrderedBy == 17 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId, BoletosSacadoTipoDocumento, BoletosId";
         }
         else if ( ( AV13OrderedBy == 17 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId DESC, BoletosSacadoTipoDocumento DESC, BoletosId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY BoletosId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      protected Object[] conditional_H00A83( IGxContext context ,
                                             string A1083BoletosStatus ,
                                             GxSimpleCollection<string> AV112Boletowwds_20_tfboletosstatus_sels ,
                                             string A1096BoletosSacadoTipoDocumento ,
                                             GxSimpleCollection<string> AV137Boletowwds_45_tfboletossacadotipodocumento_sels ,
                                             string AV94Boletowwds_2_filterfulltext ,
                                             string AV95Boletowwds_3_dynamicfiltersselector1 ,
                                             short AV96Boletowwds_4_dynamicfiltersoperator1 ,
                                             string AV97Boletowwds_5_boletosnossonumero1 ,
                                             bool AV98Boletowwds_6_dynamicfiltersenabled2 ,
                                             string AV99Boletowwds_7_dynamicfiltersselector2 ,
                                             short AV100Boletowwds_8_dynamicfiltersoperator2 ,
                                             string AV101Boletowwds_9_boletosnossonumero2 ,
                                             bool AV102Boletowwds_10_dynamicfiltersenabled3 ,
                                             string AV103Boletowwds_11_dynamicfiltersselector3 ,
                                             short AV104Boletowwds_12_dynamicfiltersoperator3 ,
                                             string AV105Boletowwds_13_boletosnossonumero3 ,
                                             string AV107Boletowwds_15_tfboletosnossonumero_sel ,
                                             string AV106Boletowwds_14_tfboletosnossonumero ,
                                             string AV109Boletowwds_17_tfboletosseunumero_sel ,
                                             string AV108Boletowwds_16_tfboletosseunumero ,
                                             string AV111Boletowwds_19_tfboletosnumero_sel ,
                                             string AV110Boletowwds_18_tfboletosnumero ,
                                             int AV112Boletowwds_20_tfboletosstatus_sels_Count ,
                                             DateTime AV113Boletowwds_21_tfboletosdataemissao ,
                                             DateTime AV114Boletowwds_22_tfboletosdataemissao_to ,
                                             DateTime AV115Boletowwds_23_tfboletosdatavencimento ,
                                             DateTime AV116Boletowwds_24_tfboletosdatavencimento_to ,
                                             DateTime AV117Boletowwds_25_tfboletosdataregistro ,
                                             DateTime AV118Boletowwds_26_tfboletosdataregistro_to ,
                                             DateTime AV119Boletowwds_27_tfboletosdatapagamento ,
                                             DateTime AV120Boletowwds_28_tfboletosdatapagamento_to ,
                                             DateTime AV121Boletowwds_29_tfboletosdatabaixa ,
                                             DateTime AV122Boletowwds_30_tfboletosdatabaixa_to ,
                                             decimal AV123Boletowwds_31_tfboletosvalornominal ,
                                             decimal AV124Boletowwds_32_tfboletosvalornominal_to ,
                                             decimal AV125Boletowwds_33_tfboletosvalorpago ,
                                             decimal AV126Boletowwds_34_tfboletosvalorpago_to ,
                                             decimal AV127Boletowwds_35_tfboletosvalordesconto ,
                                             decimal AV128Boletowwds_36_tfboletosvalordesconto_to ,
                                             decimal AV129Boletowwds_37_tfboletosvalorjuros ,
                                             decimal AV130Boletowwds_38_tfboletosvalorjuros_to ,
                                             decimal AV131Boletowwds_39_tfboletosvalormulta ,
                                             decimal AV132Boletowwds_40_tfboletosvalormulta_to ,
                                             string AV134Boletowwds_42_tfboletossacadonome_sel ,
                                             string AV133Boletowwds_41_tfboletossacadonome ,
                                             string AV136Boletowwds_44_tfboletossacadodocumento_sel ,
                                             string AV135Boletowwds_43_tfboletossacadodocumento ,
                                             int AV137Boletowwds_45_tfboletossacadotipodocumento_sels_Count ,
                                             string A1078BoletosNossoNumero ,
                                             string A1079BoletosSeuNumero ,
                                             string A1080BoletosNumero ,
                                             decimal A1089BoletosValorNominal ,
                                             decimal A1090BoletosValorPago ,
                                             decimal A1091BoletosValorDesconto ,
                                             decimal A1092BoletosValorJuros ,
                                             decimal A1093BoletosValorMulta ,
                                             string A1094BoletosSacadoNome ,
                                             string A1095BoletosSacadoDocumento ,
                                             DateTime A1084BoletosDataEmissao ,
                                             DateTime A1085BoletosDataVencimento ,
                                             DateTime A1086BoletosDataRegistro ,
                                             DateTime A1087BoletosDataPagamento ,
                                             DateTime A1088BoletosDataBaixa ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             int A1069CarteiraDeCobrancaId ,
                                             int AV93Boletowwds_1_carteiradecobrancaid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[55];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM Boleto";
         AddWhere(sWhereString, "(CarteiraDeCobrancaId = :AV93Boletowwds_1_carteiradecobrancaid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Boletowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( BoletosNossoNumero like '%' || :lV94Boletowwds_2_filterfulltext) or ( BoletosSeuNumero like '%' || :lV94Boletowwds_2_filterfulltext) or ( BoletosNumero like '%' || :lV94Boletowwds_2_filterfulltext) or ( 'rascunho' like '%' || LOWER(:lV94Boletowwds_2_filterfulltext) and BoletosStatus = ( 'RASCUNHO')) or ( 'registrado' like '%' || LOWER(:lV94Boletowwds_2_filterfulltext) and BoletosStatus = ( 'REGISTRADO')) or ( 'liquidado' like '%' || LOWER(:lV94Boletowwds_2_filterfulltext) and BoletosStatus = ( 'LIQUIDADO')) or ( 'baixado' like '%' || LOWER(:lV94Boletowwds_2_filterfulltext) and BoletosStatus = ( 'BAIXADO')) or ( 'vencido' like '%' || LOWER(:lV94Boletowwds_2_filterfulltext) and BoletosStatus = ( 'VENCIDO')) or ( 'erro' like '%' || LOWER(:lV94Boletowwds_2_filterfulltext) and BoletosStatus = ( 'ERRO')) or ( SUBSTR(TO_CHAR(BoletosValorNominal,'999999999999990.99'), 2) like '%' || :lV94Boletowwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorPago,'999999999999990.99'), 2) like '%' || :lV94Boletowwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorDesconto,'999999999999990.99'), 2) like '%' || :lV94Boletowwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorJuros,'999999999999990.99'), 2) like '%' || :lV94Boletowwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorMulta,'999999999999990.99'), 2) like '%' || :lV94Boletowwds_2_filterfulltext) or ( BoletosSacadoNome like '%' || :lV94Boletowwds_2_filterfulltext) or ( BoletosSacadoDocumento like '%' || :lV94Boletowwds_2_filterfulltext) or ( 'cpf' like '%' || LOWER(:lV94Boletowwds_2_filterfulltext) and BoletosSacadoTipoDocumento = ( 'CPF')) or ( 'cnpj' like '%' || LOWER(:lV94Boletowwds_2_filterfulltext) and BoletosSacadoTipoDocumento = ( 'CNPJ')))");
         }
         else
         {
            GXv_int12[1] = 1;
            GXv_int12[2] = 1;
            GXv_int12[3] = 1;
            GXv_int12[4] = 1;
            GXv_int12[5] = 1;
            GXv_int12[6] = 1;
            GXv_int12[7] = 1;
            GXv_int12[8] = 1;
            GXv_int12[9] = 1;
            GXv_int12[10] = 1;
            GXv_int12[11] = 1;
            GXv_int12[12] = 1;
            GXv_int12[13] = 1;
            GXv_int12[14] = 1;
            GXv_int12[15] = 1;
            GXv_int12[16] = 1;
            GXv_int12[17] = 1;
            GXv_int12[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV95Boletowwds_3_dynamicfiltersselector1, "BOLETOSNOSSONUMERO") == 0 ) && ( AV96Boletowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Boletowwds_5_boletosnossonumero1)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV97Boletowwds_5_boletosnossonumero1)");
         }
         else
         {
            GXv_int12[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV95Boletowwds_3_dynamicfiltersselector1, "BOLETOSNOSSONUMERO") == 0 ) && ( AV96Boletowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Boletowwds_5_boletosnossonumero1)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like '%' || :lV97Boletowwds_5_boletosnossonumero1)");
         }
         else
         {
            GXv_int12[20] = 1;
         }
         if ( AV98Boletowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Boletowwds_7_dynamicfiltersselector2, "BOLETOSNOSSONUMERO") == 0 ) && ( AV100Boletowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Boletowwds_9_boletosnossonumero2)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV101Boletowwds_9_boletosnossonumero2)");
         }
         else
         {
            GXv_int12[21] = 1;
         }
         if ( AV98Boletowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Boletowwds_7_dynamicfiltersselector2, "BOLETOSNOSSONUMERO") == 0 ) && ( AV100Boletowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Boletowwds_9_boletosnossonumero2)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like '%' || :lV101Boletowwds_9_boletosnossonumero2)");
         }
         else
         {
            GXv_int12[22] = 1;
         }
         if ( AV102Boletowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV103Boletowwds_11_dynamicfiltersselector3, "BOLETOSNOSSONUMERO") == 0 ) && ( AV104Boletowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Boletowwds_13_boletosnossonumero3)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV105Boletowwds_13_boletosnossonumero3)");
         }
         else
         {
            GXv_int12[23] = 1;
         }
         if ( AV102Boletowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV103Boletowwds_11_dynamicfiltersselector3, "BOLETOSNOSSONUMERO") == 0 ) && ( AV104Boletowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Boletowwds_13_boletosnossonumero3)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like '%' || :lV105Boletowwds_13_boletosnossonumero3)");
         }
         else
         {
            GXv_int12[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Boletowwds_15_tfboletosnossonumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Boletowwds_14_tfboletosnossonumero)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV106Boletowwds_14_tfboletosnossonumero)");
         }
         else
         {
            GXv_int12[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Boletowwds_15_tfboletosnossonumero_sel)) && ! ( StringUtil.StrCmp(AV107Boletowwds_15_tfboletosnossonumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero = ( :AV107Boletowwds_15_tfboletosnossonumero_sel))");
         }
         else
         {
            GXv_int12[26] = 1;
         }
         if ( StringUtil.StrCmp(AV107Boletowwds_15_tfboletosnossonumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero IS NULL or (char_length(trim(trailing ' ' from BoletosNossoNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Boletowwds_17_tfboletosseunumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Boletowwds_16_tfboletosseunumero)) ) )
         {
            AddWhere(sWhereString, "(BoletosSeuNumero like :lV108Boletowwds_16_tfboletosseunumero)");
         }
         else
         {
            GXv_int12[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Boletowwds_17_tfboletosseunumero_sel)) && ! ( StringUtil.StrCmp(AV109Boletowwds_17_tfboletosseunumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosSeuNumero = ( :AV109Boletowwds_17_tfboletosseunumero_sel))");
         }
         else
         {
            GXv_int12[28] = 1;
         }
         if ( StringUtil.StrCmp(AV109Boletowwds_17_tfboletosseunumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosSeuNumero IS NULL or (char_length(trim(trailing ' ' from BoletosSeuNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Boletowwds_19_tfboletosnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Boletowwds_18_tfboletosnumero)) ) )
         {
            AddWhere(sWhereString, "(BoletosNumero like :lV110Boletowwds_18_tfboletosnumero)");
         }
         else
         {
            GXv_int12[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Boletowwds_19_tfboletosnumero_sel)) && ! ( StringUtil.StrCmp(AV111Boletowwds_19_tfboletosnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosNumero = ( :AV111Boletowwds_19_tfboletosnumero_sel))");
         }
         else
         {
            GXv_int12[30] = 1;
         }
         if ( StringUtil.StrCmp(AV111Boletowwds_19_tfboletosnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosNumero IS NULL or (char_length(trim(trailing ' ' from BoletosNumero))=0))");
         }
         if ( AV112Boletowwds_20_tfboletosstatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV112Boletowwds_20_tfboletosstatus_sels, "BoletosStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV113Boletowwds_21_tfboletosdataemissao) )
         {
            AddWhere(sWhereString, "(BoletosDataEmissao >= :AV113Boletowwds_21_tfboletosdataemissao)");
         }
         else
         {
            GXv_int12[31] = 1;
         }
         if ( ! (DateTime.MinValue==AV114Boletowwds_22_tfboletosdataemissao_to) )
         {
            AddWhere(sWhereString, "(BoletosDataEmissao <= :AV114Boletowwds_22_tfboletosdataemissao_to)");
         }
         else
         {
            GXv_int12[32] = 1;
         }
         if ( ! (DateTime.MinValue==AV115Boletowwds_23_tfboletosdatavencimento) )
         {
            AddWhere(sWhereString, "(BoletosDataVencimento >= :AV115Boletowwds_23_tfboletosdatavencimento)");
         }
         else
         {
            GXv_int12[33] = 1;
         }
         if ( ! (DateTime.MinValue==AV116Boletowwds_24_tfboletosdatavencimento_to) )
         {
            AddWhere(sWhereString, "(BoletosDataVencimento <= :AV116Boletowwds_24_tfboletosdatavencimento_to)");
         }
         else
         {
            GXv_int12[34] = 1;
         }
         if ( ! (DateTime.MinValue==AV117Boletowwds_25_tfboletosdataregistro) )
         {
            AddWhere(sWhereString, "(BoletosDataRegistro >= :AV117Boletowwds_25_tfboletosdataregistro)");
         }
         else
         {
            GXv_int12[35] = 1;
         }
         if ( ! (DateTime.MinValue==AV118Boletowwds_26_tfboletosdataregistro_to) )
         {
            AddWhere(sWhereString, "(BoletosDataRegistro <= :AV118Boletowwds_26_tfboletosdataregistro_to)");
         }
         else
         {
            GXv_int12[36] = 1;
         }
         if ( ! (DateTime.MinValue==AV119Boletowwds_27_tfboletosdatapagamento) )
         {
            AddWhere(sWhereString, "(BoletosDataPagamento >= :AV119Boletowwds_27_tfboletosdatapagamento)");
         }
         else
         {
            GXv_int12[37] = 1;
         }
         if ( ! (DateTime.MinValue==AV120Boletowwds_28_tfboletosdatapagamento_to) )
         {
            AddWhere(sWhereString, "(BoletosDataPagamento <= :AV120Boletowwds_28_tfboletosdatapagamento_to)");
         }
         else
         {
            GXv_int12[38] = 1;
         }
         if ( ! (DateTime.MinValue==AV121Boletowwds_29_tfboletosdatabaixa) )
         {
            AddWhere(sWhereString, "(BoletosDataBaixa >= :AV121Boletowwds_29_tfboletosdatabaixa)");
         }
         else
         {
            GXv_int12[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV122Boletowwds_30_tfboletosdatabaixa_to) )
         {
            AddWhere(sWhereString, "(BoletosDataBaixa <= :AV122Boletowwds_30_tfboletosdatabaixa_to)");
         }
         else
         {
            GXv_int12[40] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV123Boletowwds_31_tfboletosvalornominal) )
         {
            AddWhere(sWhereString, "(BoletosValorNominal >= :AV123Boletowwds_31_tfboletosvalornominal)");
         }
         else
         {
            GXv_int12[41] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV124Boletowwds_32_tfboletosvalornominal_to) )
         {
            AddWhere(sWhereString, "(BoletosValorNominal <= :AV124Boletowwds_32_tfboletosvalornominal_to)");
         }
         else
         {
            GXv_int12[42] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV125Boletowwds_33_tfboletosvalorpago) )
         {
            AddWhere(sWhereString, "(BoletosValorPago >= :AV125Boletowwds_33_tfboletosvalorpago)");
         }
         else
         {
            GXv_int12[43] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV126Boletowwds_34_tfboletosvalorpago_to) )
         {
            AddWhere(sWhereString, "(BoletosValorPago <= :AV126Boletowwds_34_tfboletosvalorpago_to)");
         }
         else
         {
            GXv_int12[44] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV127Boletowwds_35_tfboletosvalordesconto) )
         {
            AddWhere(sWhereString, "(BoletosValorDesconto >= :AV127Boletowwds_35_tfboletosvalordesconto)");
         }
         else
         {
            GXv_int12[45] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV128Boletowwds_36_tfboletosvalordesconto_to) )
         {
            AddWhere(sWhereString, "(BoletosValorDesconto <= :AV128Boletowwds_36_tfboletosvalordesconto_to)");
         }
         else
         {
            GXv_int12[46] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV129Boletowwds_37_tfboletosvalorjuros) )
         {
            AddWhere(sWhereString, "(BoletosValorJuros >= :AV129Boletowwds_37_tfboletosvalorjuros)");
         }
         else
         {
            GXv_int12[47] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV130Boletowwds_38_tfboletosvalorjuros_to) )
         {
            AddWhere(sWhereString, "(BoletosValorJuros <= :AV130Boletowwds_38_tfboletosvalorjuros_to)");
         }
         else
         {
            GXv_int12[48] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV131Boletowwds_39_tfboletosvalormulta) )
         {
            AddWhere(sWhereString, "(BoletosValorMulta >= :AV131Boletowwds_39_tfboletosvalormulta)");
         }
         else
         {
            GXv_int12[49] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV132Boletowwds_40_tfboletosvalormulta_to) )
         {
            AddWhere(sWhereString, "(BoletosValorMulta <= :AV132Boletowwds_40_tfboletosvalormulta_to)");
         }
         else
         {
            GXv_int12[50] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV134Boletowwds_42_tfboletossacadonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Boletowwds_41_tfboletossacadonome)) ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoNome like :lV133Boletowwds_41_tfboletossacadonome)");
         }
         else
         {
            GXv_int12[51] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Boletowwds_42_tfboletossacadonome_sel)) && ! ( StringUtil.StrCmp(AV134Boletowwds_42_tfboletossacadonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoNome = ( :AV134Boletowwds_42_tfboletossacadonome_sel))");
         }
         else
         {
            GXv_int12[52] = 1;
         }
         if ( StringUtil.StrCmp(AV134Boletowwds_42_tfboletossacadonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosSacadoNome IS NULL or (char_length(trim(trailing ' ' from BoletosSacadoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV136Boletowwds_44_tfboletossacadodocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Boletowwds_43_tfboletossacadodocumento)) ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoDocumento like :lV135Boletowwds_43_tfboletossacadodocumento)");
         }
         else
         {
            GXv_int12[53] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Boletowwds_44_tfboletossacadodocumento_sel)) && ! ( StringUtil.StrCmp(AV136Boletowwds_44_tfboletossacadodocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoDocumento = ( :AV136Boletowwds_44_tfboletossacadodocumento_sel))");
         }
         else
         {
            GXv_int12[54] = 1;
         }
         if ( StringUtil.StrCmp(AV136Boletowwds_44_tfboletossacadodocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosSacadoDocumento IS NULL or (char_length(trim(trailing ' ' from BoletosSacadoDocumento))=0))");
         }
         if ( AV137Boletowwds_45_tfboletossacadotipodocumento_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV137Boletowwds_45_tfboletossacadotipodocumento_sels, "BoletosSacadoTipoDocumento IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 10 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 10 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 11 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 11 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 12 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 12 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 13 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 13 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 14 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 14 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 15 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 15 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 16 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 16 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 17 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 17 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object13[0] = scmdbuf;
         GXv_Object13[1] = GXv_int12;
         return GXv_Object13 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00A82(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (decimal)dynConstraints[33] , (decimal)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (decimal)dynConstraints[39] , (decimal)dynConstraints[40] , (decimal)dynConstraints[41] , (decimal)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (int)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (decimal)dynConstraints[51] , (decimal)dynConstraints[52] , (decimal)dynConstraints[53] , (decimal)dynConstraints[54] , (decimal)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (DateTime)dynConstraints[58] , (DateTime)dynConstraints[59] , (DateTime)dynConstraints[60] , (DateTime)dynConstraints[61] , (DateTime)dynConstraints[62] , (short)dynConstraints[63] , (bool)dynConstraints[64] , (int)dynConstraints[65] , (int)dynConstraints[66] );
               case 1 :
                     return conditional_H00A83(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (decimal)dynConstraints[33] , (decimal)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (decimal)dynConstraints[39] , (decimal)dynConstraints[40] , (decimal)dynConstraints[41] , (decimal)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (int)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (decimal)dynConstraints[51] , (decimal)dynConstraints[52] , (decimal)dynConstraints[53] , (decimal)dynConstraints[54] , (decimal)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (DateTime)dynConstraints[58] , (DateTime)dynConstraints[59] , (DateTime)dynConstraints[60] , (DateTime)dynConstraints[61] , (DateTime)dynConstraints[62] , (short)dynConstraints[63] , (bool)dynConstraints[64] , (int)dynConstraints[65] , (int)dynConstraints[66] );
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
          Object[] prmH00A82;
          prmH00A82 = new Object[] {
          new ParDef("AV93Boletowwds_1_carteiradecobrancaid",GXType.Int32,9,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV97Boletowwds_5_boletosnossonumero1",GXType.VarChar,50,0) ,
          new ParDef("lV97Boletowwds_5_boletosnossonumero1",GXType.VarChar,50,0) ,
          new ParDef("lV101Boletowwds_9_boletosnossonumero2",GXType.VarChar,50,0) ,
          new ParDef("lV101Boletowwds_9_boletosnossonumero2",GXType.VarChar,50,0) ,
          new ParDef("lV105Boletowwds_13_boletosnossonumero3",GXType.VarChar,50,0) ,
          new ParDef("lV105Boletowwds_13_boletosnossonumero3",GXType.VarChar,50,0) ,
          new ParDef("lV106Boletowwds_14_tfboletosnossonumero",GXType.VarChar,50,0) ,
          new ParDef("AV107Boletowwds_15_tfboletosnossonumero_sel",GXType.VarChar,50,0) ,
          new ParDef("lV108Boletowwds_16_tfboletosseunumero",GXType.VarChar,50,0) ,
          new ParDef("AV109Boletowwds_17_tfboletosseunumero_sel",GXType.VarChar,50,0) ,
          new ParDef("lV110Boletowwds_18_tfboletosnumero",GXType.VarChar,50,0) ,
          new ParDef("AV111Boletowwds_19_tfboletosnumero_sel",GXType.VarChar,50,0) ,
          new ParDef("AV113Boletowwds_21_tfboletosdataemissao",GXType.Date,8,0) ,
          new ParDef("AV114Boletowwds_22_tfboletosdataemissao_to",GXType.Date,8,0) ,
          new ParDef("AV115Boletowwds_23_tfboletosdatavencimento",GXType.Date,8,0) ,
          new ParDef("AV116Boletowwds_24_tfboletosdatavencimento_to",GXType.Date,8,0) ,
          new ParDef("AV117Boletowwds_25_tfboletosdataregistro",GXType.DateTime,8,5) ,
          new ParDef("AV118Boletowwds_26_tfboletosdataregistro_to",GXType.DateTime,8,5) ,
          new ParDef("AV119Boletowwds_27_tfboletosdatapagamento",GXType.Date,8,0) ,
          new ParDef("AV120Boletowwds_28_tfboletosdatapagamento_to",GXType.Date,8,0) ,
          new ParDef("AV121Boletowwds_29_tfboletosdatabaixa",GXType.Date,8,0) ,
          new ParDef("AV122Boletowwds_30_tfboletosdatabaixa_to",GXType.Date,8,0) ,
          new ParDef("AV123Boletowwds_31_tfboletosvalornominal",GXType.Number,18,2) ,
          new ParDef("AV124Boletowwds_32_tfboletosvalornominal_to",GXType.Number,18,2) ,
          new ParDef("AV125Boletowwds_33_tfboletosvalorpago",GXType.Number,18,2) ,
          new ParDef("AV126Boletowwds_34_tfboletosvalorpago_to",GXType.Number,18,2) ,
          new ParDef("AV127Boletowwds_35_tfboletosvalordesconto",GXType.Number,18,2) ,
          new ParDef("AV128Boletowwds_36_tfboletosvalordesconto_to",GXType.Number,18,2) ,
          new ParDef("AV129Boletowwds_37_tfboletosvalorjuros",GXType.Number,18,2) ,
          new ParDef("AV130Boletowwds_38_tfboletosvalorjuros_to",GXType.Number,18,2) ,
          new ParDef("AV131Boletowwds_39_tfboletosvalormulta",GXType.Number,18,2) ,
          new ParDef("AV132Boletowwds_40_tfboletosvalormulta_to",GXType.Number,18,2) ,
          new ParDef("lV133Boletowwds_41_tfboletossacadonome",GXType.VarChar,100,0) ,
          new ParDef("AV134Boletowwds_42_tfboletossacadonome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV135Boletowwds_43_tfboletossacadodocumento",GXType.VarChar,20,0) ,
          new ParDef("AV136Boletowwds_44_tfboletossacadodocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00A83;
          prmH00A83 = new Object[] {
          new ParDef("AV93Boletowwds_1_carteiradecobrancaid",GXType.Int32,9,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV94Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV97Boletowwds_5_boletosnossonumero1",GXType.VarChar,50,0) ,
          new ParDef("lV97Boletowwds_5_boletosnossonumero1",GXType.VarChar,50,0) ,
          new ParDef("lV101Boletowwds_9_boletosnossonumero2",GXType.VarChar,50,0) ,
          new ParDef("lV101Boletowwds_9_boletosnossonumero2",GXType.VarChar,50,0) ,
          new ParDef("lV105Boletowwds_13_boletosnossonumero3",GXType.VarChar,50,0) ,
          new ParDef("lV105Boletowwds_13_boletosnossonumero3",GXType.VarChar,50,0) ,
          new ParDef("lV106Boletowwds_14_tfboletosnossonumero",GXType.VarChar,50,0) ,
          new ParDef("AV107Boletowwds_15_tfboletosnossonumero_sel",GXType.VarChar,50,0) ,
          new ParDef("lV108Boletowwds_16_tfboletosseunumero",GXType.VarChar,50,0) ,
          new ParDef("AV109Boletowwds_17_tfboletosseunumero_sel",GXType.VarChar,50,0) ,
          new ParDef("lV110Boletowwds_18_tfboletosnumero",GXType.VarChar,50,0) ,
          new ParDef("AV111Boletowwds_19_tfboletosnumero_sel",GXType.VarChar,50,0) ,
          new ParDef("AV113Boletowwds_21_tfboletosdataemissao",GXType.Date,8,0) ,
          new ParDef("AV114Boletowwds_22_tfboletosdataemissao_to",GXType.Date,8,0) ,
          new ParDef("AV115Boletowwds_23_tfboletosdatavencimento",GXType.Date,8,0) ,
          new ParDef("AV116Boletowwds_24_tfboletosdatavencimento_to",GXType.Date,8,0) ,
          new ParDef("AV117Boletowwds_25_tfboletosdataregistro",GXType.DateTime,8,5) ,
          new ParDef("AV118Boletowwds_26_tfboletosdataregistro_to",GXType.DateTime,8,5) ,
          new ParDef("AV119Boletowwds_27_tfboletosdatapagamento",GXType.Date,8,0) ,
          new ParDef("AV120Boletowwds_28_tfboletosdatapagamento_to",GXType.Date,8,0) ,
          new ParDef("AV121Boletowwds_29_tfboletosdatabaixa",GXType.Date,8,0) ,
          new ParDef("AV122Boletowwds_30_tfboletosdatabaixa_to",GXType.Date,8,0) ,
          new ParDef("AV123Boletowwds_31_tfboletosvalornominal",GXType.Number,18,2) ,
          new ParDef("AV124Boletowwds_32_tfboletosvalornominal_to",GXType.Number,18,2) ,
          new ParDef("AV125Boletowwds_33_tfboletosvalorpago",GXType.Number,18,2) ,
          new ParDef("AV126Boletowwds_34_tfboletosvalorpago_to",GXType.Number,18,2) ,
          new ParDef("AV127Boletowwds_35_tfboletosvalordesconto",GXType.Number,18,2) ,
          new ParDef("AV128Boletowwds_36_tfboletosvalordesconto_to",GXType.Number,18,2) ,
          new ParDef("AV129Boletowwds_37_tfboletosvalorjuros",GXType.Number,18,2) ,
          new ParDef("AV130Boletowwds_38_tfboletosvalorjuros_to",GXType.Number,18,2) ,
          new ParDef("AV131Boletowwds_39_tfboletosvalormulta",GXType.Number,18,2) ,
          new ParDef("AV132Boletowwds_40_tfboletosvalormulta_to",GXType.Number,18,2) ,
          new ParDef("lV133Boletowwds_41_tfboletossacadonome",GXType.VarChar,100,0) ,
          new ParDef("AV134Boletowwds_42_tfboletossacadonome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV135Boletowwds_43_tfboletossacadodocumento",GXType.VarChar,20,0) ,
          new ParDef("AV136Boletowwds_44_tfboletossacadodocumento_sel",GXType.VarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00A82", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A82,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00A83", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A83,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[18])[0] = rslt.getGXDate(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[22])[0] = rslt.getGXDate(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[24])[0] = rslt.getGXDate(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((string[]) buf[32])[0] = rslt.getVarchar(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((string[]) buf[34])[0] = rslt.getVarchar(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((string[]) buf[36])[0] = rslt.getVarchar(19);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((int[]) buf[38])[0] = rslt.getInt(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((int[]) buf[40])[0] = rslt.getInt(21);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((int[]) buf[42])[0] = rslt.getInt(22);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
