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
   public class wpregistrartitulo : GXDataArea
   {
      public wpregistrartitulo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpregistrartitulo( IGxContext context )
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
         cmbavDynamicfiltersselector1 = new GXCombobox();
         cmbavDynamicfiltersoperator1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         chkavSelected = new GXCheckbox();
         cmbTituloPropostaTipo = new GXCombobox();
         chkTituloDeleted = new GXCheckbox();
         chkTituloArchived = new GXCheckbox();
         cmbTituloTipo = new GXCombobox();
         chkavSelectall = new GXCheckbox();
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
         nRC_GXsfl_116 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_116"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_116_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_116_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_116_idx = GetPar( "sGXsfl_116_idx");
         chkavSelected_Titleformat = (short)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
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
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV16DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV18TituloValor1 = NumberUtil.Val( GetPar( "TituloValor1"), ".");
         AV19ContaBancariaNumero1 = (long)(Math.Round(NumberUtil.Val( GetPar( "ContaBancariaNumero1"), "."), 18, MidpointRounding.ToEven));
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV23TituloValor2 = NumberUtil.Val( GetPar( "TituloValor2"), ".");
         AV24ContaBancariaNumero2 = (long)(Math.Round(NumberUtil.Val( GetPar( "ContaBancariaNumero2"), "."), 18, MidpointRounding.ToEven));
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV26DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV28TituloValor3 = NumberUtil.Val( GetPar( "TituloValor3"), ".");
         AV29ContaBancariaNumero3 = (long)(Math.Round(NumberUtil.Val( GetPar( "ContaBancariaNumero3"), "."), 18, MidpointRounding.ToEven));
         AV37ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV20DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV25DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV156Pgmname = GetPar( "Pgmname");
         AV150TituloIdJson = GetPar( "TituloIdJson");
         AV15FilterFullText = GetPar( "FilterFullText");
         AV154TFTituloCLienteRazaoSocial = GetPar( "TFTituloCLienteRazaoSocial");
         AV155TFTituloCLienteRazaoSocial_Sel = GetPar( "TFTituloCLienteRazaoSocial_Sel");
         AV143TFTituloPropostaDescricao = GetPar( "TFTituloPropostaDescricao");
         AV144TFTituloPropostaDescricao_Sel = GetPar( "TFTituloPropostaDescricao_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV121TFTituloPropostaTipo_Sels);
         AV44TFTituloValor = NumberUtil.Val( GetPar( "TFTituloValor"), ".");
         AV45TFTituloValor_To = NumberUtil.Val( GetPar( "TFTituloValor_To"), ".");
         AV46TFTituloDesconto = NumberUtil.Val( GetPar( "TFTituloDesconto"), ".");
         AV47TFTituloDesconto_To = NumberUtil.Val( GetPar( "TFTituloDesconto_To"), ".");
         AV59TFTituloCompetencia_F = GetPar( "TFTituloCompetencia_F");
         AV60TFTituloCompetencia_F_Sel = GetPar( "TFTituloCompetencia_F_Sel");
         AV61TFTituloProrrogacao = context.localUtil.ParseDateParm( GetPar( "TFTituloProrrogacao"));
         AV62TFTituloProrrogacao_To = context.localUtil.ParseDateParm( GetPar( "TFTituloProrrogacao_To"));
         AV78TFTituloJurosMora = NumberUtil.Val( GetPar( "TFTituloJurosMora"), ".");
         AV79TFTituloJurosMora_To = NumberUtil.Val( GetPar( "TFTituloJurosMora_To"), ".");
         AV141TFNotaFiscalNumero = GetPar( "TFNotaFiscalNumero");
         AV142TFNotaFiscalNumero_Sel = GetPar( "TFNotaFiscalNumero_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV31DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV30DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         chkavSelected_Titleformat = (short)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AV148i = (long)(Math.Round(NumberUtil.Val( GetPar( "i"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV149TituloIdCol);
         AV152TituloIdToFind = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloIdToFind"), "."), 18, MidpointRounding.ToEven));
         AV153SelectAll = StringUtil.StrToBool( GetPar( "SelectAll"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TituloValor1, AV19ContaBancariaNumero1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV24ContaBancariaNumero2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28TituloValor3, AV29ContaBancariaNumero3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV156Pgmname, AV150TituloIdJson, AV15FilterFullText, AV154TFTituloCLienteRazaoSocial, AV155TFTituloCLienteRazaoSocial_Sel, AV143TFTituloPropostaDescricao, AV144TFTituloPropostaDescricao_Sel, AV121TFTituloPropostaTipo_Sels, AV44TFTituloValor, AV45TFTituloValor_To, AV46TFTituloDesconto, AV47TFTituloDesconto_To, AV59TFTituloCompetencia_F, AV60TFTituloCompetencia_F_Sel, AV61TFTituloProrrogacao, AV62TFTituloProrrogacao_To, AV78TFTituloJurosMora, AV79TFTituloJurosMora_To, AV141TFNotaFiscalNumero, AV142TFNotaFiscalNumero_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV148i, AV149TituloIdCol, AV152TituloIdToFind, AV153SelectAll) ;
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
         PA9M2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9M2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpregistrartitulo") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV156Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV156Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV16DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vTITULOVALOR1", StringUtil.LTrim( StringUtil.NToC( AV18TituloValor1, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCONTABANCARIANUMERO1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ContaBancariaNumero1), 18, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV21DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vTITULOVALOR2", StringUtil.LTrim( StringUtil.NToC( AV23TituloValor2, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCONTABANCARIANUMERO2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24ContaBancariaNumero2), 18, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV26DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vTITULOVALOR3", StringUtil.LTrim( StringUtil.NToC( AV28TituloValor3, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCONTABANCARIANUMERO3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29ContaBancariaNumero3), 18, 0, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_116", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_116), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV35ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV35ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV134GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV135GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV136GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV132DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV132DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_TITULOPRORROGACAOAUXDATE", context.localUtil.DToC( AV63DDO_TituloProrrogacaoAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_TITULOPRORROGACAOAUXDATETO", context.localUtil.DToC( AV64DDO_TituloProrrogacaoAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV20DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV25DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV156Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV156Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTITULOIDJSON", AV150TituloIdJson);
         GxWebStd.gx_hidden_field( context, "vTFTITULOCLIENTERAZAOSOCIAL", AV154TFTituloCLienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "vTFTITULOCLIENTERAZAOSOCIAL_SEL", AV155TFTituloCLienteRazaoSocial_Sel);
         GxWebStd.gx_hidden_field( context, "vTFTITULOPROPOSTADESCRICAO", AV143TFTituloPropostaDescricao);
         GxWebStd.gx_hidden_field( context, "vTFTITULOPROPOSTADESCRICAO_SEL", AV144TFTituloPropostaDescricao_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFTITULOPROPOSTATIPO_SELS", AV121TFTituloPropostaTipo_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFTITULOPROPOSTATIPO_SELS", AV121TFTituloPropostaTipo_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFTITULOVALOR", StringUtil.LTrim( StringUtil.NToC( AV44TFTituloValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTITULOVALOR_TO", StringUtil.LTrim( StringUtil.NToC( AV45TFTituloValor_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTITULODESCONTO", StringUtil.LTrim( StringUtil.NToC( AV46TFTituloDesconto, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTITULODESCONTO_TO", StringUtil.LTrim( StringUtil.NToC( AV47TFTituloDesconto_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTITULOCOMPETENCIA_F", AV59TFTituloCompetencia_F);
         GxWebStd.gx_hidden_field( context, "vTFTITULOCOMPETENCIA_F_SEL", AV60TFTituloCompetencia_F_Sel);
         GxWebStd.gx_hidden_field( context, "vTFTITULOPRORROGACAO", context.localUtil.DToC( AV61TFTituloProrrogacao, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFTITULOPRORROGACAO_TO", context.localUtil.DToC( AV62TFTituloProrrogacao_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFTITULOJUROSMORA", StringUtil.LTrim( StringUtil.NToC( AV78TFTituloJurosMora, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTITULOJUROSMORA_TO", StringUtil.LTrim( StringUtil.NToC( AV79TFTituloJurosMora_To, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFNOTAFISCALNUMERO", AV141TFNotaFiscalNumero);
         GxWebStd.gx_hidden_field( context, "vTFNOTAFISCALNUMERO_SEL", AV142TFNotaFiscalNumero_Sel);
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
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV31DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV30DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, "vI", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV148i), 10, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTITULOIDCOL", AV149TituloIdCol);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTITULOIDCOL", AV149TituloIdCol);
         }
         GxWebStd.gx_hidden_field( context, "vTITULOIDTOFIND", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV152TituloIdToFind), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTITULOPROPOSTATIPO_SELSJSON", AV120TFTituloPropostaTipo_SelsJson);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSELECTEDROWS", AV146SelectedRows);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSELECTEDROWS", AV146SelectedRows);
         }
         GxWebStd.gx_hidden_field( context, "CONTABANCARIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vSELECTED_Titleformat", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavSelected_Titleformat), 4, 0, ".", "")));
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
            WE9M2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9M2( ) ;
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
         return formatLink("wpregistrartitulo")  ;
      }

      public override string GetPgmname( )
      {
         return "WPRegistrarTitulo" ;
      }

      public override string GetPgmdesc( )
      {
         return " Titulo" ;
      }

      protected void WB9M0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
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
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(116), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegistrarTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "Button WWPBtnNeedMultiRowSelection";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnregistrar_titulos_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(116), 3, 0)+","+"null"+");", "Registrar", bttBtnregistrar_titulos_Jsonclick, 5, "Registrar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOREGISTRAR_TITULOS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegistrarTitulo.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV35ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WPRegistrarTitulo.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_WPRegistrarTitulo.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_45_9M2( true) ;
         }
         else
         {
            wb_table1_45_9M2( false) ;
         }
         return  ;
      }

      protected void wb_table1_45_9M2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV21DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "", true, 0, "HLP_WPRegistrarTitulo.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_70_9M2( true) ;
         }
         else
         {
            wb_table2_70_9M2( false) ;
         }
         return  ;
      }

      protected void wb_table2_70_9M2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV26DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "", true, 0, "HLP_WPRegistrarTitulo.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_95_9M2( true) ;
         }
         else
         {
            wb_table3_95_9M2( false) ;
         }
         return  ;
      }

      protected void wb_table3_95_9M2e( bool wbgen )
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
            StartGridControl116( ) ;
         }
         if ( wbEnd == 116 )
         {
            wbEnd = 0;
            nRC_GXsfl_116 = (int)(nGXsfl_116_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV134GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV135GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV136GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_WPRegistrarTitulo.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV132DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 160,'',false,'" + sGXsfl_116_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSelectall_Internalname, StringUtil.BoolToStr( AV153SelectAll), "", "", chkavSelectall.Visible, 1, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,160);\"");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_tituloprorrogacaoauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 163,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_tituloprorrogacaoauxdatetext_Internalname, AV65DDO_TituloProrrogacaoAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV65DDO_TituloProrrogacaoAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,163);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_tituloprorrogacaoauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPRegistrarTitulo.htm");
            /* User Defined Control */
            ucTftituloprorrogacao_rangepicker.SetProperty("Start Date", AV63DDO_TituloProrrogacaoAuxDate);
            ucTftituloprorrogacao_rangepicker.SetProperty("End Date", AV64DDO_TituloProrrogacaoAuxDateTo);
            ucTftituloprorrogacao_rangepicker.Render(context, "wwp.daterangepicker", Tftituloprorrogacao_rangepicker_Internalname, "TFTITULOPRORROGACAO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 116 )
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

      protected void START9M2( )
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
         STRUP9M0( ) ;
      }

      protected void WS9M2( )
      {
         START9M2( ) ;
         EVT9M2( ) ;
      }

      protected void EVT9M2( )
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
                              E119M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E129M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E139M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E149M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E159M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E169M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E179M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOREGISTRAR_TITULOS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoRegistrar_titulos' */
                              E189M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E199M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSELECTALL.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E209M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E219M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E229M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E239M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E249M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E259M2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VSELECTED.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VSELECTED.CLICK") == 0 ) )
                           {
                              nGXsfl_116_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
                              SubsflControlProps_1162( ) ;
                              AV145Selected = StringUtil.StrToBool( cgiGet( chkavSelected_Internalname));
                              AssignAttri("", false, chkavSelected_Internalname, AV145Selected);
                              A261TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n261TituloId = false;
                              A420TituloClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n420TituloClienteId = false;
                              A972TituloCLienteRazaoSocial = StringUtil.Upper( cgiGet( edtTituloCLienteRazaoSocial_Internalname));
                              n972TituloCLienteRazaoSocial = false;
                              A971TituloPropostaDescricao = cgiGet( edtTituloPropostaDescricao_Internalname);
                              n971TituloPropostaDescricao = false;
                              cmbTituloPropostaTipo.Name = cmbTituloPropostaTipo_Internalname;
                              cmbTituloPropostaTipo.CurrentValue = cgiGet( cmbTituloPropostaTipo_Internalname);
                              A648TituloPropostaTipo = cgiGet( cmbTituloPropostaTipo_Internalname);
                              n648TituloPropostaTipo = false;
                              A262TituloValor = context.localUtil.CToN( cgiGet( edtTituloValor_Internalname), ",", ".");
                              n262TituloValor = false;
                              A276TituloDesconto = context.localUtil.CToN( cgiGet( edtTituloDesconto_Internalname), ",", ".");
                              n276TituloDesconto = false;
                              A284TituloDeleted = StringUtil.StrToBool( cgiGet( chkTituloDeleted_Internalname));
                              n284TituloDeleted = false;
                              A314TituloArchived = StringUtil.StrToBool( cgiGet( chkTituloArchived_Internalname));
                              n314TituloArchived = false;
                              A263TituloVencimento = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTituloVencimento_Internalname), 0));
                              n263TituloVencimento = false;
                              A287TituloCompetenciaMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloCompetenciaMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n287TituloCompetenciaMes = false;
                              A286TituloCompetenciaAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloCompetenciaAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n286TituloCompetenciaAno = false;
                              A295TituloCompetencia_F = cgiGet( edtTituloCompetencia_F_Internalname);
                              A264TituloProrrogacao = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTituloProrrogacao_Internalname), 0));
                              n264TituloProrrogacao = false;
                              A265TituloCEP = cgiGet( edtTituloCEP_Internalname);
                              n265TituloCEP = false;
                              A266TituloLogradouro = cgiGet( edtTituloLogradouro_Internalname);
                              n266TituloLogradouro = false;
                              A294TituloNumeroEndereco = cgiGet( edtTituloNumeroEndereco_Internalname);
                              n294TituloNumeroEndereco = false;
                              A267TituloComplemento = cgiGet( edtTituloComplemento_Internalname);
                              n267TituloComplemento = false;
                              A268TituloBairro = cgiGet( edtTituloBairro_Internalname);
                              n268TituloBairro = false;
                              A269TituloMunicipio = cgiGet( edtTituloMunicipio_Internalname);
                              n269TituloMunicipio = false;
                              A498TituloJurosMora = context.localUtil.CToN( cgiGet( edtTituloJurosMora_Internalname), ",", ".");
                              n498TituloJurosMora = false;
                              cmbTituloTipo.Name = cmbTituloTipo_Internalname;
                              cmbTituloTipo.CurrentValue = cgiGet( cmbTituloTipo_Internalname);
                              A283TituloTipo = cgiGet( cmbTituloTipo_Internalname);
                              n283TituloTipo = false;
                              A419TituloPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloPropostaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n419TituloPropostaId = false;
                              A501PropostaTaxaAdministrativa = context.localUtil.CToN( cgiGet( edtPropostaTaxaAdministrativa_Internalname), ",", ".");
                              n501PropostaTaxaAdministrativa = false;
                              A422ContaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n422ContaId = false;
                              A500TituloCriacao = context.localUtil.CToT( cgiGet( edtTituloCriacao_Internalname), 0);
                              n500TituloCriacao = false;
                              A426CategoriaTituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCategoriaTituloId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n426CategoriaTituloId = false;
                              A516TituloDataCredito_F = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTituloDataCredito_F_Internalname), 0));
                              n516TituloDataCredito_F = false;
                              A273TituloTotalMovimento_F = context.localUtil.CToN( cgiGet( edtTituloTotalMovimento_F_Internalname), ",", ".");
                              A301TituloTotalMultaJuros_F = context.localUtil.CToN( cgiGet( edtTituloTotalMultaJuros_F_Internalname), ",", ".");
                              n301TituloTotalMultaJuros_F = false;
                              A275TituloSaldo_F = context.localUtil.CToN( cgiGet( edtTituloSaldo_F_Internalname), ",", ".");
                              A282TituloStatus_F = cgiGet( edtTituloStatus_F_Internalname);
                              A890NotaFiscalParcelamentoID = StringUtil.StrToGuid( cgiGet( edtNotaFiscalParcelamentoID_Internalname));
                              n890NotaFiscalParcelamentoID = false;
                              A799NotaFiscalNumero = cgiGet( edtNotaFiscalNumero_Internalname);
                              n799NotaFiscalNumero = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E269M2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E279M2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E289M2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VSELECTED.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E299M2 ();
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
                                       /* Set Refresh If Titulovalor1 Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vTITULOVALOR1"), ",", ".") != AV18TituloValor1 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contabancarianumero1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCONTABANCARIANUMERO1"), ",", ".") != Convert.ToDecimal( AV19ContaBancariaNumero1 )) )
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
                                       /* Set Refresh If Contabancarianumero2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCONTABANCARIANUMERO2"), ",", ".") != Convert.ToDecimal( AV24ContaBancariaNumero2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV26DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV27DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Titulovalor3 Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vTITULOVALOR3"), ",", ".") != AV28TituloValor3 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contabancarianumero3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCONTABANCARIANUMERO3"), ",", ".") != Convert.ToDecimal( AV29ContaBancariaNumero3 )) )
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

      protected void WE9M2( )
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

      protected void PA9M2( )
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
         SubsflControlProps_1162( ) ;
         while ( nGXsfl_116_idx <= nRC_GXsfl_116 )
         {
            sendrow_1162( ) ;
            nGXsfl_116_idx = ((subGrid_Islastpage==1)&&(nGXsfl_116_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_116_idx+1);
            sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
            SubsflControlProps_1162( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       string AV16DynamicFiltersSelector1 ,
                                       short AV17DynamicFiltersOperator1 ,
                                       decimal AV18TituloValor1 ,
                                       long AV19ContaBancariaNumero1 ,
                                       string AV21DynamicFiltersSelector2 ,
                                       short AV22DynamicFiltersOperator2 ,
                                       decimal AV23TituloValor2 ,
                                       long AV24ContaBancariaNumero2 ,
                                       string AV26DynamicFiltersSelector3 ,
                                       short AV27DynamicFiltersOperator3 ,
                                       decimal AV28TituloValor3 ,
                                       long AV29ContaBancariaNumero3 ,
                                       short AV37ManageFiltersExecutionStep ,
                                       bool AV20DynamicFiltersEnabled2 ,
                                       bool AV25DynamicFiltersEnabled3 ,
                                       string AV156Pgmname ,
                                       string AV150TituloIdJson ,
                                       string AV15FilterFullText ,
                                       string AV154TFTituloCLienteRazaoSocial ,
                                       string AV155TFTituloCLienteRazaoSocial_Sel ,
                                       string AV143TFTituloPropostaDescricao ,
                                       string AV144TFTituloPropostaDescricao_Sel ,
                                       GxSimpleCollection<string> AV121TFTituloPropostaTipo_Sels ,
                                       decimal AV44TFTituloValor ,
                                       decimal AV45TFTituloValor_To ,
                                       decimal AV46TFTituloDesconto ,
                                       decimal AV47TFTituloDesconto_To ,
                                       string AV59TFTituloCompetencia_F ,
                                       string AV60TFTituloCompetencia_F_Sel ,
                                       DateTime AV61TFTituloProrrogacao ,
                                       DateTime AV62TFTituloProrrogacao_To ,
                                       decimal AV78TFTituloJurosMora ,
                                       decimal AV79TFTituloJurosMora_To ,
                                       string AV141TFNotaFiscalNumero ,
                                       string AV142TFNotaFiscalNumero_Sel ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV31DynamicFiltersIgnoreFirst ,
                                       bool AV30DynamicFiltersRemoving ,
                                       long AV148i ,
                                       GxSimpleCollection<int> AV149TituloIdCol ,
                                       int AV152TituloIdToFind ,
                                       bool AV153SelectAll )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF9M2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A261TituloId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TITULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A420TituloClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TITULOCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A420TituloClienteId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOPROPOSTATIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A648TituloPropostaTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "TITULOPROPOSTATIPO", A648TituloPropostaTipo);
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOVALOR", GetSecureSignedToken( "", context.localUtil.Format( A262TituloValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "TITULOVALOR", StringUtil.LTrim( StringUtil.NToC( A262TituloValor, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULODESCONTO", GetSecureSignedToken( "", context.localUtil.Format( A276TituloDesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "TITULODESCONTO", StringUtil.LTrim( StringUtil.NToC( A276TituloDesconto, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULODELETED", GetSecureSignedToken( "", A284TituloDeleted, context));
         GxWebStd.gx_hidden_field( context, "TITULODELETED", StringUtil.BoolToStr( A284TituloDeleted));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOARCHIVED", GetSecureSignedToken( "", A314TituloArchived, context));
         GxWebStd.gx_hidden_field( context, "TITULOARCHIVED", StringUtil.BoolToStr( A314TituloArchived));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOVENCIMENTO", GetSecureSignedToken( "", A263TituloVencimento, context));
         GxWebStd.gx_hidden_field( context, "TITULOVENCIMENTO", context.localUtil.Format(A263TituloVencimento, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOCOMPETENCIAMES", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A287TituloCompetenciaMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TITULOCOMPETENCIAMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(A287TituloCompetenciaMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOCOMPETENCIAANO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A286TituloCompetenciaAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TITULOCOMPETENCIAANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A286TituloCompetenciaAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOCOMPETENCIA_F", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A295TituloCompetencia_F, "")), context));
         GxWebStd.gx_hidden_field( context, "TITULOCOMPETENCIA_F", A295TituloCompetencia_F);
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOPRORROGACAO", GetSecureSignedToken( "", A264TituloProrrogacao, context));
         GxWebStd.gx_hidden_field( context, "TITULOPRORROGACAO", context.localUtil.Format(A264TituloProrrogacao, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOCEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A265TituloCEP, "")), context));
         GxWebStd.gx_hidden_field( context, "TITULOCEP", A265TituloCEP);
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOLOGRADOURO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A266TituloLogradouro, "")), context));
         GxWebStd.gx_hidden_field( context, "TITULOLOGRADOURO", A266TituloLogradouro);
         GxWebStd.gx_hidden_field( context, "gxhash_TITULONUMEROENDERECO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A294TituloNumeroEndereco, "")), context));
         GxWebStd.gx_hidden_field( context, "TITULONUMEROENDERECO", A294TituloNumeroEndereco);
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOCOMPLEMENTO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A267TituloComplemento, "")), context));
         GxWebStd.gx_hidden_field( context, "TITULOCOMPLEMENTO", A267TituloComplemento);
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOBAIRRO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A268TituloBairro, "")), context));
         GxWebStd.gx_hidden_field( context, "TITULOBAIRRO", A268TituloBairro);
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOMUNICIPIO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A269TituloMunicipio, "")), context));
         GxWebStd.gx_hidden_field( context, "TITULOMUNICIPIO", A269TituloMunicipio);
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOJUROSMORA", GetSecureSignedToken( "", context.localUtil.Format( A498TituloJurosMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
         GxWebStd.gx_hidden_field( context, "TITULOJUROSMORA", StringUtil.LTrim( StringUtil.NToC( A498TituloJurosMora, 16, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOTIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A283TituloTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "TITULOTIPO", A283TituloTipo);
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A419TituloPropostaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TITULOPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_CONTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A422ContaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CONTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOCRIACAO", GetSecureSignedToken( "", context.localUtil.Format( A500TituloCriacao, "99/99/99 99:99"), context));
         GxWebStd.gx_hidden_field( context, "TITULOCRIACAO", context.localUtil.TToC( A500TituloCriacao, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "gxhash_CATEGORIATITULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A426CategoriaTituloId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CATEGORIATITULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOSALDO_F", GetSecureSignedToken( "", context.localUtil.Format( A275TituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "TITULOSALDO_F", StringUtil.LTrim( StringUtil.NToC( A275TituloSaldo_F, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOSTATUS_F", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A282TituloStatus_F, "")), context));
         GxWebStd.gx_hidden_field( context, "TITULOSTATUS_F", A282TituloStatus_F);
         GxWebStd.gx_hidden_field( context, "gxhash_NOTAFISCALPARCELAMENTOID", GetSecureSignedToken( "", A890NotaFiscalParcelamentoID, context));
         GxWebStd.gx_hidden_field( context, "NOTAFISCALPARCELAMENTOID", A890NotaFiscalParcelamentoID.ToString());
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
            AV26DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV26DynamicFiltersSelector3);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
         AV153SelectAll = StringUtil.StrToBool( StringUtil.BoolToStr( AV153SelectAll));
         AssignAttri("", false, "AV153SelectAll", AV153SelectAll);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF9M2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV156Pgmname = "WPRegistrarTitulo";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV157Wpregistrartitulods_1_filterfulltext = AV15FilterFullText;
         AV158Wpregistrartitulods_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV159Wpregistrartitulods_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV160Wpregistrartitulods_4_titulovalor1 = AV18TituloValor1;
         AV161Wpregistrartitulods_5_contabancarianumero1 = AV19ContaBancariaNumero1;
         AV162Wpregistrartitulods_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV163Wpregistrartitulods_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV164Wpregistrartitulods_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV165Wpregistrartitulods_9_titulovalor2 = AV23TituloValor2;
         AV166Wpregistrartitulods_10_contabancarianumero2 = AV24ContaBancariaNumero2;
         AV167Wpregistrartitulods_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV168Wpregistrartitulods_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV169Wpregistrartitulods_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV170Wpregistrartitulods_14_titulovalor3 = AV28TituloValor3;
         AV171Wpregistrartitulods_15_contabancarianumero3 = AV29ContaBancariaNumero3;
         AV172Wpregistrartitulods_16_tftituloclienterazaosocial = AV154TFTituloCLienteRazaoSocial;
         AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel = AV155TFTituloCLienteRazaoSocial_Sel;
         AV174Wpregistrartitulods_18_tftitulopropostadescricao = AV143TFTituloPropostaDescricao;
         AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel = AV144TFTituloPropostaDescricao_Sel;
         AV176Wpregistrartitulods_20_tftitulopropostatipo_sels = AV121TFTituloPropostaTipo_Sels;
         AV177Wpregistrartitulods_21_tftitulovalor = AV44TFTituloValor;
         AV178Wpregistrartitulods_22_tftitulovalor_to = AV45TFTituloValor_To;
         AV179Wpregistrartitulods_23_tftitulodesconto = AV46TFTituloDesconto;
         AV180Wpregistrartitulods_24_tftitulodesconto_to = AV47TFTituloDesconto_To;
         AV181Wpregistrartitulods_25_tftitulocompetencia_f = AV59TFTituloCompetencia_F;
         AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel = AV60TFTituloCompetencia_F_Sel;
         AV183Wpregistrartitulods_27_tftituloprorrogacao = AV61TFTituloProrrogacao;
         AV184Wpregistrartitulods_28_tftituloprorrogacao_to = AV62TFTituloProrrogacao_To;
         AV185Wpregistrartitulods_29_tftitulojurosmora = AV78TFTituloJurosMora;
         AV186Wpregistrartitulods_30_tftitulojurosmora_to = AV79TFTituloJurosMora_To;
         AV187Wpregistrartitulods_31_tfnotafiscalnumero = AV141TFNotaFiscalNumero;
         AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel = AV142TFNotaFiscalNumero_Sel;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A648TituloPropostaTipo ,
                                              AV176Wpregistrartitulods_20_tftitulopropostatipo_sels ,
                                              AV158Wpregistrartitulods_2_dynamicfiltersselector1 ,
                                              AV159Wpregistrartitulods_3_dynamicfiltersoperator1 ,
                                              AV160Wpregistrartitulods_4_titulovalor1 ,
                                              AV161Wpregistrartitulods_5_contabancarianumero1 ,
                                              AV162Wpregistrartitulods_6_dynamicfiltersenabled2 ,
                                              AV163Wpregistrartitulods_7_dynamicfiltersselector2 ,
                                              AV164Wpregistrartitulods_8_dynamicfiltersoperator2 ,
                                              AV165Wpregistrartitulods_9_titulovalor2 ,
                                              AV166Wpregistrartitulods_10_contabancarianumero2 ,
                                              AV167Wpregistrartitulods_11_dynamicfiltersenabled3 ,
                                              AV168Wpregistrartitulods_12_dynamicfiltersselector3 ,
                                              AV169Wpregistrartitulods_13_dynamicfiltersoperator3 ,
                                              AV170Wpregistrartitulods_14_titulovalor3 ,
                                              AV171Wpregistrartitulods_15_contabancarianumero3 ,
                                              AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel ,
                                              AV172Wpregistrartitulods_16_tftituloclienterazaosocial ,
                                              AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel ,
                                              AV174Wpregistrartitulods_18_tftitulopropostadescricao ,
                                              AV176Wpregistrartitulods_20_tftitulopropostatipo_sels.Count ,
                                              AV177Wpregistrartitulods_21_tftitulovalor ,
                                              AV178Wpregistrartitulods_22_tftitulovalor_to ,
                                              AV179Wpregistrartitulods_23_tftitulodesconto ,
                                              AV180Wpregistrartitulods_24_tftitulodesconto_to ,
                                              AV183Wpregistrartitulods_27_tftituloprorrogacao ,
                                              AV184Wpregistrartitulods_28_tftituloprorrogacao_to ,
                                              AV185Wpregistrartitulods_29_tftitulojurosmora ,
                                              AV186Wpregistrartitulods_30_tftitulojurosmora_to ,
                                              AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel ,
                                              AV187Wpregistrartitulods_31_tfnotafiscalnumero ,
                                              A262TituloValor ,
                                              A952ContaBancariaNumero ,
                                              A972TituloCLienteRazaoSocial ,
                                              A971TituloPropostaDescricao ,
                                              A276TituloDesconto ,
                                              A264TituloProrrogacao ,
                                              A498TituloJurosMora ,
                                              A799NotaFiscalNumero ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              AV157Wpregistrartitulods_1_filterfulltext ,
                                              A295TituloCompetencia_F ,
                                              AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel ,
                                              AV181Wpregistrartitulods_25_tftitulocompetencia_f ,
                                              A951ContaBancariaId ,
                                              A284TituloDeleted ,
                                              A314TituloArchived ,
                                              A283TituloTipo ,
                                              A275TituloSaldo_F } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL
                                              }
         });
         lV172Wpregistrartitulods_16_tftituloclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV172Wpregistrartitulods_16_tftituloclienterazaosocial), "%", "");
         lV174Wpregistrartitulods_18_tftitulopropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV174Wpregistrartitulods_18_tftitulopropostadescricao), "%", "");
         lV187Wpregistrartitulods_31_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV187Wpregistrartitulods_31_tfnotafiscalnumero), "%", "");
         /* Using cursor H009M5 */
         pr_default.execute(0, new Object[] {AV160Wpregistrartitulods_4_titulovalor1, AV160Wpregistrartitulods_4_titulovalor1, AV160Wpregistrartitulods_4_titulovalor1, AV161Wpregistrartitulods_5_contabancarianumero1, AV161Wpregistrartitulods_5_contabancarianumero1, AV161Wpregistrartitulods_5_contabancarianumero1, AV165Wpregistrartitulods_9_titulovalor2, AV165Wpregistrartitulods_9_titulovalor2, AV165Wpregistrartitulods_9_titulovalor2, AV166Wpregistrartitulods_10_contabancarianumero2, AV166Wpregistrartitulods_10_contabancarianumero2, AV166Wpregistrartitulods_10_contabancarianumero2, AV170Wpregistrartitulods_14_titulovalor3, AV170Wpregistrartitulods_14_titulovalor3, AV170Wpregistrartitulods_14_titulovalor3, AV171Wpregistrartitulods_15_contabancarianumero3, AV171Wpregistrartitulods_15_contabancarianumero3, AV171Wpregistrartitulods_15_contabancarianumero3, lV172Wpregistrartitulods_16_tftituloclienterazaosocial, AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel, lV174Wpregistrartitulods_18_tftitulopropostadescricao, AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel, AV177Wpregistrartitulods_21_tftitulovalor, AV178Wpregistrartitulods_22_tftitulovalor_to, AV179Wpregistrartitulods_23_tftitulodesconto, AV180Wpregistrartitulods_24_tftitulodesconto_to, AV183Wpregistrartitulods_27_tftituloprorrogacao, AV184Wpregistrartitulods_28_tftituloprorrogacao_to, AV185Wpregistrartitulods_29_tftitulojurosmora, AV186Wpregistrartitulods_30_tftitulojurosmora_to, lV187Wpregistrartitulods_31_tfnotafiscalnumero, AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A794NotaFiscalId = H009M5_A794NotaFiscalId[0];
            n794NotaFiscalId = H009M5_n794NotaFiscalId[0];
            A951ContaBancariaId = H009M5_A951ContaBancariaId[0];
            n951ContaBancariaId = H009M5_n951ContaBancariaId[0];
            A952ContaBancariaNumero = H009M5_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = H009M5_n952ContaBancariaNumero[0];
            A799NotaFiscalNumero = H009M5_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = H009M5_n799NotaFiscalNumero[0];
            A890NotaFiscalParcelamentoID = H009M5_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = H009M5_n890NotaFiscalParcelamentoID[0];
            A426CategoriaTituloId = H009M5_A426CategoriaTituloId[0];
            n426CategoriaTituloId = H009M5_n426CategoriaTituloId[0];
            A500TituloCriacao = H009M5_A500TituloCriacao[0];
            n500TituloCriacao = H009M5_n500TituloCriacao[0];
            A422ContaId = H009M5_A422ContaId[0];
            n422ContaId = H009M5_n422ContaId[0];
            A501PropostaTaxaAdministrativa = H009M5_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = H009M5_n501PropostaTaxaAdministrativa[0];
            A419TituloPropostaId = H009M5_A419TituloPropostaId[0];
            n419TituloPropostaId = H009M5_n419TituloPropostaId[0];
            A283TituloTipo = H009M5_A283TituloTipo[0];
            n283TituloTipo = H009M5_n283TituloTipo[0];
            A498TituloJurosMora = H009M5_A498TituloJurosMora[0];
            n498TituloJurosMora = H009M5_n498TituloJurosMora[0];
            A269TituloMunicipio = H009M5_A269TituloMunicipio[0];
            n269TituloMunicipio = H009M5_n269TituloMunicipio[0];
            A268TituloBairro = H009M5_A268TituloBairro[0];
            n268TituloBairro = H009M5_n268TituloBairro[0];
            A267TituloComplemento = H009M5_A267TituloComplemento[0];
            n267TituloComplemento = H009M5_n267TituloComplemento[0];
            A294TituloNumeroEndereco = H009M5_A294TituloNumeroEndereco[0];
            n294TituloNumeroEndereco = H009M5_n294TituloNumeroEndereco[0];
            A266TituloLogradouro = H009M5_A266TituloLogradouro[0];
            n266TituloLogradouro = H009M5_n266TituloLogradouro[0];
            A265TituloCEP = H009M5_A265TituloCEP[0];
            n265TituloCEP = H009M5_n265TituloCEP[0];
            A264TituloProrrogacao = H009M5_A264TituloProrrogacao[0];
            n264TituloProrrogacao = H009M5_n264TituloProrrogacao[0];
            A263TituloVencimento = H009M5_A263TituloVencimento[0];
            n263TituloVencimento = H009M5_n263TituloVencimento[0];
            A314TituloArchived = H009M5_A314TituloArchived[0];
            n314TituloArchived = H009M5_n314TituloArchived[0];
            A284TituloDeleted = H009M5_A284TituloDeleted[0];
            n284TituloDeleted = H009M5_n284TituloDeleted[0];
            A648TituloPropostaTipo = H009M5_A648TituloPropostaTipo[0];
            n648TituloPropostaTipo = H009M5_n648TituloPropostaTipo[0];
            A971TituloPropostaDescricao = H009M5_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = H009M5_n971TituloPropostaDescricao[0];
            A972TituloCLienteRazaoSocial = H009M5_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = H009M5_n972TituloCLienteRazaoSocial[0];
            A420TituloClienteId = H009M5_A420TituloClienteId[0];
            n420TituloClienteId = H009M5_n420TituloClienteId[0];
            A261TituloId = H009M5_A261TituloId[0];
            n261TituloId = H009M5_n261TituloId[0];
            A276TituloDesconto = H009M5_A276TituloDesconto[0];
            n276TituloDesconto = H009M5_n276TituloDesconto[0];
            A273TituloTotalMovimento_F = H009M5_A273TituloTotalMovimento_F[0];
            A301TituloTotalMultaJuros_F = H009M5_A301TituloTotalMultaJuros_F[0];
            n301TituloTotalMultaJuros_F = H009M5_n301TituloTotalMultaJuros_F[0];
            A516TituloDataCredito_F = H009M5_A516TituloDataCredito_F[0];
            n516TituloDataCredito_F = H009M5_n516TituloDataCredito_F[0];
            A286TituloCompetenciaAno = H009M5_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = H009M5_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = H009M5_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = H009M5_n287TituloCompetenciaMes[0];
            A262TituloValor = H009M5_A262TituloValor[0];
            n262TituloValor = H009M5_n262TituloValor[0];
            A275TituloSaldo_F = H009M5_A275TituloSaldo_F[0];
            A952ContaBancariaNumero = H009M5_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = H009M5_n952ContaBancariaNumero[0];
            A794NotaFiscalId = H009M5_A794NotaFiscalId[0];
            n794NotaFiscalId = H009M5_n794NotaFiscalId[0];
            A799NotaFiscalNumero = H009M5_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = H009M5_n799NotaFiscalNumero[0];
            A501PropostaTaxaAdministrativa = H009M5_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = H009M5_n501PropostaTaxaAdministrativa[0];
            A971TituloPropostaDescricao = H009M5_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = H009M5_n971TituloPropostaDescricao[0];
            A972TituloCLienteRazaoSocial = H009M5_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = H009M5_n972TituloCLienteRazaoSocial[0];
            A273TituloTotalMovimento_F = H009M5_A273TituloTotalMovimento_F[0];
            A301TituloTotalMultaJuros_F = H009M5_A301TituloTotalMultaJuros_F[0];
            n301TituloTotalMultaJuros_F = H009M5_n301TituloTotalMultaJuros_F[0];
            A516TituloDataCredito_F = H009M5_A516TituloDataCredito_F[0];
            n516TituloDataCredito_F = H009M5_n516TituloDataCredito_F[0];
            A282TituloStatus_F = ((Convert.ToDecimal(0)==A275TituloSaldo_F) ? "Liquidado" : ((A275TituloSaldo_F==A262TituloValor) ? "Aberto" : "Baixado parcialmente"));
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV157Wpregistrartitulods_1_filterfulltext)) || ( ( StringUtil.Like( A972TituloCLienteRazaoSocial , StringUtil.PadR( "%" + AV157Wpregistrartitulods_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( A971TituloPropostaDescricao , StringUtil.PadR( "%" + AV157Wpregistrartitulods_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( "iof" , StringUtil.PadR( "%" + StringUtil.Lower( AV157Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "IOF") == 0 ) ) || ( StringUtil.Like( "taxa" , StringUtil.PadR( "%" + StringUtil.Lower( AV157Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "TAXA") == 0 ) ) || ( StringUtil.Like( "reembolso" , StringUtil.PadR( "%" + StringUtil.Lower( AV157Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "REEMBOLSO") == 0 ) ) || ( StringUtil.Like( "comum" , StringUtil.PadR( "%" + StringUtil.Lower( AV157Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "COMUM") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV157Wpregistrartitulods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV157Wpregistrartitulods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV157Wpregistrartitulods_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A498TituloJurosMora, 16, 4) , StringUtil.PadR( "%" + AV157Wpregistrartitulods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A799NotaFiscalNumero , StringUtil.PadR( "%" + AV157Wpregistrartitulods_1_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV181Wpregistrartitulods_25_tftitulocompetencia_f)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV181Wpregistrartitulods_25_tftitulocompetencia_f , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel)) && ! ( StringUtil.StrCmp(AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
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

      protected void RF9M2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 116;
         /* Execute user event: Refresh */
         E279M2 ();
         nGXsfl_116_idx = 1;
         sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
         SubsflControlProps_1162( ) ;
         bGXsfl_116_Refreshing = true;
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
            SubsflControlProps_1162( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A648TituloPropostaTipo ,
                                                 AV176Wpregistrartitulods_20_tftitulopropostatipo_sels ,
                                                 AV158Wpregistrartitulods_2_dynamicfiltersselector1 ,
                                                 AV159Wpregistrartitulods_3_dynamicfiltersoperator1 ,
                                                 AV160Wpregistrartitulods_4_titulovalor1 ,
                                                 AV161Wpregistrartitulods_5_contabancarianumero1 ,
                                                 AV162Wpregistrartitulods_6_dynamicfiltersenabled2 ,
                                                 AV163Wpregistrartitulods_7_dynamicfiltersselector2 ,
                                                 AV164Wpregistrartitulods_8_dynamicfiltersoperator2 ,
                                                 AV165Wpregistrartitulods_9_titulovalor2 ,
                                                 AV166Wpregistrartitulods_10_contabancarianumero2 ,
                                                 AV167Wpregistrartitulods_11_dynamicfiltersenabled3 ,
                                                 AV168Wpregistrartitulods_12_dynamicfiltersselector3 ,
                                                 AV169Wpregistrartitulods_13_dynamicfiltersoperator3 ,
                                                 AV170Wpregistrartitulods_14_titulovalor3 ,
                                                 AV171Wpregistrartitulods_15_contabancarianumero3 ,
                                                 AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel ,
                                                 AV172Wpregistrartitulods_16_tftituloclienterazaosocial ,
                                                 AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel ,
                                                 AV174Wpregistrartitulods_18_tftitulopropostadescricao ,
                                                 AV176Wpregistrartitulods_20_tftitulopropostatipo_sels.Count ,
                                                 AV177Wpregistrartitulods_21_tftitulovalor ,
                                                 AV178Wpregistrartitulods_22_tftitulovalor_to ,
                                                 AV179Wpregistrartitulods_23_tftitulodesconto ,
                                                 AV180Wpregistrartitulods_24_tftitulodesconto_to ,
                                                 AV183Wpregistrartitulods_27_tftituloprorrogacao ,
                                                 AV184Wpregistrartitulods_28_tftituloprorrogacao_to ,
                                                 AV185Wpregistrartitulods_29_tftitulojurosmora ,
                                                 AV186Wpregistrartitulods_30_tftitulojurosmora_to ,
                                                 AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel ,
                                                 AV187Wpregistrartitulods_31_tfnotafiscalnumero ,
                                                 A262TituloValor ,
                                                 A952ContaBancariaNumero ,
                                                 A972TituloCLienteRazaoSocial ,
                                                 A971TituloPropostaDescricao ,
                                                 A276TituloDesconto ,
                                                 A264TituloProrrogacao ,
                                                 A498TituloJurosMora ,
                                                 A799NotaFiscalNumero ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 AV157Wpregistrartitulods_1_filterfulltext ,
                                                 A295TituloCompetencia_F ,
                                                 AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel ,
                                                 AV181Wpregistrartitulods_25_tftitulocompetencia_f ,
                                                 A951ContaBancariaId ,
                                                 A284TituloDeleted ,
                                                 A314TituloArchived ,
                                                 A283TituloTipo ,
                                                 A275TituloSaldo_F } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                                 TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL,
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                                 TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL
                                                 }
            });
            lV172Wpregistrartitulods_16_tftituloclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV172Wpregistrartitulods_16_tftituloclienterazaosocial), "%", "");
            lV174Wpregistrartitulods_18_tftitulopropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV174Wpregistrartitulods_18_tftitulopropostadescricao), "%", "");
            lV187Wpregistrartitulods_31_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV187Wpregistrartitulods_31_tfnotafiscalnumero), "%", "");
            /* Using cursor H009M9 */
            pr_default.execute(1, new Object[] {AV160Wpregistrartitulods_4_titulovalor1, AV160Wpregistrartitulods_4_titulovalor1, AV160Wpregistrartitulods_4_titulovalor1, AV161Wpregistrartitulods_5_contabancarianumero1, AV161Wpregistrartitulods_5_contabancarianumero1, AV161Wpregistrartitulods_5_contabancarianumero1, AV165Wpregistrartitulods_9_titulovalor2, AV165Wpregistrartitulods_9_titulovalor2, AV165Wpregistrartitulods_9_titulovalor2, AV166Wpregistrartitulods_10_contabancarianumero2, AV166Wpregistrartitulods_10_contabancarianumero2, AV166Wpregistrartitulods_10_contabancarianumero2, AV170Wpregistrartitulods_14_titulovalor3, AV170Wpregistrartitulods_14_titulovalor3, AV170Wpregistrartitulods_14_titulovalor3, AV171Wpregistrartitulods_15_contabancarianumero3, AV171Wpregistrartitulods_15_contabancarianumero3, AV171Wpregistrartitulods_15_contabancarianumero3, lV172Wpregistrartitulods_16_tftituloclienterazaosocial, AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel, lV174Wpregistrartitulods_18_tftitulopropostadescricao, AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel, AV177Wpregistrartitulods_21_tftitulovalor, AV178Wpregistrartitulods_22_tftitulovalor_to, AV179Wpregistrartitulods_23_tftitulodesconto, AV180Wpregistrartitulods_24_tftitulodesconto_to, AV183Wpregistrartitulods_27_tftituloprorrogacao, AV184Wpregistrartitulods_28_tftituloprorrogacao_to, AV185Wpregistrartitulods_29_tftitulojurosmora, AV186Wpregistrartitulods_30_tftitulojurosmora_to, lV187Wpregistrartitulods_31_tfnotafiscalnumero, AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel});
            nGXsfl_116_idx = 1;
            sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
            SubsflControlProps_1162( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A794NotaFiscalId = H009M9_A794NotaFiscalId[0];
               n794NotaFiscalId = H009M9_n794NotaFiscalId[0];
               A951ContaBancariaId = H009M9_A951ContaBancariaId[0];
               n951ContaBancariaId = H009M9_n951ContaBancariaId[0];
               A952ContaBancariaNumero = H009M9_A952ContaBancariaNumero[0];
               n952ContaBancariaNumero = H009M9_n952ContaBancariaNumero[0];
               A799NotaFiscalNumero = H009M9_A799NotaFiscalNumero[0];
               n799NotaFiscalNumero = H009M9_n799NotaFiscalNumero[0];
               A890NotaFiscalParcelamentoID = H009M9_A890NotaFiscalParcelamentoID[0];
               n890NotaFiscalParcelamentoID = H009M9_n890NotaFiscalParcelamentoID[0];
               A426CategoriaTituloId = H009M9_A426CategoriaTituloId[0];
               n426CategoriaTituloId = H009M9_n426CategoriaTituloId[0];
               A500TituloCriacao = H009M9_A500TituloCriacao[0];
               n500TituloCriacao = H009M9_n500TituloCriacao[0];
               A422ContaId = H009M9_A422ContaId[0];
               n422ContaId = H009M9_n422ContaId[0];
               A501PropostaTaxaAdministrativa = H009M9_A501PropostaTaxaAdministrativa[0];
               n501PropostaTaxaAdministrativa = H009M9_n501PropostaTaxaAdministrativa[0];
               A419TituloPropostaId = H009M9_A419TituloPropostaId[0];
               n419TituloPropostaId = H009M9_n419TituloPropostaId[0];
               A283TituloTipo = H009M9_A283TituloTipo[0];
               n283TituloTipo = H009M9_n283TituloTipo[0];
               A498TituloJurosMora = H009M9_A498TituloJurosMora[0];
               n498TituloJurosMora = H009M9_n498TituloJurosMora[0];
               A269TituloMunicipio = H009M9_A269TituloMunicipio[0];
               n269TituloMunicipio = H009M9_n269TituloMunicipio[0];
               A268TituloBairro = H009M9_A268TituloBairro[0];
               n268TituloBairro = H009M9_n268TituloBairro[0];
               A267TituloComplemento = H009M9_A267TituloComplemento[0];
               n267TituloComplemento = H009M9_n267TituloComplemento[0];
               A294TituloNumeroEndereco = H009M9_A294TituloNumeroEndereco[0];
               n294TituloNumeroEndereco = H009M9_n294TituloNumeroEndereco[0];
               A266TituloLogradouro = H009M9_A266TituloLogradouro[0];
               n266TituloLogradouro = H009M9_n266TituloLogradouro[0];
               A265TituloCEP = H009M9_A265TituloCEP[0];
               n265TituloCEP = H009M9_n265TituloCEP[0];
               A264TituloProrrogacao = H009M9_A264TituloProrrogacao[0];
               n264TituloProrrogacao = H009M9_n264TituloProrrogacao[0];
               A263TituloVencimento = H009M9_A263TituloVencimento[0];
               n263TituloVencimento = H009M9_n263TituloVencimento[0];
               A314TituloArchived = H009M9_A314TituloArchived[0];
               n314TituloArchived = H009M9_n314TituloArchived[0];
               A284TituloDeleted = H009M9_A284TituloDeleted[0];
               n284TituloDeleted = H009M9_n284TituloDeleted[0];
               A648TituloPropostaTipo = H009M9_A648TituloPropostaTipo[0];
               n648TituloPropostaTipo = H009M9_n648TituloPropostaTipo[0];
               A971TituloPropostaDescricao = H009M9_A971TituloPropostaDescricao[0];
               n971TituloPropostaDescricao = H009M9_n971TituloPropostaDescricao[0];
               A972TituloCLienteRazaoSocial = H009M9_A972TituloCLienteRazaoSocial[0];
               n972TituloCLienteRazaoSocial = H009M9_n972TituloCLienteRazaoSocial[0];
               A420TituloClienteId = H009M9_A420TituloClienteId[0];
               n420TituloClienteId = H009M9_n420TituloClienteId[0];
               A261TituloId = H009M9_A261TituloId[0];
               n261TituloId = H009M9_n261TituloId[0];
               A276TituloDesconto = H009M9_A276TituloDesconto[0];
               n276TituloDesconto = H009M9_n276TituloDesconto[0];
               A273TituloTotalMovimento_F = H009M9_A273TituloTotalMovimento_F[0];
               A301TituloTotalMultaJuros_F = H009M9_A301TituloTotalMultaJuros_F[0];
               n301TituloTotalMultaJuros_F = H009M9_n301TituloTotalMultaJuros_F[0];
               A516TituloDataCredito_F = H009M9_A516TituloDataCredito_F[0];
               n516TituloDataCredito_F = H009M9_n516TituloDataCredito_F[0];
               A286TituloCompetenciaAno = H009M9_A286TituloCompetenciaAno[0];
               n286TituloCompetenciaAno = H009M9_n286TituloCompetenciaAno[0];
               A287TituloCompetenciaMes = H009M9_A287TituloCompetenciaMes[0];
               n287TituloCompetenciaMes = H009M9_n287TituloCompetenciaMes[0];
               A262TituloValor = H009M9_A262TituloValor[0];
               n262TituloValor = H009M9_n262TituloValor[0];
               A275TituloSaldo_F = H009M9_A275TituloSaldo_F[0];
               A952ContaBancariaNumero = H009M9_A952ContaBancariaNumero[0];
               n952ContaBancariaNumero = H009M9_n952ContaBancariaNumero[0];
               A794NotaFiscalId = H009M9_A794NotaFiscalId[0];
               n794NotaFiscalId = H009M9_n794NotaFiscalId[0];
               A799NotaFiscalNumero = H009M9_A799NotaFiscalNumero[0];
               n799NotaFiscalNumero = H009M9_n799NotaFiscalNumero[0];
               A501PropostaTaxaAdministrativa = H009M9_A501PropostaTaxaAdministrativa[0];
               n501PropostaTaxaAdministrativa = H009M9_n501PropostaTaxaAdministrativa[0];
               A971TituloPropostaDescricao = H009M9_A971TituloPropostaDescricao[0];
               n971TituloPropostaDescricao = H009M9_n971TituloPropostaDescricao[0];
               A972TituloCLienteRazaoSocial = H009M9_A972TituloCLienteRazaoSocial[0];
               n972TituloCLienteRazaoSocial = H009M9_n972TituloCLienteRazaoSocial[0];
               A273TituloTotalMovimento_F = H009M9_A273TituloTotalMovimento_F[0];
               A301TituloTotalMultaJuros_F = H009M9_A301TituloTotalMultaJuros_F[0];
               n301TituloTotalMultaJuros_F = H009M9_n301TituloTotalMultaJuros_F[0];
               A516TituloDataCredito_F = H009M9_A516TituloDataCredito_F[0];
               n516TituloDataCredito_F = H009M9_n516TituloDataCredito_F[0];
               A282TituloStatus_F = ((Convert.ToDecimal(0)==A275TituloSaldo_F) ? "Liquidado" : ((A275TituloSaldo_F==A262TituloValor) ? "Aberto" : "Baixado parcialmente"));
               A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV157Wpregistrartitulods_1_filterfulltext)) || ( ( StringUtil.Like( A972TituloCLienteRazaoSocial , StringUtil.PadR( "%" + AV157Wpregistrartitulods_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( A971TituloPropostaDescricao , StringUtil.PadR( "%" + AV157Wpregistrartitulods_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( "iof" , StringUtil.PadR( "%" + StringUtil.Lower( AV157Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "IOF") == 0 ) ) || ( StringUtil.Like( "taxa" , StringUtil.PadR( "%" + StringUtil.Lower( AV157Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "TAXA") == 0 ) ) || ( StringUtil.Like( "reembolso" , StringUtil.PadR( "%" + StringUtil.Lower( AV157Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "REEMBOLSO") == 0 ) ) || ( StringUtil.Like( "comum" , StringUtil.PadR( "%" + StringUtil.Lower( AV157Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "COMUM") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV157Wpregistrartitulods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV157Wpregistrartitulods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV157Wpregistrartitulods_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A498TituloJurosMora, 16, 4) , StringUtil.PadR( "%" + AV157Wpregistrartitulods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A799NotaFiscalNumero , StringUtil.PadR( "%" + AV157Wpregistrartitulods_1_filterfulltext , 101 , "%"),  ' ' ) ) ) )
               {
                  if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV181Wpregistrartitulods_25_tftitulocompetencia_f)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV181Wpregistrartitulods_25_tftitulocompetencia_f , 40 , "%"),  ' ' ) ) )
                  {
                     if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel)) && ! ( StringUtil.StrCmp(AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel) == 0 ) ) )
                     {
                        if ( ( StringUtil.StrCmp(AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
                        {
                           /* Execute user event: Grid.Load */
                           E289M2 ();
                        }
                     }
                  }
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 116;
            WB9M0( ) ;
         }
         bGXsfl_116_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9M2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV156Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV156Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOID"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, context.localUtil.Format( (decimal)(A261TituloId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOCLIENTEID"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, context.localUtil.Format( (decimal)(A420TituloClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOPROPOSTATIPO"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, StringUtil.RTrim( context.localUtil.Format( A648TituloPropostaTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOVALOR"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, context.localUtil.Format( A262TituloValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULODESCONTO"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, context.localUtil.Format( A276TituloDesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULODELETED"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, A284TituloDeleted, context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOARCHIVED"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, A314TituloArchived, context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOVENCIMENTO"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, A263TituloVencimento, context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOCOMPETENCIAMES"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, context.localUtil.Format( (decimal)(A287TituloCompetenciaMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOCOMPETENCIAANO"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, context.localUtil.Format( (decimal)(A286TituloCompetenciaAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOCOMPETENCIA_F"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, StringUtil.RTrim( context.localUtil.Format( A295TituloCompetencia_F, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOPRORROGACAO"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, A264TituloProrrogacao, context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOCEP"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, StringUtil.RTrim( context.localUtil.Format( A265TituloCEP, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOLOGRADOURO"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, StringUtil.RTrim( context.localUtil.Format( A266TituloLogradouro, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULONUMEROENDERECO"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, StringUtil.RTrim( context.localUtil.Format( A294TituloNumeroEndereco, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOCOMPLEMENTO"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, StringUtil.RTrim( context.localUtil.Format( A267TituloComplemento, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOBAIRRO"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, StringUtil.RTrim( context.localUtil.Format( A268TituloBairro, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOMUNICIPIO"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, StringUtil.RTrim( context.localUtil.Format( A269TituloMunicipio, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOJUROSMORA"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, context.localUtil.Format( A498TituloJurosMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOTIPO"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, StringUtil.RTrim( context.localUtil.Format( A283TituloTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOPROPOSTAID"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, context.localUtil.Format( (decimal)(A419TituloPropostaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CONTAID"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, context.localUtil.Format( (decimal)(A422ContaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOCRIACAO"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, context.localUtil.Format( A500TituloCriacao, "99/99/99 99:99"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CATEGORIATITULOID"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, context.localUtil.Format( (decimal)(A426CategoriaTituloId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOSALDO_F"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, context.localUtil.Format( A275TituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOSTATUS_F"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, StringUtil.RTrim( context.localUtil.Format( A282TituloStatus_F, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_NOTAFISCALPARCELAMENTOID"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sGXsfl_116_idx, A890NotaFiscalParcelamentoID, context));
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
         AV157Wpregistrartitulods_1_filterfulltext = AV15FilterFullText;
         AV158Wpregistrartitulods_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV159Wpregistrartitulods_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV160Wpregistrartitulods_4_titulovalor1 = AV18TituloValor1;
         AV161Wpregistrartitulods_5_contabancarianumero1 = AV19ContaBancariaNumero1;
         AV162Wpregistrartitulods_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV163Wpregistrartitulods_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV164Wpregistrartitulods_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV165Wpregistrartitulods_9_titulovalor2 = AV23TituloValor2;
         AV166Wpregistrartitulods_10_contabancarianumero2 = AV24ContaBancariaNumero2;
         AV167Wpregistrartitulods_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV168Wpregistrartitulods_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV169Wpregistrartitulods_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV170Wpregistrartitulods_14_titulovalor3 = AV28TituloValor3;
         AV171Wpregistrartitulods_15_contabancarianumero3 = AV29ContaBancariaNumero3;
         AV172Wpregistrartitulods_16_tftituloclienterazaosocial = AV154TFTituloCLienteRazaoSocial;
         AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel = AV155TFTituloCLienteRazaoSocial_Sel;
         AV174Wpregistrartitulods_18_tftitulopropostadescricao = AV143TFTituloPropostaDescricao;
         AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel = AV144TFTituloPropostaDescricao_Sel;
         AV176Wpregistrartitulods_20_tftitulopropostatipo_sels = AV121TFTituloPropostaTipo_Sels;
         AV177Wpregistrartitulods_21_tftitulovalor = AV44TFTituloValor;
         AV178Wpregistrartitulods_22_tftitulovalor_to = AV45TFTituloValor_To;
         AV179Wpregistrartitulods_23_tftitulodesconto = AV46TFTituloDesconto;
         AV180Wpregistrartitulods_24_tftitulodesconto_to = AV47TFTituloDesconto_To;
         AV181Wpregistrartitulods_25_tftitulocompetencia_f = AV59TFTituloCompetencia_F;
         AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel = AV60TFTituloCompetencia_F_Sel;
         AV183Wpregistrartitulods_27_tftituloprorrogacao = AV61TFTituloProrrogacao;
         AV184Wpregistrartitulods_28_tftituloprorrogacao_to = AV62TFTituloProrrogacao_To;
         AV185Wpregistrartitulods_29_tftitulojurosmora = AV78TFTituloJurosMora;
         AV186Wpregistrartitulods_30_tftitulojurosmora_to = AV79TFTituloJurosMora_To;
         AV187Wpregistrartitulods_31_tfnotafiscalnumero = AV141TFNotaFiscalNumero;
         AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel = AV142TFNotaFiscalNumero_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TituloValor1, AV19ContaBancariaNumero1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV24ContaBancariaNumero2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28TituloValor3, AV29ContaBancariaNumero3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV156Pgmname, AV150TituloIdJson, AV15FilterFullText, AV154TFTituloCLienteRazaoSocial, AV155TFTituloCLienteRazaoSocial_Sel, AV143TFTituloPropostaDescricao, AV144TFTituloPropostaDescricao_Sel, AV121TFTituloPropostaTipo_Sels, AV44TFTituloValor, AV45TFTituloValor_To, AV46TFTituloDesconto, AV47TFTituloDesconto_To, AV59TFTituloCompetencia_F, AV60TFTituloCompetencia_F_Sel, AV61TFTituloProrrogacao, AV62TFTituloProrrogacao_To, AV78TFTituloJurosMora, AV79TFTituloJurosMora_To, AV141TFNotaFiscalNumero, AV142TFNotaFiscalNumero_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV148i, AV149TituloIdCol, AV152TituloIdToFind, AV153SelectAll) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV157Wpregistrartitulods_1_filterfulltext = AV15FilterFullText;
         AV158Wpregistrartitulods_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV159Wpregistrartitulods_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV160Wpregistrartitulods_4_titulovalor1 = AV18TituloValor1;
         AV161Wpregistrartitulods_5_contabancarianumero1 = AV19ContaBancariaNumero1;
         AV162Wpregistrartitulods_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV163Wpregistrartitulods_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV164Wpregistrartitulods_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV165Wpregistrartitulods_9_titulovalor2 = AV23TituloValor2;
         AV166Wpregistrartitulods_10_contabancarianumero2 = AV24ContaBancariaNumero2;
         AV167Wpregistrartitulods_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV168Wpregistrartitulods_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV169Wpregistrartitulods_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV170Wpregistrartitulods_14_titulovalor3 = AV28TituloValor3;
         AV171Wpregistrartitulods_15_contabancarianumero3 = AV29ContaBancariaNumero3;
         AV172Wpregistrartitulods_16_tftituloclienterazaosocial = AV154TFTituloCLienteRazaoSocial;
         AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel = AV155TFTituloCLienteRazaoSocial_Sel;
         AV174Wpregistrartitulods_18_tftitulopropostadescricao = AV143TFTituloPropostaDescricao;
         AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel = AV144TFTituloPropostaDescricao_Sel;
         AV176Wpregistrartitulods_20_tftitulopropostatipo_sels = AV121TFTituloPropostaTipo_Sels;
         AV177Wpregistrartitulods_21_tftitulovalor = AV44TFTituloValor;
         AV178Wpregistrartitulods_22_tftitulovalor_to = AV45TFTituloValor_To;
         AV179Wpregistrartitulods_23_tftitulodesconto = AV46TFTituloDesconto;
         AV180Wpregistrartitulods_24_tftitulodesconto_to = AV47TFTituloDesconto_To;
         AV181Wpregistrartitulods_25_tftitulocompetencia_f = AV59TFTituloCompetencia_F;
         AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel = AV60TFTituloCompetencia_F_Sel;
         AV183Wpregistrartitulods_27_tftituloprorrogacao = AV61TFTituloProrrogacao;
         AV184Wpregistrartitulods_28_tftituloprorrogacao_to = AV62TFTituloProrrogacao_To;
         AV185Wpregistrartitulods_29_tftitulojurosmora = AV78TFTituloJurosMora;
         AV186Wpregistrartitulods_30_tftitulojurosmora_to = AV79TFTituloJurosMora_To;
         AV187Wpregistrartitulods_31_tfnotafiscalnumero = AV141TFNotaFiscalNumero;
         AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel = AV142TFNotaFiscalNumero_Sel;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TituloValor1, AV19ContaBancariaNumero1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV24ContaBancariaNumero2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28TituloValor3, AV29ContaBancariaNumero3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV156Pgmname, AV150TituloIdJson, AV15FilterFullText, AV154TFTituloCLienteRazaoSocial, AV155TFTituloCLienteRazaoSocial_Sel, AV143TFTituloPropostaDescricao, AV144TFTituloPropostaDescricao_Sel, AV121TFTituloPropostaTipo_Sels, AV44TFTituloValor, AV45TFTituloValor_To, AV46TFTituloDesconto, AV47TFTituloDesconto_To, AV59TFTituloCompetencia_F, AV60TFTituloCompetencia_F_Sel, AV61TFTituloProrrogacao, AV62TFTituloProrrogacao_To, AV78TFTituloJurosMora, AV79TFTituloJurosMora_To, AV141TFNotaFiscalNumero, AV142TFNotaFiscalNumero_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV148i, AV149TituloIdCol, AV152TituloIdToFind, AV153SelectAll) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV157Wpregistrartitulods_1_filterfulltext = AV15FilterFullText;
         AV158Wpregistrartitulods_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV159Wpregistrartitulods_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV160Wpregistrartitulods_4_titulovalor1 = AV18TituloValor1;
         AV161Wpregistrartitulods_5_contabancarianumero1 = AV19ContaBancariaNumero1;
         AV162Wpregistrartitulods_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV163Wpregistrartitulods_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV164Wpregistrartitulods_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV165Wpregistrartitulods_9_titulovalor2 = AV23TituloValor2;
         AV166Wpregistrartitulods_10_contabancarianumero2 = AV24ContaBancariaNumero2;
         AV167Wpregistrartitulods_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV168Wpregistrartitulods_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV169Wpregistrartitulods_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV170Wpregistrartitulods_14_titulovalor3 = AV28TituloValor3;
         AV171Wpregistrartitulods_15_contabancarianumero3 = AV29ContaBancariaNumero3;
         AV172Wpregistrartitulods_16_tftituloclienterazaosocial = AV154TFTituloCLienteRazaoSocial;
         AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel = AV155TFTituloCLienteRazaoSocial_Sel;
         AV174Wpregistrartitulods_18_tftitulopropostadescricao = AV143TFTituloPropostaDescricao;
         AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel = AV144TFTituloPropostaDescricao_Sel;
         AV176Wpregistrartitulods_20_tftitulopropostatipo_sels = AV121TFTituloPropostaTipo_Sels;
         AV177Wpregistrartitulods_21_tftitulovalor = AV44TFTituloValor;
         AV178Wpregistrartitulods_22_tftitulovalor_to = AV45TFTituloValor_To;
         AV179Wpregistrartitulods_23_tftitulodesconto = AV46TFTituloDesconto;
         AV180Wpregistrartitulods_24_tftitulodesconto_to = AV47TFTituloDesconto_To;
         AV181Wpregistrartitulods_25_tftitulocompetencia_f = AV59TFTituloCompetencia_F;
         AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel = AV60TFTituloCompetencia_F_Sel;
         AV183Wpregistrartitulods_27_tftituloprorrogacao = AV61TFTituloProrrogacao;
         AV184Wpregistrartitulods_28_tftituloprorrogacao_to = AV62TFTituloProrrogacao_To;
         AV185Wpregistrartitulods_29_tftitulojurosmora = AV78TFTituloJurosMora;
         AV186Wpregistrartitulods_30_tftitulojurosmora_to = AV79TFTituloJurosMora_To;
         AV187Wpregistrartitulods_31_tfnotafiscalnumero = AV141TFNotaFiscalNumero;
         AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel = AV142TFNotaFiscalNumero_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TituloValor1, AV19ContaBancariaNumero1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV24ContaBancariaNumero2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28TituloValor3, AV29ContaBancariaNumero3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV156Pgmname, AV150TituloIdJson, AV15FilterFullText, AV154TFTituloCLienteRazaoSocial, AV155TFTituloCLienteRazaoSocial_Sel, AV143TFTituloPropostaDescricao, AV144TFTituloPropostaDescricao_Sel, AV121TFTituloPropostaTipo_Sels, AV44TFTituloValor, AV45TFTituloValor_To, AV46TFTituloDesconto, AV47TFTituloDesconto_To, AV59TFTituloCompetencia_F, AV60TFTituloCompetencia_F_Sel, AV61TFTituloProrrogacao, AV62TFTituloProrrogacao_To, AV78TFTituloJurosMora, AV79TFTituloJurosMora_To, AV141TFNotaFiscalNumero, AV142TFNotaFiscalNumero_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV148i, AV149TituloIdCol, AV152TituloIdToFind, AV153SelectAll) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV157Wpregistrartitulods_1_filterfulltext = AV15FilterFullText;
         AV158Wpregistrartitulods_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV159Wpregistrartitulods_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV160Wpregistrartitulods_4_titulovalor1 = AV18TituloValor1;
         AV161Wpregistrartitulods_5_contabancarianumero1 = AV19ContaBancariaNumero1;
         AV162Wpregistrartitulods_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV163Wpregistrartitulods_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV164Wpregistrartitulods_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV165Wpregistrartitulods_9_titulovalor2 = AV23TituloValor2;
         AV166Wpregistrartitulods_10_contabancarianumero2 = AV24ContaBancariaNumero2;
         AV167Wpregistrartitulods_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV168Wpregistrartitulods_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV169Wpregistrartitulods_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV170Wpregistrartitulods_14_titulovalor3 = AV28TituloValor3;
         AV171Wpregistrartitulods_15_contabancarianumero3 = AV29ContaBancariaNumero3;
         AV172Wpregistrartitulods_16_tftituloclienterazaosocial = AV154TFTituloCLienteRazaoSocial;
         AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel = AV155TFTituloCLienteRazaoSocial_Sel;
         AV174Wpregistrartitulods_18_tftitulopropostadescricao = AV143TFTituloPropostaDescricao;
         AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel = AV144TFTituloPropostaDescricao_Sel;
         AV176Wpregistrartitulods_20_tftitulopropostatipo_sels = AV121TFTituloPropostaTipo_Sels;
         AV177Wpregistrartitulods_21_tftitulovalor = AV44TFTituloValor;
         AV178Wpregistrartitulods_22_tftitulovalor_to = AV45TFTituloValor_To;
         AV179Wpregistrartitulods_23_tftitulodesconto = AV46TFTituloDesconto;
         AV180Wpregistrartitulods_24_tftitulodesconto_to = AV47TFTituloDesconto_To;
         AV181Wpregistrartitulods_25_tftitulocompetencia_f = AV59TFTituloCompetencia_F;
         AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel = AV60TFTituloCompetencia_F_Sel;
         AV183Wpregistrartitulods_27_tftituloprorrogacao = AV61TFTituloProrrogacao;
         AV184Wpregistrartitulods_28_tftituloprorrogacao_to = AV62TFTituloProrrogacao_To;
         AV185Wpregistrartitulods_29_tftitulojurosmora = AV78TFTituloJurosMora;
         AV186Wpregistrartitulods_30_tftitulojurosmora_to = AV79TFTituloJurosMora_To;
         AV187Wpregistrartitulods_31_tfnotafiscalnumero = AV141TFNotaFiscalNumero;
         AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel = AV142TFNotaFiscalNumero_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TituloValor1, AV19ContaBancariaNumero1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV24ContaBancariaNumero2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28TituloValor3, AV29ContaBancariaNumero3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV156Pgmname, AV150TituloIdJson, AV15FilterFullText, AV154TFTituloCLienteRazaoSocial, AV155TFTituloCLienteRazaoSocial_Sel, AV143TFTituloPropostaDescricao, AV144TFTituloPropostaDescricao_Sel, AV121TFTituloPropostaTipo_Sels, AV44TFTituloValor, AV45TFTituloValor_To, AV46TFTituloDesconto, AV47TFTituloDesconto_To, AV59TFTituloCompetencia_F, AV60TFTituloCompetencia_F_Sel, AV61TFTituloProrrogacao, AV62TFTituloProrrogacao_To, AV78TFTituloJurosMora, AV79TFTituloJurosMora_To, AV141TFNotaFiscalNumero, AV142TFNotaFiscalNumero_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV148i, AV149TituloIdCol, AV152TituloIdToFind, AV153SelectAll) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV157Wpregistrartitulods_1_filterfulltext = AV15FilterFullText;
         AV158Wpregistrartitulods_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV159Wpregistrartitulods_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV160Wpregistrartitulods_4_titulovalor1 = AV18TituloValor1;
         AV161Wpregistrartitulods_5_contabancarianumero1 = AV19ContaBancariaNumero1;
         AV162Wpregistrartitulods_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV163Wpregistrartitulods_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV164Wpregistrartitulods_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV165Wpregistrartitulods_9_titulovalor2 = AV23TituloValor2;
         AV166Wpregistrartitulods_10_contabancarianumero2 = AV24ContaBancariaNumero2;
         AV167Wpregistrartitulods_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV168Wpregistrartitulods_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV169Wpregistrartitulods_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV170Wpregistrartitulods_14_titulovalor3 = AV28TituloValor3;
         AV171Wpregistrartitulods_15_contabancarianumero3 = AV29ContaBancariaNumero3;
         AV172Wpregistrartitulods_16_tftituloclienterazaosocial = AV154TFTituloCLienteRazaoSocial;
         AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel = AV155TFTituloCLienteRazaoSocial_Sel;
         AV174Wpregistrartitulods_18_tftitulopropostadescricao = AV143TFTituloPropostaDescricao;
         AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel = AV144TFTituloPropostaDescricao_Sel;
         AV176Wpregistrartitulods_20_tftitulopropostatipo_sels = AV121TFTituloPropostaTipo_Sels;
         AV177Wpregistrartitulods_21_tftitulovalor = AV44TFTituloValor;
         AV178Wpregistrartitulods_22_tftitulovalor_to = AV45TFTituloValor_To;
         AV179Wpregistrartitulods_23_tftitulodesconto = AV46TFTituloDesconto;
         AV180Wpregistrartitulods_24_tftitulodesconto_to = AV47TFTituloDesconto_To;
         AV181Wpregistrartitulods_25_tftitulocompetencia_f = AV59TFTituloCompetencia_F;
         AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel = AV60TFTituloCompetencia_F_Sel;
         AV183Wpregistrartitulods_27_tftituloprorrogacao = AV61TFTituloProrrogacao;
         AV184Wpregistrartitulods_28_tftituloprorrogacao_to = AV62TFTituloProrrogacao_To;
         AV185Wpregistrartitulods_29_tftitulojurosmora = AV78TFTituloJurosMora;
         AV186Wpregistrartitulods_30_tftitulojurosmora_to = AV79TFTituloJurosMora_To;
         AV187Wpregistrartitulods_31_tfnotafiscalnumero = AV141TFNotaFiscalNumero;
         AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel = AV142TFNotaFiscalNumero_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TituloValor1, AV19ContaBancariaNumero1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV24ContaBancariaNumero2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28TituloValor3, AV29ContaBancariaNumero3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV156Pgmname, AV150TituloIdJson, AV15FilterFullText, AV154TFTituloCLienteRazaoSocial, AV155TFTituloCLienteRazaoSocial_Sel, AV143TFTituloPropostaDescricao, AV144TFTituloPropostaDescricao_Sel, AV121TFTituloPropostaTipo_Sels, AV44TFTituloValor, AV45TFTituloValor_To, AV46TFTituloDesconto, AV47TFTituloDesconto_To, AV59TFTituloCompetencia_F, AV60TFTituloCompetencia_F_Sel, AV61TFTituloProrrogacao, AV62TFTituloProrrogacao_To, AV78TFTituloJurosMora, AV79TFTituloJurosMora_To, AV141TFNotaFiscalNumero, AV142TFNotaFiscalNumero_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV148i, AV149TituloIdCol, AV152TituloIdToFind, AV153SelectAll) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV156Pgmname = "WPRegistrarTitulo";
         edtTituloId_Enabled = 0;
         edtTituloClienteId_Enabled = 0;
         edtTituloCLienteRazaoSocial_Enabled = 0;
         edtTituloPropostaDescricao_Enabled = 0;
         cmbTituloPropostaTipo.Enabled = 0;
         edtTituloValor_Enabled = 0;
         edtTituloDesconto_Enabled = 0;
         chkTituloDeleted.Enabled = 0;
         chkTituloArchived.Enabled = 0;
         edtTituloVencimento_Enabled = 0;
         edtTituloCompetenciaMes_Enabled = 0;
         edtTituloCompetenciaAno_Enabled = 0;
         edtTituloCompetencia_F_Enabled = 0;
         edtTituloProrrogacao_Enabled = 0;
         edtTituloCEP_Enabled = 0;
         edtTituloLogradouro_Enabled = 0;
         edtTituloNumeroEndereco_Enabled = 0;
         edtTituloComplemento_Enabled = 0;
         edtTituloBairro_Enabled = 0;
         edtTituloMunicipio_Enabled = 0;
         edtTituloJurosMora_Enabled = 0;
         cmbTituloTipo.Enabled = 0;
         edtTituloPropostaId_Enabled = 0;
         edtPropostaTaxaAdministrativa_Enabled = 0;
         edtContaId_Enabled = 0;
         edtTituloCriacao_Enabled = 0;
         edtCategoriaTituloId_Enabled = 0;
         edtTituloDataCredito_F_Enabled = 0;
         edtTituloTotalMovimento_F_Enabled = 0;
         edtTituloTotalMultaJuros_F_Enabled = 0;
         edtTituloSaldo_F_Enabled = 0;
         edtTituloStatus_F_Enabled = 0;
         edtNotaFiscalParcelamentoID_Enabled = 0;
         edtNotaFiscalNumero_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9M0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E269M2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV35ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV132DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_116 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_116"), ",", "."), 18, MidpointRounding.ToEven));
            AV134GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV135GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV136GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV63DDO_TituloProrrogacaoAuxDate = context.localUtil.CToD( cgiGet( "vDDO_TITULOPRORROGACAOAUXDATE"), 0);
            AV64DDO_TituloProrrogacaoAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_TITULOPRORROGACAOAUXDATETO"), 0);
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTitulovalor1_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTitulovalor1_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTITULOVALOR1");
               GX_FocusControl = edtavTitulovalor1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18TituloValor1 = 0;
               AssignAttri("", false, "AV18TituloValor1", StringUtil.LTrimStr( AV18TituloValor1, 18, 2));
            }
            else
            {
               AV18TituloValor1 = context.localUtil.CToN( cgiGet( edtavTitulovalor1_Internalname), ",", ".");
               AssignAttri("", false, "AV18TituloValor1", StringUtil.LTrimStr( AV18TituloValor1, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavContabancarianumero1_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavContabancarianumero1_Internalname), ",", ".") > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONTABANCARIANUMERO1");
               GX_FocusControl = edtavContabancarianumero1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV19ContaBancariaNumero1 = 0;
               AssignAttri("", false, "AV19ContaBancariaNumero1", StringUtil.LTrimStr( (decimal)(AV19ContaBancariaNumero1), 18, 0));
            }
            else
            {
               AV19ContaBancariaNumero1 = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavContabancarianumero1_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV19ContaBancariaNumero1", StringUtil.LTrimStr( (decimal)(AV19ContaBancariaNumero1), 18, 0));
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavContabancarianumero2_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavContabancarianumero2_Internalname), ",", ".") > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONTABANCARIANUMERO2");
               GX_FocusControl = edtavContabancarianumero2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV24ContaBancariaNumero2 = 0;
               AssignAttri("", false, "AV24ContaBancariaNumero2", StringUtil.LTrimStr( (decimal)(AV24ContaBancariaNumero2), 18, 0));
            }
            else
            {
               AV24ContaBancariaNumero2 = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavContabancarianumero2_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV24ContaBancariaNumero2", StringUtil.LTrimStr( (decimal)(AV24ContaBancariaNumero2), 18, 0));
            }
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV26DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTitulovalor3_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTitulovalor3_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTITULOVALOR3");
               GX_FocusControl = edtavTitulovalor3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV28TituloValor3 = 0;
               AssignAttri("", false, "AV28TituloValor3", StringUtil.LTrimStr( AV28TituloValor3, 18, 2));
            }
            else
            {
               AV28TituloValor3 = context.localUtil.CToN( cgiGet( edtavTitulovalor3_Internalname), ",", ".");
               AssignAttri("", false, "AV28TituloValor3", StringUtil.LTrimStr( AV28TituloValor3, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavContabancarianumero3_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavContabancarianumero3_Internalname), ",", ".") > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONTABANCARIANUMERO3");
               GX_FocusControl = edtavContabancarianumero3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV29ContaBancariaNumero3 = 0;
               AssignAttri("", false, "AV29ContaBancariaNumero3", StringUtil.LTrimStr( (decimal)(AV29ContaBancariaNumero3), 18, 0));
            }
            else
            {
               AV29ContaBancariaNumero3 = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavContabancarianumero3_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV29ContaBancariaNumero3", StringUtil.LTrimStr( (decimal)(AV29ContaBancariaNumero3), 18, 0));
            }
            AV153SelectAll = StringUtil.StrToBool( cgiGet( chkavSelectall_Internalname));
            AssignAttri("", false, "AV153SelectAll", AV153SelectAll);
            AV65DDO_TituloProrrogacaoAuxDateText = cgiGet( edtavDdo_tituloprorrogacaoauxdatetext_Internalname);
            AssignAttri("", false, "AV65DDO_TituloProrrogacaoAuxDateText", AV65DDO_TituloProrrogacaoAuxDateText);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV16DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV17DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vTITULOVALOR1"), ",", ".") != AV18TituloValor1 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCONTABANCARIANUMERO1"), ",", ".") != Convert.ToDecimal( AV19ContaBancariaNumero1 )) )
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
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCONTABANCARIANUMERO2"), ",", ".") != Convert.ToDecimal( AV24ContaBancariaNumero2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV26DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV27DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vTITULOVALOR3"), ",", ".") != AV28TituloValor3 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCONTABANCARIANUMERO3"), ",", ".") != Convert.ToDecimal( AV29ContaBancariaNumero3 )) )
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
         E269M2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E269M2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFTITULOPRORROGACAO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_tituloprorrogacaoauxdatetext_Internalname});
         chkavSelectall.Visible = 0;
         AssignProp("", false, chkavSelectall_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavSelectall.Visible), 5, 0), true);
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
         AV16DynamicFiltersSelector1 = "TITULOVALOR";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
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
         AV26DynamicFiltersSelector3 = "TITULOVALOR";
         AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
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
         chkavSelected_Titleformat = 1;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV132DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV132DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E279M2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV37ManageFiltersExecutionStep == 1 )
         {
            AV37ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV37ManageFiltersExecutionStep == 2 )
         {
            AV37ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "TITULOVALOR") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "<", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
            cmbavDynamicfiltersoperator1.addItem("2", ">", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONTABANCARIANUMERO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "<", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
            cmbavDynamicfiltersoperator1.addItem("2", ">", 0);
         }
         if ( AV20DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "TITULOVALOR") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
               cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
            }
            else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "CONTABANCARIANUMERO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
               cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
            }
            if ( AV25DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TITULOVALOR") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
                  cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CONTABANCARIANUMERO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
                  cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
               }
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         chkavSelected.Title.Text = StringUtil.Format( "<input name=\"selectAllCheckbox\" type=\"checkbox\" value=\"Select All\" onchange=\"$(%1).click();\" class=\"AttributeCheckBox\" >", "'#"+chkavSelectall_Internalname+"'", "", "", "", "", "", "", "", "");
         AssignProp("", false, chkavSelected_Internalname, "Title", chkavSelected.Title.Text, !bGXsfl_116_Refreshing);
         AV153SelectAll = false;
         AssignAttri("", false, "AV153SelectAll", AV153SelectAll);
         AV134GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV134GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV134GridCurrentPage), 10, 0));
         AV135GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV135GridPageCount", StringUtil.LTrimStr( (decimal)(AV135GridPageCount), 10, 0));
         GXt_char2 = AV136GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV156Pgmname, out  GXt_char2) ;
         AV136GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV136GridAppliedFilters", AV136GridAppliedFilters);
         AV149TituloIdCol.FromJSonString(AV150TituloIdJson, null);
         AV157Wpregistrartitulods_1_filterfulltext = AV15FilterFullText;
         AV158Wpregistrartitulods_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV159Wpregistrartitulods_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV160Wpregistrartitulods_4_titulovalor1 = AV18TituloValor1;
         AV161Wpregistrartitulods_5_contabancarianumero1 = AV19ContaBancariaNumero1;
         AV162Wpregistrartitulods_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV163Wpregistrartitulods_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV164Wpregistrartitulods_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV165Wpregistrartitulods_9_titulovalor2 = AV23TituloValor2;
         AV166Wpregistrartitulods_10_contabancarianumero2 = AV24ContaBancariaNumero2;
         AV167Wpregistrartitulods_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV168Wpregistrartitulods_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV169Wpregistrartitulods_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV170Wpregistrartitulods_14_titulovalor3 = AV28TituloValor3;
         AV171Wpregistrartitulods_15_contabancarianumero3 = AV29ContaBancariaNumero3;
         AV172Wpregistrartitulods_16_tftituloclienterazaosocial = AV154TFTituloCLienteRazaoSocial;
         AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel = AV155TFTituloCLienteRazaoSocial_Sel;
         AV174Wpregistrartitulods_18_tftitulopropostadescricao = AV143TFTituloPropostaDescricao;
         AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel = AV144TFTituloPropostaDescricao_Sel;
         AV176Wpregistrartitulods_20_tftitulopropostatipo_sels = AV121TFTituloPropostaTipo_Sels;
         AV177Wpregistrartitulods_21_tftitulovalor = AV44TFTituloValor;
         AV178Wpregistrartitulods_22_tftitulovalor_to = AV45TFTituloValor_To;
         AV179Wpregistrartitulods_23_tftitulodesconto = AV46TFTituloDesconto;
         AV180Wpregistrartitulods_24_tftitulodesconto_to = AV47TFTituloDesconto_To;
         AV181Wpregistrartitulods_25_tftitulocompetencia_f = AV59TFTituloCompetencia_F;
         AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel = AV60TFTituloCompetencia_F_Sel;
         AV183Wpregistrartitulods_27_tftituloprorrogacao = AV61TFTituloProrrogacao;
         AV184Wpregistrartitulods_28_tftituloprorrogacao_to = AV62TFTituloProrrogacao_To;
         AV185Wpregistrartitulods_29_tftitulojurosmora = AV78TFTituloJurosMora;
         AV186Wpregistrartitulods_30_tftitulojurosmora_to = AV79TFTituloJurosMora_To;
         AV187Wpregistrartitulods_31_tfnotafiscalnumero = AV141TFNotaFiscalNumero;
         AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel = AV142TFNotaFiscalNumero_Sel;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV149TituloIdCol", AV149TituloIdCol);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E129M2( )
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
            AV133PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV133PageToGo) ;
         }
      }

      protected void E139M2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E149M2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloCLienteRazaoSocial") == 0 )
            {
               AV154TFTituloCLienteRazaoSocial = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV154TFTituloCLienteRazaoSocial", AV154TFTituloCLienteRazaoSocial);
               AV155TFTituloCLienteRazaoSocial_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV155TFTituloCLienteRazaoSocial_Sel", AV155TFTituloCLienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloPropostaDescricao") == 0 )
            {
               AV143TFTituloPropostaDescricao = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV143TFTituloPropostaDescricao", AV143TFTituloPropostaDescricao);
               AV144TFTituloPropostaDescricao_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV144TFTituloPropostaDescricao_Sel", AV144TFTituloPropostaDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloPropostaTipo") == 0 )
            {
               AV120TFTituloPropostaTipo_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV120TFTituloPropostaTipo_SelsJson", AV120TFTituloPropostaTipo_SelsJson);
               AV121TFTituloPropostaTipo_Sels.FromJSonString(AV120TFTituloPropostaTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloValor") == 0 )
            {
               AV44TFTituloValor = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV44TFTituloValor", StringUtil.LTrimStr( AV44TFTituloValor, 18, 2));
               AV45TFTituloValor_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV45TFTituloValor_To", StringUtil.LTrimStr( AV45TFTituloValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloDesconto") == 0 )
            {
               AV46TFTituloDesconto = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV46TFTituloDesconto", StringUtil.LTrimStr( AV46TFTituloDesconto, 18, 2));
               AV47TFTituloDesconto_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV47TFTituloDesconto_To", StringUtil.LTrimStr( AV47TFTituloDesconto_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloCompetencia_F") == 0 )
            {
               AV59TFTituloCompetencia_F = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV59TFTituloCompetencia_F", AV59TFTituloCompetencia_F);
               AV60TFTituloCompetencia_F_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV60TFTituloCompetencia_F_Sel", AV60TFTituloCompetencia_F_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloProrrogacao") == 0 )
            {
               AV61TFTituloProrrogacao = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV61TFTituloProrrogacao", context.localUtil.Format(AV61TFTituloProrrogacao, "99/99/9999"));
               AV62TFTituloProrrogacao_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV62TFTituloProrrogacao_To", context.localUtil.Format(AV62TFTituloProrrogacao_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloJurosMora") == 0 )
            {
               AV78TFTituloJurosMora = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV78TFTituloJurosMora", StringUtil.LTrimStr( AV78TFTituloJurosMora, 16, 4));
               AV79TFTituloJurosMora_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV79TFTituloJurosMora_To", StringUtil.LTrimStr( AV79TFTituloJurosMora_To, 16, 4));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalNumero") == 0 )
            {
               AV141TFNotaFiscalNumero = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV141TFNotaFiscalNumero", AV141TFNotaFiscalNumero);
               AV142TFNotaFiscalNumero_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV142TFNotaFiscalNumero_Sel", AV142TFNotaFiscalNumero_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV121TFTituloPropostaTipo_Sels", AV121TFTituloPropostaTipo_Sels);
      }

      private void E289M2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            AV145Selected = false;
            AssignAttri("", false, chkavSelected_Internalname, AV145Selected);
            AV152TituloIdToFind = A261TituloId;
            AssignAttri("", false, "AV152TituloIdToFind", StringUtil.LTrimStr( (decimal)(AV152TituloIdToFind), 9, 0));
            /* Execute user subroutine: 'GETINDEXOFSELECTEDROW' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV148i > 0 )
            {
               AV145Selected = true;
               AssignAttri("", false, chkavSelected_Internalname, AV145Selected);
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 116;
            }
            sendrow_1162( ) ;
         }
         GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_116_Refreshing )
         {
            DoAjaxLoad(116, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E299M2( )
      {
         /* Selected_Click Routine */
         returnInSub = false;
         if ( AV145Selected )
         {
            AV149TituloIdCol.Add(A261TituloId, 0);
         }
         else
         {
            AV152TituloIdToFind = A261TituloId;
            AssignAttri("", false, "AV152TituloIdToFind", StringUtil.LTrimStr( (decimal)(AV152TituloIdToFind), 9, 0));
            /* Execute user subroutine: 'GETINDEXOFSELECTEDROW' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            AV149TituloIdCol.RemoveItem((int)(AV148i));
         }
         AV150TituloIdJson = AV149TituloIdCol.ToJSonString(false);
         AssignAttri("", false, "AV150TituloIdJson", AV150TituloIdJson);
         divLayoutmaintable_Class = "Table TableWithSelectableGrid"+((AV149TituloIdCol.Count>0) ? " WWPMultiRowSelected" : "");
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV149TituloIdCol", AV149TituloIdCol);
      }

      protected void E219M2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TituloValor1, AV19ContaBancariaNumero1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV24ContaBancariaNumero2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28TituloValor3, AV29ContaBancariaNumero3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV156Pgmname, AV150TituloIdJson, AV15FilterFullText, AV154TFTituloCLienteRazaoSocial, AV155TFTituloCLienteRazaoSocial_Sel, AV143TFTituloPropostaDescricao, AV144TFTituloPropostaDescricao_Sel, AV121TFTituloPropostaTipo_Sels, AV44TFTituloValor, AV45TFTituloValor_To, AV46TFTituloDesconto, AV47TFTituloDesconto_To, AV59TFTituloCompetencia_F, AV60TFTituloCompetencia_F_Sel, AV61TFTituloProrrogacao, AV62TFTituloProrrogacao_To, AV78TFTituloJurosMora, AV79TFTituloJurosMora_To, AV141TFNotaFiscalNumero, AV142TFNotaFiscalNumero_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV148i, AV149TituloIdCol, AV152TituloIdToFind, AV153SelectAll) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV149TituloIdCol", AV149TituloIdCol);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E159M2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV31DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV31DynamicFiltersIgnoreFirst", AV31DynamicFiltersIgnoreFirst);
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
         AV30DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV31DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV31DynamicFiltersIgnoreFirst", AV31DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TituloValor1, AV19ContaBancariaNumero1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV24ContaBancariaNumero2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28TituloValor3, AV29ContaBancariaNumero3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV156Pgmname, AV150TituloIdJson, AV15FilterFullText, AV154TFTituloCLienteRazaoSocial, AV155TFTituloCLienteRazaoSocial_Sel, AV143TFTituloPropostaDescricao, AV144TFTituloPropostaDescricao_Sel, AV121TFTituloPropostaTipo_Sels, AV44TFTituloValor, AV45TFTituloValor_To, AV46TFTituloDesconto, AV47TFTituloDesconto_To, AV59TFTituloCompetencia_F, AV60TFTituloCompetencia_F_Sel, AV61TFTituloProrrogacao, AV62TFTituloProrrogacao_To, AV78TFTituloJurosMora, AV79TFTituloJurosMora_To, AV141TFNotaFiscalNumero, AV142TFNotaFiscalNumero_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV148i, AV149TituloIdCol, AV152TituloIdToFind, AV153SelectAll) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV149TituloIdCol", AV149TituloIdCol);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E229M2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E239M2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV25DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TituloValor1, AV19ContaBancariaNumero1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV24ContaBancariaNumero2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28TituloValor3, AV29ContaBancariaNumero3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV156Pgmname, AV150TituloIdJson, AV15FilterFullText, AV154TFTituloCLienteRazaoSocial, AV155TFTituloCLienteRazaoSocial_Sel, AV143TFTituloPropostaDescricao, AV144TFTituloPropostaDescricao_Sel, AV121TFTituloPropostaTipo_Sels, AV44TFTituloValor, AV45TFTituloValor_To, AV46TFTituloDesconto, AV47TFTituloDesconto_To, AV59TFTituloCompetencia_F, AV60TFTituloCompetencia_F_Sel, AV61TFTituloProrrogacao, AV62TFTituloProrrogacao_To, AV78TFTituloJurosMora, AV79TFTituloJurosMora_To, AV141TFNotaFiscalNumero, AV142TFNotaFiscalNumero_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV148i, AV149TituloIdCol, AV152TituloIdToFind, AV153SelectAll) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV149TituloIdCol", AV149TituloIdCol);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E169M2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
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
         AV30DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TituloValor1, AV19ContaBancariaNumero1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV24ContaBancariaNumero2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28TituloValor3, AV29ContaBancariaNumero3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV156Pgmname, AV150TituloIdJson, AV15FilterFullText, AV154TFTituloCLienteRazaoSocial, AV155TFTituloCLienteRazaoSocial_Sel, AV143TFTituloPropostaDescricao, AV144TFTituloPropostaDescricao_Sel, AV121TFTituloPropostaTipo_Sels, AV44TFTituloValor, AV45TFTituloValor_To, AV46TFTituloDesconto, AV47TFTituloDesconto_To, AV59TFTituloCompetencia_F, AV60TFTituloCompetencia_F_Sel, AV61TFTituloProrrogacao, AV62TFTituloProrrogacao_To, AV78TFTituloJurosMora, AV79TFTituloJurosMora_To, AV141TFNotaFiscalNumero, AV142TFNotaFiscalNumero_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV148i, AV149TituloIdCol, AV152TituloIdToFind, AV153SelectAll) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV149TituloIdCol", AV149TituloIdCol);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E249M2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV22DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E179M2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
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
         AV30DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TituloValor1, AV19ContaBancariaNumero1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV24ContaBancariaNumero2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28TituloValor3, AV29ContaBancariaNumero3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV156Pgmname, AV150TituloIdJson, AV15FilterFullText, AV154TFTituloCLienteRazaoSocial, AV155TFTituloCLienteRazaoSocial_Sel, AV143TFTituloPropostaDescricao, AV144TFTituloPropostaDescricao_Sel, AV121TFTituloPropostaTipo_Sels, AV44TFTituloValor, AV45TFTituloValor_To, AV46TFTituloDesconto, AV47TFTituloDesconto_To, AV59TFTituloCompetencia_F, AV60TFTituloCompetencia_F_Sel, AV61TFTituloProrrogacao, AV62TFTituloProrrogacao_To, AV78TFTituloJurosMora, AV79TFTituloJurosMora_To, AV141TFNotaFiscalNumero, AV142TFNotaFiscalNumero_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV148i, AV149TituloIdCol, AV152TituloIdToFind, AV153SelectAll) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV149TituloIdCol", AV149TituloIdCol);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E259M2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV27DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E119M2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("WPRegistrarTituloFilters")) + "," + UrlEncode(StringUtil.RTrim(AV156Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV37ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("WPRegistrarTituloFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV37ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV36ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WPRegistrarTituloFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV36ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV156Pgmname+"GridState",  AV36ManageFiltersXml) ;
               AV10GridState.FromXml(AV36ManageFiltersXml, null, "", "");
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV121TFTituloPropostaTipo_Sels", AV121TFTituloPropostaTipo_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV149TituloIdCol", AV149TituloIdCol);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E189M2( )
      {
         /* 'DoRegistrar_titulos' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADSELECTEDROWS' */
         S252 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV146SelectedRows.Count == 0 )
         {
            GX_msglist.addItem("Nenhum registro selecionado.");
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV146SelectedRows", AV146SelectedRows);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV149TituloIdCol", AV149TituloIdCol);
      }

      protected void E199M2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new wpregistrartituloexport(context ).execute( out  AV32ExcelFilename, out  AV33ErrorMessage) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV121TFTituloPropostaTipo_Sels", AV121TFTituloPropostaTipo_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E209M2( )
      {
         /* Selectall_Click Routine */
         returnInSub = false;
         AV149TituloIdCol = (GxSimpleCollection<int>)(new GxSimpleCollection<int>());
         if ( AV153SelectAll )
         {
            /* Execute user subroutine: 'ADD ALL RECORDS' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Start For Each Line */
         nRC_GXsfl_116 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_116"), ",", "."), 18, MidpointRounding.ToEven));
         nGXsfl_116_fel_idx = 0;
         while ( nGXsfl_116_fel_idx < nRC_GXsfl_116 )
         {
            nGXsfl_116_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_116_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_116_fel_idx+1);
            sGXsfl_116_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_1162( ) ;
            AV145Selected = StringUtil.StrToBool( cgiGet( chkavSelected_Internalname));
            A261TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n261TituloId = false;
            A420TituloClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n420TituloClienteId = false;
            A972TituloCLienteRazaoSocial = StringUtil.Upper( cgiGet( edtTituloCLienteRazaoSocial_Internalname));
            n972TituloCLienteRazaoSocial = false;
            A971TituloPropostaDescricao = cgiGet( edtTituloPropostaDescricao_Internalname);
            n971TituloPropostaDescricao = false;
            cmbTituloPropostaTipo.Name = cmbTituloPropostaTipo_Internalname;
            cmbTituloPropostaTipo.CurrentValue = cgiGet( cmbTituloPropostaTipo_Internalname);
            A648TituloPropostaTipo = cgiGet( cmbTituloPropostaTipo_Internalname);
            n648TituloPropostaTipo = false;
            A262TituloValor = context.localUtil.CToN( cgiGet( edtTituloValor_Internalname), ",", ".");
            n262TituloValor = false;
            A276TituloDesconto = context.localUtil.CToN( cgiGet( edtTituloDesconto_Internalname), ",", ".");
            n276TituloDesconto = false;
            A284TituloDeleted = StringUtil.StrToBool( cgiGet( chkTituloDeleted_Internalname));
            n284TituloDeleted = false;
            A314TituloArchived = StringUtil.StrToBool( cgiGet( chkTituloArchived_Internalname));
            n314TituloArchived = false;
            A263TituloVencimento = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTituloVencimento_Internalname), 0));
            n263TituloVencimento = false;
            A287TituloCompetenciaMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloCompetenciaMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n287TituloCompetenciaMes = false;
            A286TituloCompetenciaAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloCompetenciaAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n286TituloCompetenciaAno = false;
            A295TituloCompetencia_F = cgiGet( edtTituloCompetencia_F_Internalname);
            A264TituloProrrogacao = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTituloProrrogacao_Internalname), 0));
            n264TituloProrrogacao = false;
            A265TituloCEP = cgiGet( edtTituloCEP_Internalname);
            n265TituloCEP = false;
            A266TituloLogradouro = cgiGet( edtTituloLogradouro_Internalname);
            n266TituloLogradouro = false;
            A294TituloNumeroEndereco = cgiGet( edtTituloNumeroEndereco_Internalname);
            n294TituloNumeroEndereco = false;
            A267TituloComplemento = cgiGet( edtTituloComplemento_Internalname);
            n267TituloComplemento = false;
            A268TituloBairro = cgiGet( edtTituloBairro_Internalname);
            n268TituloBairro = false;
            A269TituloMunicipio = cgiGet( edtTituloMunicipio_Internalname);
            n269TituloMunicipio = false;
            A498TituloJurosMora = context.localUtil.CToN( cgiGet( edtTituloJurosMora_Internalname), ",", ".");
            n498TituloJurosMora = false;
            cmbTituloTipo.Name = cmbTituloTipo_Internalname;
            cmbTituloTipo.CurrentValue = cgiGet( cmbTituloTipo_Internalname);
            A283TituloTipo = cgiGet( cmbTituloTipo_Internalname);
            n283TituloTipo = false;
            A419TituloPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloPropostaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n419TituloPropostaId = false;
            A501PropostaTaxaAdministrativa = context.localUtil.CToN( cgiGet( edtPropostaTaxaAdministrativa_Internalname), ",", ".");
            n501PropostaTaxaAdministrativa = false;
            A422ContaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n422ContaId = false;
            A500TituloCriacao = context.localUtil.CToT( cgiGet( edtTituloCriacao_Internalname), 0);
            n500TituloCriacao = false;
            A426CategoriaTituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCategoriaTituloId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n426CategoriaTituloId = false;
            A516TituloDataCredito_F = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTituloDataCredito_F_Internalname), 0));
            n516TituloDataCredito_F = false;
            A273TituloTotalMovimento_F = context.localUtil.CToN( cgiGet( edtTituloTotalMovimento_F_Internalname), ",", ".");
            A301TituloTotalMultaJuros_F = context.localUtil.CToN( cgiGet( edtTituloTotalMultaJuros_F_Internalname), ",", ".");
            n301TituloTotalMultaJuros_F = false;
            A275TituloSaldo_F = context.localUtil.CToN( cgiGet( edtTituloSaldo_F_Internalname), ",", ".");
            A282TituloStatus_F = cgiGet( edtTituloStatus_F_Internalname);
            A890NotaFiscalParcelamentoID = StringUtil.StrToGuid( cgiGet( edtNotaFiscalParcelamentoID_Internalname));
            n890NotaFiscalParcelamentoID = false;
            A799NotaFiscalNumero = cgiGet( edtNotaFiscalNumero_Internalname);
            n799NotaFiscalNumero = false;
            AV145Selected = AV153SelectAll;
            AssignAttri("", false, chkavSelected_Internalname, AV145Selected);
            /* End For Each Line */
         }
         if ( nGXsfl_116_fel_idx == 0 )
         {
            nGXsfl_116_idx = 1;
            sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
            SubsflControlProps_1162( ) ;
         }
         nGXsfl_116_fel_idx = 1;
         AV150TituloIdJson = AV149TituloIdCol.ToJSonString(false);
         AssignAttri("", false, "AV150TituloIdJson", AV150TituloIdJson);
         divLayoutmaintable_Class = "Table TableWithSelectableGrid"+((AV149TituloIdCol.Count>0) ? " WWPMultiRowSelected" : "");
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV149TituloIdCol", AV149TituloIdCol);
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S192( )
      {
         /* 'GETINDEXOFSELECTEDROW' Routine */
         returnInSub = false;
         AV148i = 1;
         AssignAttri("", false, "AV148i", StringUtil.LTrimStr( (decimal)(AV148i), 10, 0));
         AV190GXV1 = 1;
         while ( AV190GXV1 <= AV149TituloIdCol.Count )
         {
            AV151TituloIdColItem = (int)(AV149TituloIdCol.GetNumeric(AV190GXV1));
            AssignAttri("", false, "AV151TituloIdColItem", StringUtil.LTrimStr( (decimal)(AV151TituloIdColItem), 9, 0));
            if ( AV151TituloIdColItem == AV152TituloIdToFind )
            {
               if (true) break;
            }
            AV148i = (long)(AV148i+1);
            AssignAttri("", false, "AV148i", StringUtil.LTrimStr( (decimal)(AV148i), 10, 0));
            AV190GXV1 = (int)(AV190GXV1+1);
         }
         if ( AV148i > AV149TituloIdCol.Count )
         {
            AV148i = 0;
            AssignAttri("", false, "AV148i", StringUtil.LTrimStr( (decimal)(AV148i), 10, 0));
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavTitulovalor1_Visible = 0;
         AssignProp("", false, edtavTitulovalor1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTitulovalor1_Visible), 5, 0), true);
         edtavContabancarianumero1_Visible = 0;
         AssignProp("", false, edtavContabancarianumero1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancarianumero1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "TITULOVALOR") == 0 )
         {
            edtavTitulovalor1_Visible = 1;
            AssignProp("", false, edtavTitulovalor1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTitulovalor1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONTABANCARIANUMERO") == 0 )
         {
            edtavContabancarianumero1_Visible = 1;
            AssignProp("", false, edtavContabancarianumero1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancarianumero1_Visible), 5, 0), true);
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
         edtavContabancarianumero2_Visible = 0;
         AssignProp("", false, edtavContabancarianumero2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancarianumero2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "TITULOVALOR") == 0 )
         {
            edtavTitulovalor2_Visible = 1;
            AssignProp("", false, edtavTitulovalor2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTitulovalor2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "CONTABANCARIANUMERO") == 0 )
         {
            edtavContabancarianumero2_Visible = 1;
            AssignProp("", false, edtavContabancarianumero2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancarianumero2_Visible), 5, 0), true);
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
         edtavContabancarianumero3_Visible = 0;
         AssignProp("", false, edtavContabancarianumero3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancarianumero3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TITULOVALOR") == 0 )
         {
            edtavTitulovalor3_Visible = 1;
            AssignProp("", false, edtavTitulovalor3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTitulovalor3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CONTABANCARIANUMERO") == 0 )
         {
            edtavContabancarianumero3_Visible = 1;
            AssignProp("", false, edtavContabancarianumero3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContabancarianumero3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S212( )
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
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         AV26DynamicFiltersSelector3 = "TITULOVALOR";
         AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         AV27DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AV28TituloValor3 = 0;
         AssignAttri("", false, "AV28TituloValor3", StringUtil.LTrimStr( AV28TituloValor3, 18, 2));
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV35ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WPRegistrarTituloFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV35ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S232( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV154TFTituloCLienteRazaoSocial = "";
         AssignAttri("", false, "AV154TFTituloCLienteRazaoSocial", AV154TFTituloCLienteRazaoSocial);
         AV155TFTituloCLienteRazaoSocial_Sel = "";
         AssignAttri("", false, "AV155TFTituloCLienteRazaoSocial_Sel", AV155TFTituloCLienteRazaoSocial_Sel);
         AV143TFTituloPropostaDescricao = "";
         AssignAttri("", false, "AV143TFTituloPropostaDescricao", AV143TFTituloPropostaDescricao);
         AV144TFTituloPropostaDescricao_Sel = "";
         AssignAttri("", false, "AV144TFTituloPropostaDescricao_Sel", AV144TFTituloPropostaDescricao_Sel);
         AV121TFTituloPropostaTipo_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV44TFTituloValor = 0;
         AssignAttri("", false, "AV44TFTituloValor", StringUtil.LTrimStr( AV44TFTituloValor, 18, 2));
         AV45TFTituloValor_To = 0;
         AssignAttri("", false, "AV45TFTituloValor_To", StringUtil.LTrimStr( AV45TFTituloValor_To, 18, 2));
         AV46TFTituloDesconto = 0;
         AssignAttri("", false, "AV46TFTituloDesconto", StringUtil.LTrimStr( AV46TFTituloDesconto, 18, 2));
         AV47TFTituloDesconto_To = 0;
         AssignAttri("", false, "AV47TFTituloDesconto_To", StringUtil.LTrimStr( AV47TFTituloDesconto_To, 18, 2));
         AV59TFTituloCompetencia_F = "";
         AssignAttri("", false, "AV59TFTituloCompetencia_F", AV59TFTituloCompetencia_F);
         AV60TFTituloCompetencia_F_Sel = "";
         AssignAttri("", false, "AV60TFTituloCompetencia_F_Sel", AV60TFTituloCompetencia_F_Sel);
         AV61TFTituloProrrogacao = DateTime.MinValue;
         AssignAttri("", false, "AV61TFTituloProrrogacao", context.localUtil.Format(AV61TFTituloProrrogacao, "99/99/9999"));
         AV62TFTituloProrrogacao_To = DateTime.MinValue;
         AssignAttri("", false, "AV62TFTituloProrrogacao_To", context.localUtil.Format(AV62TFTituloProrrogacao_To, "99/99/9999"));
         AV78TFTituloJurosMora = 0;
         AssignAttri("", false, "AV78TFTituloJurosMora", StringUtil.LTrimStr( AV78TFTituloJurosMora, 16, 4));
         AV79TFTituloJurosMora_To = 0;
         AssignAttri("", false, "AV79TFTituloJurosMora_To", StringUtil.LTrimStr( AV79TFTituloJurosMora_To, 16, 4));
         AV141TFNotaFiscalNumero = "";
         AssignAttri("", false, "AV141TFNotaFiscalNumero", AV141TFNotaFiscalNumero);
         AV142TFNotaFiscalNumero_Sel = "";
         AssignAttri("", false, "AV142TFNotaFiscalNumero_Sel", AV142TFNotaFiscalNumero_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV16DynamicFiltersSelector1 = "TITULOVALOR";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AV18TituloValor1 = 0;
         AssignAttri("", false, "AV18TituloValor1", StringUtil.LTrimStr( AV18TituloValor1, 18, 2));
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
         AV10GridState.gxTpr_Dynamicfilters.Clear();
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
         /* 'LOADSELECTEDROWS' Routine */
         returnInSub = false;
         AV146SelectedRows = new GXBaseCollection<SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem>( context, "WPRegistrarTituloSDTItem", "Factory21");
         AV149TituloIdCol.FromJSonString(AV150TituloIdJson, null);
         AV191GXV2 = 1;
         while ( AV191GXV2 <= AV149TituloIdCol.Count )
         {
            AV151TituloIdColItem = (int)(AV149TituloIdCol.GetNumeric(AV191GXV2));
            AssignAttri("", false, "AV151TituloIdColItem", StringUtil.LTrimStr( (decimal)(AV151TituloIdColItem), 9, 0));
            AV147SelectedRow = new SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem(context);
            /* Using cursor H009M13 */
            pr_default.execute(2, new Object[] {AV151TituloIdColItem});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A794NotaFiscalId = H009M13_A794NotaFiscalId[0];
               n794NotaFiscalId = H009M13_n794NotaFiscalId[0];
               A261TituloId = H009M13_A261TituloId[0];
               n261TituloId = H009M13_n261TituloId[0];
               A420TituloClienteId = H009M13_A420TituloClienteId[0];
               n420TituloClienteId = H009M13_n420TituloClienteId[0];
               A972TituloCLienteRazaoSocial = H009M13_A972TituloCLienteRazaoSocial[0];
               n972TituloCLienteRazaoSocial = H009M13_n972TituloCLienteRazaoSocial[0];
               A971TituloPropostaDescricao = H009M13_A971TituloPropostaDescricao[0];
               n971TituloPropostaDescricao = H009M13_n971TituloPropostaDescricao[0];
               A648TituloPropostaTipo = H009M13_A648TituloPropostaTipo[0];
               n648TituloPropostaTipo = H009M13_n648TituloPropostaTipo[0];
               A284TituloDeleted = H009M13_A284TituloDeleted[0];
               n284TituloDeleted = H009M13_n284TituloDeleted[0];
               A314TituloArchived = H009M13_A314TituloArchived[0];
               n314TituloArchived = H009M13_n314TituloArchived[0];
               A263TituloVencimento = H009M13_A263TituloVencimento[0];
               n263TituloVencimento = H009M13_n263TituloVencimento[0];
               A264TituloProrrogacao = H009M13_A264TituloProrrogacao[0];
               n264TituloProrrogacao = H009M13_n264TituloProrrogacao[0];
               A265TituloCEP = H009M13_A265TituloCEP[0];
               n265TituloCEP = H009M13_n265TituloCEP[0];
               A266TituloLogradouro = H009M13_A266TituloLogradouro[0];
               n266TituloLogradouro = H009M13_n266TituloLogradouro[0];
               A294TituloNumeroEndereco = H009M13_A294TituloNumeroEndereco[0];
               n294TituloNumeroEndereco = H009M13_n294TituloNumeroEndereco[0];
               A267TituloComplemento = H009M13_A267TituloComplemento[0];
               n267TituloComplemento = H009M13_n267TituloComplemento[0];
               A268TituloBairro = H009M13_A268TituloBairro[0];
               n268TituloBairro = H009M13_n268TituloBairro[0];
               A269TituloMunicipio = H009M13_A269TituloMunicipio[0];
               n269TituloMunicipio = H009M13_n269TituloMunicipio[0];
               A498TituloJurosMora = H009M13_A498TituloJurosMora[0];
               n498TituloJurosMora = H009M13_n498TituloJurosMora[0];
               A283TituloTipo = H009M13_A283TituloTipo[0];
               n283TituloTipo = H009M13_n283TituloTipo[0];
               A419TituloPropostaId = H009M13_A419TituloPropostaId[0];
               n419TituloPropostaId = H009M13_n419TituloPropostaId[0];
               A501PropostaTaxaAdministrativa = H009M13_A501PropostaTaxaAdministrativa[0];
               n501PropostaTaxaAdministrativa = H009M13_n501PropostaTaxaAdministrativa[0];
               A422ContaId = H009M13_A422ContaId[0];
               n422ContaId = H009M13_n422ContaId[0];
               A500TituloCriacao = H009M13_A500TituloCriacao[0];
               n500TituloCriacao = H009M13_n500TituloCriacao[0];
               A426CategoriaTituloId = H009M13_A426CategoriaTituloId[0];
               n426CategoriaTituloId = H009M13_n426CategoriaTituloId[0];
               A890NotaFiscalParcelamentoID = H009M13_A890NotaFiscalParcelamentoID[0];
               n890NotaFiscalParcelamentoID = H009M13_n890NotaFiscalParcelamentoID[0];
               A799NotaFiscalNumero = H009M13_A799NotaFiscalNumero[0];
               n799NotaFiscalNumero = H009M13_n799NotaFiscalNumero[0];
               A516TituloDataCredito_F = H009M13_A516TituloDataCredito_F[0];
               n516TituloDataCredito_F = H009M13_n516TituloDataCredito_F[0];
               A301TituloTotalMultaJuros_F = H009M13_A301TituloTotalMultaJuros_F[0];
               n301TituloTotalMultaJuros_F = H009M13_n301TituloTotalMultaJuros_F[0];
               A273TituloTotalMovimento_F = H009M13_A273TituloTotalMovimento_F[0];
               A276TituloDesconto = H009M13_A276TituloDesconto[0];
               n276TituloDesconto = H009M13_n276TituloDesconto[0];
               A262TituloValor = H009M13_A262TituloValor[0];
               n262TituloValor = H009M13_n262TituloValor[0];
               A286TituloCompetenciaAno = H009M13_A286TituloCompetenciaAno[0];
               n286TituloCompetenciaAno = H009M13_n286TituloCompetenciaAno[0];
               A287TituloCompetenciaMes = H009M13_A287TituloCompetenciaMes[0];
               n287TituloCompetenciaMes = H009M13_n287TituloCompetenciaMes[0];
               A516TituloDataCredito_F = H009M13_A516TituloDataCredito_F[0];
               n516TituloDataCredito_F = H009M13_n516TituloDataCredito_F[0];
               A273TituloTotalMovimento_F = H009M13_A273TituloTotalMovimento_F[0];
               A301TituloTotalMultaJuros_F = H009M13_A301TituloTotalMultaJuros_F[0];
               n301TituloTotalMultaJuros_F = H009M13_n301TituloTotalMultaJuros_F[0];
               A972TituloCLienteRazaoSocial = H009M13_A972TituloCLienteRazaoSocial[0];
               n972TituloCLienteRazaoSocial = H009M13_n972TituloCLienteRazaoSocial[0];
               A971TituloPropostaDescricao = H009M13_A971TituloPropostaDescricao[0];
               n971TituloPropostaDescricao = H009M13_n971TituloPropostaDescricao[0];
               A501PropostaTaxaAdministrativa = H009M13_A501PropostaTaxaAdministrativa[0];
               n501PropostaTaxaAdministrativa = H009M13_n501PropostaTaxaAdministrativa[0];
               A794NotaFiscalId = H009M13_A794NotaFiscalId[0];
               n794NotaFiscalId = H009M13_n794NotaFiscalId[0];
               A799NotaFiscalNumero = H009M13_A799NotaFiscalNumero[0];
               n799NotaFiscalNumero = H009M13_n799NotaFiscalNumero[0];
               A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
               A275TituloSaldo_F = (decimal)((A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F);
               A282TituloStatus_F = ((Convert.ToDecimal(0)==A275TituloSaldo_F) ? "Liquidado" : ((A275TituloSaldo_F==A262TituloValor) ? "Aberto" : "Baixado parcialmente"));
               AV147SelectedRow.gxTpr_Tituloid = A261TituloId;
               AV147SelectedRow.gxTpr_Tituloclienteid = A420TituloClienteId;
               AV147SelectedRow.gxTpr_Tituloclienterazaosocial = A972TituloCLienteRazaoSocial;
               AV147SelectedRow.gxTpr_Titulopropostadescricao = A971TituloPropostaDescricao;
               AV147SelectedRow.gxTpr_Titulopropostatipo = A648TituloPropostaTipo;
               AV147SelectedRow.gxTpr_Titulovalor = A262TituloValor;
               AV147SelectedRow.gxTpr_Titulodesconto = A276TituloDesconto;
               AV147SelectedRow.gxTpr_Titulodeleted = A284TituloDeleted;
               AV147SelectedRow.gxTpr_Tituloarchived = A314TituloArchived;
               AV147SelectedRow.gxTpr_Titulovencimento = A263TituloVencimento;
               AV147SelectedRow.gxTpr_Titulocompetenciames = A287TituloCompetenciaMes;
               AV147SelectedRow.gxTpr_Titulocompetenciaano = A286TituloCompetenciaAno;
               AV147SelectedRow.gxTpr_Titulocompetencia_f = A295TituloCompetencia_F;
               AV147SelectedRow.gxTpr_Tituloprorrogacao = A264TituloProrrogacao;
               AV147SelectedRow.gxTpr_Titulocep = A265TituloCEP;
               AV147SelectedRow.gxTpr_Titulologradouro = A266TituloLogradouro;
               AV147SelectedRow.gxTpr_Titulonumeroendereco = A294TituloNumeroEndereco;
               AV147SelectedRow.gxTpr_Titulocomplemento = A267TituloComplemento;
               AV147SelectedRow.gxTpr_Titulobairro = A268TituloBairro;
               AV147SelectedRow.gxTpr_Titulomunicipio = A269TituloMunicipio;
               AV147SelectedRow.gxTpr_Titulojurosmora = A498TituloJurosMora;
               AV147SelectedRow.gxTpr_Titulotipo = A283TituloTipo;
               AV147SelectedRow.gxTpr_Titulopropostaid = A419TituloPropostaId;
               AV147SelectedRow.gxTpr_Propostataxaadministrativa = A501PropostaTaxaAdministrativa;
               AV147SelectedRow.gxTpr_Contaid = A422ContaId;
               AV147SelectedRow.gxTpr_Titulocriacao = A500TituloCriacao;
               AV147SelectedRow.gxTpr_Categoriatituloid = A426CategoriaTituloId;
               AV147SelectedRow.gxTpr_Titulodatacredito_f = A516TituloDataCredito_F;
               AV147SelectedRow.gxTpr_Titulototalmovimento_f = A273TituloTotalMovimento_F;
               AV147SelectedRow.gxTpr_Titulototalmultajuros_f = A301TituloTotalMultaJuros_F;
               AV147SelectedRow.gxTpr_Titulosaldo_f = A275TituloSaldo_F;
               AV147SelectedRow.gxTpr_Titulostatus_f = A282TituloStatus_F;
               AV147SelectedRow.gxTpr_Notafiscalparcelamentoid = A890NotaFiscalParcelamentoID;
               AV147SelectedRow.gxTpr_Notafiscalnumero = A799NotaFiscalNumero;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            AV146SelectedRows.Add(AV147SelectedRow, 0);
            AV191GXV2 = (int)(AV191GXV2+1);
         }
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV34Session.Get(AV156Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV156Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV34Session.Get(AV156Pgmname+"GridState"), null, "", "");
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV10GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV10GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S242( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV193GXV3 = 1;
         while ( AV193GXV3 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV193GXV3));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTITULOCLIENTERAZAOSOCIAL") == 0 )
            {
               AV154TFTituloCLienteRazaoSocial = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV154TFTituloCLienteRazaoSocial", AV154TFTituloCLienteRazaoSocial);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTITULOCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV155TFTituloCLienteRazaoSocial_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV155TFTituloCLienteRazaoSocial_Sel", AV155TFTituloCLienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTITULOPROPOSTADESCRICAO") == 0 )
            {
               AV143TFTituloPropostaDescricao = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV143TFTituloPropostaDescricao", AV143TFTituloPropostaDescricao);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTITULOPROPOSTADESCRICAO_SEL") == 0 )
            {
               AV144TFTituloPropostaDescricao_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV144TFTituloPropostaDescricao_Sel", AV144TFTituloPropostaDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTITULOPROPOSTATIPO_SEL") == 0 )
            {
               AV120TFTituloPropostaTipo_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV120TFTituloPropostaTipo_SelsJson", AV120TFTituloPropostaTipo_SelsJson);
               AV121TFTituloPropostaTipo_Sels.FromJSonString(AV120TFTituloPropostaTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTITULOVALOR") == 0 )
            {
               AV44TFTituloValor = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV44TFTituloValor", StringUtil.LTrimStr( AV44TFTituloValor, 18, 2));
               AV45TFTituloValor_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV45TFTituloValor_To", StringUtil.LTrimStr( AV45TFTituloValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTITULODESCONTO") == 0 )
            {
               AV46TFTituloDesconto = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV46TFTituloDesconto", StringUtil.LTrimStr( AV46TFTituloDesconto, 18, 2));
               AV47TFTituloDesconto_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV47TFTituloDesconto_To", StringUtil.LTrimStr( AV47TFTituloDesconto_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTITULOCOMPETENCIA_F") == 0 )
            {
               AV59TFTituloCompetencia_F = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV59TFTituloCompetencia_F", AV59TFTituloCompetencia_F);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTITULOCOMPETENCIA_F_SEL") == 0 )
            {
               AV60TFTituloCompetencia_F_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV60TFTituloCompetencia_F_Sel", AV60TFTituloCompetencia_F_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTITULOPRORROGACAO") == 0 )
            {
               AV61TFTituloProrrogacao = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV61TFTituloProrrogacao", context.localUtil.Format(AV61TFTituloProrrogacao, "99/99/9999"));
               AV62TFTituloProrrogacao_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV62TFTituloProrrogacao_To", context.localUtil.Format(AV62TFTituloProrrogacao_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTITULOJUROSMORA") == 0 )
            {
               AV78TFTituloJurosMora = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV78TFTituloJurosMora", StringUtil.LTrimStr( AV78TFTituloJurosMora, 16, 4));
               AV79TFTituloJurosMora_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV79TFTituloJurosMora_To", StringUtil.LTrimStr( AV79TFTituloJurosMora_To, 16, 4));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO") == 0 )
            {
               AV141TFNotaFiscalNumero = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV141TFNotaFiscalNumero", AV141TFNotaFiscalNumero);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO_SEL") == 0 )
            {
               AV142TFNotaFiscalNumero_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV142TFNotaFiscalNumero_Sel", AV142TFNotaFiscalNumero_Sel);
            }
            AV193GXV3 = (int)(AV193GXV3+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV155TFTituloCLienteRazaoSocial_Sel)),  AV155TFTituloCLienteRazaoSocial_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV144TFTituloPropostaDescricao_Sel)),  AV144TFTituloPropostaDescricao_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV121TFTituloPropostaTipo_Sels.Count==0),  AV120TFTituloPropostaTipo_SelsJson, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV60TFTituloCompetencia_F_Sel)),  AV60TFTituloCompetencia_F_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV142TFNotaFiscalNumero_Sel)),  AV142TFNotaFiscalNumero_Sel, out  GXt_char7) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|"+GXt_char5+"|||"+GXt_char6+"|||"+GXt_char7;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV154TFTituloCLienteRazaoSocial)),  AV154TFTituloCLienteRazaoSocial, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV143TFTituloPropostaDescricao)),  AV143TFTituloPropostaDescricao, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV59TFTituloCompetencia_F)),  AV59TFTituloCompetencia_F, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV141TFNotaFiscalNumero)),  AV141TFNotaFiscalNumero, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = GXt_char7+"|"+GXt_char6+"||"+((Convert.ToDecimal(0)==AV44TFTituloValor) ? "" : StringUtil.Str( AV44TFTituloValor, 18, 2))+"|"+((Convert.ToDecimal(0)==AV46TFTituloDesconto) ? "" : StringUtil.Str( AV46TFTituloDesconto, 18, 2))+"|"+GXt_char5+"|"+((DateTime.MinValue==AV61TFTituloProrrogacao) ? "" : context.localUtil.DToC( AV61TFTituloProrrogacao, 4, "/"))+"|"+((Convert.ToDecimal(0)==AV78TFTituloJurosMora) ? "" : StringUtil.Str( AV78TFTituloJurosMora, 16, 4))+"|"+GXt_char4;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|||"+((Convert.ToDecimal(0)==AV45TFTituloValor_To) ? "" : StringUtil.Str( AV45TFTituloValor_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV47TFTituloDesconto_To) ? "" : StringUtil.Str( AV47TFTituloDesconto_To, 18, 2))+"||"+((DateTime.MinValue==AV62TFTituloProrrogacao_To) ? "" : context.localUtil.DToC( AV62TFTituloProrrogacao_To, 4, "/"))+"|"+((Convert.ToDecimal(0)==AV79TFTituloJurosMora_To) ? "" : StringUtil.Str( AV79TFTituloJurosMora_To, 16, 4))+"|";
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
         if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(1));
            AV16DynamicFiltersSelector1 = AV12GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "TITULOVALOR") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV18TituloValor1 = NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, ".");
               AssignAttri("", false, "AV18TituloValor1", StringUtil.LTrimStr( AV18TituloValor1, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONTABANCARIANUMERO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV19ContaBancariaNumero1 = (long)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV19ContaBancariaNumero1", StringUtil.LTrimStr( (decimal)(AV19ContaBancariaNumero1), 18, 0));
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
               AV20DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV21DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "TITULOVALOR") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
                  AV23TituloValor2 = NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, ".");
                  AssignAttri("", false, "AV23TituloValor2", StringUtil.LTrimStr( AV23TituloValor2, 18, 2));
               }
               else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "CONTABANCARIANUMERO") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
                  AV24ContaBancariaNumero2 = (long)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV24ContaBancariaNumero2", StringUtil.LTrimStr( (decimal)(AV24ContaBancariaNumero2), 18, 0));
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
                  AV25DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TITULOVALOR") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV28TituloValor3 = NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, ".");
                     AssignAttri("", false, "AV28TituloValor3", StringUtil.LTrimStr( AV28TituloValor3, 18, 2));
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CONTABANCARIANUMERO") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV29ContaBancariaNumero3 = (long)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV29ContaBancariaNumero3", StringUtil.LTrimStr( (decimal)(AV29ContaBancariaNumero3), 18, 0));
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
         if ( AV30DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV34Session.Get(AV156Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFTITULOCLIENTERAZAOSOCIAL",  "Sacado",  !String.IsNullOrEmpty(StringUtil.RTrim( AV154TFTituloCLienteRazaoSocial)),  0,  AV154TFTituloCLienteRazaoSocial,  AV154TFTituloCLienteRazaoSocial,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV155TFTituloCLienteRazaoSocial_Sel)),  AV155TFTituloCLienteRazaoSocial_Sel,  AV155TFTituloCLienteRazaoSocial_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFTITULOPROPOSTADESCRICAO",  "Proposta",  !String.IsNullOrEmpty(StringUtil.RTrim( AV143TFTituloPropostaDescricao)),  0,  AV143TFTituloPropostaDescricao,  AV143TFTituloPropostaDescricao,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV144TFTituloPropostaDescricao_Sel)),  AV144TFTituloPropostaDescricao_Sel,  AV144TFTituloPropostaDescricao_Sel) ;
         AV140AuxText = ((AV121TFTituloPropostaTipo_Sels.Count==1) ? "["+((string)AV121TFTituloPropostaTipo_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTITULOPROPOSTATIPO_SEL",  "Tipo da proposta",  !(AV121TFTituloPropostaTipo_Sels.Count==0),  0,  AV121TFTituloPropostaTipo_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV140AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV140AuxText, "[IOF]", "IOF"), "[TAXA]", "TAXA"), "[REEMBOLSO]", "REEMBOLSO"), "[COMUM]", "COMUM")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTITULOVALOR",  "Valor",  !((Convert.ToDecimal(0)==AV44TFTituloValor)&&(Convert.ToDecimal(0)==AV45TFTituloValor_To)),  0,  StringUtil.Trim( StringUtil.Str( AV44TFTituloValor, 18, 2)),  ((Convert.ToDecimal(0)==AV44TFTituloValor) ? "" : StringUtil.Trim( context.localUtil.Format( AV44TFTituloValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV45TFTituloValor_To, 18, 2)),  ((Convert.ToDecimal(0)==AV45TFTituloValor_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV45TFTituloValor_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTITULODESCONTO",  "Desconto",  !((Convert.ToDecimal(0)==AV46TFTituloDesconto)&&(Convert.ToDecimal(0)==AV47TFTituloDesconto_To)),  0,  StringUtil.Trim( StringUtil.Str( AV46TFTituloDesconto, 18, 2)),  ((Convert.ToDecimal(0)==AV46TFTituloDesconto) ? "" : StringUtil.Trim( context.localUtil.Format( AV46TFTituloDesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV47TFTituloDesconto_To, 18, 2)),  ((Convert.ToDecimal(0)==AV47TFTituloDesconto_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV47TFTituloDesconto_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFTITULOCOMPETENCIA_F",  "Competência",  !String.IsNullOrEmpty(StringUtil.RTrim( AV59TFTituloCompetencia_F)),  0,  AV59TFTituloCompetencia_F,  AV59TFTituloCompetencia_F,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV60TFTituloCompetencia_F_Sel)),  AV60TFTituloCompetencia_F_Sel,  AV60TFTituloCompetencia_F_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTITULOPRORROGACAO",  "Vencimento",  !((DateTime.MinValue==AV61TFTituloProrrogacao)&&(DateTime.MinValue==AV62TFTituloProrrogacao_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV61TFTituloProrrogacao, 4, "/")),  ((DateTime.MinValue==AV61TFTituloProrrogacao) ? "" : StringUtil.Trim( context.localUtil.Format( AV61TFTituloProrrogacao, "99/99/9999"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV62TFTituloProrrogacao_To, 4, "/")),  ((DateTime.MinValue==AV62TFTituloProrrogacao_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV62TFTituloProrrogacao_To, "99/99/9999")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTITULOJUROSMORA",  "Juros Mora",  !((Convert.ToDecimal(0)==AV78TFTituloJurosMora)&&(Convert.ToDecimal(0)==AV79TFTituloJurosMora_To)),  0,  StringUtil.Trim( StringUtil.Str( AV78TFTituloJurosMora, 16, 4)),  ((Convert.ToDecimal(0)==AV78TFTituloJurosMora) ? "" : StringUtil.Trim( context.localUtil.Format( AV78TFTituloJurosMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"))),  true,  StringUtil.Trim( StringUtil.Str( AV79TFTituloJurosMora_To, 16, 4)),  ((Convert.ToDecimal(0)==AV79TFTituloJurosMora_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV79TFTituloJurosMora_To, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFNOTAFISCALNUMERO",  "Nota de origem",  !String.IsNullOrEmpty(StringUtil.RTrim( AV141TFNotaFiscalNumero)),  0,  AV141TFNotaFiscalNumero,  AV141TFNotaFiscalNumero,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV142TFNotaFiscalNumero_Sel)),  AV142TFNotaFiscalNumero_Sel,  AV142TFNotaFiscalNumero_Sel) ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV156Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S202( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV31DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV16DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "TITULOVALOR") == 0 ) && ! (Convert.ToDecimal(0)==AV18TituloValor1) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Valor",  AV17DynamicFiltersOperator1,  StringUtil.Trim( StringUtil.Str( AV18TituloValor1, 18, 2)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( AV18TituloValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "="+" "+StringUtil.Trim( context.localUtil.Format( AV18TituloValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99")), ">"+" "+StringUtil.Trim( context.localUtil.Format( AV18TituloValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONTABANCARIANUMERO") == 0 ) && ! (0==AV19ContaBancariaNumero1) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Número",  AV17DynamicFiltersOperator1,  StringUtil.Trim( StringUtil.Str( (decimal)(AV19ContaBancariaNumero1), 18, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV19ContaBancariaNumero1), "ZZZZZZZZZZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV19ContaBancariaNumero1), "ZZZZZZZZZZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV19ContaBancariaNumero1), "ZZZZZZZZZZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV30DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV20DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV21DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "TITULOVALOR") == 0 ) && ! (Convert.ToDecimal(0)==AV23TituloValor2) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Valor",  AV22DynamicFiltersOperator2,  StringUtil.Trim( StringUtil.Str( AV23TituloValor2, 18, 2)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( AV23TituloValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "="+" "+StringUtil.Trim( context.localUtil.Format( AV23TituloValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99")), ">"+" "+StringUtil.Trim( context.localUtil.Format( AV23TituloValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "CONTABANCARIANUMERO") == 0 ) && ! (0==AV24ContaBancariaNumero2) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Número",  AV22DynamicFiltersOperator2,  StringUtil.Trim( StringUtil.Str( (decimal)(AV24ContaBancariaNumero2), 18, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV24ContaBancariaNumero2), "ZZZZZZZZZZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV24ContaBancariaNumero2), "ZZZZZZZZZZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV24ContaBancariaNumero2), "ZZZZZZZZZZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV30DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV25DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV26DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TITULOVALOR") == 0 ) && ! (Convert.ToDecimal(0)==AV28TituloValor3) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Valor",  AV27DynamicFiltersOperator3,  StringUtil.Trim( StringUtil.Str( AV28TituloValor3, 18, 2)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( AV28TituloValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "="+" "+StringUtil.Trim( context.localUtil.Format( AV28TituloValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99")), ">"+" "+StringUtil.Trim( context.localUtil.Format( AV28TituloValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CONTABANCARIANUMERO") == 0 ) && ! (0==AV29ContaBancariaNumero3) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Número",  AV27DynamicFiltersOperator3,  StringUtil.Trim( StringUtil.Str( (decimal)(AV29ContaBancariaNumero3), 18, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV29ContaBancariaNumero3), "ZZZZZZZZZZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV29ContaBancariaNumero3), "ZZZZZZZZZZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV29ContaBancariaNumero3), "ZZZZZZZZZZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV30DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
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
         AV8TrnContext.gxTpr_Callerobject = AV156Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Titulo";
         AV34Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void S262( )
      {
         /* 'ADD ALL RECORDS' Routine */
         returnInSub = false;
         AV157Wpregistrartitulods_1_filterfulltext = AV15FilterFullText;
         AV158Wpregistrartitulods_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV159Wpregistrartitulods_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV160Wpregistrartitulods_4_titulovalor1 = AV18TituloValor1;
         AV161Wpregistrartitulods_5_contabancarianumero1 = AV19ContaBancariaNumero1;
         AV162Wpregistrartitulods_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV163Wpregistrartitulods_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV164Wpregistrartitulods_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV165Wpregistrartitulods_9_titulovalor2 = AV23TituloValor2;
         AV166Wpregistrartitulods_10_contabancarianumero2 = AV24ContaBancariaNumero2;
         AV167Wpregistrartitulods_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV168Wpregistrartitulods_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV169Wpregistrartitulods_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV170Wpregistrartitulods_14_titulovalor3 = AV28TituloValor3;
         AV171Wpregistrartitulods_15_contabancarianumero3 = AV29ContaBancariaNumero3;
         AV172Wpregistrartitulods_16_tftituloclienterazaosocial = AV154TFTituloCLienteRazaoSocial;
         AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel = AV155TFTituloCLienteRazaoSocial_Sel;
         AV174Wpregistrartitulods_18_tftitulopropostadescricao = AV143TFTituloPropostaDescricao;
         AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel = AV144TFTituloPropostaDescricao_Sel;
         AV176Wpregistrartitulods_20_tftitulopropostatipo_sels = AV121TFTituloPropostaTipo_Sels;
         AV177Wpregistrartitulods_21_tftitulovalor = AV44TFTituloValor;
         AV178Wpregistrartitulods_22_tftitulovalor_to = AV45TFTituloValor_To;
         AV179Wpregistrartitulods_23_tftitulodesconto = AV46TFTituloDesconto;
         AV180Wpregistrartitulods_24_tftitulodesconto_to = AV47TFTituloDesconto_To;
         AV181Wpregistrartitulods_25_tftitulocompetencia_f = AV59TFTituloCompetencia_F;
         AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel = AV60TFTituloCompetencia_F_Sel;
         AV183Wpregistrartitulods_27_tftituloprorrogacao = AV61TFTituloProrrogacao;
         AV184Wpregistrartitulods_28_tftituloprorrogacao_to = AV62TFTituloProrrogacao_To;
         AV185Wpregistrartitulods_29_tftitulojurosmora = AV78TFTituloJurosMora;
         AV186Wpregistrartitulods_30_tftitulojurosmora_to = AV79TFTituloJurosMora_To;
         AV187Wpregistrartitulods_31_tfnotafiscalnumero = AV141TFNotaFiscalNumero;
         AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel = AV142TFNotaFiscalNumero_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A648TituloPropostaTipo ,
                                              AV176Wpregistrartitulods_20_tftitulopropostatipo_sels ,
                                              AV158Wpregistrartitulods_2_dynamicfiltersselector1 ,
                                              AV159Wpregistrartitulods_3_dynamicfiltersoperator1 ,
                                              AV160Wpregistrartitulods_4_titulovalor1 ,
                                              AV161Wpregistrartitulods_5_contabancarianumero1 ,
                                              AV162Wpregistrartitulods_6_dynamicfiltersenabled2 ,
                                              AV163Wpregistrartitulods_7_dynamicfiltersselector2 ,
                                              AV164Wpregistrartitulods_8_dynamicfiltersoperator2 ,
                                              AV165Wpregistrartitulods_9_titulovalor2 ,
                                              AV166Wpregistrartitulods_10_contabancarianumero2 ,
                                              AV167Wpregistrartitulods_11_dynamicfiltersenabled3 ,
                                              AV168Wpregistrartitulods_12_dynamicfiltersselector3 ,
                                              AV169Wpregistrartitulods_13_dynamicfiltersoperator3 ,
                                              AV170Wpregistrartitulods_14_titulovalor3 ,
                                              AV171Wpregistrartitulods_15_contabancarianumero3 ,
                                              AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel ,
                                              AV172Wpregistrartitulods_16_tftituloclienterazaosocial ,
                                              AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel ,
                                              AV174Wpregistrartitulods_18_tftitulopropostadescricao ,
                                              AV176Wpregistrartitulods_20_tftitulopropostatipo_sels.Count ,
                                              AV177Wpregistrartitulods_21_tftitulovalor ,
                                              AV178Wpregistrartitulods_22_tftitulovalor_to ,
                                              AV179Wpregistrartitulods_23_tftitulodesconto ,
                                              AV180Wpregistrartitulods_24_tftitulodesconto_to ,
                                              AV183Wpregistrartitulods_27_tftituloprorrogacao ,
                                              AV184Wpregistrartitulods_28_tftituloprorrogacao_to ,
                                              AV185Wpregistrartitulods_29_tftitulojurosmora ,
                                              AV186Wpregistrartitulods_30_tftitulojurosmora_to ,
                                              AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel ,
                                              AV187Wpregistrartitulods_31_tfnotafiscalnumero ,
                                              A262TituloValor ,
                                              A952ContaBancariaNumero ,
                                              A972TituloCLienteRazaoSocial ,
                                              A971TituloPropostaDescricao ,
                                              A276TituloDesconto ,
                                              A264TituloProrrogacao ,
                                              A498TituloJurosMora ,
                                              A799NotaFiscalNumero ,
                                              AV157Wpregistrartitulods_1_filterfulltext ,
                                              A295TituloCompetencia_F ,
                                              AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel ,
                                              AV181Wpregistrartitulods_25_tftitulocompetencia_f ,
                                              A951ContaBancariaId ,
                                              A284TituloDeleted ,
                                              A314TituloArchived ,
                                              A275TituloSaldo_F ,
                                              A283TituloTipo } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN
                                              }
         });
         lV172Wpregistrartitulods_16_tftituloclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV172Wpregistrartitulods_16_tftituloclienterazaosocial), "%", "");
         lV174Wpregistrartitulods_18_tftitulopropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV174Wpregistrartitulods_18_tftitulopropostadescricao), "%", "");
         lV187Wpregistrartitulods_31_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV187Wpregistrartitulods_31_tfnotafiscalnumero), "%", "");
         /* Using cursor H009M15 */
         pr_default.execute(3, new Object[] {AV160Wpregistrartitulods_4_titulovalor1, AV160Wpregistrartitulods_4_titulovalor1, AV160Wpregistrartitulods_4_titulovalor1, AV161Wpregistrartitulods_5_contabancarianumero1, AV161Wpregistrartitulods_5_contabancarianumero1, AV161Wpregistrartitulods_5_contabancarianumero1, AV165Wpregistrartitulods_9_titulovalor2, AV165Wpregistrartitulods_9_titulovalor2, AV165Wpregistrartitulods_9_titulovalor2, AV166Wpregistrartitulods_10_contabancarianumero2, AV166Wpregistrartitulods_10_contabancarianumero2, AV166Wpregistrartitulods_10_contabancarianumero2, AV170Wpregistrartitulods_14_titulovalor3, AV170Wpregistrartitulods_14_titulovalor3, AV170Wpregistrartitulods_14_titulovalor3, AV171Wpregistrartitulods_15_contabancarianumero3, AV171Wpregistrartitulods_15_contabancarianumero3, AV171Wpregistrartitulods_15_contabancarianumero3, lV172Wpregistrartitulods_16_tftituloclienterazaosocial, AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel, lV174Wpregistrartitulods_18_tftitulopropostadescricao, AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel, AV177Wpregistrartitulods_21_tftitulovalor, AV178Wpregistrartitulods_22_tftitulovalor_to, AV179Wpregistrartitulods_23_tftitulodesconto, AV180Wpregistrartitulods_24_tftitulodesconto_to, AV183Wpregistrartitulods_27_tftituloprorrogacao, AV184Wpregistrartitulods_28_tftituloprorrogacao_to, AV185Wpregistrartitulods_29_tftitulojurosmora, AV186Wpregistrartitulods_30_tftitulojurosmora_to, lV187Wpregistrartitulods_31_tfnotafiscalnumero, AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A890NotaFiscalParcelamentoID = H009M15_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = H009M15_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = H009M15_A794NotaFiscalId[0];
            n794NotaFiscalId = H009M15_n794NotaFiscalId[0];
            A419TituloPropostaId = H009M15_A419TituloPropostaId[0];
            n419TituloPropostaId = H009M15_n419TituloPropostaId[0];
            A420TituloClienteId = H009M15_A420TituloClienteId[0];
            n420TituloClienteId = H009M15_n420TituloClienteId[0];
            A275TituloSaldo_F = H009M15_A275TituloSaldo_F[0];
            A283TituloTipo = H009M15_A283TituloTipo[0];
            n283TituloTipo = H009M15_n283TituloTipo[0];
            A314TituloArchived = H009M15_A314TituloArchived[0];
            n314TituloArchived = H009M15_n314TituloArchived[0];
            A284TituloDeleted = H009M15_A284TituloDeleted[0];
            n284TituloDeleted = H009M15_n284TituloDeleted[0];
            A951ContaBancariaId = H009M15_A951ContaBancariaId[0];
            n951ContaBancariaId = H009M15_n951ContaBancariaId[0];
            A498TituloJurosMora = H009M15_A498TituloJurosMora[0];
            n498TituloJurosMora = H009M15_n498TituloJurosMora[0];
            A264TituloProrrogacao = H009M15_A264TituloProrrogacao[0];
            n264TituloProrrogacao = H009M15_n264TituloProrrogacao[0];
            A952ContaBancariaNumero = H009M15_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = H009M15_n952ContaBancariaNumero[0];
            A799NotaFiscalNumero = H009M15_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = H009M15_n799NotaFiscalNumero[0];
            A648TituloPropostaTipo = H009M15_A648TituloPropostaTipo[0];
            n648TituloPropostaTipo = H009M15_n648TituloPropostaTipo[0];
            A971TituloPropostaDescricao = H009M15_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = H009M15_n971TituloPropostaDescricao[0];
            A972TituloCLienteRazaoSocial = H009M15_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = H009M15_n972TituloCLienteRazaoSocial[0];
            A261TituloId = H009M15_A261TituloId[0];
            n261TituloId = H009M15_n261TituloId[0];
            A262TituloValor = H009M15_A262TituloValor[0];
            n262TituloValor = H009M15_n262TituloValor[0];
            A276TituloDesconto = H009M15_A276TituloDesconto[0];
            n276TituloDesconto = H009M15_n276TituloDesconto[0];
            A273TituloTotalMovimento_F = H009M15_A273TituloTotalMovimento_F[0];
            A286TituloCompetenciaAno = H009M15_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = H009M15_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = H009M15_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = H009M15_n287TituloCompetenciaMes[0];
            A794NotaFiscalId = H009M15_A794NotaFiscalId[0];
            n794NotaFiscalId = H009M15_n794NotaFiscalId[0];
            A799NotaFiscalNumero = H009M15_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = H009M15_n799NotaFiscalNumero[0];
            A971TituloPropostaDescricao = H009M15_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = H009M15_n971TituloPropostaDescricao[0];
            A972TituloCLienteRazaoSocial = H009M15_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = H009M15_n972TituloCLienteRazaoSocial[0];
            A952ContaBancariaNumero = H009M15_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = H009M15_n952ContaBancariaNumero[0];
            A273TituloTotalMovimento_F = H009M15_A273TituloTotalMovimento_F[0];
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV157Wpregistrartitulods_1_filterfulltext)) || ( ( StringUtil.Like( A972TituloCLienteRazaoSocial , StringUtil.PadR( "%" + AV157Wpregistrartitulods_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( A971TituloPropostaDescricao , StringUtil.PadR( "%" + AV157Wpregistrartitulods_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( "iof" , StringUtil.PadR( "%" + StringUtil.Lower( AV157Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "IOF") == 0 ) ) || ( StringUtil.Like( "taxa" , StringUtil.PadR( "%" + StringUtil.Lower( AV157Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "TAXA") == 0 ) ) || ( StringUtil.Like( "reembolso" , StringUtil.PadR( "%" + StringUtil.Lower( AV157Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "REEMBOLSO") == 0 ) ) || ( StringUtil.Like( "comum" , StringUtil.PadR( "%" + StringUtil.Lower( AV157Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "COMUM") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV157Wpregistrartitulods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV157Wpregistrartitulods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV157Wpregistrartitulods_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A498TituloJurosMora, 16, 4) , StringUtil.PadR( "%" + AV157Wpregistrartitulods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A799NotaFiscalNumero , StringUtil.PadR( "%" + AV157Wpregistrartitulods_1_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV181Wpregistrartitulods_25_tftitulocompetencia_f)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV181Wpregistrartitulods_25_tftitulocompetencia_f , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel)) && ! ( StringUtil.StrCmp(AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
                     {
                        AV149TituloIdCol.Add(A261TituloId, 0);
                     }
                  }
               }
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void wb_table3_95_9M2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "", true, 0, "HLP_WPRegistrarTitulo.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_titulovalor3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitulovalor3_Internalname, "Titulo Valor3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitulovalor3_Internalname, StringUtil.LTrim( StringUtil.NToC( AV28TituloValor3, 18, 2, ",", "")), StringUtil.LTrim( ((edtavTitulovalor3_Enabled!=0) ? context.localUtil.Format( AV28TituloValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV28TituloValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,102);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitulovalor3_Jsonclick, 0, "Attribute", "", "", "", "", edtavTitulovalor3_Visible, edtavTitulovalor3_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPRegistrarTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contabancarianumero3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContabancarianumero3_Internalname, "Conta Bancaria Numero3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContabancarianumero3_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29ContaBancariaNumero3), 18, 0, ",", "")), StringUtil.LTrim( ((edtavContabancarianumero3_Enabled!=0) ? context.localUtil.Format( (decimal)(AV29ContaBancariaNumero3), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV29ContaBancariaNumero3), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,105);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContabancarianumero3_Jsonclick, 0, "Attribute", "", "", "", "", edtavContabancarianumero3_Visible, edtavContabancarianumero3_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPRegistrarTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPRegistrarTitulo.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_95_9M2e( true) ;
         }
         else
         {
            wb_table3_95_9M2e( false) ;
         }
      }

      protected void wb_table2_70_9M2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "", true, 0, "HLP_WPRegistrarTitulo.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitulovalor2_Internalname, StringUtil.LTrim( StringUtil.NToC( AV23TituloValor2, 18, 2, ",", "")), StringUtil.LTrim( ((edtavTitulovalor2_Enabled!=0) ? context.localUtil.Format( AV23TituloValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV23TituloValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitulovalor2_Jsonclick, 0, "Attribute", "", "", "", "", edtavTitulovalor2_Visible, edtavTitulovalor2_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPRegistrarTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contabancarianumero2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContabancarianumero2_Internalname, "Conta Bancaria Numero2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContabancarianumero2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24ContaBancariaNumero2), 18, 0, ",", "")), StringUtil.LTrim( ((edtavContabancarianumero2_Enabled!=0) ? context.localUtil.Format( (decimal)(AV24ContaBancariaNumero2), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV24ContaBancariaNumero2), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,80);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContabancarianumero2_Jsonclick, 0, "Attribute", "", "", "", "", edtavContabancarianumero2_Visible, edtavContabancarianumero2_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPRegistrarTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPRegistrarTitulo.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPRegistrarTitulo.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_70_9M2e( true) ;
         }
         else
         {
            wb_table2_70_9M2e( false) ;
         }
      }

      protected void wb_table1_45_9M2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_WPRegistrarTitulo.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_titulovalor1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitulovalor1_Internalname, "Titulo Valor1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitulovalor1_Internalname, StringUtil.LTrim( StringUtil.NToC( AV18TituloValor1, 18, 2, ",", "")), StringUtil.LTrim( ((edtavTitulovalor1_Enabled!=0) ? context.localUtil.Format( AV18TituloValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV18TituloValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitulovalor1_Jsonclick, 0, "Attribute", "", "", "", "", edtavTitulovalor1_Visible, edtavTitulovalor1_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPRegistrarTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contabancarianumero1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContabancarianumero1_Internalname, "Conta Bancaria Numero1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContabancarianumero1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ContaBancariaNumero1), 18, 0, ",", "")), StringUtil.LTrim( ((edtavContabancarianumero1_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19ContaBancariaNumero1), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV19ContaBancariaNumero1), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContabancarianumero1_Jsonclick, 0, "Attribute", "", "", "", "", edtavContabancarianumero1_Visible, edtavContabancarianumero1_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPRegistrarTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPRegistrarTitulo.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPRegistrarTitulo.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_45_9M2e( true) ;
         }
         else
         {
            wb_table1_45_9M2e( false) ;
         }
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
         PA9M2( ) ;
         WS9M2( ) ;
         WE9M2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019291752", true, true);
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
         context.AddJavascriptSource("wpregistrartitulo.js", "?202561019291753", false, true);
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
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1162( )
      {
         chkavSelected_Internalname = "vSELECTED_"+sGXsfl_116_idx;
         edtTituloId_Internalname = "TITULOID_"+sGXsfl_116_idx;
         edtTituloClienteId_Internalname = "TITULOCLIENTEID_"+sGXsfl_116_idx;
         edtTituloCLienteRazaoSocial_Internalname = "TITULOCLIENTERAZAOSOCIAL_"+sGXsfl_116_idx;
         edtTituloPropostaDescricao_Internalname = "TITULOPROPOSTADESCRICAO_"+sGXsfl_116_idx;
         cmbTituloPropostaTipo_Internalname = "TITULOPROPOSTATIPO_"+sGXsfl_116_idx;
         edtTituloValor_Internalname = "TITULOVALOR_"+sGXsfl_116_idx;
         edtTituloDesconto_Internalname = "TITULODESCONTO_"+sGXsfl_116_idx;
         chkTituloDeleted_Internalname = "TITULODELETED_"+sGXsfl_116_idx;
         chkTituloArchived_Internalname = "TITULOARCHIVED_"+sGXsfl_116_idx;
         edtTituloVencimento_Internalname = "TITULOVENCIMENTO_"+sGXsfl_116_idx;
         edtTituloCompetenciaMes_Internalname = "TITULOCOMPETENCIAMES_"+sGXsfl_116_idx;
         edtTituloCompetenciaAno_Internalname = "TITULOCOMPETENCIAANO_"+sGXsfl_116_idx;
         edtTituloCompetencia_F_Internalname = "TITULOCOMPETENCIA_F_"+sGXsfl_116_idx;
         edtTituloProrrogacao_Internalname = "TITULOPRORROGACAO_"+sGXsfl_116_idx;
         edtTituloCEP_Internalname = "TITULOCEP_"+sGXsfl_116_idx;
         edtTituloLogradouro_Internalname = "TITULOLOGRADOURO_"+sGXsfl_116_idx;
         edtTituloNumeroEndereco_Internalname = "TITULONUMEROENDERECO_"+sGXsfl_116_idx;
         edtTituloComplemento_Internalname = "TITULOCOMPLEMENTO_"+sGXsfl_116_idx;
         edtTituloBairro_Internalname = "TITULOBAIRRO_"+sGXsfl_116_idx;
         edtTituloMunicipio_Internalname = "TITULOMUNICIPIO_"+sGXsfl_116_idx;
         edtTituloJurosMora_Internalname = "TITULOJUROSMORA_"+sGXsfl_116_idx;
         cmbTituloTipo_Internalname = "TITULOTIPO_"+sGXsfl_116_idx;
         edtTituloPropostaId_Internalname = "TITULOPROPOSTAID_"+sGXsfl_116_idx;
         edtPropostaTaxaAdministrativa_Internalname = "PROPOSTATAXAADMINISTRATIVA_"+sGXsfl_116_idx;
         edtContaId_Internalname = "CONTAID_"+sGXsfl_116_idx;
         edtTituloCriacao_Internalname = "TITULOCRIACAO_"+sGXsfl_116_idx;
         edtCategoriaTituloId_Internalname = "CATEGORIATITULOID_"+sGXsfl_116_idx;
         edtTituloDataCredito_F_Internalname = "TITULODATACREDITO_F_"+sGXsfl_116_idx;
         edtTituloTotalMovimento_F_Internalname = "TITULOTOTALMOVIMENTO_F_"+sGXsfl_116_idx;
         edtTituloTotalMultaJuros_F_Internalname = "TITULOTOTALMULTAJUROS_F_"+sGXsfl_116_idx;
         edtTituloSaldo_F_Internalname = "TITULOSALDO_F_"+sGXsfl_116_idx;
         edtTituloStatus_F_Internalname = "TITULOSTATUS_F_"+sGXsfl_116_idx;
         edtNotaFiscalParcelamentoID_Internalname = "NOTAFISCALPARCELAMENTOID_"+sGXsfl_116_idx;
         edtNotaFiscalNumero_Internalname = "NOTAFISCALNUMERO_"+sGXsfl_116_idx;
      }

      protected void SubsflControlProps_fel_1162( )
      {
         chkavSelected_Internalname = "vSELECTED_"+sGXsfl_116_fel_idx;
         edtTituloId_Internalname = "TITULOID_"+sGXsfl_116_fel_idx;
         edtTituloClienteId_Internalname = "TITULOCLIENTEID_"+sGXsfl_116_fel_idx;
         edtTituloCLienteRazaoSocial_Internalname = "TITULOCLIENTERAZAOSOCIAL_"+sGXsfl_116_fel_idx;
         edtTituloPropostaDescricao_Internalname = "TITULOPROPOSTADESCRICAO_"+sGXsfl_116_fel_idx;
         cmbTituloPropostaTipo_Internalname = "TITULOPROPOSTATIPO_"+sGXsfl_116_fel_idx;
         edtTituloValor_Internalname = "TITULOVALOR_"+sGXsfl_116_fel_idx;
         edtTituloDesconto_Internalname = "TITULODESCONTO_"+sGXsfl_116_fel_idx;
         chkTituloDeleted_Internalname = "TITULODELETED_"+sGXsfl_116_fel_idx;
         chkTituloArchived_Internalname = "TITULOARCHIVED_"+sGXsfl_116_fel_idx;
         edtTituloVencimento_Internalname = "TITULOVENCIMENTO_"+sGXsfl_116_fel_idx;
         edtTituloCompetenciaMes_Internalname = "TITULOCOMPETENCIAMES_"+sGXsfl_116_fel_idx;
         edtTituloCompetenciaAno_Internalname = "TITULOCOMPETENCIAANO_"+sGXsfl_116_fel_idx;
         edtTituloCompetencia_F_Internalname = "TITULOCOMPETENCIA_F_"+sGXsfl_116_fel_idx;
         edtTituloProrrogacao_Internalname = "TITULOPRORROGACAO_"+sGXsfl_116_fel_idx;
         edtTituloCEP_Internalname = "TITULOCEP_"+sGXsfl_116_fel_idx;
         edtTituloLogradouro_Internalname = "TITULOLOGRADOURO_"+sGXsfl_116_fel_idx;
         edtTituloNumeroEndereco_Internalname = "TITULONUMEROENDERECO_"+sGXsfl_116_fel_idx;
         edtTituloComplemento_Internalname = "TITULOCOMPLEMENTO_"+sGXsfl_116_fel_idx;
         edtTituloBairro_Internalname = "TITULOBAIRRO_"+sGXsfl_116_fel_idx;
         edtTituloMunicipio_Internalname = "TITULOMUNICIPIO_"+sGXsfl_116_fel_idx;
         edtTituloJurosMora_Internalname = "TITULOJUROSMORA_"+sGXsfl_116_fel_idx;
         cmbTituloTipo_Internalname = "TITULOTIPO_"+sGXsfl_116_fel_idx;
         edtTituloPropostaId_Internalname = "TITULOPROPOSTAID_"+sGXsfl_116_fel_idx;
         edtPropostaTaxaAdministrativa_Internalname = "PROPOSTATAXAADMINISTRATIVA_"+sGXsfl_116_fel_idx;
         edtContaId_Internalname = "CONTAID_"+sGXsfl_116_fel_idx;
         edtTituloCriacao_Internalname = "TITULOCRIACAO_"+sGXsfl_116_fel_idx;
         edtCategoriaTituloId_Internalname = "CATEGORIATITULOID_"+sGXsfl_116_fel_idx;
         edtTituloDataCredito_F_Internalname = "TITULODATACREDITO_F_"+sGXsfl_116_fel_idx;
         edtTituloTotalMovimento_F_Internalname = "TITULOTOTALMOVIMENTO_F_"+sGXsfl_116_fel_idx;
         edtTituloTotalMultaJuros_F_Internalname = "TITULOTOTALMULTAJUROS_F_"+sGXsfl_116_fel_idx;
         edtTituloSaldo_F_Internalname = "TITULOSALDO_F_"+sGXsfl_116_fel_idx;
         edtTituloStatus_F_Internalname = "TITULOSTATUS_F_"+sGXsfl_116_fel_idx;
         edtNotaFiscalParcelamentoID_Internalname = "NOTAFISCALPARCELAMENTOID_"+sGXsfl_116_fel_idx;
         edtNotaFiscalNumero_Internalname = "NOTAFISCALNUMERO_"+sGXsfl_116_fel_idx;
      }

      protected void sendrow_1162( )
      {
         sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
         SubsflControlProps_1162( ) ;
         WB9M0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_116_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_116_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_116_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'" + sGXsfl_116_idx + "',116)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "vSELECTED_" + sGXsfl_116_idx;
            chkavSelected.Name = GXCCtl;
            chkavSelected.WebTags = "";
            chkavSelected.Caption = "";
            AssignProp("", false, chkavSelected_Internalname, "TitleCaption", chkavSelected.Caption, !bGXsfl_116_Refreshing);
            chkavSelected.CheckedValue = "false";
            AV145Selected = StringUtil.StrToBool( StringUtil.BoolToStr( AV145Selected));
            AssignAttri("", false, chkavSelected_Internalname, AV145Selected);
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavSelected_Internalname,StringUtil.BoolToStr( AV145Selected),(string)"",(string)"",(short)-1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onblur=\""+""+";gx.evt.onblur(this,117);\""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A261TituloId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A420TituloClienteId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A420TituloClienteId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloCLienteRazaoSocial_Internalname,(string)A972TituloCLienteRazaoSocial,StringUtil.RTrim( context.localUtil.Format( A972TituloCLienteRazaoSocial, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloCLienteRazaoSocial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloPropostaDescricao_Internalname,(string)A971TituloPropostaDescricao,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloPropostaDescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbTituloPropostaTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "TITULOPROPOSTATIPO_" + sGXsfl_116_idx;
               cmbTituloPropostaTipo.Name = GXCCtl;
               cmbTituloPropostaTipo.WebTags = "";
               cmbTituloPropostaTipo.addItem("IOF", "IOF", 0);
               cmbTituloPropostaTipo.addItem("TAXA", "TAXA", 0);
               cmbTituloPropostaTipo.addItem("REEMBOLSO", "REEMBOLSO", 0);
               cmbTituloPropostaTipo.addItem("COMUM", "COMUM", 0);
               if ( cmbTituloPropostaTipo.ItemCount > 0 )
               {
                  A648TituloPropostaTipo = cmbTituloPropostaTipo.getValidValue(A648TituloPropostaTipo);
                  n648TituloPropostaTipo = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbTituloPropostaTipo,(string)cmbTituloPropostaTipo_Internalname,StringUtil.RTrim( A648TituloPropostaTipo),(short)1,(string)cmbTituloPropostaTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbTituloPropostaTipo.CurrentValue = StringUtil.RTrim( A648TituloPropostaTipo);
            AssignProp("", false, cmbTituloPropostaTipo_Internalname, "Values", (string)(cmbTituloPropostaTipo.ToJavascriptSource()), !bGXsfl_116_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A262TituloValor, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A262TituloValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloDesconto_Internalname,StringUtil.LTrim( StringUtil.NToC( A276TituloDesconto, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A276TituloDesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloDesconto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "TITULODELETED_" + sGXsfl_116_idx;
            chkTituloDeleted.Name = GXCCtl;
            chkTituloDeleted.WebTags = "";
            chkTituloDeleted.Caption = "";
            AssignProp("", false, chkTituloDeleted_Internalname, "TitleCaption", chkTituloDeleted.Caption, !bGXsfl_116_Refreshing);
            chkTituloDeleted.CheckedValue = "false";
            A284TituloDeleted = StringUtil.StrToBool( StringUtil.BoolToStr( A284TituloDeleted));
            n284TituloDeleted = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTituloDeleted_Internalname,StringUtil.BoolToStr( A284TituloDeleted),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "TITULOARCHIVED_" + sGXsfl_116_idx;
            chkTituloArchived.Name = GXCCtl;
            chkTituloArchived.WebTags = "";
            chkTituloArchived.Caption = "";
            AssignProp("", false, chkTituloArchived_Internalname, "TitleCaption", chkTituloArchived.Caption, !bGXsfl_116_Refreshing);
            chkTituloArchived.CheckedValue = "false";
            A314TituloArchived = StringUtil.StrToBool( StringUtil.BoolToStr( A314TituloArchived));
            n314TituloArchived = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTituloArchived_Internalname,StringUtil.BoolToStr( A314TituloArchived),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloVencimento_Internalname,context.localUtil.Format(A263TituloVencimento, "99/99/9999"),context.localUtil.Format( A263TituloVencimento, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloVencimento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloCompetenciaMes_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A287TituloCompetenciaMes), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A287TituloCompetenciaMes), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloCompetenciaMes_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloCompetenciaAno_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A286TituloCompetenciaAno), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A286TituloCompetenciaAno), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloCompetenciaAno_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloCompetencia_F_Internalname,(string)A295TituloCompetencia_F,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloCompetencia_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloProrrogacao_Internalname,context.localUtil.Format(A264TituloProrrogacao, "99/99/9999"),context.localUtil.Format( A264TituloProrrogacao, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloProrrogacao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloCEP_Internalname,(string)A265TituloCEP,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloCEP_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloLogradouro_Internalname,(string)A266TituloLogradouro,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloLogradouro_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloNumeroEndereco_Internalname,(string)A294TituloNumeroEndereco,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloNumeroEndereco_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloComplemento_Internalname,(string)A267TituloComplemento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloComplemento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloBairro_Internalname,(string)A268TituloBairro,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloBairro_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloMunicipio_Internalname,(string)A269TituloMunicipio,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloMunicipio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloJurosMora_Internalname,StringUtil.LTrim( StringUtil.NToC( A498TituloJurosMora, 21, 4, ",", "")),StringUtil.LTrim( context.localUtil.Format( A498TituloJurosMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloJurosMora_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentual",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbTituloTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "TITULOTIPO_" + sGXsfl_116_idx;
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
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbTituloTipo,(string)cmbTituloTipo_Internalname,StringUtil.RTrim( A283TituloTipo),(short)1,(string)cmbTituloTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbTituloTipo.CurrentValue = StringUtil.RTrim( A283TituloTipo);
            AssignProp("", false, cmbTituloTipo_Internalname, "Values", (string)(cmbTituloTipo.ToJavascriptSource()), !bGXsfl_116_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloPropostaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A419TituloPropostaId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloPropostaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaTaxaAdministrativa_Internalname,StringUtil.LTrim( StringUtil.NToC( A501PropostaTaxaAdministrativa, 21, 4, ",", "")),StringUtil.LTrim( context.localUtil.Format( A501PropostaTaxaAdministrativa, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaTaxaAdministrativa_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentual",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A422ContaId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloCriacao_Internalname,context.localUtil.TToC( A500TituloCriacao, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A500TituloCriacao, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloCriacao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoriaTituloId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A426CategoriaTituloId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCategoriaTituloId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloDataCredito_F_Internalname,context.localUtil.Format(A516TituloDataCredito_F, "99/99/9999"),context.localUtil.Format( A516TituloDataCredito_F, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloDataCredito_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloTotalMovimento_F_Internalname,StringUtil.LTrim( StringUtil.NToC( A273TituloTotalMovimento_F, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A273TituloTotalMovimento_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloTotalMovimento_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloTotalMultaJuros_F_Internalname,StringUtil.LTrim( StringUtil.NToC( A301TituloTotalMultaJuros_F, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A301TituloTotalMultaJuros_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloTotalMultaJuros_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloSaldo_F_Internalname,StringUtil.LTrim( StringUtil.NToC( A275TituloSaldo_F, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A275TituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloSaldo_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloStatus_F_Internalname,(string)A282TituloStatus_F,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloStatus_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalParcelamentoID_Internalname,A890NotaFiscalParcelamentoID.ToString(),A890NotaFiscalParcelamentoID.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalParcelamentoID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)116,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalNumero_Internalname,(string)A799NotaFiscalNumero,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalNumero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes9M2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_116_idx = ((subGrid_Islastpage==1)&&(nGXsfl_116_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_116_idx+1);
            sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
            SubsflControlProps_1162( ) ;
         }
         /* End function sendrow_1162 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("TITULOVALOR", "Valor", 0);
         cmbavDynamicfiltersselector1.addItem("CONTABANCARIANUMERO", "Número", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV16DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV16DynamicFiltersSelector1);
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator1.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("TITULOVALOR", "Valor", 0);
         cmbavDynamicfiltersselector2.addItem("CONTABANCARIANUMERO", "Número", 0);
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
         cmbavDynamicfiltersselector3.addItem("CONTABANCARIANUMERO", "Número", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV26DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV26DynamicFiltersSelector3);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vSELECTED_" + sGXsfl_116_idx;
         chkavSelected.Name = GXCCtl;
         chkavSelected.WebTags = "";
         chkavSelected.Caption = "";
         AssignProp("", false, chkavSelected_Internalname, "TitleCaption", chkavSelected.Caption, !bGXsfl_116_Refreshing);
         chkavSelected.CheckedValue = "false";
         AV145Selected = StringUtil.StrToBool( StringUtil.BoolToStr( AV145Selected));
         AssignAttri("", false, chkavSelected_Internalname, AV145Selected);
         GXCCtl = "TITULOPROPOSTATIPO_" + sGXsfl_116_idx;
         cmbTituloPropostaTipo.Name = GXCCtl;
         cmbTituloPropostaTipo.WebTags = "";
         cmbTituloPropostaTipo.addItem("IOF", "IOF", 0);
         cmbTituloPropostaTipo.addItem("TAXA", "TAXA", 0);
         cmbTituloPropostaTipo.addItem("REEMBOLSO", "REEMBOLSO", 0);
         cmbTituloPropostaTipo.addItem("COMUM", "COMUM", 0);
         if ( cmbTituloPropostaTipo.ItemCount > 0 )
         {
            A648TituloPropostaTipo = cmbTituloPropostaTipo.getValidValue(A648TituloPropostaTipo);
            n648TituloPropostaTipo = false;
         }
         GXCCtl = "TITULODELETED_" + sGXsfl_116_idx;
         chkTituloDeleted.Name = GXCCtl;
         chkTituloDeleted.WebTags = "";
         chkTituloDeleted.Caption = "";
         AssignProp("", false, chkTituloDeleted_Internalname, "TitleCaption", chkTituloDeleted.Caption, !bGXsfl_116_Refreshing);
         chkTituloDeleted.CheckedValue = "false";
         A284TituloDeleted = StringUtil.StrToBool( StringUtil.BoolToStr( A284TituloDeleted));
         n284TituloDeleted = false;
         GXCCtl = "TITULOARCHIVED_" + sGXsfl_116_idx;
         chkTituloArchived.Name = GXCCtl;
         chkTituloArchived.WebTags = "";
         chkTituloArchived.Caption = "";
         AssignProp("", false, chkTituloArchived_Internalname, "TitleCaption", chkTituloArchived.Caption, !bGXsfl_116_Refreshing);
         chkTituloArchived.CheckedValue = "false";
         A314TituloArchived = StringUtil.StrToBool( StringUtil.BoolToStr( A314TituloArchived));
         n314TituloArchived = false;
         GXCCtl = "TITULOTIPO_" + sGXsfl_116_idx;
         cmbTituloTipo.Name = GXCCtl;
         cmbTituloTipo.WebTags = "";
         cmbTituloTipo.addItem("DEBITO", "Débito", 0);
         cmbTituloTipo.addItem("CREDITO", "Crédito", 0);
         if ( cmbTituloTipo.ItemCount > 0 )
         {
            A283TituloTipo = cmbTituloTipo.getValidValue(A283TituloTipo);
            n283TituloTipo = false;
         }
         chkavSelectall.Name = "vSELECTALL";
         chkavSelectall.WebTags = "";
         chkavSelectall.Caption = "";
         AssignProp("", false, chkavSelectall_Internalname, "TitleCaption", chkavSelectall.Caption, true);
         chkavSelectall.CheckedValue = "false";
         AV153SelectAll = StringUtil.StrToBool( StringUtil.BoolToStr( AV153SelectAll));
         AssignAttri("", false, "AV153SelectAll", AV153SelectAll);
         /* End function init_web_controls */
      }

      protected void StartGridControl116( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"116\">") ;
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
            if ( chkavSelected_Titleformat == 0 )
            {
               context.SendWebValue( chkavSelected.Title.Text) ;
            }
            else
            {
               context.WriteHtmlText( chkavSelected.Title.Text) ;
            }
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Cliente Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Sacado") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Proposta") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo da proposta") ;
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Título arquivado") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Vencimento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Mês") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Ano") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Competência") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Vencimento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "CEP") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Logradouro") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Numero Endereco") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Complemento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Bairro") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Municipio") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Juros Mora") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Tipo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Proposta Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Taxa Administrativa") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Criacao") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Titulo Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Data de crédito final do título") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Total movimento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Multa e Juros") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Saldo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Status_F") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Parcelamento ID") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nota de origem") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV145Selected)));
            GridColumn.AddObjectProperty("Title", StringUtil.RTrim( chkavSelected.Title.Text));
            GridColumn.AddObjectProperty("Titleformat", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavSelected_Titleformat), 4, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A420TituloClienteId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A972TituloCLienteRazaoSocial));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A971TituloPropostaDescricao));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A648TituloPropostaTipo));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A314TituloArchived)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A263TituloVencimento, "99/99/9999")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A287TituloCompetenciaMes), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A286TituloCompetenciaAno), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A295TituloCompetencia_F));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A264TituloProrrogacao, "99/99/9999")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A265TituloCEP));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A266TituloLogradouro));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A294TituloNumeroEndereco));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A267TituloComplemento));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A268TituloBairro));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A269TituloMunicipio));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A498TituloJurosMora, 21, 4, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A283TituloTipo));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A501PropostaTaxaAdministrativa, 21, 4, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A500TituloCriacao, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A516TituloDataCredito_F, "99/99/9999")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A273TituloTotalMovimento_F, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A301TituloTotalMultaJuros_F, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A275TituloSaldo_F, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A282TituloStatus_F));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A890NotaFiscalParcelamentoID.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A799NotaFiscalNumero));
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
         bttBtnexport_Internalname = "BTNEXPORT";
         bttBtnregistrar_titulos_Internalname = "BTNREGISTRAR_TITULOS";
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
         edtavContabancarianumero1_Internalname = "vCONTABANCARIANUMERO1";
         cellFilter_contabancarianumero1_cell_Internalname = "FILTER_CONTABANCARIANUMERO1_CELL";
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
         edtavContabancarianumero2_Internalname = "vCONTABANCARIANUMERO2";
         cellFilter_contabancarianumero2_cell_Internalname = "FILTER_CONTABANCARIANUMERO2_CELL";
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
         edtavContabancarianumero3_Internalname = "vCONTABANCARIANUMERO3";
         cellFilter_contabancarianumero3_cell_Internalname = "FILTER_CONTABANCARIANUMERO3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         chkavSelected_Internalname = "vSELECTED";
         edtTituloId_Internalname = "TITULOID";
         edtTituloClienteId_Internalname = "TITULOCLIENTEID";
         edtTituloCLienteRazaoSocial_Internalname = "TITULOCLIENTERAZAOSOCIAL";
         edtTituloPropostaDescricao_Internalname = "TITULOPROPOSTADESCRICAO";
         cmbTituloPropostaTipo_Internalname = "TITULOPROPOSTATIPO";
         edtTituloValor_Internalname = "TITULOVALOR";
         edtTituloDesconto_Internalname = "TITULODESCONTO";
         chkTituloDeleted_Internalname = "TITULODELETED";
         chkTituloArchived_Internalname = "TITULOARCHIVED";
         edtTituloVencimento_Internalname = "TITULOVENCIMENTO";
         edtTituloCompetenciaMes_Internalname = "TITULOCOMPETENCIAMES";
         edtTituloCompetenciaAno_Internalname = "TITULOCOMPETENCIAANO";
         edtTituloCompetencia_F_Internalname = "TITULOCOMPETENCIA_F";
         edtTituloProrrogacao_Internalname = "TITULOPRORROGACAO";
         edtTituloCEP_Internalname = "TITULOCEP";
         edtTituloLogradouro_Internalname = "TITULOLOGRADOURO";
         edtTituloNumeroEndereco_Internalname = "TITULONUMEROENDERECO";
         edtTituloComplemento_Internalname = "TITULOCOMPLEMENTO";
         edtTituloBairro_Internalname = "TITULOBAIRRO";
         edtTituloMunicipio_Internalname = "TITULOMUNICIPIO";
         edtTituloJurosMora_Internalname = "TITULOJUROSMORA";
         cmbTituloTipo_Internalname = "TITULOTIPO";
         edtTituloPropostaId_Internalname = "TITULOPROPOSTAID";
         edtPropostaTaxaAdministrativa_Internalname = "PROPOSTATAXAADMINISTRATIVA";
         edtContaId_Internalname = "CONTAID";
         edtTituloCriacao_Internalname = "TITULOCRIACAO";
         edtCategoriaTituloId_Internalname = "CATEGORIATITULOID";
         edtTituloDataCredito_F_Internalname = "TITULODATACREDITO_F";
         edtTituloTotalMovimento_F_Internalname = "TITULOTOTALMOVIMENTO_F";
         edtTituloTotalMultaJuros_F_Internalname = "TITULOTOTALMULTAJUROS_F";
         edtTituloSaldo_F_Internalname = "TITULOSALDO_F";
         edtTituloStatus_F_Internalname = "TITULOSTATUS_F";
         edtNotaFiscalParcelamentoID_Internalname = "NOTAFISCALPARCELAMENTOID";
         edtNotaFiscalNumero_Internalname = "NOTAFISCALNUMERO";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         chkavSelectall_Internalname = "vSELECTALL";
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
         chkavSelectall.Caption = "";
         edtNotaFiscalNumero_Jsonclick = "";
         edtNotaFiscalParcelamentoID_Jsonclick = "";
         edtTituloStatus_F_Jsonclick = "";
         edtTituloSaldo_F_Jsonclick = "";
         edtTituloTotalMultaJuros_F_Jsonclick = "";
         edtTituloTotalMovimento_F_Jsonclick = "";
         edtTituloDataCredito_F_Jsonclick = "";
         edtCategoriaTituloId_Jsonclick = "";
         edtTituloCriacao_Jsonclick = "";
         edtContaId_Jsonclick = "";
         edtPropostaTaxaAdministrativa_Jsonclick = "";
         edtTituloPropostaId_Jsonclick = "";
         cmbTituloTipo_Jsonclick = "";
         edtTituloJurosMora_Jsonclick = "";
         edtTituloMunicipio_Jsonclick = "";
         edtTituloBairro_Jsonclick = "";
         edtTituloComplemento_Jsonclick = "";
         edtTituloNumeroEndereco_Jsonclick = "";
         edtTituloLogradouro_Jsonclick = "";
         edtTituloCEP_Jsonclick = "";
         edtTituloProrrogacao_Jsonclick = "";
         edtTituloCompetencia_F_Jsonclick = "";
         edtTituloCompetenciaAno_Jsonclick = "";
         edtTituloCompetenciaMes_Jsonclick = "";
         edtTituloVencimento_Jsonclick = "";
         chkTituloArchived.Caption = "";
         chkTituloDeleted.Caption = "";
         edtTituloDesconto_Jsonclick = "";
         edtTituloValor_Jsonclick = "";
         cmbTituloPropostaTipo_Jsonclick = "";
         edtTituloPropostaDescricao_Jsonclick = "";
         edtTituloCLienteRazaoSocial_Jsonclick = "";
         edtTituloClienteId_Jsonclick = "";
         edtTituloId_Jsonclick = "";
         chkavSelected.Caption = "";
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavContabancarianumero1_Jsonclick = "";
         edtavContabancarianumero1_Enabled = 1;
         edtavTitulovalor1_Jsonclick = "";
         edtavTitulovalor1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavContabancarianumero2_Jsonclick = "";
         edtavContabancarianumero2_Enabled = 1;
         edtavTitulovalor2_Jsonclick = "";
         edtavTitulovalor2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavContabancarianumero3_Jsonclick = "";
         edtavContabancarianumero3_Enabled = 1;
         edtavTitulovalor3_Jsonclick = "";
         edtavTitulovalor3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavContabancarianumero3_Visible = 1;
         edtavTitulovalor3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavContabancarianumero2_Visible = 1;
         edtavTitulovalor2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavContabancarianumero1_Visible = 1;
         edtavTitulovalor1_Visible = 1;
         chkavSelected.Title.Text = "";
         edtNotaFiscalNumero_Enabled = 0;
         edtNotaFiscalParcelamentoID_Enabled = 0;
         edtTituloStatus_F_Enabled = 0;
         edtTituloSaldo_F_Enabled = 0;
         edtTituloTotalMultaJuros_F_Enabled = 0;
         edtTituloTotalMovimento_F_Enabled = 0;
         edtTituloDataCredito_F_Enabled = 0;
         edtCategoriaTituloId_Enabled = 0;
         edtTituloCriacao_Enabled = 0;
         edtContaId_Enabled = 0;
         edtPropostaTaxaAdministrativa_Enabled = 0;
         edtTituloPropostaId_Enabled = 0;
         cmbTituloTipo.Enabled = 0;
         edtTituloJurosMora_Enabled = 0;
         edtTituloMunicipio_Enabled = 0;
         edtTituloBairro_Enabled = 0;
         edtTituloComplemento_Enabled = 0;
         edtTituloNumeroEndereco_Enabled = 0;
         edtTituloLogradouro_Enabled = 0;
         edtTituloCEP_Enabled = 0;
         edtTituloProrrogacao_Enabled = 0;
         edtTituloCompetencia_F_Enabled = 0;
         edtTituloCompetenciaAno_Enabled = 0;
         edtTituloCompetenciaMes_Enabled = 0;
         edtTituloVencimento_Enabled = 0;
         chkTituloArchived.Enabled = 0;
         chkTituloDeleted.Enabled = 0;
         edtTituloDesconto_Enabled = 0;
         edtTituloValor_Enabled = 0;
         cmbTituloPropostaTipo.Enabled = 0;
         edtTituloPropostaDescricao_Enabled = 0;
         edtTituloCLienteRazaoSocial_Enabled = 0;
         edtTituloClienteId_Enabled = 0;
         edtTituloId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_tituloprorrogacaoauxdatetext_Jsonclick = "";
         chkavSelectall.Visible = 1;
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         divLayoutmaintable_Class = "Table TableWithSelectableGrid";
         chkavSelected_Titleformat = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "|||18.2|18.2|||16.4|";
         Ddo_grid_Datalistproc = "WPRegistrarTituloGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||IOF:IOF,TAXA:TAXA,REEMBOLSO:REEMBOLSO,COMUM:COMUM||||||";
         Ddo_grid_Allowmultipleselection = "||T||||||";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|FixedValues|||Dynamic|||Dynamic";
         Ddo_grid_Includedatalist = "T|T|T|||T|||T";
         Ddo_grid_Filterisrange = "|||T|T||P|T|";
         Ddo_grid_Filtertype = "Character|Character||Numeric|Numeric|Character|Date|Numeric|Character";
         Ddo_grid_Includefilter = "T|T||T|T|T|T|T|T";
         Ddo_grid_Includesortasc = "T|T|T|T|T||T|T|T";
         Ddo_grid_Columnssortvalues = "2|3|4|5|6||1|7|8";
         Ddo_grid_Columnids = "3:TituloCLienteRazaoSocial|4:TituloPropostaDescricao|5:TituloPropostaTipo|6:TituloValor|7:TituloDesconto|13:TituloCompetencia_F|14:TituloProrrogacao|21:TituloJurosMora|34:NotaFiscalNumero";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV148i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV149TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV152TituloIdToFind","fld":"vTITULOIDTOFIND","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV29ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV156Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV150TituloIdJson","fld":"vTITULOIDJSON","type":"vchar"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV154TFTituloCLienteRazaoSocial","fld":"vTFTITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV155TFTituloCLienteRazaoSocial_Sel","fld":"vTFTITULOCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV143TFTituloPropostaDescricao","fld":"vTFTITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"AV144TFTituloPropostaDescricao_Sel","fld":"vTFTITULOPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV121TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV44TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV60TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV61TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV62TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV78TFTituloJurosMora","fld":"vTFTITULOJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV79TFTituloJurosMora_To","fld":"vTFTITULOJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV141TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV142TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV153SelectAll","fld":"vSELECTALL","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"chkavSelected.Title.Text","ctrl":"vSELECTED","prop":"Title"},{"av":"AV153SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"AV134GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV135GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV136GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV149TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E129M2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV29ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV156Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV150TituloIdJson","fld":"vTITULOIDJSON","type":"vchar"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV154TFTituloCLienteRazaoSocial","fld":"vTFTITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV155TFTituloCLienteRazaoSocial_Sel","fld":"vTFTITULOCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV143TFTituloPropostaDescricao","fld":"vTFTITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"AV144TFTituloPropostaDescricao_Sel","fld":"vTFTITULOPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV121TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV44TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV60TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV61TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV62TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV78TFTituloJurosMora","fld":"vTFTITULOJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV79TFTituloJurosMora_To","fld":"vTFTITULOJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV141TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV142TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV148i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV149TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV152TituloIdToFind","fld":"vTITULOIDTOFIND","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV153SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E139M2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV29ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV156Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV150TituloIdJson","fld":"vTITULOIDJSON","type":"vchar"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV154TFTituloCLienteRazaoSocial","fld":"vTFTITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV155TFTituloCLienteRazaoSocial_Sel","fld":"vTFTITULOCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV143TFTituloPropostaDescricao","fld":"vTFTITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"AV144TFTituloPropostaDescricao_Sel","fld":"vTFTITULOPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV121TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV44TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV60TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV61TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV62TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV78TFTituloJurosMora","fld":"vTFTITULOJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV79TFTituloJurosMora_To","fld":"vTFTITULOJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV141TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV142TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV148i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV149TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV152TituloIdToFind","fld":"vTITULOIDTOFIND","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV153SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E149M2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV29ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV156Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV150TituloIdJson","fld":"vTITULOIDJSON","type":"vchar"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV154TFTituloCLienteRazaoSocial","fld":"vTFTITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV155TFTituloCLienteRazaoSocial_Sel","fld":"vTFTITULOCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV143TFTituloPropostaDescricao","fld":"vTFTITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"AV144TFTituloPropostaDescricao_Sel","fld":"vTFTITULOPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV121TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV44TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV60TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV61TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV62TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV78TFTituloJurosMora","fld":"vTFTITULOJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV79TFTituloJurosMora_To","fld":"vTFTITULOJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV141TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV142TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV148i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV149TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV152TituloIdToFind","fld":"vTITULOIDTOFIND","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV153SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV141TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV142TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV78TFTituloJurosMora","fld":"vTFTITULOJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV79TFTituloJurosMora_To","fld":"vTFTITULOJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV61TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV62TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV59TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV60TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV46TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV44TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV120TFTituloPropostaTipo_SelsJson","fld":"vTFTITULOPROPOSTATIPO_SELSJSON","type":"vchar"},{"av":"AV121TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV143TFTituloPropostaDescricao","fld":"vTFTITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"AV144TFTituloPropostaDescricao_Sel","fld":"vTFTITULOPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV154TFTituloCLienteRazaoSocial","fld":"vTFTITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV155TFTituloCLienteRazaoSocial_Sel","fld":"vTFTITULOCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E289M2","iparms":[{"av":"A261TituloId","fld":"TITULOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV148i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV149TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV152TituloIdToFind","fld":"vTITULOIDTOFIND","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV145Selected","fld":"vSELECTED","type":"boolean"},{"av":"AV152TituloIdToFind","fld":"vTITULOIDTOFIND","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV148i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV151TituloIdColItem","fld":"vTITULOIDCOLITEM","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("VSELECTED.CLICK","""{"handler":"E299M2","iparms":[{"av":"AV145Selected","fld":"vSELECTED","type":"boolean"},{"av":"A261TituloId","fld":"TITULOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV149TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV148i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV152TituloIdToFind","fld":"vTITULOIDTOFIND","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("VSELECTED.CLICK",""","oparms":[{"av":"AV152TituloIdToFind","fld":"vTITULOIDTOFIND","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV149TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV150TituloIdJson","fld":"vTITULOIDJSON","type":"vchar"},{"av":"divLayoutmaintable_Class","ctrl":"LAYOUTMAINTABLE","prop":"Class"},{"av":"AV148i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV151TituloIdColItem","fld":"vTITULOIDCOLITEM","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E219M2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV29ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV156Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV150TituloIdJson","fld":"vTITULOIDJSON","type":"vchar"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV154TFTituloCLienteRazaoSocial","fld":"vTFTITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV155TFTituloCLienteRazaoSocial_Sel","fld":"vTFTITULOCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV143TFTituloPropostaDescricao","fld":"vTFTITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"AV144TFTituloPropostaDescricao_Sel","fld":"vTFTITULOPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV121TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV44TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV60TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV61TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV62TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV78TFTituloJurosMora","fld":"vTFTITULOJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV79TFTituloJurosMora_To","fld":"vTFTITULOJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV141TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV142TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV148i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV149TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV152TituloIdToFind","fld":"vTITULOIDTOFIND","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV153SelectAll","fld":"vSELECTALL","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"chkavSelected.Title.Text","ctrl":"vSELECTED","prop":"Title"},{"av":"AV153SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"AV134GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV135GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV136GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV149TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E159M2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV29ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV156Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV150TituloIdJson","fld":"vTITULOIDJSON","type":"vchar"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV154TFTituloCLienteRazaoSocial","fld":"vTFTITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV155TFTituloCLienteRazaoSocial_Sel","fld":"vTFTITULOCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV143TFTituloPropostaDescricao","fld":"vTFTITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"AV144TFTituloPropostaDescricao_Sel","fld":"vTFTITULOPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV121TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV44TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV60TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV61TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV62TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV78TFTituloJurosMora","fld":"vTFTITULOJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV79TFTituloJurosMora_To","fld":"vTFTITULOJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV141TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV142TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV148i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV149TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV152TituloIdToFind","fld":"vTITULOIDTOFIND","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV153SelectAll","fld":"vSELECTALL","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV24ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV29ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"edtavTitulovalor2_Visible","ctrl":"vTITULOVALOR2","prop":"Visible"},{"av":"edtavContabancarianumero2_Visible","ctrl":"vCONTABANCARIANUMERO2","prop":"Visible"},{"av":"edtavTitulovalor3_Visible","ctrl":"vTITULOVALOR3","prop":"Visible"},{"av":"edtavContabancarianumero3_Visible","ctrl":"vCONTABANCARIANUMERO3","prop":"Visible"},{"av":"edtavTitulovalor1_Visible","ctrl":"vTITULOVALOR1","prop":"Visible"},{"av":"edtavContabancarianumero1_Visible","ctrl":"vCONTABANCARIANUMERO1","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"chkavSelected.Title.Text","ctrl":"vSELECTED","prop":"Title"},{"av":"AV153SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"AV134GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV135GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV136GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV149TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E229M2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"edtavTitulovalor1_Visible","ctrl":"vTITULOVALOR1","prop":"Visible"},{"av":"edtavContabancarianumero1_Visible","ctrl":"vCONTABANCARIANUMERO1","prop":"Visible"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E239M2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV29ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV156Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV150TituloIdJson","fld":"vTITULOIDJSON","type":"vchar"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV154TFTituloCLienteRazaoSocial","fld":"vTFTITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV155TFTituloCLienteRazaoSocial_Sel","fld":"vTFTITULOCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV143TFTituloPropostaDescricao","fld":"vTFTITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"AV144TFTituloPropostaDescricao_Sel","fld":"vTFTITULOPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV121TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV44TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV60TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV61TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV62TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV78TFTituloJurosMora","fld":"vTFTITULOJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV79TFTituloJurosMora_To","fld":"vTFTITULOJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV141TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV142TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV148i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV149TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV152TituloIdToFind","fld":"vTITULOIDTOFIND","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV153SelectAll","fld":"vSELECTALL","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"chkavSelected.Title.Text","ctrl":"vSELECTED","prop":"Title"},{"av":"AV153SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"AV134GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV135GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV136GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV149TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E169M2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV29ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV156Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV150TituloIdJson","fld":"vTITULOIDJSON","type":"vchar"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV154TFTituloCLienteRazaoSocial","fld":"vTFTITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV155TFTituloCLienteRazaoSocial_Sel","fld":"vTFTITULOCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV143TFTituloPropostaDescricao","fld":"vTFTITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"AV144TFTituloPropostaDescricao_Sel","fld":"vTFTITULOPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV121TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV44TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV60TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV61TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV62TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV78TFTituloJurosMora","fld":"vTFTITULOJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV79TFTituloJurosMora_To","fld":"vTFTITULOJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV141TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV142TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV148i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV149TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV152TituloIdToFind","fld":"vTITULOIDTOFIND","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV153SelectAll","fld":"vSELECTALL","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV24ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV29ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"edtavTitulovalor2_Visible","ctrl":"vTITULOVALOR2","prop":"Visible"},{"av":"edtavContabancarianumero2_Visible","ctrl":"vCONTABANCARIANUMERO2","prop":"Visible"},{"av":"edtavTitulovalor3_Visible","ctrl":"vTITULOVALOR3","prop":"Visible"},{"av":"edtavContabancarianumero3_Visible","ctrl":"vCONTABANCARIANUMERO3","prop":"Visible"},{"av":"edtavTitulovalor1_Visible","ctrl":"vTITULOVALOR1","prop":"Visible"},{"av":"edtavContabancarianumero1_Visible","ctrl":"vCONTABANCARIANUMERO1","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"chkavSelected.Title.Text","ctrl":"vSELECTED","prop":"Title"},{"av":"AV153SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"AV134GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV135GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV136GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV149TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E249M2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"edtavTitulovalor2_Visible","ctrl":"vTITULOVALOR2","prop":"Visible"},{"av":"edtavContabancarianumero2_Visible","ctrl":"vCONTABANCARIANUMERO2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E179M2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV29ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV156Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV150TituloIdJson","fld":"vTITULOIDJSON","type":"vchar"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV154TFTituloCLienteRazaoSocial","fld":"vTFTITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV155TFTituloCLienteRazaoSocial_Sel","fld":"vTFTITULOCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV143TFTituloPropostaDescricao","fld":"vTFTITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"AV144TFTituloPropostaDescricao_Sel","fld":"vTFTITULOPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV121TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV44TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV60TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV61TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV62TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV78TFTituloJurosMora","fld":"vTFTITULOJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV79TFTituloJurosMora_To","fld":"vTFTITULOJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV141TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV142TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV148i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV149TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV152TituloIdToFind","fld":"vTITULOIDTOFIND","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV153SelectAll","fld":"vSELECTALL","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV24ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV29ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"edtavTitulovalor2_Visible","ctrl":"vTITULOVALOR2","prop":"Visible"},{"av":"edtavContabancarianumero2_Visible","ctrl":"vCONTABANCARIANUMERO2","prop":"Visible"},{"av":"edtavTitulovalor3_Visible","ctrl":"vTITULOVALOR3","prop":"Visible"},{"av":"edtavContabancarianumero3_Visible","ctrl":"vCONTABANCARIANUMERO3","prop":"Visible"},{"av":"edtavTitulovalor1_Visible","ctrl":"vTITULOVALOR1","prop":"Visible"},{"av":"edtavContabancarianumero1_Visible","ctrl":"vCONTABANCARIANUMERO1","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"chkavSelected.Title.Text","ctrl":"vSELECTED","prop":"Title"},{"av":"AV153SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"AV134GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV135GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV136GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV149TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E259M2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"edtavTitulovalor3_Visible","ctrl":"vTITULOVALOR3","prop":"Visible"},{"av":"edtavContabancarianumero3_Visible","ctrl":"vCONTABANCARIANUMERO3","prop":"Visible"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E119M2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV29ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV156Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV150TituloIdJson","fld":"vTITULOIDJSON","type":"vchar"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV154TFTituloCLienteRazaoSocial","fld":"vTFTITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV155TFTituloCLienteRazaoSocial_Sel","fld":"vTFTITULOCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV143TFTituloPropostaDescricao","fld":"vTFTITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"AV144TFTituloPropostaDescricao_Sel","fld":"vTFTITULOPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV121TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV44TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV60TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV61TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV62TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV78TFTituloJurosMora","fld":"vTFTITULOJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV79TFTituloJurosMora_To","fld":"vTFTITULOJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV141TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV142TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV148i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV149TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV152TituloIdToFind","fld":"vTITULOIDTOFIND","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV153SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV120TFTituloPropostaTipo_SelsJson","fld":"vTFTITULOPROPOSTATIPO_SELSJSON","type":"vchar"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV154TFTituloCLienteRazaoSocial","fld":"vTFTITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV155TFTituloCLienteRazaoSocial_Sel","fld":"vTFTITULOCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV143TFTituloPropostaDescricao","fld":"vTFTITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"AV144TFTituloPropostaDescricao_Sel","fld":"vTFTITULOPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV121TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV44TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV60TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV61TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV62TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV78TFTituloJurosMora","fld":"vTFTITULOJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV79TFTituloJurosMora_To","fld":"vTFTITULOJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV141TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV142TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV120TFTituloPropostaTipo_SelsJson","fld":"vTFTITULOPROPOSTATIPO_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV29ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"edtavTitulovalor1_Visible","ctrl":"vTITULOVALOR1","prop":"Visible"},{"av":"edtavContabancarianumero1_Visible","ctrl":"vCONTABANCARIANUMERO1","prop":"Visible"},{"av":"edtavTitulovalor2_Visible","ctrl":"vTITULOVALOR2","prop":"Visible"},{"av":"edtavContabancarianumero2_Visible","ctrl":"vCONTABANCARIANUMERO2","prop":"Visible"},{"av":"edtavTitulovalor3_Visible","ctrl":"vTITULOVALOR3","prop":"Visible"},{"av":"edtavContabancarianumero3_Visible","ctrl":"vCONTABANCARIANUMERO3","prop":"Visible"},{"av":"chkavSelected.Title.Text","ctrl":"vSELECTED","prop":"Title"},{"av":"AV153SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"AV134GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV135GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV136GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV149TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOREGISTRAR_TITULOS'","""{"handler":"E189M2","iparms":[{"av":"AV146SelectedRows","fld":"vSELECTEDROWS","type":""},{"av":"AV150TituloIdJson","fld":"vTITULOIDJSON","type":"vchar"},{"av":"A261TituloId","fld":"TITULOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A420TituloClienteId","fld":"TITULOCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A972TituloCLienteRazaoSocial","fld":"TITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"A971TituloPropostaDescricao","fld":"TITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"cmbTituloPropostaTipo"},{"av":"A648TituloPropostaTipo","fld":"TITULOPROPOSTATIPO","hsh":true,"type":"svchar"},{"av":"A262TituloValor","fld":"TITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","hsh":true,"type":"decimal"},{"av":"A276TituloDesconto","fld":"TITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","hsh":true,"type":"decimal"},{"av":"A284TituloDeleted","fld":"TITULODELETED","hsh":true,"type":"boolean"},{"av":"A314TituloArchived","fld":"TITULOARCHIVED","hsh":true,"type":"boolean"},{"av":"A263TituloVencimento","fld":"TITULOVENCIMENTO","hsh":true,"type":"date"},{"av":"A287TituloCompetenciaMes","fld":"TITULOCOMPETENCIAMES","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"A286TituloCompetenciaAno","fld":"TITULOCOMPETENCIAANO","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"A295TituloCompetencia_F","fld":"TITULOCOMPETENCIA_F","hsh":true,"type":"svchar"},{"av":"A264TituloProrrogacao","fld":"TITULOPRORROGACAO","hsh":true,"type":"date"},{"av":"A265TituloCEP","fld":"TITULOCEP","hsh":true,"type":"svchar"},{"av":"A266TituloLogradouro","fld":"TITULOLOGRADOURO","hsh":true,"type":"svchar"},{"av":"A294TituloNumeroEndereco","fld":"TITULONUMEROENDERECO","hsh":true,"type":"svchar"},{"av":"A267TituloComplemento","fld":"TITULOCOMPLEMENTO","hsh":true,"type":"svchar"},{"av":"A268TituloBairro","fld":"TITULOBAIRRO","hsh":true,"type":"svchar"},{"av":"A269TituloMunicipio","fld":"TITULOMUNICIPIO","hsh":true,"type":"svchar"},{"av":"A498TituloJurosMora","fld":"TITULOJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","hsh":true,"type":"decimal"},{"av":"cmbTituloTipo"},{"av":"A283TituloTipo","fld":"TITULOTIPO","hsh":true,"type":"svchar"},{"av":"A419TituloPropostaId","fld":"TITULOPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A501PropostaTaxaAdministrativa","fld":"PROPOSTATAXAADMINISTRATIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"A422ContaId","fld":"CONTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A500TituloCriacao","fld":"TITULOCRIACAO","pic":"99/99/99 99:99","hsh":true,"type":"dtime"},{"av":"A426CategoriaTituloId","fld":"CATEGORIATITULOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A516TituloDataCredito_F","fld":"TITULODATACREDITO_F","type":"date"},{"av":"A273TituloTotalMovimento_F","fld":"TITULOTOTALMOVIMENTO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A301TituloTotalMultaJuros_F","fld":"TITULOTOTALMULTAJUROS_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A275TituloSaldo_F","fld":"TITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","hsh":true,"type":"decimal"},{"av":"A282TituloStatus_F","fld":"TITULOSTATUS_F","hsh":true,"type":"svchar"},{"av":"A890NotaFiscalParcelamentoID","fld":"NOTAFISCALPARCELAMENTOID","hsh":true,"type":"guid"},{"av":"A799NotaFiscalNumero","fld":"NOTAFISCALNUMERO","type":"svchar"}]""");
         setEventMetadata("'DOREGISTRAR_TITULOS'",""","oparms":[{"av":"AV146SelectedRows","fld":"vSELECTEDROWS","type":""},{"av":"AV149TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV151TituloIdColItem","fld":"vTITULOIDCOLITEM","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E199M2","iparms":[{"av":"AV156Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV155TFTituloCLienteRazaoSocial_Sel","fld":"vTFTITULOCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV144TFTituloPropostaDescricao_Sel","fld":"vTFTITULOPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV121TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV120TFTituloPropostaTipo_SelsJson","fld":"vTFTITULOPROPOSTATIPO_SELSJSON","type":"vchar"},{"av":"AV60TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV142TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV154TFTituloCLienteRazaoSocial","fld":"vTFTITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV143TFTituloPropostaDescricao","fld":"vTFTITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"AV44TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV61TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV78TFTituloJurosMora","fld":"vTFTITULOJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV141TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV45TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV62TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV79TFTituloJurosMora_To","fld":"vTFTITULOJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORT'",""","oparms":[{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV29ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV156Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV150TituloIdJson","fld":"vTITULOIDJSON","type":"vchar"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV154TFTituloCLienteRazaoSocial","fld":"vTFTITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV155TFTituloCLienteRazaoSocial_Sel","fld":"vTFTITULOCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV143TFTituloPropostaDescricao","fld":"vTFTITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"AV144TFTituloPropostaDescricao_Sel","fld":"vTFTITULOPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV121TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV44TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV59TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV60TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV61TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV62TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV78TFTituloJurosMora","fld":"vTFTITULOJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV79TFTituloJurosMora_To","fld":"vTFTITULOJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV141TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV142TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV148i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV149TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV152TituloIdToFind","fld":"vTITULOIDTOFIND","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV153SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV120TFTituloPropostaTipo_SelsJson","fld":"vTFTITULOPROPOSTATIPO_SELSJSON","type":"vchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavTitulovalor1_Visible","ctrl":"vTITULOVALOR1","prop":"Visible"},{"av":"edtavContabancarianumero1_Visible","ctrl":"vCONTABANCARIANUMERO1","prop":"Visible"},{"av":"edtavTitulovalor2_Visible","ctrl":"vTITULOVALOR2","prop":"Visible"},{"av":"edtavContabancarianumero2_Visible","ctrl":"vCONTABANCARIANUMERO2","prop":"Visible"},{"av":"edtavTitulovalor3_Visible","ctrl":"vTITULOVALOR3","prop":"Visible"},{"av":"edtavContabancarianumero3_Visible","ctrl":"vCONTABANCARIANUMERO3","prop":"Visible"}]}""");
         setEventMetadata("VSELECTALL.CLICK","""{"handler":"E209M2","iparms":[{"av":"AV153SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"AV142TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV141TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV79TFTituloJurosMora_To","fld":"vTFTITULOJUROSMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV78TFTituloJurosMora","fld":"vTFTITULOJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV62TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV61TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV60TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV59TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV47TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV44TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV121TFTituloPropostaTipo_Sels","fld":"vTFTITULOPROPOSTATIPO_SELS","type":""},{"av":"AV144TFTituloPropostaDescricao_Sel","fld":"vTFTITULOPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV143TFTituloPropostaDescricao","fld":"vTFTITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"AV155TFTituloCLienteRazaoSocial_Sel","fld":"vTFTITULOCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV154TFTituloCLienteRazaoSocial","fld":"vTFTITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV29ContaBancariaNumero3","fld":"vCONTABANCARIANUMERO3","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV28TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV24ContaBancariaNumero2","fld":"vCONTABANCARIANUMERO2","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV19ContaBancariaNumero1","fld":"vCONTABANCARIANUMERO1","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV18TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"A951ContaBancariaId","fld":"CONTABANCARIAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A284TituloDeleted","fld":"TITULODELETED","grid":116,"hsh":true,"type":"boolean"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"nRC_GXsfl_116","ctrl":"GRID","prop":"GridRC","grid":116,"type":"int"},{"av":"A314TituloArchived","fld":"TITULOARCHIVED","grid":116,"hsh":true,"type":"boolean"},{"av":"A283TituloTipo","fld":"TITULOTIPO","grid":116,"hsh":true,"type":"svchar"},{"av":"A275TituloSaldo_F","fld":"TITULOSALDO_F","grid":116,"pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","hsh":true,"type":"decimal"},{"av":"A261TituloId","fld":"TITULOID","grid":116,"pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV149TituloIdCol","fld":"vTITULOIDCOL","type":""}]""");
         setEventMetadata("VSELECTALL.CLICK",""","oparms":[{"av":"AV149TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV145Selected","fld":"vSELECTED","type":"boolean"},{"av":"AV150TituloIdJson","fld":"vTITULOIDJSON","type":"vchar"},{"av":"divLayoutmaintable_Class","ctrl":"LAYOUTMAINTABLE","prop":"Class"}]}""");
         setEventMetadata("VALID_TITULOID","""{"handler":"Valid_Tituloid","iparms":[]}""");
         setEventMetadata("VALID_TITULOCLIENTEID","""{"handler":"Valid_Tituloclienteid","iparms":[]}""");
         setEventMetadata("VALID_TITULOCLIENTERAZAOSOCIAL","""{"handler":"Valid_Tituloclienterazaosocial","iparms":[]}""");
         setEventMetadata("VALID_TITULOPROPOSTADESCRICAO","""{"handler":"Valid_Titulopropostadescricao","iparms":[]}""");
         setEventMetadata("VALID_TITULOPROPOSTATIPO","""{"handler":"Valid_Titulopropostatipo","iparms":[]}""");
         setEventMetadata("VALID_TITULOVALOR","""{"handler":"Valid_Titulovalor","iparms":[]}""");
         setEventMetadata("VALID_TITULODESCONTO","""{"handler":"Valid_Titulodesconto","iparms":[]}""");
         setEventMetadata("VALID_TITULOCOMPETENCIAMES","""{"handler":"Valid_Titulocompetenciames","iparms":[]}""");
         setEventMetadata("VALID_TITULOCOMPETENCIAANO","""{"handler":"Valid_Titulocompetenciaano","iparms":[]}""");
         setEventMetadata("VALID_TITULOCOMPETENCIA_F","""{"handler":"Valid_Titulocompetencia_f","iparms":[]}""");
         setEventMetadata("VALID_TITULOJUROSMORA","""{"handler":"Valid_Titulojurosmora","iparms":[]}""");
         setEventMetadata("VALID_TITULOPROPOSTAID","""{"handler":"Valid_Titulopropostaid","iparms":[]}""");
         setEventMetadata("VALID_TITULOTOTALMOVIMENTO_F","""{"handler":"Valid_Titulototalmovimento_f","iparms":[]}""");
         setEventMetadata("VALID_TITULOSALDO_F","""{"handler":"Valid_Titulosaldo_f","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALPARCELAMENTOID","""{"handler":"Valid_Notafiscalparcelamentoid","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALNUMERO","""{"handler":"Valid_Notafiscalnumero","iparms":[]}""");
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
         AV16DynamicFiltersSelector1 = "";
         AV21DynamicFiltersSelector2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV156Pgmname = "";
         AV150TituloIdJson = "";
         AV15FilterFullText = "";
         AV154TFTituloCLienteRazaoSocial = "";
         AV155TFTituloCLienteRazaoSocial_Sel = "";
         AV143TFTituloPropostaDescricao = "";
         AV144TFTituloPropostaDescricao_Sel = "";
         AV121TFTituloPropostaTipo_Sels = new GxSimpleCollection<string>();
         AV59TFTituloCompetencia_F = "";
         AV60TFTituloCompetencia_F_Sel = "";
         AV61TFTituloProrrogacao = DateTime.MinValue;
         AV62TFTituloProrrogacao_To = DateTime.MinValue;
         AV141TFNotaFiscalNumero = "";
         AV142TFNotaFiscalNumero_Sel = "";
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV149TituloIdCol = new GxSimpleCollection<int>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV35ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV136GridAppliedFilters = "";
         AV132DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV63DDO_TituloProrrogacaoAuxDate = DateTime.MinValue;
         AV64DDO_TituloProrrogacaoAuxDateTo = DateTime.MinValue;
         AV120TFTituloPropostaTipo_SelsJson = "";
         AV146SelectedRows = new GXBaseCollection<SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem>( context, "WPRegistrarTituloSDTItem", "Factory21");
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
         bttBtnexport_Jsonclick = "";
         bttBtnregistrar_titulos_Jsonclick = "";
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
         AV65DDO_TituloProrrogacaoAuxDateText = "";
         ucTftituloprorrogacao_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A972TituloCLienteRazaoSocial = "";
         A971TituloPropostaDescricao = "";
         A648TituloPropostaTipo = "";
         A263TituloVencimento = DateTime.MinValue;
         A295TituloCompetencia_F = "";
         A264TituloProrrogacao = DateTime.MinValue;
         A265TituloCEP = "";
         A266TituloLogradouro = "";
         A294TituloNumeroEndereco = "";
         A267TituloComplemento = "";
         A268TituloBairro = "";
         A269TituloMunicipio = "";
         A283TituloTipo = "";
         A500TituloCriacao = (DateTime)(DateTime.MinValue);
         A516TituloDataCredito_F = DateTime.MinValue;
         A282TituloStatus_F = "";
         A890NotaFiscalParcelamentoID = Guid.Empty;
         A799NotaFiscalNumero = "";
         AV157Wpregistrartitulods_1_filterfulltext = "";
         AV158Wpregistrartitulods_2_dynamicfiltersselector1 = "";
         AV163Wpregistrartitulods_7_dynamicfiltersselector2 = "";
         AV168Wpregistrartitulods_12_dynamicfiltersselector3 = "";
         AV172Wpregistrartitulods_16_tftituloclienterazaosocial = "";
         AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel = "";
         AV174Wpregistrartitulods_18_tftitulopropostadescricao = "";
         AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel = "";
         AV176Wpregistrartitulods_20_tftitulopropostatipo_sels = new GxSimpleCollection<string>();
         AV181Wpregistrartitulods_25_tftitulocompetencia_f = "";
         AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel = "";
         AV183Wpregistrartitulods_27_tftituloprorrogacao = DateTime.MinValue;
         AV184Wpregistrartitulods_28_tftituloprorrogacao_to = DateTime.MinValue;
         AV187Wpregistrartitulods_31_tfnotafiscalnumero = "";
         AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel = "";
         lV157Wpregistrartitulods_1_filterfulltext = "";
         lV172Wpregistrartitulods_16_tftituloclienterazaosocial = "";
         lV174Wpregistrartitulods_18_tftitulopropostadescricao = "";
         lV187Wpregistrartitulods_31_tfnotafiscalnumero = "";
         H009M5_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         H009M5_n794NotaFiscalId = new bool[] {false} ;
         H009M5_A951ContaBancariaId = new int[1] ;
         H009M5_n951ContaBancariaId = new bool[] {false} ;
         H009M5_A952ContaBancariaNumero = new long[1] ;
         H009M5_n952ContaBancariaNumero = new bool[] {false} ;
         H009M5_A799NotaFiscalNumero = new string[] {""} ;
         H009M5_n799NotaFiscalNumero = new bool[] {false} ;
         H009M5_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         H009M5_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         H009M5_A426CategoriaTituloId = new int[1] ;
         H009M5_n426CategoriaTituloId = new bool[] {false} ;
         H009M5_A500TituloCriacao = new DateTime[] {DateTime.MinValue} ;
         H009M5_n500TituloCriacao = new bool[] {false} ;
         H009M5_A422ContaId = new int[1] ;
         H009M5_n422ContaId = new bool[] {false} ;
         H009M5_A501PropostaTaxaAdministrativa = new decimal[1] ;
         H009M5_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         H009M5_A419TituloPropostaId = new int[1] ;
         H009M5_n419TituloPropostaId = new bool[] {false} ;
         H009M5_A283TituloTipo = new string[] {""} ;
         H009M5_n283TituloTipo = new bool[] {false} ;
         H009M5_A498TituloJurosMora = new decimal[1] ;
         H009M5_n498TituloJurosMora = new bool[] {false} ;
         H009M5_A269TituloMunicipio = new string[] {""} ;
         H009M5_n269TituloMunicipio = new bool[] {false} ;
         H009M5_A268TituloBairro = new string[] {""} ;
         H009M5_n268TituloBairro = new bool[] {false} ;
         H009M5_A267TituloComplemento = new string[] {""} ;
         H009M5_n267TituloComplemento = new bool[] {false} ;
         H009M5_A294TituloNumeroEndereco = new string[] {""} ;
         H009M5_n294TituloNumeroEndereco = new bool[] {false} ;
         H009M5_A266TituloLogradouro = new string[] {""} ;
         H009M5_n266TituloLogradouro = new bool[] {false} ;
         H009M5_A265TituloCEP = new string[] {""} ;
         H009M5_n265TituloCEP = new bool[] {false} ;
         H009M5_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         H009M5_n264TituloProrrogacao = new bool[] {false} ;
         H009M5_A263TituloVencimento = new DateTime[] {DateTime.MinValue} ;
         H009M5_n263TituloVencimento = new bool[] {false} ;
         H009M5_A314TituloArchived = new bool[] {false} ;
         H009M5_n314TituloArchived = new bool[] {false} ;
         H009M5_A284TituloDeleted = new bool[] {false} ;
         H009M5_n284TituloDeleted = new bool[] {false} ;
         H009M5_A648TituloPropostaTipo = new string[] {""} ;
         H009M5_n648TituloPropostaTipo = new bool[] {false} ;
         H009M5_A971TituloPropostaDescricao = new string[] {""} ;
         H009M5_n971TituloPropostaDescricao = new bool[] {false} ;
         H009M5_A972TituloCLienteRazaoSocial = new string[] {""} ;
         H009M5_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         H009M5_A420TituloClienteId = new int[1] ;
         H009M5_n420TituloClienteId = new bool[] {false} ;
         H009M5_A261TituloId = new int[1] ;
         H009M5_n261TituloId = new bool[] {false} ;
         H009M5_A276TituloDesconto = new decimal[1] ;
         H009M5_n276TituloDesconto = new bool[] {false} ;
         H009M5_A273TituloTotalMovimento_F = new decimal[1] ;
         H009M5_A301TituloTotalMultaJuros_F = new decimal[1] ;
         H009M5_n301TituloTotalMultaJuros_F = new bool[] {false} ;
         H009M5_A516TituloDataCredito_F = new DateTime[] {DateTime.MinValue} ;
         H009M5_n516TituloDataCredito_F = new bool[] {false} ;
         H009M5_A286TituloCompetenciaAno = new short[1] ;
         H009M5_n286TituloCompetenciaAno = new bool[] {false} ;
         H009M5_A287TituloCompetenciaMes = new short[1] ;
         H009M5_n287TituloCompetenciaMes = new bool[] {false} ;
         H009M5_A262TituloValor = new decimal[1] ;
         H009M5_n262TituloValor = new bool[] {false} ;
         H009M5_A275TituloSaldo_F = new decimal[1] ;
         A794NotaFiscalId = Guid.Empty;
         H009M9_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         H009M9_n794NotaFiscalId = new bool[] {false} ;
         H009M9_A951ContaBancariaId = new int[1] ;
         H009M9_n951ContaBancariaId = new bool[] {false} ;
         H009M9_A952ContaBancariaNumero = new long[1] ;
         H009M9_n952ContaBancariaNumero = new bool[] {false} ;
         H009M9_A799NotaFiscalNumero = new string[] {""} ;
         H009M9_n799NotaFiscalNumero = new bool[] {false} ;
         H009M9_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         H009M9_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         H009M9_A426CategoriaTituloId = new int[1] ;
         H009M9_n426CategoriaTituloId = new bool[] {false} ;
         H009M9_A500TituloCriacao = new DateTime[] {DateTime.MinValue} ;
         H009M9_n500TituloCriacao = new bool[] {false} ;
         H009M9_A422ContaId = new int[1] ;
         H009M9_n422ContaId = new bool[] {false} ;
         H009M9_A501PropostaTaxaAdministrativa = new decimal[1] ;
         H009M9_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         H009M9_A419TituloPropostaId = new int[1] ;
         H009M9_n419TituloPropostaId = new bool[] {false} ;
         H009M9_A283TituloTipo = new string[] {""} ;
         H009M9_n283TituloTipo = new bool[] {false} ;
         H009M9_A498TituloJurosMora = new decimal[1] ;
         H009M9_n498TituloJurosMora = new bool[] {false} ;
         H009M9_A269TituloMunicipio = new string[] {""} ;
         H009M9_n269TituloMunicipio = new bool[] {false} ;
         H009M9_A268TituloBairro = new string[] {""} ;
         H009M9_n268TituloBairro = new bool[] {false} ;
         H009M9_A267TituloComplemento = new string[] {""} ;
         H009M9_n267TituloComplemento = new bool[] {false} ;
         H009M9_A294TituloNumeroEndereco = new string[] {""} ;
         H009M9_n294TituloNumeroEndereco = new bool[] {false} ;
         H009M9_A266TituloLogradouro = new string[] {""} ;
         H009M9_n266TituloLogradouro = new bool[] {false} ;
         H009M9_A265TituloCEP = new string[] {""} ;
         H009M9_n265TituloCEP = new bool[] {false} ;
         H009M9_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         H009M9_n264TituloProrrogacao = new bool[] {false} ;
         H009M9_A263TituloVencimento = new DateTime[] {DateTime.MinValue} ;
         H009M9_n263TituloVencimento = new bool[] {false} ;
         H009M9_A314TituloArchived = new bool[] {false} ;
         H009M9_n314TituloArchived = new bool[] {false} ;
         H009M9_A284TituloDeleted = new bool[] {false} ;
         H009M9_n284TituloDeleted = new bool[] {false} ;
         H009M9_A648TituloPropostaTipo = new string[] {""} ;
         H009M9_n648TituloPropostaTipo = new bool[] {false} ;
         H009M9_A971TituloPropostaDescricao = new string[] {""} ;
         H009M9_n971TituloPropostaDescricao = new bool[] {false} ;
         H009M9_A972TituloCLienteRazaoSocial = new string[] {""} ;
         H009M9_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         H009M9_A420TituloClienteId = new int[1] ;
         H009M9_n420TituloClienteId = new bool[] {false} ;
         H009M9_A261TituloId = new int[1] ;
         H009M9_n261TituloId = new bool[] {false} ;
         H009M9_A276TituloDesconto = new decimal[1] ;
         H009M9_n276TituloDesconto = new bool[] {false} ;
         H009M9_A273TituloTotalMovimento_F = new decimal[1] ;
         H009M9_A301TituloTotalMultaJuros_F = new decimal[1] ;
         H009M9_n301TituloTotalMultaJuros_F = new bool[] {false} ;
         H009M9_A516TituloDataCredito_F = new DateTime[] {DateTime.MinValue} ;
         H009M9_n516TituloDataCredito_F = new bool[] {false} ;
         H009M9_A286TituloCompetenciaAno = new short[1] ;
         H009M9_n286TituloCompetenciaAno = new bool[] {false} ;
         H009M9_A287TituloCompetenciaMes = new short[1] ;
         H009M9_n287TituloCompetenciaMes = new bool[] {false} ;
         H009M9_A262TituloValor = new decimal[1] ;
         H009M9_n262TituloValor = new bool[] {false} ;
         H009M9_A275TituloSaldo_F = new decimal[1] ;
         AV7HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         GXEncryptionTmp = "";
         AV36ManageFiltersXml = "";
         AV32ExcelFilename = "";
         AV33ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV147SelectedRow = new SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem(context);
         H009M13_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         H009M13_n794NotaFiscalId = new bool[] {false} ;
         H009M13_A261TituloId = new int[1] ;
         H009M13_n261TituloId = new bool[] {false} ;
         H009M13_A420TituloClienteId = new int[1] ;
         H009M13_n420TituloClienteId = new bool[] {false} ;
         H009M13_A972TituloCLienteRazaoSocial = new string[] {""} ;
         H009M13_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         H009M13_A971TituloPropostaDescricao = new string[] {""} ;
         H009M13_n971TituloPropostaDescricao = new bool[] {false} ;
         H009M13_A648TituloPropostaTipo = new string[] {""} ;
         H009M13_n648TituloPropostaTipo = new bool[] {false} ;
         H009M13_A284TituloDeleted = new bool[] {false} ;
         H009M13_n284TituloDeleted = new bool[] {false} ;
         H009M13_A314TituloArchived = new bool[] {false} ;
         H009M13_n314TituloArchived = new bool[] {false} ;
         H009M13_A263TituloVencimento = new DateTime[] {DateTime.MinValue} ;
         H009M13_n263TituloVencimento = new bool[] {false} ;
         H009M13_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         H009M13_n264TituloProrrogacao = new bool[] {false} ;
         H009M13_A265TituloCEP = new string[] {""} ;
         H009M13_n265TituloCEP = new bool[] {false} ;
         H009M13_A266TituloLogradouro = new string[] {""} ;
         H009M13_n266TituloLogradouro = new bool[] {false} ;
         H009M13_A294TituloNumeroEndereco = new string[] {""} ;
         H009M13_n294TituloNumeroEndereco = new bool[] {false} ;
         H009M13_A267TituloComplemento = new string[] {""} ;
         H009M13_n267TituloComplemento = new bool[] {false} ;
         H009M13_A268TituloBairro = new string[] {""} ;
         H009M13_n268TituloBairro = new bool[] {false} ;
         H009M13_A269TituloMunicipio = new string[] {""} ;
         H009M13_n269TituloMunicipio = new bool[] {false} ;
         H009M13_A498TituloJurosMora = new decimal[1] ;
         H009M13_n498TituloJurosMora = new bool[] {false} ;
         H009M13_A283TituloTipo = new string[] {""} ;
         H009M13_n283TituloTipo = new bool[] {false} ;
         H009M13_A419TituloPropostaId = new int[1] ;
         H009M13_n419TituloPropostaId = new bool[] {false} ;
         H009M13_A501PropostaTaxaAdministrativa = new decimal[1] ;
         H009M13_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         H009M13_A422ContaId = new int[1] ;
         H009M13_n422ContaId = new bool[] {false} ;
         H009M13_A500TituloCriacao = new DateTime[] {DateTime.MinValue} ;
         H009M13_n500TituloCriacao = new bool[] {false} ;
         H009M13_A426CategoriaTituloId = new int[1] ;
         H009M13_n426CategoriaTituloId = new bool[] {false} ;
         H009M13_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         H009M13_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         H009M13_A799NotaFiscalNumero = new string[] {""} ;
         H009M13_n799NotaFiscalNumero = new bool[] {false} ;
         H009M13_A516TituloDataCredito_F = new DateTime[] {DateTime.MinValue} ;
         H009M13_n516TituloDataCredito_F = new bool[] {false} ;
         H009M13_A301TituloTotalMultaJuros_F = new decimal[1] ;
         H009M13_n301TituloTotalMultaJuros_F = new bool[] {false} ;
         H009M13_A273TituloTotalMovimento_F = new decimal[1] ;
         H009M13_A276TituloDesconto = new decimal[1] ;
         H009M13_n276TituloDesconto = new bool[] {false} ;
         H009M13_A262TituloValor = new decimal[1] ;
         H009M13_n262TituloValor = new bool[] {false} ;
         H009M13_A286TituloCompetenciaAno = new short[1] ;
         H009M13_n286TituloCompetenciaAno = new bool[] {false} ;
         H009M13_A287TituloCompetenciaMes = new short[1] ;
         H009M13_n287TituloCompetenciaMes = new bool[] {false} ;
         AV34Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV140AuxText = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         H009M15_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         H009M15_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         H009M15_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         H009M15_n794NotaFiscalId = new bool[] {false} ;
         H009M15_A419TituloPropostaId = new int[1] ;
         H009M15_n419TituloPropostaId = new bool[] {false} ;
         H009M15_A420TituloClienteId = new int[1] ;
         H009M15_n420TituloClienteId = new bool[] {false} ;
         H009M15_A275TituloSaldo_F = new decimal[1] ;
         H009M15_A283TituloTipo = new string[] {""} ;
         H009M15_n283TituloTipo = new bool[] {false} ;
         H009M15_A314TituloArchived = new bool[] {false} ;
         H009M15_n314TituloArchived = new bool[] {false} ;
         H009M15_A284TituloDeleted = new bool[] {false} ;
         H009M15_n284TituloDeleted = new bool[] {false} ;
         H009M15_A951ContaBancariaId = new int[1] ;
         H009M15_n951ContaBancariaId = new bool[] {false} ;
         H009M15_A498TituloJurosMora = new decimal[1] ;
         H009M15_n498TituloJurosMora = new bool[] {false} ;
         H009M15_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         H009M15_n264TituloProrrogacao = new bool[] {false} ;
         H009M15_A952ContaBancariaNumero = new long[1] ;
         H009M15_n952ContaBancariaNumero = new bool[] {false} ;
         H009M15_A799NotaFiscalNumero = new string[] {""} ;
         H009M15_n799NotaFiscalNumero = new bool[] {false} ;
         H009M15_A648TituloPropostaTipo = new string[] {""} ;
         H009M15_n648TituloPropostaTipo = new bool[] {false} ;
         H009M15_A971TituloPropostaDescricao = new string[] {""} ;
         H009M15_n971TituloPropostaDescricao = new bool[] {false} ;
         H009M15_A972TituloCLienteRazaoSocial = new string[] {""} ;
         H009M15_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         H009M15_A261TituloId = new int[1] ;
         H009M15_n261TituloId = new bool[] {false} ;
         H009M15_A262TituloValor = new decimal[1] ;
         H009M15_n262TituloValor = new bool[] {false} ;
         H009M15_A276TituloDesconto = new decimal[1] ;
         H009M15_n276TituloDesconto = new bool[] {false} ;
         H009M15_A273TituloTotalMovimento_F = new decimal[1] ;
         H009M15_A286TituloCompetenciaAno = new short[1] ;
         H009M15_n286TituloCompetenciaAno = new bool[] {false} ;
         H009M15_A287TituloCompetenciaMes = new short[1] ;
         H009M15_n287TituloCompetenciaMes = new bool[] {false} ;
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpregistrartitulo__default(),
            new Object[][] {
                new Object[] {
               H009M5_A794NotaFiscalId, H009M5_n794NotaFiscalId, H009M5_A951ContaBancariaId, H009M5_n951ContaBancariaId, H009M5_A952ContaBancariaNumero, H009M5_n952ContaBancariaNumero, H009M5_A799NotaFiscalNumero, H009M5_n799NotaFiscalNumero, H009M5_A890NotaFiscalParcelamentoID, H009M5_n890NotaFiscalParcelamentoID,
               H009M5_A426CategoriaTituloId, H009M5_n426CategoriaTituloId, H009M5_A500TituloCriacao, H009M5_n500TituloCriacao, H009M5_A422ContaId, H009M5_n422ContaId, H009M5_A501PropostaTaxaAdministrativa, H009M5_n501PropostaTaxaAdministrativa, H009M5_A419TituloPropostaId, H009M5_n419TituloPropostaId,
               H009M5_A283TituloTipo, H009M5_n283TituloTipo, H009M5_A498TituloJurosMora, H009M5_n498TituloJurosMora, H009M5_A269TituloMunicipio, H009M5_n269TituloMunicipio, H009M5_A268TituloBairro, H009M5_n268TituloBairro, H009M5_A267TituloComplemento, H009M5_n267TituloComplemento,
               H009M5_A294TituloNumeroEndereco, H009M5_n294TituloNumeroEndereco, H009M5_A266TituloLogradouro, H009M5_n266TituloLogradouro, H009M5_A265TituloCEP, H009M5_n265TituloCEP, H009M5_A264TituloProrrogacao, H009M5_n264TituloProrrogacao, H009M5_A263TituloVencimento, H009M5_n263TituloVencimento,
               H009M5_A314TituloArchived, H009M5_n314TituloArchived, H009M5_A284TituloDeleted, H009M5_n284TituloDeleted, H009M5_A648TituloPropostaTipo, H009M5_n648TituloPropostaTipo, H009M5_A971TituloPropostaDescricao, H009M5_n971TituloPropostaDescricao, H009M5_A972TituloCLienteRazaoSocial, H009M5_n972TituloCLienteRazaoSocial,
               H009M5_A420TituloClienteId, H009M5_n420TituloClienteId, H009M5_A261TituloId, H009M5_A276TituloDesconto, H009M5_n276TituloDesconto, H009M5_A273TituloTotalMovimento_F, H009M5_A301TituloTotalMultaJuros_F, H009M5_n301TituloTotalMultaJuros_F, H009M5_A516TituloDataCredito_F, H009M5_n516TituloDataCredito_F,
               H009M5_A286TituloCompetenciaAno, H009M5_n286TituloCompetenciaAno, H009M5_A287TituloCompetenciaMes, H009M5_n287TituloCompetenciaMes, H009M5_A262TituloValor, H009M5_n262TituloValor, H009M5_A275TituloSaldo_F
               }
               , new Object[] {
               H009M9_A794NotaFiscalId, H009M9_n794NotaFiscalId, H009M9_A951ContaBancariaId, H009M9_n951ContaBancariaId, H009M9_A952ContaBancariaNumero, H009M9_n952ContaBancariaNumero, H009M9_A799NotaFiscalNumero, H009M9_n799NotaFiscalNumero, H009M9_A890NotaFiscalParcelamentoID, H009M9_n890NotaFiscalParcelamentoID,
               H009M9_A426CategoriaTituloId, H009M9_n426CategoriaTituloId, H009M9_A500TituloCriacao, H009M9_n500TituloCriacao, H009M9_A422ContaId, H009M9_n422ContaId, H009M9_A501PropostaTaxaAdministrativa, H009M9_n501PropostaTaxaAdministrativa, H009M9_A419TituloPropostaId, H009M9_n419TituloPropostaId,
               H009M9_A283TituloTipo, H009M9_n283TituloTipo, H009M9_A498TituloJurosMora, H009M9_n498TituloJurosMora, H009M9_A269TituloMunicipio, H009M9_n269TituloMunicipio, H009M9_A268TituloBairro, H009M9_n268TituloBairro, H009M9_A267TituloComplemento, H009M9_n267TituloComplemento,
               H009M9_A294TituloNumeroEndereco, H009M9_n294TituloNumeroEndereco, H009M9_A266TituloLogradouro, H009M9_n266TituloLogradouro, H009M9_A265TituloCEP, H009M9_n265TituloCEP, H009M9_A264TituloProrrogacao, H009M9_n264TituloProrrogacao, H009M9_A263TituloVencimento, H009M9_n263TituloVencimento,
               H009M9_A314TituloArchived, H009M9_n314TituloArchived, H009M9_A284TituloDeleted, H009M9_n284TituloDeleted, H009M9_A648TituloPropostaTipo, H009M9_n648TituloPropostaTipo, H009M9_A971TituloPropostaDescricao, H009M9_n971TituloPropostaDescricao, H009M9_A972TituloCLienteRazaoSocial, H009M9_n972TituloCLienteRazaoSocial,
               H009M9_A420TituloClienteId, H009M9_n420TituloClienteId, H009M9_A261TituloId, H009M9_A276TituloDesconto, H009M9_n276TituloDesconto, H009M9_A273TituloTotalMovimento_F, H009M9_A301TituloTotalMultaJuros_F, H009M9_n301TituloTotalMultaJuros_F, H009M9_A516TituloDataCredito_F, H009M9_n516TituloDataCredito_F,
               H009M9_A286TituloCompetenciaAno, H009M9_n286TituloCompetenciaAno, H009M9_A287TituloCompetenciaMes, H009M9_n287TituloCompetenciaMes, H009M9_A262TituloValor, H009M9_n262TituloValor, H009M9_A275TituloSaldo_F
               }
               , new Object[] {
               H009M13_A794NotaFiscalId, H009M13_n794NotaFiscalId, H009M13_A261TituloId, H009M13_A420TituloClienteId, H009M13_n420TituloClienteId, H009M13_A972TituloCLienteRazaoSocial, H009M13_n972TituloCLienteRazaoSocial, H009M13_A971TituloPropostaDescricao, H009M13_n971TituloPropostaDescricao, H009M13_A648TituloPropostaTipo,
               H009M13_n648TituloPropostaTipo, H009M13_A284TituloDeleted, H009M13_n284TituloDeleted, H009M13_A314TituloArchived, H009M13_n314TituloArchived, H009M13_A263TituloVencimento, H009M13_n263TituloVencimento, H009M13_A264TituloProrrogacao, H009M13_n264TituloProrrogacao, H009M13_A265TituloCEP,
               H009M13_n265TituloCEP, H009M13_A266TituloLogradouro, H009M13_n266TituloLogradouro, H009M13_A294TituloNumeroEndereco, H009M13_n294TituloNumeroEndereco, H009M13_A267TituloComplemento, H009M13_n267TituloComplemento, H009M13_A268TituloBairro, H009M13_n268TituloBairro, H009M13_A269TituloMunicipio,
               H009M13_n269TituloMunicipio, H009M13_A498TituloJurosMora, H009M13_n498TituloJurosMora, H009M13_A283TituloTipo, H009M13_n283TituloTipo, H009M13_A419TituloPropostaId, H009M13_n419TituloPropostaId, H009M13_A501PropostaTaxaAdministrativa, H009M13_n501PropostaTaxaAdministrativa, H009M13_A422ContaId,
               H009M13_n422ContaId, H009M13_A500TituloCriacao, H009M13_n500TituloCriacao, H009M13_A426CategoriaTituloId, H009M13_n426CategoriaTituloId, H009M13_A890NotaFiscalParcelamentoID, H009M13_n890NotaFiscalParcelamentoID, H009M13_A799NotaFiscalNumero, H009M13_n799NotaFiscalNumero, H009M13_A516TituloDataCredito_F,
               H009M13_n516TituloDataCredito_F, H009M13_A301TituloTotalMultaJuros_F, H009M13_n301TituloTotalMultaJuros_F, H009M13_A273TituloTotalMovimento_F, H009M13_A276TituloDesconto, H009M13_n276TituloDesconto, H009M13_A262TituloValor, H009M13_n262TituloValor, H009M13_A286TituloCompetenciaAno, H009M13_n286TituloCompetenciaAno,
               H009M13_A287TituloCompetenciaMes, H009M13_n287TituloCompetenciaMes
               }
               , new Object[] {
               H009M15_A890NotaFiscalParcelamentoID, H009M15_n890NotaFiscalParcelamentoID, H009M15_A794NotaFiscalId, H009M15_n794NotaFiscalId, H009M15_A419TituloPropostaId, H009M15_n419TituloPropostaId, H009M15_A420TituloClienteId, H009M15_n420TituloClienteId, H009M15_A275TituloSaldo_F, H009M15_A283TituloTipo,
               H009M15_n283TituloTipo, H009M15_A314TituloArchived, H009M15_n314TituloArchived, H009M15_A284TituloDeleted, H009M15_n284TituloDeleted, H009M15_A951ContaBancariaId, H009M15_n951ContaBancariaId, H009M15_A498TituloJurosMora, H009M15_n498TituloJurosMora, H009M15_A264TituloProrrogacao,
               H009M15_n264TituloProrrogacao, H009M15_A952ContaBancariaNumero, H009M15_n952ContaBancariaNumero, H009M15_A799NotaFiscalNumero, H009M15_n799NotaFiscalNumero, H009M15_A648TituloPropostaTipo, H009M15_n648TituloPropostaTipo, H009M15_A971TituloPropostaDescricao, H009M15_n971TituloPropostaDescricao, H009M15_A972TituloCLienteRazaoSocial,
               H009M15_n972TituloCLienteRazaoSocial, H009M15_A261TituloId, H009M15_A262TituloValor, H009M15_n262TituloValor, H009M15_A276TituloDesconto, H009M15_n276TituloDesconto, H009M15_A273TituloTotalMovimento_F, H009M15_A286TituloCompetenciaAno, H009M15_n286TituloCompetenciaAno, H009M15_A287TituloCompetenciaMes,
               H009M15_n287TituloCompetenciaMes
               }
            }
         );
         AV156Pgmname = "WPRegistrarTitulo";
         /* GeneXus formulas. */
         AV156Pgmname = "WPRegistrarTitulo";
      }

      private short chkavSelected_Titleformat ;
      private short GRID_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV22DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV37ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A287TituloCompetenciaMes ;
      private short A286TituloCompetenciaAno ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV159Wpregistrartitulods_3_dynamicfiltersoperator1 ;
      private short AV164Wpregistrartitulods_8_dynamicfiltersoperator2 ;
      private short AV169Wpregistrartitulods_13_dynamicfiltersoperator3 ;
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
      private int nRC_GXsfl_116 ;
      private int nGXsfl_116_idx=1 ;
      private int AV152TituloIdToFind ;
      private int A951ContaBancariaId ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A261TituloId ;
      private int A420TituloClienteId ;
      private int A419TituloPropostaId ;
      private int A422ContaId ;
      private int A426CategoriaTituloId ;
      private int subGrid_Islastpage ;
      private int AV176Wpregistrartitulods_20_tftitulopropostatipo_sels_Count ;
      private int edtTituloId_Enabled ;
      private int edtTituloClienteId_Enabled ;
      private int edtTituloCLienteRazaoSocial_Enabled ;
      private int edtTituloPropostaDescricao_Enabled ;
      private int edtTituloValor_Enabled ;
      private int edtTituloDesconto_Enabled ;
      private int edtTituloVencimento_Enabled ;
      private int edtTituloCompetenciaMes_Enabled ;
      private int edtTituloCompetenciaAno_Enabled ;
      private int edtTituloCompetencia_F_Enabled ;
      private int edtTituloProrrogacao_Enabled ;
      private int edtTituloCEP_Enabled ;
      private int edtTituloLogradouro_Enabled ;
      private int edtTituloNumeroEndereco_Enabled ;
      private int edtTituloComplemento_Enabled ;
      private int edtTituloBairro_Enabled ;
      private int edtTituloMunicipio_Enabled ;
      private int edtTituloJurosMora_Enabled ;
      private int edtTituloPropostaId_Enabled ;
      private int edtPropostaTaxaAdministrativa_Enabled ;
      private int edtContaId_Enabled ;
      private int edtTituloCriacao_Enabled ;
      private int edtCategoriaTituloId_Enabled ;
      private int edtTituloDataCredito_F_Enabled ;
      private int edtTituloTotalMovimento_F_Enabled ;
      private int edtTituloTotalMultaJuros_F_Enabled ;
      private int edtTituloSaldo_F_Enabled ;
      private int edtTituloStatus_F_Enabled ;
      private int edtNotaFiscalParcelamentoID_Enabled ;
      private int edtNotaFiscalNumero_Enabled ;
      private int AV133PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int nGXsfl_116_fel_idx=1 ;
      private int AV190GXV1 ;
      private int AV151TituloIdColItem ;
      private int edtavTitulovalor1_Visible ;
      private int edtavContabancarianumero1_Visible ;
      private int edtavTitulovalor2_Visible ;
      private int edtavContabancarianumero2_Visible ;
      private int edtavTitulovalor3_Visible ;
      private int edtavContabancarianumero3_Visible ;
      private int AV191GXV2 ;
      private int AV193GXV3 ;
      private int edtavTitulovalor3_Enabled ;
      private int edtavContabancarianumero3_Enabled ;
      private int edtavTitulovalor2_Enabled ;
      private int edtavContabancarianumero2_Enabled ;
      private int edtavTitulovalor1_Enabled ;
      private int edtavContabancarianumero1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV19ContaBancariaNumero1 ;
      private long AV24ContaBancariaNumero2 ;
      private long AV29ContaBancariaNumero3 ;
      private long AV148i ;
      private long AV134GridCurrentPage ;
      private long AV135GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long AV161Wpregistrartitulods_5_contabancarianumero1 ;
      private long AV166Wpregistrartitulods_10_contabancarianumero2 ;
      private long AV171Wpregistrartitulods_15_contabancarianumero3 ;
      private long GRID_nRecordCount ;
      private long A952ContaBancariaNumero ;
      private decimal AV18TituloValor1 ;
      private decimal AV23TituloValor2 ;
      private decimal AV28TituloValor3 ;
      private decimal AV44TFTituloValor ;
      private decimal AV45TFTituloValor_To ;
      private decimal AV46TFTituloDesconto ;
      private decimal AV47TFTituloDesconto_To ;
      private decimal AV78TFTituloJurosMora ;
      private decimal AV79TFTituloJurosMora_To ;
      private decimal A262TituloValor ;
      private decimal A276TituloDesconto ;
      private decimal A498TituloJurosMora ;
      private decimal A501PropostaTaxaAdministrativa ;
      private decimal A273TituloTotalMovimento_F ;
      private decimal A301TituloTotalMultaJuros_F ;
      private decimal A275TituloSaldo_F ;
      private decimal AV160Wpregistrartitulods_4_titulovalor1 ;
      private decimal AV165Wpregistrartitulods_9_titulovalor2 ;
      private decimal AV170Wpregistrartitulods_14_titulovalor3 ;
      private decimal AV177Wpregistrartitulods_21_tftitulovalor ;
      private decimal AV178Wpregistrartitulods_22_tftitulovalor_to ;
      private decimal AV179Wpregistrartitulods_23_tftitulodesconto ;
      private decimal AV180Wpregistrartitulods_24_tftitulodesconto_to ;
      private decimal AV185Wpregistrartitulods_29_tftitulojurosmora ;
      private decimal AV186Wpregistrartitulods_30_tftitulojurosmora_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_116_idx="0001" ;
      private string AV156Pgmname ;
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
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tableheader_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnexport_Internalname ;
      private string bttBtnexport_Jsonclick ;
      private string bttBtnregistrar_titulos_Internalname ;
      private string bttBtnregistrar_titulos_Jsonclick ;
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
      private string chkavSelectall_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_tituloprorrogacaoauxdates_Internalname ;
      private string edtavDdo_tituloprorrogacaoauxdatetext_Internalname ;
      private string edtavDdo_tituloprorrogacaoauxdatetext_Jsonclick ;
      private string Tftituloprorrogacao_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string chkavSelected_Internalname ;
      private string edtTituloId_Internalname ;
      private string edtTituloClienteId_Internalname ;
      private string edtTituloCLienteRazaoSocial_Internalname ;
      private string edtTituloPropostaDescricao_Internalname ;
      private string cmbTituloPropostaTipo_Internalname ;
      private string edtTituloValor_Internalname ;
      private string edtTituloDesconto_Internalname ;
      private string chkTituloDeleted_Internalname ;
      private string chkTituloArchived_Internalname ;
      private string edtTituloVencimento_Internalname ;
      private string edtTituloCompetenciaMes_Internalname ;
      private string edtTituloCompetenciaAno_Internalname ;
      private string edtTituloCompetencia_F_Internalname ;
      private string edtTituloProrrogacao_Internalname ;
      private string edtTituloCEP_Internalname ;
      private string edtTituloLogradouro_Internalname ;
      private string edtTituloNumeroEndereco_Internalname ;
      private string edtTituloComplemento_Internalname ;
      private string edtTituloBairro_Internalname ;
      private string edtTituloMunicipio_Internalname ;
      private string edtTituloJurosMora_Internalname ;
      private string cmbTituloTipo_Internalname ;
      private string edtTituloPropostaId_Internalname ;
      private string edtPropostaTaxaAdministrativa_Internalname ;
      private string edtContaId_Internalname ;
      private string edtTituloCriacao_Internalname ;
      private string edtCategoriaTituloId_Internalname ;
      private string edtTituloDataCredito_F_Internalname ;
      private string edtTituloTotalMovimento_F_Internalname ;
      private string edtTituloTotalMultaJuros_F_Internalname ;
      private string edtTituloSaldo_F_Internalname ;
      private string edtTituloStatus_F_Internalname ;
      private string edtNotaFiscalParcelamentoID_Internalname ;
      private string edtNotaFiscalNumero_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavTitulovalor1_Internalname ;
      private string edtavContabancarianumero1_Internalname ;
      private string edtavTitulovalor2_Internalname ;
      private string edtavContabancarianumero2_Internalname ;
      private string edtavTitulovalor3_Internalname ;
      private string edtavContabancarianumero3_Internalname ;
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
      private string GXEncryptionTmp ;
      private string sGXsfl_116_fel_idx="0001" ;
      private string GXt_char2 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_titulovalor3_cell_Internalname ;
      private string edtavTitulovalor3_Jsonclick ;
      private string cellFilter_contabancarianumero3_cell_Internalname ;
      private string edtavContabancarianumero3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_titulovalor2_cell_Internalname ;
      private string edtavTitulovalor2_Jsonclick ;
      private string cellFilter_contabancarianumero2_cell_Internalname ;
      private string edtavContabancarianumero2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_titulovalor1_cell_Internalname ;
      private string edtavTitulovalor1_Jsonclick ;
      private string cellFilter_contabancarianumero1_cell_Internalname ;
      private string edtavContabancarianumero1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string ROClassString ;
      private string edtTituloId_Jsonclick ;
      private string edtTituloClienteId_Jsonclick ;
      private string edtTituloCLienteRazaoSocial_Jsonclick ;
      private string edtTituloPropostaDescricao_Jsonclick ;
      private string cmbTituloPropostaTipo_Jsonclick ;
      private string edtTituloValor_Jsonclick ;
      private string edtTituloDesconto_Jsonclick ;
      private string edtTituloVencimento_Jsonclick ;
      private string edtTituloCompetenciaMes_Jsonclick ;
      private string edtTituloCompetenciaAno_Jsonclick ;
      private string edtTituloCompetencia_F_Jsonclick ;
      private string edtTituloProrrogacao_Jsonclick ;
      private string edtTituloCEP_Jsonclick ;
      private string edtTituloLogradouro_Jsonclick ;
      private string edtTituloNumeroEndereco_Jsonclick ;
      private string edtTituloComplemento_Jsonclick ;
      private string edtTituloBairro_Jsonclick ;
      private string edtTituloMunicipio_Jsonclick ;
      private string edtTituloJurosMora_Jsonclick ;
      private string cmbTituloTipo_Jsonclick ;
      private string edtTituloPropostaId_Jsonclick ;
      private string edtPropostaTaxaAdministrativa_Jsonclick ;
      private string edtContaId_Jsonclick ;
      private string edtTituloCriacao_Jsonclick ;
      private string edtCategoriaTituloId_Jsonclick ;
      private string edtTituloDataCredito_F_Jsonclick ;
      private string edtTituloTotalMovimento_F_Jsonclick ;
      private string edtTituloTotalMultaJuros_F_Jsonclick ;
      private string edtTituloSaldo_F_Jsonclick ;
      private string edtTituloStatus_F_Jsonclick ;
      private string edtNotaFiscalParcelamentoID_Jsonclick ;
      private string edtNotaFiscalNumero_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A500TituloCriacao ;
      private DateTime AV61TFTituloProrrogacao ;
      private DateTime AV62TFTituloProrrogacao_To ;
      private DateTime AV63DDO_TituloProrrogacaoAuxDate ;
      private DateTime AV64DDO_TituloProrrogacaoAuxDateTo ;
      private DateTime A263TituloVencimento ;
      private DateTime A264TituloProrrogacao ;
      private DateTime A516TituloDataCredito_F ;
      private DateTime AV183Wpregistrartitulods_27_tftituloprorrogacao ;
      private DateTime AV184Wpregistrartitulods_28_tftituloprorrogacao_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV20DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV31DynamicFiltersIgnoreFirst ;
      private bool AV30DynamicFiltersRemoving ;
      private bool AV153SelectAll ;
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
      private bool AV145Selected ;
      private bool n261TituloId ;
      private bool n420TituloClienteId ;
      private bool n972TituloCLienteRazaoSocial ;
      private bool n971TituloPropostaDescricao ;
      private bool n648TituloPropostaTipo ;
      private bool n262TituloValor ;
      private bool n276TituloDesconto ;
      private bool A284TituloDeleted ;
      private bool n284TituloDeleted ;
      private bool A314TituloArchived ;
      private bool n314TituloArchived ;
      private bool n263TituloVencimento ;
      private bool n287TituloCompetenciaMes ;
      private bool n286TituloCompetenciaAno ;
      private bool n264TituloProrrogacao ;
      private bool n265TituloCEP ;
      private bool n266TituloLogradouro ;
      private bool n294TituloNumeroEndereco ;
      private bool n267TituloComplemento ;
      private bool n268TituloBairro ;
      private bool n269TituloMunicipio ;
      private bool n498TituloJurosMora ;
      private bool n283TituloTipo ;
      private bool n419TituloPropostaId ;
      private bool n501PropostaTaxaAdministrativa ;
      private bool n422ContaId ;
      private bool n500TituloCriacao ;
      private bool n426CategoriaTituloId ;
      private bool n516TituloDataCredito_F ;
      private bool n301TituloTotalMultaJuros_F ;
      private bool n890NotaFiscalParcelamentoID ;
      private bool n799NotaFiscalNumero ;
      private bool AV162Wpregistrartitulods_6_dynamicfiltersenabled2 ;
      private bool AV167Wpregistrartitulods_11_dynamicfiltersenabled3 ;
      private bool n794NotaFiscalId ;
      private bool n951ContaBancariaId ;
      private bool n952ContaBancariaNumero ;
      private bool bGXsfl_116_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV150TituloIdJson ;
      private string AV120TFTituloPropostaTipo_SelsJson ;
      private string AV36ManageFiltersXml ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV15FilterFullText ;
      private string AV154TFTituloCLienteRazaoSocial ;
      private string AV155TFTituloCLienteRazaoSocial_Sel ;
      private string AV143TFTituloPropostaDescricao ;
      private string AV144TFTituloPropostaDescricao_Sel ;
      private string AV59TFTituloCompetencia_F ;
      private string AV60TFTituloCompetencia_F_Sel ;
      private string AV141TFNotaFiscalNumero ;
      private string AV142TFNotaFiscalNumero_Sel ;
      private string AV136GridAppliedFilters ;
      private string AV65DDO_TituloProrrogacaoAuxDateText ;
      private string A972TituloCLienteRazaoSocial ;
      private string A971TituloPropostaDescricao ;
      private string A648TituloPropostaTipo ;
      private string A295TituloCompetencia_F ;
      private string A265TituloCEP ;
      private string A266TituloLogradouro ;
      private string A294TituloNumeroEndereco ;
      private string A267TituloComplemento ;
      private string A268TituloBairro ;
      private string A269TituloMunicipio ;
      private string A283TituloTipo ;
      private string A282TituloStatus_F ;
      private string A799NotaFiscalNumero ;
      private string AV157Wpregistrartitulods_1_filterfulltext ;
      private string AV158Wpregistrartitulods_2_dynamicfiltersselector1 ;
      private string AV163Wpregistrartitulods_7_dynamicfiltersselector2 ;
      private string AV168Wpregistrartitulods_12_dynamicfiltersselector3 ;
      private string AV172Wpregistrartitulods_16_tftituloclienterazaosocial ;
      private string AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel ;
      private string AV174Wpregistrartitulods_18_tftitulopropostadescricao ;
      private string AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel ;
      private string AV181Wpregistrartitulods_25_tftitulocompetencia_f ;
      private string AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel ;
      private string AV187Wpregistrartitulods_31_tfnotafiscalnumero ;
      private string AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel ;
      private string lV157Wpregistrartitulods_1_filterfulltext ;
      private string lV172Wpregistrartitulods_16_tftituloclienterazaosocial ;
      private string lV174Wpregistrartitulods_18_tftitulopropostadescricao ;
      private string lV187Wpregistrartitulods_31_tfnotafiscalnumero ;
      private string AV32ExcelFilename ;
      private string AV33ErrorMessage ;
      private string AV140AuxText ;
      private Guid A890NotaFiscalParcelamentoID ;
      private Guid A794NotaFiscalId ;
      private IGxSession AV34Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTftituloprorrogacao_rangepicker ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCheckbox chkavSelected ;
      private GXCombobox cmbTituloPropostaTipo ;
      private GXCheckbox chkTituloDeleted ;
      private GXCheckbox chkTituloArchived ;
      private GXCombobox cmbTituloTipo ;
      private GXCheckbox chkavSelectall ;
      private GxSimpleCollection<string> AV121TFTituloPropostaTipo_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GxSimpleCollection<int> AV149TituloIdCol ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV35ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV132DDO_TitleSettingsIcons ;
      private GXBaseCollection<SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem> AV146SelectedRows ;
      private GxSimpleCollection<string> AV176Wpregistrartitulods_20_tftitulopropostatipo_sels ;
      private IDataStoreProvider pr_default ;
      private Guid[] H009M5_A794NotaFiscalId ;
      private bool[] H009M5_n794NotaFiscalId ;
      private int[] H009M5_A951ContaBancariaId ;
      private bool[] H009M5_n951ContaBancariaId ;
      private long[] H009M5_A952ContaBancariaNumero ;
      private bool[] H009M5_n952ContaBancariaNumero ;
      private string[] H009M5_A799NotaFiscalNumero ;
      private bool[] H009M5_n799NotaFiscalNumero ;
      private Guid[] H009M5_A890NotaFiscalParcelamentoID ;
      private bool[] H009M5_n890NotaFiscalParcelamentoID ;
      private int[] H009M5_A426CategoriaTituloId ;
      private bool[] H009M5_n426CategoriaTituloId ;
      private DateTime[] H009M5_A500TituloCriacao ;
      private bool[] H009M5_n500TituloCriacao ;
      private int[] H009M5_A422ContaId ;
      private bool[] H009M5_n422ContaId ;
      private decimal[] H009M5_A501PropostaTaxaAdministrativa ;
      private bool[] H009M5_n501PropostaTaxaAdministrativa ;
      private int[] H009M5_A419TituloPropostaId ;
      private bool[] H009M5_n419TituloPropostaId ;
      private string[] H009M5_A283TituloTipo ;
      private bool[] H009M5_n283TituloTipo ;
      private decimal[] H009M5_A498TituloJurosMora ;
      private bool[] H009M5_n498TituloJurosMora ;
      private string[] H009M5_A269TituloMunicipio ;
      private bool[] H009M5_n269TituloMunicipio ;
      private string[] H009M5_A268TituloBairro ;
      private bool[] H009M5_n268TituloBairro ;
      private string[] H009M5_A267TituloComplemento ;
      private bool[] H009M5_n267TituloComplemento ;
      private string[] H009M5_A294TituloNumeroEndereco ;
      private bool[] H009M5_n294TituloNumeroEndereco ;
      private string[] H009M5_A266TituloLogradouro ;
      private bool[] H009M5_n266TituloLogradouro ;
      private string[] H009M5_A265TituloCEP ;
      private bool[] H009M5_n265TituloCEP ;
      private DateTime[] H009M5_A264TituloProrrogacao ;
      private bool[] H009M5_n264TituloProrrogacao ;
      private DateTime[] H009M5_A263TituloVencimento ;
      private bool[] H009M5_n263TituloVencimento ;
      private bool[] H009M5_A314TituloArchived ;
      private bool[] H009M5_n314TituloArchived ;
      private bool[] H009M5_A284TituloDeleted ;
      private bool[] H009M5_n284TituloDeleted ;
      private string[] H009M5_A648TituloPropostaTipo ;
      private bool[] H009M5_n648TituloPropostaTipo ;
      private string[] H009M5_A971TituloPropostaDescricao ;
      private bool[] H009M5_n971TituloPropostaDescricao ;
      private string[] H009M5_A972TituloCLienteRazaoSocial ;
      private bool[] H009M5_n972TituloCLienteRazaoSocial ;
      private int[] H009M5_A420TituloClienteId ;
      private bool[] H009M5_n420TituloClienteId ;
      private int[] H009M5_A261TituloId ;
      private bool[] H009M5_n261TituloId ;
      private decimal[] H009M5_A276TituloDesconto ;
      private bool[] H009M5_n276TituloDesconto ;
      private decimal[] H009M5_A273TituloTotalMovimento_F ;
      private decimal[] H009M5_A301TituloTotalMultaJuros_F ;
      private bool[] H009M5_n301TituloTotalMultaJuros_F ;
      private DateTime[] H009M5_A516TituloDataCredito_F ;
      private bool[] H009M5_n516TituloDataCredito_F ;
      private short[] H009M5_A286TituloCompetenciaAno ;
      private bool[] H009M5_n286TituloCompetenciaAno ;
      private short[] H009M5_A287TituloCompetenciaMes ;
      private bool[] H009M5_n287TituloCompetenciaMes ;
      private decimal[] H009M5_A262TituloValor ;
      private bool[] H009M5_n262TituloValor ;
      private decimal[] H009M5_A275TituloSaldo_F ;
      private Guid[] H009M9_A794NotaFiscalId ;
      private bool[] H009M9_n794NotaFiscalId ;
      private int[] H009M9_A951ContaBancariaId ;
      private bool[] H009M9_n951ContaBancariaId ;
      private long[] H009M9_A952ContaBancariaNumero ;
      private bool[] H009M9_n952ContaBancariaNumero ;
      private string[] H009M9_A799NotaFiscalNumero ;
      private bool[] H009M9_n799NotaFiscalNumero ;
      private Guid[] H009M9_A890NotaFiscalParcelamentoID ;
      private bool[] H009M9_n890NotaFiscalParcelamentoID ;
      private int[] H009M9_A426CategoriaTituloId ;
      private bool[] H009M9_n426CategoriaTituloId ;
      private DateTime[] H009M9_A500TituloCriacao ;
      private bool[] H009M9_n500TituloCriacao ;
      private int[] H009M9_A422ContaId ;
      private bool[] H009M9_n422ContaId ;
      private decimal[] H009M9_A501PropostaTaxaAdministrativa ;
      private bool[] H009M9_n501PropostaTaxaAdministrativa ;
      private int[] H009M9_A419TituloPropostaId ;
      private bool[] H009M9_n419TituloPropostaId ;
      private string[] H009M9_A283TituloTipo ;
      private bool[] H009M9_n283TituloTipo ;
      private decimal[] H009M9_A498TituloJurosMora ;
      private bool[] H009M9_n498TituloJurosMora ;
      private string[] H009M9_A269TituloMunicipio ;
      private bool[] H009M9_n269TituloMunicipio ;
      private string[] H009M9_A268TituloBairro ;
      private bool[] H009M9_n268TituloBairro ;
      private string[] H009M9_A267TituloComplemento ;
      private bool[] H009M9_n267TituloComplemento ;
      private string[] H009M9_A294TituloNumeroEndereco ;
      private bool[] H009M9_n294TituloNumeroEndereco ;
      private string[] H009M9_A266TituloLogradouro ;
      private bool[] H009M9_n266TituloLogradouro ;
      private string[] H009M9_A265TituloCEP ;
      private bool[] H009M9_n265TituloCEP ;
      private DateTime[] H009M9_A264TituloProrrogacao ;
      private bool[] H009M9_n264TituloProrrogacao ;
      private DateTime[] H009M9_A263TituloVencimento ;
      private bool[] H009M9_n263TituloVencimento ;
      private bool[] H009M9_A314TituloArchived ;
      private bool[] H009M9_n314TituloArchived ;
      private bool[] H009M9_A284TituloDeleted ;
      private bool[] H009M9_n284TituloDeleted ;
      private string[] H009M9_A648TituloPropostaTipo ;
      private bool[] H009M9_n648TituloPropostaTipo ;
      private string[] H009M9_A971TituloPropostaDescricao ;
      private bool[] H009M9_n971TituloPropostaDescricao ;
      private string[] H009M9_A972TituloCLienteRazaoSocial ;
      private bool[] H009M9_n972TituloCLienteRazaoSocial ;
      private int[] H009M9_A420TituloClienteId ;
      private bool[] H009M9_n420TituloClienteId ;
      private int[] H009M9_A261TituloId ;
      private bool[] H009M9_n261TituloId ;
      private decimal[] H009M9_A276TituloDesconto ;
      private bool[] H009M9_n276TituloDesconto ;
      private decimal[] H009M9_A273TituloTotalMovimento_F ;
      private decimal[] H009M9_A301TituloTotalMultaJuros_F ;
      private bool[] H009M9_n301TituloTotalMultaJuros_F ;
      private DateTime[] H009M9_A516TituloDataCredito_F ;
      private bool[] H009M9_n516TituloDataCredito_F ;
      private short[] H009M9_A286TituloCompetenciaAno ;
      private bool[] H009M9_n286TituloCompetenciaAno ;
      private short[] H009M9_A287TituloCompetenciaMes ;
      private bool[] H009M9_n287TituloCompetenciaMes ;
      private decimal[] H009M9_A262TituloValor ;
      private bool[] H009M9_n262TituloValor ;
      private decimal[] H009M9_A275TituloSaldo_F ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem AV147SelectedRow ;
      private Guid[] H009M13_A794NotaFiscalId ;
      private bool[] H009M13_n794NotaFiscalId ;
      private int[] H009M13_A261TituloId ;
      private bool[] H009M13_n261TituloId ;
      private int[] H009M13_A420TituloClienteId ;
      private bool[] H009M13_n420TituloClienteId ;
      private string[] H009M13_A972TituloCLienteRazaoSocial ;
      private bool[] H009M13_n972TituloCLienteRazaoSocial ;
      private string[] H009M13_A971TituloPropostaDescricao ;
      private bool[] H009M13_n971TituloPropostaDescricao ;
      private string[] H009M13_A648TituloPropostaTipo ;
      private bool[] H009M13_n648TituloPropostaTipo ;
      private bool[] H009M13_A284TituloDeleted ;
      private bool[] H009M13_n284TituloDeleted ;
      private bool[] H009M13_A314TituloArchived ;
      private bool[] H009M13_n314TituloArchived ;
      private DateTime[] H009M13_A263TituloVencimento ;
      private bool[] H009M13_n263TituloVencimento ;
      private DateTime[] H009M13_A264TituloProrrogacao ;
      private bool[] H009M13_n264TituloProrrogacao ;
      private string[] H009M13_A265TituloCEP ;
      private bool[] H009M13_n265TituloCEP ;
      private string[] H009M13_A266TituloLogradouro ;
      private bool[] H009M13_n266TituloLogradouro ;
      private string[] H009M13_A294TituloNumeroEndereco ;
      private bool[] H009M13_n294TituloNumeroEndereco ;
      private string[] H009M13_A267TituloComplemento ;
      private bool[] H009M13_n267TituloComplemento ;
      private string[] H009M13_A268TituloBairro ;
      private bool[] H009M13_n268TituloBairro ;
      private string[] H009M13_A269TituloMunicipio ;
      private bool[] H009M13_n269TituloMunicipio ;
      private decimal[] H009M13_A498TituloJurosMora ;
      private bool[] H009M13_n498TituloJurosMora ;
      private string[] H009M13_A283TituloTipo ;
      private bool[] H009M13_n283TituloTipo ;
      private int[] H009M13_A419TituloPropostaId ;
      private bool[] H009M13_n419TituloPropostaId ;
      private decimal[] H009M13_A501PropostaTaxaAdministrativa ;
      private bool[] H009M13_n501PropostaTaxaAdministrativa ;
      private int[] H009M13_A422ContaId ;
      private bool[] H009M13_n422ContaId ;
      private DateTime[] H009M13_A500TituloCriacao ;
      private bool[] H009M13_n500TituloCriacao ;
      private int[] H009M13_A426CategoriaTituloId ;
      private bool[] H009M13_n426CategoriaTituloId ;
      private Guid[] H009M13_A890NotaFiscalParcelamentoID ;
      private bool[] H009M13_n890NotaFiscalParcelamentoID ;
      private string[] H009M13_A799NotaFiscalNumero ;
      private bool[] H009M13_n799NotaFiscalNumero ;
      private DateTime[] H009M13_A516TituloDataCredito_F ;
      private bool[] H009M13_n516TituloDataCredito_F ;
      private decimal[] H009M13_A301TituloTotalMultaJuros_F ;
      private bool[] H009M13_n301TituloTotalMultaJuros_F ;
      private decimal[] H009M13_A273TituloTotalMovimento_F ;
      private decimal[] H009M13_A276TituloDesconto ;
      private bool[] H009M13_n276TituloDesconto ;
      private decimal[] H009M13_A262TituloValor ;
      private bool[] H009M13_n262TituloValor ;
      private short[] H009M13_A286TituloCompetenciaAno ;
      private bool[] H009M13_n286TituloCompetenciaAno ;
      private short[] H009M13_A287TituloCompetenciaMes ;
      private bool[] H009M13_n287TituloCompetenciaMes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private Guid[] H009M15_A890NotaFiscalParcelamentoID ;
      private bool[] H009M15_n890NotaFiscalParcelamentoID ;
      private Guid[] H009M15_A794NotaFiscalId ;
      private bool[] H009M15_n794NotaFiscalId ;
      private int[] H009M15_A419TituloPropostaId ;
      private bool[] H009M15_n419TituloPropostaId ;
      private int[] H009M15_A420TituloClienteId ;
      private bool[] H009M15_n420TituloClienteId ;
      private decimal[] H009M15_A275TituloSaldo_F ;
      private string[] H009M15_A283TituloTipo ;
      private bool[] H009M15_n283TituloTipo ;
      private bool[] H009M15_A314TituloArchived ;
      private bool[] H009M15_n314TituloArchived ;
      private bool[] H009M15_A284TituloDeleted ;
      private bool[] H009M15_n284TituloDeleted ;
      private int[] H009M15_A951ContaBancariaId ;
      private bool[] H009M15_n951ContaBancariaId ;
      private decimal[] H009M15_A498TituloJurosMora ;
      private bool[] H009M15_n498TituloJurosMora ;
      private DateTime[] H009M15_A264TituloProrrogacao ;
      private bool[] H009M15_n264TituloProrrogacao ;
      private long[] H009M15_A952ContaBancariaNumero ;
      private bool[] H009M15_n952ContaBancariaNumero ;
      private string[] H009M15_A799NotaFiscalNumero ;
      private bool[] H009M15_n799NotaFiscalNumero ;
      private string[] H009M15_A648TituloPropostaTipo ;
      private bool[] H009M15_n648TituloPropostaTipo ;
      private string[] H009M15_A971TituloPropostaDescricao ;
      private bool[] H009M15_n971TituloPropostaDescricao ;
      private string[] H009M15_A972TituloCLienteRazaoSocial ;
      private bool[] H009M15_n972TituloCLienteRazaoSocial ;
      private int[] H009M15_A261TituloId ;
      private bool[] H009M15_n261TituloId ;
      private decimal[] H009M15_A262TituloValor ;
      private bool[] H009M15_n262TituloValor ;
      private decimal[] H009M15_A276TituloDesconto ;
      private bool[] H009M15_n276TituloDesconto ;
      private decimal[] H009M15_A273TituloTotalMovimento_F ;
      private short[] H009M15_A286TituloCompetenciaAno ;
      private bool[] H009M15_n286TituloCompetenciaAno ;
      private short[] H009M15_A287TituloCompetenciaMes ;
      private bool[] H009M15_n287TituloCompetenciaMes ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpregistrartitulo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009M5( IGxContext context ,
                                             string A648TituloPropostaTipo ,
                                             GxSimpleCollection<string> AV176Wpregistrartitulods_20_tftitulopropostatipo_sels ,
                                             string AV158Wpregistrartitulods_2_dynamicfiltersselector1 ,
                                             short AV159Wpregistrartitulods_3_dynamicfiltersoperator1 ,
                                             decimal AV160Wpregistrartitulods_4_titulovalor1 ,
                                             long AV161Wpregistrartitulods_5_contabancarianumero1 ,
                                             bool AV162Wpregistrartitulods_6_dynamicfiltersenabled2 ,
                                             string AV163Wpregistrartitulods_7_dynamicfiltersselector2 ,
                                             short AV164Wpregistrartitulods_8_dynamicfiltersoperator2 ,
                                             decimal AV165Wpregistrartitulods_9_titulovalor2 ,
                                             long AV166Wpregistrartitulods_10_contabancarianumero2 ,
                                             bool AV167Wpregistrartitulods_11_dynamicfiltersenabled3 ,
                                             string AV168Wpregistrartitulods_12_dynamicfiltersselector3 ,
                                             short AV169Wpregistrartitulods_13_dynamicfiltersoperator3 ,
                                             decimal AV170Wpregistrartitulods_14_titulovalor3 ,
                                             long AV171Wpregistrartitulods_15_contabancarianumero3 ,
                                             string AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel ,
                                             string AV172Wpregistrartitulods_16_tftituloclienterazaosocial ,
                                             string AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel ,
                                             string AV174Wpregistrartitulods_18_tftitulopropostadescricao ,
                                             int AV176Wpregistrartitulods_20_tftitulopropostatipo_sels_Count ,
                                             decimal AV177Wpregistrartitulods_21_tftitulovalor ,
                                             decimal AV178Wpregistrartitulods_22_tftitulovalor_to ,
                                             decimal AV179Wpregistrartitulods_23_tftitulodesconto ,
                                             decimal AV180Wpregistrartitulods_24_tftitulodesconto_to ,
                                             DateTime AV183Wpregistrartitulods_27_tftituloprorrogacao ,
                                             DateTime AV184Wpregistrartitulods_28_tftituloprorrogacao_to ,
                                             decimal AV185Wpregistrartitulods_29_tftitulojurosmora ,
                                             decimal AV186Wpregistrartitulods_30_tftitulojurosmora_to ,
                                             string AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel ,
                                             string AV187Wpregistrartitulods_31_tfnotafiscalnumero ,
                                             decimal A262TituloValor ,
                                             long A952ContaBancariaNumero ,
                                             string A972TituloCLienteRazaoSocial ,
                                             string A971TituloPropostaDescricao ,
                                             decimal A276TituloDesconto ,
                                             DateTime A264TituloProrrogacao ,
                                             decimal A498TituloJurosMora ,
                                             string A799NotaFiscalNumero ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV157Wpregistrartitulods_1_filterfulltext ,
                                             string A295TituloCompetencia_F ,
                                             string AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel ,
                                             string AV181Wpregistrartitulods_25_tftitulocompetencia_f ,
                                             int A951ContaBancariaId ,
                                             bool A284TituloDeleted ,
                                             bool A314TituloArchived ,
                                             string A283TituloTipo ,
                                             decimal A275TituloSaldo_F )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[32];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T3.NotaFiscalId, T1.ContaBancariaId, T2.ContaBancariaNumero, T4.NotaFiscalNumero, T1.NotaFiscalParcelamentoID, T1.CategoriaTituloId, T1.TituloCriacao, T1.ContaId, T5.PropostaTaxaAdministrativa, T1.TituloPropostaId AS TituloPropostaId, T1.TituloTipo, T1.TituloJurosMora, T1.TituloMunicipio, T1.TituloBairro, T1.TituloComplemento, T1.TituloNumeroEndereco, T1.TituloLogradouro, T1.TituloCEP, T1.TituloProrrogacao, T1.TituloVencimento, T1.TituloArchived, T1.TituloDeleted, T1.TituloPropostaTipo, T5.PropostaDescricao AS TituloPropostaDescricao, T6.ClienteRazaoSocial AS TituloCLienteRazaoSocial, T1.TituloClienteId AS TituloClienteId, T1.TituloId, T1.TituloDesconto, COALESCE( T7.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F, COALESCE( T8.TituloTotalMovimento_F, 0) AS TituloTotalMultaJuros_F, COALESCE( T9.TituloDataCredito_F, DATE '00010101') AS TituloDataCredito_F, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes, T1.TituloValor, ( COALESCE( T1.TituloValor, 0) - COALESCE( T1.TituloDesconto, 0)) - COALESCE( T7.TituloTotalMovimento_F, 0) AS TituloSaldo_F FROM ((((((((Titulo T1 LEFT JOIN ContaBancaria T2 ON T2.ContaBancariaId = T1.ContaBancariaId) LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN Proposta T5 ON T5.PropostaId = T1.TituloPropostaId) LEFT JOIN Cliente T6 ON T6.ClienteId = T1.TituloClienteId) LEFT JOIN LATERAL (SELECT TituloId, SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE (T1.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T7 ON T7.TituloId = T1.TituloId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T1.TituloId = TituloId)";
         scmdbuf += " AND (Not TituloMovimentoSoma) GROUP BY TituloId ) T8 ON T8.TituloId = T1.TituloId) LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE T1.TituloId = TituloId GROUP BY TituloId ) T9 ON T9.TituloId = T1.TituloId)";
         AddWhere(sWhereString, "((T1.ContaBancariaId = 0) or T1.ContaBancariaId IS NULL)");
         AddWhere(sWhereString, "(Not T1.TituloDeleted)");
         AddWhere(sWhereString, "(Not T1.TituloArchived)");
         AddWhere(sWhereString, "(T1.TituloTipo = ( 'CREDITO'))");
         AddWhere(sWhereString, "(Not (( COALESCE( T1.TituloValor, 0) - COALESCE( T1.TituloDesconto, 0)) - COALESCE( T7.TituloTotalMovimento_F, 0) = 0))");
         if ( ( StringUtil.StrCmp(AV158Wpregistrartitulods_2_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV159Wpregistrartitulods_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV160Wpregistrartitulods_4_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV160Wpregistrartitulods_4_titulovalor1)");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV158Wpregistrartitulods_2_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV159Wpregistrartitulods_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV160Wpregistrartitulods_4_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV160Wpregistrartitulods_4_titulovalor1)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV158Wpregistrartitulods_2_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV159Wpregistrartitulods_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV160Wpregistrartitulods_4_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV160Wpregistrartitulods_4_titulovalor1)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV158Wpregistrartitulods_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV159Wpregistrartitulods_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV161Wpregistrartitulods_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero < :AV161Wpregistrartitulods_5_contabancarianumero1)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV158Wpregistrartitulods_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV159Wpregistrartitulods_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV161Wpregistrartitulods_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero = :AV161Wpregistrartitulods_5_contabancarianumero1)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV158Wpregistrartitulods_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV159Wpregistrartitulods_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV161Wpregistrartitulods_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero > :AV161Wpregistrartitulods_5_contabancarianumero1)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( AV162Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV163Wpregistrartitulods_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV164Wpregistrartitulods_8_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV165Wpregistrartitulods_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV165Wpregistrartitulods_9_titulovalor2)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( AV162Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV163Wpregistrartitulods_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV164Wpregistrartitulods_8_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV165Wpregistrartitulods_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV165Wpregistrartitulods_9_titulovalor2)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( AV162Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV163Wpregistrartitulods_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV164Wpregistrartitulods_8_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV165Wpregistrartitulods_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV165Wpregistrartitulods_9_titulovalor2)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( AV162Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV163Wpregistrartitulods_7_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV164Wpregistrartitulods_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV166Wpregistrartitulods_10_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero < :AV166Wpregistrartitulods_10_contabancarianumero2)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( AV162Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV163Wpregistrartitulods_7_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV164Wpregistrartitulods_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV166Wpregistrartitulods_10_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero = :AV166Wpregistrartitulods_10_contabancarianumero2)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( AV162Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV163Wpregistrartitulods_7_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV164Wpregistrartitulods_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV166Wpregistrartitulods_10_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero > :AV166Wpregistrartitulods_10_contabancarianumero2)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( AV167Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV168Wpregistrartitulods_12_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV169Wpregistrartitulods_13_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV170Wpregistrartitulods_14_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV170Wpregistrartitulods_14_titulovalor3)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( AV167Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV168Wpregistrartitulods_12_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV169Wpregistrartitulods_13_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV170Wpregistrartitulods_14_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV170Wpregistrartitulods_14_titulovalor3)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( AV167Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV168Wpregistrartitulods_12_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV169Wpregistrartitulods_13_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV170Wpregistrartitulods_14_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV170Wpregistrartitulods_14_titulovalor3)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( AV167Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV168Wpregistrartitulods_12_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV169Wpregistrartitulods_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV171Wpregistrartitulods_15_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero < :AV171Wpregistrartitulods_15_contabancarianumero3)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( AV167Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV168Wpregistrartitulods_12_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV169Wpregistrartitulods_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV171Wpregistrartitulods_15_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero = :AV171Wpregistrartitulods_15_contabancarianumero3)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( AV167Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV168Wpregistrartitulods_12_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV169Wpregistrartitulods_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV171Wpregistrartitulods_15_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero > :AV171Wpregistrartitulods_15_contabancarianumero3)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV172Wpregistrartitulods_16_tftituloclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteRazaoSocial like :lV172Wpregistrartitulods_16_tftituloclienterazaosocial)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T6.ClienteRazaoSocial = ( :AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel))");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( StringUtil.StrCmp(AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T6.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T6.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV174Wpregistrartitulods_18_tftitulopropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T5.PropostaDescricao like :lV174Wpregistrartitulods_18_tftitulopropostadescricao)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.PropostaDescricao = ( :AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel))");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( StringUtil.StrCmp(AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T5.PropostaDescricao))=0))");
         }
         if ( AV176Wpregistrartitulods_20_tftitulopropostatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV176Wpregistrartitulods_20_tftitulopropostatipo_sels, "T1.TituloPropostaTipo IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV177Wpregistrartitulods_21_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV177Wpregistrartitulods_21_tftitulovalor)");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV178Wpregistrartitulods_22_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV178Wpregistrartitulods_22_tftitulovalor_to)");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV179Wpregistrartitulods_23_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV179Wpregistrartitulods_23_tftitulodesconto)");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV180Wpregistrartitulods_24_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV180Wpregistrartitulods_24_tftitulodesconto_to)");
         }
         else
         {
            GXv_int8[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV183Wpregistrartitulods_27_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV183Wpregistrartitulods_27_tftituloprorrogacao)");
         }
         else
         {
            GXv_int8[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV184Wpregistrartitulods_28_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV184Wpregistrartitulods_28_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int8[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV185Wpregistrartitulods_29_tftitulojurosmora) )
         {
            AddWhere(sWhereString, "(T1.TituloJurosMora >= :AV185Wpregistrartitulods_29_tftitulojurosmora)");
         }
         else
         {
            GXv_int8[28] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV186Wpregistrartitulods_30_tftitulojurosmora_to) )
         {
            AddWhere(sWhereString, "(T1.TituloJurosMora <= :AV186Wpregistrartitulods_30_tftitulojurosmora_to)");
         }
         else
         {
            GXv_int8[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV187Wpregistrartitulods_31_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(T4.NotaFiscalNumero like :lV187Wpregistrartitulods_31_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int8[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.NotaFiscalNumero = ( :AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int8[31] = 1;
         }
         if ( StringUtil.StrCmp(AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T4.NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloProrrogacao, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloProrrogacao DESC, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T6.ClienteRazaoSocial, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T6.ClienteRazaoSocial DESC, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T5.PropostaDescricao, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T5.PropostaDescricao DESC, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaTipo, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaTipo DESC, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloValor, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloValor DESC, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloDesconto, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloDesconto DESC, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloJurosMora, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloJurosMora DESC, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.NotaFiscalNumero, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.NotaFiscalNumero DESC, T1.TituloId";
         }
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H009M9( IGxContext context ,
                                             string A648TituloPropostaTipo ,
                                             GxSimpleCollection<string> AV176Wpregistrartitulods_20_tftitulopropostatipo_sels ,
                                             string AV158Wpregistrartitulods_2_dynamicfiltersselector1 ,
                                             short AV159Wpregistrartitulods_3_dynamicfiltersoperator1 ,
                                             decimal AV160Wpregistrartitulods_4_titulovalor1 ,
                                             long AV161Wpregistrartitulods_5_contabancarianumero1 ,
                                             bool AV162Wpregistrartitulods_6_dynamicfiltersenabled2 ,
                                             string AV163Wpregistrartitulods_7_dynamicfiltersselector2 ,
                                             short AV164Wpregistrartitulods_8_dynamicfiltersoperator2 ,
                                             decimal AV165Wpregistrartitulods_9_titulovalor2 ,
                                             long AV166Wpregistrartitulods_10_contabancarianumero2 ,
                                             bool AV167Wpregistrartitulods_11_dynamicfiltersenabled3 ,
                                             string AV168Wpregistrartitulods_12_dynamicfiltersselector3 ,
                                             short AV169Wpregistrartitulods_13_dynamicfiltersoperator3 ,
                                             decimal AV170Wpregistrartitulods_14_titulovalor3 ,
                                             long AV171Wpregistrartitulods_15_contabancarianumero3 ,
                                             string AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel ,
                                             string AV172Wpregistrartitulods_16_tftituloclienterazaosocial ,
                                             string AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel ,
                                             string AV174Wpregistrartitulods_18_tftitulopropostadescricao ,
                                             int AV176Wpregistrartitulods_20_tftitulopropostatipo_sels_Count ,
                                             decimal AV177Wpregistrartitulods_21_tftitulovalor ,
                                             decimal AV178Wpregistrartitulods_22_tftitulovalor_to ,
                                             decimal AV179Wpregistrartitulods_23_tftitulodesconto ,
                                             decimal AV180Wpregistrartitulods_24_tftitulodesconto_to ,
                                             DateTime AV183Wpregistrartitulods_27_tftituloprorrogacao ,
                                             DateTime AV184Wpregistrartitulods_28_tftituloprorrogacao_to ,
                                             decimal AV185Wpregistrartitulods_29_tftitulojurosmora ,
                                             decimal AV186Wpregistrartitulods_30_tftitulojurosmora_to ,
                                             string AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel ,
                                             string AV187Wpregistrartitulods_31_tfnotafiscalnumero ,
                                             decimal A262TituloValor ,
                                             long A952ContaBancariaNumero ,
                                             string A972TituloCLienteRazaoSocial ,
                                             string A971TituloPropostaDescricao ,
                                             decimal A276TituloDesconto ,
                                             DateTime A264TituloProrrogacao ,
                                             decimal A498TituloJurosMora ,
                                             string A799NotaFiscalNumero ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV157Wpregistrartitulods_1_filterfulltext ,
                                             string A295TituloCompetencia_F ,
                                             string AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel ,
                                             string AV181Wpregistrartitulods_25_tftitulocompetencia_f ,
                                             int A951ContaBancariaId ,
                                             bool A284TituloDeleted ,
                                             bool A314TituloArchived ,
                                             string A283TituloTipo ,
                                             decimal A275TituloSaldo_F )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[32];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T3.NotaFiscalId, T1.ContaBancariaId, T2.ContaBancariaNumero, T4.NotaFiscalNumero, T1.NotaFiscalParcelamentoID, T1.CategoriaTituloId, T1.TituloCriacao, T1.ContaId, T5.PropostaTaxaAdministrativa, T1.TituloPropostaId AS TituloPropostaId, T1.TituloTipo, T1.TituloJurosMora, T1.TituloMunicipio, T1.TituloBairro, T1.TituloComplemento, T1.TituloNumeroEndereco, T1.TituloLogradouro, T1.TituloCEP, T1.TituloProrrogacao, T1.TituloVencimento, T1.TituloArchived, T1.TituloDeleted, T1.TituloPropostaTipo, T5.PropostaDescricao AS TituloPropostaDescricao, T6.ClienteRazaoSocial AS TituloCLienteRazaoSocial, T1.TituloClienteId AS TituloClienteId, T1.TituloId, T1.TituloDesconto, COALESCE( T7.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F, COALESCE( T8.TituloTotalMovimento_F, 0) AS TituloTotalMultaJuros_F, COALESCE( T9.TituloDataCredito_F, DATE '00010101') AS TituloDataCredito_F, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes, T1.TituloValor, ( COALESCE( T1.TituloValor, 0) - COALESCE( T1.TituloDesconto, 0)) - COALESCE( T7.TituloTotalMovimento_F, 0) AS TituloSaldo_F FROM ((((((((Titulo T1 LEFT JOIN ContaBancaria T2 ON T2.ContaBancariaId = T1.ContaBancariaId) LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN Proposta T5 ON T5.PropostaId = T1.TituloPropostaId) LEFT JOIN Cliente T6 ON T6.ClienteId = T1.TituloClienteId) LEFT JOIN LATERAL (SELECT TituloId, SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE (T1.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T7 ON T7.TituloId = T1.TituloId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T1.TituloId = TituloId)";
         scmdbuf += " AND (Not TituloMovimentoSoma) GROUP BY TituloId ) T8 ON T8.TituloId = T1.TituloId) LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE T1.TituloId = TituloId GROUP BY TituloId ) T9 ON T9.TituloId = T1.TituloId)";
         AddWhere(sWhereString, "((T1.ContaBancariaId = 0) or T1.ContaBancariaId IS NULL)");
         AddWhere(sWhereString, "(Not T1.TituloDeleted)");
         AddWhere(sWhereString, "(Not T1.TituloArchived)");
         AddWhere(sWhereString, "(T1.TituloTipo = ( 'CREDITO'))");
         AddWhere(sWhereString, "(Not (( COALESCE( T1.TituloValor, 0) - COALESCE( T1.TituloDesconto, 0)) - COALESCE( T7.TituloTotalMovimento_F, 0) = 0))");
         if ( ( StringUtil.StrCmp(AV158Wpregistrartitulods_2_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV159Wpregistrartitulods_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV160Wpregistrartitulods_4_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV160Wpregistrartitulods_4_titulovalor1)");
         }
         else
         {
            GXv_int10[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV158Wpregistrartitulods_2_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV159Wpregistrartitulods_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV160Wpregistrartitulods_4_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV160Wpregistrartitulods_4_titulovalor1)");
         }
         else
         {
            GXv_int10[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV158Wpregistrartitulods_2_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV159Wpregistrartitulods_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV160Wpregistrartitulods_4_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV160Wpregistrartitulods_4_titulovalor1)");
         }
         else
         {
            GXv_int10[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV158Wpregistrartitulods_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV159Wpregistrartitulods_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV161Wpregistrartitulods_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero < :AV161Wpregistrartitulods_5_contabancarianumero1)");
         }
         else
         {
            GXv_int10[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV158Wpregistrartitulods_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV159Wpregistrartitulods_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV161Wpregistrartitulods_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero = :AV161Wpregistrartitulods_5_contabancarianumero1)");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV158Wpregistrartitulods_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV159Wpregistrartitulods_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV161Wpregistrartitulods_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero > :AV161Wpregistrartitulods_5_contabancarianumero1)");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( AV162Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV163Wpregistrartitulods_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV164Wpregistrartitulods_8_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV165Wpregistrartitulods_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV165Wpregistrartitulods_9_titulovalor2)");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( AV162Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV163Wpregistrartitulods_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV164Wpregistrartitulods_8_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV165Wpregistrartitulods_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV165Wpregistrartitulods_9_titulovalor2)");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( AV162Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV163Wpregistrartitulods_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV164Wpregistrartitulods_8_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV165Wpregistrartitulods_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV165Wpregistrartitulods_9_titulovalor2)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( AV162Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV163Wpregistrartitulods_7_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV164Wpregistrartitulods_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV166Wpregistrartitulods_10_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero < :AV166Wpregistrartitulods_10_contabancarianumero2)");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( AV162Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV163Wpregistrartitulods_7_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV164Wpregistrartitulods_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV166Wpregistrartitulods_10_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero = :AV166Wpregistrartitulods_10_contabancarianumero2)");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( AV162Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV163Wpregistrartitulods_7_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV164Wpregistrartitulods_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV166Wpregistrartitulods_10_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero > :AV166Wpregistrartitulods_10_contabancarianumero2)");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( AV167Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV168Wpregistrartitulods_12_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV169Wpregistrartitulods_13_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV170Wpregistrartitulods_14_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV170Wpregistrartitulods_14_titulovalor3)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( AV167Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV168Wpregistrartitulods_12_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV169Wpregistrartitulods_13_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV170Wpregistrartitulods_14_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV170Wpregistrartitulods_14_titulovalor3)");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( AV167Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV168Wpregistrartitulods_12_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV169Wpregistrartitulods_13_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV170Wpregistrartitulods_14_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV170Wpregistrartitulods_14_titulovalor3)");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( AV167Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV168Wpregistrartitulods_12_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV169Wpregistrartitulods_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV171Wpregistrartitulods_15_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero < :AV171Wpregistrartitulods_15_contabancarianumero3)");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( AV167Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV168Wpregistrartitulods_12_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV169Wpregistrartitulods_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV171Wpregistrartitulods_15_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero = :AV171Wpregistrartitulods_15_contabancarianumero3)");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( AV167Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV168Wpregistrartitulods_12_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV169Wpregistrartitulods_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV171Wpregistrartitulods_15_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T2.ContaBancariaNumero > :AV171Wpregistrartitulods_15_contabancarianumero3)");
         }
         else
         {
            GXv_int10[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV172Wpregistrartitulods_16_tftituloclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteRazaoSocial like :lV172Wpregistrartitulods_16_tftituloclienterazaosocial)");
         }
         else
         {
            GXv_int10[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T6.ClienteRazaoSocial = ( :AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel))");
         }
         else
         {
            GXv_int10[19] = 1;
         }
         if ( StringUtil.StrCmp(AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T6.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T6.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV174Wpregistrartitulods_18_tftitulopropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T5.PropostaDescricao like :lV174Wpregistrartitulods_18_tftitulopropostadescricao)");
         }
         else
         {
            GXv_int10[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.PropostaDescricao = ( :AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel))");
         }
         else
         {
            GXv_int10[21] = 1;
         }
         if ( StringUtil.StrCmp(AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T5.PropostaDescricao))=0))");
         }
         if ( AV176Wpregistrartitulods_20_tftitulopropostatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV176Wpregistrartitulods_20_tftitulopropostatipo_sels, "T1.TituloPropostaTipo IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV177Wpregistrartitulods_21_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV177Wpregistrartitulods_21_tftitulovalor)");
         }
         else
         {
            GXv_int10[22] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV178Wpregistrartitulods_22_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV178Wpregistrartitulods_22_tftitulovalor_to)");
         }
         else
         {
            GXv_int10[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV179Wpregistrartitulods_23_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV179Wpregistrartitulods_23_tftitulodesconto)");
         }
         else
         {
            GXv_int10[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV180Wpregistrartitulods_24_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV180Wpregistrartitulods_24_tftitulodesconto_to)");
         }
         else
         {
            GXv_int10[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV183Wpregistrartitulods_27_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV183Wpregistrartitulods_27_tftituloprorrogacao)");
         }
         else
         {
            GXv_int10[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV184Wpregistrartitulods_28_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV184Wpregistrartitulods_28_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int10[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV185Wpregistrartitulods_29_tftitulojurosmora) )
         {
            AddWhere(sWhereString, "(T1.TituloJurosMora >= :AV185Wpregistrartitulods_29_tftitulojurosmora)");
         }
         else
         {
            GXv_int10[28] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV186Wpregistrartitulods_30_tftitulojurosmora_to) )
         {
            AddWhere(sWhereString, "(T1.TituloJurosMora <= :AV186Wpregistrartitulods_30_tftitulojurosmora_to)");
         }
         else
         {
            GXv_int10[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV187Wpregistrartitulods_31_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(T4.NotaFiscalNumero like :lV187Wpregistrartitulods_31_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int10[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.NotaFiscalNumero = ( :AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int10[31] = 1;
         }
         if ( StringUtil.StrCmp(AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T4.NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloProrrogacao, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloProrrogacao DESC, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T6.ClienteRazaoSocial, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T6.ClienteRazaoSocial DESC, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T5.PropostaDescricao, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T5.PropostaDescricao DESC, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaTipo, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaTipo DESC, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloValor, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloValor DESC, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloDesconto, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloDesconto DESC, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloJurosMora, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloJurosMora DESC, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.NotaFiscalNumero, T1.TituloId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.NotaFiscalNumero DESC, T1.TituloId";
         }
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      protected Object[] conditional_H009M15( IGxContext context ,
                                              string A648TituloPropostaTipo ,
                                              GxSimpleCollection<string> AV176Wpregistrartitulods_20_tftitulopropostatipo_sels ,
                                              string AV158Wpregistrartitulods_2_dynamicfiltersselector1 ,
                                              short AV159Wpregistrartitulods_3_dynamicfiltersoperator1 ,
                                              decimal AV160Wpregistrartitulods_4_titulovalor1 ,
                                              long AV161Wpregistrartitulods_5_contabancarianumero1 ,
                                              bool AV162Wpregistrartitulods_6_dynamicfiltersenabled2 ,
                                              string AV163Wpregistrartitulods_7_dynamicfiltersselector2 ,
                                              short AV164Wpregistrartitulods_8_dynamicfiltersoperator2 ,
                                              decimal AV165Wpregistrartitulods_9_titulovalor2 ,
                                              long AV166Wpregistrartitulods_10_contabancarianumero2 ,
                                              bool AV167Wpregistrartitulods_11_dynamicfiltersenabled3 ,
                                              string AV168Wpregistrartitulods_12_dynamicfiltersselector3 ,
                                              short AV169Wpregistrartitulods_13_dynamicfiltersoperator3 ,
                                              decimal AV170Wpregistrartitulods_14_titulovalor3 ,
                                              long AV171Wpregistrartitulods_15_contabancarianumero3 ,
                                              string AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel ,
                                              string AV172Wpregistrartitulods_16_tftituloclienterazaosocial ,
                                              string AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel ,
                                              string AV174Wpregistrartitulods_18_tftitulopropostadescricao ,
                                              int AV176Wpregistrartitulods_20_tftitulopropostatipo_sels_Count ,
                                              decimal AV177Wpregistrartitulods_21_tftitulovalor ,
                                              decimal AV178Wpregistrartitulods_22_tftitulovalor_to ,
                                              decimal AV179Wpregistrartitulods_23_tftitulodesconto ,
                                              decimal AV180Wpregistrartitulods_24_tftitulodesconto_to ,
                                              DateTime AV183Wpregistrartitulods_27_tftituloprorrogacao ,
                                              DateTime AV184Wpregistrartitulods_28_tftituloprorrogacao_to ,
                                              decimal AV185Wpregistrartitulods_29_tftitulojurosmora ,
                                              decimal AV186Wpregistrartitulods_30_tftitulojurosmora_to ,
                                              string AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel ,
                                              string AV187Wpregistrartitulods_31_tfnotafiscalnumero ,
                                              decimal A262TituloValor ,
                                              long A952ContaBancariaNumero ,
                                              string A972TituloCLienteRazaoSocial ,
                                              string A971TituloPropostaDescricao ,
                                              decimal A276TituloDesconto ,
                                              DateTime A264TituloProrrogacao ,
                                              decimal A498TituloJurosMora ,
                                              string A799NotaFiscalNumero ,
                                              string AV157Wpregistrartitulods_1_filterfulltext ,
                                              string A295TituloCompetencia_F ,
                                              string AV182Wpregistrartitulods_26_tftitulocompetencia_f_sel ,
                                              string AV181Wpregistrartitulods_25_tftitulocompetencia_f ,
                                              int A951ContaBancariaId ,
                                              bool A284TituloDeleted ,
                                              bool A314TituloArchived ,
                                              decimal A275TituloSaldo_F ,
                                              string A283TituloTipo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[32];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalParcelamentoID, T2.NotaFiscalId, T1.TituloPropostaId AS TituloPropostaId, T1.TituloClienteId AS TituloClienteId, ( COALESCE( T1.TituloValor, 0) - COALESCE( T1.TituloDesconto, 0)) - COALESCE( T7.TituloTotalMovimento_F, 0) AS TituloSaldo_F, T1.TituloTipo, T1.TituloArchived, T1.TituloDeleted, T1.ContaBancariaId, T1.TituloJurosMora, T1.TituloProrrogacao, T6.ContaBancariaNumero, T3.NotaFiscalNumero, T1.TituloPropostaTipo, T4.PropostaDescricao AS TituloPropostaDescricao, T5.ClienteRazaoSocial AS TituloCLienteRazaoSocial, T1.TituloId, T1.TituloValor, T1.TituloDesconto, T7.TituloTotalMovimento_F, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes FROM ((((((Titulo T1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) LEFT JOIN Proposta T4 ON T4.PropostaId = T1.TituloPropostaId) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.TituloClienteId) LEFT JOIN ContaBancaria T6 ON T6.ContaBancariaId = T1.ContaBancariaId) LEFT JOIN LATERAL (SELECT TituloId, SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE (T1.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T7 ON T7.TituloId = T1.TituloId)";
         AddWhere(sWhereString, "((T1.ContaBancariaId = 0) or T1.ContaBancariaId IS NULL)");
         AddWhere(sWhereString, "(Not T1.TituloDeleted)");
         AddWhere(sWhereString, "(Not T1.TituloArchived)");
         AddWhere(sWhereString, "(Not (( COALESCE( T1.TituloValor, 0) - COALESCE( T1.TituloDesconto, 0)) - COALESCE( T7.TituloTotalMovimento_F, 0) = 0))");
         AddWhere(sWhereString, "(T1.TituloTipo = ( 'CREDITO'))");
         if ( ( StringUtil.StrCmp(AV158Wpregistrartitulods_2_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV159Wpregistrartitulods_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV160Wpregistrartitulods_4_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV160Wpregistrartitulods_4_titulovalor1)");
         }
         else
         {
            GXv_int12[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV158Wpregistrartitulods_2_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV159Wpregistrartitulods_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV160Wpregistrartitulods_4_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV160Wpregistrartitulods_4_titulovalor1)");
         }
         else
         {
            GXv_int12[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV158Wpregistrartitulods_2_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV159Wpregistrartitulods_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV160Wpregistrartitulods_4_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV160Wpregistrartitulods_4_titulovalor1)");
         }
         else
         {
            GXv_int12[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV158Wpregistrartitulods_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV159Wpregistrartitulods_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV161Wpregistrartitulods_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T6.ContaBancariaNumero < :AV161Wpregistrartitulods_5_contabancarianumero1)");
         }
         else
         {
            GXv_int12[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV158Wpregistrartitulods_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV159Wpregistrartitulods_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV161Wpregistrartitulods_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T6.ContaBancariaNumero = :AV161Wpregistrartitulods_5_contabancarianumero1)");
         }
         else
         {
            GXv_int12[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV158Wpregistrartitulods_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV159Wpregistrartitulods_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV161Wpregistrartitulods_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T6.ContaBancariaNumero > :AV161Wpregistrartitulods_5_contabancarianumero1)");
         }
         else
         {
            GXv_int12[5] = 1;
         }
         if ( AV162Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV163Wpregistrartitulods_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV164Wpregistrartitulods_8_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV165Wpregistrartitulods_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV165Wpregistrartitulods_9_titulovalor2)");
         }
         else
         {
            GXv_int12[6] = 1;
         }
         if ( AV162Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV163Wpregistrartitulods_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV164Wpregistrartitulods_8_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV165Wpregistrartitulods_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV165Wpregistrartitulods_9_titulovalor2)");
         }
         else
         {
            GXv_int12[7] = 1;
         }
         if ( AV162Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV163Wpregistrartitulods_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV164Wpregistrartitulods_8_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV165Wpregistrartitulods_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV165Wpregistrartitulods_9_titulovalor2)");
         }
         else
         {
            GXv_int12[8] = 1;
         }
         if ( AV162Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV163Wpregistrartitulods_7_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV164Wpregistrartitulods_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV166Wpregistrartitulods_10_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T6.ContaBancariaNumero < :AV166Wpregistrartitulods_10_contabancarianumero2)");
         }
         else
         {
            GXv_int12[9] = 1;
         }
         if ( AV162Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV163Wpregistrartitulods_7_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV164Wpregistrartitulods_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV166Wpregistrartitulods_10_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T6.ContaBancariaNumero = :AV166Wpregistrartitulods_10_contabancarianumero2)");
         }
         else
         {
            GXv_int12[10] = 1;
         }
         if ( AV162Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV163Wpregistrartitulods_7_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV164Wpregistrartitulods_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV166Wpregistrartitulods_10_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T6.ContaBancariaNumero > :AV166Wpregistrartitulods_10_contabancarianumero2)");
         }
         else
         {
            GXv_int12[11] = 1;
         }
         if ( AV167Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV168Wpregistrartitulods_12_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV169Wpregistrartitulods_13_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV170Wpregistrartitulods_14_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV170Wpregistrartitulods_14_titulovalor3)");
         }
         else
         {
            GXv_int12[12] = 1;
         }
         if ( AV167Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV168Wpregistrartitulods_12_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV169Wpregistrartitulods_13_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV170Wpregistrartitulods_14_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV170Wpregistrartitulods_14_titulovalor3)");
         }
         else
         {
            GXv_int12[13] = 1;
         }
         if ( AV167Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV168Wpregistrartitulods_12_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV169Wpregistrartitulods_13_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV170Wpregistrartitulods_14_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV170Wpregistrartitulods_14_titulovalor3)");
         }
         else
         {
            GXv_int12[14] = 1;
         }
         if ( AV167Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV168Wpregistrartitulods_12_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV169Wpregistrartitulods_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV171Wpregistrartitulods_15_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T6.ContaBancariaNumero < :AV171Wpregistrartitulods_15_contabancarianumero3)");
         }
         else
         {
            GXv_int12[15] = 1;
         }
         if ( AV167Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV168Wpregistrartitulods_12_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV169Wpregistrartitulods_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV171Wpregistrartitulods_15_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T6.ContaBancariaNumero = :AV171Wpregistrartitulods_15_contabancarianumero3)");
         }
         else
         {
            GXv_int12[16] = 1;
         }
         if ( AV167Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV168Wpregistrartitulods_12_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV169Wpregistrartitulods_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV171Wpregistrartitulods_15_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T6.ContaBancariaNumero > :AV171Wpregistrartitulods_15_contabancarianumero3)");
         }
         else
         {
            GXv_int12[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV172Wpregistrartitulods_16_tftituloclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV172Wpregistrartitulods_16_tftituloclienterazaosocial)");
         }
         else
         {
            GXv_int12[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel))");
         }
         else
         {
            GXv_int12[19] = 1;
         }
         if ( StringUtil.StrCmp(AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV174Wpregistrartitulods_18_tftitulopropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao like :lV174Wpregistrartitulods_18_tftitulopropostadescricao)");
         }
         else
         {
            GXv_int12[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao = ( :AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel))");
         }
         else
         {
            GXv_int12[21] = 1;
         }
         if ( StringUtil.StrCmp(AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T4.PropostaDescricao))=0))");
         }
         if ( AV176Wpregistrartitulods_20_tftitulopropostatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV176Wpregistrartitulods_20_tftitulopropostatipo_sels, "T1.TituloPropostaTipo IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV177Wpregistrartitulods_21_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV177Wpregistrartitulods_21_tftitulovalor)");
         }
         else
         {
            GXv_int12[22] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV178Wpregistrartitulods_22_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV178Wpregistrartitulods_22_tftitulovalor_to)");
         }
         else
         {
            GXv_int12[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV179Wpregistrartitulods_23_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV179Wpregistrartitulods_23_tftitulodesconto)");
         }
         else
         {
            GXv_int12[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV180Wpregistrartitulods_24_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV180Wpregistrartitulods_24_tftitulodesconto_to)");
         }
         else
         {
            GXv_int12[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV183Wpregistrartitulods_27_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV183Wpregistrartitulods_27_tftituloprorrogacao)");
         }
         else
         {
            GXv_int12[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV184Wpregistrartitulods_28_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV184Wpregistrartitulods_28_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int12[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV185Wpregistrartitulods_29_tftitulojurosmora) )
         {
            AddWhere(sWhereString, "(T1.TituloJurosMora >= :AV185Wpregistrartitulods_29_tftitulojurosmora)");
         }
         else
         {
            GXv_int12[28] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV186Wpregistrartitulods_30_tftitulojurosmora_to) )
         {
            AddWhere(sWhereString, "(T1.TituloJurosMora <= :AV186Wpregistrartitulods_30_tftitulojurosmora_to)");
         }
         else
         {
            GXv_int12[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV187Wpregistrartitulods_31_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero like :lV187Wpregistrartitulods_31_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int12[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero = ( :AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int12[31] = 1;
         }
         if ( StringUtil.StrCmp(AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T3.NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.TituloId";
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
                     return conditional_H009M5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (long)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (decimal)dynConstraints[9] , (long)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (decimal)dynConstraints[27] , (decimal)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (DateTime)dynConstraints[36] , (decimal)dynConstraints[37] , (string)dynConstraints[38] , (short)dynConstraints[39] , (bool)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (int)dynConstraints[45] , (bool)dynConstraints[46] , (bool)dynConstraints[47] , (string)dynConstraints[48] , (decimal)dynConstraints[49] );
               case 1 :
                     return conditional_H009M9(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (long)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (decimal)dynConstraints[9] , (long)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (decimal)dynConstraints[27] , (decimal)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (DateTime)dynConstraints[36] , (decimal)dynConstraints[37] , (string)dynConstraints[38] , (short)dynConstraints[39] , (bool)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (int)dynConstraints[45] , (bool)dynConstraints[46] , (bool)dynConstraints[47] , (string)dynConstraints[48] , (decimal)dynConstraints[49] );
               case 3 :
                     return conditional_H009M15(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (long)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (decimal)dynConstraints[9] , (long)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (decimal)dynConstraints[27] , (decimal)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (DateTime)dynConstraints[36] , (decimal)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (int)dynConstraints[43] , (bool)dynConstraints[44] , (bool)dynConstraints[45] , (decimal)dynConstraints[46] , (string)dynConstraints[47] );
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
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH009M13;
          prmH009M13 = new Object[] {
          new ParDef("AV151TituloIdColItem",GXType.Int32,9,0)
          };
          string cmdBufferH009M13;
          cmdBufferH009M13=" SELECT T7.NotaFiscalId, T1.TituloId, T1.TituloClienteId AS TituloClienteId, T5.ClienteRazaoSocial AS TituloCLienteRazaoSocial, T6.PropostaDescricao AS TituloPropostaDescricao, T1.TituloPropostaTipo, T1.TituloDeleted, T1.TituloArchived, T1.TituloVencimento, T1.TituloProrrogacao, T1.TituloCEP, T1.TituloLogradouro, T1.TituloNumeroEndereco, T1.TituloComplemento, T1.TituloBairro, T1.TituloMunicipio, T1.TituloJurosMora, T1.TituloTipo, T1.TituloPropostaId AS TituloPropostaId, T6.PropostaTaxaAdministrativa, T1.ContaId, T1.TituloCriacao, T1.CategoriaTituloId, T1.NotaFiscalParcelamentoID, T8.NotaFiscalNumero, COALESCE( T2.TituloDataCredito_F, DATE '00010101') AS TituloDataCredito_F, COALESCE( T4.TituloTotalMovimento_F, 0) AS TituloTotalMultaJuros_F, COALESCE( T3.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F, T1.TituloDesconto, T1.TituloValor, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes FROM (((((((Titulo T1 LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE T1.TituloId = TituloId GROUP BY TituloId ) T2 ON T2.TituloId = T1.TituloId) LEFT JOIN LATERAL (SELECT TituloId, SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE (T1.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T3 ON T3.TituloId = T1.TituloId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T1.TituloId = TituloId) AND (Not TituloMovimentoSoma) GROUP BY TituloId ) T4 ON T4.TituloId = T1.TituloId) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.TituloClienteId) LEFT JOIN Proposta T6 ON T6.PropostaId = T1.TituloPropostaId) LEFT JOIN NotaFiscalParcelamento T7 ON T7.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T8 "
          + " ON T8.NotaFiscalId = T7.NotaFiscalId) WHERE T1.TituloId = :AV151TituloIdColItem ORDER BY T1.TituloId" ;
          Object[] prmH009M5;
          prmH009M5 = new Object[] {
          new ParDef("AV160Wpregistrartitulods_4_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV160Wpregistrartitulods_4_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV160Wpregistrartitulods_4_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV161Wpregistrartitulods_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV161Wpregistrartitulods_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV161Wpregistrartitulods_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV165Wpregistrartitulods_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV165Wpregistrartitulods_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV165Wpregistrartitulods_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV166Wpregistrartitulods_10_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV166Wpregistrartitulods_10_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV166Wpregistrartitulods_10_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV170Wpregistrartitulods_14_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV170Wpregistrartitulods_14_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV170Wpregistrartitulods_14_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV171Wpregistrartitulods_15_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV171Wpregistrartitulods_15_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV171Wpregistrartitulods_15_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("lV172Wpregistrartitulods_16_tftituloclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV174Wpregistrartitulods_18_tftitulopropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV177Wpregistrartitulods_21_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV178Wpregistrartitulods_22_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV179Wpregistrartitulods_23_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV180Wpregistrartitulods_24_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV183Wpregistrartitulods_27_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV184Wpregistrartitulods_28_tftituloprorrogacao_to",GXType.Date,8,0) ,
          new ParDef("AV185Wpregistrartitulods_29_tftitulojurosmora",GXType.Number,16,4) ,
          new ParDef("AV186Wpregistrartitulods_30_tftitulojurosmora_to",GXType.Number,16,4) ,
          new ParDef("lV187Wpregistrartitulods_31_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel",GXType.VarChar,40,0)
          };
          Object[] prmH009M9;
          prmH009M9 = new Object[] {
          new ParDef("AV160Wpregistrartitulods_4_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV160Wpregistrartitulods_4_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV160Wpregistrartitulods_4_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV161Wpregistrartitulods_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV161Wpregistrartitulods_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV161Wpregistrartitulods_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV165Wpregistrartitulods_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV165Wpregistrartitulods_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV165Wpregistrartitulods_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV166Wpregistrartitulods_10_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV166Wpregistrartitulods_10_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV166Wpregistrartitulods_10_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV170Wpregistrartitulods_14_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV170Wpregistrartitulods_14_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV170Wpregistrartitulods_14_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV171Wpregistrartitulods_15_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV171Wpregistrartitulods_15_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV171Wpregistrartitulods_15_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("lV172Wpregistrartitulods_16_tftituloclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV174Wpregistrartitulods_18_tftitulopropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV177Wpregistrartitulods_21_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV178Wpregistrartitulods_22_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV179Wpregistrartitulods_23_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV180Wpregistrartitulods_24_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV183Wpregistrartitulods_27_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV184Wpregistrartitulods_28_tftituloprorrogacao_to",GXType.Date,8,0) ,
          new ParDef("AV185Wpregistrartitulods_29_tftitulojurosmora",GXType.Number,16,4) ,
          new ParDef("AV186Wpregistrartitulods_30_tftitulojurosmora_to",GXType.Number,16,4) ,
          new ParDef("lV187Wpregistrartitulods_31_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel",GXType.VarChar,40,0)
          };
          Object[] prmH009M15;
          prmH009M15 = new Object[] {
          new ParDef("AV160Wpregistrartitulods_4_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV160Wpregistrartitulods_4_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV160Wpregistrartitulods_4_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV161Wpregistrartitulods_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV161Wpregistrartitulods_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV161Wpregistrartitulods_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV165Wpregistrartitulods_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV165Wpregistrartitulods_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV165Wpregistrartitulods_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV166Wpregistrartitulods_10_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV166Wpregistrartitulods_10_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV166Wpregistrartitulods_10_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV170Wpregistrartitulods_14_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV170Wpregistrartitulods_14_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV170Wpregistrartitulods_14_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV171Wpregistrartitulods_15_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV171Wpregistrartitulods_15_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV171Wpregistrartitulods_15_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("lV172Wpregistrartitulods_16_tftituloclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV173Wpregistrartitulods_17_tftituloclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV174Wpregistrartitulods_18_tftitulopropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV175Wpregistrartitulods_19_tftitulopropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV177Wpregistrartitulods_21_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV178Wpregistrartitulods_22_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV179Wpregistrartitulods_23_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV180Wpregistrartitulods_24_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV183Wpregistrartitulods_27_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV184Wpregistrartitulods_28_tftituloprorrogacao_to",GXType.Date,8,0) ,
          new ParDef("AV185Wpregistrartitulods_29_tftitulojurosmora",GXType.Number,16,4) ,
          new ParDef("AV186Wpregistrartitulods_30_tftitulojurosmora_to",GXType.Number,16,4) ,
          new ParDef("lV187Wpregistrartitulods_31_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV188Wpregistrartitulods_32_tfnotafiscalnumero_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H009M5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009M5,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H009M9", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009M9,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H009M13", cmdBufferH009M13,false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009M13,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H009M15", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009M15,11, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((Guid[]) buf[8])[0] = rslt.getGuid(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
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
                ((DateTime[]) buf[36])[0] = rslt.getGXDate(19);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((DateTime[]) buf[38])[0] = rslt.getGXDate(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((bool[]) buf[40])[0] = rslt.getBool(21);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((bool[]) buf[42])[0] = rslt.getBool(22);
                ((bool[]) buf[43])[0] = rslt.wasNull(22);
                ((string[]) buf[44])[0] = rslt.getVarchar(23);
                ((bool[]) buf[45])[0] = rslt.wasNull(23);
                ((string[]) buf[46])[0] = rslt.getVarchar(24);
                ((bool[]) buf[47])[0] = rslt.wasNull(24);
                ((string[]) buf[48])[0] = rslt.getVarchar(25);
                ((bool[]) buf[49])[0] = rslt.wasNull(25);
                ((int[]) buf[50])[0] = rslt.getInt(26);
                ((bool[]) buf[51])[0] = rslt.wasNull(26);
                ((int[]) buf[52])[0] = rslt.getInt(27);
                ((decimal[]) buf[53])[0] = rslt.getDecimal(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((decimal[]) buf[55])[0] = rslt.getDecimal(29);
                ((decimal[]) buf[56])[0] = rslt.getDecimal(30);
                ((bool[]) buf[57])[0] = rslt.wasNull(30);
                ((DateTime[]) buf[58])[0] = rslt.getGXDate(31);
                ((bool[]) buf[59])[0] = rslt.wasNull(31);
                ((short[]) buf[60])[0] = rslt.getShort(32);
                ((bool[]) buf[61])[0] = rslt.wasNull(32);
                ((short[]) buf[62])[0] = rslt.getShort(33);
                ((bool[]) buf[63])[0] = rslt.wasNull(33);
                ((decimal[]) buf[64])[0] = rslt.getDecimal(34);
                ((bool[]) buf[65])[0] = rslt.wasNull(34);
                ((decimal[]) buf[66])[0] = rslt.getDecimal(35);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((Guid[]) buf[8])[0] = rslt.getGuid(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
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
                ((DateTime[]) buf[36])[0] = rslt.getGXDate(19);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((DateTime[]) buf[38])[0] = rslt.getGXDate(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((bool[]) buf[40])[0] = rslt.getBool(21);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((bool[]) buf[42])[0] = rslt.getBool(22);
                ((bool[]) buf[43])[0] = rslt.wasNull(22);
                ((string[]) buf[44])[0] = rslt.getVarchar(23);
                ((bool[]) buf[45])[0] = rslt.wasNull(23);
                ((string[]) buf[46])[0] = rslt.getVarchar(24);
                ((bool[]) buf[47])[0] = rslt.wasNull(24);
                ((string[]) buf[48])[0] = rslt.getVarchar(25);
                ((bool[]) buf[49])[0] = rslt.wasNull(25);
                ((int[]) buf[50])[0] = rslt.getInt(26);
                ((bool[]) buf[51])[0] = rslt.wasNull(26);
                ((int[]) buf[52])[0] = rslt.getInt(27);
                ((decimal[]) buf[53])[0] = rslt.getDecimal(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((decimal[]) buf[55])[0] = rslt.getDecimal(29);
                ((decimal[]) buf[56])[0] = rslt.getDecimal(30);
                ((bool[]) buf[57])[0] = rslt.wasNull(30);
                ((DateTime[]) buf[58])[0] = rslt.getGXDate(31);
                ((bool[]) buf[59])[0] = rslt.wasNull(31);
                ((short[]) buf[60])[0] = rslt.getShort(32);
                ((bool[]) buf[61])[0] = rslt.wasNull(32);
                ((short[]) buf[62])[0] = rslt.getShort(33);
                ((bool[]) buf[63])[0] = rslt.wasNull(33);
                ((decimal[]) buf[64])[0] = rslt.getDecimal(34);
                ((bool[]) buf[65])[0] = rslt.wasNull(34);
                ((decimal[]) buf[66])[0] = rslt.getDecimal(35);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((int[]) buf[35])[0] = rslt.getInt(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((decimal[]) buf[37])[0] = rslt.getDecimal(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((int[]) buf[39])[0] = rslt.getInt(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((DateTime[]) buf[41])[0] = rslt.getGXDateTime(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((int[]) buf[43])[0] = rslt.getInt(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((Guid[]) buf[45])[0] = rslt.getGuid(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((DateTime[]) buf[49])[0] = rslt.getGXDate(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((decimal[]) buf[51])[0] = rslt.getDecimal(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((decimal[]) buf[53])[0] = rslt.getDecimal(28);
                ((decimal[]) buf[54])[0] = rslt.getDecimal(29);
                ((bool[]) buf[55])[0] = rslt.wasNull(29);
                ((decimal[]) buf[56])[0] = rslt.getDecimal(30);
                ((bool[]) buf[57])[0] = rslt.wasNull(30);
                ((short[]) buf[58])[0] = rslt.getShort(31);
                ((bool[]) buf[59])[0] = rslt.wasNull(31);
                ((short[]) buf[60])[0] = rslt.getShort(32);
                ((bool[]) buf[61])[0] = rslt.wasNull(32);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((long[]) buf[21])[0] = rslt.getLong(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((int[]) buf[31])[0] = rslt.getInt(17);
                ((decimal[]) buf[32])[0] = rslt.getDecimal(18);
                ((bool[]) buf[33])[0] = rslt.wasNull(18);
                ((decimal[]) buf[34])[0] = rslt.getDecimal(19);
                ((bool[]) buf[35])[0] = rslt.wasNull(19);
                ((decimal[]) buf[36])[0] = rslt.getDecimal(20);
                ((short[]) buf[37])[0] = rslt.getShort(21);
                ((bool[]) buf[38])[0] = rslt.wasNull(21);
                ((short[]) buf[39])[0] = rslt.getShort(22);
                ((bool[]) buf[40])[0] = rslt.wasNull(22);
                return;
       }
    }

 }

}
