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
   public class operacoeslista : GXDataArea
   {
      public operacoeslista( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public operacoeslista( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ClienteId )
      {
         this.AV80ClienteId = aP0_ClienteId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbOperacoesStatus = new GXCombobox();
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
         nRC_GXsfl_39 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_39"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_39_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_39_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_39_idx = GetPar( "sGXsfl_39_idx");
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
         AV80ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
         AV40ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV91Pgmname = GetPar( "Pgmname");
         AV81TFOperacoesId = (int)(Math.Round(NumberUtil.Val( GetPar( "TFOperacoesId"), "."), 18, MidpointRounding.ToEven));
         AV82TFOperacoesId_To = (int)(Math.Round(NumberUtil.Val( GetPar( "TFOperacoesId_To"), "."), 18, MidpointRounding.ToEven));
         AV41TFClienteRazaoSocial = GetPar( "TFClienteRazaoSocial");
         AV42TFClienteRazaoSocial_Sel = GetPar( "TFClienteRazaoSocial_Sel");
         AV43TFOperacoesData = context.localUtil.ParseDateParm( GetPar( "TFOperacoesData"));
         AV44TFOperacoesData_To = context.localUtil.ParseDateParm( GetPar( "TFOperacoesData_To"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV49TFOperacoesStatus_Sels);
         AV50TFOperacoesTaxaEfetiva = NumberUtil.Val( GetPar( "TFOperacoesTaxaEfetiva"), ".");
         AV51TFOperacoesTaxaEfetiva_To = NumberUtil.Val( GetPar( "TFOperacoesTaxaEfetiva_To"), ".");
         AV52TFOperacoesTaxaMora = NumberUtil.Val( GetPar( "TFOperacoesTaxaMora"), ".");
         AV53TFOperacoesTaxaMora_To = NumberUtil.Val( GetPar( "TFOperacoesTaxaMora_To"), ".");
         AV54TFContratoNome = GetPar( "TFContratoNome");
         AV55TFContratoNome_Sel = GetPar( "TFContratoNome_Sel");
         AV56TFOperacoesCreatedAt = context.localUtil.ParseDTimeParm( GetPar( "TFOperacoesCreatedAt"));
         AV57TFOperacoesCreatedAt_To = context.localUtil.ParseDTimeParm( GetPar( "TFOperacoesCreatedAt_To"));
         AV61TFOperacoesUpdateAt = context.localUtil.ParseDTimeParm( GetPar( "TFOperacoesUpdateAt"));
         AV62TFOperacoesUpdateAt_To = context.localUtil.ParseDTimeParm( GetPar( "TFOperacoesUpdateAt_To"));
         AV86ClienteTaxasEfetiva = NumberUtil.Val( GetPar( "ClienteTaxasEfetiva"), ".");
         AV87ClienteTaxasMora = NumberUtil.Val( GetPar( "ClienteTaxasMora"), ".");
         AV88ClienteTaxasFator = NumberUtil.Val( GetPar( "ClienteTaxasFator"), ".");
         AV85ClienteTaxasTipoTarifa = GetPar( "ClienteTaxasTipoTarifa");
         AV84ClienteTaxasTarifa = NumberUtil.Val( GetPar( "ClienteTaxasTarifa"), ".");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV80ClienteId, AV40ManageFiltersExecutionStep, AV91Pgmname, AV81TFOperacoesId, AV82TFOperacoesId_To, AV41TFClienteRazaoSocial, AV42TFClienteRazaoSocial_Sel, AV43TFOperacoesData, AV44TFOperacoesData_To, AV49TFOperacoesStatus_Sels, AV50TFOperacoesTaxaEfetiva, AV51TFOperacoesTaxaEfetiva_To, AV52TFOperacoesTaxaMora, AV53TFOperacoesTaxaMora_To, AV54TFContratoNome, AV55TFContratoNome_Sel, AV56TFOperacoesCreatedAt, AV57TFOperacoesCreatedAt_To, AV61TFOperacoesUpdateAt, AV62TFOperacoesUpdateAt_To, AV86ClienteTaxasEfetiva, AV87ClienteTaxasMora, AV88ClienteTaxasFator, AV85ClienteTaxasTipoTarifa, AV84ClienteTaxasTarifa) ;
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
         PAA12( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTA12( ) ;
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
         GXEncryptionTmp = "operacoeslista"+UrlEncode(StringUtil.LTrimStr(AV80ClienteId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("operacoeslista") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV91Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV91Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTETAXASEFETIVA", StringUtil.LTrim( StringUtil.NToC( AV86ClienteTaxasEfetiva, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETAXASEFETIVA", GetSecureSignedToken( "", context.localUtil.Format( AV86ClienteTaxasEfetiva, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTETAXASMORA", StringUtil.LTrim( StringUtil.NToC( AV87ClienteTaxasMora, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETAXASMORA", GetSecureSignedToken( "", context.localUtil.Format( AV87ClienteTaxasMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTETAXASFATOR", StringUtil.LTrim( StringUtil.NToC( AV88ClienteTaxasFator, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETAXASFATOR", GetSecureSignedToken( "", context.localUtil.Format( AV88ClienteTaxasFator, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTETAXASTIPOTARIFA", AV85ClienteTaxasTipoTarifa);
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETAXASTIPOTARIFA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV85ClienteTaxasTipoTarifa, "")), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTETAXASTARIFA", StringUtil.LTrim( StringUtil.NToC( AV84ClienteTaxasTarifa, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETAXASTARIFA", GetSecureSignedToken( "", context.localUtil.Format( AV84ClienteTaxasTarifa, "ZZZZZZZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV80ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV80ClienteId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV15FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_39", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_39), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV38ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV38ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV68GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV69GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV70GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV66DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV66DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_OPERACOESDATAAUXDATE", context.localUtil.DToC( AV45DDO_OperacoesDataAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_OPERACOESDATAAUXDATETO", context.localUtil.DToC( AV46DDO_OperacoesDataAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_OPERACOESCREATEDATAUXDATE", context.localUtil.DToC( AV58DDO_OperacoesCreatedAtAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_OPERACOESCREATEDATAUXDATETO", context.localUtil.DToC( AV59DDO_OperacoesCreatedAtAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_OPERACOESUPDATEATAUXDATE", context.localUtil.DToC( AV63DDO_OperacoesUpdateAtAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_OPERACOESUPDATEATAUXDATETO", context.localUtil.DToC( AV64DDO_OperacoesUpdateAtAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV91Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV91Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFOPERACOESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV81TFOperacoesId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFOPERACOESID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV82TFOperacoesId_To), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCLIENTERAZAOSOCIAL", AV41TFClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTERAZAOSOCIAL_SEL", AV42TFClienteRazaoSocial_Sel);
         GxWebStd.gx_hidden_field( context, "vTFOPERACOESDATA", context.localUtil.DToC( AV43TFOperacoesData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFOPERACOESDATA_TO", context.localUtil.DToC( AV44TFOperacoesData_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFOPERACOESSTATUS_SELS", AV49TFOperacoesStatus_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFOPERACOESSTATUS_SELS", AV49TFOperacoesStatus_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFOPERACOESTAXAEFETIVA", StringUtil.LTrim( StringUtil.NToC( AV50TFOperacoesTaxaEfetiva, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFOPERACOESTAXAEFETIVA_TO", StringUtil.LTrim( StringUtil.NToC( AV51TFOperacoesTaxaEfetiva_To, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFOPERACOESTAXAMORA", StringUtil.LTrim( StringUtil.NToC( AV52TFOperacoesTaxaMora, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFOPERACOESTAXAMORA_TO", StringUtil.LTrim( StringUtil.NToC( AV53TFOperacoesTaxaMora_To, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCONTRATONOME", AV54TFContratoNome);
         GxWebStd.gx_hidden_field( context, "vTFCONTRATONOME_SEL", AV55TFContratoNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFOPERACOESCREATEDAT", context.localUtil.TToC( AV56TFOperacoesCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFOPERACOESCREATEDAT_TO", context.localUtil.TToC( AV57TFOperacoesCreatedAt_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFOPERACOESUPDATEAT", context.localUtil.TToC( AV61TFOperacoesUpdateAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFOPERACOESUPDATEAT_TO", context.localUtil.TToC( AV62TFOperacoesUpdateAt_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV80ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV80ClienteId), "ZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_hidden_field( context, "vTFOPERACOESSTATUS_SELSJSON", AV48TFOperacoesStatus_SelsJson);
         GxWebStd.gx_hidden_field( context, "vCLIENTETAXASEFETIVA", StringUtil.LTrim( StringUtil.NToC( AV86ClienteTaxasEfetiva, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETAXASEFETIVA", GetSecureSignedToken( "", context.localUtil.Format( AV86ClienteTaxasEfetiva, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTETAXASMORA", StringUtil.LTrim( StringUtil.NToC( AV87ClienteTaxasMora, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETAXASMORA", GetSecureSignedToken( "", context.localUtil.Format( AV87ClienteTaxasMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTETAXASFATOR", StringUtil.LTrim( StringUtil.NToC( AV88ClienteTaxasFator, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETAXASFATOR", GetSecureSignedToken( "", context.localUtil.Format( AV88ClienteTaxasFator, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTETAXASTIPOTARIFA", AV85ClienteTaxasTipoTarifa);
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETAXASTIPOTARIFA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV85ClienteTaxasTipoTarifa, "")), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTETAXASTARIFA", StringUtil.LTrim( StringUtil.NToC( AV84ClienteTaxasTarifa, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETAXASTARIFA", GetSecureSignedToken( "", context.localUtil.Format( AV84ClienteTaxasTarifa, "ZZZZZZZZZZZ9.99"), context));
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
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
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
            WEA12( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTA12( ) ;
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
         GXEncryptionTmp = "operacoeslista"+UrlEncode(StringUtil.LTrimStr(AV80ClienteId,9,0));
         return formatLink("operacoeslista") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "OperacoesLista" ;
      }

      public override string GetPgmdesc( )
      {
         return " Operacoes" ;
      }

      protected void WBA10( )
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
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtniniciaroperacao_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "Iniciar nova operação", bttBtniniciaroperacao_Jsonclick, 5, "Iniciar nova operação", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINICIAROPERACAO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_OperacoesLista.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_OperacoesLista.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_39_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_OperacoesLista.htm");
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
            StartGridControl39( ) ;
         }
         if ( wbEnd == 39 )
         {
            wbEnd = 0;
            nRC_GXsfl_39 = (int)(nGXsfl_39_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV68GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV69GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV70GridAppliedFilters);
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
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV66DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_operacoesdataauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_39_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_operacoesdataauxdatetext_Internalname, AV47DDO_OperacoesDataAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV47DDO_OperacoesDataAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_operacoesdataauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_OperacoesLista.htm");
            /* User Defined Control */
            ucTfoperacoesdata_rangepicker.SetProperty("Start Date", AV45DDO_OperacoesDataAuxDate);
            ucTfoperacoesdata_rangepicker.SetProperty("End Date", AV46DDO_OperacoesDataAuxDateTo);
            ucTfoperacoesdata_rangepicker.Render(context, "wwp.daterangepicker", Tfoperacoesdata_rangepicker_Internalname, "TFOPERACOESDATA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_operacoescreatedatauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_39_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_operacoescreatedatauxdatetext_Internalname, AV60DDO_OperacoesCreatedAtAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV60DDO_OperacoesCreatedAtAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_operacoescreatedatauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_OperacoesLista.htm");
            /* User Defined Control */
            ucTfoperacoescreatedat_rangepicker.SetProperty("Start Date", AV58DDO_OperacoesCreatedAtAuxDate);
            ucTfoperacoescreatedat_rangepicker.SetProperty("End Date", AV59DDO_OperacoesCreatedAtAuxDateTo);
            ucTfoperacoescreatedat_rangepicker.Render(context, "wwp.daterangepicker", Tfoperacoescreatedat_rangepicker_Internalname, "TFOPERACOESCREATEDAT_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_operacoesupdateatauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_39_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_operacoesupdateatauxdatetext_Internalname, AV65DDO_OperacoesUpdateAtAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV65DDO_OperacoesUpdateAtAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_operacoesupdateatauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_OperacoesLista.htm");
            /* User Defined Control */
            ucTfoperacoesupdateat_rangepicker.SetProperty("Start Date", AV63DDO_OperacoesUpdateAtAuxDate);
            ucTfoperacoesupdateat_rangepicker.SetProperty("End Date", AV64DDO_OperacoesUpdateAtAuxDateTo);
            ucTfoperacoesupdateat_rangepicker.Render(context, "wwp.daterangepicker", Tfoperacoesupdateat_rangepicker_Internalname, "TFOPERACOESUPDATEAT_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 39 )
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

      protected void STARTA12( )
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
         Form.Meta.addItem("description", " Operacoes", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPA10( ) ;
      }

      protected void WSA12( )
      {
         STARTA12( ) ;
         EVTA12( ) ;
      }

      protected void EVTA12( )
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
                              E11A12 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12A12 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13A12 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E14A12 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINICIAROPERACAO'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoIniciarOperacao' */
                              E15A12 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E16A12 ();
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
                              nGXsfl_39_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
                              SubsflControlProps_392( ) ;
                              AV71Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri("", false, edtavDisplay_Internalname, AV71Display);
                              AV72Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV72Update);
                              A1010OperacoesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacoesId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n168ClienteId = false;
                              A170ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtClienteRazaoSocial_Internalname));
                              n170ClienteRazaoSocial = false;
                              A1011OperacoesData = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtOperacoesData_Internalname), 0));
                              n1011OperacoesData = false;
                              cmbOperacoesStatus.Name = cmbOperacoesStatus_Internalname;
                              cmbOperacoesStatus.CurrentValue = cgiGet( cmbOperacoesStatus_Internalname);
                              A1012OperacoesStatus = cgiGet( cmbOperacoesStatus_Internalname);
                              n1012OperacoesStatus = false;
                              A1015OperacoesTaxaEfetiva = context.localUtil.CToN( cgiGet( edtOperacoesTaxaEfetiva_Internalname), ",", ".");
                              n1015OperacoesTaxaEfetiva = false;
                              A227ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContratoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n227ContratoId = false;
                              A1016OperacoesTaxaMora = context.localUtil.CToN( cgiGet( edtOperacoesTaxaMora_Internalname), ",", ".");
                              n1016OperacoesTaxaMora = false;
                              A228ContratoNome = cgiGet( edtContratoNome_Internalname);
                              n228ContratoNome = false;
                              A1017OperacoesCreatedAt = context.localUtil.CToT( cgiGet( edtOperacoesCreatedAt_Internalname), 0);
                              n1017OperacoesCreatedAt = false;
                              A1018OperacoesUpdateAt = context.localUtil.CToT( cgiGet( edtOperacoesUpdateAt_Internalname), 0);
                              n1018OperacoesUpdateAt = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E17A12 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E18A12 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E19A12 ();
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

      protected void WEA12( )
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

      protected void PAA12( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "operacoeslista")), "operacoeslista") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "operacoeslista")))) ;
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
                     AV80ClienteId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV80ClienteId", StringUtil.LTrimStr( (decimal)(AV80ClienteId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV80ClienteId), "ZZZZZZZZ9"), context));
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
         SubsflControlProps_392( ) ;
         while ( nGXsfl_39_idx <= nRC_GXsfl_39 )
         {
            sendrow_392( ) ;
            nGXsfl_39_idx = ((subGrid_Islastpage==1)&&(nGXsfl_39_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       string AV15FilterFullText ,
                                       int AV80ClienteId ,
                                       short AV40ManageFiltersExecutionStep ,
                                       string AV91Pgmname ,
                                       int AV81TFOperacoesId ,
                                       int AV82TFOperacoesId_To ,
                                       string AV41TFClienteRazaoSocial ,
                                       string AV42TFClienteRazaoSocial_Sel ,
                                       DateTime AV43TFOperacoesData ,
                                       DateTime AV44TFOperacoesData_To ,
                                       GxSimpleCollection<string> AV49TFOperacoesStatus_Sels ,
                                       decimal AV50TFOperacoesTaxaEfetiva ,
                                       decimal AV51TFOperacoesTaxaEfetiva_To ,
                                       decimal AV52TFOperacoesTaxaMora ,
                                       decimal AV53TFOperacoesTaxaMora_To ,
                                       string AV54TFContratoNome ,
                                       string AV55TFContratoNome_Sel ,
                                       DateTime AV56TFOperacoesCreatedAt ,
                                       DateTime AV57TFOperacoesCreatedAt_To ,
                                       DateTime AV61TFOperacoesUpdateAt ,
                                       DateTime AV62TFOperacoesUpdateAt_To ,
                                       decimal AV86ClienteTaxasEfetiva ,
                                       decimal AV87ClienteTaxasMora ,
                                       decimal AV88ClienteTaxasFator ,
                                       string AV85ClienteTaxasTipoTarifa ,
                                       decimal AV84ClienteTaxasTarifa )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFA12( ) ;
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
         RFA12( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV91Pgmname = "OperacoesLista";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
      }

      protected void RFA12( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 39;
         /* Execute user event: Refresh */
         E18A12 ();
         nGXsfl_39_idx = 1;
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_392( ) ;
         bGXsfl_39_Refreshing = true;
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
            SubsflControlProps_392( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A1012OperacoesStatus ,
                                                 AV99Operacoeslistads_8_tfoperacoesstatus_sels ,
                                                 AV92Operacoeslistads_1_filterfulltext ,
                                                 AV93Operacoeslistads_2_tfoperacoesid ,
                                                 AV94Operacoeslistads_3_tfoperacoesid_to ,
                                                 AV96Operacoeslistads_5_tfclienterazaosocial_sel ,
                                                 AV95Operacoeslistads_4_tfclienterazaosocial ,
                                                 AV97Operacoeslistads_6_tfoperacoesdata ,
                                                 AV98Operacoeslistads_7_tfoperacoesdata_to ,
                                                 AV99Operacoeslistads_8_tfoperacoesstatus_sels.Count ,
                                                 AV100Operacoeslistads_9_tfoperacoestaxaefetiva ,
                                                 AV101Operacoeslistads_10_tfoperacoestaxaefetiva_to ,
                                                 AV102Operacoeslistads_11_tfoperacoestaxamora ,
                                                 AV103Operacoeslistads_12_tfoperacoestaxamora_to ,
                                                 AV105Operacoeslistads_14_tfcontratonome_sel ,
                                                 AV104Operacoeslistads_13_tfcontratonome ,
                                                 AV106Operacoeslistads_15_tfoperacoescreatedat ,
                                                 AV107Operacoeslistads_16_tfoperacoescreatedat_to ,
                                                 AV108Operacoeslistads_17_tfoperacoesupdateat ,
                                                 AV109Operacoeslistads_18_tfoperacoesupdateat_to ,
                                                 A1010OperacoesId ,
                                                 A170ClienteRazaoSocial ,
                                                 A1015OperacoesTaxaEfetiva ,
                                                 A1016OperacoesTaxaMora ,
                                                 A228ContratoNome ,
                                                 A1011OperacoesData ,
                                                 A1017OperacoesCreatedAt ,
                                                 A1018OperacoesUpdateAt ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 A168ClienteId ,
                                                 AV80ClienteId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                                 TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV92Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Operacoeslistads_1_filterfulltext), "%", "");
            lV92Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Operacoeslistads_1_filterfulltext), "%", "");
            lV92Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Operacoeslistads_1_filterfulltext), "%", "");
            lV92Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Operacoeslistads_1_filterfulltext), "%", "");
            lV92Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Operacoeslistads_1_filterfulltext), "%", "");
            lV92Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Operacoeslistads_1_filterfulltext), "%", "");
            lV92Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Operacoeslistads_1_filterfulltext), "%", "");
            lV92Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Operacoeslistads_1_filterfulltext), "%", "");
            lV92Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Operacoeslistads_1_filterfulltext), "%", "");
            lV95Operacoeslistads_4_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV95Operacoeslistads_4_tfclienterazaosocial), "%", "");
            lV104Operacoeslistads_13_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV104Operacoeslistads_13_tfcontratonome), "%", "");
            /* Using cursor H00A12 */
            pr_default.execute(0, new Object[] {AV80ClienteId, lV92Operacoeslistads_1_filterfulltext, lV92Operacoeslistads_1_filterfulltext, lV92Operacoeslistads_1_filterfulltext, lV92Operacoeslistads_1_filterfulltext, lV92Operacoeslistads_1_filterfulltext, lV92Operacoeslistads_1_filterfulltext, lV92Operacoeslistads_1_filterfulltext, lV92Operacoeslistads_1_filterfulltext, lV92Operacoeslistads_1_filterfulltext, AV93Operacoeslistads_2_tfoperacoesid, AV94Operacoeslistads_3_tfoperacoesid_to, lV95Operacoeslistads_4_tfclienterazaosocial, AV96Operacoeslistads_5_tfclienterazaosocial_sel, AV97Operacoeslistads_6_tfoperacoesdata, AV98Operacoeslistads_7_tfoperacoesdata_to, AV100Operacoeslistads_9_tfoperacoestaxaefetiva, AV101Operacoeslistads_10_tfoperacoestaxaefetiva_to, AV102Operacoeslistads_11_tfoperacoestaxamora, AV103Operacoeslistads_12_tfoperacoestaxamora_to, lV104Operacoeslistads_13_tfcontratonome, AV105Operacoeslistads_14_tfcontratonome_sel, AV106Operacoeslistads_15_tfoperacoescreatedat, AV107Operacoeslistads_16_tfoperacoescreatedat_to, AV108Operacoeslistads_17_tfoperacoesupdateat, AV109Operacoeslistads_18_tfoperacoesupdateat_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_39_idx = 1;
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A1018OperacoesUpdateAt = H00A12_A1018OperacoesUpdateAt[0];
               n1018OperacoesUpdateAt = H00A12_n1018OperacoesUpdateAt[0];
               A1017OperacoesCreatedAt = H00A12_A1017OperacoesCreatedAt[0];
               n1017OperacoesCreatedAt = H00A12_n1017OperacoesCreatedAt[0];
               A228ContratoNome = H00A12_A228ContratoNome[0];
               n228ContratoNome = H00A12_n228ContratoNome[0];
               A1016OperacoesTaxaMora = H00A12_A1016OperacoesTaxaMora[0];
               n1016OperacoesTaxaMora = H00A12_n1016OperacoesTaxaMora[0];
               A227ContratoId = H00A12_A227ContratoId[0];
               n227ContratoId = H00A12_n227ContratoId[0];
               A1015OperacoesTaxaEfetiva = H00A12_A1015OperacoesTaxaEfetiva[0];
               n1015OperacoesTaxaEfetiva = H00A12_n1015OperacoesTaxaEfetiva[0];
               A1012OperacoesStatus = H00A12_A1012OperacoesStatus[0];
               n1012OperacoesStatus = H00A12_n1012OperacoesStatus[0];
               A1011OperacoesData = H00A12_A1011OperacoesData[0];
               n1011OperacoesData = H00A12_n1011OperacoesData[0];
               A170ClienteRazaoSocial = H00A12_A170ClienteRazaoSocial[0];
               n170ClienteRazaoSocial = H00A12_n170ClienteRazaoSocial[0];
               A168ClienteId = H00A12_A168ClienteId[0];
               n168ClienteId = H00A12_n168ClienteId[0];
               A1010OperacoesId = H00A12_A1010OperacoesId[0];
               A228ContratoNome = H00A12_A228ContratoNome[0];
               n228ContratoNome = H00A12_n228ContratoNome[0];
               A170ClienteRazaoSocial = H00A12_A170ClienteRazaoSocial[0];
               n170ClienteRazaoSocial = H00A12_n170ClienteRazaoSocial[0];
               /* Execute user event: Grid.Load */
               E19A12 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 39;
            WBA10( ) ;
         }
         bGXsfl_39_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesA12( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV91Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV91Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTETAXASEFETIVA", StringUtil.LTrim( StringUtil.NToC( AV86ClienteTaxasEfetiva, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETAXASEFETIVA", GetSecureSignedToken( "", context.localUtil.Format( AV86ClienteTaxasEfetiva, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTETAXASMORA", StringUtil.LTrim( StringUtil.NToC( AV87ClienteTaxasMora, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETAXASMORA", GetSecureSignedToken( "", context.localUtil.Format( AV87ClienteTaxasMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTETAXASFATOR", StringUtil.LTrim( StringUtil.NToC( AV88ClienteTaxasFator, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETAXASFATOR", GetSecureSignedToken( "", context.localUtil.Format( AV88ClienteTaxasFator, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTETAXASTIPOTARIFA", AV85ClienteTaxasTipoTarifa);
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETAXASTIPOTARIFA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV85ClienteTaxasTipoTarifa, "")), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTETAXASTARIFA", StringUtil.LTrim( StringUtil.NToC( AV84ClienteTaxasTarifa, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETAXASTARIFA", GetSecureSignedToken( "", context.localUtil.Format( AV84ClienteTaxasTarifa, "ZZZZZZZZZZZ9.99"), context));
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
         AV92Operacoeslistads_1_filterfulltext = AV15FilterFullText;
         AV93Operacoeslistads_2_tfoperacoesid = AV81TFOperacoesId;
         AV94Operacoeslistads_3_tfoperacoesid_to = AV82TFOperacoesId_To;
         AV95Operacoeslistads_4_tfclienterazaosocial = AV41TFClienteRazaoSocial;
         AV96Operacoeslistads_5_tfclienterazaosocial_sel = AV42TFClienteRazaoSocial_Sel;
         AV97Operacoeslistads_6_tfoperacoesdata = AV43TFOperacoesData;
         AV98Operacoeslistads_7_tfoperacoesdata_to = AV44TFOperacoesData_To;
         AV99Operacoeslistads_8_tfoperacoesstatus_sels = AV49TFOperacoesStatus_Sels;
         AV100Operacoeslistads_9_tfoperacoestaxaefetiva = AV50TFOperacoesTaxaEfetiva;
         AV101Operacoeslistads_10_tfoperacoestaxaefetiva_to = AV51TFOperacoesTaxaEfetiva_To;
         AV102Operacoeslistads_11_tfoperacoestaxamora = AV52TFOperacoesTaxaMora;
         AV103Operacoeslistads_12_tfoperacoestaxamora_to = AV53TFOperacoesTaxaMora_To;
         AV104Operacoeslistads_13_tfcontratonome = AV54TFContratoNome;
         AV105Operacoeslistads_14_tfcontratonome_sel = AV55TFContratoNome_Sel;
         AV106Operacoeslistads_15_tfoperacoescreatedat = AV56TFOperacoesCreatedAt;
         AV107Operacoeslistads_16_tfoperacoescreatedat_to = AV57TFOperacoesCreatedAt_To;
         AV108Operacoeslistads_17_tfoperacoesupdateat = AV61TFOperacoesUpdateAt;
         AV109Operacoeslistads_18_tfoperacoesupdateat_to = AV62TFOperacoesUpdateAt_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1012OperacoesStatus ,
                                              AV99Operacoeslistads_8_tfoperacoesstatus_sels ,
                                              AV92Operacoeslistads_1_filterfulltext ,
                                              AV93Operacoeslistads_2_tfoperacoesid ,
                                              AV94Operacoeslistads_3_tfoperacoesid_to ,
                                              AV96Operacoeslistads_5_tfclienterazaosocial_sel ,
                                              AV95Operacoeslistads_4_tfclienterazaosocial ,
                                              AV97Operacoeslistads_6_tfoperacoesdata ,
                                              AV98Operacoeslistads_7_tfoperacoesdata_to ,
                                              AV99Operacoeslistads_8_tfoperacoesstatus_sels.Count ,
                                              AV100Operacoeslistads_9_tfoperacoestaxaefetiva ,
                                              AV101Operacoeslistads_10_tfoperacoestaxaefetiva_to ,
                                              AV102Operacoeslistads_11_tfoperacoestaxamora ,
                                              AV103Operacoeslistads_12_tfoperacoestaxamora_to ,
                                              AV105Operacoeslistads_14_tfcontratonome_sel ,
                                              AV104Operacoeslistads_13_tfcontratonome ,
                                              AV106Operacoeslistads_15_tfoperacoescreatedat ,
                                              AV107Operacoeslistads_16_tfoperacoescreatedat_to ,
                                              AV108Operacoeslistads_17_tfoperacoesupdateat ,
                                              AV109Operacoeslistads_18_tfoperacoesupdateat_to ,
                                              A1010OperacoesId ,
                                              A170ClienteRazaoSocial ,
                                              A1015OperacoesTaxaEfetiva ,
                                              A1016OperacoesTaxaMora ,
                                              A228ContratoNome ,
                                              A1011OperacoesData ,
                                              A1017OperacoesCreatedAt ,
                                              A1018OperacoesUpdateAt ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              A168ClienteId ,
                                              AV80ClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV92Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Operacoeslistads_1_filterfulltext), "%", "");
         lV92Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Operacoeslistads_1_filterfulltext), "%", "");
         lV92Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Operacoeslistads_1_filterfulltext), "%", "");
         lV92Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Operacoeslistads_1_filterfulltext), "%", "");
         lV92Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Operacoeslistads_1_filterfulltext), "%", "");
         lV92Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Operacoeslistads_1_filterfulltext), "%", "");
         lV92Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Operacoeslistads_1_filterfulltext), "%", "");
         lV92Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Operacoeslistads_1_filterfulltext), "%", "");
         lV92Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Operacoeslistads_1_filterfulltext), "%", "");
         lV95Operacoeslistads_4_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV95Operacoeslistads_4_tfclienterazaosocial), "%", "");
         lV104Operacoeslistads_13_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV104Operacoeslistads_13_tfcontratonome), "%", "");
         /* Using cursor H00A13 */
         pr_default.execute(1, new Object[] {AV80ClienteId, lV92Operacoeslistads_1_filterfulltext, lV92Operacoeslistads_1_filterfulltext, lV92Operacoeslistads_1_filterfulltext, lV92Operacoeslistads_1_filterfulltext, lV92Operacoeslistads_1_filterfulltext, lV92Operacoeslistads_1_filterfulltext, lV92Operacoeslistads_1_filterfulltext, lV92Operacoeslistads_1_filterfulltext, lV92Operacoeslistads_1_filterfulltext, AV93Operacoeslistads_2_tfoperacoesid, AV94Operacoeslistads_3_tfoperacoesid_to, lV95Operacoeslistads_4_tfclienterazaosocial, AV96Operacoeslistads_5_tfclienterazaosocial_sel, AV97Operacoeslistads_6_tfoperacoesdata, AV98Operacoeslistads_7_tfoperacoesdata_to, AV100Operacoeslistads_9_tfoperacoestaxaefetiva, AV101Operacoeslistads_10_tfoperacoestaxaefetiva_to, AV102Operacoeslistads_11_tfoperacoestaxamora, AV103Operacoeslistads_12_tfoperacoestaxamora_to, lV104Operacoeslistads_13_tfcontratonome, AV105Operacoeslistads_14_tfcontratonome_sel, AV106Operacoeslistads_15_tfoperacoescreatedat, AV107Operacoeslistads_16_tfoperacoescreatedat_to, AV108Operacoeslistads_17_tfoperacoesupdateat, AV109Operacoeslistads_18_tfoperacoesupdateat_to});
         GRID_nRecordCount = H00A13_AGRID_nRecordCount[0];
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
         AV92Operacoeslistads_1_filterfulltext = AV15FilterFullText;
         AV93Operacoeslistads_2_tfoperacoesid = AV81TFOperacoesId;
         AV94Operacoeslistads_3_tfoperacoesid_to = AV82TFOperacoesId_To;
         AV95Operacoeslistads_4_tfclienterazaosocial = AV41TFClienteRazaoSocial;
         AV96Operacoeslistads_5_tfclienterazaosocial_sel = AV42TFClienteRazaoSocial_Sel;
         AV97Operacoeslistads_6_tfoperacoesdata = AV43TFOperacoesData;
         AV98Operacoeslistads_7_tfoperacoesdata_to = AV44TFOperacoesData_To;
         AV99Operacoeslistads_8_tfoperacoesstatus_sels = AV49TFOperacoesStatus_Sels;
         AV100Operacoeslistads_9_tfoperacoestaxaefetiva = AV50TFOperacoesTaxaEfetiva;
         AV101Operacoeslistads_10_tfoperacoestaxaefetiva_to = AV51TFOperacoesTaxaEfetiva_To;
         AV102Operacoeslistads_11_tfoperacoestaxamora = AV52TFOperacoesTaxaMora;
         AV103Operacoeslistads_12_tfoperacoestaxamora_to = AV53TFOperacoesTaxaMora_To;
         AV104Operacoeslistads_13_tfcontratonome = AV54TFContratoNome;
         AV105Operacoeslistads_14_tfcontratonome_sel = AV55TFContratoNome_Sel;
         AV106Operacoeslistads_15_tfoperacoescreatedat = AV56TFOperacoesCreatedAt;
         AV107Operacoeslistads_16_tfoperacoescreatedat_to = AV57TFOperacoesCreatedAt_To;
         AV108Operacoeslistads_17_tfoperacoesupdateat = AV61TFOperacoesUpdateAt;
         AV109Operacoeslistads_18_tfoperacoesupdateat_to = AV62TFOperacoesUpdateAt_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV80ClienteId, AV40ManageFiltersExecutionStep, AV91Pgmname, AV81TFOperacoesId, AV82TFOperacoesId_To, AV41TFClienteRazaoSocial, AV42TFClienteRazaoSocial_Sel, AV43TFOperacoesData, AV44TFOperacoesData_To, AV49TFOperacoesStatus_Sels, AV50TFOperacoesTaxaEfetiva, AV51TFOperacoesTaxaEfetiva_To, AV52TFOperacoesTaxaMora, AV53TFOperacoesTaxaMora_To, AV54TFContratoNome, AV55TFContratoNome_Sel, AV56TFOperacoesCreatedAt, AV57TFOperacoesCreatedAt_To, AV61TFOperacoesUpdateAt, AV62TFOperacoesUpdateAt_To, AV86ClienteTaxasEfetiva, AV87ClienteTaxasMora, AV88ClienteTaxasFator, AV85ClienteTaxasTipoTarifa, AV84ClienteTaxasTarifa) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV92Operacoeslistads_1_filterfulltext = AV15FilterFullText;
         AV93Operacoeslistads_2_tfoperacoesid = AV81TFOperacoesId;
         AV94Operacoeslistads_3_tfoperacoesid_to = AV82TFOperacoesId_To;
         AV95Operacoeslistads_4_tfclienterazaosocial = AV41TFClienteRazaoSocial;
         AV96Operacoeslistads_5_tfclienterazaosocial_sel = AV42TFClienteRazaoSocial_Sel;
         AV97Operacoeslistads_6_tfoperacoesdata = AV43TFOperacoesData;
         AV98Operacoeslistads_7_tfoperacoesdata_to = AV44TFOperacoesData_To;
         AV99Operacoeslistads_8_tfoperacoesstatus_sels = AV49TFOperacoesStatus_Sels;
         AV100Operacoeslistads_9_tfoperacoestaxaefetiva = AV50TFOperacoesTaxaEfetiva;
         AV101Operacoeslistads_10_tfoperacoestaxaefetiva_to = AV51TFOperacoesTaxaEfetiva_To;
         AV102Operacoeslistads_11_tfoperacoestaxamora = AV52TFOperacoesTaxaMora;
         AV103Operacoeslistads_12_tfoperacoestaxamora_to = AV53TFOperacoesTaxaMora_To;
         AV104Operacoeslistads_13_tfcontratonome = AV54TFContratoNome;
         AV105Operacoeslistads_14_tfcontratonome_sel = AV55TFContratoNome_Sel;
         AV106Operacoeslistads_15_tfoperacoescreatedat = AV56TFOperacoesCreatedAt;
         AV107Operacoeslistads_16_tfoperacoescreatedat_to = AV57TFOperacoesCreatedAt_To;
         AV108Operacoeslistads_17_tfoperacoesupdateat = AV61TFOperacoesUpdateAt;
         AV109Operacoeslistads_18_tfoperacoesupdateat_to = AV62TFOperacoesUpdateAt_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV80ClienteId, AV40ManageFiltersExecutionStep, AV91Pgmname, AV81TFOperacoesId, AV82TFOperacoesId_To, AV41TFClienteRazaoSocial, AV42TFClienteRazaoSocial_Sel, AV43TFOperacoesData, AV44TFOperacoesData_To, AV49TFOperacoesStatus_Sels, AV50TFOperacoesTaxaEfetiva, AV51TFOperacoesTaxaEfetiva_To, AV52TFOperacoesTaxaMora, AV53TFOperacoesTaxaMora_To, AV54TFContratoNome, AV55TFContratoNome_Sel, AV56TFOperacoesCreatedAt, AV57TFOperacoesCreatedAt_To, AV61TFOperacoesUpdateAt, AV62TFOperacoesUpdateAt_To, AV86ClienteTaxasEfetiva, AV87ClienteTaxasMora, AV88ClienteTaxasFator, AV85ClienteTaxasTipoTarifa, AV84ClienteTaxasTarifa) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV92Operacoeslistads_1_filterfulltext = AV15FilterFullText;
         AV93Operacoeslistads_2_tfoperacoesid = AV81TFOperacoesId;
         AV94Operacoeslistads_3_tfoperacoesid_to = AV82TFOperacoesId_To;
         AV95Operacoeslistads_4_tfclienterazaosocial = AV41TFClienteRazaoSocial;
         AV96Operacoeslistads_5_tfclienterazaosocial_sel = AV42TFClienteRazaoSocial_Sel;
         AV97Operacoeslistads_6_tfoperacoesdata = AV43TFOperacoesData;
         AV98Operacoeslistads_7_tfoperacoesdata_to = AV44TFOperacoesData_To;
         AV99Operacoeslistads_8_tfoperacoesstatus_sels = AV49TFOperacoesStatus_Sels;
         AV100Operacoeslistads_9_tfoperacoestaxaefetiva = AV50TFOperacoesTaxaEfetiva;
         AV101Operacoeslistads_10_tfoperacoestaxaefetiva_to = AV51TFOperacoesTaxaEfetiva_To;
         AV102Operacoeslistads_11_tfoperacoestaxamora = AV52TFOperacoesTaxaMora;
         AV103Operacoeslistads_12_tfoperacoestaxamora_to = AV53TFOperacoesTaxaMora_To;
         AV104Operacoeslistads_13_tfcontratonome = AV54TFContratoNome;
         AV105Operacoeslistads_14_tfcontratonome_sel = AV55TFContratoNome_Sel;
         AV106Operacoeslistads_15_tfoperacoescreatedat = AV56TFOperacoesCreatedAt;
         AV107Operacoeslistads_16_tfoperacoescreatedat_to = AV57TFOperacoesCreatedAt_To;
         AV108Operacoeslistads_17_tfoperacoesupdateat = AV61TFOperacoesUpdateAt;
         AV109Operacoeslistads_18_tfoperacoesupdateat_to = AV62TFOperacoesUpdateAt_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV80ClienteId, AV40ManageFiltersExecutionStep, AV91Pgmname, AV81TFOperacoesId, AV82TFOperacoesId_To, AV41TFClienteRazaoSocial, AV42TFClienteRazaoSocial_Sel, AV43TFOperacoesData, AV44TFOperacoesData_To, AV49TFOperacoesStatus_Sels, AV50TFOperacoesTaxaEfetiva, AV51TFOperacoesTaxaEfetiva_To, AV52TFOperacoesTaxaMora, AV53TFOperacoesTaxaMora_To, AV54TFContratoNome, AV55TFContratoNome_Sel, AV56TFOperacoesCreatedAt, AV57TFOperacoesCreatedAt_To, AV61TFOperacoesUpdateAt, AV62TFOperacoesUpdateAt_To, AV86ClienteTaxasEfetiva, AV87ClienteTaxasMora, AV88ClienteTaxasFator, AV85ClienteTaxasTipoTarifa, AV84ClienteTaxasTarifa) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV92Operacoeslistads_1_filterfulltext = AV15FilterFullText;
         AV93Operacoeslistads_2_tfoperacoesid = AV81TFOperacoesId;
         AV94Operacoeslistads_3_tfoperacoesid_to = AV82TFOperacoesId_To;
         AV95Operacoeslistads_4_tfclienterazaosocial = AV41TFClienteRazaoSocial;
         AV96Operacoeslistads_5_tfclienterazaosocial_sel = AV42TFClienteRazaoSocial_Sel;
         AV97Operacoeslistads_6_tfoperacoesdata = AV43TFOperacoesData;
         AV98Operacoeslistads_7_tfoperacoesdata_to = AV44TFOperacoesData_To;
         AV99Operacoeslistads_8_tfoperacoesstatus_sels = AV49TFOperacoesStatus_Sels;
         AV100Operacoeslistads_9_tfoperacoestaxaefetiva = AV50TFOperacoesTaxaEfetiva;
         AV101Operacoeslistads_10_tfoperacoestaxaefetiva_to = AV51TFOperacoesTaxaEfetiva_To;
         AV102Operacoeslistads_11_tfoperacoestaxamora = AV52TFOperacoesTaxaMora;
         AV103Operacoeslistads_12_tfoperacoestaxamora_to = AV53TFOperacoesTaxaMora_To;
         AV104Operacoeslistads_13_tfcontratonome = AV54TFContratoNome;
         AV105Operacoeslistads_14_tfcontratonome_sel = AV55TFContratoNome_Sel;
         AV106Operacoeslistads_15_tfoperacoescreatedat = AV56TFOperacoesCreatedAt;
         AV107Operacoeslistads_16_tfoperacoescreatedat_to = AV57TFOperacoesCreatedAt_To;
         AV108Operacoeslistads_17_tfoperacoesupdateat = AV61TFOperacoesUpdateAt;
         AV109Operacoeslistads_18_tfoperacoesupdateat_to = AV62TFOperacoesUpdateAt_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV80ClienteId, AV40ManageFiltersExecutionStep, AV91Pgmname, AV81TFOperacoesId, AV82TFOperacoesId_To, AV41TFClienteRazaoSocial, AV42TFClienteRazaoSocial_Sel, AV43TFOperacoesData, AV44TFOperacoesData_To, AV49TFOperacoesStatus_Sels, AV50TFOperacoesTaxaEfetiva, AV51TFOperacoesTaxaEfetiva_To, AV52TFOperacoesTaxaMora, AV53TFOperacoesTaxaMora_To, AV54TFContratoNome, AV55TFContratoNome_Sel, AV56TFOperacoesCreatedAt, AV57TFOperacoesCreatedAt_To, AV61TFOperacoesUpdateAt, AV62TFOperacoesUpdateAt_To, AV86ClienteTaxasEfetiva, AV87ClienteTaxasMora, AV88ClienteTaxasFator, AV85ClienteTaxasTipoTarifa, AV84ClienteTaxasTarifa) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV92Operacoeslistads_1_filterfulltext = AV15FilterFullText;
         AV93Operacoeslistads_2_tfoperacoesid = AV81TFOperacoesId;
         AV94Operacoeslistads_3_tfoperacoesid_to = AV82TFOperacoesId_To;
         AV95Operacoeslistads_4_tfclienterazaosocial = AV41TFClienteRazaoSocial;
         AV96Operacoeslistads_5_tfclienterazaosocial_sel = AV42TFClienteRazaoSocial_Sel;
         AV97Operacoeslistads_6_tfoperacoesdata = AV43TFOperacoesData;
         AV98Operacoeslistads_7_tfoperacoesdata_to = AV44TFOperacoesData_To;
         AV99Operacoeslistads_8_tfoperacoesstatus_sels = AV49TFOperacoesStatus_Sels;
         AV100Operacoeslistads_9_tfoperacoestaxaefetiva = AV50TFOperacoesTaxaEfetiva;
         AV101Operacoeslistads_10_tfoperacoestaxaefetiva_to = AV51TFOperacoesTaxaEfetiva_To;
         AV102Operacoeslistads_11_tfoperacoestaxamora = AV52TFOperacoesTaxaMora;
         AV103Operacoeslistads_12_tfoperacoestaxamora_to = AV53TFOperacoesTaxaMora_To;
         AV104Operacoeslistads_13_tfcontratonome = AV54TFContratoNome;
         AV105Operacoeslistads_14_tfcontratonome_sel = AV55TFContratoNome_Sel;
         AV106Operacoeslistads_15_tfoperacoescreatedat = AV56TFOperacoesCreatedAt;
         AV107Operacoeslistads_16_tfoperacoescreatedat_to = AV57TFOperacoesCreatedAt_To;
         AV108Operacoeslistads_17_tfoperacoesupdateat = AV61TFOperacoesUpdateAt;
         AV109Operacoeslistads_18_tfoperacoesupdateat_to = AV62TFOperacoesUpdateAt_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV80ClienteId, AV40ManageFiltersExecutionStep, AV91Pgmname, AV81TFOperacoesId, AV82TFOperacoesId_To, AV41TFClienteRazaoSocial, AV42TFClienteRazaoSocial_Sel, AV43TFOperacoesData, AV44TFOperacoesData_To, AV49TFOperacoesStatus_Sels, AV50TFOperacoesTaxaEfetiva, AV51TFOperacoesTaxaEfetiva_To, AV52TFOperacoesTaxaMora, AV53TFOperacoesTaxaMora_To, AV54TFContratoNome, AV55TFContratoNome_Sel, AV56TFOperacoesCreatedAt, AV57TFOperacoesCreatedAt_To, AV61TFOperacoesUpdateAt, AV62TFOperacoesUpdateAt_To, AV86ClienteTaxasEfetiva, AV87ClienteTaxasMora, AV88ClienteTaxasFator, AV85ClienteTaxasTipoTarifa, AV84ClienteTaxasTarifa) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV91Pgmname = "OperacoesLista";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtOperacoesId_Enabled = 0;
         edtClienteId_Enabled = 0;
         edtClienteRazaoSocial_Enabled = 0;
         edtOperacoesData_Enabled = 0;
         cmbOperacoesStatus.Enabled = 0;
         edtOperacoesTaxaEfetiva_Enabled = 0;
         edtContratoId_Enabled = 0;
         edtOperacoesTaxaMora_Enabled = 0;
         edtContratoNome_Enabled = 0;
         edtOperacoesCreatedAt_Enabled = 0;
         edtOperacoesUpdateAt_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPA10( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17A12 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV38ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV66DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_39 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_39"), ",", "."), 18, MidpointRounding.ToEven));
            AV68GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV69GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV70GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV45DDO_OperacoesDataAuxDate = context.localUtil.CToD( cgiGet( "vDDO_OPERACOESDATAAUXDATE"), 0);
            AV46DDO_OperacoesDataAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_OPERACOESDATAAUXDATETO"), 0);
            AV58DDO_OperacoesCreatedAtAuxDate = context.localUtil.CToD( cgiGet( "vDDO_OPERACOESCREATEDATAUXDATE"), 0);
            AssignAttri("", false, "AV58DDO_OperacoesCreatedAtAuxDate", context.localUtil.Format(AV58DDO_OperacoesCreatedAtAuxDate, "99/99/99"));
            AV59DDO_OperacoesCreatedAtAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_OPERACOESCREATEDATAUXDATETO"), 0);
            AssignAttri("", false, "AV59DDO_OperacoesCreatedAtAuxDateTo", context.localUtil.Format(AV59DDO_OperacoesCreatedAtAuxDateTo, "99/99/99"));
            AV63DDO_OperacoesUpdateAtAuxDate = context.localUtil.CToD( cgiGet( "vDDO_OPERACOESUPDATEATAUXDATE"), 0);
            AssignAttri("", false, "AV63DDO_OperacoesUpdateAtAuxDate", context.localUtil.Format(AV63DDO_OperacoesUpdateAtAuxDate, "99/99/99"));
            AV64DDO_OperacoesUpdateAtAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_OPERACOESUPDATEATAUXDATETO"), 0);
            AssignAttri("", false, "AV64DDO_OperacoesUpdateAtAuxDateTo", context.localUtil.Format(AV64DDO_OperacoesUpdateAtAuxDateTo, "99/99/99"));
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
            Grid_empowerer_Fixedcolumns = cgiGet( "GRID_EMPOWERER_Fixedcolumns");
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
            AV47DDO_OperacoesDataAuxDateText = cgiGet( edtavDdo_operacoesdataauxdatetext_Internalname);
            AssignAttri("", false, "AV47DDO_OperacoesDataAuxDateText", AV47DDO_OperacoesDataAuxDateText);
            AV60DDO_OperacoesCreatedAtAuxDateText = cgiGet( edtavDdo_operacoescreatedatauxdatetext_Internalname);
            AssignAttri("", false, "AV60DDO_OperacoesCreatedAtAuxDateText", AV60DDO_OperacoesCreatedAtAuxDateText);
            AV65DDO_OperacoesUpdateAtAuxDateText = cgiGet( edtavDdo_operacoesupdateatauxdatetext_Internalname);
            AssignAttri("", false, "AV65DDO_OperacoesUpdateAtAuxDateText", AV65DDO_OperacoesUpdateAtAuxDateText);
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
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E17A12 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E17A12( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFOPERACOESUPDATEAT_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_operacoesupdateatauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFOPERACOESCREATEDAT_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_operacoescreatedatauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFOPERACOESDATA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_operacoesdataauxdatetext_Internalname});
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
         Form.Caption = " Operacoes";
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
         if ( AV13OrderedBy < 1 )
         {
            AV13OrderedBy = 1;
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV66DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV66DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         /* Using cursor H00A14 */
         pr_default.execute(2, new Object[] {AV80ClienteId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A168ClienteId = H00A14_A168ClienteId[0];
            n168ClienteId = H00A14_n168ClienteId[0];
            A1039ClienteTipoRisco = H00A14_A1039ClienteTipoRisco[0];
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1039ClienteTipoRisco)) )
            {
               AV83ClienteTipoRisco = A1039ClienteTipoRisco;
               AssignAttri("", false, "AV83ClienteTipoRisco", AV83ClienteTipoRisco);
            }
            else
            {
               AV83ClienteTipoRisco = "SEM_RISCO";
               AssignAttri("", false, "AV83ClienteTipoRisco", AV83ClienteTipoRisco);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         /* Using cursor H00A15 */
         pr_default.execute(3, new Object[] {AV83ClienteTipoRisco});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A1009ClienteTaxasTipo = H00A15_A1009ClienteTaxasTipo[0];
            n1009ClienteTaxasTipo = H00A15_n1009ClienteTaxasTipo[0];
            A1040ClienteTaxasEfetiva = H00A15_A1040ClienteTaxasEfetiva[0];
            n1040ClienteTaxasEfetiva = H00A15_n1040ClienteTaxasEfetiva[0];
            A1041ClienteTaxasMora = H00A15_A1041ClienteTaxasMora[0];
            n1041ClienteTaxasMora = H00A15_n1041ClienteTaxasMora[0];
            A1042ClienteTaxasFator = H00A15_A1042ClienteTaxasFator[0];
            n1042ClienteTaxasFator = H00A15_n1042ClienteTaxasFator[0];
            A1043ClienteTaxasTipoTarifa = H00A15_A1043ClienteTaxasTipoTarifa[0];
            n1043ClienteTaxasTipoTarifa = H00A15_n1043ClienteTaxasTipoTarifa[0];
            A1044ClienteTaxasTarifa = H00A15_A1044ClienteTaxasTarifa[0];
            n1044ClienteTaxasTarifa = H00A15_n1044ClienteTaxasTarifa[0];
            AV86ClienteTaxasEfetiva = A1040ClienteTaxasEfetiva;
            AssignAttri("", false, "AV86ClienteTaxasEfetiva", StringUtil.LTrimStr( AV86ClienteTaxasEfetiva, 16, 4));
            GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETAXASEFETIVA", GetSecureSignedToken( "", context.localUtil.Format( AV86ClienteTaxasEfetiva, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
            AV87ClienteTaxasMora = A1041ClienteTaxasMora;
            AssignAttri("", false, "AV87ClienteTaxasMora", StringUtil.LTrimStr( AV87ClienteTaxasMora, 16, 4));
            GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETAXASMORA", GetSecureSignedToken( "", context.localUtil.Format( AV87ClienteTaxasMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
            AV88ClienteTaxasFator = A1042ClienteTaxasFator;
            AssignAttri("", false, "AV88ClienteTaxasFator", StringUtil.LTrimStr( AV88ClienteTaxasFator, 16, 4));
            GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETAXASFATOR", GetSecureSignedToken( "", context.localUtil.Format( AV88ClienteTaxasFator, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
            AV85ClienteTaxasTipoTarifa = A1043ClienteTaxasTipoTarifa;
            AssignAttri("", false, "AV85ClienteTaxasTipoTarifa", AV85ClienteTaxasTipoTarifa);
            GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETAXASTIPOTARIFA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV85ClienteTaxasTipoTarifa, "")), context));
            AV84ClienteTaxasTarifa = A1044ClienteTaxasTarifa;
            AssignAttri("", false, "AV84ClienteTaxasTarifa", StringUtil.LTrimStr( AV84ClienteTaxasTarifa, 15, 2));
            GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETAXASTARIFA", GetSecureSignedToken( "", context.localUtil.Format( AV84ClienteTaxasTarifa, "ZZZZZZZZZZZ9.99"), context));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
      }

      protected void E18A12( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV40ManageFiltersExecutionStep == 1 )
         {
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV40ManageFiltersExecutionStep == 2 )
         {
            AV40ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
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
         AV68GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV68GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV68GridCurrentPage), 10, 0));
         AV69GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV69GridPageCount", StringUtil.LTrimStr( (decimal)(AV69GridPageCount), 10, 0));
         GXt_char2 = AV70GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV91Pgmname, out  GXt_char2) ;
         AV70GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV70GridAppliedFilters", AV70GridAppliedFilters);
         AV92Operacoeslistads_1_filterfulltext = AV15FilterFullText;
         AV93Operacoeslistads_2_tfoperacoesid = AV81TFOperacoesId;
         AV94Operacoeslistads_3_tfoperacoesid_to = AV82TFOperacoesId_To;
         AV95Operacoeslistads_4_tfclienterazaosocial = AV41TFClienteRazaoSocial;
         AV96Operacoeslistads_5_tfclienterazaosocial_sel = AV42TFClienteRazaoSocial_Sel;
         AV97Operacoeslistads_6_tfoperacoesdata = AV43TFOperacoesData;
         AV98Operacoeslistads_7_tfoperacoesdata_to = AV44TFOperacoesData_To;
         AV99Operacoeslistads_8_tfoperacoesstatus_sels = AV49TFOperacoesStatus_Sels;
         AV100Operacoeslistads_9_tfoperacoestaxaefetiva = AV50TFOperacoesTaxaEfetiva;
         AV101Operacoeslistads_10_tfoperacoestaxaefetiva_to = AV51TFOperacoesTaxaEfetiva_To;
         AV102Operacoeslistads_11_tfoperacoestaxamora = AV52TFOperacoesTaxaMora;
         AV103Operacoeslistads_12_tfoperacoestaxamora_to = AV53TFOperacoesTaxaMora_To;
         AV104Operacoeslistads_13_tfcontratonome = AV54TFContratoNome;
         AV105Operacoeslistads_14_tfcontratonome_sel = AV55TFContratoNome_Sel;
         AV106Operacoeslistads_15_tfoperacoescreatedat = AV56TFOperacoesCreatedAt;
         AV107Operacoeslistads_16_tfoperacoescreatedat_to = AV57TFOperacoesCreatedAt_To;
         AV108Operacoeslistads_17_tfoperacoesupdateat = AV61TFOperacoesUpdateAt;
         AV109Operacoeslistads_18_tfoperacoesupdateat_to = AV62TFOperacoesUpdateAt_To;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E12A12( )
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
            AV67PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV67PageToGo) ;
         }
      }

      protected void E13A12( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14A12( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacoesId") == 0 )
            {
               AV81TFOperacoesId = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV81TFOperacoesId", StringUtil.LTrimStr( (decimal)(AV81TFOperacoesId), 9, 0));
               AV82TFOperacoesId_To = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV82TFOperacoesId_To", StringUtil.LTrimStr( (decimal)(AV82TFOperacoesId_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteRazaoSocial") == 0 )
            {
               AV41TFClienteRazaoSocial = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV41TFClienteRazaoSocial", AV41TFClienteRazaoSocial);
               AV42TFClienteRazaoSocial_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV42TFClienteRazaoSocial_Sel", AV42TFClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacoesData") == 0 )
            {
               AV43TFOperacoesData = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV43TFOperacoesData", context.localUtil.Format(AV43TFOperacoesData, "99/99/99"));
               AV44TFOperacoesData_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV44TFOperacoesData_To", context.localUtil.Format(AV44TFOperacoesData_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacoesStatus") == 0 )
            {
               AV48TFOperacoesStatus_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV48TFOperacoesStatus_SelsJson", AV48TFOperacoesStatus_SelsJson);
               AV49TFOperacoesStatus_Sels.FromJSonString(AV48TFOperacoesStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacoesTaxaEfetiva") == 0 )
            {
               AV50TFOperacoesTaxaEfetiva = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV50TFOperacoesTaxaEfetiva", StringUtil.LTrimStr( AV50TFOperacoesTaxaEfetiva, 16, 4));
               AV51TFOperacoesTaxaEfetiva_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV51TFOperacoesTaxaEfetiva_To", StringUtil.LTrimStr( AV51TFOperacoesTaxaEfetiva_To, 16, 4));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacoesTaxaMora") == 0 )
            {
               AV52TFOperacoesTaxaMora = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV52TFOperacoesTaxaMora", StringUtil.LTrimStr( AV52TFOperacoesTaxaMora, 16, 4));
               AV53TFOperacoesTaxaMora_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV53TFOperacoesTaxaMora_To", StringUtil.LTrimStr( AV53TFOperacoesTaxaMora_To, 16, 4));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ContratoNome") == 0 )
            {
               AV54TFContratoNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV54TFContratoNome", AV54TFContratoNome);
               AV55TFContratoNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV55TFContratoNome_Sel", AV55TFContratoNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacoesCreatedAt") == 0 )
            {
               AV56TFOperacoesCreatedAt = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV56TFOperacoesCreatedAt", context.localUtil.TToC( AV56TFOperacoesCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV57TFOperacoesCreatedAt_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV57TFOperacoesCreatedAt_To", context.localUtil.TToC( AV57TFOperacoesCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV57TFOperacoesCreatedAt_To) )
               {
                  AV57TFOperacoesCreatedAt_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV57TFOperacoesCreatedAt_To)), (short)(DateTimeUtil.Month( AV57TFOperacoesCreatedAt_To)), (short)(DateTimeUtil.Day( AV57TFOperacoesCreatedAt_To)), 23, 59, 59);
                  AssignAttri("", false, "AV57TFOperacoesCreatedAt_To", context.localUtil.TToC( AV57TFOperacoesCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacoesUpdateAt") == 0 )
            {
               AV61TFOperacoesUpdateAt = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV61TFOperacoesUpdateAt", context.localUtil.TToC( AV61TFOperacoesUpdateAt, 8, 5, 0, 3, "/", ":", " "));
               AV62TFOperacoesUpdateAt_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV62TFOperacoesUpdateAt_To", context.localUtil.TToC( AV62TFOperacoesUpdateAt_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV62TFOperacoesUpdateAt_To) )
               {
                  AV62TFOperacoesUpdateAt_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV62TFOperacoesUpdateAt_To)), (short)(DateTimeUtil.Month( AV62TFOperacoesUpdateAt_To)), (short)(DateTimeUtil.Day( AV62TFOperacoesUpdateAt_To)), 23, 59, 59);
                  AssignAttri("", false, "AV62TFOperacoesUpdateAt_To", context.localUtil.TToC( AV62TFOperacoesUpdateAt_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV49TFOperacoesStatus_Sels", AV49TFOperacoesStatus_Sels);
      }

      private void E19A12( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV71Display = "<i class=\"fa fa-search\"></i>";
         AssignAttri("", false, edtavDisplay_Internalname, AV71Display);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "operacao"+UrlEncode(StringUtil.LTrimStr(A1010OperacoesId,9,0)) + "," + UrlEncode(StringUtil.RTrim("DSP"));
         edtavDisplay_Link = formatLink("operacao") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV72Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV72Update);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "operacao"+UrlEncode(StringUtil.LTrimStr(A1010OperacoesId,9,0)) + "," + UrlEncode(StringUtil.RTrim("UPD"));
         edtavUpdate_Link = formatLink("operacao") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "contrato"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A227ContratoId,6,0));
         edtContratoNome_Link = formatLink("contrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 39;
         }
         sendrow_392( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_39_Refreshing )
         {
            DoAjaxLoad(39, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E11A12( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("OperacoesListaFilters")) + "," + UrlEncode(StringUtil.RTrim(AV91Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("OperacoesListaFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV39ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "OperacoesListaFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV39ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV91Pgmname+"GridState",  AV39ManageFiltersXml) ;
               AV10GridState.FromXml(AV39ManageFiltersXml, null, "", "");
               AV13OrderedBy = AV10GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV49TFOperacoesStatus_Sels", AV49TFOperacoesStatus_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E15A12( )
      {
         /* 'DoIniciarOperacao' Routine */
         returnInSub = false;
         AV77Operacao = new SdtOperacoes(context);
         AV77Operacao.gxTpr_Clienteid = AV80ClienteId;
         AV77Operacao.gxTpr_Operacoesdata = DateTimeUtil.ServerDate( context, pr_default);
         AV77Operacao.gxTpr_Operacoesstatus = "PENDENTE";
         AV77Operacao.gxTv_SdtOperacoes_Contratoid_SetNull();
         AV77Operacao.gxTpr_Operacoescreatedat = DateTimeUtil.ServerNow( context, pr_default);
         AV77Operacao.gxTpr_Operacoestaxaefetiva = AV86ClienteTaxasEfetiva;
         AV77Operacao.gxTpr_Operacoestaxamora = AV87ClienteTaxasMora;
         AV77Operacao.gxTpr_Operacoesfator = AV88ClienteTaxasFator;
         AV77Operacao.gxTpr_Operacoestipotarifa = AV85ClienteTaxasTipoTarifa;
         AV77Operacao.gxTpr_Operacoestarifa = AV84ClienteTaxasTarifa;
         AV77Operacao.Save();
         if ( AV77Operacao.Success() )
         {
            context.CommitDataStores("operacoeslista",pr_default);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "operacao"+UrlEncode(StringUtil.LTrimStr(AV77Operacao.gxTpr_Operacoesid,9,0)) + "," + UrlEncode(StringUtil.RTrim("INS"));
            CallWebObject(formatLink("operacao") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            context.RollbackDataStores("operacoeslista",pr_default);
            GXt_char2 = ((GeneXus.Utils.SdtMessages_Message)AV77Operacao.GetMessages().Item(1)).gxTpr_Description;
            new message(context ).gxep_erro( ref  GXt_char2) ;
            ((GeneXus.Utils.SdtMessages_Message)AV77Operacao.GetMessages().Item(1)).gxTpr_Description = GXt_char2;
         }
      }

      protected void E16A12( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         new operacoeslistaexport(context ).execute( out  AV35ExcelFilename, out  AV36ErrorMessage) ;
         if ( StringUtil.StrCmp(AV35ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV35ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV36ErrorMessage);
         }
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV38ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "OperacoesListaFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV38ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S162( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV81TFOperacoesId = 0;
         AssignAttri("", false, "AV81TFOperacoesId", StringUtil.LTrimStr( (decimal)(AV81TFOperacoesId), 9, 0));
         AV82TFOperacoesId_To = 0;
         AssignAttri("", false, "AV82TFOperacoesId_To", StringUtil.LTrimStr( (decimal)(AV82TFOperacoesId_To), 9, 0));
         AV41TFClienteRazaoSocial = "";
         AssignAttri("", false, "AV41TFClienteRazaoSocial", AV41TFClienteRazaoSocial);
         AV42TFClienteRazaoSocial_Sel = "";
         AssignAttri("", false, "AV42TFClienteRazaoSocial_Sel", AV42TFClienteRazaoSocial_Sel);
         AV43TFOperacoesData = DateTime.MinValue;
         AssignAttri("", false, "AV43TFOperacoesData", context.localUtil.Format(AV43TFOperacoesData, "99/99/99"));
         AV44TFOperacoesData_To = DateTime.MinValue;
         AssignAttri("", false, "AV44TFOperacoesData_To", context.localUtil.Format(AV44TFOperacoesData_To, "99/99/99"));
         AV49TFOperacoesStatus_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV50TFOperacoesTaxaEfetiva = 0;
         AssignAttri("", false, "AV50TFOperacoesTaxaEfetiva", StringUtil.LTrimStr( AV50TFOperacoesTaxaEfetiva, 16, 4));
         AV51TFOperacoesTaxaEfetiva_To = 0;
         AssignAttri("", false, "AV51TFOperacoesTaxaEfetiva_To", StringUtil.LTrimStr( AV51TFOperacoesTaxaEfetiva_To, 16, 4));
         AV52TFOperacoesTaxaMora = 0;
         AssignAttri("", false, "AV52TFOperacoesTaxaMora", StringUtil.LTrimStr( AV52TFOperacoesTaxaMora, 16, 4));
         AV53TFOperacoesTaxaMora_To = 0;
         AssignAttri("", false, "AV53TFOperacoesTaxaMora_To", StringUtil.LTrimStr( AV53TFOperacoesTaxaMora_To, 16, 4));
         AV54TFContratoNome = "";
         AssignAttri("", false, "AV54TFContratoNome", AV54TFContratoNome);
         AV55TFContratoNome_Sel = "";
         AssignAttri("", false, "AV55TFContratoNome_Sel", AV55TFContratoNome_Sel);
         AV56TFOperacoesCreatedAt = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV56TFOperacoesCreatedAt", context.localUtil.TToC( AV56TFOperacoesCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         AV57TFOperacoesCreatedAt_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV57TFOperacoesCreatedAt_To", context.localUtil.TToC( AV57TFOperacoesCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
         AV61TFOperacoesUpdateAt = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV61TFOperacoesUpdateAt", context.localUtil.TToC( AV61TFOperacoesUpdateAt, 8, 5, 0, 3, "/", ":", " "));
         AV62TFOperacoesUpdateAt_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV62TFOperacoesUpdateAt_To", context.localUtil.TToC( AV62TFOperacoesUpdateAt_To, 8, 5, 0, 3, "/", ":", " "));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV37Session.Get(AV91Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV91Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV37Session.Get(AV91Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV10GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV10GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S172( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV110GXV1 = 1;
         while ( AV110GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV110GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFOPERACOESID") == 0 )
            {
               AV81TFOperacoesId = (int)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV81TFOperacoesId", StringUtil.LTrimStr( (decimal)(AV81TFOperacoesId), 9, 0));
               AV82TFOperacoesId_To = (int)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV82TFOperacoesId_To", StringUtil.LTrimStr( (decimal)(AV82TFOperacoesId_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV41TFClienteRazaoSocial = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFClienteRazaoSocial", AV41TFClienteRazaoSocial);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV42TFClienteRazaoSocial_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFClienteRazaoSocial_Sel", AV42TFClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFOPERACOESDATA") == 0 )
            {
               AV43TFOperacoesData = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV43TFOperacoesData", context.localUtil.Format(AV43TFOperacoesData, "99/99/99"));
               AV44TFOperacoesData_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV44TFOperacoesData_To", context.localUtil.Format(AV44TFOperacoesData_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFOPERACOESSTATUS_SEL") == 0 )
            {
               AV48TFOperacoesStatus_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV48TFOperacoesStatus_SelsJson", AV48TFOperacoesStatus_SelsJson);
               AV49TFOperacoesStatus_Sels.FromJSonString(AV48TFOperacoesStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFOPERACOESTAXAEFETIVA") == 0 )
            {
               AV50TFOperacoesTaxaEfetiva = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV50TFOperacoesTaxaEfetiva", StringUtil.LTrimStr( AV50TFOperacoesTaxaEfetiva, 16, 4));
               AV51TFOperacoesTaxaEfetiva_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV51TFOperacoesTaxaEfetiva_To", StringUtil.LTrimStr( AV51TFOperacoesTaxaEfetiva_To, 16, 4));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFOPERACOESTAXAMORA") == 0 )
            {
               AV52TFOperacoesTaxaMora = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV52TFOperacoesTaxaMora", StringUtil.LTrimStr( AV52TFOperacoesTaxaMora, 16, 4));
               AV53TFOperacoesTaxaMora_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV53TFOperacoesTaxaMora_To", StringUtil.LTrimStr( AV53TFOperacoesTaxaMora_To, 16, 4));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME") == 0 )
            {
               AV54TFContratoNome = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV54TFContratoNome", AV54TFContratoNome);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME_SEL") == 0 )
            {
               AV55TFContratoNome_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV55TFContratoNome_Sel", AV55TFContratoNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFOPERACOESCREATEDAT") == 0 )
            {
               AV56TFOperacoesCreatedAt = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV56TFOperacoesCreatedAt", context.localUtil.TToC( AV56TFOperacoesCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV57TFOperacoesCreatedAt_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV57TFOperacoesCreatedAt_To", context.localUtil.TToC( AV57TFOperacoesCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               AV58DDO_OperacoesCreatedAtAuxDate = DateTimeUtil.ResetTime(AV56TFOperacoesCreatedAt);
               AssignAttri("", false, "AV58DDO_OperacoesCreatedAtAuxDate", context.localUtil.Format(AV58DDO_OperacoesCreatedAtAuxDate, "99/99/99"));
               AV59DDO_OperacoesCreatedAtAuxDateTo = DateTimeUtil.ResetTime(AV57TFOperacoesCreatedAt_To);
               AssignAttri("", false, "AV59DDO_OperacoesCreatedAtAuxDateTo", context.localUtil.Format(AV59DDO_OperacoesCreatedAtAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFOPERACOESUPDATEAT") == 0 )
            {
               AV61TFOperacoesUpdateAt = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV61TFOperacoesUpdateAt", context.localUtil.TToC( AV61TFOperacoesUpdateAt, 8, 5, 0, 3, "/", ":", " "));
               AV62TFOperacoesUpdateAt_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV62TFOperacoesUpdateAt_To", context.localUtil.TToC( AV62TFOperacoesUpdateAt_To, 8, 5, 0, 3, "/", ":", " "));
               AV63DDO_OperacoesUpdateAtAuxDate = DateTimeUtil.ResetTime(AV61TFOperacoesUpdateAt);
               AssignAttri("", false, "AV63DDO_OperacoesUpdateAtAuxDate", context.localUtil.Format(AV63DDO_OperacoesUpdateAtAuxDate, "99/99/99"));
               AV64DDO_OperacoesUpdateAtAuxDateTo = DateTimeUtil.ResetTime(AV62TFOperacoesUpdateAt_To);
               AssignAttri("", false, "AV64DDO_OperacoesUpdateAtAuxDateTo", context.localUtil.Format(AV64DDO_OperacoesUpdateAtAuxDateTo, "99/99/99"));
            }
            AV110GXV1 = (int)(AV110GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFClienteRazaoSocial_Sel)),  AV42TFClienteRazaoSocial_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV49TFOperacoesStatus_Sels.Count==0),  AV48TFOperacoesStatus_SelsJson, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV55TFContratoNome_Sel)),  AV55TFContratoNome_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char2+"||"+GXt_char4+"|||"+GXt_char5+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFClienteRazaoSocial)),  AV41TFClienteRazaoSocial, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV54TFContratoNome)),  AV54TFContratoNome, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = ((0==AV81TFOperacoesId) ? "" : StringUtil.Str( (decimal)(AV81TFOperacoesId), 9, 0))+"|"+GXt_char5+"|"+((DateTime.MinValue==AV43TFOperacoesData) ? "" : context.localUtil.DToC( AV43TFOperacoesData, 4, "/"))+"||"+((Convert.ToDecimal(0)==AV50TFOperacoesTaxaEfetiva) ? "" : StringUtil.Str( AV50TFOperacoesTaxaEfetiva, 16, 4))+"|"+((Convert.ToDecimal(0)==AV52TFOperacoesTaxaMora) ? "" : StringUtil.Str( AV52TFOperacoesTaxaMora, 16, 4))+"|"+GXt_char4+"|"+((DateTime.MinValue==AV56TFOperacoesCreatedAt) ? "" : context.localUtil.DToC( AV58DDO_OperacoesCreatedAtAuxDate, 4, "/"))+"|"+((DateTime.MinValue==AV61TFOperacoesUpdateAt) ? "" : context.localUtil.DToC( AV63DDO_OperacoesUpdateAtAuxDate, 4, "/"));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV82TFOperacoesId_To) ? "" : StringUtil.Str( (decimal)(AV82TFOperacoesId_To), 9, 0))+"||"+((DateTime.MinValue==AV44TFOperacoesData_To) ? "" : context.localUtil.DToC( AV44TFOperacoesData_To, 4, "/"))+"||"+((Convert.ToDecimal(0)==AV51TFOperacoesTaxaEfetiva_To) ? "" : StringUtil.Str( AV51TFOperacoesTaxaEfetiva_To, 16, 4))+"|"+((Convert.ToDecimal(0)==AV53TFOperacoesTaxaMora_To) ? "" : StringUtil.Str( AV53TFOperacoesTaxaMora_To, 16, 4))+"||"+((DateTime.MinValue==AV57TFOperacoesCreatedAt_To) ? "" : context.localUtil.DToC( AV59DDO_OperacoesCreatedAtAuxDateTo, 4, "/"))+"|"+((DateTime.MinValue==AV62TFOperacoesUpdateAt_To) ? "" : context.localUtil.DToC( AV64DDO_OperacoesUpdateAtAuxDateTo, 4, "/"));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV37Session.Get(AV91Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFOPERACOESID",  "Identificador",  !((0==AV81TFOperacoesId)&&(0==AV82TFOperacoesId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV81TFOperacoesId), 9, 0)),  ((0==AV81TFOperacoesId) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV81TFOperacoesId), "ZZZZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV82TFOperacoesId_To), 9, 0)),  ((0==AV82TFOperacoesId_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV82TFOperacoesId_To), "ZZZZZZZZ9")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIENTERAZAOSOCIAL",  "Razão social",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFClienteRazaoSocial)),  0,  AV41TFClienteRazaoSocial,  AV41TFClienteRazaoSocial,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFClienteRazaoSocial_Sel)),  AV42TFClienteRazaoSocial_Sel,  AV42TFClienteRazaoSocial_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFOPERACOESDATA",  "Data",  !((DateTime.MinValue==AV43TFOperacoesData)&&(DateTime.MinValue==AV44TFOperacoesData_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV43TFOperacoesData, 4, "/")),  ((DateTime.MinValue==AV43TFOperacoesData) ? "" : StringUtil.Trim( context.localUtil.Format( AV43TFOperacoesData, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV44TFOperacoesData_To, 4, "/")),  ((DateTime.MinValue==AV44TFOperacoesData_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV44TFOperacoesData_To, "99/99/99")))) ;
         AV76AuxText = ((AV49TFOperacoesStatus_Sels.Count==1) ? "["+((string)AV49TFOperacoesStatus_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFOPERACOESSTATUS_SEL",  "Status",  !(AV49TFOperacoesStatus_Sels.Count==0),  0,  AV49TFOperacoesStatus_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV76AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV76AuxText, "[PENDENTE]", "Pendente"), "[APROVADA]", "Aprovada"), "[RECUSADA]", "Recusada"), "[LIQUIDADA]", "Liquidada")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFOPERACOESTAXAEFETIVA",  "Taxa",  !((Convert.ToDecimal(0)==AV50TFOperacoesTaxaEfetiva)&&(Convert.ToDecimal(0)==AV51TFOperacoesTaxaEfetiva_To)),  0,  StringUtil.Trim( StringUtil.Str( AV50TFOperacoesTaxaEfetiva, 16, 4)),  ((Convert.ToDecimal(0)==AV50TFOperacoesTaxaEfetiva) ? "" : StringUtil.Trim( context.localUtil.Format( AV50TFOperacoesTaxaEfetiva, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"))),  true,  StringUtil.Trim( StringUtil.Str( AV51TFOperacoesTaxaEfetiva_To, 16, 4)),  ((Convert.ToDecimal(0)==AV51TFOperacoesTaxaEfetiva_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV51TFOperacoesTaxaEfetiva_To, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFOPERACOESTAXAMORA",  "Mora",  !((Convert.ToDecimal(0)==AV52TFOperacoesTaxaMora)&&(Convert.ToDecimal(0)==AV53TFOperacoesTaxaMora_To)),  0,  StringUtil.Trim( StringUtil.Str( AV52TFOperacoesTaxaMora, 16, 4)),  ((Convert.ToDecimal(0)==AV52TFOperacoesTaxaMora) ? "" : StringUtil.Trim( context.localUtil.Format( AV52TFOperacoesTaxaMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"))),  true,  StringUtil.Trim( StringUtil.Str( AV53TFOperacoesTaxaMora_To, 16, 4)),  ((Convert.ToDecimal(0)==AV53TFOperacoesTaxaMora_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV53TFOperacoesTaxaMora_To, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCONTRATONOME",  "Contrato",  !String.IsNullOrEmpty(StringUtil.RTrim( AV54TFContratoNome)),  0,  AV54TFContratoNome,  AV54TFContratoNome,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV55TFContratoNome_Sel)),  AV55TFContratoNome_Sel,  AV55TFContratoNome_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFOPERACOESCREATEDAT",  "Criado em",  !((DateTime.MinValue==AV56TFOperacoesCreatedAt)&&(DateTime.MinValue==AV57TFOperacoesCreatedAt_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV56TFOperacoesCreatedAt, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV56TFOperacoesCreatedAt) ? "" : StringUtil.Trim( context.localUtil.Format( AV56TFOperacoesCreatedAt, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV57TFOperacoesCreatedAt_To, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV57TFOperacoesCreatedAt_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV57TFOperacoesCreatedAt_To, "99/99/99 99:99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFOPERACOESUPDATEAT",  "Atualizado em",  !((DateTime.MinValue==AV61TFOperacoesUpdateAt)&&(DateTime.MinValue==AV62TFOperacoesUpdateAt_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV61TFOperacoesUpdateAt, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV61TFOperacoesUpdateAt) ? "" : StringUtil.Trim( context.localUtil.Format( AV61TFOperacoesUpdateAt, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV62TFOperacoesUpdateAt_To, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV62TFOperacoesUpdateAt_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV62TFOperacoesUpdateAt_To, "99/99/99 99:99")))) ;
         if ( ! (0==AV80ClienteId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&CLIENTEID";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV80ClienteId), 9, 0);
            AV10GridState.gxTpr_Filtervalues.Add(AV11GridStateFilterValue, 0);
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV91Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV91Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Operacoes";
         AV37Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV80ClienteId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV80ClienteId", StringUtil.LTrimStr( (decimal)(AV80ClienteId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV80ClienteId), "ZZZZZZZZ9"), context));
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
         PAA12( ) ;
         WSA12( ) ;
         WEA12( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019291518", true, true);
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
         context.AddJavascriptSource("operacoeslista.js", "?202561019291519", false, true);
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
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_392( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_39_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_39_idx;
         edtOperacoesId_Internalname = "OPERACOESID_"+sGXsfl_39_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_39_idx;
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL_"+sGXsfl_39_idx;
         edtOperacoesData_Internalname = "OPERACOESDATA_"+sGXsfl_39_idx;
         cmbOperacoesStatus_Internalname = "OPERACOESSTATUS_"+sGXsfl_39_idx;
         edtOperacoesTaxaEfetiva_Internalname = "OPERACOESTAXAEFETIVA_"+sGXsfl_39_idx;
         edtContratoId_Internalname = "CONTRATOID_"+sGXsfl_39_idx;
         edtOperacoesTaxaMora_Internalname = "OPERACOESTAXAMORA_"+sGXsfl_39_idx;
         edtContratoNome_Internalname = "CONTRATONOME_"+sGXsfl_39_idx;
         edtOperacoesCreatedAt_Internalname = "OPERACOESCREATEDAT_"+sGXsfl_39_idx;
         edtOperacoesUpdateAt_Internalname = "OPERACOESUPDATEAT_"+sGXsfl_39_idx;
      }

      protected void SubsflControlProps_fel_392( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_39_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_39_fel_idx;
         edtOperacoesId_Internalname = "OPERACOESID_"+sGXsfl_39_fel_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_39_fel_idx;
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL_"+sGXsfl_39_fel_idx;
         edtOperacoesData_Internalname = "OPERACOESDATA_"+sGXsfl_39_fel_idx;
         cmbOperacoesStatus_Internalname = "OPERACOESSTATUS_"+sGXsfl_39_fel_idx;
         edtOperacoesTaxaEfetiva_Internalname = "OPERACOESTAXAEFETIVA_"+sGXsfl_39_fel_idx;
         edtContratoId_Internalname = "CONTRATOID_"+sGXsfl_39_fel_idx;
         edtOperacoesTaxaMora_Internalname = "OPERACOESTAXAMORA_"+sGXsfl_39_fel_idx;
         edtContratoNome_Internalname = "CONTRATONOME_"+sGXsfl_39_fel_idx;
         edtOperacoesCreatedAt_Internalname = "OPERACOESCREATEDAT_"+sGXsfl_39_fel_idx;
         edtOperacoesUpdateAt_Internalname = "OPERACOESUPDATEAT_"+sGXsfl_39_fel_idx;
      }

      protected void sendrow_392( )
      {
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_392( ) ;
         WBA10( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_39_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_39_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_39_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_39_idx + "',39)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV71Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",(string)"Mostrar",(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_39_idx + "',39)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV72Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacoesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1010OperacoesId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1010OperacoesId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacoesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteRazaoSocial_Internalname,(string)A170ClienteRazaoSocial,StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteRazaoSocial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacoesData_Internalname,context.localUtil.Format(A1011OperacoesData, "99/99/99"),context.localUtil.Format( A1011OperacoesData, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacoesData_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbOperacoesStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "OPERACOESSTATUS_" + sGXsfl_39_idx;
               cmbOperacoesStatus.Name = GXCCtl;
               cmbOperacoesStatus.WebTags = "";
               cmbOperacoesStatus.addItem("PENDENTE", "Pendente", 0);
               cmbOperacoesStatus.addItem("APROVADA", "Aprovada", 0);
               cmbOperacoesStatus.addItem("RECUSADA", "Recusada", 0);
               cmbOperacoesStatus.addItem("LIQUIDADA", "Liquidada", 0);
               if ( cmbOperacoesStatus.ItemCount > 0 )
               {
                  A1012OperacoesStatus = cmbOperacoesStatus.getValidValue(A1012OperacoesStatus);
                  n1012OperacoesStatus = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbOperacoesStatus,(string)cmbOperacoesStatus_Internalname,StringUtil.RTrim( A1012OperacoesStatus),(short)1,(string)cmbOperacoesStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbOperacoesStatus.CurrentValue = StringUtil.RTrim( A1012OperacoesStatus);
            AssignProp("", false, cmbOperacoesStatus_Internalname, "Values", (string)(cmbOperacoesStatus.ToJavascriptSource()), !bGXsfl_39_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacoesTaxaEfetiva_Internalname,StringUtil.LTrim( StringUtil.NToC( A1015OperacoesTaxaEfetiva, 21, 4, ",", "")),StringUtil.LTrim( context.localUtil.Format( A1015OperacoesTaxaEfetiva, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacoesTaxaEfetiva_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentual",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContratoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A227ContratoId), "ZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContratoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacoesTaxaMora_Internalname,StringUtil.LTrim( StringUtil.NToC( A1016OperacoesTaxaMora, 21, 4, ",", "")),StringUtil.LTrim( context.localUtil.Format( A1016OperacoesTaxaMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacoesTaxaMora_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentual",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContratoNome_Internalname,(string)A228ContratoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtContratoNome_Link,(string)"",(string)"",(string)"",(string)edtContratoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)125,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacoesCreatedAt_Internalname,context.localUtil.TToC( A1017OperacoesCreatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A1017OperacoesCreatedAt, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacoesCreatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacoesUpdateAt_Internalname,context.localUtil.TToC( A1018OperacoesUpdateAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A1018OperacoesUpdateAt, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacoesUpdateAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesA12( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_39_idx = ((subGrid_Islastpage==1)&&(nGXsfl_39_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
         }
         /* End function sendrow_392 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "OPERACOESSTATUS_" + sGXsfl_39_idx;
         cmbOperacoesStatus.Name = GXCCtl;
         cmbOperacoesStatus.WebTags = "";
         cmbOperacoesStatus.addItem("PENDENTE", "Pendente", 0);
         cmbOperacoesStatus.addItem("APROVADA", "Aprovada", 0);
         cmbOperacoesStatus.addItem("RECUSADA", "Recusada", 0);
         cmbOperacoesStatus.addItem("LIQUIDADA", "Liquidada", 0);
         if ( cmbOperacoesStatus.ItemCount > 0 )
         {
            A1012OperacoesStatus = cmbOperacoesStatus.getValidValue(A1012OperacoesStatus);
            n1012OperacoesStatus = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl39( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"39\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Identificador") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Razão social") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Data") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Taxa") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Mora") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Contrato") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV71Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV72Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1010OperacoesId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A170ClienteRazaoSocial));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A1011OperacoesData, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1012OperacoesStatus));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A1015OperacoesTaxaEfetiva, 21, 4, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A1016OperacoesTaxaMora, 21, 4, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A228ContratoNome));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtContratoNome_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A1017OperacoesCreatedAt, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A1018OperacoesUpdateAt, 10, 8, 0, 3, "/", ":", " ")));
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
         bttBtniniciaroperacao_Internalname = "BTNINICIAROPERACAO";
         bttBtnexport_Internalname = "BTNEXPORT";
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
         edtOperacoesId_Internalname = "OPERACOESID";
         edtClienteId_Internalname = "CLIENTEID";
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL";
         edtOperacoesData_Internalname = "OPERACOESDATA";
         cmbOperacoesStatus_Internalname = "OPERACOESSTATUS";
         edtOperacoesTaxaEfetiva_Internalname = "OPERACOESTAXAEFETIVA";
         edtContratoId_Internalname = "CONTRATOID";
         edtOperacoesTaxaMora_Internalname = "OPERACOESTAXAMORA";
         edtContratoNome_Internalname = "CONTRATONOME";
         edtOperacoesCreatedAt_Internalname = "OPERACOESCREATEDAT";
         edtOperacoesUpdateAt_Internalname = "OPERACOESUPDATEAT";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_operacoesdataauxdatetext_Internalname = "vDDO_OPERACOESDATAAUXDATETEXT";
         Tfoperacoesdata_rangepicker_Internalname = "TFOPERACOESDATA_RANGEPICKER";
         divDdo_operacoesdataauxdates_Internalname = "DDO_OPERACOESDATAAUXDATES";
         edtavDdo_operacoescreatedatauxdatetext_Internalname = "vDDO_OPERACOESCREATEDATAUXDATETEXT";
         Tfoperacoescreatedat_rangepicker_Internalname = "TFOPERACOESCREATEDAT_RANGEPICKER";
         divDdo_operacoescreatedatauxdates_Internalname = "DDO_OPERACOESCREATEDATAUXDATES";
         edtavDdo_operacoesupdateatauxdatetext_Internalname = "vDDO_OPERACOESUPDATEATAUXDATETEXT";
         Tfoperacoesupdateat_rangepicker_Internalname = "TFOPERACOESUPDATEAT_RANGEPICKER";
         divDdo_operacoesupdateatauxdates_Internalname = "DDO_OPERACOESUPDATEATAUXDATES";
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
         edtOperacoesUpdateAt_Jsonclick = "";
         edtOperacoesCreatedAt_Jsonclick = "";
         edtContratoNome_Jsonclick = "";
         edtContratoNome_Link = "";
         edtOperacoesTaxaMora_Jsonclick = "";
         edtContratoId_Jsonclick = "";
         edtOperacoesTaxaEfetiva_Jsonclick = "";
         cmbOperacoesStatus_Jsonclick = "";
         edtOperacoesData_Jsonclick = "";
         edtClienteRazaoSocial_Jsonclick = "";
         edtClienteId_Jsonclick = "";
         edtOperacoesId_Jsonclick = "";
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         edtavDisplay_Jsonclick = "";
         edtavDisplay_Link = "";
         edtavDisplay_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         edtOperacoesUpdateAt_Enabled = 0;
         edtOperacoesCreatedAt_Enabled = 0;
         edtContratoNome_Enabled = 0;
         edtOperacoesTaxaMora_Enabled = 0;
         edtContratoId_Enabled = 0;
         edtOperacoesTaxaEfetiva_Enabled = 0;
         cmbOperacoesStatus.Enabled = 0;
         edtOperacoesData_Enabled = 0;
         edtClienteRazaoSocial_Enabled = 0;
         edtClienteId_Enabled = 0;
         edtOperacoesId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_operacoesupdateatauxdatetext_Jsonclick = "";
         edtavDdo_operacoescreatedatauxdatetext_Jsonclick = "";
         edtavDdo_operacoesdataauxdatetext_Jsonclick = "";
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Fixedcolumns = ";L;;;;;;;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "9.0||||16.4|16.4|||";
         Ddo_grid_Datalistproc = "OperacoesListaGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||PENDENTE:Pendente,APROVADA:Aprovada,RECUSADA:Recusada,LIQUIDADA:Liquidada|||||";
         Ddo_grid_Allowmultipleselection = "|||T|||||";
         Ddo_grid_Datalisttype = "|Dynamic||FixedValues|||Dynamic||";
         Ddo_grid_Includedatalist = "|T||T|||T||";
         Ddo_grid_Filterisrange = "T||P||T|T||P|P";
         Ddo_grid_Filtertype = "Numeric|Character|Date||Numeric|Numeric|Character|Date|Date";
         Ddo_grid_Includefilter = "T|T|T||T|T|T|T|T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|1|4|5|6|7|8|9";
         Ddo_grid_Columnids = "2:OperacoesId|4:ClienteRazaoSocial|5:OperacoesData|6:OperacoesStatus|7:OperacoesTaxaEfetiva|9:OperacoesTaxaMora|10:ContratoNome|11:OperacoesCreatedAt|12:OperacoesUpdateAt";
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
         Form.Caption = " Operacoes";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV80ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV91Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV81TFOperacoesId","fld":"vTFOPERACOESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV82TFOperacoesId_To","fld":"vTFOPERACOESID_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV41TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFOperacoesData","fld":"vTFOPERACOESDATA","type":"date"},{"av":"AV44TFOperacoesData_To","fld":"vTFOPERACOESDATA_TO","type":"date"},{"av":"AV49TFOperacoesStatus_Sels","fld":"vTFOPERACOESSTATUS_SELS","type":""},{"av":"AV50TFOperacoesTaxaEfetiva","fld":"vTFOPERACOESTAXAEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV51TFOperacoesTaxaEfetiva_To","fld":"vTFOPERACOESTAXAEFETIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV52TFOperacoesTaxaMora","fld":"vTFOPERACOESTAXAMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV53TFOperacoesTaxaMora_To","fld":"vTFOPERACOESTAXAMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV54TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV55TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV56TFOperacoesCreatedAt","fld":"vTFOPERACOESCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV57TFOperacoesCreatedAt_To","fld":"vTFOPERACOESCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV61TFOperacoesUpdateAt","fld":"vTFOPERACOESUPDATEAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV62TFOperacoesUpdateAt_To","fld":"vTFOPERACOESUPDATEAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV86ClienteTaxasEfetiva","fld":"vCLIENTETAXASEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","hsh":true,"type":"decimal"},{"av":"AV87ClienteTaxasMora","fld":"vCLIENTETAXASMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","hsh":true,"type":"decimal"},{"av":"AV88ClienteTaxasFator","fld":"vCLIENTETAXASFATOR","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","hsh":true,"type":"decimal"},{"av":"AV85ClienteTaxasTipoTarifa","fld":"vCLIENTETAXASTIPOTARIFA","hsh":true,"type":"svchar"},{"av":"AV84ClienteTaxasTarifa","fld":"vCLIENTETAXASTARIFA","pic":"ZZZZZZZZZZZ9.99","hsh":true,"type":"decimal"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV68GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV69GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV70GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV38ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12A12","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV80ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV91Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV81TFOperacoesId","fld":"vTFOPERACOESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV82TFOperacoesId_To","fld":"vTFOPERACOESID_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV41TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFOperacoesData","fld":"vTFOPERACOESDATA","type":"date"},{"av":"AV44TFOperacoesData_To","fld":"vTFOPERACOESDATA_TO","type":"date"},{"av":"AV49TFOperacoesStatus_Sels","fld":"vTFOPERACOESSTATUS_SELS","type":""},{"av":"AV50TFOperacoesTaxaEfetiva","fld":"vTFOPERACOESTAXAEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV51TFOperacoesTaxaEfetiva_To","fld":"vTFOPERACOESTAXAEFETIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV52TFOperacoesTaxaMora","fld":"vTFOPERACOESTAXAMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV53TFOperacoesTaxaMora_To","fld":"vTFOPERACOESTAXAMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV54TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV55TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV56TFOperacoesCreatedAt","fld":"vTFOPERACOESCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV57TFOperacoesCreatedAt_To","fld":"vTFOPERACOESCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV61TFOperacoesUpdateAt","fld":"vTFOPERACOESUPDATEAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV62TFOperacoesUpdateAt_To","fld":"vTFOPERACOESUPDATEAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV86ClienteTaxasEfetiva","fld":"vCLIENTETAXASEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","hsh":true,"type":"decimal"},{"av":"AV87ClienteTaxasMora","fld":"vCLIENTETAXASMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","hsh":true,"type":"decimal"},{"av":"AV88ClienteTaxasFator","fld":"vCLIENTETAXASFATOR","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","hsh":true,"type":"decimal"},{"av":"AV85ClienteTaxasTipoTarifa","fld":"vCLIENTETAXASTIPOTARIFA","hsh":true,"type":"svchar"},{"av":"AV84ClienteTaxasTarifa","fld":"vCLIENTETAXASTARIFA","pic":"ZZZZZZZZZZZ9.99","hsh":true,"type":"decimal"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13A12","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV80ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV91Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV81TFOperacoesId","fld":"vTFOPERACOESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV82TFOperacoesId_To","fld":"vTFOPERACOESID_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV41TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFOperacoesData","fld":"vTFOPERACOESDATA","type":"date"},{"av":"AV44TFOperacoesData_To","fld":"vTFOPERACOESDATA_TO","type":"date"},{"av":"AV49TFOperacoesStatus_Sels","fld":"vTFOPERACOESSTATUS_SELS","type":""},{"av":"AV50TFOperacoesTaxaEfetiva","fld":"vTFOPERACOESTAXAEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV51TFOperacoesTaxaEfetiva_To","fld":"vTFOPERACOESTAXAEFETIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV52TFOperacoesTaxaMora","fld":"vTFOPERACOESTAXAMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV53TFOperacoesTaxaMora_To","fld":"vTFOPERACOESTAXAMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV54TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV55TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV56TFOperacoesCreatedAt","fld":"vTFOPERACOESCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV57TFOperacoesCreatedAt_To","fld":"vTFOPERACOESCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV61TFOperacoesUpdateAt","fld":"vTFOPERACOESUPDATEAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV62TFOperacoesUpdateAt_To","fld":"vTFOPERACOESUPDATEAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV86ClienteTaxasEfetiva","fld":"vCLIENTETAXASEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","hsh":true,"type":"decimal"},{"av":"AV87ClienteTaxasMora","fld":"vCLIENTETAXASMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","hsh":true,"type":"decimal"},{"av":"AV88ClienteTaxasFator","fld":"vCLIENTETAXASFATOR","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","hsh":true,"type":"decimal"},{"av":"AV85ClienteTaxasTipoTarifa","fld":"vCLIENTETAXASTIPOTARIFA","hsh":true,"type":"svchar"},{"av":"AV84ClienteTaxasTarifa","fld":"vCLIENTETAXASTARIFA","pic":"ZZZZZZZZZZZ9.99","hsh":true,"type":"decimal"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E14A12","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV80ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV91Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV81TFOperacoesId","fld":"vTFOPERACOESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV82TFOperacoesId_To","fld":"vTFOPERACOESID_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV41TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFOperacoesData","fld":"vTFOPERACOESDATA","type":"date"},{"av":"AV44TFOperacoesData_To","fld":"vTFOPERACOESDATA_TO","type":"date"},{"av":"AV49TFOperacoesStatus_Sels","fld":"vTFOPERACOESSTATUS_SELS","type":""},{"av":"AV50TFOperacoesTaxaEfetiva","fld":"vTFOPERACOESTAXAEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV51TFOperacoesTaxaEfetiva_To","fld":"vTFOPERACOESTAXAEFETIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV52TFOperacoesTaxaMora","fld":"vTFOPERACOESTAXAMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV53TFOperacoesTaxaMora_To","fld":"vTFOPERACOESTAXAMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV54TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV55TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV56TFOperacoesCreatedAt","fld":"vTFOPERACOESCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV57TFOperacoesCreatedAt_To","fld":"vTFOPERACOESCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV61TFOperacoesUpdateAt","fld":"vTFOPERACOESUPDATEAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV62TFOperacoesUpdateAt_To","fld":"vTFOPERACOESUPDATEAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV86ClienteTaxasEfetiva","fld":"vCLIENTETAXASEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","hsh":true,"type":"decimal"},{"av":"AV87ClienteTaxasMora","fld":"vCLIENTETAXASMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","hsh":true,"type":"decimal"},{"av":"AV88ClienteTaxasFator","fld":"vCLIENTETAXASFATOR","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","hsh":true,"type":"decimal"},{"av":"AV85ClienteTaxasTipoTarifa","fld":"vCLIENTETAXASTIPOTARIFA","hsh":true,"type":"svchar"},{"av":"AV84ClienteTaxasTarifa","fld":"vCLIENTETAXASTARIFA","pic":"ZZZZZZZZZZZ9.99","hsh":true,"type":"decimal"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV61TFOperacoesUpdateAt","fld":"vTFOPERACOESUPDATEAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV62TFOperacoesUpdateAt_To","fld":"vTFOPERACOESUPDATEAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV56TFOperacoesCreatedAt","fld":"vTFOPERACOESCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV57TFOperacoesCreatedAt_To","fld":"vTFOPERACOESCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV54TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV55TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV52TFOperacoesTaxaMora","fld":"vTFOPERACOESTAXAMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV53TFOperacoesTaxaMora_To","fld":"vTFOPERACOESTAXAMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV50TFOperacoesTaxaEfetiva","fld":"vTFOPERACOESTAXAEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV51TFOperacoesTaxaEfetiva_To","fld":"vTFOPERACOESTAXAEFETIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV48TFOperacoesStatus_SelsJson","fld":"vTFOPERACOESSTATUS_SELSJSON","type":"vchar"},{"av":"AV49TFOperacoesStatus_Sels","fld":"vTFOPERACOESSTATUS_SELS","type":""},{"av":"AV43TFOperacoesData","fld":"vTFOPERACOESDATA","type":"date"},{"av":"AV44TFOperacoesData_To","fld":"vTFOPERACOESDATA_TO","type":"date"},{"av":"AV41TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV81TFOperacoesId","fld":"vTFOPERACOESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV82TFOperacoesId_To","fld":"vTFOPERACOESID_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E19A12","iparms":[{"av":"A1010OperacoesId","fld":"OPERACOESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A227ContratoId","fld":"CONTRATOID","pic":"ZZZZZ9","type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV71Display","fld":"vDISPLAY","type":"char"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"},{"av":"AV72Update","fld":"vUPDATE","type":"char"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"edtContratoNome_Link","ctrl":"CONTRATONOME","prop":"Link"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11A12","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV80ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV91Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV81TFOperacoesId","fld":"vTFOPERACOESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV82TFOperacoesId_To","fld":"vTFOPERACOESID_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV41TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFOperacoesData","fld":"vTFOPERACOESDATA","type":"date"},{"av":"AV44TFOperacoesData_To","fld":"vTFOPERACOESDATA_TO","type":"date"},{"av":"AV49TFOperacoesStatus_Sels","fld":"vTFOPERACOESSTATUS_SELS","type":""},{"av":"AV50TFOperacoesTaxaEfetiva","fld":"vTFOPERACOESTAXAEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV51TFOperacoesTaxaEfetiva_To","fld":"vTFOPERACOESTAXAEFETIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV52TFOperacoesTaxaMora","fld":"vTFOPERACOESTAXAMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV53TFOperacoesTaxaMora_To","fld":"vTFOPERACOESTAXAMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV54TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV55TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV56TFOperacoesCreatedAt","fld":"vTFOPERACOESCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV57TFOperacoesCreatedAt_To","fld":"vTFOPERACOESCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV61TFOperacoesUpdateAt","fld":"vTFOPERACOESUPDATEAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV62TFOperacoesUpdateAt_To","fld":"vTFOPERACOESUPDATEAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV86ClienteTaxasEfetiva","fld":"vCLIENTETAXASEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","hsh":true,"type":"decimal"},{"av":"AV87ClienteTaxasMora","fld":"vCLIENTETAXASMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","hsh":true,"type":"decimal"},{"av":"AV88ClienteTaxasFator","fld":"vCLIENTETAXASFATOR","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","hsh":true,"type":"decimal"},{"av":"AV85ClienteTaxasTipoTarifa","fld":"vCLIENTETAXASTIPOTARIFA","hsh":true,"type":"svchar"},{"av":"AV84ClienteTaxasTarifa","fld":"vCLIENTETAXASTARIFA","pic":"ZZZZZZZZZZZ9.99","hsh":true,"type":"decimal"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV48TFOperacoesStatus_SelsJson","fld":"vTFOPERACOESSTATUS_SELSJSON","type":"vchar"},{"av":"AV58DDO_OperacoesCreatedAtAuxDate","fld":"vDDO_OPERACOESCREATEDATAUXDATE","type":"date"},{"av":"AV63DDO_OperacoesUpdateAtAuxDate","fld":"vDDO_OPERACOESUPDATEATAUXDATE","type":"date"},{"av":"AV59DDO_OperacoesCreatedAtAuxDateTo","fld":"vDDO_OPERACOESCREATEDATAUXDATETO","type":"date"},{"av":"AV64DDO_OperacoesUpdateAtAuxDateTo","fld":"vDDO_OPERACOESUPDATEATAUXDATETO","type":"date"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV81TFOperacoesId","fld":"vTFOPERACOESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV82TFOperacoesId_To","fld":"vTFOPERACOESID_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV41TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFOperacoesData","fld":"vTFOPERACOESDATA","type":"date"},{"av":"AV44TFOperacoesData_To","fld":"vTFOPERACOESDATA_TO","type":"date"},{"av":"AV49TFOperacoesStatus_Sels","fld":"vTFOPERACOESSTATUS_SELS","type":""},{"av":"AV50TFOperacoesTaxaEfetiva","fld":"vTFOPERACOESTAXAEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV51TFOperacoesTaxaEfetiva_To","fld":"vTFOPERACOESTAXAEFETIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV52TFOperacoesTaxaMora","fld":"vTFOPERACOESTAXAMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV53TFOperacoesTaxaMora_To","fld":"vTFOPERACOESTAXAMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV54TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV55TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV56TFOperacoesCreatedAt","fld":"vTFOPERACOESCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV57TFOperacoesCreatedAt_To","fld":"vTFOPERACOESCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV61TFOperacoesUpdateAt","fld":"vTFOPERACOESUPDATEAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV62TFOperacoesUpdateAt_To","fld":"vTFOPERACOESUPDATEAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV63DDO_OperacoesUpdateAtAuxDate","fld":"vDDO_OPERACOESUPDATEATAUXDATE","type":"date"},{"av":"AV64DDO_OperacoesUpdateAtAuxDateTo","fld":"vDDO_OPERACOESUPDATEATAUXDATETO","type":"date"},{"av":"AV58DDO_OperacoesCreatedAtAuxDate","fld":"vDDO_OPERACOESCREATEDATAUXDATE","type":"date"},{"av":"AV59DDO_OperacoesCreatedAtAuxDateTo","fld":"vDDO_OPERACOESCREATEDATAUXDATETO","type":"date"},{"av":"AV48TFOperacoesStatus_SelsJson","fld":"vTFOPERACOESSTATUS_SELSJSON","type":"vchar"},{"av":"AV68GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV69GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV70GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV38ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOINICIAROPERACAO'","""{"handler":"E15A12","iparms":[{"av":"AV80ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV86ClienteTaxasEfetiva","fld":"vCLIENTETAXASEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","hsh":true,"type":"decimal"},{"av":"AV87ClienteTaxasMora","fld":"vCLIENTETAXASMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","hsh":true,"type":"decimal"},{"av":"AV88ClienteTaxasFator","fld":"vCLIENTETAXASFATOR","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","hsh":true,"type":"decimal"},{"av":"AV85ClienteTaxasTipoTarifa","fld":"vCLIENTETAXASTIPOTARIFA","hsh":true,"type":"svchar"},{"av":"AV84ClienteTaxasTarifa","fld":"vCLIENTETAXASTARIFA","pic":"ZZZZZZZZZZZ9.99","hsh":true,"type":"decimal"}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E16A12","iparms":[]}""");
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[]}""");
         setEventMetadata("VALID_CONTRATOID","""{"handler":"Valid_Contratoid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Operacoesupdateat","iparms":[]}""");
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
         AV91Pgmname = "";
         AV41TFClienteRazaoSocial = "";
         AV42TFClienteRazaoSocial_Sel = "";
         AV43TFOperacoesData = DateTime.MinValue;
         AV44TFOperacoesData_To = DateTime.MinValue;
         AV49TFOperacoesStatus_Sels = new GxSimpleCollection<string>();
         AV54TFContratoNome = "";
         AV55TFContratoNome_Sel = "";
         AV56TFOperacoesCreatedAt = (DateTime)(DateTime.MinValue);
         AV57TFOperacoesCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV61TFOperacoesUpdateAt = (DateTime)(DateTime.MinValue);
         AV62TFOperacoesUpdateAt_To = (DateTime)(DateTime.MinValue);
         AV85ClienteTaxasTipoTarifa = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV38ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV70GridAppliedFilters = "";
         AV66DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV45DDO_OperacoesDataAuxDate = DateTime.MinValue;
         AV46DDO_OperacoesDataAuxDateTo = DateTime.MinValue;
         AV58DDO_OperacoesCreatedAtAuxDate = DateTime.MinValue;
         AV59DDO_OperacoesCreatedAtAuxDateTo = DateTime.MinValue;
         AV63DDO_OperacoesUpdateAtAuxDate = DateTime.MinValue;
         AV64DDO_OperacoesUpdateAtAuxDateTo = DateTime.MinValue;
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV48TFOperacoesStatus_SelsJson = "";
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
         bttBtniniciaroperacao_Jsonclick = "";
         bttBtnexport_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV47DDO_OperacoesDataAuxDateText = "";
         ucTfoperacoesdata_rangepicker = new GXUserControl();
         AV60DDO_OperacoesCreatedAtAuxDateText = "";
         ucTfoperacoescreatedat_rangepicker = new GXUserControl();
         AV65DDO_OperacoesUpdateAtAuxDateText = "";
         ucTfoperacoesupdateat_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV71Display = "";
         AV72Update = "";
         A170ClienteRazaoSocial = "";
         A1011OperacoesData = DateTime.MinValue;
         A1012OperacoesStatus = "";
         A228ContratoNome = "";
         A1017OperacoesCreatedAt = (DateTime)(DateTime.MinValue);
         A1018OperacoesUpdateAt = (DateTime)(DateTime.MinValue);
         GXDecQS = "";
         AV99Operacoeslistads_8_tfoperacoesstatus_sels = new GxSimpleCollection<string>();
         lV92Operacoeslistads_1_filterfulltext = "";
         lV95Operacoeslistads_4_tfclienterazaosocial = "";
         lV104Operacoeslistads_13_tfcontratonome = "";
         AV92Operacoeslistads_1_filterfulltext = "";
         AV96Operacoeslistads_5_tfclienterazaosocial_sel = "";
         AV95Operacoeslistads_4_tfclienterazaosocial = "";
         AV97Operacoeslistads_6_tfoperacoesdata = DateTime.MinValue;
         AV98Operacoeslistads_7_tfoperacoesdata_to = DateTime.MinValue;
         AV105Operacoeslistads_14_tfcontratonome_sel = "";
         AV104Operacoeslistads_13_tfcontratonome = "";
         AV106Operacoeslistads_15_tfoperacoescreatedat = (DateTime)(DateTime.MinValue);
         AV107Operacoeslistads_16_tfoperacoescreatedat_to = (DateTime)(DateTime.MinValue);
         AV108Operacoeslistads_17_tfoperacoesupdateat = (DateTime)(DateTime.MinValue);
         AV109Operacoeslistads_18_tfoperacoesupdateat_to = (DateTime)(DateTime.MinValue);
         H00A12_A1018OperacoesUpdateAt = new DateTime[] {DateTime.MinValue} ;
         H00A12_n1018OperacoesUpdateAt = new bool[] {false} ;
         H00A12_A1017OperacoesCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H00A12_n1017OperacoesCreatedAt = new bool[] {false} ;
         H00A12_A228ContratoNome = new string[] {""} ;
         H00A12_n228ContratoNome = new bool[] {false} ;
         H00A12_A1016OperacoesTaxaMora = new decimal[1] ;
         H00A12_n1016OperacoesTaxaMora = new bool[] {false} ;
         H00A12_A227ContratoId = new int[1] ;
         H00A12_n227ContratoId = new bool[] {false} ;
         H00A12_A1015OperacoesTaxaEfetiva = new decimal[1] ;
         H00A12_n1015OperacoesTaxaEfetiva = new bool[] {false} ;
         H00A12_A1012OperacoesStatus = new string[] {""} ;
         H00A12_n1012OperacoesStatus = new bool[] {false} ;
         H00A12_A1011OperacoesData = new DateTime[] {DateTime.MinValue} ;
         H00A12_n1011OperacoesData = new bool[] {false} ;
         H00A12_A170ClienteRazaoSocial = new string[] {""} ;
         H00A12_n170ClienteRazaoSocial = new bool[] {false} ;
         H00A12_A168ClienteId = new int[1] ;
         H00A12_n168ClienteId = new bool[] {false} ;
         H00A12_A1010OperacoesId = new int[1] ;
         H00A13_AGRID_nRecordCount = new long[1] ;
         AV7HTTPRequest = new GxHttpRequest( context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         H00A14_A168ClienteId = new int[1] ;
         H00A14_n168ClienteId = new bool[] {false} ;
         H00A14_A1039ClienteTipoRisco = new string[] {""} ;
         A1039ClienteTipoRisco = "";
         AV83ClienteTipoRisco = "";
         H00A15_A1008ClienteTaxasId = new int[1] ;
         H00A15_A1009ClienteTaxasTipo = new string[] {""} ;
         H00A15_n1009ClienteTaxasTipo = new bool[] {false} ;
         H00A15_A1040ClienteTaxasEfetiva = new decimal[1] ;
         H00A15_n1040ClienteTaxasEfetiva = new bool[] {false} ;
         H00A15_A1041ClienteTaxasMora = new decimal[1] ;
         H00A15_n1041ClienteTaxasMora = new bool[] {false} ;
         H00A15_A1042ClienteTaxasFator = new decimal[1] ;
         H00A15_n1042ClienteTaxasFator = new bool[] {false} ;
         H00A15_A1043ClienteTaxasTipoTarifa = new string[] {""} ;
         H00A15_n1043ClienteTaxasTipoTarifa = new bool[] {false} ;
         H00A15_A1044ClienteTaxasTarifa = new decimal[1] ;
         H00A15_n1044ClienteTaxasTarifa = new bool[] {false} ;
         A1009ClienteTaxasTipo = "";
         A1043ClienteTaxasTipoTarifa = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV39ManageFiltersXml = "";
         AV77Operacao = new SdtOperacoes(context);
         AV35ExcelFilename = "";
         AV36ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV37Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         AV76AuxText = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.operacoeslista__default(),
            new Object[][] {
                new Object[] {
               H00A12_A1018OperacoesUpdateAt, H00A12_n1018OperacoesUpdateAt, H00A12_A1017OperacoesCreatedAt, H00A12_n1017OperacoesCreatedAt, H00A12_A228ContratoNome, H00A12_n228ContratoNome, H00A12_A1016OperacoesTaxaMora, H00A12_n1016OperacoesTaxaMora, H00A12_A227ContratoId, H00A12_n227ContratoId,
               H00A12_A1015OperacoesTaxaEfetiva, H00A12_n1015OperacoesTaxaEfetiva, H00A12_A1012OperacoesStatus, H00A12_n1012OperacoesStatus, H00A12_A1011OperacoesData, H00A12_n1011OperacoesData, H00A12_A170ClienteRazaoSocial, H00A12_n170ClienteRazaoSocial, H00A12_A168ClienteId, H00A12_n168ClienteId,
               H00A12_A1010OperacoesId
               }
               , new Object[] {
               H00A13_AGRID_nRecordCount
               }
               , new Object[] {
               H00A14_A168ClienteId, H00A14_A1039ClienteTipoRisco
               }
               , new Object[] {
               H00A15_A1008ClienteTaxasId, H00A15_A1009ClienteTaxasTipo, H00A15_n1009ClienteTaxasTipo, H00A15_A1040ClienteTaxasEfetiva, H00A15_n1040ClienteTaxasEfetiva, H00A15_A1041ClienteTaxasMora, H00A15_n1041ClienteTaxasMora, H00A15_A1042ClienteTaxasFator, H00A15_n1042ClienteTaxasFator, H00A15_A1043ClienteTaxasTipoTarifa,
               H00A15_n1043ClienteTaxasTipoTarifa, H00A15_A1044ClienteTaxasTarifa, H00A15_n1044ClienteTaxasTarifa
               }
            }
         );
         AV91Pgmname = "OperacoesLista";
         /* GeneXus formulas. */
         AV91Pgmname = "OperacoesLista";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV40ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
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
      private int AV80ClienteId ;
      private int wcpOAV80ClienteId ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_39 ;
      private int nGXsfl_39_idx=1 ;
      private int AV81TFOperacoesId ;
      private int AV82TFOperacoesId_To ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A1010OperacoesId ;
      private int A168ClienteId ;
      private int A227ContratoId ;
      private int subGrid_Islastpage ;
      private int edtavDisplay_Enabled ;
      private int edtavUpdate_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV99Operacoeslistads_8_tfoperacoesstatus_sels_Count ;
      private int AV93Operacoeslistads_2_tfoperacoesid ;
      private int AV94Operacoeslistads_3_tfoperacoesid_to ;
      private int edtOperacoesId_Enabled ;
      private int edtClienteId_Enabled ;
      private int edtClienteRazaoSocial_Enabled ;
      private int edtOperacoesData_Enabled ;
      private int edtOperacoesTaxaEfetiva_Enabled ;
      private int edtContratoId_Enabled ;
      private int edtOperacoesTaxaMora_Enabled ;
      private int edtContratoNome_Enabled ;
      private int edtOperacoesCreatedAt_Enabled ;
      private int edtOperacoesUpdateAt_Enabled ;
      private int AV67PageToGo ;
      private int AV110GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV68GridCurrentPage ;
      private long AV69GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV50TFOperacoesTaxaEfetiva ;
      private decimal AV51TFOperacoesTaxaEfetiva_To ;
      private decimal AV52TFOperacoesTaxaMora ;
      private decimal AV53TFOperacoesTaxaMora_To ;
      private decimal AV86ClienteTaxasEfetiva ;
      private decimal AV87ClienteTaxasMora ;
      private decimal AV88ClienteTaxasFator ;
      private decimal AV84ClienteTaxasTarifa ;
      private decimal A1015OperacoesTaxaEfetiva ;
      private decimal A1016OperacoesTaxaMora ;
      private decimal AV100Operacoeslistads_9_tfoperacoestaxaefetiva ;
      private decimal AV101Operacoeslistads_10_tfoperacoestaxaefetiva_to ;
      private decimal AV102Operacoeslistads_11_tfoperacoestaxamora ;
      private decimal AV103Operacoeslistads_12_tfoperacoestaxamora_to ;
      private decimal A1040ClienteTaxasEfetiva ;
      private decimal A1041ClienteTaxasMora ;
      private decimal A1042ClienteTaxasFator ;
      private decimal A1044ClienteTaxasTarifa ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_39_idx="0001" ;
      private string AV91Pgmname ;
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
      private string bttBtniniciaroperacao_Internalname ;
      private string bttBtniniciaroperacao_Jsonclick ;
      private string bttBtnexport_Internalname ;
      private string bttBtnexport_Jsonclick ;
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
      private string Grid_empowerer_Internalname ;
      private string divDdo_operacoesdataauxdates_Internalname ;
      private string edtavDdo_operacoesdataauxdatetext_Internalname ;
      private string edtavDdo_operacoesdataauxdatetext_Jsonclick ;
      private string Tfoperacoesdata_rangepicker_Internalname ;
      private string divDdo_operacoescreatedatauxdates_Internalname ;
      private string edtavDdo_operacoescreatedatauxdatetext_Internalname ;
      private string edtavDdo_operacoescreatedatauxdatetext_Jsonclick ;
      private string Tfoperacoescreatedat_rangepicker_Internalname ;
      private string divDdo_operacoesupdateatauxdates_Internalname ;
      private string edtavDdo_operacoesupdateatauxdatetext_Internalname ;
      private string edtavDdo_operacoesupdateatauxdatetext_Jsonclick ;
      private string Tfoperacoesupdateat_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV71Display ;
      private string edtavDisplay_Internalname ;
      private string AV72Update ;
      private string edtavUpdate_Internalname ;
      private string edtOperacoesId_Internalname ;
      private string edtClienteId_Internalname ;
      private string edtClienteRazaoSocial_Internalname ;
      private string edtOperacoesData_Internalname ;
      private string cmbOperacoesStatus_Internalname ;
      private string edtOperacoesTaxaEfetiva_Internalname ;
      private string edtContratoId_Internalname ;
      private string edtOperacoesTaxaMora_Internalname ;
      private string edtContratoNome_Internalname ;
      private string edtOperacoesCreatedAt_Internalname ;
      private string edtOperacoesUpdateAt_Internalname ;
      private string GXDecQS ;
      private string edtavDisplay_Link ;
      private string edtavUpdate_Link ;
      private string edtContratoNome_Link ;
      private string GXt_char2 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string sGXsfl_39_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDisplay_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtOperacoesId_Jsonclick ;
      private string edtClienteId_Jsonclick ;
      private string edtClienteRazaoSocial_Jsonclick ;
      private string edtOperacoesData_Jsonclick ;
      private string GXCCtl ;
      private string cmbOperacoesStatus_Jsonclick ;
      private string edtOperacoesTaxaEfetiva_Jsonclick ;
      private string edtContratoId_Jsonclick ;
      private string edtOperacoesTaxaMora_Jsonclick ;
      private string edtContratoNome_Jsonclick ;
      private string edtOperacoesCreatedAt_Jsonclick ;
      private string edtOperacoesUpdateAt_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV56TFOperacoesCreatedAt ;
      private DateTime AV57TFOperacoesCreatedAt_To ;
      private DateTime AV61TFOperacoesUpdateAt ;
      private DateTime AV62TFOperacoesUpdateAt_To ;
      private DateTime A1017OperacoesCreatedAt ;
      private DateTime A1018OperacoesUpdateAt ;
      private DateTime AV106Operacoeslistads_15_tfoperacoescreatedat ;
      private DateTime AV107Operacoeslistads_16_tfoperacoescreatedat_to ;
      private DateTime AV108Operacoeslistads_17_tfoperacoesupdateat ;
      private DateTime AV109Operacoeslistads_18_tfoperacoesupdateat_to ;
      private DateTime AV43TFOperacoesData ;
      private DateTime AV44TFOperacoesData_To ;
      private DateTime AV45DDO_OperacoesDataAuxDate ;
      private DateTime AV46DDO_OperacoesDataAuxDateTo ;
      private DateTime AV58DDO_OperacoesCreatedAtAuxDate ;
      private DateTime AV59DDO_OperacoesCreatedAtAuxDateTo ;
      private DateTime AV63DDO_OperacoesUpdateAtAuxDate ;
      private DateTime AV64DDO_OperacoesUpdateAtAuxDateTo ;
      private DateTime A1011OperacoesData ;
      private DateTime AV97Operacoeslistads_6_tfoperacoesdata ;
      private DateTime AV98Operacoeslistads_7_tfoperacoesdata_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
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
      private bool n1011OperacoesData ;
      private bool n1012OperacoesStatus ;
      private bool n1015OperacoesTaxaEfetiva ;
      private bool n227ContratoId ;
      private bool n1016OperacoesTaxaMora ;
      private bool n228ContratoNome ;
      private bool n1017OperacoesCreatedAt ;
      private bool n1018OperacoesUpdateAt ;
      private bool bGXsfl_39_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n1009ClienteTaxasTipo ;
      private bool n1040ClienteTaxasEfetiva ;
      private bool n1041ClienteTaxasMora ;
      private bool n1042ClienteTaxasFator ;
      private bool n1043ClienteTaxasTipoTarifa ;
      private bool n1044ClienteTaxasTarifa ;
      private bool gx_refresh_fired ;
      private string AV48TFOperacoesStatus_SelsJson ;
      private string AV39ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV41TFClienteRazaoSocial ;
      private string AV42TFClienteRazaoSocial_Sel ;
      private string AV54TFContratoNome ;
      private string AV55TFContratoNome_Sel ;
      private string AV85ClienteTaxasTipoTarifa ;
      private string AV70GridAppliedFilters ;
      private string AV47DDO_OperacoesDataAuxDateText ;
      private string AV60DDO_OperacoesCreatedAtAuxDateText ;
      private string AV65DDO_OperacoesUpdateAtAuxDateText ;
      private string A170ClienteRazaoSocial ;
      private string A1012OperacoesStatus ;
      private string A228ContratoNome ;
      private string lV92Operacoeslistads_1_filterfulltext ;
      private string lV95Operacoeslistads_4_tfclienterazaosocial ;
      private string lV104Operacoeslistads_13_tfcontratonome ;
      private string AV92Operacoeslistads_1_filterfulltext ;
      private string AV96Operacoeslistads_5_tfclienterazaosocial_sel ;
      private string AV95Operacoeslistads_4_tfclienterazaosocial ;
      private string AV105Operacoeslistads_14_tfcontratonome_sel ;
      private string AV104Operacoeslistads_13_tfcontratonome ;
      private string A1039ClienteTipoRisco ;
      private string AV83ClienteTipoRisco ;
      private string A1009ClienteTaxasTipo ;
      private string A1043ClienteTaxasTipoTarifa ;
      private string AV35ExcelFilename ;
      private string AV36ErrorMessage ;
      private string AV76AuxText ;
      private IGxSession AV37Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfoperacoesdata_rangepicker ;
      private GXUserControl ucTfoperacoescreatedat_rangepicker ;
      private GXUserControl ucTfoperacoesupdateat_rangepicker ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbOperacoesStatus ;
      private GxSimpleCollection<string> AV49TFOperacoesStatus_Sels ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV38ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV66DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GxSimpleCollection<string> AV99Operacoeslistads_8_tfoperacoesstatus_sels ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H00A12_A1018OperacoesUpdateAt ;
      private bool[] H00A12_n1018OperacoesUpdateAt ;
      private DateTime[] H00A12_A1017OperacoesCreatedAt ;
      private bool[] H00A12_n1017OperacoesCreatedAt ;
      private string[] H00A12_A228ContratoNome ;
      private bool[] H00A12_n228ContratoNome ;
      private decimal[] H00A12_A1016OperacoesTaxaMora ;
      private bool[] H00A12_n1016OperacoesTaxaMora ;
      private int[] H00A12_A227ContratoId ;
      private bool[] H00A12_n227ContratoId ;
      private decimal[] H00A12_A1015OperacoesTaxaEfetiva ;
      private bool[] H00A12_n1015OperacoesTaxaEfetiva ;
      private string[] H00A12_A1012OperacoesStatus ;
      private bool[] H00A12_n1012OperacoesStatus ;
      private DateTime[] H00A12_A1011OperacoesData ;
      private bool[] H00A12_n1011OperacoesData ;
      private string[] H00A12_A170ClienteRazaoSocial ;
      private bool[] H00A12_n170ClienteRazaoSocial ;
      private int[] H00A12_A168ClienteId ;
      private bool[] H00A12_n168ClienteId ;
      private int[] H00A12_A1010OperacoesId ;
      private long[] H00A13_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private int[] H00A14_A168ClienteId ;
      private bool[] H00A14_n168ClienteId ;
      private string[] H00A14_A1039ClienteTipoRisco ;
      private int[] H00A15_A1008ClienteTaxasId ;
      private string[] H00A15_A1009ClienteTaxasTipo ;
      private bool[] H00A15_n1009ClienteTaxasTipo ;
      private decimal[] H00A15_A1040ClienteTaxasEfetiva ;
      private bool[] H00A15_n1040ClienteTaxasEfetiva ;
      private decimal[] H00A15_A1041ClienteTaxasMora ;
      private bool[] H00A15_n1041ClienteTaxasMora ;
      private decimal[] H00A15_A1042ClienteTaxasFator ;
      private bool[] H00A15_n1042ClienteTaxasFator ;
      private string[] H00A15_A1043ClienteTaxasTipoTarifa ;
      private bool[] H00A15_n1043ClienteTaxasTipoTarifa ;
      private decimal[] H00A15_A1044ClienteTaxasTarifa ;
      private bool[] H00A15_n1044ClienteTaxasTarifa ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private SdtOperacoes AV77Operacao ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class operacoeslista__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00A12( IGxContext context ,
                                             string A1012OperacoesStatus ,
                                             GxSimpleCollection<string> AV99Operacoeslistads_8_tfoperacoesstatus_sels ,
                                             string AV92Operacoeslistads_1_filterfulltext ,
                                             int AV93Operacoeslistads_2_tfoperacoesid ,
                                             int AV94Operacoeslistads_3_tfoperacoesid_to ,
                                             string AV96Operacoeslistads_5_tfclienterazaosocial_sel ,
                                             string AV95Operacoeslistads_4_tfclienterazaosocial ,
                                             DateTime AV97Operacoeslistads_6_tfoperacoesdata ,
                                             DateTime AV98Operacoeslistads_7_tfoperacoesdata_to ,
                                             int AV99Operacoeslistads_8_tfoperacoesstatus_sels_Count ,
                                             decimal AV100Operacoeslistads_9_tfoperacoestaxaefetiva ,
                                             decimal AV101Operacoeslistads_10_tfoperacoestaxaefetiva_to ,
                                             decimal AV102Operacoeslistads_11_tfoperacoestaxamora ,
                                             decimal AV103Operacoeslistads_12_tfoperacoestaxamora_to ,
                                             string AV105Operacoeslistads_14_tfcontratonome_sel ,
                                             string AV104Operacoeslistads_13_tfcontratonome ,
                                             DateTime AV106Operacoeslistads_15_tfoperacoescreatedat ,
                                             DateTime AV107Operacoeslistads_16_tfoperacoescreatedat_to ,
                                             DateTime AV108Operacoeslistads_17_tfoperacoesupdateat ,
                                             DateTime AV109Operacoeslistads_18_tfoperacoesupdateat_to ,
                                             int A1010OperacoesId ,
                                             string A170ClienteRazaoSocial ,
                                             decimal A1015OperacoesTaxaEfetiva ,
                                             decimal A1016OperacoesTaxaMora ,
                                             string A228ContratoNome ,
                                             DateTime A1011OperacoesData ,
                                             DateTime A1017OperacoesCreatedAt ,
                                             DateTime A1018OperacoesUpdateAt ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             int A168ClienteId ,
                                             int AV80ClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[29];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.OperacoesUpdateAt, T1.OperacoesCreatedAt, T2.ContratoNome, T1.OperacoesTaxaMora, T1.ContratoId, T1.OperacoesTaxaEfetiva, T1.OperacoesStatus, T1.OperacoesData, T3.ClienteRazaoSocial, T1.ClienteId, T1.OperacoesId";
         sFromString = " FROM ((Operacoes T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN Cliente T3 ON T3.ClienteId = T1.ClienteId)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.ClienteId = :AV80ClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Operacoeslistads_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.OperacoesId,'999999999'), 2) like '%' || :lV92Operacoeslistads_1_filterfulltext) or ( T3.ClienteRazaoSocial like '%' || :lV92Operacoeslistads_1_filterfulltext) or ( 'pendente' like '%' || LOWER(:lV92Operacoeslistads_1_filterfulltext) and T1.OperacoesStatus = ( 'PENDENTE')) or ( 'aprovada' like '%' || LOWER(:lV92Operacoeslistads_1_filterfulltext) and T1.OperacoesStatus = ( 'APROVADA')) or ( 'recusada' like '%' || LOWER(:lV92Operacoeslistads_1_filterfulltext) and T1.OperacoesStatus = ( 'RECUSADA')) or ( 'liquidada' like '%' || LOWER(:lV92Operacoeslistads_1_filterfulltext) and T1.OperacoesStatus = ( 'LIQUIDADA')) or ( SUBSTR(TO_CHAR(T1.OperacoesTaxaEfetiva,'99999999990.9999'), 2) like '%' || :lV92Operacoeslistads_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.OperacoesTaxaMora,'99999999990.9999'), 2) like '%' || :lV92Operacoeslistads_1_filterfulltext) or ( T2.ContratoNome like '%' || :lV92Operacoeslistads_1_filterfulltext))");
         }
         else
         {
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
            GXv_int6[4] = 1;
            GXv_int6[5] = 1;
            GXv_int6[6] = 1;
            GXv_int6[7] = 1;
            GXv_int6[8] = 1;
            GXv_int6[9] = 1;
         }
         if ( ! (0==AV93Operacoeslistads_2_tfoperacoesid) )
         {
            AddWhere(sWhereString, "(T1.OperacoesId >= :AV93Operacoeslistads_2_tfoperacoesid)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( ! (0==AV94Operacoeslistads_3_tfoperacoesid_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesId <= :AV94Operacoeslistads_3_tfoperacoesid_to)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Operacoeslistads_5_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Operacoeslistads_4_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like :lV95Operacoeslistads_4_tfclienterazaosocial)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Operacoeslistads_5_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV96Operacoeslistads_5_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial = ( :AV96Operacoeslistads_5_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( StringUtil.StrCmp(AV96Operacoeslistads_5_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T3.ClienteRazaoSocial))=0))");
         }
         if ( ! (DateTime.MinValue==AV97Operacoeslistads_6_tfoperacoesdata) )
         {
            AddWhere(sWhereString, "(T1.OperacoesData >= :AV97Operacoeslistads_6_tfoperacoesdata)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV98Operacoeslistads_7_tfoperacoesdata_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesData <= :AV98Operacoeslistads_7_tfoperacoesdata_to)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( AV99Operacoeslistads_8_tfoperacoesstatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV99Operacoeslistads_8_tfoperacoesstatus_sels, "T1.OperacoesStatus IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV100Operacoeslistads_9_tfoperacoestaxaefetiva) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTaxaEfetiva >= :AV100Operacoeslistads_9_tfoperacoestaxaefetiva)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV101Operacoeslistads_10_tfoperacoestaxaefetiva_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTaxaEfetiva <= :AV101Operacoeslistads_10_tfoperacoestaxaefetiva_to)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV102Operacoeslistads_11_tfoperacoestaxamora) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTaxaMora >= :AV102Operacoeslistads_11_tfoperacoestaxamora)");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV103Operacoeslistads_12_tfoperacoestaxamora_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTaxaMora <= :AV103Operacoeslistads_12_tfoperacoestaxamora_to)");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Operacoeslistads_14_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Operacoeslistads_13_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV104Operacoeslistads_13_tfcontratonome)");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Operacoeslistads_14_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV105Operacoeslistads_14_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome = ( :AV105Operacoeslistads_14_tfcontratonome_sel))");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( StringUtil.StrCmp(AV105Operacoeslistads_14_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T2.ContratoNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV106Operacoeslistads_15_tfoperacoescreatedat) )
         {
            AddWhere(sWhereString, "(T1.OperacoesCreatedAt >= :AV106Operacoeslistads_15_tfoperacoescreatedat)");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV107Operacoeslistads_16_tfoperacoescreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesCreatedAt <= :AV107Operacoeslistads_16_tfoperacoescreatedat_to)");
         }
         else
         {
            GXv_int6[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV108Operacoeslistads_17_tfoperacoesupdateat) )
         {
            AddWhere(sWhereString, "(T1.OperacoesUpdateAt >= :AV108Operacoeslistads_17_tfoperacoesupdateat)");
         }
         else
         {
            GXv_int6[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV109Operacoeslistads_18_tfoperacoesupdateat_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesUpdateAt <= :AV109Operacoeslistads_18_tfoperacoesupdateat_to)");
         }
         else
         {
            GXv_int6[25] = 1;
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.OperacoesData, T1.OperacoesId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.OperacoesData DESC, T1.OperacoesId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.OperacoesId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.OperacoesId DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T3.ClienteRazaoSocial, T1.OperacoesId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.ClienteRazaoSocial DESC, T1.OperacoesId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.OperacoesStatus, T1.OperacoesId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.OperacoesStatus DESC, T1.OperacoesId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.OperacoesTaxaEfetiva, T1.OperacoesId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.OperacoesTaxaEfetiva DESC, T1.OperacoesId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.OperacoesTaxaMora, T1.OperacoesId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.OperacoesTaxaMora DESC, T1.OperacoesId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.ContratoNome, T1.OperacoesId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.ContratoNome DESC, T1.OperacoesId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.OperacoesCreatedAt, T1.OperacoesId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.OperacoesCreatedAt DESC, T1.OperacoesId";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.OperacoesUpdateAt, T1.OperacoesId";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.OperacoesUpdateAt DESC, T1.OperacoesId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.OperacoesId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H00A13( IGxContext context ,
                                             string A1012OperacoesStatus ,
                                             GxSimpleCollection<string> AV99Operacoeslistads_8_tfoperacoesstatus_sels ,
                                             string AV92Operacoeslistads_1_filterfulltext ,
                                             int AV93Operacoeslistads_2_tfoperacoesid ,
                                             int AV94Operacoeslistads_3_tfoperacoesid_to ,
                                             string AV96Operacoeslistads_5_tfclienterazaosocial_sel ,
                                             string AV95Operacoeslistads_4_tfclienterazaosocial ,
                                             DateTime AV97Operacoeslistads_6_tfoperacoesdata ,
                                             DateTime AV98Operacoeslistads_7_tfoperacoesdata_to ,
                                             int AV99Operacoeslistads_8_tfoperacoesstatus_sels_Count ,
                                             decimal AV100Operacoeslistads_9_tfoperacoestaxaefetiva ,
                                             decimal AV101Operacoeslistads_10_tfoperacoestaxaefetiva_to ,
                                             decimal AV102Operacoeslistads_11_tfoperacoestaxamora ,
                                             decimal AV103Operacoeslistads_12_tfoperacoestaxamora_to ,
                                             string AV105Operacoeslistads_14_tfcontratonome_sel ,
                                             string AV104Operacoeslistads_13_tfcontratonome ,
                                             DateTime AV106Operacoeslistads_15_tfoperacoescreatedat ,
                                             DateTime AV107Operacoeslistads_16_tfoperacoescreatedat_to ,
                                             DateTime AV108Operacoeslistads_17_tfoperacoesupdateat ,
                                             DateTime AV109Operacoeslistads_18_tfoperacoesupdateat_to ,
                                             int A1010OperacoesId ,
                                             string A170ClienteRazaoSocial ,
                                             decimal A1015OperacoesTaxaEfetiva ,
                                             decimal A1016OperacoesTaxaMora ,
                                             string A228ContratoNome ,
                                             DateTime A1011OperacoesData ,
                                             DateTime A1017OperacoesCreatedAt ,
                                             DateTime A1018OperacoesUpdateAt ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             int A168ClienteId ,
                                             int AV80ClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[26];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((Operacoes T1 LEFT JOIN Contrato T3 ON T3.ContratoId = T1.ContratoId) LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ClienteId)";
         AddWhere(sWhereString, "(T1.ClienteId = :AV80ClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Operacoeslistads_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.OperacoesId,'999999999'), 2) like '%' || :lV92Operacoeslistads_1_filterfulltext) or ( T2.ClienteRazaoSocial like '%' || :lV92Operacoeslistads_1_filterfulltext) or ( 'pendente' like '%' || LOWER(:lV92Operacoeslistads_1_filterfulltext) and T1.OperacoesStatus = ( 'PENDENTE')) or ( 'aprovada' like '%' || LOWER(:lV92Operacoeslistads_1_filterfulltext) and T1.OperacoesStatus = ( 'APROVADA')) or ( 'recusada' like '%' || LOWER(:lV92Operacoeslistads_1_filterfulltext) and T1.OperacoesStatus = ( 'RECUSADA')) or ( 'liquidada' like '%' || LOWER(:lV92Operacoeslistads_1_filterfulltext) and T1.OperacoesStatus = ( 'LIQUIDADA')) or ( SUBSTR(TO_CHAR(T1.OperacoesTaxaEfetiva,'99999999990.9999'), 2) like '%' || :lV92Operacoeslistads_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.OperacoesTaxaMora,'99999999990.9999'), 2) like '%' || :lV92Operacoeslistads_1_filterfulltext) or ( T3.ContratoNome like '%' || :lV92Operacoeslistads_1_filterfulltext))");
         }
         else
         {
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
            GXv_int8[4] = 1;
            GXv_int8[5] = 1;
            GXv_int8[6] = 1;
            GXv_int8[7] = 1;
            GXv_int8[8] = 1;
            GXv_int8[9] = 1;
         }
         if ( ! (0==AV93Operacoeslistads_2_tfoperacoesid) )
         {
            AddWhere(sWhereString, "(T1.OperacoesId >= :AV93Operacoeslistads_2_tfoperacoesid)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ! (0==AV94Operacoeslistads_3_tfoperacoesid_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesId <= :AV94Operacoeslistads_3_tfoperacoesid_to)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Operacoeslistads_5_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Operacoeslistads_4_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV95Operacoeslistads_4_tfclienterazaosocial)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Operacoeslistads_5_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV96Operacoeslistads_5_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV96Operacoeslistads_5_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( StringUtil.StrCmp(AV96Operacoeslistads_5_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( ! (DateTime.MinValue==AV97Operacoeslistads_6_tfoperacoesdata) )
         {
            AddWhere(sWhereString, "(T1.OperacoesData >= :AV97Operacoeslistads_6_tfoperacoesdata)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV98Operacoeslistads_7_tfoperacoesdata_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesData <= :AV98Operacoeslistads_7_tfoperacoesdata_to)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( AV99Operacoeslistads_8_tfoperacoesstatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV99Operacoeslistads_8_tfoperacoesstatus_sels, "T1.OperacoesStatus IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV100Operacoeslistads_9_tfoperacoestaxaefetiva) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTaxaEfetiva >= :AV100Operacoeslistads_9_tfoperacoestaxaefetiva)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV101Operacoeslistads_10_tfoperacoestaxaefetiva_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTaxaEfetiva <= :AV101Operacoeslistads_10_tfoperacoestaxaefetiva_to)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV102Operacoeslistads_11_tfoperacoestaxamora) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTaxaMora >= :AV102Operacoeslistads_11_tfoperacoestaxamora)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV103Operacoeslistads_12_tfoperacoestaxamora_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTaxaMora <= :AV103Operacoeslistads_12_tfoperacoestaxamora_to)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Operacoeslistads_14_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Operacoeslistads_13_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T3.ContratoNome like :lV104Operacoeslistads_13_tfcontratonome)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Operacoeslistads_14_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV105Operacoeslistads_14_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ContratoNome = ( :AV105Operacoeslistads_14_tfcontratonome_sel))");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( StringUtil.StrCmp(AV105Operacoeslistads_14_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T3.ContratoNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV106Operacoeslistads_15_tfoperacoescreatedat) )
         {
            AddWhere(sWhereString, "(T1.OperacoesCreatedAt >= :AV106Operacoeslistads_15_tfoperacoescreatedat)");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV107Operacoeslistads_16_tfoperacoescreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesCreatedAt <= :AV107Operacoeslistads_16_tfoperacoescreatedat_to)");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV108Operacoeslistads_17_tfoperacoesupdateat) )
         {
            AddWhere(sWhereString, "(T1.OperacoesUpdateAt >= :AV108Operacoeslistads_17_tfoperacoesupdateat)");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV109Operacoeslistads_18_tfoperacoesupdateat_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesUpdateAt <= :AV109Operacoeslistads_18_tfoperacoesupdateat_to)");
         }
         else
         {
            GXv_int8[25] = 1;
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
         else if ( true )
         {
            scmdbuf += "";
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
                     return conditional_H00A12(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (int)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (short)dynConstraints[28] , (bool)dynConstraints[29] , (int)dynConstraints[30] , (int)dynConstraints[31] );
               case 1 :
                     return conditional_H00A13(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (int)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (short)dynConstraints[28] , (bool)dynConstraints[29] , (int)dynConstraints[30] , (int)dynConstraints[31] );
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
          Object[] prmH00A14;
          prmH00A14 = new Object[] {
          new ParDef("AV80ClienteId",GXType.Int32,9,0)
          };
          Object[] prmH00A15;
          prmH00A15 = new Object[] {
          new ParDef("AV83ClienteTipoRisco",GXType.VarChar,40,0)
          };
          Object[] prmH00A12;
          prmH00A12 = new Object[] {
          new ParDef("AV80ClienteId",GXType.Int32,9,0) ,
          new ParDef("lV92Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV92Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV92Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV92Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV92Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV92Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV92Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV92Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV92Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV93Operacoeslistads_2_tfoperacoesid",GXType.Int32,9,0) ,
          new ParDef("AV94Operacoeslistads_3_tfoperacoesid_to",GXType.Int32,9,0) ,
          new ParDef("lV95Operacoeslistads_4_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV96Operacoeslistads_5_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV97Operacoeslistads_6_tfoperacoesdata",GXType.Date,8,0) ,
          new ParDef("AV98Operacoeslistads_7_tfoperacoesdata_to",GXType.Date,8,0) ,
          new ParDef("AV100Operacoeslistads_9_tfoperacoestaxaefetiva",GXType.Number,16,4) ,
          new ParDef("AV101Operacoeslistads_10_tfoperacoestaxaefetiva_to",GXType.Number,16,4) ,
          new ParDef("AV102Operacoeslistads_11_tfoperacoestaxamora",GXType.Number,16,4) ,
          new ParDef("AV103Operacoeslistads_12_tfoperacoestaxamora_to",GXType.Number,16,4) ,
          new ParDef("lV104Operacoeslistads_13_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV105Operacoeslistads_14_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("AV106Operacoeslistads_15_tfoperacoescreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV107Operacoeslistads_16_tfoperacoescreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV108Operacoeslistads_17_tfoperacoesupdateat",GXType.DateTime,8,5) ,
          new ParDef("AV109Operacoeslistads_18_tfoperacoesupdateat_to",GXType.DateTime,8,5) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00A13;
          prmH00A13 = new Object[] {
          new ParDef("AV80ClienteId",GXType.Int32,9,0) ,
          new ParDef("lV92Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV92Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV92Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV92Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV92Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV92Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV92Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV92Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV92Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV93Operacoeslistads_2_tfoperacoesid",GXType.Int32,9,0) ,
          new ParDef("AV94Operacoeslistads_3_tfoperacoesid_to",GXType.Int32,9,0) ,
          new ParDef("lV95Operacoeslistads_4_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV96Operacoeslistads_5_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV97Operacoeslistads_6_tfoperacoesdata",GXType.Date,8,0) ,
          new ParDef("AV98Operacoeslistads_7_tfoperacoesdata_to",GXType.Date,8,0) ,
          new ParDef("AV100Operacoeslistads_9_tfoperacoestaxaefetiva",GXType.Number,16,4) ,
          new ParDef("AV101Operacoeslistads_10_tfoperacoestaxaefetiva_to",GXType.Number,16,4) ,
          new ParDef("AV102Operacoeslistads_11_tfoperacoestaxamora",GXType.Number,16,4) ,
          new ParDef("AV103Operacoeslistads_12_tfoperacoestaxamora_to",GXType.Number,16,4) ,
          new ParDef("lV104Operacoeslistads_13_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV105Operacoeslistads_14_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("AV106Operacoeslistads_15_tfoperacoescreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV107Operacoeslistads_16_tfoperacoescreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV108Operacoeslistads_17_tfoperacoesupdateat",GXType.DateTime,8,5) ,
          new ParDef("AV109Operacoeslistads_18_tfoperacoesupdateat_to",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("H00A12", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A12,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00A13", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00A14", "SELECT ClienteId, ClienteTipoRisco FROM Cliente WHERE ClienteId = :AV80ClienteId ORDER BY ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A14,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00A15", "SELECT ClienteTaxasId, ClienteTaxasTipo, ClienteTaxasEfetiva, ClienteTaxasMora, ClienteTaxasFator, ClienteTaxasTipoTarifa, ClienteTaxasTarifa FROM ClienteTaxas WHERE ClienteTaxasTipo = ( :AV83ClienteTipoRisco) ORDER BY ClienteTaxasTipo ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A15,1, GxCacheFrequency.OFF ,false,true )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((int[]) buf[20])[0] = rslt.getInt(11);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

}
