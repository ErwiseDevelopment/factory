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
   public class operacoestitulosww : GXWebComponent
   {
      public operacoestitulosww( )
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

      public operacoestitulosww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_OperacoesId ,
                           string aP1_TrnMode )
      {
         this.AV73OperacoesId = aP0_OperacoesId;
         this.AV74TrnMode = aP1_TrnMode;
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
         cmbavDynamicfiltersselector1 = new GXCombobox();
         cmbavOperacoestitulostipo1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavOperacoestitulostipo2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavOperacoestitulostipo3 = new GXCombobox();
         cmbOperacoesTitulosTipo = new GXCombobox();
         cmbOperacoesTitulosStatus = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "OperacoesId");
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
                  AV73OperacoesId = (int)(Math.Round(NumberUtil.Val( GetPar( "OperacoesId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV73OperacoesId", StringUtil.LTrimStr( (decimal)(AV73OperacoesId), 9, 0));
                  AV74TrnMode = GetPar( "TrnMode");
                  AssignAttri(sPrefix, false, "AV74TrnMode", AV74TrnMode);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)AV73OperacoesId,(string)AV74TrnMode});
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
                  gxfirstwebparm = GetFirstPar( "OperacoesId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "OperacoesId");
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
         nRC_GXsfl_98 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_98"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_98_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_98_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_98_idx = GetPar( "sGXsfl_98_idx");
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
         AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV15FilterFullText = GetPar( "FilterFullText");
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV16DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavOperacoestitulostipo1.FromJSonString( GetNextPar( ));
         AV17OperacoesTitulosTipo1 = GetPar( "OperacoesTitulosTipo1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV19DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavOperacoestitulostipo2.FromJSonString( GetNextPar( ));
         AV20OperacoesTitulosTipo2 = GetPar( "OperacoesTitulosTipo2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavOperacoestitulostipo3.FromJSonString( GetNextPar( ));
         AV23OperacoesTitulosTipo3 = GetPar( "OperacoesTitulosTipo3");
         AV31ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV77Pgmname = GetPar( "Pgmname");
         AV73OperacoesId = (int)(Math.Round(NumberUtil.Val( GetPar( "OperacoesId"), "."), 18, MidpointRounding.ToEven));
         AV18DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV21DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV75TFSacadoRazaoSocial = GetPar( "TFSacadoRazaoSocial");
         AV76TFSacadoRazaoSocial_Sel = GetPar( "TFSacadoRazaoSocial_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV33TFOperacoesTitulosTipo_Sels);
         AV34TFOperacoesTitulosNumero = (int)(Math.Round(NumberUtil.Val( GetPar( "TFOperacoesTitulosNumero"), "."), 18, MidpointRounding.ToEven));
         AV35TFOperacoesTitulosNumero_To = (int)(Math.Round(NumberUtil.Val( GetPar( "TFOperacoesTitulosNumero_To"), "."), 18, MidpointRounding.ToEven));
         AV36TFOperacoesTitulosDataEmissao = context.localUtil.ParseDateParm( GetPar( "TFOperacoesTitulosDataEmissao"));
         AV37TFOperacoesTitulosDataEmissao_To = context.localUtil.ParseDateParm( GetPar( "TFOperacoesTitulosDataEmissao_To"));
         AV41TFOperacoesTitulosDataVencimento = context.localUtil.ParseDateParm( GetPar( "TFOperacoesTitulosDataVencimento"));
         AV42TFOperacoesTitulosDataVencimento_To = context.localUtil.ParseDateParm( GetPar( "TFOperacoesTitulosDataVencimento_To"));
         AV46TFOperacoesTitulosValor = NumberUtil.Val( GetPar( "TFOperacoesTitulosValor"), ".");
         AV47TFOperacoesTitulosValor_To = NumberUtil.Val( GetPar( "TFOperacoesTitulosValor_To"), ".");
         AV48TFOperacoesTitulosLiquido = NumberUtil.Val( GetPar( "TFOperacoesTitulosLiquido"), ".");
         AV49TFOperacoesTitulosLiquido_To = NumberUtil.Val( GetPar( "TFOperacoesTitulosLiquido_To"), ".");
         AV50TFOperacoesTitulosTaxa = NumberUtil.Val( GetPar( "TFOperacoesTitulosTaxa"), ".");
         AV51TFOperacoesTitulosTaxa_To = NumberUtil.Val( GetPar( "TFOperacoesTitulosTaxa_To"), ".");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV53TFOperacoesTitulosStatus_Sels);
         AV54TFOperacoesTitulosCreatedAt = context.localUtil.ParseDTimeParm( GetPar( "TFOperacoesTitulosCreatedAt"));
         AV55TFOperacoesTitulosCreatedAt_To = context.localUtil.ParseDTimeParm( GetPar( "TFOperacoesTitulosCreatedAt_To"));
         AV59TFOperacoesTitulosUpdatedAt = context.localUtil.ParseDTimeParm( GetPar( "TFOperacoesTitulosUpdatedAt"));
         AV60TFOperacoesTitulosUpdatedAt_To = context.localUtil.ParseDTimeParm( GetPar( "TFOperacoesTitulosUpdatedAt_To"));
         AV74TrnMode = GetPar( "TrnMode");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV25DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV24DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17OperacoesTitulosTipo1, AV19DynamicFiltersSelector2, AV20OperacoesTitulosTipo2, AV22DynamicFiltersSelector3, AV23OperacoesTitulosTipo3, AV31ManageFiltersExecutionStep, AV77Pgmname, AV73OperacoesId, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3, AV75TFSacadoRazaoSocial, AV76TFSacadoRazaoSocial_Sel, AV33TFOperacoesTitulosTipo_Sels, AV34TFOperacoesTitulosNumero, AV35TFOperacoesTitulosNumero_To, AV36TFOperacoesTitulosDataEmissao, AV37TFOperacoesTitulosDataEmissao_To, AV41TFOperacoesTitulosDataVencimento, AV42TFOperacoesTitulosDataVencimento_To, AV46TFOperacoesTitulosValor, AV47TFOperacoesTitulosValor_To, AV48TFOperacoesTitulosLiquido, AV49TFOperacoesTitulosLiquido_To, AV50TFOperacoesTitulosTaxa, AV51TFOperacoesTitulosTaxa_To, AV53TFOperacoesTitulosStatus_Sels, AV54TFOperacoesTitulosCreatedAt, AV55TFOperacoesTitulosCreatedAt_To, AV59TFOperacoesTitulosUpdatedAt, AV60TFOperacoesTitulosUpdatedAt_To, AV74TrnMode, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving, sPrefix) ;
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
            PAA42( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV77Pgmname = "OperacoesTitulosWW";
               edtavDisplay_Enabled = 0;
               AssignProp(sPrefix, false, edtavDisplay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplay_Enabled), 5, 0), !bGXsfl_98_Refreshing);
               edtavUpdate_Enabled = 0;
               AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_98_Refreshing);
               edtavDelete_Enabled = 0;
               AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_98_Refreshing);
               WSA42( ) ;
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
            context.SendWebValue( " Operacoes Titulos") ;
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
            GXEncryptionTmp = "operacoestitulosww"+UrlEncode(StringUtil.LTrimStr(AV73OperacoesId,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV74TrnMode));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("operacoestitulosww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV77Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV77Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vFILTERFULLTEXT", AV15FilterFullText);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR1", AV16DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vOPERACOESTITULOSTIPO1", AV17OperacoesTitulosTipo1);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2", AV19DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vOPERACOESTITULOSTIPO2", AV20OperacoesTitulosTipo2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3", AV22DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vOPERACOESTITULOSTIPO3", AV23OperacoesTitulosTipo3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_98", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_98), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV29ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV29ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV66GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV67GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV68GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV64DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV64DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_OPERACOESTITULOSDATAEMISSAOAUXDATE", context.localUtil.DToC( AV38DDO_OperacoesTitulosDataEmissaoAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_OPERACOESTITULOSDATAEMISSAOAUXDATETO", context.localUtil.DToC( AV39DDO_OperacoesTitulosDataEmissaoAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_OPERACOESTITULOSDATAVENCIMENTOAUXDATE", context.localUtil.DToC( AV43DDO_OperacoesTitulosDataVencimentoAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_OPERACOESTITULOSDATAVENCIMENTOAUXDATETO", context.localUtil.DToC( AV44DDO_OperacoesTitulosDataVencimentoAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_OPERACOESTITULOSCREATEDATAUXDATE", context.localUtil.DToC( AV56DDO_OperacoesTitulosCreatedAtAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_OPERACOESTITULOSCREATEDATAUXDATETO", context.localUtil.DToC( AV57DDO_OperacoesTitulosCreatedAtAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_OPERACOESTITULOSUPDATEDATAUXDATE", context.localUtil.DToC( AV61DDO_OperacoesTitulosUpdatedAtAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_OPERACOESTITULOSUPDATEDATAUXDATETO", context.localUtil.DToC( AV62DDO_OperacoesTitulosUpdatedAtAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV73OperacoesId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV73OperacoesId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV74TrnMode", StringUtil.RTrim( wcpOAV74TrnMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV77Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV77Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vOPERACOESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV73OperacoesId), 9, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED2", AV18DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED3", AV21DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSACADORAZAOSOCIAL", AV75TFSacadoRazaoSocial);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSACADORAZAOSOCIAL_SEL", AV76TFSacadoRazaoSocial_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTFOPERACOESTITULOSTIPO_SELS", AV33TFOperacoesTitulosTipo_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTFOPERACOESTITULOSTIPO_SELS", AV33TFOperacoesTitulosTipo_Sels);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFOPERACOESTITULOSNUMERO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34TFOperacoesTitulosNumero), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFOPERACOESTITULOSNUMERO_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35TFOperacoesTitulosNumero_To), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFOPERACOESTITULOSDATAEMISSAO", context.localUtil.DToC( AV36TFOperacoesTitulosDataEmissao, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFOPERACOESTITULOSDATAEMISSAO_TO", context.localUtil.DToC( AV37TFOperacoesTitulosDataEmissao_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFOPERACOESTITULOSDATAVENCIMENTO", context.localUtil.DToC( AV41TFOperacoesTitulosDataVencimento, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFOPERACOESTITULOSDATAVENCIMENTO_TO", context.localUtil.DToC( AV42TFOperacoesTitulosDataVencimento_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFOPERACOESTITULOSVALOR", StringUtil.LTrim( StringUtil.NToC( AV46TFOperacoesTitulosValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFOPERACOESTITULOSVALOR_TO", StringUtil.LTrim( StringUtil.NToC( AV47TFOperacoesTitulosValor_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFOPERACOESTITULOSLIQUIDO", StringUtil.LTrim( StringUtil.NToC( AV48TFOperacoesTitulosLiquido, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFOPERACOESTITULOSLIQUIDO_TO", StringUtil.LTrim( StringUtil.NToC( AV49TFOperacoesTitulosLiquido_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFOPERACOESTITULOSTAXA", StringUtil.LTrim( StringUtil.NToC( AV50TFOperacoesTitulosTaxa, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFOPERACOESTITULOSTAXA_TO", StringUtil.LTrim( StringUtil.NToC( AV51TFOperacoesTitulosTaxa_To, 16, 4, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTFOPERACOESTITULOSSTATUS_SELS", AV53TFOperacoesTitulosStatus_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTFOPERACOESTITULOSSTATUS_SELS", AV53TFOperacoesTitulosStatus_Sels);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFOPERACOESTITULOSCREATEDAT", context.localUtil.TToC( AV54TFOperacoesTitulosCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFOPERACOESTITULOSCREATEDAT_TO", context.localUtil.TToC( AV55TFOperacoesTitulosCreatedAt_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFOPERACOESTITULOSUPDATEDAT", context.localUtil.TToC( AV59TFOperacoesTitulosUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFOPERACOESTITULOSUPDATEDAT_TO", context.localUtil.TToC( AV60TFOperacoesTitulosUpdatedAt_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTRNMODE", StringUtil.RTrim( AV74TrnMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV14OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSIGNOREFIRST", AV25DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSREMOVING", AV24DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFOPERACOESTITULOSTIPO_SELSJSON", AV32TFOperacoesTitulosTipo_SelsJson);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFOPERACOESTITULOSSTATUS_SELSJSON", AV52TFOperacoesTitulosStatus_SelsJson);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Width", StringUtil.RTrim( Dvpanel_tableheader_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Autowidth", StringUtil.BoolToStr( Dvpanel_tableheader_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Autoheight", StringUtil.BoolToStr( Dvpanel_tableheader_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Cls", StringUtil.RTrim( Dvpanel_tableheader_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Title", StringUtil.RTrim( Dvpanel_tableheader_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Collapsible", StringUtil.BoolToStr( Dvpanel_tableheader_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Collapsed", StringUtil.BoolToStr( Dvpanel_tableheader_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableheader_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Iconposition", StringUtil.RTrim( Dvpanel_tableheader_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableheader_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseFormA42( )
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
         return "OperacoesTitulosWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Operacoes Titulos" ;
      }

      protected void WBA40( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "operacoestitulosww");
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
            ucDvpanel_tableheader.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableheader_Internalname, sPrefix+"DVPANEL_TABLEHEADERContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_TABLEHEADERContainer"+"TableHeader"+"\" style=\"display:none;\">") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(98), 2, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_OperacoesTitulosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(98), 2, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_OperacoesTitulosWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV29ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, sPrefix+"DDO_MANAGEFILTERSContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_OperacoesTitulosWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_OperacoesTitulosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_OperacoesTitulosWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_OperacoesTitulosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_45_A42( true) ;
         }
         else
         {
            wb_table1_45_A42( false) ;
         }
         return  ;
      }

      protected void wb_table1_45_A42e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_OperacoesTitulosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV19DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "", true, 0, "HLP_OperacoesTitulosWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_OperacoesTitulosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_64_A42( true) ;
         }
         else
         {
            wb_table2_64_A42( false) ;
         }
         return  ;
      }

      protected void wb_table2_64_A42e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_OperacoesTitulosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV22DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 0, "HLP_OperacoesTitulosWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector3);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_OperacoesTitulosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_83_A42( true) ;
         }
         else
         {
            wb_table3_83_A42( false) ;
         }
         return  ;
      }

      protected void wb_table3_83_A42e( bool wbgen )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
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
            StartGridControl98( ) ;
         }
         if ( wbEnd == 98 )
         {
            wbEnd = 0;
            nRC_GXsfl_98 = (int)(nGXsfl_98_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV66GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV67GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV68GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, sPrefix+"GRIDPAGINATIONBARContainer");
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_OperacoesTitulosWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV64DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_operacoestitulosdataemissaoauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_operacoestitulosdataemissaoauxdatetext_Internalname, AV40DDO_OperacoesTitulosDataEmissaoAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV40DDO_OperacoesTitulosDataEmissaoAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,125);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_operacoestitulosdataemissaoauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_OperacoesTitulosWW.htm");
            /* User Defined Control */
            ucTfoperacoestitulosdataemissao_rangepicker.SetProperty("Start Date", AV38DDO_OperacoesTitulosDataEmissaoAuxDate);
            ucTfoperacoestitulosdataemissao_rangepicker.SetProperty("End Date", AV39DDO_OperacoesTitulosDataEmissaoAuxDateTo);
            ucTfoperacoestitulosdataemissao_rangepicker.Render(context, "wwp.daterangepicker", Tfoperacoestitulosdataemissao_rangepicker_Internalname, sPrefix+"TFOPERACOESTITULOSDATAEMISSAO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_operacoestitulosdatavencimentoauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_operacoestitulosdatavencimentoauxdatetext_Internalname, AV45DDO_OperacoesTitulosDataVencimentoAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV45DDO_OperacoesTitulosDataVencimentoAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,128);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_operacoestitulosdatavencimentoauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_OperacoesTitulosWW.htm");
            /* User Defined Control */
            ucTfoperacoestitulosdatavencimento_rangepicker.SetProperty("Start Date", AV43DDO_OperacoesTitulosDataVencimentoAuxDate);
            ucTfoperacoestitulosdatavencimento_rangepicker.SetProperty("End Date", AV44DDO_OperacoesTitulosDataVencimentoAuxDateTo);
            ucTfoperacoestitulosdatavencimento_rangepicker.Render(context, "wwp.daterangepicker", Tfoperacoestitulosdatavencimento_rangepicker_Internalname, sPrefix+"TFOPERACOESTITULOSDATAVENCIMENTO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_operacoestituloscreatedatauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_operacoestituloscreatedatauxdatetext_Internalname, AV58DDO_OperacoesTitulosCreatedAtAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV58DDO_OperacoesTitulosCreatedAtAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,131);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_operacoestituloscreatedatauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_OperacoesTitulosWW.htm");
            /* User Defined Control */
            ucTfoperacoestituloscreatedat_rangepicker.SetProperty("Start Date", AV56DDO_OperacoesTitulosCreatedAtAuxDate);
            ucTfoperacoestituloscreatedat_rangepicker.SetProperty("End Date", AV57DDO_OperacoesTitulosCreatedAtAuxDateTo);
            ucTfoperacoestituloscreatedat_rangepicker.Render(context, "wwp.daterangepicker", Tfoperacoestituloscreatedat_rangepicker_Internalname, sPrefix+"TFOPERACOESTITULOSCREATEDAT_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_operacoestitulosupdatedatauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_operacoestitulosupdatedatauxdatetext_Internalname, AV63DDO_OperacoesTitulosUpdatedAtAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV63DDO_OperacoesTitulosUpdatedAtAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,134);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_operacoestitulosupdatedatauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_OperacoesTitulosWW.htm");
            /* User Defined Control */
            ucTfoperacoestitulosupdatedat_rangepicker.SetProperty("Start Date", AV61DDO_OperacoesTitulosUpdatedAtAuxDate);
            ucTfoperacoestitulosupdatedat_rangepicker.SetProperty("End Date", AV62DDO_OperacoesTitulosUpdatedAtAuxDateTo);
            ucTfoperacoestitulosupdatedat_rangepicker.Render(context, "wwp.daterangepicker", Tfoperacoestitulosupdatedat_rangepicker_Internalname, sPrefix+"TFOPERACOESTITULOSUPDATEDAT_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 98 )
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

      protected void STARTA42( )
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
            Form.Meta.addItem("description", " Operacoes Titulos", 0) ;
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
               STRUPA40( ) ;
            }
         }
      }

      protected void WSA42( )
      {
         STARTA42( ) ;
         EVTA42( ) ;
      }

      protected void EVTA42( )
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
                                 STRUPA40( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E11A42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E12A42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E13A42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E14A42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters1' */
                                    E15A42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters2' */
                                    E16A42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters3' */
                                    E17A42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E18A42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoExport' */
                                    E19A42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'AddDynamicFilters1' */
                                    E20A42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E21A42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'AddDynamicFilters2' */
                                    E22A42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E23A42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E24A42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavDisplay_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VDISPLAY.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VUPDATE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VDELETE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VDISPLAY.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VUPDATE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VDELETE.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA40( ) ;
                              }
                              nGXsfl_98_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
                              SubsflControlProps_982( ) ;
                              AV69Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri(sPrefix, false, edtavDisplay_Internalname, AV69Display);
                              AV70Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV70Update);
                              AV71Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri(sPrefix, false, edtavDelete_Internalname, AV71Delete);
                              A1035SacadoRazaoSocial = StringUtil.Upper( cgiGet( edtSacadoRazaoSocial_Internalname));
                              n1035SacadoRazaoSocial = false;
                              A1019OperacoesTitulosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacoesTitulosId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A1010OperacoesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacoesId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n1010OperacoesId = false;
                              cmbOperacoesTitulosTipo.Name = cmbOperacoesTitulosTipo_Internalname;
                              cmbOperacoesTitulosTipo.CurrentValue = cgiGet( cmbOperacoesTitulosTipo_Internalname);
                              A1020OperacoesTitulosTipo = cgiGet( cmbOperacoesTitulosTipo_Internalname);
                              n1020OperacoesTitulosTipo = false;
                              A1021OperacoesTitulosNumero = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacoesTitulosNumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n1021OperacoesTitulosNumero = false;
                              A1022OperacoesTitulosDataEmissao = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtOperacoesTitulosDataEmissao_Internalname), 0));
                              n1022OperacoesTitulosDataEmissao = false;
                              A1023OperacoesTitulosDataVencimento = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtOperacoesTitulosDataVencimento_Internalname), 0));
                              n1023OperacoesTitulosDataVencimento = false;
                              A1024OperacoesTitulosValor = context.localUtil.CToN( cgiGet( edtOperacoesTitulosValor_Internalname), ",", ".");
                              n1024OperacoesTitulosValor = false;
                              A1025OperacoesTitulosLiquido = context.localUtil.CToN( cgiGet( edtOperacoesTitulosLiquido_Internalname), ",", ".");
                              n1025OperacoesTitulosLiquido = false;
                              A1026OperacoesTitulosTaxa = context.localUtil.CToN( cgiGet( edtOperacoesTitulosTaxa_Internalname), ",", ".");
                              n1026OperacoesTitulosTaxa = false;
                              cmbOperacoesTitulosStatus.Name = cmbOperacoesTitulosStatus_Internalname;
                              cmbOperacoesTitulosStatus.CurrentValue = cgiGet( cmbOperacoesTitulosStatus_Internalname);
                              A1027OperacoesTitulosStatus = cgiGet( cmbOperacoesTitulosStatus_Internalname);
                              n1027OperacoesTitulosStatus = false;
                              A1028OperacoesTitulosCreatedAt = context.localUtil.CToT( cgiGet( edtOperacoesTitulosCreatedAt_Internalname), 0);
                              n1028OperacoesTitulosCreatedAt = false;
                              A1029OperacoesTitulosUpdatedAt = context.localUtil.CToT( cgiGet( edtOperacoesTitulosUpdatedAt_Internalname), 0);
                              n1029OperacoesTitulosUpdatedAt = false;
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
                                          GX_FocusControl = edtavDisplay_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E25A42 ();
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
                                          GX_FocusControl = edtavDisplay_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E26A42 ();
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
                                          GX_FocusControl = edtavDisplay_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E27A42 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VDISPLAY.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDisplay_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E28A42 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUPDATE.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDisplay_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E29A42 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VDELETE.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDisplay_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E30A42 ();
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
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV13OrderedBy )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Ordereddsc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV14OrderedDsc )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Filterfulltext Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersselector1 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR1"), AV16DynamicFiltersSelector1) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Operacoestitulostipo1 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vOPERACOESTITULOSTIPO1"), AV17OperacoesTitulosTipo1) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersselector2 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2"), AV19DynamicFiltersSelector2) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Operacoestitulostipo2 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vOPERACOESTITULOSTIPO2"), AV20OperacoesTitulosTipo2) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersselector3 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3"), AV22DynamicFiltersSelector3) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Operacoestitulostipo3 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vOPERACOESTITULOSTIPO3"), AV23OperacoesTitulosTipo3) != 0 )
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
                                       STRUPA40( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDisplay_Internalname;
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

      protected void WEA42( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormA42( ) ;
            }
         }
      }

      protected void PAA42( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "operacoestitulosww")), "operacoestitulosww") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "operacoestitulosww")))) ;
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
                     gxfirstwebparm = GetFirstPar( "OperacoesId");
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
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
         SubsflControlProps_982( ) ;
         while ( nGXsfl_98_idx <= nRC_GXsfl_98 )
         {
            sendrow_982( ) ;
            nGXsfl_98_idx = ((subGrid_Islastpage==1)&&(nGXsfl_98_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_98_idx+1);
            sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
            SubsflControlProps_982( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       string AV15FilterFullText ,
                                       string AV16DynamicFiltersSelector1 ,
                                       string AV17OperacoesTitulosTipo1 ,
                                       string AV19DynamicFiltersSelector2 ,
                                       string AV20OperacoesTitulosTipo2 ,
                                       string AV22DynamicFiltersSelector3 ,
                                       string AV23OperacoesTitulosTipo3 ,
                                       short AV31ManageFiltersExecutionStep ,
                                       string AV77Pgmname ,
                                       int AV73OperacoesId ,
                                       bool AV18DynamicFiltersEnabled2 ,
                                       bool AV21DynamicFiltersEnabled3 ,
                                       string AV75TFSacadoRazaoSocial ,
                                       string AV76TFSacadoRazaoSocial_Sel ,
                                       GxSimpleCollection<string> AV33TFOperacoesTitulosTipo_Sels ,
                                       int AV34TFOperacoesTitulosNumero ,
                                       int AV35TFOperacoesTitulosNumero_To ,
                                       DateTime AV36TFOperacoesTitulosDataEmissao ,
                                       DateTime AV37TFOperacoesTitulosDataEmissao_To ,
                                       DateTime AV41TFOperacoesTitulosDataVencimento ,
                                       DateTime AV42TFOperacoesTitulosDataVencimento_To ,
                                       decimal AV46TFOperacoesTitulosValor ,
                                       decimal AV47TFOperacoesTitulosValor_To ,
                                       decimal AV48TFOperacoesTitulosLiquido ,
                                       decimal AV49TFOperacoesTitulosLiquido_To ,
                                       decimal AV50TFOperacoesTitulosTaxa ,
                                       decimal AV51TFOperacoesTitulosTaxa_To ,
                                       GxSimpleCollection<string> AV53TFOperacoesTitulosStatus_Sels ,
                                       DateTime AV54TFOperacoesTitulosCreatedAt ,
                                       DateTime AV55TFOperacoesTitulosCreatedAt_To ,
                                       DateTime AV59TFOperacoesTitulosUpdatedAt ,
                                       DateTime AV60TFOperacoesTitulosUpdatedAt_To ,
                                       string AV74TrnMode ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV25DynamicFiltersIgnoreFirst ,
                                       bool AV24DynamicFiltersRemoving ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFA42( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_OPERACOESTITULOSID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A1019OperacoesTitulosId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"OPERACOESTITULOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1019OperacoesTitulosId), 9, 0, ".", "")));
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
            AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavOperacoestitulostipo1.ItemCount > 0 )
         {
            AV17OperacoesTitulosTipo1 = cmbavOperacoestitulostipo1.getValidValue(AV17OperacoesTitulosTipo1);
            AssignAttri(sPrefix, false, "AV17OperacoesTitulosTipo1", AV17OperacoesTitulosTipo1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOperacoestitulostipo1.CurrentValue = StringUtil.RTrim( AV17OperacoesTitulosTipo1);
            AssignProp(sPrefix, false, cmbavOperacoestitulostipo1_Internalname, "Values", cmbavOperacoestitulostipo1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV19DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV19DynamicFiltersSelector2);
            AssignAttri(sPrefix, false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavOperacoestitulostipo2.ItemCount > 0 )
         {
            AV20OperacoesTitulosTipo2 = cmbavOperacoestitulostipo2.getValidValue(AV20OperacoesTitulosTipo2);
            AssignAttri(sPrefix, false, "AV20OperacoesTitulosTipo2", AV20OperacoesTitulosTipo2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOperacoestitulostipo2.CurrentValue = StringUtil.RTrim( AV20OperacoesTitulosTipo2);
            AssignProp(sPrefix, false, cmbavOperacoestitulostipo2_Internalname, "Values", cmbavOperacoestitulostipo2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV22DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV22DynamicFiltersSelector3);
            AssignAttri(sPrefix, false, "AV22DynamicFiltersSelector3", AV22DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector3);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavOperacoestitulostipo3.ItemCount > 0 )
         {
            AV23OperacoesTitulosTipo3 = cmbavOperacoestitulostipo3.getValidValue(AV23OperacoesTitulosTipo3);
            AssignAttri(sPrefix, false, "AV23OperacoesTitulosTipo3", AV23OperacoesTitulosTipo3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOperacoestitulostipo3.CurrentValue = StringUtil.RTrim( AV23OperacoesTitulosTipo3);
            AssignProp(sPrefix, false, cmbavOperacoestitulostipo3_Internalname, "Values", cmbavOperacoestitulostipo3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFA42( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV77Pgmname = "OperacoesTitulosWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected void RFA42( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 98;
         /* Execute user event: Refresh */
         E26A42 ();
         nGXsfl_98_idx = 1;
         sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
         SubsflControlProps_982( ) ;
         bGXsfl_98_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
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
            SubsflControlProps_982( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A1020OperacoesTitulosTipo ,
                                                 AV90Operacoestituloswwds_13_tfoperacoestitulostipo_sels ,
                                                 A1027OperacoesTitulosStatus ,
                                                 AV103Operacoestituloswwds_26_tfoperacoestitulosstatus_sels ,
                                                 AV79Operacoestituloswwds_2_filterfulltext ,
                                                 AV80Operacoestituloswwds_3_dynamicfiltersselector1 ,
                                                 AV81Operacoestituloswwds_4_operacoestitulostipo1 ,
                                                 AV82Operacoestituloswwds_5_dynamicfiltersenabled2 ,
                                                 AV83Operacoestituloswwds_6_dynamicfiltersselector2 ,
                                                 AV84Operacoestituloswwds_7_operacoestitulostipo2 ,
                                                 AV85Operacoestituloswwds_8_dynamicfiltersenabled3 ,
                                                 AV86Operacoestituloswwds_9_dynamicfiltersselector3 ,
                                                 AV87Operacoestituloswwds_10_operacoestitulostipo3 ,
                                                 AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel ,
                                                 AV88Operacoestituloswwds_11_tfsacadorazaosocial ,
                                                 AV90Operacoestituloswwds_13_tfoperacoestitulostipo_sels.Count ,
                                                 AV91Operacoestituloswwds_14_tfoperacoestitulosnumero ,
                                                 AV92Operacoestituloswwds_15_tfoperacoestitulosnumero_to ,
                                                 AV93Operacoestituloswwds_16_tfoperacoestitulosdataemissao ,
                                                 AV94Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to ,
                                                 AV95Operacoestituloswwds_18_tfoperacoestitulosdatavencimento ,
                                                 AV96Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to ,
                                                 AV97Operacoestituloswwds_20_tfoperacoestitulosvalor ,
                                                 AV98Operacoestituloswwds_21_tfoperacoestitulosvalor_to ,
                                                 AV99Operacoestituloswwds_22_tfoperacoestitulosliquido ,
                                                 AV100Operacoestituloswwds_23_tfoperacoestitulosliquido_to ,
                                                 AV101Operacoestituloswwds_24_tfoperacoestitulostaxa ,
                                                 AV102Operacoestituloswwds_25_tfoperacoestitulostaxa_to ,
                                                 AV103Operacoestituloswwds_26_tfoperacoestitulosstatus_sels.Count ,
                                                 AV104Operacoestituloswwds_27_tfoperacoestituloscreatedat ,
                                                 AV105Operacoestituloswwds_28_tfoperacoestituloscreatedat_to ,
                                                 AV106Operacoestituloswwds_29_tfoperacoestitulosupdatedat ,
                                                 AV107Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to ,
                                                 A1035SacadoRazaoSocial ,
                                                 A1021OperacoesTitulosNumero ,
                                                 A1024OperacoesTitulosValor ,
                                                 A1025OperacoesTitulosLiquido ,
                                                 A1026OperacoesTitulosTaxa ,
                                                 A1022OperacoesTitulosDataEmissao ,
                                                 A1023OperacoesTitulosDataVencimento ,
                                                 A1028OperacoesTitulosCreatedAt ,
                                                 A1029OperacoesTitulosUpdatedAt ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 A1010OperacoesId ,
                                                 AV78Operacoestituloswwds_1_operacoesid } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                                 TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                                 TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
            lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
            lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
            lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
            lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
            lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
            lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
            lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
            lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
            lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
            lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
            lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
            lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
            lV88Operacoestituloswwds_11_tfsacadorazaosocial = StringUtil.Concat( StringUtil.RTrim( AV88Operacoestituloswwds_11_tfsacadorazaosocial), "%", "");
            /* Using cursor H00A42 */
            pr_default.execute(0, new Object[] {AV78Operacoestituloswwds_1_operacoesid, lV79Operacoestituloswwds_2_filterfulltext, lV79Operacoestituloswwds_2_filterfulltext, lV79Operacoestituloswwds_2_filterfulltext, lV79Operacoestituloswwds_2_filterfulltext, lV79Operacoestituloswwds_2_filterfulltext, lV79Operacoestituloswwds_2_filterfulltext, lV79Operacoestituloswwds_2_filterfulltext, lV79Operacoestituloswwds_2_filterfulltext, lV79Operacoestituloswwds_2_filterfulltext, lV79Operacoestituloswwds_2_filterfulltext, lV79Operacoestituloswwds_2_filterfulltext, lV79Operacoestituloswwds_2_filterfulltext, lV79Operacoestituloswwds_2_filterfulltext, AV81Operacoestituloswwds_4_operacoestitulostipo1, AV84Operacoestituloswwds_7_operacoestitulostipo2, AV87Operacoestituloswwds_10_operacoestitulostipo3, lV88Operacoestituloswwds_11_tfsacadorazaosocial, AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel, AV91Operacoestituloswwds_14_tfoperacoestitulosnumero, AV92Operacoestituloswwds_15_tfoperacoestitulosnumero_to, AV93Operacoestituloswwds_16_tfoperacoestitulosdataemissao, AV94Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to, AV95Operacoestituloswwds_18_tfoperacoestitulosdatavencimento, AV96Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to, AV97Operacoestituloswwds_20_tfoperacoestitulosvalor, AV98Operacoestituloswwds_21_tfoperacoestitulosvalor_to, AV99Operacoestituloswwds_22_tfoperacoestitulosliquido, AV100Operacoestituloswwds_23_tfoperacoestitulosliquido_to, AV101Operacoestituloswwds_24_tfoperacoestitulostaxa, AV102Operacoestituloswwds_25_tfoperacoestitulostaxa_to, AV104Operacoestituloswwds_27_tfoperacoestituloscreatedat, AV105Operacoestituloswwds_28_tfoperacoestituloscreatedat_to, AV106Operacoestituloswwds_29_tfoperacoestitulosupdatedat, AV107Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_98_idx = 1;
            sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
            SubsflControlProps_982( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A1034SacadoId = H00A42_A1034SacadoId[0];
               n1034SacadoId = H00A42_n1034SacadoId[0];
               A1029OperacoesTitulosUpdatedAt = H00A42_A1029OperacoesTitulosUpdatedAt[0];
               n1029OperacoesTitulosUpdatedAt = H00A42_n1029OperacoesTitulosUpdatedAt[0];
               A1028OperacoesTitulosCreatedAt = H00A42_A1028OperacoesTitulosCreatedAt[0];
               n1028OperacoesTitulosCreatedAt = H00A42_n1028OperacoesTitulosCreatedAt[0];
               A1027OperacoesTitulosStatus = H00A42_A1027OperacoesTitulosStatus[0];
               n1027OperacoesTitulosStatus = H00A42_n1027OperacoesTitulosStatus[0];
               A1026OperacoesTitulosTaxa = H00A42_A1026OperacoesTitulosTaxa[0];
               n1026OperacoesTitulosTaxa = H00A42_n1026OperacoesTitulosTaxa[0];
               A1025OperacoesTitulosLiquido = H00A42_A1025OperacoesTitulosLiquido[0];
               n1025OperacoesTitulosLiquido = H00A42_n1025OperacoesTitulosLiquido[0];
               A1024OperacoesTitulosValor = H00A42_A1024OperacoesTitulosValor[0];
               n1024OperacoesTitulosValor = H00A42_n1024OperacoesTitulosValor[0];
               A1023OperacoesTitulosDataVencimento = H00A42_A1023OperacoesTitulosDataVencimento[0];
               n1023OperacoesTitulosDataVencimento = H00A42_n1023OperacoesTitulosDataVencimento[0];
               A1022OperacoesTitulosDataEmissao = H00A42_A1022OperacoesTitulosDataEmissao[0];
               n1022OperacoesTitulosDataEmissao = H00A42_n1022OperacoesTitulosDataEmissao[0];
               A1021OperacoesTitulosNumero = H00A42_A1021OperacoesTitulosNumero[0];
               n1021OperacoesTitulosNumero = H00A42_n1021OperacoesTitulosNumero[0];
               A1020OperacoesTitulosTipo = H00A42_A1020OperacoesTitulosTipo[0];
               n1020OperacoesTitulosTipo = H00A42_n1020OperacoesTitulosTipo[0];
               A1010OperacoesId = H00A42_A1010OperacoesId[0];
               n1010OperacoesId = H00A42_n1010OperacoesId[0];
               A1019OperacoesTitulosId = H00A42_A1019OperacoesTitulosId[0];
               A1035SacadoRazaoSocial = H00A42_A1035SacadoRazaoSocial[0];
               n1035SacadoRazaoSocial = H00A42_n1035SacadoRazaoSocial[0];
               A1035SacadoRazaoSocial = H00A42_A1035SacadoRazaoSocial[0];
               n1035SacadoRazaoSocial = H00A42_n1035SacadoRazaoSocial[0];
               /* Execute user event: Grid.Load */
               E27A42 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 98;
            WBA40( ) ;
         }
         bGXsfl_98_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesA42( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV77Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV77Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_OPERACOESTITULOSID"+"_"+sGXsfl_98_idx, GetSecureSignedToken( sPrefix+sGXsfl_98_idx, context.localUtil.Format( (decimal)(A1019OperacoesTitulosId), "ZZZZZZZZ9"), context));
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
         AV78Operacoestituloswwds_1_operacoesid = AV73OperacoesId;
         AV79Operacoestituloswwds_2_filterfulltext = AV15FilterFullText;
         AV80Operacoestituloswwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV81Operacoestituloswwds_4_operacoestitulostipo1 = AV17OperacoesTitulosTipo1;
         AV82Operacoestituloswwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV83Operacoestituloswwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV84Operacoestituloswwds_7_operacoestitulostipo2 = AV20OperacoesTitulosTipo2;
         AV85Operacoestituloswwds_8_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV86Operacoestituloswwds_9_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV87Operacoestituloswwds_10_operacoestitulostipo3 = AV23OperacoesTitulosTipo3;
         AV88Operacoestituloswwds_11_tfsacadorazaosocial = AV75TFSacadoRazaoSocial;
         AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel = AV76TFSacadoRazaoSocial_Sel;
         AV90Operacoestituloswwds_13_tfoperacoestitulostipo_sels = AV33TFOperacoesTitulosTipo_Sels;
         AV91Operacoestituloswwds_14_tfoperacoestitulosnumero = AV34TFOperacoesTitulosNumero;
         AV92Operacoestituloswwds_15_tfoperacoestitulosnumero_to = AV35TFOperacoesTitulosNumero_To;
         AV93Operacoestituloswwds_16_tfoperacoestitulosdataemissao = AV36TFOperacoesTitulosDataEmissao;
         AV94Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to = AV37TFOperacoesTitulosDataEmissao_To;
         AV95Operacoestituloswwds_18_tfoperacoestitulosdatavencimento = AV41TFOperacoesTitulosDataVencimento;
         AV96Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to = AV42TFOperacoesTitulosDataVencimento_To;
         AV97Operacoestituloswwds_20_tfoperacoestitulosvalor = AV46TFOperacoesTitulosValor;
         AV98Operacoestituloswwds_21_tfoperacoestitulosvalor_to = AV47TFOperacoesTitulosValor_To;
         AV99Operacoestituloswwds_22_tfoperacoestitulosliquido = AV48TFOperacoesTitulosLiquido;
         AV100Operacoestituloswwds_23_tfoperacoestitulosliquido_to = AV49TFOperacoesTitulosLiquido_To;
         AV101Operacoestituloswwds_24_tfoperacoestitulostaxa = AV50TFOperacoesTitulosTaxa;
         AV102Operacoestituloswwds_25_tfoperacoestitulostaxa_to = AV51TFOperacoesTitulosTaxa_To;
         AV103Operacoestituloswwds_26_tfoperacoestitulosstatus_sels = AV53TFOperacoesTitulosStatus_Sels;
         AV104Operacoestituloswwds_27_tfoperacoestituloscreatedat = AV54TFOperacoesTitulosCreatedAt;
         AV105Operacoestituloswwds_28_tfoperacoestituloscreatedat_to = AV55TFOperacoesTitulosCreatedAt_To;
         AV106Operacoestituloswwds_29_tfoperacoestitulosupdatedat = AV59TFOperacoesTitulosUpdatedAt;
         AV107Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to = AV60TFOperacoesTitulosUpdatedAt_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1020OperacoesTitulosTipo ,
                                              AV90Operacoestituloswwds_13_tfoperacoestitulostipo_sels ,
                                              A1027OperacoesTitulosStatus ,
                                              AV103Operacoestituloswwds_26_tfoperacoestitulosstatus_sels ,
                                              AV79Operacoestituloswwds_2_filterfulltext ,
                                              AV80Operacoestituloswwds_3_dynamicfiltersselector1 ,
                                              AV81Operacoestituloswwds_4_operacoestitulostipo1 ,
                                              AV82Operacoestituloswwds_5_dynamicfiltersenabled2 ,
                                              AV83Operacoestituloswwds_6_dynamicfiltersselector2 ,
                                              AV84Operacoestituloswwds_7_operacoestitulostipo2 ,
                                              AV85Operacoestituloswwds_8_dynamicfiltersenabled3 ,
                                              AV86Operacoestituloswwds_9_dynamicfiltersselector3 ,
                                              AV87Operacoestituloswwds_10_operacoestitulostipo3 ,
                                              AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel ,
                                              AV88Operacoestituloswwds_11_tfsacadorazaosocial ,
                                              AV90Operacoestituloswwds_13_tfoperacoestitulostipo_sels.Count ,
                                              AV91Operacoestituloswwds_14_tfoperacoestitulosnumero ,
                                              AV92Operacoestituloswwds_15_tfoperacoestitulosnumero_to ,
                                              AV93Operacoestituloswwds_16_tfoperacoestitulosdataemissao ,
                                              AV94Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to ,
                                              AV95Operacoestituloswwds_18_tfoperacoestitulosdatavencimento ,
                                              AV96Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to ,
                                              AV97Operacoestituloswwds_20_tfoperacoestitulosvalor ,
                                              AV98Operacoestituloswwds_21_tfoperacoestitulosvalor_to ,
                                              AV99Operacoestituloswwds_22_tfoperacoestitulosliquido ,
                                              AV100Operacoestituloswwds_23_tfoperacoestitulosliquido_to ,
                                              AV101Operacoestituloswwds_24_tfoperacoestitulostaxa ,
                                              AV102Operacoestituloswwds_25_tfoperacoestitulostaxa_to ,
                                              AV103Operacoestituloswwds_26_tfoperacoestitulosstatus_sels.Count ,
                                              AV104Operacoestituloswwds_27_tfoperacoestituloscreatedat ,
                                              AV105Operacoestituloswwds_28_tfoperacoestituloscreatedat_to ,
                                              AV106Operacoestituloswwds_29_tfoperacoestitulosupdatedat ,
                                              AV107Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to ,
                                              A1035SacadoRazaoSocial ,
                                              A1021OperacoesTitulosNumero ,
                                              A1024OperacoesTitulosValor ,
                                              A1025OperacoesTitulosLiquido ,
                                              A1026OperacoesTitulosTaxa ,
                                              A1022OperacoesTitulosDataEmissao ,
                                              A1023OperacoesTitulosDataVencimento ,
                                              A1028OperacoesTitulosCreatedAt ,
                                              A1029OperacoesTitulosUpdatedAt ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              A1010OperacoesId ,
                                              AV78Operacoestituloswwds_1_operacoesid } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
         lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
         lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
         lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
         lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
         lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
         lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
         lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
         lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
         lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
         lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
         lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
         lV79Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext), "%", "");
         lV88Operacoestituloswwds_11_tfsacadorazaosocial = StringUtil.Concat( StringUtil.RTrim( AV88Operacoestituloswwds_11_tfsacadorazaosocial), "%", "");
         /* Using cursor H00A43 */
         pr_default.execute(1, new Object[] {AV78Operacoestituloswwds_1_operacoesid, lV79Operacoestituloswwds_2_filterfulltext, lV79Operacoestituloswwds_2_filterfulltext, lV79Operacoestituloswwds_2_filterfulltext, lV79Operacoestituloswwds_2_filterfulltext, lV79Operacoestituloswwds_2_filterfulltext, lV79Operacoestituloswwds_2_filterfulltext, lV79Operacoestituloswwds_2_filterfulltext, lV79Operacoestituloswwds_2_filterfulltext, lV79Operacoestituloswwds_2_filterfulltext, lV79Operacoestituloswwds_2_filterfulltext, lV79Operacoestituloswwds_2_filterfulltext, lV79Operacoestituloswwds_2_filterfulltext, lV79Operacoestituloswwds_2_filterfulltext, AV81Operacoestituloswwds_4_operacoestitulostipo1, AV84Operacoestituloswwds_7_operacoestitulostipo2, AV87Operacoestituloswwds_10_operacoestitulostipo3, lV88Operacoestituloswwds_11_tfsacadorazaosocial, AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel, AV91Operacoestituloswwds_14_tfoperacoestitulosnumero, AV92Operacoestituloswwds_15_tfoperacoestitulosnumero_to, AV93Operacoestituloswwds_16_tfoperacoestitulosdataemissao, AV94Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to, AV95Operacoestituloswwds_18_tfoperacoestitulosdatavencimento, AV96Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to, AV97Operacoestituloswwds_20_tfoperacoestitulosvalor, AV98Operacoestituloswwds_21_tfoperacoestitulosvalor_to, AV99Operacoestituloswwds_22_tfoperacoestitulosliquido, AV100Operacoestituloswwds_23_tfoperacoestitulosliquido_to, AV101Operacoestituloswwds_24_tfoperacoestitulostaxa, AV102Operacoestituloswwds_25_tfoperacoestitulostaxa_to, AV104Operacoestituloswwds_27_tfoperacoestituloscreatedat, AV105Operacoestituloswwds_28_tfoperacoestituloscreatedat_to, AV106Operacoestituloswwds_29_tfoperacoestitulosupdatedat, AV107Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to});
         GRID_nRecordCount = H00A43_AGRID_nRecordCount[0];
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
         AV78Operacoestituloswwds_1_operacoesid = AV73OperacoesId;
         AV79Operacoestituloswwds_2_filterfulltext = AV15FilterFullText;
         AV80Operacoestituloswwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV81Operacoestituloswwds_4_operacoestitulostipo1 = AV17OperacoesTitulosTipo1;
         AV82Operacoestituloswwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV83Operacoestituloswwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV84Operacoestituloswwds_7_operacoestitulostipo2 = AV20OperacoesTitulosTipo2;
         AV85Operacoestituloswwds_8_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV86Operacoestituloswwds_9_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV87Operacoestituloswwds_10_operacoestitulostipo3 = AV23OperacoesTitulosTipo3;
         AV88Operacoestituloswwds_11_tfsacadorazaosocial = AV75TFSacadoRazaoSocial;
         AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel = AV76TFSacadoRazaoSocial_Sel;
         AV90Operacoestituloswwds_13_tfoperacoestitulostipo_sels = AV33TFOperacoesTitulosTipo_Sels;
         AV91Operacoestituloswwds_14_tfoperacoestitulosnumero = AV34TFOperacoesTitulosNumero;
         AV92Operacoestituloswwds_15_tfoperacoestitulosnumero_to = AV35TFOperacoesTitulosNumero_To;
         AV93Operacoestituloswwds_16_tfoperacoestitulosdataemissao = AV36TFOperacoesTitulosDataEmissao;
         AV94Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to = AV37TFOperacoesTitulosDataEmissao_To;
         AV95Operacoestituloswwds_18_tfoperacoestitulosdatavencimento = AV41TFOperacoesTitulosDataVencimento;
         AV96Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to = AV42TFOperacoesTitulosDataVencimento_To;
         AV97Operacoestituloswwds_20_tfoperacoestitulosvalor = AV46TFOperacoesTitulosValor;
         AV98Operacoestituloswwds_21_tfoperacoestitulosvalor_to = AV47TFOperacoesTitulosValor_To;
         AV99Operacoestituloswwds_22_tfoperacoestitulosliquido = AV48TFOperacoesTitulosLiquido;
         AV100Operacoestituloswwds_23_tfoperacoestitulosliquido_to = AV49TFOperacoesTitulosLiquido_To;
         AV101Operacoestituloswwds_24_tfoperacoestitulostaxa = AV50TFOperacoesTitulosTaxa;
         AV102Operacoestituloswwds_25_tfoperacoestitulostaxa_to = AV51TFOperacoesTitulosTaxa_To;
         AV103Operacoestituloswwds_26_tfoperacoestitulosstatus_sels = AV53TFOperacoesTitulosStatus_Sels;
         AV104Operacoestituloswwds_27_tfoperacoestituloscreatedat = AV54TFOperacoesTitulosCreatedAt;
         AV105Operacoestituloswwds_28_tfoperacoestituloscreatedat_to = AV55TFOperacoesTitulosCreatedAt_To;
         AV106Operacoestituloswwds_29_tfoperacoestitulosupdatedat = AV59TFOperacoesTitulosUpdatedAt;
         AV107Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to = AV60TFOperacoesTitulosUpdatedAt_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17OperacoesTitulosTipo1, AV19DynamicFiltersSelector2, AV20OperacoesTitulosTipo2, AV22DynamicFiltersSelector3, AV23OperacoesTitulosTipo3, AV31ManageFiltersExecutionStep, AV77Pgmname, AV73OperacoesId, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3, AV75TFSacadoRazaoSocial, AV76TFSacadoRazaoSocial_Sel, AV33TFOperacoesTitulosTipo_Sels, AV34TFOperacoesTitulosNumero, AV35TFOperacoesTitulosNumero_To, AV36TFOperacoesTitulosDataEmissao, AV37TFOperacoesTitulosDataEmissao_To, AV41TFOperacoesTitulosDataVencimento, AV42TFOperacoesTitulosDataVencimento_To, AV46TFOperacoesTitulosValor, AV47TFOperacoesTitulosValor_To, AV48TFOperacoesTitulosLiquido, AV49TFOperacoesTitulosLiquido_To, AV50TFOperacoesTitulosTaxa, AV51TFOperacoesTitulosTaxa_To, AV53TFOperacoesTitulosStatus_Sels, AV54TFOperacoesTitulosCreatedAt, AV55TFOperacoesTitulosCreatedAt_To, AV59TFOperacoesTitulosUpdatedAt, AV60TFOperacoesTitulosUpdatedAt_To, AV74TrnMode, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV78Operacoestituloswwds_1_operacoesid = AV73OperacoesId;
         AV79Operacoestituloswwds_2_filterfulltext = AV15FilterFullText;
         AV80Operacoestituloswwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV81Operacoestituloswwds_4_operacoestitulostipo1 = AV17OperacoesTitulosTipo1;
         AV82Operacoestituloswwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV83Operacoestituloswwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV84Operacoestituloswwds_7_operacoestitulostipo2 = AV20OperacoesTitulosTipo2;
         AV85Operacoestituloswwds_8_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV86Operacoestituloswwds_9_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV87Operacoestituloswwds_10_operacoestitulostipo3 = AV23OperacoesTitulosTipo3;
         AV88Operacoestituloswwds_11_tfsacadorazaosocial = AV75TFSacadoRazaoSocial;
         AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel = AV76TFSacadoRazaoSocial_Sel;
         AV90Operacoestituloswwds_13_tfoperacoestitulostipo_sels = AV33TFOperacoesTitulosTipo_Sels;
         AV91Operacoestituloswwds_14_tfoperacoestitulosnumero = AV34TFOperacoesTitulosNumero;
         AV92Operacoestituloswwds_15_tfoperacoestitulosnumero_to = AV35TFOperacoesTitulosNumero_To;
         AV93Operacoestituloswwds_16_tfoperacoestitulosdataemissao = AV36TFOperacoesTitulosDataEmissao;
         AV94Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to = AV37TFOperacoesTitulosDataEmissao_To;
         AV95Operacoestituloswwds_18_tfoperacoestitulosdatavencimento = AV41TFOperacoesTitulosDataVencimento;
         AV96Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to = AV42TFOperacoesTitulosDataVencimento_To;
         AV97Operacoestituloswwds_20_tfoperacoestitulosvalor = AV46TFOperacoesTitulosValor;
         AV98Operacoestituloswwds_21_tfoperacoestitulosvalor_to = AV47TFOperacoesTitulosValor_To;
         AV99Operacoestituloswwds_22_tfoperacoestitulosliquido = AV48TFOperacoesTitulosLiquido;
         AV100Operacoestituloswwds_23_tfoperacoestitulosliquido_to = AV49TFOperacoesTitulosLiquido_To;
         AV101Operacoestituloswwds_24_tfoperacoestitulostaxa = AV50TFOperacoesTitulosTaxa;
         AV102Operacoestituloswwds_25_tfoperacoestitulostaxa_to = AV51TFOperacoesTitulosTaxa_To;
         AV103Operacoestituloswwds_26_tfoperacoestitulosstatus_sels = AV53TFOperacoesTitulosStatus_Sels;
         AV104Operacoestituloswwds_27_tfoperacoestituloscreatedat = AV54TFOperacoesTitulosCreatedAt;
         AV105Operacoestituloswwds_28_tfoperacoestituloscreatedat_to = AV55TFOperacoesTitulosCreatedAt_To;
         AV106Operacoestituloswwds_29_tfoperacoestitulosupdatedat = AV59TFOperacoesTitulosUpdatedAt;
         AV107Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to = AV60TFOperacoesTitulosUpdatedAt_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17OperacoesTitulosTipo1, AV19DynamicFiltersSelector2, AV20OperacoesTitulosTipo2, AV22DynamicFiltersSelector3, AV23OperacoesTitulosTipo3, AV31ManageFiltersExecutionStep, AV77Pgmname, AV73OperacoesId, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3, AV75TFSacadoRazaoSocial, AV76TFSacadoRazaoSocial_Sel, AV33TFOperacoesTitulosTipo_Sels, AV34TFOperacoesTitulosNumero, AV35TFOperacoesTitulosNumero_To, AV36TFOperacoesTitulosDataEmissao, AV37TFOperacoesTitulosDataEmissao_To, AV41TFOperacoesTitulosDataVencimento, AV42TFOperacoesTitulosDataVencimento_To, AV46TFOperacoesTitulosValor, AV47TFOperacoesTitulosValor_To, AV48TFOperacoesTitulosLiquido, AV49TFOperacoesTitulosLiquido_To, AV50TFOperacoesTitulosTaxa, AV51TFOperacoesTitulosTaxa_To, AV53TFOperacoesTitulosStatus_Sels, AV54TFOperacoesTitulosCreatedAt, AV55TFOperacoesTitulosCreatedAt_To, AV59TFOperacoesTitulosUpdatedAt, AV60TFOperacoesTitulosUpdatedAt_To, AV74TrnMode, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV78Operacoestituloswwds_1_operacoesid = AV73OperacoesId;
         AV79Operacoestituloswwds_2_filterfulltext = AV15FilterFullText;
         AV80Operacoestituloswwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV81Operacoestituloswwds_4_operacoestitulostipo1 = AV17OperacoesTitulosTipo1;
         AV82Operacoestituloswwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV83Operacoestituloswwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV84Operacoestituloswwds_7_operacoestitulostipo2 = AV20OperacoesTitulosTipo2;
         AV85Operacoestituloswwds_8_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV86Operacoestituloswwds_9_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV87Operacoestituloswwds_10_operacoestitulostipo3 = AV23OperacoesTitulosTipo3;
         AV88Operacoestituloswwds_11_tfsacadorazaosocial = AV75TFSacadoRazaoSocial;
         AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel = AV76TFSacadoRazaoSocial_Sel;
         AV90Operacoestituloswwds_13_tfoperacoestitulostipo_sels = AV33TFOperacoesTitulosTipo_Sels;
         AV91Operacoestituloswwds_14_tfoperacoestitulosnumero = AV34TFOperacoesTitulosNumero;
         AV92Operacoestituloswwds_15_tfoperacoestitulosnumero_to = AV35TFOperacoesTitulosNumero_To;
         AV93Operacoestituloswwds_16_tfoperacoestitulosdataemissao = AV36TFOperacoesTitulosDataEmissao;
         AV94Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to = AV37TFOperacoesTitulosDataEmissao_To;
         AV95Operacoestituloswwds_18_tfoperacoestitulosdatavencimento = AV41TFOperacoesTitulosDataVencimento;
         AV96Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to = AV42TFOperacoesTitulosDataVencimento_To;
         AV97Operacoestituloswwds_20_tfoperacoestitulosvalor = AV46TFOperacoesTitulosValor;
         AV98Operacoestituloswwds_21_tfoperacoestitulosvalor_to = AV47TFOperacoesTitulosValor_To;
         AV99Operacoestituloswwds_22_tfoperacoestitulosliquido = AV48TFOperacoesTitulosLiquido;
         AV100Operacoestituloswwds_23_tfoperacoestitulosliquido_to = AV49TFOperacoesTitulosLiquido_To;
         AV101Operacoestituloswwds_24_tfoperacoestitulostaxa = AV50TFOperacoesTitulosTaxa;
         AV102Operacoestituloswwds_25_tfoperacoestitulostaxa_to = AV51TFOperacoesTitulosTaxa_To;
         AV103Operacoestituloswwds_26_tfoperacoestitulosstatus_sels = AV53TFOperacoesTitulosStatus_Sels;
         AV104Operacoestituloswwds_27_tfoperacoestituloscreatedat = AV54TFOperacoesTitulosCreatedAt;
         AV105Operacoestituloswwds_28_tfoperacoestituloscreatedat_to = AV55TFOperacoesTitulosCreatedAt_To;
         AV106Operacoestituloswwds_29_tfoperacoestitulosupdatedat = AV59TFOperacoesTitulosUpdatedAt;
         AV107Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to = AV60TFOperacoesTitulosUpdatedAt_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17OperacoesTitulosTipo1, AV19DynamicFiltersSelector2, AV20OperacoesTitulosTipo2, AV22DynamicFiltersSelector3, AV23OperacoesTitulosTipo3, AV31ManageFiltersExecutionStep, AV77Pgmname, AV73OperacoesId, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3, AV75TFSacadoRazaoSocial, AV76TFSacadoRazaoSocial_Sel, AV33TFOperacoesTitulosTipo_Sels, AV34TFOperacoesTitulosNumero, AV35TFOperacoesTitulosNumero_To, AV36TFOperacoesTitulosDataEmissao, AV37TFOperacoesTitulosDataEmissao_To, AV41TFOperacoesTitulosDataVencimento, AV42TFOperacoesTitulosDataVencimento_To, AV46TFOperacoesTitulosValor, AV47TFOperacoesTitulosValor_To, AV48TFOperacoesTitulosLiquido, AV49TFOperacoesTitulosLiquido_To, AV50TFOperacoesTitulosTaxa, AV51TFOperacoesTitulosTaxa_To, AV53TFOperacoesTitulosStatus_Sels, AV54TFOperacoesTitulosCreatedAt, AV55TFOperacoesTitulosCreatedAt_To, AV59TFOperacoesTitulosUpdatedAt, AV60TFOperacoesTitulosUpdatedAt_To, AV74TrnMode, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV78Operacoestituloswwds_1_operacoesid = AV73OperacoesId;
         AV79Operacoestituloswwds_2_filterfulltext = AV15FilterFullText;
         AV80Operacoestituloswwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV81Operacoestituloswwds_4_operacoestitulostipo1 = AV17OperacoesTitulosTipo1;
         AV82Operacoestituloswwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV83Operacoestituloswwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV84Operacoestituloswwds_7_operacoestitulostipo2 = AV20OperacoesTitulosTipo2;
         AV85Operacoestituloswwds_8_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV86Operacoestituloswwds_9_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV87Operacoestituloswwds_10_operacoestitulostipo3 = AV23OperacoesTitulosTipo3;
         AV88Operacoestituloswwds_11_tfsacadorazaosocial = AV75TFSacadoRazaoSocial;
         AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel = AV76TFSacadoRazaoSocial_Sel;
         AV90Operacoestituloswwds_13_tfoperacoestitulostipo_sels = AV33TFOperacoesTitulosTipo_Sels;
         AV91Operacoestituloswwds_14_tfoperacoestitulosnumero = AV34TFOperacoesTitulosNumero;
         AV92Operacoestituloswwds_15_tfoperacoestitulosnumero_to = AV35TFOperacoesTitulosNumero_To;
         AV93Operacoestituloswwds_16_tfoperacoestitulosdataemissao = AV36TFOperacoesTitulosDataEmissao;
         AV94Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to = AV37TFOperacoesTitulosDataEmissao_To;
         AV95Operacoestituloswwds_18_tfoperacoestitulosdatavencimento = AV41TFOperacoesTitulosDataVencimento;
         AV96Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to = AV42TFOperacoesTitulosDataVencimento_To;
         AV97Operacoestituloswwds_20_tfoperacoestitulosvalor = AV46TFOperacoesTitulosValor;
         AV98Operacoestituloswwds_21_tfoperacoestitulosvalor_to = AV47TFOperacoesTitulosValor_To;
         AV99Operacoestituloswwds_22_tfoperacoestitulosliquido = AV48TFOperacoesTitulosLiquido;
         AV100Operacoestituloswwds_23_tfoperacoestitulosliquido_to = AV49TFOperacoesTitulosLiquido_To;
         AV101Operacoestituloswwds_24_tfoperacoestitulostaxa = AV50TFOperacoesTitulosTaxa;
         AV102Operacoestituloswwds_25_tfoperacoestitulostaxa_to = AV51TFOperacoesTitulosTaxa_To;
         AV103Operacoestituloswwds_26_tfoperacoestitulosstatus_sels = AV53TFOperacoesTitulosStatus_Sels;
         AV104Operacoestituloswwds_27_tfoperacoestituloscreatedat = AV54TFOperacoesTitulosCreatedAt;
         AV105Operacoestituloswwds_28_tfoperacoestituloscreatedat_to = AV55TFOperacoesTitulosCreatedAt_To;
         AV106Operacoestituloswwds_29_tfoperacoestitulosupdatedat = AV59TFOperacoesTitulosUpdatedAt;
         AV107Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to = AV60TFOperacoesTitulosUpdatedAt_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17OperacoesTitulosTipo1, AV19DynamicFiltersSelector2, AV20OperacoesTitulosTipo2, AV22DynamicFiltersSelector3, AV23OperacoesTitulosTipo3, AV31ManageFiltersExecutionStep, AV77Pgmname, AV73OperacoesId, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3, AV75TFSacadoRazaoSocial, AV76TFSacadoRazaoSocial_Sel, AV33TFOperacoesTitulosTipo_Sels, AV34TFOperacoesTitulosNumero, AV35TFOperacoesTitulosNumero_To, AV36TFOperacoesTitulosDataEmissao, AV37TFOperacoesTitulosDataEmissao_To, AV41TFOperacoesTitulosDataVencimento, AV42TFOperacoesTitulosDataVencimento_To, AV46TFOperacoesTitulosValor, AV47TFOperacoesTitulosValor_To, AV48TFOperacoesTitulosLiquido, AV49TFOperacoesTitulosLiquido_To, AV50TFOperacoesTitulosTaxa, AV51TFOperacoesTitulosTaxa_To, AV53TFOperacoesTitulosStatus_Sels, AV54TFOperacoesTitulosCreatedAt, AV55TFOperacoesTitulosCreatedAt_To, AV59TFOperacoesTitulosUpdatedAt, AV60TFOperacoesTitulosUpdatedAt_To, AV74TrnMode, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV78Operacoestituloswwds_1_operacoesid = AV73OperacoesId;
         AV79Operacoestituloswwds_2_filterfulltext = AV15FilterFullText;
         AV80Operacoestituloswwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV81Operacoestituloswwds_4_operacoestitulostipo1 = AV17OperacoesTitulosTipo1;
         AV82Operacoestituloswwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV83Operacoestituloswwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV84Operacoestituloswwds_7_operacoestitulostipo2 = AV20OperacoesTitulosTipo2;
         AV85Operacoestituloswwds_8_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV86Operacoestituloswwds_9_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV87Operacoestituloswwds_10_operacoestitulostipo3 = AV23OperacoesTitulosTipo3;
         AV88Operacoestituloswwds_11_tfsacadorazaosocial = AV75TFSacadoRazaoSocial;
         AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel = AV76TFSacadoRazaoSocial_Sel;
         AV90Operacoestituloswwds_13_tfoperacoestitulostipo_sels = AV33TFOperacoesTitulosTipo_Sels;
         AV91Operacoestituloswwds_14_tfoperacoestitulosnumero = AV34TFOperacoesTitulosNumero;
         AV92Operacoestituloswwds_15_tfoperacoestitulosnumero_to = AV35TFOperacoesTitulosNumero_To;
         AV93Operacoestituloswwds_16_tfoperacoestitulosdataemissao = AV36TFOperacoesTitulosDataEmissao;
         AV94Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to = AV37TFOperacoesTitulosDataEmissao_To;
         AV95Operacoestituloswwds_18_tfoperacoestitulosdatavencimento = AV41TFOperacoesTitulosDataVencimento;
         AV96Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to = AV42TFOperacoesTitulosDataVencimento_To;
         AV97Operacoestituloswwds_20_tfoperacoestitulosvalor = AV46TFOperacoesTitulosValor;
         AV98Operacoestituloswwds_21_tfoperacoestitulosvalor_to = AV47TFOperacoesTitulosValor_To;
         AV99Operacoestituloswwds_22_tfoperacoestitulosliquido = AV48TFOperacoesTitulosLiquido;
         AV100Operacoestituloswwds_23_tfoperacoestitulosliquido_to = AV49TFOperacoesTitulosLiquido_To;
         AV101Operacoestituloswwds_24_tfoperacoestitulostaxa = AV50TFOperacoesTitulosTaxa;
         AV102Operacoestituloswwds_25_tfoperacoestitulostaxa_to = AV51TFOperacoesTitulosTaxa_To;
         AV103Operacoestituloswwds_26_tfoperacoestitulosstatus_sels = AV53TFOperacoesTitulosStatus_Sels;
         AV104Operacoestituloswwds_27_tfoperacoestituloscreatedat = AV54TFOperacoesTitulosCreatedAt;
         AV105Operacoestituloswwds_28_tfoperacoestituloscreatedat_to = AV55TFOperacoesTitulosCreatedAt_To;
         AV106Operacoestituloswwds_29_tfoperacoestitulosupdatedat = AV59TFOperacoesTitulosUpdatedAt;
         AV107Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to = AV60TFOperacoesTitulosUpdatedAt_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17OperacoesTitulosTipo1, AV19DynamicFiltersSelector2, AV20OperacoesTitulosTipo2, AV22DynamicFiltersSelector3, AV23OperacoesTitulosTipo3, AV31ManageFiltersExecutionStep, AV77Pgmname, AV73OperacoesId, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3, AV75TFSacadoRazaoSocial, AV76TFSacadoRazaoSocial_Sel, AV33TFOperacoesTitulosTipo_Sels, AV34TFOperacoesTitulosNumero, AV35TFOperacoesTitulosNumero_To, AV36TFOperacoesTitulosDataEmissao, AV37TFOperacoesTitulosDataEmissao_To, AV41TFOperacoesTitulosDataVencimento, AV42TFOperacoesTitulosDataVencimento_To, AV46TFOperacoesTitulosValor, AV47TFOperacoesTitulosValor_To, AV48TFOperacoesTitulosLiquido, AV49TFOperacoesTitulosLiquido_To, AV50TFOperacoesTitulosTaxa, AV51TFOperacoesTitulosTaxa_To, AV53TFOperacoesTitulosStatus_Sels, AV54TFOperacoesTitulosCreatedAt, AV55TFOperacoesTitulosCreatedAt_To, AV59TFOperacoesTitulosUpdatedAt, AV60TFOperacoesTitulosUpdatedAt_To, AV74TrnMode, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV77Pgmname = "OperacoesTitulosWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtSacadoRazaoSocial_Enabled = 0;
         edtOperacoesTitulosId_Enabled = 0;
         edtOperacoesId_Enabled = 0;
         cmbOperacoesTitulosTipo.Enabled = 0;
         edtOperacoesTitulosNumero_Enabled = 0;
         edtOperacoesTitulosDataEmissao_Enabled = 0;
         edtOperacoesTitulosDataVencimento_Enabled = 0;
         edtOperacoesTitulosValor_Enabled = 0;
         edtOperacoesTitulosLiquido_Enabled = 0;
         edtOperacoesTitulosTaxa_Enabled = 0;
         cmbOperacoesTitulosStatus.Enabled = 0;
         edtOperacoesTitulosCreatedAt_Enabled = 0;
         edtOperacoesTitulosUpdatedAt_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPA40( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E25A42 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV29ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV64DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_98 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_98"), ",", "."), 18, MidpointRounding.ToEven));
            AV66GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV67GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV68GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            AV38DDO_OperacoesTitulosDataEmissaoAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_OPERACOESTITULOSDATAEMISSAOAUXDATE"), 0);
            AV39DDO_OperacoesTitulosDataEmissaoAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_OPERACOESTITULOSDATAEMISSAOAUXDATETO"), 0);
            AV43DDO_OperacoesTitulosDataVencimentoAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_OPERACOESTITULOSDATAVENCIMENTOAUXDATE"), 0);
            AV44DDO_OperacoesTitulosDataVencimentoAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_OPERACOESTITULOSDATAVENCIMENTOAUXDATETO"), 0);
            AV56DDO_OperacoesTitulosCreatedAtAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_OPERACOESTITULOSCREATEDATAUXDATE"), 0);
            AssignAttri(sPrefix, false, "AV56DDO_OperacoesTitulosCreatedAtAuxDate", context.localUtil.Format(AV56DDO_OperacoesTitulosCreatedAtAuxDate, "99/99/99"));
            AV57DDO_OperacoesTitulosCreatedAtAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_OPERACOESTITULOSCREATEDATAUXDATETO"), 0);
            AssignAttri(sPrefix, false, "AV57DDO_OperacoesTitulosCreatedAtAuxDateTo", context.localUtil.Format(AV57DDO_OperacoesTitulosCreatedAtAuxDateTo, "99/99/99"));
            AV61DDO_OperacoesTitulosUpdatedAtAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_OPERACOESTITULOSUPDATEDATAUXDATE"), 0);
            AssignAttri(sPrefix, false, "AV61DDO_OperacoesTitulosUpdatedAtAuxDate", context.localUtil.Format(AV61DDO_OperacoesTitulosUpdatedAtAuxDate, "99/99/99"));
            AV62DDO_OperacoesTitulosUpdatedAtAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_OPERACOESTITULOSUPDATEDATAUXDATETO"), 0);
            AssignAttri(sPrefix, false, "AV62DDO_OperacoesTitulosUpdatedAtAuxDateTo", context.localUtil.Format(AV62DDO_OperacoesTitulosUpdatedAtAuxDateTo, "99/99/99"));
            wcpOAV73OperacoesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV73OperacoesId"), ",", "."), 18, MidpointRounding.ToEven));
            wcpOAV74TrnMode = cgiGet( sPrefix+"wcpOAV74TrnMode");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Cls");
            Dvpanel_tableheader_Width = cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Width");
            Dvpanel_tableheader_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Autowidth"));
            Dvpanel_tableheader_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Autoheight"));
            Dvpanel_tableheader_Cls = cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Cls");
            Dvpanel_tableheader_Title = cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Title");
            Dvpanel_tableheader_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Collapsible"));
            Dvpanel_tableheader_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Collapsed"));
            Dvpanel_tableheader_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Showcollapseicon"));
            Dvpanel_tableheader_Iconposition = cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Iconposition");
            Dvpanel_tableheader_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Autoscroll"));
            Gridpaginationbar_Class = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagestoshow"), ",", "."), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption");
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
            Ddo_grid_Allowmultipleselection = cgiGet( sPrefix+"DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( sPrefix+"DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( sPrefix+"DDO_GRID_Format");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Fixedcolumns = cgiGet( sPrefix+"GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_managefilters_Activeeventkey = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV16DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            cmbavOperacoestitulostipo1.Name = cmbavOperacoestitulostipo1_Internalname;
            cmbavOperacoestitulostipo1.CurrentValue = cgiGet( cmbavOperacoestitulostipo1_Internalname);
            AV17OperacoesTitulosTipo1 = cgiGet( cmbavOperacoestitulostipo1_Internalname);
            AssignAttri(sPrefix, false, "AV17OperacoesTitulosTipo1", AV17OperacoesTitulosTipo1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV19DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri(sPrefix, false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
            cmbavOperacoestitulostipo2.Name = cmbavOperacoestitulostipo2_Internalname;
            cmbavOperacoestitulostipo2.CurrentValue = cgiGet( cmbavOperacoestitulostipo2_Internalname);
            AV20OperacoesTitulosTipo2 = cgiGet( cmbavOperacoestitulostipo2_Internalname);
            AssignAttri(sPrefix, false, "AV20OperacoesTitulosTipo2", AV20OperacoesTitulosTipo2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV22DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri(sPrefix, false, "AV22DynamicFiltersSelector3", AV22DynamicFiltersSelector3);
            cmbavOperacoestitulostipo3.Name = cmbavOperacoestitulostipo3_Internalname;
            cmbavOperacoestitulostipo3.CurrentValue = cgiGet( cmbavOperacoestitulostipo3_Internalname);
            AV23OperacoesTitulosTipo3 = cgiGet( cmbavOperacoestitulostipo3_Internalname);
            AssignAttri(sPrefix, false, "AV23OperacoesTitulosTipo3", AV23OperacoesTitulosTipo3);
            AV40DDO_OperacoesTitulosDataEmissaoAuxDateText = cgiGet( edtavDdo_operacoestitulosdataemissaoauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV40DDO_OperacoesTitulosDataEmissaoAuxDateText", AV40DDO_OperacoesTitulosDataEmissaoAuxDateText);
            AV45DDO_OperacoesTitulosDataVencimentoAuxDateText = cgiGet( edtavDdo_operacoestitulosdatavencimentoauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV45DDO_OperacoesTitulosDataVencimentoAuxDateText", AV45DDO_OperacoesTitulosDataVencimentoAuxDateText);
            AV58DDO_OperacoesTitulosCreatedAtAuxDateText = cgiGet( edtavDdo_operacoestituloscreatedatauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV58DDO_OperacoesTitulosCreatedAtAuxDateText", AV58DDO_OperacoesTitulosCreatedAtAuxDateText);
            AV63DDO_OperacoesTitulosUpdatedAtAuxDateText = cgiGet( edtavDdo_operacoestitulosupdatedatauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV63DDO_OperacoesTitulosUpdatedAtAuxDateText", AV63DDO_OperacoesTitulosUpdatedAtAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV13OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV14OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR1"), AV16DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vOPERACOESTITULOSTIPO1"), AV17OperacoesTitulosTipo1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2"), AV19DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vOPERACOESTITULOSTIPO2"), AV20OperacoesTitulosTipo2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3"), AV22DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vOPERACOESTITULOSTIPO3"), AV23OperacoesTitulosTipo3) != 0 )
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
         E25A42 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E25A42( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod(sPrefix, false, "TFOPERACOESTITULOSUPDATEDAT_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_operacoestitulosupdatedatauxdatetext_Internalname});
         this.executeUsercontrolMethod(sPrefix, false, "TFOPERACOESTITULOSCREATEDAT_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_operacoestituloscreatedatauxdatetext_Internalname});
         this.executeUsercontrolMethod(sPrefix, false, "TFOPERACOESTITULOSDATAVENCIMENTO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_operacoestitulosdatavencimentoauxdatetext_Internalname});
         this.executeUsercontrolMethod(sPrefix, false, "TFOPERACOESTITULOSDATAEMISSAO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_operacoestitulosdataemissaoauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         /* Execute user subroutine: 'LOADSAVEDFILTERS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         lblJsdynamicfilters_Caption = "";
         AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV17OperacoesTitulosTipo1 = "";
         AssignAttri(sPrefix, false, "AV17OperacoesTitulosTipo1", AV17OperacoesTitulosTipo1);
         AV16DynamicFiltersSelector1 = "OPERACOESTITULOSTIPO";
         AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20OperacoesTitulosTipo2 = "";
         AssignAttri(sPrefix, false, "AV20OperacoesTitulosTipo2", AV20OperacoesTitulosTipo2);
         AV19DynamicFiltersSelector2 = "OPERACOESTITULOSTIPO";
         AssignAttri(sPrefix, false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23OperacoesTitulosTipo3 = "";
         AssignAttri(sPrefix, false, "AV23OperacoesTitulosTipo3", AV23OperacoesTitulosTipo3);
         AV22DynamicFiltersSelector3 = "OPERACOESTITULOSTIPO";
         AssignAttri(sPrefix, false, "AV22DynamicFiltersSelector3", AV22DynamicFiltersSelector3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         imgAdddynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, imgAdddynamicfilters1_Internalname, "Jsonclick", imgAdddynamicfilters1_Jsonclick, true);
         imgRemovedynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, imgRemovedynamicfilters1_Internalname, "Jsonclick", imgRemovedynamicfilters1_Jsonclick, true);
         imgAdddynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Jsonclick", imgAdddynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Jsonclick", imgRemovedynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters3_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, imgRemovedynamicfilters3_Internalname, "Jsonclick", imgRemovedynamicfilters3_Jsonclick, true);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
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
            AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV64DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV64DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E26A42( )
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
         if ( AV31ManageFiltersExecutionStep == 1 )
         {
            AV31ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV31ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV31ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV31ManageFiltersExecutionStep == 2 )
         {
            AV31ManageFiltersExecutionStep = 0;
            AssignAttri(sPrefix, false, "AV31ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV31ManageFiltersExecutionStep), 1, 0));
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
         AV66GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV66GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV66GridCurrentPage), 10, 0));
         AV67GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV67GridPageCount", StringUtil.LTrimStr( (decimal)(AV67GridPageCount), 10, 0));
         GXt_char2 = AV68GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV77Pgmname, out  GXt_char2) ;
         AV68GridAppliedFilters = GXt_char2;
         AssignAttri(sPrefix, false, "AV68GridAppliedFilters", AV68GridAppliedFilters);
         AV78Operacoestituloswwds_1_operacoesid = AV73OperacoesId;
         AV79Operacoestituloswwds_2_filterfulltext = AV15FilterFullText;
         AV80Operacoestituloswwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV81Operacoestituloswwds_4_operacoestitulostipo1 = AV17OperacoesTitulosTipo1;
         AV82Operacoestituloswwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV83Operacoestituloswwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV84Operacoestituloswwds_7_operacoestitulostipo2 = AV20OperacoesTitulosTipo2;
         AV85Operacoestituloswwds_8_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV86Operacoestituloswwds_9_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV87Operacoestituloswwds_10_operacoestitulostipo3 = AV23OperacoesTitulosTipo3;
         AV88Operacoestituloswwds_11_tfsacadorazaosocial = AV75TFSacadoRazaoSocial;
         AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel = AV76TFSacadoRazaoSocial_Sel;
         AV90Operacoestituloswwds_13_tfoperacoestitulostipo_sels = AV33TFOperacoesTitulosTipo_Sels;
         AV91Operacoestituloswwds_14_tfoperacoestitulosnumero = AV34TFOperacoesTitulosNumero;
         AV92Operacoestituloswwds_15_tfoperacoestitulosnumero_to = AV35TFOperacoesTitulosNumero_To;
         AV93Operacoestituloswwds_16_tfoperacoestitulosdataemissao = AV36TFOperacoesTitulosDataEmissao;
         AV94Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to = AV37TFOperacoesTitulosDataEmissao_To;
         AV95Operacoestituloswwds_18_tfoperacoestitulosdatavencimento = AV41TFOperacoesTitulosDataVencimento;
         AV96Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to = AV42TFOperacoesTitulosDataVencimento_To;
         AV97Operacoestituloswwds_20_tfoperacoestitulosvalor = AV46TFOperacoesTitulosValor;
         AV98Operacoestituloswwds_21_tfoperacoestitulosvalor_to = AV47TFOperacoesTitulosValor_To;
         AV99Operacoestituloswwds_22_tfoperacoestitulosliquido = AV48TFOperacoesTitulosLiquido;
         AV100Operacoestituloswwds_23_tfoperacoestitulosliquido_to = AV49TFOperacoesTitulosLiquido_To;
         AV101Operacoestituloswwds_24_tfoperacoestitulostaxa = AV50TFOperacoesTitulosTaxa;
         AV102Operacoestituloswwds_25_tfoperacoestitulostaxa_to = AV51TFOperacoesTitulosTaxa_To;
         AV103Operacoestituloswwds_26_tfoperacoestitulosstatus_sels = AV53TFOperacoesTitulosStatus_Sels;
         AV104Operacoestituloswwds_27_tfoperacoestituloscreatedat = AV54TFOperacoesTitulosCreatedAt;
         AV105Operacoestituloswwds_28_tfoperacoestituloscreatedat_to = AV55TFOperacoesTitulosCreatedAt_To;
         AV106Operacoestituloswwds_29_tfoperacoestitulosupdatedat = AV59TFOperacoesTitulosUpdatedAt;
         AV107Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to = AV60TFOperacoesTitulosUpdatedAt_To;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29ManageFiltersData", AV29ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E12A42( )
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
            AV65PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV65PageToGo) ;
         }
      }

      protected void E13A42( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14A42( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV14OrderedDsc", AV14OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SacadoRazaoSocial") == 0 )
            {
               AV75TFSacadoRazaoSocial = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV75TFSacadoRazaoSocial", AV75TFSacadoRazaoSocial);
               AV76TFSacadoRazaoSocial_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV76TFSacadoRazaoSocial_Sel", AV76TFSacadoRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacoesTitulosTipo") == 0 )
            {
               AV32TFOperacoesTitulosTipo_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV32TFOperacoesTitulosTipo_SelsJson", AV32TFOperacoesTitulosTipo_SelsJson);
               AV33TFOperacoesTitulosTipo_Sels.FromJSonString(AV32TFOperacoesTitulosTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacoesTitulosNumero") == 0 )
            {
               AV34TFOperacoesTitulosNumero = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV34TFOperacoesTitulosNumero", StringUtil.LTrimStr( (decimal)(AV34TFOperacoesTitulosNumero), 9, 0));
               AV35TFOperacoesTitulosNumero_To = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV35TFOperacoesTitulosNumero_To", StringUtil.LTrimStr( (decimal)(AV35TFOperacoesTitulosNumero_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacoesTitulosDataEmissao") == 0 )
            {
               AV36TFOperacoesTitulosDataEmissao = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 4);
               AssignAttri(sPrefix, false, "AV36TFOperacoesTitulosDataEmissao", context.localUtil.Format(AV36TFOperacoesTitulosDataEmissao, "99/99/99"));
               AV37TFOperacoesTitulosDataEmissao_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri(sPrefix, false, "AV37TFOperacoesTitulosDataEmissao_To", context.localUtil.Format(AV37TFOperacoesTitulosDataEmissao_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacoesTitulosDataVencimento") == 0 )
            {
               AV41TFOperacoesTitulosDataVencimento = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 4);
               AssignAttri(sPrefix, false, "AV41TFOperacoesTitulosDataVencimento", context.localUtil.Format(AV41TFOperacoesTitulosDataVencimento, "99/99/99"));
               AV42TFOperacoesTitulosDataVencimento_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri(sPrefix, false, "AV42TFOperacoesTitulosDataVencimento_To", context.localUtil.Format(AV42TFOperacoesTitulosDataVencimento_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacoesTitulosValor") == 0 )
            {
               AV46TFOperacoesTitulosValor = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV46TFOperacoesTitulosValor", StringUtil.LTrimStr( AV46TFOperacoesTitulosValor, 18, 2));
               AV47TFOperacoesTitulosValor_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV47TFOperacoesTitulosValor_To", StringUtil.LTrimStr( AV47TFOperacoesTitulosValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacoesTitulosLiquido") == 0 )
            {
               AV48TFOperacoesTitulosLiquido = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV48TFOperacoesTitulosLiquido", StringUtil.LTrimStr( AV48TFOperacoesTitulosLiquido, 18, 2));
               AV49TFOperacoesTitulosLiquido_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV49TFOperacoesTitulosLiquido_To", StringUtil.LTrimStr( AV49TFOperacoesTitulosLiquido_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacoesTitulosTaxa") == 0 )
            {
               AV50TFOperacoesTitulosTaxa = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV50TFOperacoesTitulosTaxa", StringUtil.LTrimStr( AV50TFOperacoesTitulosTaxa, 16, 4));
               AV51TFOperacoesTitulosTaxa_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV51TFOperacoesTitulosTaxa_To", StringUtil.LTrimStr( AV51TFOperacoesTitulosTaxa_To, 16, 4));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacoesTitulosStatus") == 0 )
            {
               AV52TFOperacoesTitulosStatus_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV52TFOperacoesTitulosStatus_SelsJson", AV52TFOperacoesTitulosStatus_SelsJson);
               AV53TFOperacoesTitulosStatus_Sels.FromJSonString(AV52TFOperacoesTitulosStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacoesTitulosCreatedAt") == 0 )
            {
               AV54TFOperacoesTitulosCreatedAt = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri(sPrefix, false, "AV54TFOperacoesTitulosCreatedAt", context.localUtil.TToC( AV54TFOperacoesTitulosCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV55TFOperacoesTitulosCreatedAt_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri(sPrefix, false, "AV55TFOperacoesTitulosCreatedAt_To", context.localUtil.TToC( AV55TFOperacoesTitulosCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV55TFOperacoesTitulosCreatedAt_To) )
               {
                  AV55TFOperacoesTitulosCreatedAt_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV55TFOperacoesTitulosCreatedAt_To)), (short)(DateTimeUtil.Month( AV55TFOperacoesTitulosCreatedAt_To)), (short)(DateTimeUtil.Day( AV55TFOperacoesTitulosCreatedAt_To)), 23, 59, 59);
                  AssignAttri(sPrefix, false, "AV55TFOperacoesTitulosCreatedAt_To", context.localUtil.TToC( AV55TFOperacoesTitulosCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacoesTitulosUpdatedAt") == 0 )
            {
               AV59TFOperacoesTitulosUpdatedAt = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri(sPrefix, false, "AV59TFOperacoesTitulosUpdatedAt", context.localUtil.TToC( AV59TFOperacoesTitulosUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV60TFOperacoesTitulosUpdatedAt_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri(sPrefix, false, "AV60TFOperacoesTitulosUpdatedAt_To", context.localUtil.TToC( AV60TFOperacoesTitulosUpdatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV60TFOperacoesTitulosUpdatedAt_To) )
               {
                  AV60TFOperacoesTitulosUpdatedAt_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV60TFOperacoesTitulosUpdatedAt_To)), (short)(DateTimeUtil.Month( AV60TFOperacoesTitulosUpdatedAt_To)), (short)(DateTimeUtil.Day( AV60TFOperacoesTitulosUpdatedAt_To)), 23, 59, 59);
                  AssignAttri(sPrefix, false, "AV60TFOperacoesTitulosUpdatedAt_To", context.localUtil.TToC( AV60TFOperacoesTitulosUpdatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV53TFOperacoesTitulosStatus_Sels", AV53TFOperacoesTitulosStatus_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV33TFOperacoesTitulosTipo_Sels", AV33TFOperacoesTitulosTipo_Sels);
      }

      private void E27A42( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV69Display = "<i class=\"fa fa-search\"></i>";
         AssignAttri(sPrefix, false, edtavDisplay_Internalname, AV69Display);
         AV70Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV70Update);
         if ( StringUtil.StrCmp(AV74TrnMode, "DSP") != 0 )
         {
            edtavUpdate_Class = "Attribute";
         }
         else
         {
            edtavUpdate_Class = "Invisible";
         }
         AV71Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri(sPrefix, false, edtavDelete_Internalname, AV71Delete);
         if ( StringUtil.StrCmp(AV74TrnMode, "DSP") != 0 )
         {
            edtavDelete_Class = "Attribute";
         }
         else
         {
            edtavDelete_Class = "Invisible";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 98;
         }
         sendrow_982( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_98_Refreshing )
         {
            DoAjaxLoad(98, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E20A42( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV18DynamicFiltersEnabled2 = true;
         AssignAttri(sPrefix, false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp(sPrefix, false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp(sPrefix, false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E15A42( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV24DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV24DynamicFiltersRemoving", AV24DynamicFiltersRemoving);
         AV25DynamicFiltersIgnoreFirst = true;
         AssignAttri(sPrefix, false, "AV25DynamicFiltersIgnoreFirst", AV25DynamicFiltersIgnoreFirst);
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
         AV24DynamicFiltersRemoving = false;
         AssignAttri(sPrefix, false, "AV24DynamicFiltersRemoving", AV24DynamicFiltersRemoving);
         AV25DynamicFiltersIgnoreFirst = false;
         AssignAttri(sPrefix, false, "AV25DynamicFiltersIgnoreFirst", AV25DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17OperacoesTitulosTipo1, AV19DynamicFiltersSelector2, AV20OperacoesTitulosTipo2, AV22DynamicFiltersSelector3, AV23OperacoesTitulosTipo3, AV31ManageFiltersExecutionStep, AV77Pgmname, AV73OperacoesId, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3, AV75TFSacadoRazaoSocial, AV76TFSacadoRazaoSocial_Sel, AV33TFOperacoesTitulosTipo_Sels, AV34TFOperacoesTitulosNumero, AV35TFOperacoesTitulosNumero_To, AV36TFOperacoesTitulosDataEmissao, AV37TFOperacoesTitulosDataEmissao_To, AV41TFOperacoesTitulosDataVencimento, AV42TFOperacoesTitulosDataVencimento_To, AV46TFOperacoesTitulosValor, AV47TFOperacoesTitulosValor_To, AV48TFOperacoesTitulosLiquido, AV49TFOperacoesTitulosLiquido_To, AV50TFOperacoesTitulosTaxa, AV51TFOperacoesTitulosTaxa_To, AV53TFOperacoesTitulosStatus_Sels, AV54TFOperacoesTitulosCreatedAt, AV55TFOperacoesTitulosCreatedAt_To, AV59TFOperacoesTitulosUpdatedAt, AV60TFOperacoesTitulosUpdatedAt_To, AV74TrnMode, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavOperacoestitulostipo2.CurrentValue = StringUtil.RTrim( AV20OperacoesTitulosTipo2);
         AssignProp(sPrefix, false, cmbavOperacoestitulostipo2_Internalname, "Values", cmbavOperacoestitulostipo2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavOperacoestitulostipo3.CurrentValue = StringUtil.RTrim( AV23OperacoesTitulosTipo3);
         AssignProp(sPrefix, false, cmbavOperacoestitulostipo3_Internalname, "Values", cmbavOperacoestitulostipo3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavOperacoestitulostipo1.CurrentValue = StringUtil.RTrim( AV17OperacoesTitulosTipo1);
         AssignProp(sPrefix, false, cmbavOperacoestitulostipo1_Internalname, "Values", cmbavOperacoestitulostipo1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29ManageFiltersData", AV29ManageFiltersData);
      }

      protected void E21A42( )
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

      protected void E22A42( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV21DynamicFiltersEnabled3 = true;
         AssignAttri(sPrefix, false, "AV21DynamicFiltersEnabled3", AV21DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E16A42( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV24DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV24DynamicFiltersRemoving", AV24DynamicFiltersRemoving);
         AV18DynamicFiltersEnabled2 = false;
         AssignAttri(sPrefix, false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
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
         AV24DynamicFiltersRemoving = false;
         AssignAttri(sPrefix, false, "AV24DynamicFiltersRemoving", AV24DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17OperacoesTitulosTipo1, AV19DynamicFiltersSelector2, AV20OperacoesTitulosTipo2, AV22DynamicFiltersSelector3, AV23OperacoesTitulosTipo3, AV31ManageFiltersExecutionStep, AV77Pgmname, AV73OperacoesId, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3, AV75TFSacadoRazaoSocial, AV76TFSacadoRazaoSocial_Sel, AV33TFOperacoesTitulosTipo_Sels, AV34TFOperacoesTitulosNumero, AV35TFOperacoesTitulosNumero_To, AV36TFOperacoesTitulosDataEmissao, AV37TFOperacoesTitulosDataEmissao_To, AV41TFOperacoesTitulosDataVencimento, AV42TFOperacoesTitulosDataVencimento_To, AV46TFOperacoesTitulosValor, AV47TFOperacoesTitulosValor_To, AV48TFOperacoesTitulosLiquido, AV49TFOperacoesTitulosLiquido_To, AV50TFOperacoesTitulosTaxa, AV51TFOperacoesTitulosTaxa_To, AV53TFOperacoesTitulosStatus_Sels, AV54TFOperacoesTitulosCreatedAt, AV55TFOperacoesTitulosCreatedAt_To, AV59TFOperacoesTitulosUpdatedAt, AV60TFOperacoesTitulosUpdatedAt_To, AV74TrnMode, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavOperacoestitulostipo2.CurrentValue = StringUtil.RTrim( AV20OperacoesTitulosTipo2);
         AssignProp(sPrefix, false, cmbavOperacoestitulostipo2_Internalname, "Values", cmbavOperacoestitulostipo2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavOperacoestitulostipo3.CurrentValue = StringUtil.RTrim( AV23OperacoesTitulosTipo3);
         AssignProp(sPrefix, false, cmbavOperacoestitulostipo3_Internalname, "Values", cmbavOperacoestitulostipo3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavOperacoestitulostipo1.CurrentValue = StringUtil.RTrim( AV17OperacoesTitulosTipo1);
         AssignProp(sPrefix, false, cmbavOperacoestitulostipo1_Internalname, "Values", cmbavOperacoestitulostipo1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29ManageFiltersData", AV29ManageFiltersData);
      }

      protected void E23A42( )
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

      protected void E17A42( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV24DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV24DynamicFiltersRemoving", AV24DynamicFiltersRemoving);
         AV21DynamicFiltersEnabled3 = false;
         AssignAttri(sPrefix, false, "AV21DynamicFiltersEnabled3", AV21DynamicFiltersEnabled3);
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
         AV24DynamicFiltersRemoving = false;
         AssignAttri(sPrefix, false, "AV24DynamicFiltersRemoving", AV24DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17OperacoesTitulosTipo1, AV19DynamicFiltersSelector2, AV20OperacoesTitulosTipo2, AV22DynamicFiltersSelector3, AV23OperacoesTitulosTipo3, AV31ManageFiltersExecutionStep, AV77Pgmname, AV73OperacoesId, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3, AV75TFSacadoRazaoSocial, AV76TFSacadoRazaoSocial_Sel, AV33TFOperacoesTitulosTipo_Sels, AV34TFOperacoesTitulosNumero, AV35TFOperacoesTitulosNumero_To, AV36TFOperacoesTitulosDataEmissao, AV37TFOperacoesTitulosDataEmissao_To, AV41TFOperacoesTitulosDataVencimento, AV42TFOperacoesTitulosDataVencimento_To, AV46TFOperacoesTitulosValor, AV47TFOperacoesTitulosValor_To, AV48TFOperacoesTitulosLiquido, AV49TFOperacoesTitulosLiquido_To, AV50TFOperacoesTitulosTaxa, AV51TFOperacoesTitulosTaxa_To, AV53TFOperacoesTitulosStatus_Sels, AV54TFOperacoesTitulosCreatedAt, AV55TFOperacoesTitulosCreatedAt_To, AV59TFOperacoesTitulosUpdatedAt, AV60TFOperacoesTitulosUpdatedAt_To, AV74TrnMode, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavOperacoestitulostipo2.CurrentValue = StringUtil.RTrim( AV20OperacoesTitulosTipo2);
         AssignProp(sPrefix, false, cmbavOperacoestitulostipo2_Internalname, "Values", cmbavOperacoestitulostipo2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavOperacoestitulostipo3.CurrentValue = StringUtil.RTrim( AV23OperacoesTitulosTipo3);
         AssignProp(sPrefix, false, cmbavOperacoestitulostipo3_Internalname, "Values", cmbavOperacoestitulostipo3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavOperacoestitulostipo1.CurrentValue = StringUtil.RTrim( AV17OperacoesTitulosTipo1);
         AssignProp(sPrefix, false, cmbavOperacoestitulostipo1_Internalname, "Values", cmbavOperacoestitulostipo1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29ManageFiltersData", AV29ManageFiltersData);
      }

      protected void E24A42( )
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

      protected void E11A42( )
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("OperacoesTitulosWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV77Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV31ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV31ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV31ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("OperacoesTitulosWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV31ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV31ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV31ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char2 = AV30ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "OperacoesTitulosWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV30ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV77Pgmname+"GridState",  AV30ManageFiltersXml) ;
               AV10GridState.FromXml(AV30ManageFiltersXml, null, "", "");
               AV13OrderedBy = AV10GridState.gxTpr_Orderedby;
               AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
               AssignAttri(sPrefix, false, "AV14OrderedDsc", AV14OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV33TFOperacoesTitulosTipo_Sels", AV33TFOperacoesTitulosTipo_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV53TFOperacoesTitulosStatus_Sels", AV53TFOperacoesTitulosStatus_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavOperacoestitulostipo1.CurrentValue = StringUtil.RTrim( AV17OperacoesTitulosTipo1);
         AssignProp(sPrefix, false, cmbavOperacoestitulostipo1_Internalname, "Values", cmbavOperacoestitulostipo1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavOperacoestitulostipo2.CurrentValue = StringUtil.RTrim( AV20OperacoesTitulosTipo2);
         AssignProp(sPrefix, false, cmbavOperacoestitulostipo2_Internalname, "Values", cmbavOperacoestitulostipo2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavOperacoestitulostipo3.CurrentValue = StringUtil.RTrim( AV23OperacoesTitulosTipo3);
         AssignProp(sPrefix, false, cmbavOperacoestitulostipo3_Internalname, "Values", cmbavOperacoestitulostipo3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29ManageFiltersData", AV29ManageFiltersData);
      }

      protected void E28A42( )
      {
         /* Display_Click Routine */
         returnInSub = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "operacoestitulos"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A1019OperacoesTitulosId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV73OperacoesId,9,0));
         context.PopUp(formatLink("operacoestitulos") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29ManageFiltersData", AV29ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E29A42( )
      {
         /* Update_Click Routine */
         returnInSub = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "operacoestitulos"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A1019OperacoesTitulosId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV73OperacoesId,9,0));
         context.PopUp(formatLink("operacoestitulos") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29ManageFiltersData", AV29ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E30A42( )
      {
         /* Delete_Click Routine */
         returnInSub = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "operacoestitulos"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A1019OperacoesTitulosId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV73OperacoesId,9,0));
         context.PopUp(formatLink("operacoestitulos") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29ManageFiltersData", AV29ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E18A42( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "operacoestitulos"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV73OperacoesId,9,0));
         context.PopUp(formatLink("operacoestitulos") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29ManageFiltersData", AV29ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E19A42( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         new operacoestituloswwexport(context ).execute( out  AV26ExcelFilename, out  AV27ErrorMessage) ;
         if ( StringUtil.StrCmp(AV26ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV26ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV27ErrorMessage);
         }
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S182( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV74TrnMode, "DSP") != 0 ) ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp(sPrefix, false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         cmbavOperacoestitulostipo1.Visible = 0;
         AssignProp(sPrefix, false, cmbavOperacoestitulostipo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavOperacoestitulostipo1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "OPERACOESTITULOSTIPO") == 0 )
         {
            cmbavOperacoestitulostipo1.Visible = 1;
            AssignProp(sPrefix, false, cmbavOperacoestitulostipo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavOperacoestitulostipo1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         cmbavOperacoestitulostipo2.Visible = 0;
         AssignProp(sPrefix, false, cmbavOperacoestitulostipo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavOperacoestitulostipo2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "OPERACOESTITULOSTIPO") == 0 )
         {
            cmbavOperacoestitulostipo2.Visible = 1;
            AssignProp(sPrefix, false, cmbavOperacoestitulostipo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavOperacoestitulostipo2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         cmbavOperacoestitulostipo3.Visible = 0;
         AssignProp(sPrefix, false, cmbavOperacoestitulostipo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavOperacoestitulostipo3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "OPERACOESTITULOSTIPO") == 0 )
         {
            cmbavOperacoestitulostipo3.Visible = 1;
            AssignProp(sPrefix, false, cmbavOperacoestitulostipo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavOperacoestitulostipo3.Visible), 5, 0), true);
         }
      }

      protected void S212( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV18DynamicFiltersEnabled2 = false;
         AssignAttri(sPrefix, false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
         AV19DynamicFiltersSelector2 = "OPERACOESTITULOSTIPO";
         AssignAttri(sPrefix, false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         AV20OperacoesTitulosTipo2 = "";
         AssignAttri(sPrefix, false, "AV20OperacoesTitulosTipo2", AV20OperacoesTitulosTipo2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV21DynamicFiltersEnabled3 = false;
         AssignAttri(sPrefix, false, "AV21DynamicFiltersEnabled3", AV21DynamicFiltersEnabled3);
         AV22DynamicFiltersSelector3 = "OPERACOESTITULOSTIPO";
         AssignAttri(sPrefix, false, "AV22DynamicFiltersSelector3", AV22DynamicFiltersSelector3);
         AV23OperacoesTitulosTipo3 = "";
         AssignAttri(sPrefix, false, "AV23OperacoesTitulosTipo3", AV23OperacoesTitulosTipo3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV29ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "OperacoesTitulosWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV29ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S232( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
         AV75TFSacadoRazaoSocial = "";
         AssignAttri(sPrefix, false, "AV75TFSacadoRazaoSocial", AV75TFSacadoRazaoSocial);
         AV76TFSacadoRazaoSocial_Sel = "";
         AssignAttri(sPrefix, false, "AV76TFSacadoRazaoSocial_Sel", AV76TFSacadoRazaoSocial_Sel);
         AV33TFOperacoesTitulosTipo_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34TFOperacoesTitulosNumero = 0;
         AssignAttri(sPrefix, false, "AV34TFOperacoesTitulosNumero", StringUtil.LTrimStr( (decimal)(AV34TFOperacoesTitulosNumero), 9, 0));
         AV35TFOperacoesTitulosNumero_To = 0;
         AssignAttri(sPrefix, false, "AV35TFOperacoesTitulosNumero_To", StringUtil.LTrimStr( (decimal)(AV35TFOperacoesTitulosNumero_To), 9, 0));
         AV36TFOperacoesTitulosDataEmissao = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV36TFOperacoesTitulosDataEmissao", context.localUtil.Format(AV36TFOperacoesTitulosDataEmissao, "99/99/99"));
         AV37TFOperacoesTitulosDataEmissao_To = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV37TFOperacoesTitulosDataEmissao_To", context.localUtil.Format(AV37TFOperacoesTitulosDataEmissao_To, "99/99/99"));
         AV41TFOperacoesTitulosDataVencimento = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV41TFOperacoesTitulosDataVencimento", context.localUtil.Format(AV41TFOperacoesTitulosDataVencimento, "99/99/99"));
         AV42TFOperacoesTitulosDataVencimento_To = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV42TFOperacoesTitulosDataVencimento_To", context.localUtil.Format(AV42TFOperacoesTitulosDataVencimento_To, "99/99/99"));
         AV46TFOperacoesTitulosValor = 0;
         AssignAttri(sPrefix, false, "AV46TFOperacoesTitulosValor", StringUtil.LTrimStr( AV46TFOperacoesTitulosValor, 18, 2));
         AV47TFOperacoesTitulosValor_To = 0;
         AssignAttri(sPrefix, false, "AV47TFOperacoesTitulosValor_To", StringUtil.LTrimStr( AV47TFOperacoesTitulosValor_To, 18, 2));
         AV48TFOperacoesTitulosLiquido = 0;
         AssignAttri(sPrefix, false, "AV48TFOperacoesTitulosLiquido", StringUtil.LTrimStr( AV48TFOperacoesTitulosLiquido, 18, 2));
         AV49TFOperacoesTitulosLiquido_To = 0;
         AssignAttri(sPrefix, false, "AV49TFOperacoesTitulosLiquido_To", StringUtil.LTrimStr( AV49TFOperacoesTitulosLiquido_To, 18, 2));
         AV50TFOperacoesTitulosTaxa = 0;
         AssignAttri(sPrefix, false, "AV50TFOperacoesTitulosTaxa", StringUtil.LTrimStr( AV50TFOperacoesTitulosTaxa, 16, 4));
         AV51TFOperacoesTitulosTaxa_To = 0;
         AssignAttri(sPrefix, false, "AV51TFOperacoesTitulosTaxa_To", StringUtil.LTrimStr( AV51TFOperacoesTitulosTaxa_To, 16, 4));
         AV53TFOperacoesTitulosStatus_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV54TFOperacoesTitulosCreatedAt = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV54TFOperacoesTitulosCreatedAt", context.localUtil.TToC( AV54TFOperacoesTitulosCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         AV55TFOperacoesTitulosCreatedAt_To = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV55TFOperacoesTitulosCreatedAt_To", context.localUtil.TToC( AV55TFOperacoesTitulosCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
         AV59TFOperacoesTitulosUpdatedAt = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV59TFOperacoesTitulosUpdatedAt", context.localUtil.TToC( AV59TFOperacoesTitulosUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         AV60TFOperacoesTitulosUpdatedAt_To = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV60TFOperacoesTitulosUpdatedAt_To", context.localUtil.TToC( AV60TFOperacoesTitulosUpdatedAt_To, 8, 5, 0, 3, "/", ":", " "));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV16DynamicFiltersSelector1 = "OPERACOESTITULOSTIPO";
         AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV17OperacoesTitulosTipo1 = "";
         AssignAttri(sPrefix, false, "AV17OperacoesTitulosTipo1", AV17OperacoesTitulosTipo1);
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

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28Session.Get(AV77Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV77Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV28Session.Get(AV77Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV14OrderedDsc", AV14OrderedDsc);
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
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S242( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV108GXV1 = 1;
         while ( AV108GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV108GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSACADORAZAOSOCIAL") == 0 )
            {
               AV75TFSacadoRazaoSocial = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV75TFSacadoRazaoSocial", AV75TFSacadoRazaoSocial);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSACADORAZAOSOCIAL_SEL") == 0 )
            {
               AV76TFSacadoRazaoSocial_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV76TFSacadoRazaoSocial_Sel", AV76TFSacadoRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSTIPO_SEL") == 0 )
            {
               AV32TFOperacoesTitulosTipo_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV32TFOperacoesTitulosTipo_SelsJson", AV32TFOperacoesTitulosTipo_SelsJson);
               AV33TFOperacoesTitulosTipo_Sels.FromJSonString(AV32TFOperacoesTitulosTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSNUMERO") == 0 )
            {
               AV34TFOperacoesTitulosNumero = (int)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV34TFOperacoesTitulosNumero", StringUtil.LTrimStr( (decimal)(AV34TFOperacoesTitulosNumero), 9, 0));
               AV35TFOperacoesTitulosNumero_To = (int)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV35TFOperacoesTitulosNumero_To", StringUtil.LTrimStr( (decimal)(AV35TFOperacoesTitulosNumero_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSDATAEMISSAO") == 0 )
            {
               AV36TFOperacoesTitulosDataEmissao = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri(sPrefix, false, "AV36TFOperacoesTitulosDataEmissao", context.localUtil.Format(AV36TFOperacoesTitulosDataEmissao, "99/99/99"));
               AV37TFOperacoesTitulosDataEmissao_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri(sPrefix, false, "AV37TFOperacoesTitulosDataEmissao_To", context.localUtil.Format(AV37TFOperacoesTitulosDataEmissao_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSDATAVENCIMENTO") == 0 )
            {
               AV41TFOperacoesTitulosDataVencimento = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri(sPrefix, false, "AV41TFOperacoesTitulosDataVencimento", context.localUtil.Format(AV41TFOperacoesTitulosDataVencimento, "99/99/99"));
               AV42TFOperacoesTitulosDataVencimento_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri(sPrefix, false, "AV42TFOperacoesTitulosDataVencimento_To", context.localUtil.Format(AV42TFOperacoesTitulosDataVencimento_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSVALOR") == 0 )
            {
               AV46TFOperacoesTitulosValor = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV46TFOperacoesTitulosValor", StringUtil.LTrimStr( AV46TFOperacoesTitulosValor, 18, 2));
               AV47TFOperacoesTitulosValor_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV47TFOperacoesTitulosValor_To", StringUtil.LTrimStr( AV47TFOperacoesTitulosValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSLIQUIDO") == 0 )
            {
               AV48TFOperacoesTitulosLiquido = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV48TFOperacoesTitulosLiquido", StringUtil.LTrimStr( AV48TFOperacoesTitulosLiquido, 18, 2));
               AV49TFOperacoesTitulosLiquido_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV49TFOperacoesTitulosLiquido_To", StringUtil.LTrimStr( AV49TFOperacoesTitulosLiquido_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSTAXA") == 0 )
            {
               AV50TFOperacoesTitulosTaxa = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV50TFOperacoesTitulosTaxa", StringUtil.LTrimStr( AV50TFOperacoesTitulosTaxa, 16, 4));
               AV51TFOperacoesTitulosTaxa_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV51TFOperacoesTitulosTaxa_To", StringUtil.LTrimStr( AV51TFOperacoesTitulosTaxa_To, 16, 4));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSSTATUS_SEL") == 0 )
            {
               AV52TFOperacoesTitulosStatus_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV52TFOperacoesTitulosStatus_SelsJson", AV52TFOperacoesTitulosStatus_SelsJson);
               AV53TFOperacoesTitulosStatus_Sels.FromJSonString(AV52TFOperacoesTitulosStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSCREATEDAT") == 0 )
            {
               AV54TFOperacoesTitulosCreatedAt = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri(sPrefix, false, "AV54TFOperacoesTitulosCreatedAt", context.localUtil.TToC( AV54TFOperacoesTitulosCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV55TFOperacoesTitulosCreatedAt_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri(sPrefix, false, "AV55TFOperacoesTitulosCreatedAt_To", context.localUtil.TToC( AV55TFOperacoesTitulosCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               AV56DDO_OperacoesTitulosCreatedAtAuxDate = DateTimeUtil.ResetTime(AV54TFOperacoesTitulosCreatedAt);
               AssignAttri(sPrefix, false, "AV56DDO_OperacoesTitulosCreatedAtAuxDate", context.localUtil.Format(AV56DDO_OperacoesTitulosCreatedAtAuxDate, "99/99/99"));
               AV57DDO_OperacoesTitulosCreatedAtAuxDateTo = DateTimeUtil.ResetTime(AV55TFOperacoesTitulosCreatedAt_To);
               AssignAttri(sPrefix, false, "AV57DDO_OperacoesTitulosCreatedAtAuxDateTo", context.localUtil.Format(AV57DDO_OperacoesTitulosCreatedAtAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSUPDATEDAT") == 0 )
            {
               AV59TFOperacoesTitulosUpdatedAt = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri(sPrefix, false, "AV59TFOperacoesTitulosUpdatedAt", context.localUtil.TToC( AV59TFOperacoesTitulosUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV60TFOperacoesTitulosUpdatedAt_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri(sPrefix, false, "AV60TFOperacoesTitulosUpdatedAt_To", context.localUtil.TToC( AV60TFOperacoesTitulosUpdatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               AV61DDO_OperacoesTitulosUpdatedAtAuxDate = DateTimeUtil.ResetTime(AV59TFOperacoesTitulosUpdatedAt);
               AssignAttri(sPrefix, false, "AV61DDO_OperacoesTitulosUpdatedAtAuxDate", context.localUtil.Format(AV61DDO_OperacoesTitulosUpdatedAtAuxDate, "99/99/99"));
               AV62DDO_OperacoesTitulosUpdatedAtAuxDateTo = DateTimeUtil.ResetTime(AV60TFOperacoesTitulosUpdatedAt_To);
               AssignAttri(sPrefix, false, "AV62DDO_OperacoesTitulosUpdatedAtAuxDateTo", context.localUtil.Format(AV62DDO_OperacoesTitulosUpdatedAtAuxDateTo, "99/99/99"));
            }
            AV108GXV1 = (int)(AV108GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV76TFSacadoRazaoSocial_Sel)),  AV76TFSacadoRazaoSocial_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV33TFOperacoesTitulosTipo_Sels.Count==0),  AV32TFOperacoesTitulosTipo_SelsJson, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV53TFOperacoesTitulosStatus_Sels.Count==0),  AV52TFOperacoesTitulosStatus_SelsJson, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|||||||"+GXt_char5+"||";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV75TFSacadoRazaoSocial)),  AV75TFSacadoRazaoSocial, out  GXt_char5) ;
         Ddo_grid_Filteredtext_set = GXt_char5+"||"+((0==AV34TFOperacoesTitulosNumero) ? "" : StringUtil.Str( (decimal)(AV34TFOperacoesTitulosNumero), 9, 0))+"|"+((DateTime.MinValue==AV36TFOperacoesTitulosDataEmissao) ? "" : context.localUtil.DToC( AV36TFOperacoesTitulosDataEmissao, 4, "/"))+"|"+((DateTime.MinValue==AV41TFOperacoesTitulosDataVencimento) ? "" : context.localUtil.DToC( AV41TFOperacoesTitulosDataVencimento, 4, "/"))+"|"+((Convert.ToDecimal(0)==AV46TFOperacoesTitulosValor) ? "" : StringUtil.Str( AV46TFOperacoesTitulosValor, 18, 2))+"|"+((Convert.ToDecimal(0)==AV48TFOperacoesTitulosLiquido) ? "" : StringUtil.Str( AV48TFOperacoesTitulosLiquido, 18, 2))+"|"+((Convert.ToDecimal(0)==AV50TFOperacoesTitulosTaxa) ? "" : StringUtil.Str( AV50TFOperacoesTitulosTaxa, 16, 4))+"||"+((DateTime.MinValue==AV54TFOperacoesTitulosCreatedAt) ? "" : context.localUtil.DToC( AV56DDO_OperacoesTitulosCreatedAtAuxDate, 4, "/"))+"|"+((DateTime.MinValue==AV59TFOperacoesTitulosUpdatedAt) ? "" : context.localUtil.DToC( AV61DDO_OperacoesTitulosUpdatedAtAuxDate, 4, "/"));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((0==AV35TFOperacoesTitulosNumero_To) ? "" : StringUtil.Str( (decimal)(AV35TFOperacoesTitulosNumero_To), 9, 0))+"|"+((DateTime.MinValue==AV37TFOperacoesTitulosDataEmissao_To) ? "" : context.localUtil.DToC( AV37TFOperacoesTitulosDataEmissao_To, 4, "/"))+"|"+((DateTime.MinValue==AV42TFOperacoesTitulosDataVencimento_To) ? "" : context.localUtil.DToC( AV42TFOperacoesTitulosDataVencimento_To, 4, "/"))+"|"+((Convert.ToDecimal(0)==AV47TFOperacoesTitulosValor_To) ? "" : StringUtil.Str( AV47TFOperacoesTitulosValor_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV49TFOperacoesTitulosLiquido_To) ? "" : StringUtil.Str( AV49TFOperacoesTitulosLiquido_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV51TFOperacoesTitulosTaxa_To) ? "" : StringUtil.Str( AV51TFOperacoesTitulosTaxa_To, 16, 4))+"||"+((DateTime.MinValue==AV55TFOperacoesTitulosCreatedAt_To) ? "" : context.localUtil.DToC( AV57DDO_OperacoesTitulosCreatedAtAuxDateTo, 4, "/"))+"|"+((DateTime.MinValue==AV60TFOperacoesTitulosUpdatedAt_To) ? "" : context.localUtil.DToC( AV62DDO_OperacoesTitulosUpdatedAtAuxDateTo, 4, "/"));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S222( )
      {
         /* 'LOADDYNFILTERSSTATE' Routine */
         returnInSub = false;
         imgAdddynamicfilters1_Visible = 1;
         AssignProp(sPrefix, false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 0;
         AssignProp(sPrefix, false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         imgAdddynamicfilters2_Visible = 1;
         AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 0;
         AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(1));
            AV16DynamicFiltersSelector1 = AV12GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "OPERACOESTITULOSTIPO") == 0 )
            {
               AV17OperacoesTitulosTipo1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV17OperacoesTitulosTipo1", AV17OperacoesTitulosTipo1);
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
               AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               imgAdddynamicfilters1_Visible = 0;
               AssignProp(sPrefix, false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
               imgRemovedynamicfilters1_Visible = 1;
               AssignProp(sPrefix, false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
               AV18DynamicFiltersEnabled2 = true;
               AssignAttri(sPrefix, false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri(sPrefix, false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "OPERACOESTITULOSTIPO") == 0 )
               {
                  AV20OperacoesTitulosTipo2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri(sPrefix, false, "AV20OperacoesTitulosTipo2", AV20OperacoesTitulosTipo2);
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
                  AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV21DynamicFiltersEnabled3 = true;
                  AssignAttri(sPrefix, false, "AV21DynamicFiltersEnabled3", AV21DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV22DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri(sPrefix, false, "AV22DynamicFiltersSelector3", AV22DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "OPERACOESTITULOSTIPO") == 0 )
                  {
                     AV23OperacoesTitulosTipo3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri(sPrefix, false, "AV23OperacoesTitulosTipo3", AV23OperacoesTitulosTipo3);
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
               AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
            }
         }
         if ( AV24DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S192( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV28Session.Get(AV77Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSACADORAZAOSOCIAL",  "Sacado",  !String.IsNullOrEmpty(StringUtil.RTrim( AV75TFSacadoRazaoSocial)),  0,  AV75TFSacadoRazaoSocial,  AV75TFSacadoRazaoSocial,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV76TFSacadoRazaoSocial_Sel)),  AV76TFSacadoRazaoSocial_Sel,  AV76TFSacadoRazaoSocial_Sel) ;
         AV72AuxText = ((AV33TFOperacoesTitulosTipo_Sels.Count==1) ? "["+((string)AV33TFOperacoesTitulosTipo_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFOPERACOESTITULOSTIPO_SEL",  "Tipo",  !(AV33TFOperacoesTitulosTipo_Sels.Count==0),  0,  AV33TFOperacoesTitulosTipo_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV72AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( AV72AuxText, "[NOTA_FISCAL]", "Nota Fiscal"), "[RPA]", "RPA")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFOPERACOESTITULOSNUMERO",  "Número nota",  !((0==AV34TFOperacoesTitulosNumero)&&(0==AV35TFOperacoesTitulosNumero_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV34TFOperacoesTitulosNumero), 9, 0)),  ((0==AV34TFOperacoesTitulosNumero) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV34TFOperacoesTitulosNumero), "ZZZZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV35TFOperacoesTitulosNumero_To), 9, 0)),  ((0==AV35TFOperacoesTitulosNumero_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV35TFOperacoesTitulosNumero_To), "ZZZZZZZZ9")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFOPERACOESTITULOSDATAEMISSAO",  "Emissão",  !((DateTime.MinValue==AV36TFOperacoesTitulosDataEmissao)&&(DateTime.MinValue==AV37TFOperacoesTitulosDataEmissao_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV36TFOperacoesTitulosDataEmissao, 4, "/")),  ((DateTime.MinValue==AV36TFOperacoesTitulosDataEmissao) ? "" : StringUtil.Trim( context.localUtil.Format( AV36TFOperacoesTitulosDataEmissao, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV37TFOperacoesTitulosDataEmissao_To, 4, "/")),  ((DateTime.MinValue==AV37TFOperacoesTitulosDataEmissao_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV37TFOperacoesTitulosDataEmissao_To, "99/99/99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFOPERACOESTITULOSDATAVENCIMENTO",  "Vencimento",  !((DateTime.MinValue==AV41TFOperacoesTitulosDataVencimento)&&(DateTime.MinValue==AV42TFOperacoesTitulosDataVencimento_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV41TFOperacoesTitulosDataVencimento, 4, "/")),  ((DateTime.MinValue==AV41TFOperacoesTitulosDataVencimento) ? "" : StringUtil.Trim( context.localUtil.Format( AV41TFOperacoesTitulosDataVencimento, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV42TFOperacoesTitulosDataVencimento_To, 4, "/")),  ((DateTime.MinValue==AV42TFOperacoesTitulosDataVencimento_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV42TFOperacoesTitulosDataVencimento_To, "99/99/99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFOPERACOESTITULOSVALOR",  "Valor",  !((Convert.ToDecimal(0)==AV46TFOperacoesTitulosValor)&&(Convert.ToDecimal(0)==AV47TFOperacoesTitulosValor_To)),  0,  StringUtil.Trim( StringUtil.Str( AV46TFOperacoesTitulosValor, 18, 2)),  ((Convert.ToDecimal(0)==AV46TFOperacoesTitulosValor) ? "" : StringUtil.Trim( context.localUtil.Format( AV46TFOperacoesTitulosValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV47TFOperacoesTitulosValor_To, 18, 2)),  ((Convert.ToDecimal(0)==AV47TFOperacoesTitulosValor_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV47TFOperacoesTitulosValor_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFOPERACOESTITULOSLIQUIDO",  "Líquido",  !((Convert.ToDecimal(0)==AV48TFOperacoesTitulosLiquido)&&(Convert.ToDecimal(0)==AV49TFOperacoesTitulosLiquido_To)),  0,  StringUtil.Trim( StringUtil.Str( AV48TFOperacoesTitulosLiquido, 18, 2)),  ((Convert.ToDecimal(0)==AV48TFOperacoesTitulosLiquido) ? "" : StringUtil.Trim( context.localUtil.Format( AV48TFOperacoesTitulosLiquido, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV49TFOperacoesTitulosLiquido_To, 18, 2)),  ((Convert.ToDecimal(0)==AV49TFOperacoesTitulosLiquido_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV49TFOperacoesTitulosLiquido_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFOPERACOESTITULOSTAXA",  "Taxa",  !((Convert.ToDecimal(0)==AV50TFOperacoesTitulosTaxa)&&(Convert.ToDecimal(0)==AV51TFOperacoesTitulosTaxa_To)),  0,  StringUtil.Trim( StringUtil.Str( AV50TFOperacoesTitulosTaxa, 16, 4)),  ((Convert.ToDecimal(0)==AV50TFOperacoesTitulosTaxa) ? "" : StringUtil.Trim( context.localUtil.Format( AV50TFOperacoesTitulosTaxa, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"))),  true,  StringUtil.Trim( StringUtil.Str( AV51TFOperacoesTitulosTaxa_To, 16, 4)),  ((Convert.ToDecimal(0)==AV51TFOperacoesTitulosTaxa_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV51TFOperacoesTitulosTaxa_To, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))) ;
         AV72AuxText = ((AV53TFOperacoesTitulosStatus_Sels.Count==1) ? "["+((string)AV53TFOperacoesTitulosStatus_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFOPERACOESTITULOSSTATUS_SEL",  "Status",  !(AV53TFOperacoesTitulosStatus_Sels.Count==0),  0,  AV53TFOperacoesTitulosStatus_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV72AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV72AuxText, "[PENDENTE]", "Pendente"), "[ACEITO]", "Aceito"), "[RECUSADO]", "Recusado"), "[VENCIDO]", "Vencido"), "[LIQUIDADO]", "Liquidado")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFOPERACOESTITULOSCREATEDAT",  "Criado em",  !((DateTime.MinValue==AV54TFOperacoesTitulosCreatedAt)&&(DateTime.MinValue==AV55TFOperacoesTitulosCreatedAt_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV54TFOperacoesTitulosCreatedAt, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV54TFOperacoesTitulosCreatedAt) ? "" : StringUtil.Trim( context.localUtil.Format( AV54TFOperacoesTitulosCreatedAt, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV55TFOperacoesTitulosCreatedAt_To, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV55TFOperacoesTitulosCreatedAt_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV55TFOperacoesTitulosCreatedAt_To, "99/99/99 99:99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFOPERACOESTITULOSUPDATEDAT",  "Atualizado em",  !((DateTime.MinValue==AV59TFOperacoesTitulosUpdatedAt)&&(DateTime.MinValue==AV60TFOperacoesTitulosUpdatedAt_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV59TFOperacoesTitulosUpdatedAt, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV59TFOperacoesTitulosUpdatedAt) ? "" : StringUtil.Trim( context.localUtil.Format( AV59TFOperacoesTitulosUpdatedAt, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV60TFOperacoesTitulosUpdatedAt_To, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV60TFOperacoesTitulosUpdatedAt_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV60TFOperacoesTitulosUpdatedAt_To, "99/99/99 99:99")))) ;
         if ( ! (0==AV73OperacoesId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&OPERACOESID";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV73OperacoesId), 9, 0);
            AV10GridState.gxTpr_Filtervalues.Add(AV11GridStateFilterValue, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74TrnMode)) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&TRNMODE";
            AV11GridStateFilterValue.gxTpr_Value = AV74TrnMode;
            AV10GridState.gxTpr_Filtervalues.Add(AV11GridStateFilterValue, 0);
         }
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV77Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S202( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV25DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV16DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "OPERACOESTITULOSTIPO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17OperacoesTitulosTipo1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Tipo",  0,  AV17OperacoesTitulosTipo1,  StringUtil.Trim( gxdomaindmoperacoestipotitulo.getDescription(context,AV17OperacoesTitulosTipo1)),  false,  "",  "") ;
            }
            if ( AV24DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV18DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV19DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "OPERACOESTITULOSTIPO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV20OperacoesTitulosTipo2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Tipo",  0,  AV20OperacoesTitulosTipo2,  StringUtil.Trim( gxdomaindmoperacoestipotitulo.getDescription(context,AV20OperacoesTitulosTipo2)),  false,  "",  "") ;
            }
            if ( AV24DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV21DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV22DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "OPERACOESTITULOSTIPO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV23OperacoesTitulosTipo3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Tipo",  0,  AV23OperacoesTitulosTipo3,  StringUtil.Trim( gxdomaindmoperacoestipotitulo.getDescription(context,AV23OperacoesTitulosTipo3)),  false,  "",  "") ;
            }
            if ( AV24DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
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
         AV8TrnContext.gxTpr_Callerobject = AV77Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "OperacoesTitulos";
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "OperacoesId";
         AV9TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV73OperacoesId), 9, 0);
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV28Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_83_A42( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtabledynamicfilters_3_Internalname, tblUnnamedtabledynamicfilters_3_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_operacoestitulostipo3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavOperacoestitulostipo3_Internalname, "Operacoes Titulos Tipo3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOperacoestitulostipo3, cmbavOperacoestitulostipo3_Internalname, StringUtil.RTrim( AV23OperacoesTitulosTipo3), 1, cmbavOperacoestitulostipo3_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavOperacoestitulostipo3.Visible, cmbavOperacoestitulostipo3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "", true, 0, "HLP_OperacoesTitulosWW.htm");
            cmbavOperacoestitulostipo3.CurrentValue = StringUtil.RTrim( AV23OperacoesTitulosTipo3);
            AssignProp(sPrefix, false, cmbavOperacoestitulostipo3_Internalname, "Values", (string)(cmbavOperacoestitulostipo3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_OperacoesTitulosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_83_A42e( true) ;
         }
         else
         {
            wb_table3_83_A42e( false) ;
         }
      }

      protected void wb_table2_64_A42( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtabledynamicfilters_2_Internalname, tblUnnamedtabledynamicfilters_2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_operacoestitulostipo2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavOperacoestitulostipo2_Internalname, "Operacoes Titulos Tipo2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOperacoestitulostipo2, cmbavOperacoestitulostipo2_Internalname, StringUtil.RTrim( AV20OperacoesTitulosTipo2), 1, cmbavOperacoestitulostipo2_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavOperacoestitulostipo2.Visible, cmbavOperacoestitulostipo2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "", true, 0, "HLP_OperacoesTitulosWW.htm");
            cmbavOperacoestitulostipo2.CurrentValue = StringUtil.RTrim( AV20OperacoesTitulosTipo2);
            AssignProp(sPrefix, false, cmbavOperacoestitulostipo2_Internalname, "Values", (string)(cmbavOperacoestitulostipo2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_OperacoesTitulosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_OperacoesTitulosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_64_A42e( true) ;
         }
         else
         {
            wb_table2_64_A42e( false) ;
         }
      }

      protected void wb_table1_45_A42( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtabledynamicfilters_1_Internalname, tblUnnamedtabledynamicfilters_1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_operacoestitulostipo1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavOperacoestitulostipo1_Internalname, "Operacoes Titulos Tipo1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOperacoestitulostipo1, cmbavOperacoestitulostipo1_Internalname, StringUtil.RTrim( AV17OperacoesTitulosTipo1), 1, cmbavOperacoestitulostipo1_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavOperacoestitulostipo1.Visible, cmbavOperacoestitulostipo1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_OperacoesTitulosWW.htm");
            cmbavOperacoestitulostipo1.CurrentValue = StringUtil.RTrim( AV17OperacoesTitulosTipo1);
            AssignProp(sPrefix, false, cmbavOperacoestitulostipo1_Internalname, "Values", (string)(cmbavOperacoestitulostipo1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_OperacoesTitulosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_OperacoesTitulosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_45_A42e( true) ;
         }
         else
         {
            wb_table1_45_A42e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV73OperacoesId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV73OperacoesId", StringUtil.LTrimStr( (decimal)(AV73OperacoesId), 9, 0));
         AV74TrnMode = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV74TrnMode", AV74TrnMode);
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
         PAA42( ) ;
         WSA42( ) ;
         WEA42( ) ;
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
         sCtrlAV73OperacoesId = (string)((string)getParm(obj,0));
         sCtrlAV74TrnMode = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PAA42( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "operacoestitulosww", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PAA42( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV73OperacoesId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV73OperacoesId", StringUtil.LTrimStr( (decimal)(AV73OperacoesId), 9, 0));
            AV74TrnMode = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV74TrnMode", AV74TrnMode);
         }
         wcpOAV73OperacoesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV73OperacoesId"), ",", "."), 18, MidpointRounding.ToEven));
         wcpOAV74TrnMode = cgiGet( sPrefix+"wcpOAV74TrnMode");
         if ( ! GetJustCreated( ) && ( ( AV73OperacoesId != wcpOAV73OperacoesId ) || ( StringUtil.StrCmp(AV74TrnMode, wcpOAV74TrnMode) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV73OperacoesId = AV73OperacoesId;
         wcpOAV74TrnMode = AV74TrnMode;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV73OperacoesId = cgiGet( sPrefix+"AV73OperacoesId_CTRL");
         if ( StringUtil.Len( sCtrlAV73OperacoesId) > 0 )
         {
            AV73OperacoesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV73OperacoesId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV73OperacoesId", StringUtil.LTrimStr( (decimal)(AV73OperacoesId), 9, 0));
         }
         else
         {
            AV73OperacoesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV73OperacoesId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
         }
         sCtrlAV74TrnMode = cgiGet( sPrefix+"AV74TrnMode_CTRL");
         if ( StringUtil.Len( sCtrlAV74TrnMode) > 0 )
         {
            AV74TrnMode = cgiGet( sCtrlAV74TrnMode);
            AssignAttri(sPrefix, false, "AV74TrnMode", AV74TrnMode);
         }
         else
         {
            AV74TrnMode = cgiGet( sPrefix+"AV74TrnMode_PARM");
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
         PAA42( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSA42( ) ;
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
         WSA42( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV73OperacoesId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV73OperacoesId), 9, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV73OperacoesId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV73OperacoesId_CTRL", StringUtil.RTrim( sCtrlAV73OperacoesId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV74TrnMode_PARM", StringUtil.RTrim( AV74TrnMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV74TrnMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV74TrnMode_CTRL", StringUtil.RTrim( sCtrlAV74TrnMode));
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
         WEA42( ) ;
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
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019223547", true, true);
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
         context.AddJavascriptSource("operacoestitulosww.js", "?202561019223548", false, true);
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
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_982( )
      {
         edtavDisplay_Internalname = sPrefix+"vDISPLAY_"+sGXsfl_98_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_98_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_98_idx;
         edtSacadoRazaoSocial_Internalname = sPrefix+"SACADORAZAOSOCIAL_"+sGXsfl_98_idx;
         edtOperacoesTitulosId_Internalname = sPrefix+"OPERACOESTITULOSID_"+sGXsfl_98_idx;
         edtOperacoesId_Internalname = sPrefix+"OPERACOESID_"+sGXsfl_98_idx;
         cmbOperacoesTitulosTipo_Internalname = sPrefix+"OPERACOESTITULOSTIPO_"+sGXsfl_98_idx;
         edtOperacoesTitulosNumero_Internalname = sPrefix+"OPERACOESTITULOSNUMERO_"+sGXsfl_98_idx;
         edtOperacoesTitulosDataEmissao_Internalname = sPrefix+"OPERACOESTITULOSDATAEMISSAO_"+sGXsfl_98_idx;
         edtOperacoesTitulosDataVencimento_Internalname = sPrefix+"OPERACOESTITULOSDATAVENCIMENTO_"+sGXsfl_98_idx;
         edtOperacoesTitulosValor_Internalname = sPrefix+"OPERACOESTITULOSVALOR_"+sGXsfl_98_idx;
         edtOperacoesTitulosLiquido_Internalname = sPrefix+"OPERACOESTITULOSLIQUIDO_"+sGXsfl_98_idx;
         edtOperacoesTitulosTaxa_Internalname = sPrefix+"OPERACOESTITULOSTAXA_"+sGXsfl_98_idx;
         cmbOperacoesTitulosStatus_Internalname = sPrefix+"OPERACOESTITULOSSTATUS_"+sGXsfl_98_idx;
         edtOperacoesTitulosCreatedAt_Internalname = sPrefix+"OPERACOESTITULOSCREATEDAT_"+sGXsfl_98_idx;
         edtOperacoesTitulosUpdatedAt_Internalname = sPrefix+"OPERACOESTITULOSUPDATEDAT_"+sGXsfl_98_idx;
      }

      protected void SubsflControlProps_fel_982( )
      {
         edtavDisplay_Internalname = sPrefix+"vDISPLAY_"+sGXsfl_98_fel_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_98_fel_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_98_fel_idx;
         edtSacadoRazaoSocial_Internalname = sPrefix+"SACADORAZAOSOCIAL_"+sGXsfl_98_fel_idx;
         edtOperacoesTitulosId_Internalname = sPrefix+"OPERACOESTITULOSID_"+sGXsfl_98_fel_idx;
         edtOperacoesId_Internalname = sPrefix+"OPERACOESID_"+sGXsfl_98_fel_idx;
         cmbOperacoesTitulosTipo_Internalname = sPrefix+"OPERACOESTITULOSTIPO_"+sGXsfl_98_fel_idx;
         edtOperacoesTitulosNumero_Internalname = sPrefix+"OPERACOESTITULOSNUMERO_"+sGXsfl_98_fel_idx;
         edtOperacoesTitulosDataEmissao_Internalname = sPrefix+"OPERACOESTITULOSDATAEMISSAO_"+sGXsfl_98_fel_idx;
         edtOperacoesTitulosDataVencimento_Internalname = sPrefix+"OPERACOESTITULOSDATAVENCIMENTO_"+sGXsfl_98_fel_idx;
         edtOperacoesTitulosValor_Internalname = sPrefix+"OPERACOESTITULOSVALOR_"+sGXsfl_98_fel_idx;
         edtOperacoesTitulosLiquido_Internalname = sPrefix+"OPERACOESTITULOSLIQUIDO_"+sGXsfl_98_fel_idx;
         edtOperacoesTitulosTaxa_Internalname = sPrefix+"OPERACOESTITULOSTAXA_"+sGXsfl_98_fel_idx;
         cmbOperacoesTitulosStatus_Internalname = sPrefix+"OPERACOESTITULOSSTATUS_"+sGXsfl_98_fel_idx;
         edtOperacoesTitulosCreatedAt_Internalname = sPrefix+"OPERACOESTITULOSCREATEDAT_"+sGXsfl_98_fel_idx;
         edtOperacoesTitulosUpdatedAt_Internalname = sPrefix+"OPERACOESTITULOSUPDATEDAT_"+sGXsfl_98_fel_idx;
      }

      protected void sendrow_982( )
      {
         sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
         SubsflControlProps_982( ) ;
         WBA40( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_98_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_98_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_98_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',98)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV69Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDISPLAY.CLICK."+sGXsfl_98_idx+"'",(string)"",(string)"",(string)"Mostrar",(string)"",(string)edtavDisplay_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)98,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',98)\"";
            ROClassString = edtavUpdate_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV70Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVUPDATE.CLICK."+sGXsfl_98_idx+"'",(string)"",(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)5,(string)edtavUpdate_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)98,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',98)\"";
            ROClassString = edtavDelete_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV71Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDELETE.CLICK."+sGXsfl_98_idx+"'",(string)"",(string)"",(string)"Eliminar",(string)"",(string)edtavDelete_Jsonclick,(short)5,(string)edtavDelete_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)98,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSacadoRazaoSocial_Internalname,(string)A1035SacadoRazaoSocial,StringUtil.RTrim( context.localUtil.Format( A1035SacadoRazaoSocial, "@!")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSacadoRazaoSocial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacoesTitulosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1019OperacoesTitulosId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1019OperacoesTitulosId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacoesTitulosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacoesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1010OperacoesId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1010OperacoesId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacoesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbOperacoesTitulosTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "OPERACOESTITULOSTIPO_" + sGXsfl_98_idx;
               cmbOperacoesTitulosTipo.Name = GXCCtl;
               cmbOperacoesTitulosTipo.WebTags = "";
               cmbOperacoesTitulosTipo.addItem("", "NA", 0);
               cmbOperacoesTitulosTipo.addItem("NOTA_FISCAL", "Nota Fiscal", 0);
               cmbOperacoesTitulosTipo.addItem("RPA", "RPA", 0);
               if ( cmbOperacoesTitulosTipo.ItemCount > 0 )
               {
                  A1020OperacoesTitulosTipo = cmbOperacoesTitulosTipo.getValidValue(A1020OperacoesTitulosTipo);
                  n1020OperacoesTitulosTipo = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbOperacoesTitulosTipo,(string)cmbOperacoesTitulosTipo_Internalname,StringUtil.RTrim( A1020OperacoesTitulosTipo),(short)1,(string)cmbOperacoesTitulosTipo_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbOperacoesTitulosTipo.CurrentValue = StringUtil.RTrim( A1020OperacoesTitulosTipo);
            AssignProp(sPrefix, false, cmbOperacoesTitulosTipo_Internalname, "Values", (string)(cmbOperacoesTitulosTipo.ToJavascriptSource()), !bGXsfl_98_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacoesTitulosNumero_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1021OperacoesTitulosNumero), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1021OperacoesTitulosNumero), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacoesTitulosNumero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacoesTitulosDataEmissao_Internalname,context.localUtil.Format(A1022OperacoesTitulosDataEmissao, "99/99/99"),context.localUtil.Format( A1022OperacoesTitulosDataEmissao, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacoesTitulosDataEmissao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacoesTitulosDataVencimento_Internalname,context.localUtil.Format(A1023OperacoesTitulosDataVencimento, "99/99/99"),context.localUtil.Format( A1023OperacoesTitulosDataVencimento, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacoesTitulosDataVencimento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacoesTitulosValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A1024OperacoesTitulosValor, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A1024OperacoesTitulosValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacoesTitulosValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacoesTitulosLiquido_Internalname,StringUtil.LTrim( StringUtil.NToC( A1025OperacoesTitulosLiquido, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A1025OperacoesTitulosLiquido, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacoesTitulosLiquido_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacoesTitulosTaxa_Internalname,StringUtil.LTrim( StringUtil.NToC( A1026OperacoesTitulosTaxa, 21, 4, ",", "")),StringUtil.LTrim( context.localUtil.Format( A1026OperacoesTitulosTaxa, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacoesTitulosTaxa_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentual",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbOperacoesTitulosStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "OPERACOESTITULOSSTATUS_" + sGXsfl_98_idx;
               cmbOperacoesTitulosStatus.Name = GXCCtl;
               cmbOperacoesTitulosStatus.WebTags = "";
               cmbOperacoesTitulosStatus.addItem("PENDENTE", "Pendente", 0);
               cmbOperacoesTitulosStatus.addItem("ACEITO", "Aceito", 0);
               cmbOperacoesTitulosStatus.addItem("RECUSADO", "Recusado", 0);
               cmbOperacoesTitulosStatus.addItem("VENCIDO", "Vencido", 0);
               cmbOperacoesTitulosStatus.addItem("LIQUIDADO", "Liquidado", 0);
               if ( cmbOperacoesTitulosStatus.ItemCount > 0 )
               {
                  A1027OperacoesTitulosStatus = cmbOperacoesTitulosStatus.getValidValue(A1027OperacoesTitulosStatus);
                  n1027OperacoesTitulosStatus = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbOperacoesTitulosStatus,(string)cmbOperacoesTitulosStatus_Internalname,StringUtil.RTrim( A1027OperacoesTitulosStatus),(short)1,(string)cmbOperacoesTitulosStatus_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbOperacoesTitulosStatus.CurrentValue = StringUtil.RTrim( A1027OperacoesTitulosStatus);
            AssignProp(sPrefix, false, cmbOperacoesTitulosStatus_Internalname, "Values", (string)(cmbOperacoesTitulosStatus.ToJavascriptSource()), !bGXsfl_98_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacoesTitulosCreatedAt_Internalname,context.localUtil.TToC( A1028OperacoesTitulosCreatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A1028OperacoesTitulosCreatedAt, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacoesTitulosCreatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacoesTitulosUpdatedAt_Internalname,context.localUtil.TToC( A1029OperacoesTitulosUpdatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A1029OperacoesTitulosUpdatedAt, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacoesTitulosUpdatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesA42( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_98_idx = ((subGrid_Islastpage==1)&&(nGXsfl_98_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_98_idx+1);
            sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
            SubsflControlProps_982( ) ;
         }
         /* End function sendrow_982 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("OPERACOESTITULOSTIPO", "Tipo", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
         }
         cmbavOperacoestitulostipo1.Name = "vOPERACOESTITULOSTIPO1";
         cmbavOperacoestitulostipo1.WebTags = "";
         cmbavOperacoestitulostipo1.addItem("", "Todos", 0);
         cmbavOperacoestitulostipo1.addItem("NOTA_FISCAL", "Nota Fiscal", 0);
         cmbavOperacoestitulostipo1.addItem("RPA", "RPA", 0);
         if ( cmbavOperacoestitulostipo1.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("OPERACOESTITULOSTIPO", "Tipo", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
         }
         cmbavOperacoestitulostipo2.Name = "vOPERACOESTITULOSTIPO2";
         cmbavOperacoestitulostipo2.WebTags = "";
         cmbavOperacoestitulostipo2.addItem("", "Todos", 0);
         cmbavOperacoestitulostipo2.addItem("NOTA_FISCAL", "Nota Fiscal", 0);
         cmbavOperacoestitulostipo2.addItem("RPA", "RPA", 0);
         if ( cmbavOperacoestitulostipo2.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("OPERACOESTITULOSTIPO", "Tipo", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
         }
         cmbavOperacoestitulostipo3.Name = "vOPERACOESTITULOSTIPO3";
         cmbavOperacoestitulostipo3.WebTags = "";
         cmbavOperacoestitulostipo3.addItem("", "Todos", 0);
         cmbavOperacoestitulostipo3.addItem("NOTA_FISCAL", "Nota Fiscal", 0);
         cmbavOperacoestitulostipo3.addItem("RPA", "RPA", 0);
         if ( cmbavOperacoestitulostipo3.ItemCount > 0 )
         {
         }
         GXCCtl = "OPERACOESTITULOSTIPO_" + sGXsfl_98_idx;
         cmbOperacoesTitulosTipo.Name = GXCCtl;
         cmbOperacoesTitulosTipo.WebTags = "";
         cmbOperacoesTitulosTipo.addItem("", "NA", 0);
         cmbOperacoesTitulosTipo.addItem("NOTA_FISCAL", "Nota Fiscal", 0);
         cmbOperacoesTitulosTipo.addItem("RPA", "RPA", 0);
         if ( cmbOperacoesTitulosTipo.ItemCount > 0 )
         {
         }
         GXCCtl = "OPERACOESTITULOSSTATUS_" + sGXsfl_98_idx;
         cmbOperacoesTitulosStatus.Name = GXCCtl;
         cmbOperacoesTitulosStatus.WebTags = "";
         cmbOperacoesTitulosStatus.addItem("PENDENTE", "Pendente", 0);
         cmbOperacoesTitulosStatus.addItem("ACEITO", "Aceito", 0);
         cmbOperacoesTitulosStatus.addItem("RECUSADO", "Recusado", 0);
         cmbOperacoesTitulosStatus.addItem("VENCIDO", "Vencido", 0);
         cmbOperacoesTitulosStatus.addItem("LIQUIDADO", "Liquidado", 0);
         if ( cmbOperacoesTitulosStatus.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl98( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"98\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavUpdate_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavDelete_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Sacado") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Titulos Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Número nota") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Emissão") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Vencimento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Valor") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Líquido") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Taxa") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
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
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV69Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV70Update)));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavUpdate_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV71Delete)));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavDelete_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1035SacadoRazaoSocial));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1019OperacoesTitulosId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1010OperacoesId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1020OperacoesTitulosTipo));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1021OperacoesTitulosNumero), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A1022OperacoesTitulosDataEmissao, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A1023OperacoesTitulosDataVencimento, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A1024OperacoesTitulosValor, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A1025OperacoesTitulosLiquido, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A1026OperacoesTitulosTaxa, 21, 4, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1027OperacoesTitulosStatus));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A1028OperacoesTitulosCreatedAt, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A1029OperacoesTitulosUpdatedAt, 10, 8, 0, 3, "/", ":", " ")));
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
         bttBtninsert_Internalname = sPrefix+"BTNINSERT";
         bttBtnexport_Internalname = sPrefix+"BTNEXPORT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         Ddo_managefilters_Internalname = sPrefix+"DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = sPrefix+"vFILTERFULLTEXT";
         divTablefilters_Internalname = sPrefix+"TABLEFILTERS";
         divTablerightheader_Internalname = sPrefix+"TABLERIGHTHEADER";
         divTableheadercontent_Internalname = sPrefix+"TABLEHEADERCONTENT";
         lblDynamicfiltersprefix1_Internalname = sPrefix+"DYNAMICFILTERSPREFIX1";
         cmbavDynamicfiltersselector1_Internalname = sPrefix+"vDYNAMICFILTERSSELECTOR1";
         lblDynamicfiltersmiddle1_Internalname = sPrefix+"DYNAMICFILTERSMIDDLE1";
         cmbavOperacoestitulostipo1_Internalname = sPrefix+"vOPERACOESTITULOSTIPO1";
         cellFilter_operacoestitulostipo1_cell_Internalname = sPrefix+"FILTER_OPERACOESTITULOSTIPO1_CELL";
         imgAdddynamicfilters1_Internalname = sPrefix+"ADDDYNAMICFILTERS1";
         cellDynamicfilters_addfilter1_cell_Internalname = sPrefix+"DYNAMICFILTERS_ADDFILTER1_CELL";
         imgRemovedynamicfilters1_Internalname = sPrefix+"REMOVEDYNAMICFILTERS1";
         cellDynamicfilters_removefilter1_cell_Internalname = sPrefix+"DYNAMICFILTERS_REMOVEFILTER1_CELL";
         tblUnnamedtabledynamicfilters_1_Internalname = sPrefix+"UNNAMEDTABLEDYNAMICFILTERS_1";
         divTabledynamicfiltersrow1_Internalname = sPrefix+"TABLEDYNAMICFILTERSROW1";
         lblDynamicfiltersprefix2_Internalname = sPrefix+"DYNAMICFILTERSPREFIX2";
         cmbavDynamicfiltersselector2_Internalname = sPrefix+"vDYNAMICFILTERSSELECTOR2";
         lblDynamicfiltersmiddle2_Internalname = sPrefix+"DYNAMICFILTERSMIDDLE2";
         cmbavOperacoestitulostipo2_Internalname = sPrefix+"vOPERACOESTITULOSTIPO2";
         cellFilter_operacoestitulostipo2_cell_Internalname = sPrefix+"FILTER_OPERACOESTITULOSTIPO2_CELL";
         imgAdddynamicfilters2_Internalname = sPrefix+"ADDDYNAMICFILTERS2";
         cellDynamicfilters_addfilter2_cell_Internalname = sPrefix+"DYNAMICFILTERS_ADDFILTER2_CELL";
         imgRemovedynamicfilters2_Internalname = sPrefix+"REMOVEDYNAMICFILTERS2";
         cellDynamicfilters_removefilter2_cell_Internalname = sPrefix+"DYNAMICFILTERS_REMOVEFILTER2_CELL";
         tblUnnamedtabledynamicfilters_2_Internalname = sPrefix+"UNNAMEDTABLEDYNAMICFILTERS_2";
         divTabledynamicfiltersrow2_Internalname = sPrefix+"TABLEDYNAMICFILTERSROW2";
         lblDynamicfiltersprefix3_Internalname = sPrefix+"DYNAMICFILTERSPREFIX3";
         cmbavDynamicfiltersselector3_Internalname = sPrefix+"vDYNAMICFILTERSSELECTOR3";
         lblDynamicfiltersmiddle3_Internalname = sPrefix+"DYNAMICFILTERSMIDDLE3";
         cmbavOperacoestitulostipo3_Internalname = sPrefix+"vOPERACOESTITULOSTIPO3";
         cellFilter_operacoestitulostipo3_cell_Internalname = sPrefix+"FILTER_OPERACOESTITULOSTIPO3_CELL";
         imgRemovedynamicfilters3_Internalname = sPrefix+"REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = sPrefix+"DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblUnnamedtabledynamicfilters_3_Internalname = sPrefix+"UNNAMEDTABLEDYNAMICFILTERS_3";
         divTabledynamicfiltersrow3_Internalname = sPrefix+"TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = sPrefix+"TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = sPrefix+"ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         Dvpanel_tableheader_Internalname = sPrefix+"DVPANEL_TABLEHEADER";
         edtavDisplay_Internalname = sPrefix+"vDISPLAY";
         edtavUpdate_Internalname = sPrefix+"vUPDATE";
         edtavDelete_Internalname = sPrefix+"vDELETE";
         edtSacadoRazaoSocial_Internalname = sPrefix+"SACADORAZAOSOCIAL";
         edtOperacoesTitulosId_Internalname = sPrefix+"OPERACOESTITULOSID";
         edtOperacoesId_Internalname = sPrefix+"OPERACOESID";
         cmbOperacoesTitulosTipo_Internalname = sPrefix+"OPERACOESTITULOSTIPO";
         edtOperacoesTitulosNumero_Internalname = sPrefix+"OPERACOESTITULOSNUMERO";
         edtOperacoesTitulosDataEmissao_Internalname = sPrefix+"OPERACOESTITULOSDATAEMISSAO";
         edtOperacoesTitulosDataVencimento_Internalname = sPrefix+"OPERACOESTITULOSDATAVENCIMENTO";
         edtOperacoesTitulosValor_Internalname = sPrefix+"OPERACOESTITULOSVALOR";
         edtOperacoesTitulosLiquido_Internalname = sPrefix+"OPERACOESTITULOSLIQUIDO";
         edtOperacoesTitulosTaxa_Internalname = sPrefix+"OPERACOESTITULOSTAXA";
         cmbOperacoesTitulosStatus_Internalname = sPrefix+"OPERACOESTITULOSSTATUS";
         edtOperacoesTitulosCreatedAt_Internalname = sPrefix+"OPERACOESTITULOSCREATEDAT";
         edtOperacoesTitulosUpdatedAt_Internalname = sPrefix+"OPERACOESTITULOSUPDATEDAT";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         lblJsdynamicfilters_Internalname = sPrefix+"JSDYNAMICFILTERS";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         edtavDdo_operacoestitulosdataemissaoauxdatetext_Internalname = sPrefix+"vDDO_OPERACOESTITULOSDATAEMISSAOAUXDATETEXT";
         Tfoperacoestitulosdataemissao_rangepicker_Internalname = sPrefix+"TFOPERACOESTITULOSDATAEMISSAO_RANGEPICKER";
         divDdo_operacoestitulosdataemissaoauxdates_Internalname = sPrefix+"DDO_OPERACOESTITULOSDATAEMISSAOAUXDATES";
         edtavDdo_operacoestitulosdatavencimentoauxdatetext_Internalname = sPrefix+"vDDO_OPERACOESTITULOSDATAVENCIMENTOAUXDATETEXT";
         Tfoperacoestitulosdatavencimento_rangepicker_Internalname = sPrefix+"TFOPERACOESTITULOSDATAVENCIMENTO_RANGEPICKER";
         divDdo_operacoestitulosdatavencimentoauxdates_Internalname = sPrefix+"DDO_OPERACOESTITULOSDATAVENCIMENTOAUXDATES";
         edtavDdo_operacoestituloscreatedatauxdatetext_Internalname = sPrefix+"vDDO_OPERACOESTITULOSCREATEDATAUXDATETEXT";
         Tfoperacoestituloscreatedat_rangepicker_Internalname = sPrefix+"TFOPERACOESTITULOSCREATEDAT_RANGEPICKER";
         divDdo_operacoestituloscreatedatauxdates_Internalname = sPrefix+"DDO_OPERACOESTITULOSCREATEDATAUXDATES";
         edtavDdo_operacoestitulosupdatedatauxdatetext_Internalname = sPrefix+"vDDO_OPERACOESTITULOSUPDATEDATAUXDATETEXT";
         Tfoperacoestitulosupdatedat_rangepicker_Internalname = sPrefix+"TFOPERACOESTITULOSUPDATEDAT_RANGEPICKER";
         divDdo_operacoestitulosupdatedatauxdates_Internalname = sPrefix+"DDO_OPERACOESTITULOSUPDATEDATAUXDATES";
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
         edtOperacoesTitulosUpdatedAt_Jsonclick = "";
         edtOperacoesTitulosCreatedAt_Jsonclick = "";
         cmbOperacoesTitulosStatus_Jsonclick = "";
         edtOperacoesTitulosTaxa_Jsonclick = "";
         edtOperacoesTitulosLiquido_Jsonclick = "";
         edtOperacoesTitulosValor_Jsonclick = "";
         edtOperacoesTitulosDataVencimento_Jsonclick = "";
         edtOperacoesTitulosDataEmissao_Jsonclick = "";
         edtOperacoesTitulosNumero_Jsonclick = "";
         cmbOperacoesTitulosTipo_Jsonclick = "";
         edtOperacoesId_Jsonclick = "";
         edtOperacoesTitulosId_Jsonclick = "";
         edtSacadoRazaoSocial_Jsonclick = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Class = "Attribute";
         edtavDelete_Enabled = 1;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Class = "Attribute";
         edtavUpdate_Enabled = 1;
         edtavDisplay_Jsonclick = "";
         edtavDisplay_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         cmbavOperacoestitulostipo1_Jsonclick = "";
         cmbavOperacoestitulostipo1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         cmbavOperacoestitulostipo2_Jsonclick = "";
         cmbavOperacoestitulostipo2.Enabled = 1;
         cmbavOperacoestitulostipo3_Jsonclick = "";
         cmbavOperacoestitulostipo3.Enabled = 1;
         cmbavOperacoestitulostipo3.Visible = 1;
         cmbavOperacoestitulostipo2.Visible = 1;
         cmbavOperacoestitulostipo1.Visible = 1;
         edtOperacoesTitulosUpdatedAt_Enabled = 0;
         edtOperacoesTitulosCreatedAt_Enabled = 0;
         cmbOperacoesTitulosStatus.Enabled = 0;
         edtOperacoesTitulosTaxa_Enabled = 0;
         edtOperacoesTitulosLiquido_Enabled = 0;
         edtOperacoesTitulosValor_Enabled = 0;
         edtOperacoesTitulosDataVencimento_Enabled = 0;
         edtOperacoesTitulosDataEmissao_Enabled = 0;
         edtOperacoesTitulosNumero_Enabled = 0;
         cmbOperacoesTitulosTipo.Enabled = 0;
         edtOperacoesId_Enabled = 0;
         edtOperacoesTitulosId_Enabled = 0;
         edtSacadoRazaoSocial_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_operacoestitulosupdatedatauxdatetext_Jsonclick = "";
         edtavDdo_operacoestituloscreatedatauxdatetext_Jsonclick = "";
         edtavDdo_operacoestitulosdatavencimentoauxdatetext_Jsonclick = "";
         edtavDdo_operacoestitulosdataemissaoauxdatetext_Jsonclick = "";
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
         Grid_empowerer_Fixedcolumns = ";L;L;;;;;;;;;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "||9.0|||18.2|18.2|16.4|||";
         Ddo_grid_Datalistproc = "OperacoesTitulosWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|NOTA_FISCAL:Nota Fiscal,RPA:RPA|||||||PENDENTE:Pendente,ACEITO:Aceito,RECUSADO:Recusado,VENCIDO:Vencido,LIQUIDADO:Liquidado||";
         Ddo_grid_Allowmultipleselection = "|T|||||||T||";
         Ddo_grid_Datalisttype = "Dynamic|FixedValues|||||||FixedValues||";
         Ddo_grid_Includedatalist = "T|T|||||||T||";
         Ddo_grid_Filterisrange = "||T|P|P|T|T|T||P|P";
         Ddo_grid_Filtertype = "Character||Numeric|Date|Date|Numeric|Numeric|Numeric||Date|Date";
         Ddo_grid_Includefilter = "T||T|T|T|T|T|T||T|T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|5|1|6|7|8|9|10|11";
         Ddo_grid_Columnids = "3:SacadoRazaoSocial|6:OperacoesTitulosTipo|7:OperacoesTitulosNumero|8:OperacoesTitulosDataEmissao|9:OperacoesTitulosDataVencimento|10:OperacoesTitulosValor|11:OperacoesTitulosLiquido|12:OperacoesTitulosTaxa|13:OperacoesTitulosStatus|14:OperacoesTitulosCreatedAt|15:OperacoesTitulosUpdatedAt";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavOperacoestitulostipo1"},{"av":"AV17OperacoesTitulosTipo1","fld":"vOPERACOESTITULOSTIPO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavOperacoestitulostipo2"},{"av":"AV20OperacoesTitulosTipo2","fld":"vOPERACOESTITULOSTIPO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavOperacoestitulostipo3"},{"av":"AV23OperacoesTitulosTipo3","fld":"vOPERACOESTITULOSTIPO3","type":"svchar"},{"av":"AV77Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV73OperacoesId","fld":"vOPERACOESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV75TFSacadoRazaoSocial","fld":"vTFSACADORAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV76TFSacadoRazaoSocial_Sel","fld":"vTFSACADORAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV33TFOperacoesTitulosTipo_Sels","fld":"vTFOPERACOESTITULOSTIPO_SELS","type":""},{"av":"AV34TFOperacoesTitulosNumero","fld":"vTFOPERACOESTITULOSNUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35TFOperacoesTitulosNumero_To","fld":"vTFOPERACOESTITULOSNUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV36TFOperacoesTitulosDataEmissao","fld":"vTFOPERACOESTITULOSDATAEMISSAO","type":"date"},{"av":"AV37TFOperacoesTitulosDataEmissao_To","fld":"vTFOPERACOESTITULOSDATAEMISSAO_TO","type":"date"},{"av":"AV41TFOperacoesTitulosDataVencimento","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO","type":"date"},{"av":"AV42TFOperacoesTitulosDataVencimento_To","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO_TO","type":"date"},{"av":"AV46TFOperacoesTitulosValor","fld":"vTFOPERACOESTITULOSVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFOperacoesTitulosValor_To","fld":"vTFOPERACOESTITULOSVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFOperacoesTitulosLiquido","fld":"vTFOPERACOESTITULOSLIQUIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFOperacoesTitulosLiquido_To","fld":"vTFOPERACOESTITULOSLIQUIDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV50TFOperacoesTitulosTaxa","fld":"vTFOPERACOESTITULOSTAXA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV51TFOperacoesTitulosTaxa_To","fld":"vTFOPERACOESTITULOSTAXA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV53TFOperacoesTitulosStatus_Sels","fld":"vTFOPERACOESTITULOSSTATUS_SELS","type":""},{"av":"AV54TFOperacoesTitulosCreatedAt","fld":"vTFOPERACOESTITULOSCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFOperacoesTitulosCreatedAt_To","fld":"vTFOPERACOESTITULOSCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFOperacoesTitulosUpdatedAt","fld":"vTFOPERACOESTITULOSUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV60TFOperacoesTitulosUpdatedAt_To","fld":"vTFOPERACOESTITULOSUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV74TrnMode","fld":"vTRNMODE","type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV66GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV67GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV68GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV29ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12A42","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavOperacoestitulostipo1"},{"av":"AV17OperacoesTitulosTipo1","fld":"vOPERACOESTITULOSTIPO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavOperacoestitulostipo2"},{"av":"AV20OperacoesTitulosTipo2","fld":"vOPERACOESTITULOSTIPO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavOperacoestitulostipo3"},{"av":"AV23OperacoesTitulosTipo3","fld":"vOPERACOESTITULOSTIPO3","type":"svchar"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV77Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV73OperacoesId","fld":"vOPERACOESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV75TFSacadoRazaoSocial","fld":"vTFSACADORAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV76TFSacadoRazaoSocial_Sel","fld":"vTFSACADORAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV33TFOperacoesTitulosTipo_Sels","fld":"vTFOPERACOESTITULOSTIPO_SELS","type":""},{"av":"AV34TFOperacoesTitulosNumero","fld":"vTFOPERACOESTITULOSNUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35TFOperacoesTitulosNumero_To","fld":"vTFOPERACOESTITULOSNUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV36TFOperacoesTitulosDataEmissao","fld":"vTFOPERACOESTITULOSDATAEMISSAO","type":"date"},{"av":"AV37TFOperacoesTitulosDataEmissao_To","fld":"vTFOPERACOESTITULOSDATAEMISSAO_TO","type":"date"},{"av":"AV41TFOperacoesTitulosDataVencimento","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO","type":"date"},{"av":"AV42TFOperacoesTitulosDataVencimento_To","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO_TO","type":"date"},{"av":"AV46TFOperacoesTitulosValor","fld":"vTFOPERACOESTITULOSVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFOperacoesTitulosValor_To","fld":"vTFOPERACOESTITULOSVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFOperacoesTitulosLiquido","fld":"vTFOPERACOESTITULOSLIQUIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFOperacoesTitulosLiquido_To","fld":"vTFOPERACOESTITULOSLIQUIDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV50TFOperacoesTitulosTaxa","fld":"vTFOPERACOESTITULOSTAXA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV51TFOperacoesTitulosTaxa_To","fld":"vTFOPERACOESTITULOSTAXA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV53TFOperacoesTitulosStatus_Sels","fld":"vTFOPERACOESTITULOSSTATUS_SELS","type":""},{"av":"AV54TFOperacoesTitulosCreatedAt","fld":"vTFOPERACOESTITULOSCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFOperacoesTitulosCreatedAt_To","fld":"vTFOPERACOESTITULOSCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFOperacoesTitulosUpdatedAt","fld":"vTFOPERACOESTITULOSUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV60TFOperacoesTitulosUpdatedAt_To","fld":"vTFOPERACOESTITULOSUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV74TrnMode","fld":"vTRNMODE","type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13A42","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavOperacoestitulostipo1"},{"av":"AV17OperacoesTitulosTipo1","fld":"vOPERACOESTITULOSTIPO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavOperacoestitulostipo2"},{"av":"AV20OperacoesTitulosTipo2","fld":"vOPERACOESTITULOSTIPO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavOperacoestitulostipo3"},{"av":"AV23OperacoesTitulosTipo3","fld":"vOPERACOESTITULOSTIPO3","type":"svchar"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV77Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV73OperacoesId","fld":"vOPERACOESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV75TFSacadoRazaoSocial","fld":"vTFSACADORAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV76TFSacadoRazaoSocial_Sel","fld":"vTFSACADORAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV33TFOperacoesTitulosTipo_Sels","fld":"vTFOPERACOESTITULOSTIPO_SELS","type":""},{"av":"AV34TFOperacoesTitulosNumero","fld":"vTFOPERACOESTITULOSNUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35TFOperacoesTitulosNumero_To","fld":"vTFOPERACOESTITULOSNUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV36TFOperacoesTitulosDataEmissao","fld":"vTFOPERACOESTITULOSDATAEMISSAO","type":"date"},{"av":"AV37TFOperacoesTitulosDataEmissao_To","fld":"vTFOPERACOESTITULOSDATAEMISSAO_TO","type":"date"},{"av":"AV41TFOperacoesTitulosDataVencimento","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO","type":"date"},{"av":"AV42TFOperacoesTitulosDataVencimento_To","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO_TO","type":"date"},{"av":"AV46TFOperacoesTitulosValor","fld":"vTFOPERACOESTITULOSVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFOperacoesTitulosValor_To","fld":"vTFOPERACOESTITULOSVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFOperacoesTitulosLiquido","fld":"vTFOPERACOESTITULOSLIQUIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFOperacoesTitulosLiquido_To","fld":"vTFOPERACOESTITULOSLIQUIDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV50TFOperacoesTitulosTaxa","fld":"vTFOPERACOESTITULOSTAXA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV51TFOperacoesTitulosTaxa_To","fld":"vTFOPERACOESTITULOSTAXA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV53TFOperacoesTitulosStatus_Sels","fld":"vTFOPERACOESTITULOSSTATUS_SELS","type":""},{"av":"AV54TFOperacoesTitulosCreatedAt","fld":"vTFOPERACOESTITULOSCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFOperacoesTitulosCreatedAt_To","fld":"vTFOPERACOESTITULOSCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFOperacoesTitulosUpdatedAt","fld":"vTFOPERACOESTITULOSUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV60TFOperacoesTitulosUpdatedAt_To","fld":"vTFOPERACOESTITULOSUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV74TrnMode","fld":"vTRNMODE","type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E14A42","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavOperacoestitulostipo1"},{"av":"AV17OperacoesTitulosTipo1","fld":"vOPERACOESTITULOSTIPO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavOperacoestitulostipo2"},{"av":"AV20OperacoesTitulosTipo2","fld":"vOPERACOESTITULOSTIPO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavOperacoestitulostipo3"},{"av":"AV23OperacoesTitulosTipo3","fld":"vOPERACOESTITULOSTIPO3","type":"svchar"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV77Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV73OperacoesId","fld":"vOPERACOESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV75TFSacadoRazaoSocial","fld":"vTFSACADORAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV76TFSacadoRazaoSocial_Sel","fld":"vTFSACADORAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV33TFOperacoesTitulosTipo_Sels","fld":"vTFOPERACOESTITULOSTIPO_SELS","type":""},{"av":"AV34TFOperacoesTitulosNumero","fld":"vTFOPERACOESTITULOSNUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35TFOperacoesTitulosNumero_To","fld":"vTFOPERACOESTITULOSNUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV36TFOperacoesTitulosDataEmissao","fld":"vTFOPERACOESTITULOSDATAEMISSAO","type":"date"},{"av":"AV37TFOperacoesTitulosDataEmissao_To","fld":"vTFOPERACOESTITULOSDATAEMISSAO_TO","type":"date"},{"av":"AV41TFOperacoesTitulosDataVencimento","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO","type":"date"},{"av":"AV42TFOperacoesTitulosDataVencimento_To","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO_TO","type":"date"},{"av":"AV46TFOperacoesTitulosValor","fld":"vTFOPERACOESTITULOSVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFOperacoesTitulosValor_To","fld":"vTFOPERACOESTITULOSVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFOperacoesTitulosLiquido","fld":"vTFOPERACOESTITULOSLIQUIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFOperacoesTitulosLiquido_To","fld":"vTFOPERACOESTITULOSLIQUIDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV50TFOperacoesTitulosTaxa","fld":"vTFOPERACOESTITULOSTAXA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV51TFOperacoesTitulosTaxa_To","fld":"vTFOPERACOESTITULOSTAXA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV53TFOperacoesTitulosStatus_Sels","fld":"vTFOPERACOESTITULOSSTATUS_SELS","type":""},{"av":"AV54TFOperacoesTitulosCreatedAt","fld":"vTFOPERACOESTITULOSCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFOperacoesTitulosCreatedAt_To","fld":"vTFOPERACOESTITULOSCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFOperacoesTitulosUpdatedAt","fld":"vTFOPERACOESTITULOSUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV60TFOperacoesTitulosUpdatedAt_To","fld":"vTFOPERACOESTITULOSUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV74TrnMode","fld":"vTRNMODE","type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV59TFOperacoesTitulosUpdatedAt","fld":"vTFOPERACOESTITULOSUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV60TFOperacoesTitulosUpdatedAt_To","fld":"vTFOPERACOESTITULOSUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV54TFOperacoesTitulosCreatedAt","fld":"vTFOPERACOESTITULOSCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFOperacoesTitulosCreatedAt_To","fld":"vTFOPERACOESTITULOSCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV52TFOperacoesTitulosStatus_SelsJson","fld":"vTFOPERACOESTITULOSSTATUS_SELSJSON","type":"vchar"},{"av":"AV53TFOperacoesTitulosStatus_Sels","fld":"vTFOPERACOESTITULOSSTATUS_SELS","type":""},{"av":"AV50TFOperacoesTitulosTaxa","fld":"vTFOPERACOESTITULOSTAXA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV51TFOperacoesTitulosTaxa_To","fld":"vTFOPERACOESTITULOSTAXA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV48TFOperacoesTitulosLiquido","fld":"vTFOPERACOESTITULOSLIQUIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFOperacoesTitulosLiquido_To","fld":"vTFOPERACOESTITULOSLIQUIDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFOperacoesTitulosValor","fld":"vTFOPERACOESTITULOSVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFOperacoesTitulosValor_To","fld":"vTFOPERACOESTITULOSVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFOperacoesTitulosDataVencimento","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO","type":"date"},{"av":"AV42TFOperacoesTitulosDataVencimento_To","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO_TO","type":"date"},{"av":"AV36TFOperacoesTitulosDataEmissao","fld":"vTFOPERACOESTITULOSDATAEMISSAO","type":"date"},{"av":"AV37TFOperacoesTitulosDataEmissao_To","fld":"vTFOPERACOESTITULOSDATAEMISSAO_TO","type":"date"},{"av":"AV34TFOperacoesTitulosNumero","fld":"vTFOPERACOESTITULOSNUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35TFOperacoesTitulosNumero_To","fld":"vTFOPERACOESTITULOSNUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV32TFOperacoesTitulosTipo_SelsJson","fld":"vTFOPERACOESTITULOSTIPO_SELSJSON","type":"vchar"},{"av":"AV33TFOperacoesTitulosTipo_Sels","fld":"vTFOPERACOESTITULOSTIPO_SELS","type":""},{"av":"AV75TFSacadoRazaoSocial","fld":"vTFSACADORAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV76TFSacadoRazaoSocial_Sel","fld":"vTFSACADORAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E27A42","iparms":[{"av":"AV74TrnMode","fld":"vTRNMODE","type":"char"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV69Display","fld":"vDISPLAY","type":"char"},{"av":"AV70Update","fld":"vUPDATE","type":"char"},{"av":"edtavUpdate_Class","ctrl":"vUPDATE","prop":"Class"},{"av":"AV71Delete","fld":"vDELETE","type":"char"},{"av":"edtavDelete_Class","ctrl":"vDELETE","prop":"Class"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E20A42","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E15A42","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavOperacoestitulostipo1"},{"av":"AV17OperacoesTitulosTipo1","fld":"vOPERACOESTITULOSTIPO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavOperacoestitulostipo2"},{"av":"AV20OperacoesTitulosTipo2","fld":"vOPERACOESTITULOSTIPO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavOperacoestitulostipo3"},{"av":"AV23OperacoesTitulosTipo3","fld":"vOPERACOESTITULOSTIPO3","type":"svchar"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV77Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV73OperacoesId","fld":"vOPERACOESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV75TFSacadoRazaoSocial","fld":"vTFSACADORAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV76TFSacadoRazaoSocial_Sel","fld":"vTFSACADORAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV33TFOperacoesTitulosTipo_Sels","fld":"vTFOPERACOESTITULOSTIPO_SELS","type":""},{"av":"AV34TFOperacoesTitulosNumero","fld":"vTFOPERACOESTITULOSNUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35TFOperacoesTitulosNumero_To","fld":"vTFOPERACOESTITULOSNUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV36TFOperacoesTitulosDataEmissao","fld":"vTFOPERACOESTITULOSDATAEMISSAO","type":"date"},{"av":"AV37TFOperacoesTitulosDataEmissao_To","fld":"vTFOPERACOESTITULOSDATAEMISSAO_TO","type":"date"},{"av":"AV41TFOperacoesTitulosDataVencimento","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO","type":"date"},{"av":"AV42TFOperacoesTitulosDataVencimento_To","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO_TO","type":"date"},{"av":"AV46TFOperacoesTitulosValor","fld":"vTFOPERACOESTITULOSVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFOperacoesTitulosValor_To","fld":"vTFOPERACOESTITULOSVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFOperacoesTitulosLiquido","fld":"vTFOPERACOESTITULOSLIQUIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFOperacoesTitulosLiquido_To","fld":"vTFOPERACOESTITULOSLIQUIDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV50TFOperacoesTitulosTaxa","fld":"vTFOPERACOESTITULOSTAXA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV51TFOperacoesTitulosTaxa_To","fld":"vTFOPERACOESTITULOSTAXA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV53TFOperacoesTitulosStatus_Sels","fld":"vTFOPERACOESTITULOSSTATUS_SELS","type":""},{"av":"AV54TFOperacoesTitulosCreatedAt","fld":"vTFOPERACOESTITULOSCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFOperacoesTitulosCreatedAt_To","fld":"vTFOPERACOESTITULOSCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFOperacoesTitulosUpdatedAt","fld":"vTFOPERACOESTITULOSUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV60TFOperacoesTitulosUpdatedAt_To","fld":"vTFOPERACOESTITULOSUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV74TrnMode","fld":"vTRNMODE","type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavOperacoestitulostipo2"},{"av":"AV20OperacoesTitulosTipo2","fld":"vOPERACOESTITULOSTIPO2","type":"svchar"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavOperacoestitulostipo3"},{"av":"AV23OperacoesTitulosTipo3","fld":"vOPERACOESTITULOSTIPO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavOperacoestitulostipo1"},{"av":"AV17OperacoesTitulosTipo1","fld":"vOPERACOESTITULOSTIPO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV66GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV67GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV68GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV29ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E21A42","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavOperacoestitulostipo1"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E22A42","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E16A42","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavOperacoestitulostipo1"},{"av":"AV17OperacoesTitulosTipo1","fld":"vOPERACOESTITULOSTIPO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavOperacoestitulostipo2"},{"av":"AV20OperacoesTitulosTipo2","fld":"vOPERACOESTITULOSTIPO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavOperacoestitulostipo3"},{"av":"AV23OperacoesTitulosTipo3","fld":"vOPERACOESTITULOSTIPO3","type":"svchar"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV77Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV73OperacoesId","fld":"vOPERACOESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV75TFSacadoRazaoSocial","fld":"vTFSACADORAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV76TFSacadoRazaoSocial_Sel","fld":"vTFSACADORAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV33TFOperacoesTitulosTipo_Sels","fld":"vTFOPERACOESTITULOSTIPO_SELS","type":""},{"av":"AV34TFOperacoesTitulosNumero","fld":"vTFOPERACOESTITULOSNUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35TFOperacoesTitulosNumero_To","fld":"vTFOPERACOESTITULOSNUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV36TFOperacoesTitulosDataEmissao","fld":"vTFOPERACOESTITULOSDATAEMISSAO","type":"date"},{"av":"AV37TFOperacoesTitulosDataEmissao_To","fld":"vTFOPERACOESTITULOSDATAEMISSAO_TO","type":"date"},{"av":"AV41TFOperacoesTitulosDataVencimento","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO","type":"date"},{"av":"AV42TFOperacoesTitulosDataVencimento_To","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO_TO","type":"date"},{"av":"AV46TFOperacoesTitulosValor","fld":"vTFOPERACOESTITULOSVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFOperacoesTitulosValor_To","fld":"vTFOPERACOESTITULOSVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFOperacoesTitulosLiquido","fld":"vTFOPERACOESTITULOSLIQUIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFOperacoesTitulosLiquido_To","fld":"vTFOPERACOESTITULOSLIQUIDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV50TFOperacoesTitulosTaxa","fld":"vTFOPERACOESTITULOSTAXA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV51TFOperacoesTitulosTaxa_To","fld":"vTFOPERACOESTITULOSTAXA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV53TFOperacoesTitulosStatus_Sels","fld":"vTFOPERACOESTITULOSSTATUS_SELS","type":""},{"av":"AV54TFOperacoesTitulosCreatedAt","fld":"vTFOPERACOESTITULOSCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFOperacoesTitulosCreatedAt_To","fld":"vTFOPERACOESTITULOSCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFOperacoesTitulosUpdatedAt","fld":"vTFOPERACOESTITULOSUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV60TFOperacoesTitulosUpdatedAt_To","fld":"vTFOPERACOESTITULOSUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV74TrnMode","fld":"vTRNMODE","type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavOperacoestitulostipo2"},{"av":"AV20OperacoesTitulosTipo2","fld":"vOPERACOESTITULOSTIPO2","type":"svchar"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavOperacoestitulostipo3"},{"av":"AV23OperacoesTitulosTipo3","fld":"vOPERACOESTITULOSTIPO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavOperacoestitulostipo1"},{"av":"AV17OperacoesTitulosTipo1","fld":"vOPERACOESTITULOSTIPO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV66GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV67GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV68GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV29ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E23A42","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavOperacoestitulostipo2"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E17A42","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavOperacoestitulostipo1"},{"av":"AV17OperacoesTitulosTipo1","fld":"vOPERACOESTITULOSTIPO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavOperacoestitulostipo2"},{"av":"AV20OperacoesTitulosTipo2","fld":"vOPERACOESTITULOSTIPO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavOperacoestitulostipo3"},{"av":"AV23OperacoesTitulosTipo3","fld":"vOPERACOESTITULOSTIPO3","type":"svchar"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV77Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV73OperacoesId","fld":"vOPERACOESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV75TFSacadoRazaoSocial","fld":"vTFSACADORAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV76TFSacadoRazaoSocial_Sel","fld":"vTFSACADORAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV33TFOperacoesTitulosTipo_Sels","fld":"vTFOPERACOESTITULOSTIPO_SELS","type":""},{"av":"AV34TFOperacoesTitulosNumero","fld":"vTFOPERACOESTITULOSNUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35TFOperacoesTitulosNumero_To","fld":"vTFOPERACOESTITULOSNUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV36TFOperacoesTitulosDataEmissao","fld":"vTFOPERACOESTITULOSDATAEMISSAO","type":"date"},{"av":"AV37TFOperacoesTitulosDataEmissao_To","fld":"vTFOPERACOESTITULOSDATAEMISSAO_TO","type":"date"},{"av":"AV41TFOperacoesTitulosDataVencimento","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO","type":"date"},{"av":"AV42TFOperacoesTitulosDataVencimento_To","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO_TO","type":"date"},{"av":"AV46TFOperacoesTitulosValor","fld":"vTFOPERACOESTITULOSVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFOperacoesTitulosValor_To","fld":"vTFOPERACOESTITULOSVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFOperacoesTitulosLiquido","fld":"vTFOPERACOESTITULOSLIQUIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFOperacoesTitulosLiquido_To","fld":"vTFOPERACOESTITULOSLIQUIDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV50TFOperacoesTitulosTaxa","fld":"vTFOPERACOESTITULOSTAXA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV51TFOperacoesTitulosTaxa_To","fld":"vTFOPERACOESTITULOSTAXA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV53TFOperacoesTitulosStatus_Sels","fld":"vTFOPERACOESTITULOSSTATUS_SELS","type":""},{"av":"AV54TFOperacoesTitulosCreatedAt","fld":"vTFOPERACOESTITULOSCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFOperacoesTitulosCreatedAt_To","fld":"vTFOPERACOESTITULOSCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFOperacoesTitulosUpdatedAt","fld":"vTFOPERACOESTITULOSUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV60TFOperacoesTitulosUpdatedAt_To","fld":"vTFOPERACOESTITULOSUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV74TrnMode","fld":"vTRNMODE","type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavOperacoestitulostipo2"},{"av":"AV20OperacoesTitulosTipo2","fld":"vOPERACOESTITULOSTIPO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavOperacoestitulostipo3"},{"av":"AV23OperacoesTitulosTipo3","fld":"vOPERACOESTITULOSTIPO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavOperacoestitulostipo1"},{"av":"AV17OperacoesTitulosTipo1","fld":"vOPERACOESTITULOSTIPO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV66GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV67GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV68GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV29ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E24A42","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavOperacoestitulostipo3"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11A42","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavOperacoestitulostipo1"},{"av":"AV17OperacoesTitulosTipo1","fld":"vOPERACOESTITULOSTIPO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavOperacoestitulostipo2"},{"av":"AV20OperacoesTitulosTipo2","fld":"vOPERACOESTITULOSTIPO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavOperacoestitulostipo3"},{"av":"AV23OperacoesTitulosTipo3","fld":"vOPERACOESTITULOSTIPO3","type":"svchar"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV77Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV73OperacoesId","fld":"vOPERACOESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV75TFSacadoRazaoSocial","fld":"vTFSACADORAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV76TFSacadoRazaoSocial_Sel","fld":"vTFSACADORAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV33TFOperacoesTitulosTipo_Sels","fld":"vTFOPERACOESTITULOSTIPO_SELS","type":""},{"av":"AV34TFOperacoesTitulosNumero","fld":"vTFOPERACOESTITULOSNUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35TFOperacoesTitulosNumero_To","fld":"vTFOPERACOESTITULOSNUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV36TFOperacoesTitulosDataEmissao","fld":"vTFOPERACOESTITULOSDATAEMISSAO","type":"date"},{"av":"AV37TFOperacoesTitulosDataEmissao_To","fld":"vTFOPERACOESTITULOSDATAEMISSAO_TO","type":"date"},{"av":"AV41TFOperacoesTitulosDataVencimento","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO","type":"date"},{"av":"AV42TFOperacoesTitulosDataVencimento_To","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO_TO","type":"date"},{"av":"AV46TFOperacoesTitulosValor","fld":"vTFOPERACOESTITULOSVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFOperacoesTitulosValor_To","fld":"vTFOPERACOESTITULOSVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFOperacoesTitulosLiquido","fld":"vTFOPERACOESTITULOSLIQUIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFOperacoesTitulosLiquido_To","fld":"vTFOPERACOESTITULOSLIQUIDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV50TFOperacoesTitulosTaxa","fld":"vTFOPERACOESTITULOSTAXA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV51TFOperacoesTitulosTaxa_To","fld":"vTFOPERACOESTITULOSTAXA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV53TFOperacoesTitulosStatus_Sels","fld":"vTFOPERACOESTITULOSSTATUS_SELS","type":""},{"av":"AV54TFOperacoesTitulosCreatedAt","fld":"vTFOPERACOESTITULOSCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFOperacoesTitulosCreatedAt_To","fld":"vTFOPERACOESTITULOSCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFOperacoesTitulosUpdatedAt","fld":"vTFOPERACOESTITULOSUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV60TFOperacoesTitulosUpdatedAt_To","fld":"vTFOPERACOESTITULOSUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV74TrnMode","fld":"vTRNMODE","type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV32TFOperacoesTitulosTipo_SelsJson","fld":"vTFOPERACOESTITULOSTIPO_SELSJSON","type":"vchar"},{"av":"AV52TFOperacoesTitulosStatus_SelsJson","fld":"vTFOPERACOESTITULOSSTATUS_SELSJSON","type":"vchar"},{"av":"AV56DDO_OperacoesTitulosCreatedAtAuxDate","fld":"vDDO_OPERACOESTITULOSCREATEDATAUXDATE","type":"date"},{"av":"AV61DDO_OperacoesTitulosUpdatedAtAuxDate","fld":"vDDO_OPERACOESTITULOSUPDATEDATAUXDATE","type":"date"},{"av":"AV57DDO_OperacoesTitulosCreatedAtAuxDateTo","fld":"vDDO_OPERACOESTITULOSCREATEDATAUXDATETO","type":"date"},{"av":"AV62DDO_OperacoesTitulosUpdatedAtAuxDateTo","fld":"vDDO_OPERACOESTITULOSUPDATEDATAUXDATETO","type":"date"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV75TFSacadoRazaoSocial","fld":"vTFSACADORAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV76TFSacadoRazaoSocial_Sel","fld":"vTFSACADORAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV33TFOperacoesTitulosTipo_Sels","fld":"vTFOPERACOESTITULOSTIPO_SELS","type":""},{"av":"AV34TFOperacoesTitulosNumero","fld":"vTFOPERACOESTITULOSNUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35TFOperacoesTitulosNumero_To","fld":"vTFOPERACOESTITULOSNUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV36TFOperacoesTitulosDataEmissao","fld":"vTFOPERACOESTITULOSDATAEMISSAO","type":"date"},{"av":"AV37TFOperacoesTitulosDataEmissao_To","fld":"vTFOPERACOESTITULOSDATAEMISSAO_TO","type":"date"},{"av":"AV41TFOperacoesTitulosDataVencimento","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO","type":"date"},{"av":"AV42TFOperacoesTitulosDataVencimento_To","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO_TO","type":"date"},{"av":"AV46TFOperacoesTitulosValor","fld":"vTFOPERACOESTITULOSVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFOperacoesTitulosValor_To","fld":"vTFOPERACOESTITULOSVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFOperacoesTitulosLiquido","fld":"vTFOPERACOESTITULOSLIQUIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFOperacoesTitulosLiquido_To","fld":"vTFOPERACOESTITULOSLIQUIDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV50TFOperacoesTitulosTaxa","fld":"vTFOPERACOESTITULOSTAXA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV51TFOperacoesTitulosTaxa_To","fld":"vTFOPERACOESTITULOSTAXA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV53TFOperacoesTitulosStatus_Sels","fld":"vTFOPERACOESTITULOSSTATUS_SELS","type":""},{"av":"AV54TFOperacoesTitulosCreatedAt","fld":"vTFOPERACOESTITULOSCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFOperacoesTitulosCreatedAt_To","fld":"vTFOPERACOESTITULOSCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFOperacoesTitulosUpdatedAt","fld":"vTFOPERACOESTITULOSUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV60TFOperacoesTitulosUpdatedAt_To","fld":"vTFOPERACOESTITULOSUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavOperacoestitulostipo1"},{"av":"AV17OperacoesTitulosTipo1","fld":"vOPERACOESTITULOSTIPO1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV61DDO_OperacoesTitulosUpdatedAtAuxDate","fld":"vDDO_OPERACOESTITULOSUPDATEDATAUXDATE","type":"date"},{"av":"AV62DDO_OperacoesTitulosUpdatedAtAuxDateTo","fld":"vDDO_OPERACOESTITULOSUPDATEDATAUXDATETO","type":"date"},{"av":"AV56DDO_OperacoesTitulosCreatedAtAuxDate","fld":"vDDO_OPERACOESTITULOSCREATEDATAUXDATE","type":"date"},{"av":"AV57DDO_OperacoesTitulosCreatedAtAuxDateTo","fld":"vDDO_OPERACOESTITULOSCREATEDATAUXDATETO","type":"date"},{"av":"AV52TFOperacoesTitulosStatus_SelsJson","fld":"vTFOPERACOESTITULOSSTATUS_SELSJSON","type":"vchar"},{"av":"AV32TFOperacoesTitulosTipo_SelsJson","fld":"vTFOPERACOESTITULOSTIPO_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavOperacoestitulostipo2"},{"av":"AV20OperacoesTitulosTipo2","fld":"vOPERACOESTITULOSTIPO2","type":"svchar"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavOperacoestitulostipo3"},{"av":"AV23OperacoesTitulosTipo3","fld":"vOPERACOESTITULOSTIPO3","type":"svchar"},{"av":"AV66GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV67GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV68GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV29ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDISPLAY.CLICK","""{"handler":"E28A42","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavOperacoestitulostipo1"},{"av":"AV17OperacoesTitulosTipo1","fld":"vOPERACOESTITULOSTIPO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavOperacoestitulostipo2"},{"av":"AV20OperacoesTitulosTipo2","fld":"vOPERACOESTITULOSTIPO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavOperacoestitulostipo3"},{"av":"AV23OperacoesTitulosTipo3","fld":"vOPERACOESTITULOSTIPO3","type":"svchar"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV77Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV73OperacoesId","fld":"vOPERACOESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV75TFSacadoRazaoSocial","fld":"vTFSACADORAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV76TFSacadoRazaoSocial_Sel","fld":"vTFSACADORAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV33TFOperacoesTitulosTipo_Sels","fld":"vTFOPERACOESTITULOSTIPO_SELS","type":""},{"av":"AV34TFOperacoesTitulosNumero","fld":"vTFOPERACOESTITULOSNUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35TFOperacoesTitulosNumero_To","fld":"vTFOPERACOESTITULOSNUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV36TFOperacoesTitulosDataEmissao","fld":"vTFOPERACOESTITULOSDATAEMISSAO","type":"date"},{"av":"AV37TFOperacoesTitulosDataEmissao_To","fld":"vTFOPERACOESTITULOSDATAEMISSAO_TO","type":"date"},{"av":"AV41TFOperacoesTitulosDataVencimento","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO","type":"date"},{"av":"AV42TFOperacoesTitulosDataVencimento_To","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO_TO","type":"date"},{"av":"AV46TFOperacoesTitulosValor","fld":"vTFOPERACOESTITULOSVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFOperacoesTitulosValor_To","fld":"vTFOPERACOESTITULOSVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFOperacoesTitulosLiquido","fld":"vTFOPERACOESTITULOSLIQUIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFOperacoesTitulosLiquido_To","fld":"vTFOPERACOESTITULOSLIQUIDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV50TFOperacoesTitulosTaxa","fld":"vTFOPERACOESTITULOSTAXA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV51TFOperacoesTitulosTaxa_To","fld":"vTFOPERACOESTITULOSTAXA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV53TFOperacoesTitulosStatus_Sels","fld":"vTFOPERACOESTITULOSSTATUS_SELS","type":""},{"av":"AV54TFOperacoesTitulosCreatedAt","fld":"vTFOPERACOESTITULOSCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFOperacoesTitulosCreatedAt_To","fld":"vTFOPERACOESTITULOSCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFOperacoesTitulosUpdatedAt","fld":"vTFOPERACOESTITULOSUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV60TFOperacoesTitulosUpdatedAt_To","fld":"vTFOPERACOESTITULOSUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV74TrnMode","fld":"vTRNMODE","type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"A1019OperacoesTitulosId","fld":"OPERACOESTITULOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VDISPLAY.CLICK",""","oparms":[{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV66GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV67GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV68GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV29ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("VUPDATE.CLICK","""{"handler":"E29A42","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavOperacoestitulostipo1"},{"av":"AV17OperacoesTitulosTipo1","fld":"vOPERACOESTITULOSTIPO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavOperacoestitulostipo2"},{"av":"AV20OperacoesTitulosTipo2","fld":"vOPERACOESTITULOSTIPO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavOperacoestitulostipo3"},{"av":"AV23OperacoesTitulosTipo3","fld":"vOPERACOESTITULOSTIPO3","type":"svchar"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV77Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV73OperacoesId","fld":"vOPERACOESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV75TFSacadoRazaoSocial","fld":"vTFSACADORAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV76TFSacadoRazaoSocial_Sel","fld":"vTFSACADORAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV33TFOperacoesTitulosTipo_Sels","fld":"vTFOPERACOESTITULOSTIPO_SELS","type":""},{"av":"AV34TFOperacoesTitulosNumero","fld":"vTFOPERACOESTITULOSNUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35TFOperacoesTitulosNumero_To","fld":"vTFOPERACOESTITULOSNUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV36TFOperacoesTitulosDataEmissao","fld":"vTFOPERACOESTITULOSDATAEMISSAO","type":"date"},{"av":"AV37TFOperacoesTitulosDataEmissao_To","fld":"vTFOPERACOESTITULOSDATAEMISSAO_TO","type":"date"},{"av":"AV41TFOperacoesTitulosDataVencimento","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO","type":"date"},{"av":"AV42TFOperacoesTitulosDataVencimento_To","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO_TO","type":"date"},{"av":"AV46TFOperacoesTitulosValor","fld":"vTFOPERACOESTITULOSVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFOperacoesTitulosValor_To","fld":"vTFOPERACOESTITULOSVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFOperacoesTitulosLiquido","fld":"vTFOPERACOESTITULOSLIQUIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFOperacoesTitulosLiquido_To","fld":"vTFOPERACOESTITULOSLIQUIDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV50TFOperacoesTitulosTaxa","fld":"vTFOPERACOESTITULOSTAXA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV51TFOperacoesTitulosTaxa_To","fld":"vTFOPERACOESTITULOSTAXA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV53TFOperacoesTitulosStatus_Sels","fld":"vTFOPERACOESTITULOSSTATUS_SELS","type":""},{"av":"AV54TFOperacoesTitulosCreatedAt","fld":"vTFOPERACOESTITULOSCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFOperacoesTitulosCreatedAt_To","fld":"vTFOPERACOESTITULOSCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFOperacoesTitulosUpdatedAt","fld":"vTFOPERACOESTITULOSUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV60TFOperacoesTitulosUpdatedAt_To","fld":"vTFOPERACOESTITULOSUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV74TrnMode","fld":"vTRNMODE","type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"A1019OperacoesTitulosId","fld":"OPERACOESTITULOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VUPDATE.CLICK",""","oparms":[{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV66GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV67GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV68GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV29ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("VDELETE.CLICK","""{"handler":"E30A42","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavOperacoestitulostipo1"},{"av":"AV17OperacoesTitulosTipo1","fld":"vOPERACOESTITULOSTIPO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavOperacoestitulostipo2"},{"av":"AV20OperacoesTitulosTipo2","fld":"vOPERACOESTITULOSTIPO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavOperacoestitulostipo3"},{"av":"AV23OperacoesTitulosTipo3","fld":"vOPERACOESTITULOSTIPO3","type":"svchar"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV77Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV73OperacoesId","fld":"vOPERACOESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV75TFSacadoRazaoSocial","fld":"vTFSACADORAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV76TFSacadoRazaoSocial_Sel","fld":"vTFSACADORAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV33TFOperacoesTitulosTipo_Sels","fld":"vTFOPERACOESTITULOSTIPO_SELS","type":""},{"av":"AV34TFOperacoesTitulosNumero","fld":"vTFOPERACOESTITULOSNUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35TFOperacoesTitulosNumero_To","fld":"vTFOPERACOESTITULOSNUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV36TFOperacoesTitulosDataEmissao","fld":"vTFOPERACOESTITULOSDATAEMISSAO","type":"date"},{"av":"AV37TFOperacoesTitulosDataEmissao_To","fld":"vTFOPERACOESTITULOSDATAEMISSAO_TO","type":"date"},{"av":"AV41TFOperacoesTitulosDataVencimento","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO","type":"date"},{"av":"AV42TFOperacoesTitulosDataVencimento_To","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO_TO","type":"date"},{"av":"AV46TFOperacoesTitulosValor","fld":"vTFOPERACOESTITULOSVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFOperacoesTitulosValor_To","fld":"vTFOPERACOESTITULOSVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFOperacoesTitulosLiquido","fld":"vTFOPERACOESTITULOSLIQUIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFOperacoesTitulosLiquido_To","fld":"vTFOPERACOESTITULOSLIQUIDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV50TFOperacoesTitulosTaxa","fld":"vTFOPERACOESTITULOSTAXA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV51TFOperacoesTitulosTaxa_To","fld":"vTFOPERACOESTITULOSTAXA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV53TFOperacoesTitulosStatus_Sels","fld":"vTFOPERACOESTITULOSSTATUS_SELS","type":""},{"av":"AV54TFOperacoesTitulosCreatedAt","fld":"vTFOPERACOESTITULOSCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFOperacoesTitulosCreatedAt_To","fld":"vTFOPERACOESTITULOSCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFOperacoesTitulosUpdatedAt","fld":"vTFOPERACOESTITULOSUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV60TFOperacoesTitulosUpdatedAt_To","fld":"vTFOPERACOESTITULOSUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV74TrnMode","fld":"vTRNMODE","type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"A1019OperacoesTitulosId","fld":"OPERACOESTITULOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VDELETE.CLICK",""","oparms":[{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV66GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV67GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV68GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV29ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E18A42","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavOperacoestitulostipo1"},{"av":"AV17OperacoesTitulosTipo1","fld":"vOPERACOESTITULOSTIPO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavOperacoestitulostipo2"},{"av":"AV20OperacoesTitulosTipo2","fld":"vOPERACOESTITULOSTIPO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavOperacoestitulostipo3"},{"av":"AV23OperacoesTitulosTipo3","fld":"vOPERACOESTITULOSTIPO3","type":"svchar"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV77Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV73OperacoesId","fld":"vOPERACOESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV75TFSacadoRazaoSocial","fld":"vTFSACADORAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV76TFSacadoRazaoSocial_Sel","fld":"vTFSACADORAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV33TFOperacoesTitulosTipo_Sels","fld":"vTFOPERACOESTITULOSTIPO_SELS","type":""},{"av":"AV34TFOperacoesTitulosNumero","fld":"vTFOPERACOESTITULOSNUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35TFOperacoesTitulosNumero_To","fld":"vTFOPERACOESTITULOSNUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV36TFOperacoesTitulosDataEmissao","fld":"vTFOPERACOESTITULOSDATAEMISSAO","type":"date"},{"av":"AV37TFOperacoesTitulosDataEmissao_To","fld":"vTFOPERACOESTITULOSDATAEMISSAO_TO","type":"date"},{"av":"AV41TFOperacoesTitulosDataVencimento","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO","type":"date"},{"av":"AV42TFOperacoesTitulosDataVencimento_To","fld":"vTFOPERACOESTITULOSDATAVENCIMENTO_TO","type":"date"},{"av":"AV46TFOperacoesTitulosValor","fld":"vTFOPERACOESTITULOSVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFOperacoesTitulosValor_To","fld":"vTFOPERACOESTITULOSVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFOperacoesTitulosLiquido","fld":"vTFOPERACOESTITULOSLIQUIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV49TFOperacoesTitulosLiquido_To","fld":"vTFOPERACOESTITULOSLIQUIDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV50TFOperacoesTitulosTaxa","fld":"vTFOPERACOESTITULOSTAXA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV51TFOperacoesTitulosTaxa_To","fld":"vTFOPERACOESTITULOSTAXA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV53TFOperacoesTitulosStatus_Sels","fld":"vTFOPERACOESTITULOSSTATUS_SELS","type":""},{"av":"AV54TFOperacoesTitulosCreatedAt","fld":"vTFOPERACOESTITULOSCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV55TFOperacoesTitulosCreatedAt_To","fld":"vTFOPERACOESTITULOSCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFOperacoesTitulosUpdatedAt","fld":"vTFOPERACOESTITULOSUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV60TFOperacoesTitulosUpdatedAt_To","fld":"vTFOPERACOESTITULOSUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV74TrnMode","fld":"vTRNMODE","type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"A1019OperacoesTitulosId","fld":"OPERACOESTITULOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV66GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV67GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV68GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV29ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E19A42","iparms":[]}""");
         setEventMetadata("VALIDV_OPERACOESTITULOSTIPO1","""{"handler":"Validv_Operacoestitulostipo1","iparms":[]}""");
         setEventMetadata("VALIDV_OPERACOESTITULOSTIPO2","""{"handler":"Validv_Operacoestitulostipo2","iparms":[]}""");
         setEventMetadata("VALIDV_OPERACOESTITULOSTIPO3","""{"handler":"Validv_Operacoestitulostipo3","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Operacoestitulosupdatedat","iparms":[]}""");
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
         wcpOAV74TrnMode = "";
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV15FilterFullText = "";
         AV16DynamicFiltersSelector1 = "";
         AV17OperacoesTitulosTipo1 = "";
         AV19DynamicFiltersSelector2 = "";
         AV20OperacoesTitulosTipo2 = "";
         AV22DynamicFiltersSelector3 = "";
         AV23OperacoesTitulosTipo3 = "";
         AV77Pgmname = "";
         AV75TFSacadoRazaoSocial = "";
         AV76TFSacadoRazaoSocial_Sel = "";
         AV33TFOperacoesTitulosTipo_Sels = new GxSimpleCollection<string>();
         AV36TFOperacoesTitulosDataEmissao = DateTime.MinValue;
         AV37TFOperacoesTitulosDataEmissao_To = DateTime.MinValue;
         AV41TFOperacoesTitulosDataVencimento = DateTime.MinValue;
         AV42TFOperacoesTitulosDataVencimento_To = DateTime.MinValue;
         AV53TFOperacoesTitulosStatus_Sels = new GxSimpleCollection<string>();
         AV54TFOperacoesTitulosCreatedAt = (DateTime)(DateTime.MinValue);
         AV55TFOperacoesTitulosCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV59TFOperacoesTitulosUpdatedAt = (DateTime)(DateTime.MinValue);
         AV60TFOperacoesTitulosUpdatedAt_To = (DateTime)(DateTime.MinValue);
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV29ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV68GridAppliedFilters = "";
         AV64DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV38DDO_OperacoesTitulosDataEmissaoAuxDate = DateTime.MinValue;
         AV39DDO_OperacoesTitulosDataEmissaoAuxDateTo = DateTime.MinValue;
         AV43DDO_OperacoesTitulosDataVencimentoAuxDate = DateTime.MinValue;
         AV44DDO_OperacoesTitulosDataVencimentoAuxDateTo = DateTime.MinValue;
         AV56DDO_OperacoesTitulosCreatedAtAuxDate = DateTime.MinValue;
         AV57DDO_OperacoesTitulosCreatedAtAuxDateTo = DateTime.MinValue;
         AV61DDO_OperacoesTitulosUpdatedAtAuxDate = DateTime.MinValue;
         AV62DDO_OperacoesTitulosUpdatedAtAuxDateTo = DateTime.MinValue;
         AV32TFOperacoesTitulosTipo_SelsJson = "";
         AV52TFOperacoesTitulosStatus_SelsJson = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
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
         AV40DDO_OperacoesTitulosDataEmissaoAuxDateText = "";
         ucTfoperacoestitulosdataemissao_rangepicker = new GXUserControl();
         AV45DDO_OperacoesTitulosDataVencimentoAuxDateText = "";
         ucTfoperacoestitulosdatavencimento_rangepicker = new GXUserControl();
         AV58DDO_OperacoesTitulosCreatedAtAuxDateText = "";
         ucTfoperacoestituloscreatedat_rangepicker = new GXUserControl();
         AV63DDO_OperacoesTitulosUpdatedAtAuxDateText = "";
         ucTfoperacoestitulosupdatedat_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV69Display = "";
         AV70Update = "";
         AV71Delete = "";
         A1035SacadoRazaoSocial = "";
         A1020OperacoesTitulosTipo = "";
         A1022OperacoesTitulosDataEmissao = DateTime.MinValue;
         A1023OperacoesTitulosDataVencimento = DateTime.MinValue;
         A1027OperacoesTitulosStatus = "";
         A1028OperacoesTitulosCreatedAt = (DateTime)(DateTime.MinValue);
         A1029OperacoesTitulosUpdatedAt = (DateTime)(DateTime.MinValue);
         GXDecQS = "";
         AV90Operacoestituloswwds_13_tfoperacoestitulostipo_sels = new GxSimpleCollection<string>();
         AV103Operacoestituloswwds_26_tfoperacoestitulosstatus_sels = new GxSimpleCollection<string>();
         lV79Operacoestituloswwds_2_filterfulltext = "";
         lV88Operacoestituloswwds_11_tfsacadorazaosocial = "";
         AV79Operacoestituloswwds_2_filterfulltext = "";
         AV80Operacoestituloswwds_3_dynamicfiltersselector1 = "";
         AV81Operacoestituloswwds_4_operacoestitulostipo1 = "";
         AV83Operacoestituloswwds_6_dynamicfiltersselector2 = "";
         AV84Operacoestituloswwds_7_operacoestitulostipo2 = "";
         AV86Operacoestituloswwds_9_dynamicfiltersselector3 = "";
         AV87Operacoestituloswwds_10_operacoestitulostipo3 = "";
         AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel = "";
         AV88Operacoestituloswwds_11_tfsacadorazaosocial = "";
         AV93Operacoestituloswwds_16_tfoperacoestitulosdataemissao = DateTime.MinValue;
         AV94Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to = DateTime.MinValue;
         AV95Operacoestituloswwds_18_tfoperacoestitulosdatavencimento = DateTime.MinValue;
         AV96Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to = DateTime.MinValue;
         AV104Operacoestituloswwds_27_tfoperacoestituloscreatedat = (DateTime)(DateTime.MinValue);
         AV105Operacoestituloswwds_28_tfoperacoestituloscreatedat_to = (DateTime)(DateTime.MinValue);
         AV106Operacoestituloswwds_29_tfoperacoestitulosupdatedat = (DateTime)(DateTime.MinValue);
         AV107Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to = (DateTime)(DateTime.MinValue);
         H00A42_A1034SacadoId = new int[1] ;
         H00A42_n1034SacadoId = new bool[] {false} ;
         H00A42_A1029OperacoesTitulosUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         H00A42_n1029OperacoesTitulosUpdatedAt = new bool[] {false} ;
         H00A42_A1028OperacoesTitulosCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H00A42_n1028OperacoesTitulosCreatedAt = new bool[] {false} ;
         H00A42_A1027OperacoesTitulosStatus = new string[] {""} ;
         H00A42_n1027OperacoesTitulosStatus = new bool[] {false} ;
         H00A42_A1026OperacoesTitulosTaxa = new decimal[1] ;
         H00A42_n1026OperacoesTitulosTaxa = new bool[] {false} ;
         H00A42_A1025OperacoesTitulosLiquido = new decimal[1] ;
         H00A42_n1025OperacoesTitulosLiquido = new bool[] {false} ;
         H00A42_A1024OperacoesTitulosValor = new decimal[1] ;
         H00A42_n1024OperacoesTitulosValor = new bool[] {false} ;
         H00A42_A1023OperacoesTitulosDataVencimento = new DateTime[] {DateTime.MinValue} ;
         H00A42_n1023OperacoesTitulosDataVencimento = new bool[] {false} ;
         H00A42_A1022OperacoesTitulosDataEmissao = new DateTime[] {DateTime.MinValue} ;
         H00A42_n1022OperacoesTitulosDataEmissao = new bool[] {false} ;
         H00A42_A1021OperacoesTitulosNumero = new int[1] ;
         H00A42_n1021OperacoesTitulosNumero = new bool[] {false} ;
         H00A42_A1020OperacoesTitulosTipo = new string[] {""} ;
         H00A42_n1020OperacoesTitulosTipo = new bool[] {false} ;
         H00A42_A1010OperacoesId = new int[1] ;
         H00A42_n1010OperacoesId = new bool[] {false} ;
         H00A42_A1019OperacoesTitulosId = new int[1] ;
         H00A42_A1035SacadoRazaoSocial = new string[] {""} ;
         H00A42_n1035SacadoRazaoSocial = new bool[] {false} ;
         H00A43_AGRID_nRecordCount = new long[1] ;
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV30ManageFiltersXml = "";
         AV26ExcelFilename = "";
         AV27ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV28Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char4 = "";
         GXt_char5 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV72AuxText = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         imgRemovedynamicfilters3_gximage = "";
         sImgUrl = "";
         imgAdddynamicfilters2_gximage = "";
         imgRemovedynamicfilters2_gximage = "";
         imgAdddynamicfilters1_gximage = "";
         imgRemovedynamicfilters1_gximage = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV73OperacoesId = "";
         sCtrlAV74TrnMode = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.operacoestitulosww__default(),
            new Object[][] {
                new Object[] {
               H00A42_A1034SacadoId, H00A42_n1034SacadoId, H00A42_A1029OperacoesTitulosUpdatedAt, H00A42_n1029OperacoesTitulosUpdatedAt, H00A42_A1028OperacoesTitulosCreatedAt, H00A42_n1028OperacoesTitulosCreatedAt, H00A42_A1027OperacoesTitulosStatus, H00A42_n1027OperacoesTitulosStatus, H00A42_A1026OperacoesTitulosTaxa, H00A42_n1026OperacoesTitulosTaxa,
               H00A42_A1025OperacoesTitulosLiquido, H00A42_n1025OperacoesTitulosLiquido, H00A42_A1024OperacoesTitulosValor, H00A42_n1024OperacoesTitulosValor, H00A42_A1023OperacoesTitulosDataVencimento, H00A42_n1023OperacoesTitulosDataVencimento, H00A42_A1022OperacoesTitulosDataEmissao, H00A42_n1022OperacoesTitulosDataEmissao, H00A42_A1021OperacoesTitulosNumero, H00A42_n1021OperacoesTitulosNumero,
               H00A42_A1020OperacoesTitulosTipo, H00A42_n1020OperacoesTitulosTipo, H00A42_A1010OperacoesId, H00A42_n1010OperacoesId, H00A42_A1019OperacoesTitulosId, H00A42_A1035SacadoRazaoSocial, H00A42_n1035SacadoRazaoSocial
               }
               , new Object[] {
               H00A43_AGRID_nRecordCount
               }
            }
         );
         AV77Pgmname = "OperacoesTitulosWW";
         /* GeneXus formulas. */
         AV77Pgmname = "OperacoesTitulosWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV13OrderedBy ;
      private short AV31ManageFiltersExecutionStep ;
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
      private int AV73OperacoesId ;
      private int wcpOAV73OperacoesId ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_98 ;
      private int nGXsfl_98_idx=1 ;
      private int AV34TFOperacoesTitulosNumero ;
      private int AV35TFOperacoesTitulosNumero_To ;
      private int edtavDisplay_Enabled ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int A1019OperacoesTitulosId ;
      private int A1010OperacoesId ;
      private int A1021OperacoesTitulosNumero ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV90Operacoestituloswwds_13_tfoperacoestitulostipo_sels_Count ;
      private int AV103Operacoestituloswwds_26_tfoperacoestitulosstatus_sels_Count ;
      private int AV91Operacoestituloswwds_14_tfoperacoestitulosnumero ;
      private int AV92Operacoestituloswwds_15_tfoperacoestitulosnumero_to ;
      private int AV78Operacoestituloswwds_1_operacoesid ;
      private int A1034SacadoId ;
      private int edtSacadoRazaoSocial_Enabled ;
      private int edtOperacoesTitulosId_Enabled ;
      private int edtOperacoesId_Enabled ;
      private int edtOperacoesTitulosNumero_Enabled ;
      private int edtOperacoesTitulosDataEmissao_Enabled ;
      private int edtOperacoesTitulosDataVencimento_Enabled ;
      private int edtOperacoesTitulosValor_Enabled ;
      private int edtOperacoesTitulosLiquido_Enabled ;
      private int edtOperacoesTitulosTaxa_Enabled ;
      private int edtOperacoesTitulosCreatedAt_Enabled ;
      private int edtOperacoesTitulosUpdatedAt_Enabled ;
      private int AV65PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int AV108GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV66GridCurrentPage ;
      private long AV67GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV46TFOperacoesTitulosValor ;
      private decimal AV47TFOperacoesTitulosValor_To ;
      private decimal AV48TFOperacoesTitulosLiquido ;
      private decimal AV49TFOperacoesTitulosLiquido_To ;
      private decimal AV50TFOperacoesTitulosTaxa ;
      private decimal AV51TFOperacoesTitulosTaxa_To ;
      private decimal A1024OperacoesTitulosValor ;
      private decimal A1025OperacoesTitulosLiquido ;
      private decimal A1026OperacoesTitulosTaxa ;
      private decimal AV97Operacoestituloswwds_20_tfoperacoestitulosvalor ;
      private decimal AV98Operacoestituloswwds_21_tfoperacoestitulosvalor_to ;
      private decimal AV99Operacoestituloswwds_22_tfoperacoestitulosliquido ;
      private decimal AV100Operacoestituloswwds_23_tfoperacoestitulosliquido_to ;
      private decimal AV101Operacoestituloswwds_24_tfoperacoestitulostaxa ;
      private decimal AV102Operacoestituloswwds_25_tfoperacoestitulostaxa_to ;
      private string AV74TrnMode ;
      private string wcpOAV74TrnMode ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_98_idx="0001" ;
      private string AV77Pgmname ;
      private string edtavDisplay_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
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
      private string divDdo_operacoestitulosdataemissaoauxdates_Internalname ;
      private string edtavDdo_operacoestitulosdataemissaoauxdatetext_Internalname ;
      private string edtavDdo_operacoestitulosdataemissaoauxdatetext_Jsonclick ;
      private string Tfoperacoestitulosdataemissao_rangepicker_Internalname ;
      private string divDdo_operacoestitulosdatavencimentoauxdates_Internalname ;
      private string edtavDdo_operacoestitulosdatavencimentoauxdatetext_Internalname ;
      private string edtavDdo_operacoestitulosdatavencimentoauxdatetext_Jsonclick ;
      private string Tfoperacoestitulosdatavencimento_rangepicker_Internalname ;
      private string divDdo_operacoestituloscreatedatauxdates_Internalname ;
      private string edtavDdo_operacoestituloscreatedatauxdatetext_Internalname ;
      private string edtavDdo_operacoestituloscreatedatauxdatetext_Jsonclick ;
      private string Tfoperacoestituloscreatedat_rangepicker_Internalname ;
      private string divDdo_operacoestitulosupdatedatauxdates_Internalname ;
      private string edtavDdo_operacoestitulosupdatedatauxdatetext_Internalname ;
      private string edtavDdo_operacoestitulosupdatedatauxdatetext_Jsonclick ;
      private string Tfoperacoestitulosupdatedat_rangepicker_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV69Display ;
      private string AV70Update ;
      private string AV71Delete ;
      private string edtSacadoRazaoSocial_Internalname ;
      private string edtOperacoesTitulosId_Internalname ;
      private string edtOperacoesId_Internalname ;
      private string cmbOperacoesTitulosTipo_Internalname ;
      private string edtOperacoesTitulosNumero_Internalname ;
      private string edtOperacoesTitulosDataEmissao_Internalname ;
      private string edtOperacoesTitulosDataVencimento_Internalname ;
      private string edtOperacoesTitulosValor_Internalname ;
      private string edtOperacoesTitulosLiquido_Internalname ;
      private string edtOperacoesTitulosTaxa_Internalname ;
      private string cmbOperacoesTitulosStatus_Internalname ;
      private string edtOperacoesTitulosCreatedAt_Internalname ;
      private string edtOperacoesTitulosUpdatedAt_Internalname ;
      private string GXDecQS ;
      private string cmbavOperacoestitulostipo1_Internalname ;
      private string cmbavOperacoestitulostipo2_Internalname ;
      private string cmbavOperacoestitulostipo3_Internalname ;
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
      private string edtavUpdate_Class ;
      private string edtavDelete_Class ;
      private string GXt_char2 ;
      private string GXt_char4 ;
      private string GXt_char5 ;
      private string tblUnnamedtabledynamicfilters_3_Internalname ;
      private string cellFilter_operacoestitulostipo3_cell_Internalname ;
      private string cmbavOperacoestitulostipo3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblUnnamedtabledynamicfilters_2_Internalname ;
      private string cellFilter_operacoestitulostipo2_cell_Internalname ;
      private string cmbavOperacoestitulostipo2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblUnnamedtabledynamicfilters_1_Internalname ;
      private string cellFilter_operacoestitulostipo1_cell_Internalname ;
      private string cmbavOperacoestitulostipo1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sCtrlAV73OperacoesId ;
      private string sCtrlAV74TrnMode ;
      private string sGXsfl_98_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDisplay_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtSacadoRazaoSocial_Jsonclick ;
      private string edtOperacoesTitulosId_Jsonclick ;
      private string edtOperacoesId_Jsonclick ;
      private string GXCCtl ;
      private string cmbOperacoesTitulosTipo_Jsonclick ;
      private string edtOperacoesTitulosNumero_Jsonclick ;
      private string edtOperacoesTitulosDataEmissao_Jsonclick ;
      private string edtOperacoesTitulosDataVencimento_Jsonclick ;
      private string edtOperacoesTitulosValor_Jsonclick ;
      private string edtOperacoesTitulosLiquido_Jsonclick ;
      private string edtOperacoesTitulosTaxa_Jsonclick ;
      private string cmbOperacoesTitulosStatus_Jsonclick ;
      private string edtOperacoesTitulosCreatedAt_Jsonclick ;
      private string edtOperacoesTitulosUpdatedAt_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV54TFOperacoesTitulosCreatedAt ;
      private DateTime AV55TFOperacoesTitulosCreatedAt_To ;
      private DateTime AV59TFOperacoesTitulosUpdatedAt ;
      private DateTime AV60TFOperacoesTitulosUpdatedAt_To ;
      private DateTime A1028OperacoesTitulosCreatedAt ;
      private DateTime A1029OperacoesTitulosUpdatedAt ;
      private DateTime AV104Operacoestituloswwds_27_tfoperacoestituloscreatedat ;
      private DateTime AV105Operacoestituloswwds_28_tfoperacoestituloscreatedat_to ;
      private DateTime AV106Operacoestituloswwds_29_tfoperacoestitulosupdatedat ;
      private DateTime AV107Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to ;
      private DateTime AV36TFOperacoesTitulosDataEmissao ;
      private DateTime AV37TFOperacoesTitulosDataEmissao_To ;
      private DateTime AV41TFOperacoesTitulosDataVencimento ;
      private DateTime AV42TFOperacoesTitulosDataVencimento_To ;
      private DateTime AV38DDO_OperacoesTitulosDataEmissaoAuxDate ;
      private DateTime AV39DDO_OperacoesTitulosDataEmissaoAuxDateTo ;
      private DateTime AV43DDO_OperacoesTitulosDataVencimentoAuxDate ;
      private DateTime AV44DDO_OperacoesTitulosDataVencimentoAuxDateTo ;
      private DateTime AV56DDO_OperacoesTitulosCreatedAtAuxDate ;
      private DateTime AV57DDO_OperacoesTitulosCreatedAtAuxDateTo ;
      private DateTime AV61DDO_OperacoesTitulosUpdatedAtAuxDate ;
      private DateTime AV62DDO_OperacoesTitulosUpdatedAtAuxDateTo ;
      private DateTime A1022OperacoesTitulosDataEmissao ;
      private DateTime A1023OperacoesTitulosDataVencimento ;
      private DateTime AV93Operacoestituloswwds_16_tfoperacoestitulosdataemissao ;
      private DateTime AV94Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to ;
      private DateTime AV95Operacoestituloswwds_18_tfoperacoestitulosdatavencimento ;
      private DateTime AV96Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV21DynamicFiltersEnabled3 ;
      private bool AV25DynamicFiltersIgnoreFirst ;
      private bool AV24DynamicFiltersRemoving ;
      private bool bGXsfl_98_Refreshing=false ;
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
      private bool n1035SacadoRazaoSocial ;
      private bool n1010OperacoesId ;
      private bool n1020OperacoesTitulosTipo ;
      private bool n1021OperacoesTitulosNumero ;
      private bool n1022OperacoesTitulosDataEmissao ;
      private bool n1023OperacoesTitulosDataVencimento ;
      private bool n1024OperacoesTitulosValor ;
      private bool n1025OperacoesTitulosLiquido ;
      private bool n1026OperacoesTitulosTaxa ;
      private bool n1027OperacoesTitulosStatus ;
      private bool n1028OperacoesTitulosCreatedAt ;
      private bool n1029OperacoesTitulosUpdatedAt ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV82Operacoestituloswwds_5_dynamicfiltersenabled2 ;
      private bool AV85Operacoestituloswwds_8_dynamicfiltersenabled3 ;
      private bool n1034SacadoId ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV32TFOperacoesTitulosTipo_SelsJson ;
      private string AV52TFOperacoesTitulosStatus_SelsJson ;
      private string AV30ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV17OperacoesTitulosTipo1 ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV20OperacoesTitulosTipo2 ;
      private string AV22DynamicFiltersSelector3 ;
      private string AV23OperacoesTitulosTipo3 ;
      private string AV75TFSacadoRazaoSocial ;
      private string AV76TFSacadoRazaoSocial_Sel ;
      private string AV68GridAppliedFilters ;
      private string AV40DDO_OperacoesTitulosDataEmissaoAuxDateText ;
      private string AV45DDO_OperacoesTitulosDataVencimentoAuxDateText ;
      private string AV58DDO_OperacoesTitulosCreatedAtAuxDateText ;
      private string AV63DDO_OperacoesTitulosUpdatedAtAuxDateText ;
      private string A1035SacadoRazaoSocial ;
      private string A1020OperacoesTitulosTipo ;
      private string A1027OperacoesTitulosStatus ;
      private string lV79Operacoestituloswwds_2_filterfulltext ;
      private string lV88Operacoestituloswwds_11_tfsacadorazaosocial ;
      private string AV79Operacoestituloswwds_2_filterfulltext ;
      private string AV80Operacoestituloswwds_3_dynamicfiltersselector1 ;
      private string AV81Operacoestituloswwds_4_operacoestitulostipo1 ;
      private string AV83Operacoestituloswwds_6_dynamicfiltersselector2 ;
      private string AV84Operacoestituloswwds_7_operacoestitulostipo2 ;
      private string AV86Operacoestituloswwds_9_dynamicfiltersselector3 ;
      private string AV87Operacoestituloswwds_10_operacoestitulostipo3 ;
      private string AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel ;
      private string AV88Operacoestituloswwds_11_tfsacadorazaosocial ;
      private string AV26ExcelFilename ;
      private string AV27ErrorMessage ;
      private string AV72AuxText ;
      private IGxSession AV28Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfoperacoestitulosdataemissao_rangepicker ;
      private GXUserControl ucTfoperacoestitulosdatavencimento_rangepicker ;
      private GXUserControl ucTfoperacoestituloscreatedat_rangepicker ;
      private GXUserControl ucTfoperacoestitulosupdatedat_rangepicker ;
      private GXWebForm Form ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavOperacoestitulostipo1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavOperacoestitulostipo2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavOperacoestitulostipo3 ;
      private GXCombobox cmbOperacoesTitulosTipo ;
      private GXCombobox cmbOperacoesTitulosStatus ;
      private GxSimpleCollection<string> AV33TFOperacoesTitulosTipo_Sels ;
      private GxSimpleCollection<string> AV53TFOperacoesTitulosStatus_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV29ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV64DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV90Operacoestituloswwds_13_tfoperacoestitulostipo_sels ;
      private GxSimpleCollection<string> AV103Operacoestituloswwds_26_tfoperacoestitulosstatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] H00A42_A1034SacadoId ;
      private bool[] H00A42_n1034SacadoId ;
      private DateTime[] H00A42_A1029OperacoesTitulosUpdatedAt ;
      private bool[] H00A42_n1029OperacoesTitulosUpdatedAt ;
      private DateTime[] H00A42_A1028OperacoesTitulosCreatedAt ;
      private bool[] H00A42_n1028OperacoesTitulosCreatedAt ;
      private string[] H00A42_A1027OperacoesTitulosStatus ;
      private bool[] H00A42_n1027OperacoesTitulosStatus ;
      private decimal[] H00A42_A1026OperacoesTitulosTaxa ;
      private bool[] H00A42_n1026OperacoesTitulosTaxa ;
      private decimal[] H00A42_A1025OperacoesTitulosLiquido ;
      private bool[] H00A42_n1025OperacoesTitulosLiquido ;
      private decimal[] H00A42_A1024OperacoesTitulosValor ;
      private bool[] H00A42_n1024OperacoesTitulosValor ;
      private DateTime[] H00A42_A1023OperacoesTitulosDataVencimento ;
      private bool[] H00A42_n1023OperacoesTitulosDataVencimento ;
      private DateTime[] H00A42_A1022OperacoesTitulosDataEmissao ;
      private bool[] H00A42_n1022OperacoesTitulosDataEmissao ;
      private int[] H00A42_A1021OperacoesTitulosNumero ;
      private bool[] H00A42_n1021OperacoesTitulosNumero ;
      private string[] H00A42_A1020OperacoesTitulosTipo ;
      private bool[] H00A42_n1020OperacoesTitulosTipo ;
      private int[] H00A42_A1010OperacoesId ;
      private bool[] H00A42_n1010OperacoesId ;
      private int[] H00A42_A1019OperacoesTitulosId ;
      private string[] H00A42_A1035SacadoRazaoSocial ;
      private bool[] H00A42_n1035SacadoRazaoSocial ;
      private long[] H00A43_AGRID_nRecordCount ;
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

   public class operacoestitulosww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00A42( IGxContext context ,
                                             string A1020OperacoesTitulosTipo ,
                                             GxSimpleCollection<string> AV90Operacoestituloswwds_13_tfoperacoestitulostipo_sels ,
                                             string A1027OperacoesTitulosStatus ,
                                             GxSimpleCollection<string> AV103Operacoestituloswwds_26_tfoperacoestitulosstatus_sels ,
                                             string AV79Operacoestituloswwds_2_filterfulltext ,
                                             string AV80Operacoestituloswwds_3_dynamicfiltersselector1 ,
                                             string AV81Operacoestituloswwds_4_operacoestitulostipo1 ,
                                             bool AV82Operacoestituloswwds_5_dynamicfiltersenabled2 ,
                                             string AV83Operacoestituloswwds_6_dynamicfiltersselector2 ,
                                             string AV84Operacoestituloswwds_7_operacoestitulostipo2 ,
                                             bool AV85Operacoestituloswwds_8_dynamicfiltersenabled3 ,
                                             string AV86Operacoestituloswwds_9_dynamicfiltersselector3 ,
                                             string AV87Operacoestituloswwds_10_operacoestitulostipo3 ,
                                             string AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel ,
                                             string AV88Operacoestituloswwds_11_tfsacadorazaosocial ,
                                             int AV90Operacoestituloswwds_13_tfoperacoestitulostipo_sels_Count ,
                                             int AV91Operacoestituloswwds_14_tfoperacoestitulosnumero ,
                                             int AV92Operacoestituloswwds_15_tfoperacoestitulosnumero_to ,
                                             DateTime AV93Operacoestituloswwds_16_tfoperacoestitulosdataemissao ,
                                             DateTime AV94Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to ,
                                             DateTime AV95Operacoestituloswwds_18_tfoperacoestitulosdatavencimento ,
                                             DateTime AV96Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to ,
                                             decimal AV97Operacoestituloswwds_20_tfoperacoestitulosvalor ,
                                             decimal AV98Operacoestituloswwds_21_tfoperacoestitulosvalor_to ,
                                             decimal AV99Operacoestituloswwds_22_tfoperacoestitulosliquido ,
                                             decimal AV100Operacoestituloswwds_23_tfoperacoestitulosliquido_to ,
                                             decimal AV101Operacoestituloswwds_24_tfoperacoestitulostaxa ,
                                             decimal AV102Operacoestituloswwds_25_tfoperacoestitulostaxa_to ,
                                             int AV103Operacoestituloswwds_26_tfoperacoestitulosstatus_sels_Count ,
                                             DateTime AV104Operacoestituloswwds_27_tfoperacoestituloscreatedat ,
                                             DateTime AV105Operacoestituloswwds_28_tfoperacoestituloscreatedat_to ,
                                             DateTime AV106Operacoestituloswwds_29_tfoperacoestitulosupdatedat ,
                                             DateTime AV107Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to ,
                                             string A1035SacadoRazaoSocial ,
                                             int A1021OperacoesTitulosNumero ,
                                             decimal A1024OperacoesTitulosValor ,
                                             decimal A1025OperacoesTitulosLiquido ,
                                             decimal A1026OperacoesTitulosTaxa ,
                                             DateTime A1022OperacoesTitulosDataEmissao ,
                                             DateTime A1023OperacoesTitulosDataVencimento ,
                                             DateTime A1028OperacoesTitulosCreatedAt ,
                                             DateTime A1029OperacoesTitulosUpdatedAt ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             int A1010OperacoesId ,
                                             int AV78Operacoestituloswwds_1_operacoesid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[38];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.SacadoId AS SacadoId, T1.OperacoesTitulosUpdatedAt, T1.OperacoesTitulosCreatedAt, T1.OperacoesTitulosStatus, T1.OperacoesTitulosTaxa, T1.OperacoesTitulosLiquido, T1.OperacoesTitulosValor, T1.OperacoesTitulosDataVencimento, T1.OperacoesTitulosDataEmissao, T1.OperacoesTitulosNumero, T1.OperacoesTitulosTipo, T1.OperacoesId, T1.OperacoesTitulosId, T2.ClienteRazaoSocial AS SacadoRazaoSocial";
         sFromString = " FROM (OperacoesTitulos T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.SacadoId)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.OperacoesId = :AV78Operacoestituloswwds_1_operacoesid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ClienteRazaoSocial like '%' || :lV79Operacoestituloswwds_2_filterfulltext) or ( 'na' like '%' || LOWER(:lV79Operacoestituloswwds_2_filterfulltext) and (char_length(trim(trailing ' ' from T1.OperacoesTitulosTipo))=0)) or ( 'nota fiscal' like '%' || LOWER(:lV79Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosTipo = ( 'NOTA_FISCAL')) or ( 'rpa' like '%' || LOWER(:lV79Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosTipo = ( 'RPA')) or ( SUBSTR(TO_CHAR(T1.OperacoesTitulosNumero,'999999999'), 2) like '%' || :lV79Operacoestituloswwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.OperacoesTitulosValor,'999999999999990.99'), 2) like '%' || :lV79Operacoestituloswwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.OperacoesTitulosLiquido,'999999999999990.99'), 2) like '%' || :lV79Operacoestituloswwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.OperacoesTitulosTaxa,'99999999990.9999'), 2) like '%' || :lV79Operacoestituloswwds_2_filterfulltext) or ( 'pendente' like '%' || LOWER(:lV79Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosStatus = ( 'PENDENTE')) or ( 'aceito' like '%' || LOWER(:lV79Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosStatus = ( 'ACEITO')) or ( 'recusado' like '%' || LOWER(:lV79Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosStatus = ( 'RECUSADO')) or ( 'vencido' like '%' || LOWER(:lV79Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosStatus = ( 'VENCIDO')) or ( 'liquidado' like '%' || LOWER(:lV79Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosStatus = ( 'LIQUIDADO')))");
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
            GXv_int6[10] = 1;
            GXv_int6[11] = 1;
            GXv_int6[12] = 1;
            GXv_int6[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV80Operacoestituloswwds_3_dynamicfiltersselector1, "OPERACOESTITULOSTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Operacoestituloswwds_4_operacoestitulostipo1)) ) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosTipo = ( :AV81Operacoestituloswwds_4_operacoestitulostipo1))");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( AV82Operacoestituloswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV83Operacoestituloswwds_6_dynamicfiltersselector2, "OPERACOESTITULOSTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Operacoestituloswwds_7_operacoestitulostipo2)) ) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosTipo = ( :AV84Operacoestituloswwds_7_operacoestitulostipo2))");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( AV85Operacoestituloswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Operacoestituloswwds_9_dynamicfiltersselector3, "OPERACOESTITULOSTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Operacoestituloswwds_10_operacoestitulostipo3)) ) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosTipo = ( :AV87Operacoestituloswwds_10_operacoestitulostipo3))");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Operacoestituloswwds_11_tfsacadorazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV88Operacoestituloswwds_11_tfsacadorazaosocial)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel)) && ! ( StringUtil.StrCmp(AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel))");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( StringUtil.StrCmp(AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( AV90Operacoestituloswwds_13_tfoperacoestitulostipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV90Operacoestituloswwds_13_tfoperacoestitulostipo_sels, "T1.OperacoesTitulosTipo IN (", ")")+")");
         }
         if ( ! (0==AV91Operacoestituloswwds_14_tfoperacoestitulosnumero) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosNumero >= :AV91Operacoestituloswwds_14_tfoperacoestitulosnumero)");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( ! (0==AV92Operacoestituloswwds_15_tfoperacoestitulosnumero_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosNumero <= :AV92Operacoestituloswwds_15_tfoperacoestitulosnumero_to)");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV93Operacoestituloswwds_16_tfoperacoestitulosdataemissao) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosDataEmissao >= :AV93Operacoestituloswwds_16_tfoperacoestitulosdataemissao)");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosDataEmissao <= :AV94Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to)");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV95Operacoestituloswwds_18_tfoperacoestitulosdatavencimento) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosDataVencimento >= :AV95Operacoestituloswwds_18_tfoperacoestitulosdatavencimento)");
         }
         else
         {
            GXv_int6[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV96Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosDataVencimento <= :AV96Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to)");
         }
         else
         {
            GXv_int6[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV97Operacoestituloswwds_20_tfoperacoestitulosvalor) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosValor >= :AV97Operacoestituloswwds_20_tfoperacoestitulosvalor)");
         }
         else
         {
            GXv_int6[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV98Operacoestituloswwds_21_tfoperacoestitulosvalor_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosValor <= :AV98Operacoestituloswwds_21_tfoperacoestitulosvalor_to)");
         }
         else
         {
            GXv_int6[26] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV99Operacoestituloswwds_22_tfoperacoestitulosliquido) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosLiquido >= :AV99Operacoestituloswwds_22_tfoperacoestitulosliquido)");
         }
         else
         {
            GXv_int6[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV100Operacoestituloswwds_23_tfoperacoestitulosliquido_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosLiquido <= :AV100Operacoestituloswwds_23_tfoperacoestitulosliquido_to)");
         }
         else
         {
            GXv_int6[28] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV101Operacoestituloswwds_24_tfoperacoestitulostaxa) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosTaxa >= :AV101Operacoestituloswwds_24_tfoperacoestitulostaxa)");
         }
         else
         {
            GXv_int6[29] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV102Operacoestituloswwds_25_tfoperacoestitulostaxa_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosTaxa <= :AV102Operacoestituloswwds_25_tfoperacoestitulostaxa_to)");
         }
         else
         {
            GXv_int6[30] = 1;
         }
         if ( AV103Operacoestituloswwds_26_tfoperacoestitulosstatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV103Operacoestituloswwds_26_tfoperacoestitulosstatus_sels, "T1.OperacoesTitulosStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV104Operacoestituloswwds_27_tfoperacoestituloscreatedat) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosCreatedAt >= :AV104Operacoestituloswwds_27_tfoperacoestituloscreatedat)");
         }
         else
         {
            GXv_int6[31] = 1;
         }
         if ( ! (DateTime.MinValue==AV105Operacoestituloswwds_28_tfoperacoestituloscreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosCreatedAt <= :AV105Operacoestituloswwds_28_tfoperacoestituloscreatedat_to)");
         }
         else
         {
            GXv_int6[32] = 1;
         }
         if ( ! (DateTime.MinValue==AV106Operacoestituloswwds_29_tfoperacoestitulosupdatedat) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosUpdatedAt >= :AV106Operacoestituloswwds_29_tfoperacoestitulosupdatedat)");
         }
         else
         {
            GXv_int6[33] = 1;
         }
         if ( ! (DateTime.MinValue==AV107Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosUpdatedAt <= :AV107Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to)");
         }
         else
         {
            GXv_int6[34] = 1;
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.OperacoesId, T1.OperacoesTitulosDataVencimento, T1.OperacoesTitulosId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.OperacoesId DESC, T1.OperacoesTitulosDataVencimento DESC, T1.OperacoesTitulosId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.OperacoesId, T2.ClienteRazaoSocial, T1.OperacoesTitulosId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.OperacoesId DESC, T2.ClienteRazaoSocial DESC, T1.OperacoesTitulosId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.OperacoesId, T1.OperacoesTitulosTipo, T1.OperacoesTitulosId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.OperacoesId DESC, T1.OperacoesTitulosTipo DESC, T1.OperacoesTitulosId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.OperacoesId, T1.OperacoesTitulosNumero, T1.OperacoesTitulosId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.OperacoesId DESC, T1.OperacoesTitulosNumero DESC, T1.OperacoesTitulosId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.OperacoesId, T1.OperacoesTitulosDataEmissao, T1.OperacoesTitulosId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.OperacoesId DESC, T1.OperacoesTitulosDataEmissao DESC, T1.OperacoesTitulosId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.OperacoesId, T1.OperacoesTitulosValor, T1.OperacoesTitulosId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.OperacoesId DESC, T1.OperacoesTitulosValor DESC, T1.OperacoesTitulosId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.OperacoesId, T1.OperacoesTitulosLiquido, T1.OperacoesTitulosId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.OperacoesId DESC, T1.OperacoesTitulosLiquido DESC, T1.OperacoesTitulosId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.OperacoesId, T1.OperacoesTitulosTaxa, T1.OperacoesTitulosId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.OperacoesId DESC, T1.OperacoesTitulosTaxa DESC, T1.OperacoesTitulosId";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.OperacoesId, T1.OperacoesTitulosStatus, T1.OperacoesTitulosId";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.OperacoesId DESC, T1.OperacoesTitulosStatus DESC, T1.OperacoesTitulosId";
         }
         else if ( ( AV13OrderedBy == 10 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.OperacoesId, T1.OperacoesTitulosCreatedAt, T1.OperacoesTitulosId";
         }
         else if ( ( AV13OrderedBy == 10 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.OperacoesId DESC, T1.OperacoesTitulosCreatedAt DESC, T1.OperacoesTitulosId";
         }
         else if ( ( AV13OrderedBy == 11 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.OperacoesId, T1.OperacoesTitulosUpdatedAt, T1.OperacoesTitulosId";
         }
         else if ( ( AV13OrderedBy == 11 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.OperacoesId DESC, T1.OperacoesTitulosUpdatedAt DESC, T1.OperacoesTitulosId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.OperacoesTitulosId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H00A43( IGxContext context ,
                                             string A1020OperacoesTitulosTipo ,
                                             GxSimpleCollection<string> AV90Operacoestituloswwds_13_tfoperacoestitulostipo_sels ,
                                             string A1027OperacoesTitulosStatus ,
                                             GxSimpleCollection<string> AV103Operacoestituloswwds_26_tfoperacoestitulosstatus_sels ,
                                             string AV79Operacoestituloswwds_2_filterfulltext ,
                                             string AV80Operacoestituloswwds_3_dynamicfiltersselector1 ,
                                             string AV81Operacoestituloswwds_4_operacoestitulostipo1 ,
                                             bool AV82Operacoestituloswwds_5_dynamicfiltersenabled2 ,
                                             string AV83Operacoestituloswwds_6_dynamicfiltersselector2 ,
                                             string AV84Operacoestituloswwds_7_operacoestitulostipo2 ,
                                             bool AV85Operacoestituloswwds_8_dynamicfiltersenabled3 ,
                                             string AV86Operacoestituloswwds_9_dynamicfiltersselector3 ,
                                             string AV87Operacoestituloswwds_10_operacoestitulostipo3 ,
                                             string AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel ,
                                             string AV88Operacoestituloswwds_11_tfsacadorazaosocial ,
                                             int AV90Operacoestituloswwds_13_tfoperacoestitulostipo_sels_Count ,
                                             int AV91Operacoestituloswwds_14_tfoperacoestitulosnumero ,
                                             int AV92Operacoestituloswwds_15_tfoperacoestitulosnumero_to ,
                                             DateTime AV93Operacoestituloswwds_16_tfoperacoestitulosdataemissao ,
                                             DateTime AV94Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to ,
                                             DateTime AV95Operacoestituloswwds_18_tfoperacoestitulosdatavencimento ,
                                             DateTime AV96Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to ,
                                             decimal AV97Operacoestituloswwds_20_tfoperacoestitulosvalor ,
                                             decimal AV98Operacoestituloswwds_21_tfoperacoestitulosvalor_to ,
                                             decimal AV99Operacoestituloswwds_22_tfoperacoestitulosliquido ,
                                             decimal AV100Operacoestituloswwds_23_tfoperacoestitulosliquido_to ,
                                             decimal AV101Operacoestituloswwds_24_tfoperacoestitulostaxa ,
                                             decimal AV102Operacoestituloswwds_25_tfoperacoestitulostaxa_to ,
                                             int AV103Operacoestituloswwds_26_tfoperacoestitulosstatus_sels_Count ,
                                             DateTime AV104Operacoestituloswwds_27_tfoperacoestituloscreatedat ,
                                             DateTime AV105Operacoestituloswwds_28_tfoperacoestituloscreatedat_to ,
                                             DateTime AV106Operacoestituloswwds_29_tfoperacoestitulosupdatedat ,
                                             DateTime AV107Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to ,
                                             string A1035SacadoRazaoSocial ,
                                             int A1021OperacoesTitulosNumero ,
                                             decimal A1024OperacoesTitulosValor ,
                                             decimal A1025OperacoesTitulosLiquido ,
                                             decimal A1026OperacoesTitulosTaxa ,
                                             DateTime A1022OperacoesTitulosDataEmissao ,
                                             DateTime A1023OperacoesTitulosDataVencimento ,
                                             DateTime A1028OperacoesTitulosCreatedAt ,
                                             DateTime A1029OperacoesTitulosUpdatedAt ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             int A1010OperacoesId ,
                                             int AV78Operacoestituloswwds_1_operacoesid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[35];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (OperacoesTitulos T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.SacadoId)";
         AddWhere(sWhereString, "(T1.OperacoesId = :AV78Operacoestituloswwds_1_operacoesid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Operacoestituloswwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ClienteRazaoSocial like '%' || :lV79Operacoestituloswwds_2_filterfulltext) or ( 'na' like '%' || LOWER(:lV79Operacoestituloswwds_2_filterfulltext) and (char_length(trim(trailing ' ' from T1.OperacoesTitulosTipo))=0)) or ( 'nota fiscal' like '%' || LOWER(:lV79Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosTipo = ( 'NOTA_FISCAL')) or ( 'rpa' like '%' || LOWER(:lV79Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosTipo = ( 'RPA')) or ( SUBSTR(TO_CHAR(T1.OperacoesTitulosNumero,'999999999'), 2) like '%' || :lV79Operacoestituloswwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.OperacoesTitulosValor,'999999999999990.99'), 2) like '%' || :lV79Operacoestituloswwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.OperacoesTitulosLiquido,'999999999999990.99'), 2) like '%' || :lV79Operacoestituloswwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.OperacoesTitulosTaxa,'99999999990.9999'), 2) like '%' || :lV79Operacoestituloswwds_2_filterfulltext) or ( 'pendente' like '%' || LOWER(:lV79Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosStatus = ( 'PENDENTE')) or ( 'aceito' like '%' || LOWER(:lV79Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosStatus = ( 'ACEITO')) or ( 'recusado' like '%' || LOWER(:lV79Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosStatus = ( 'RECUSADO')) or ( 'vencido' like '%' || LOWER(:lV79Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosStatus = ( 'VENCIDO')) or ( 'liquidado' like '%' || LOWER(:lV79Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosStatus = ( 'LIQUIDADO')))");
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
            GXv_int8[10] = 1;
            GXv_int8[11] = 1;
            GXv_int8[12] = 1;
            GXv_int8[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV80Operacoestituloswwds_3_dynamicfiltersselector1, "OPERACOESTITULOSTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Operacoestituloswwds_4_operacoestitulostipo1)) ) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosTipo = ( :AV81Operacoestituloswwds_4_operacoestitulostipo1))");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( AV82Operacoestituloswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV83Operacoestituloswwds_6_dynamicfiltersselector2, "OPERACOESTITULOSTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Operacoestituloswwds_7_operacoestitulostipo2)) ) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosTipo = ( :AV84Operacoestituloswwds_7_operacoestitulostipo2))");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( AV85Operacoestituloswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Operacoestituloswwds_9_dynamicfiltersselector3, "OPERACOESTITULOSTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Operacoestituloswwds_10_operacoestitulostipo3)) ) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosTipo = ( :AV87Operacoestituloswwds_10_operacoestitulostipo3))");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Operacoestituloswwds_11_tfsacadorazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV88Operacoestituloswwds_11_tfsacadorazaosocial)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel)) && ! ( StringUtil.StrCmp(AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel))");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( StringUtil.StrCmp(AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( AV90Operacoestituloswwds_13_tfoperacoestitulostipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV90Operacoestituloswwds_13_tfoperacoestitulostipo_sels, "T1.OperacoesTitulosTipo IN (", ")")+")");
         }
         if ( ! (0==AV91Operacoestituloswwds_14_tfoperacoestitulosnumero) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosNumero >= :AV91Operacoestituloswwds_14_tfoperacoestitulosnumero)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( ! (0==AV92Operacoestituloswwds_15_tfoperacoestitulosnumero_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosNumero <= :AV92Operacoestituloswwds_15_tfoperacoestitulosnumero_to)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV93Operacoestituloswwds_16_tfoperacoestitulosdataemissao) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosDataEmissao >= :AV93Operacoestituloswwds_16_tfoperacoestitulosdataemissao)");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosDataEmissao <= :AV94Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to)");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV95Operacoestituloswwds_18_tfoperacoestitulosdatavencimento) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosDataVencimento >= :AV95Operacoestituloswwds_18_tfoperacoestitulosdatavencimento)");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV96Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosDataVencimento <= :AV96Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to)");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV97Operacoestituloswwds_20_tfoperacoestitulosvalor) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosValor >= :AV97Operacoestituloswwds_20_tfoperacoestitulosvalor)");
         }
         else
         {
            GXv_int8[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV98Operacoestituloswwds_21_tfoperacoestitulosvalor_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosValor <= :AV98Operacoestituloswwds_21_tfoperacoestitulosvalor_to)");
         }
         else
         {
            GXv_int8[26] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV99Operacoestituloswwds_22_tfoperacoestitulosliquido) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosLiquido >= :AV99Operacoestituloswwds_22_tfoperacoestitulosliquido)");
         }
         else
         {
            GXv_int8[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV100Operacoestituloswwds_23_tfoperacoestitulosliquido_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosLiquido <= :AV100Operacoestituloswwds_23_tfoperacoestitulosliquido_to)");
         }
         else
         {
            GXv_int8[28] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV101Operacoestituloswwds_24_tfoperacoestitulostaxa) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosTaxa >= :AV101Operacoestituloswwds_24_tfoperacoestitulostaxa)");
         }
         else
         {
            GXv_int8[29] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV102Operacoestituloswwds_25_tfoperacoestitulostaxa_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosTaxa <= :AV102Operacoestituloswwds_25_tfoperacoestitulostaxa_to)");
         }
         else
         {
            GXv_int8[30] = 1;
         }
         if ( AV103Operacoestituloswwds_26_tfoperacoestitulosstatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV103Operacoestituloswwds_26_tfoperacoestitulosstatus_sels, "T1.OperacoesTitulosStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV104Operacoestituloswwds_27_tfoperacoestituloscreatedat) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosCreatedAt >= :AV104Operacoestituloswwds_27_tfoperacoestituloscreatedat)");
         }
         else
         {
            GXv_int8[31] = 1;
         }
         if ( ! (DateTime.MinValue==AV105Operacoestituloswwds_28_tfoperacoestituloscreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosCreatedAt <= :AV105Operacoestituloswwds_28_tfoperacoestituloscreatedat_to)");
         }
         else
         {
            GXv_int8[32] = 1;
         }
         if ( ! (DateTime.MinValue==AV106Operacoestituloswwds_29_tfoperacoestitulosupdatedat) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosUpdatedAt >= :AV106Operacoestituloswwds_29_tfoperacoestitulosupdatedat)");
         }
         else
         {
            GXv_int8[33] = 1;
         }
         if ( ! (DateTime.MinValue==AV107Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosUpdatedAt <= :AV107Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to)");
         }
         else
         {
            GXv_int8[34] = 1;
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
                     return conditional_H00A42(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (decimal)dynConstraints[27] , (int)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (string)dynConstraints[33] , (int)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (DateTime)dynConstraints[40] , (DateTime)dynConstraints[41] , (short)dynConstraints[42] , (bool)dynConstraints[43] , (int)dynConstraints[44] , (int)dynConstraints[45] );
               case 1 :
                     return conditional_H00A43(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (decimal)dynConstraints[27] , (int)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (string)dynConstraints[33] , (int)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (DateTime)dynConstraints[40] , (DateTime)dynConstraints[41] , (short)dynConstraints[42] , (bool)dynConstraints[43] , (int)dynConstraints[44] , (int)dynConstraints[45] );
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
          Object[] prmH00A42;
          prmH00A42 = new Object[] {
          new ParDef("AV78Operacoestituloswwds_1_operacoesid",GXType.Int32,9,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV81Operacoestituloswwds_4_operacoestitulostipo1",GXType.VarChar,40,0) ,
          new ParDef("AV84Operacoestituloswwds_7_operacoestitulostipo2",GXType.VarChar,40,0) ,
          new ParDef("AV87Operacoestituloswwds_10_operacoestitulostipo3",GXType.VarChar,40,0) ,
          new ParDef("lV88Operacoestituloswwds_11_tfsacadorazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV91Operacoestituloswwds_14_tfoperacoestitulosnumero",GXType.Int32,9,0) ,
          new ParDef("AV92Operacoestituloswwds_15_tfoperacoestitulosnumero_to",GXType.Int32,9,0) ,
          new ParDef("AV93Operacoestituloswwds_16_tfoperacoestitulosdataemissao",GXType.Date,8,0) ,
          new ParDef("AV94Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to",GXType.Date,8,0) ,
          new ParDef("AV95Operacoestituloswwds_18_tfoperacoestitulosdatavencimento",GXType.Date,8,0) ,
          new ParDef("AV96Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to",GXType.Date,8,0) ,
          new ParDef("AV97Operacoestituloswwds_20_tfoperacoestitulosvalor",GXType.Number,18,2) ,
          new ParDef("AV98Operacoestituloswwds_21_tfoperacoestitulosvalor_to",GXType.Number,18,2) ,
          new ParDef("AV99Operacoestituloswwds_22_tfoperacoestitulosliquido",GXType.Number,18,2) ,
          new ParDef("AV100Operacoestituloswwds_23_tfoperacoestitulosliquido_to",GXType.Number,18,2) ,
          new ParDef("AV101Operacoestituloswwds_24_tfoperacoestitulostaxa",GXType.Number,16,4) ,
          new ParDef("AV102Operacoestituloswwds_25_tfoperacoestitulostaxa_to",GXType.Number,16,4) ,
          new ParDef("AV104Operacoestituloswwds_27_tfoperacoestituloscreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV105Operacoestituloswwds_28_tfoperacoestituloscreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV106Operacoestituloswwds_29_tfoperacoestitulosupdatedat",GXType.DateTime,8,5) ,
          new ParDef("AV107Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to",GXType.DateTime,8,5) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00A43;
          prmH00A43 = new Object[] {
          new ParDef("AV78Operacoestituloswwds_1_operacoesid",GXType.Int32,9,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV81Operacoestituloswwds_4_operacoestitulostipo1",GXType.VarChar,40,0) ,
          new ParDef("AV84Operacoestituloswwds_7_operacoestitulostipo2",GXType.VarChar,40,0) ,
          new ParDef("AV87Operacoestituloswwds_10_operacoestitulostipo3",GXType.VarChar,40,0) ,
          new ParDef("lV88Operacoestituloswwds_11_tfsacadorazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV89Operacoestituloswwds_12_tfsacadorazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV91Operacoestituloswwds_14_tfoperacoestitulosnumero",GXType.Int32,9,0) ,
          new ParDef("AV92Operacoestituloswwds_15_tfoperacoestitulosnumero_to",GXType.Int32,9,0) ,
          new ParDef("AV93Operacoestituloswwds_16_tfoperacoestitulosdataemissao",GXType.Date,8,0) ,
          new ParDef("AV94Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to",GXType.Date,8,0) ,
          new ParDef("AV95Operacoestituloswwds_18_tfoperacoestitulosdatavencimento",GXType.Date,8,0) ,
          new ParDef("AV96Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to",GXType.Date,8,0) ,
          new ParDef("AV97Operacoestituloswwds_20_tfoperacoestitulosvalor",GXType.Number,18,2) ,
          new ParDef("AV98Operacoestituloswwds_21_tfoperacoestitulosvalor_to",GXType.Number,18,2) ,
          new ParDef("AV99Operacoestituloswwds_22_tfoperacoestitulosliquido",GXType.Number,18,2) ,
          new ParDef("AV100Operacoestituloswwds_23_tfoperacoestitulosliquido_to",GXType.Number,18,2) ,
          new ParDef("AV101Operacoestituloswwds_24_tfoperacoestitulostaxa",GXType.Number,16,4) ,
          new ParDef("AV102Operacoestituloswwds_25_tfoperacoestitulostaxa_to",GXType.Number,16,4) ,
          new ParDef("AV104Operacoestituloswwds_27_tfoperacoestituloscreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV105Operacoestituloswwds_28_tfoperacoestituloscreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV106Operacoestituloswwds_29_tfoperacoestitulosupdatedat",GXType.DateTime,8,5) ,
          new ParDef("AV107Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("H00A42", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A42,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00A43", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A43,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((int[]) buf[24])[0] = rslt.getInt(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
