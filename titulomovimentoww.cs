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
   public class titulomovimentoww : GXWebComponent
   {
      public titulomovimentoww( )
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

      public titulomovimentoww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_TituloId )
      {
         this.AV53TituloId = aP0_TituloId;
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
         cmbavDynamicfiltersoperator1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         cmbTituloMovimentoTipo = new GXCombobox();
         chkTituloMovimentoSoma = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "TituloId");
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
                  AV53TituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV53TituloId", StringUtil.LTrimStr( (decimal)(AV53TituloId), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)AV53TituloId});
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
                  gxfirstwebparm = GetFirstPar( "TituloId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "TituloId");
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
         nRC_GXsfl_107 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_107"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_107_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_107_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_107_idx = GetPar( "sGXsfl_107_idx");
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
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV18TituloMovimentoValor1 = NumberUtil.Val( GetPar( "TituloMovimentoValor1"), ".");
         AV54TipoPagamentoNome1 = GetPar( "TipoPagamentoNome1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV20DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV22TituloMovimentoValor2 = NumberUtil.Val( GetPar( "TituloMovimentoValor2"), ".");
         AV55TipoPagamentoNome2 = GetPar( "TipoPagamentoNome2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV26TituloMovimentoValor3 = NumberUtil.Val( GetPar( "TituloMovimentoValor3"), ".");
         AV56TipoPagamentoNome3 = GetPar( "TipoPagamentoNome3");
         AV32ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV19DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV23DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV53TituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloId"), "."), 18, MidpointRounding.ToEven));
         AV35TFTituloMovimentoValor = NumberUtil.Val( GetPar( "TFTituloMovimentoValor"), ".");
         AV36TFTituloMovimentoValor_To = NumberUtil.Val( GetPar( "TFTituloMovimentoValor_To"), ".");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV38TFTituloMovimentoTipo_Sels);
         AV39TFTituloMovimentoDataCredito = context.localUtil.ParseDateParm( GetPar( "TFTituloMovimentoDataCredito"));
         AV40TFTituloMovimentoDataCredito_To = context.localUtil.ParseDateParm( GetPar( "TFTituloMovimentoDataCredito_To"));
         AV44TFTituloMovimentoCreatedAt = context.localUtil.ParseDTimeParm( GetPar( "TFTituloMovimentoCreatedAt"));
         AV45TFTituloMovimentoCreatedAt_To = context.localUtil.ParseDTimeParm( GetPar( "TFTituloMovimentoCreatedAt_To"));
         AV51TFTipoPagamentoNome = GetPar( "TFTipoPagamentoNome");
         AV52TFTipoPagamentoNome_Sel = GetPar( "TFTipoPagamentoNome_Sel");
         AV82Pgmname = GetPar( "Pgmname");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV28DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV27DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TituloMovimentoValor1, AV54TipoPagamentoNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TituloMovimentoValor2, AV55TipoPagamentoNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26TituloMovimentoValor3, AV56TipoPagamentoNome3, AV32ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV53TituloId, AV35TFTituloMovimentoValor, AV36TFTituloMovimentoValor_To, AV38TFTituloMovimentoTipo_Sels, AV39TFTituloMovimentoDataCredito, AV40TFTituloMovimentoDataCredito_To, AV44TFTituloMovimentoCreatedAt, AV45TFTituloMovimentoCreatedAt_To, AV51TFTipoPagamentoNome, AV52TFTipoPagamentoNome_Sel, AV82Pgmname, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
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
            PA4O2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV82Pgmname = "TituloMovimentoWW";
               WS4O2( ) ;
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
            context.SendWebValue( " Titulo Movimento") ;
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
            GXEncryptionTmp = "titulomovimentoww"+UrlEncode(StringUtil.LTrimStr(AV53TituloId,9,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("titulomovimentoww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV82Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV82Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vFILTERFULLTEXT", AV15FilterFullText);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR1", AV16DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vTITULOMOVIMENTOVALOR1", StringUtil.LTrim( StringUtil.NToC( AV18TituloMovimentoValor1, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vTIPOPAGAMENTONOME1", AV54TipoPagamentoNome1);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2", AV20DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vTITULOMOVIMENTOVALOR2", StringUtil.LTrim( StringUtil.NToC( AV22TituloMovimentoValor2, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vTIPOPAGAMENTONOME2", AV55TipoPagamentoNome2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3", AV24DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vTITULOMOVIMENTOVALOR3", StringUtil.LTrim( StringUtil.NToC( AV26TituloMovimentoValor3, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vTIPOPAGAMENTONOME3", AV56TipoPagamentoNome3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_107", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_107), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV30ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV30ManageFiltersData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV49DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV49DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_TITULOMOVIMENTODATACREDITOAUXDATE", context.localUtil.DToC( AV41DDO_TituloMovimentoDataCreditoAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_TITULOMOVIMENTODATACREDITOAUXDATETO", context.localUtil.DToC( AV42DDO_TituloMovimentoDataCreditoAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_TITULOMOVIMENTOCREATEDATAUXDATE", context.localUtil.DToC( AV46DDO_TituloMovimentoCreatedAtAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_TITULOMOVIMENTOCREATEDATAUXDATETO", context.localUtil.DToC( AV47DDO_TituloMovimentoCreatedAtAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV53TituloId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV53TituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED2", AV19DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED3", AV23DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTITULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV53TituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTITULOMOVIMENTOVALOR", StringUtil.LTrim( StringUtil.NToC( AV35TFTituloMovimentoValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTITULOMOVIMENTOVALOR_TO", StringUtil.LTrim( StringUtil.NToC( AV36TFTituloMovimentoValor_To, 18, 2, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTFTITULOMOVIMENTOTIPO_SELS", AV38TFTituloMovimentoTipo_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTFTITULOMOVIMENTOTIPO_SELS", AV38TFTituloMovimentoTipo_Sels);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTITULOMOVIMENTODATACREDITO", context.localUtil.DToC( AV39TFTituloMovimentoDataCredito, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTITULOMOVIMENTODATACREDITO_TO", context.localUtil.DToC( AV40TFTituloMovimentoDataCredito_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTITULOMOVIMENTOCREATEDAT", context.localUtil.TToC( AV44TFTituloMovimentoCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTITULOMOVIMENTOCREATEDAT_TO", context.localUtil.TToC( AV45TFTituloMovimentoCreatedAt_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTIPOPAGAMENTONOME", AV51TFTipoPagamentoNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTIPOPAGAMENTONOME_SEL", AV52TFTipoPagamentoNome_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV82Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV82Pgmname, "")), context));
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSIGNOREFIRST", AV28DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSREMOVING", AV27DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTITULOMOVIMENTOTIPO_SELSJSON", AV37TFTituloMovimentoTipo_SelsJson);
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm4O2( )
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
         return "TituloMovimentoWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Titulo Movimento" ;
      }

      protected void WB4O0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "titulomovimentoww");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV30ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_TituloMovimentoWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_TituloMovimentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 0, "HLP_TituloMovimentoWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_TituloMovimentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_39_4O2( true) ;
         }
         else
         {
            wb_table1_39_4O2( false) ;
         }
         return  ;
      }

      protected void wb_table1_39_4O2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_TituloMovimentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV20DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "", true, 0, "HLP_TituloMovimentoWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_TituloMovimentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_64_4O2( true) ;
         }
         else
         {
            wb_table2_64_4O2( false) ;
         }
         return  ;
      }

      protected void wb_table2_64_4O2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_TituloMovimentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV24DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "", true, 0, "HLP_TituloMovimentoWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_TituloMovimentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_89_4O2( true) ;
         }
         else
         {
            wb_table3_89_4O2( false) ;
         }
         return  ;
      }

      protected void wb_table3_89_4O2e( bool wbgen )
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_TituloMovimentoWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV49DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_titulomovimentodatacreditoauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_titulomovimentodatacreditoauxdatetext_Internalname, AV43DDO_TituloMovimentoDataCreditoAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV43DDO_TituloMovimentoDataCreditoAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,125);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_titulomovimentodatacreditoauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TituloMovimentoWW.htm");
            /* User Defined Control */
            ucTftitulomovimentodatacredito_rangepicker.SetProperty("Start Date", AV41DDO_TituloMovimentoDataCreditoAuxDate);
            ucTftitulomovimentodatacredito_rangepicker.SetProperty("End Date", AV42DDO_TituloMovimentoDataCreditoAuxDateTo);
            ucTftitulomovimentodatacredito_rangepicker.Render(context, "wwp.daterangepicker", Tftitulomovimentodatacredito_rangepicker_Internalname, sPrefix+"TFTITULOMOVIMENTODATACREDITO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_titulomovimentocreatedatauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_titulomovimentocreatedatauxdatetext_Internalname, AV48DDO_TituloMovimentoCreatedAtAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV48DDO_TituloMovimentoCreatedAtAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,128);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_titulomovimentocreatedatauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TituloMovimentoWW.htm");
            /* User Defined Control */
            ucTftitulomovimentocreatedat_rangepicker.SetProperty("Start Date", AV46DDO_TituloMovimentoCreatedAtAuxDate);
            ucTftitulomovimentocreatedat_rangepicker.SetProperty("End Date", AV47DDO_TituloMovimentoCreatedAtAuxDateTo);
            ucTftitulomovimentocreatedat_rangepicker.Render(context, "wwp.daterangepicker", Tftitulomovimentocreatedat_rangepicker_Internalname, sPrefix+"TFTITULOMOVIMENTOCREATEDAT_RANGEPICKERContainer");
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

      protected void START4O2( )
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
            Form.Meta.addItem("description", " Titulo Movimento", 0) ;
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
               STRUP4O0( ) ;
            }
         }
      }

      protected void WS4O2( )
      {
         START4O2( ) ;
         EVT4O2( ) ;
      }

      protected void EVT4O2( )
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
                                 STRUP4O0( ) ;
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
                                 STRUP4O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E114O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E124O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters1' */
                                    E134O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters2' */
                                    E144O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters3' */
                                    E154O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'AddDynamicFilters1' */
                                    E164O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E174O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'AddDynamicFilters2' */
                                    E184O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E194O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E204O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavFilterfulltext_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4O0( ) ;
                              }
                              AV57Titulomovimentowwds_1_tituloid = AV53TituloId;
                              AV58Titulomovimentowwds_2_filterfulltext = AV15FilterFullText;
                              AV59Titulomovimentowwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
                              AV60Titulomovimentowwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
                              AV61Titulomovimentowwds_5_titulomovimentovalor1 = AV18TituloMovimentoValor1;
                              AV62Titulomovimentowwds_6_tipopagamentonome1 = AV54TipoPagamentoNome1;
                              AV63Titulomovimentowwds_7_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
                              AV64Titulomovimentowwds_8_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
                              AV65Titulomovimentowwds_9_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
                              AV66Titulomovimentowwds_10_titulomovimentovalor2 = AV22TituloMovimentoValor2;
                              AV67Titulomovimentowwds_11_tipopagamentonome2 = AV55TipoPagamentoNome2;
                              AV68Titulomovimentowwds_12_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
                              AV69Titulomovimentowwds_13_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
                              AV70Titulomovimentowwds_14_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
                              AV71Titulomovimentowwds_15_titulomovimentovalor3 = AV26TituloMovimentoValor3;
                              AV72Titulomovimentowwds_16_tipopagamentonome3 = AV56TipoPagamentoNome3;
                              AV73Titulomovimentowwds_17_tftitulomovimentovalor = AV35TFTituloMovimentoValor;
                              AV74Titulomovimentowwds_18_tftitulomovimentovalor_to = AV36TFTituloMovimentoValor_To;
                              AV75Titulomovimentowwds_19_tftitulomovimentotipo_sels = AV38TFTituloMovimentoTipo_Sels;
                              AV76Titulomovimentowwds_20_tftitulomovimentodatacredito = AV39TFTituloMovimentoDataCredito;
                              AV77Titulomovimentowwds_21_tftitulomovimentodatacredito_to = AV40TFTituloMovimentoDataCredito_To;
                              AV78Titulomovimentowwds_22_tftitulomovimentocreatedat = AV44TFTituloMovimentoCreatedAt;
                              AV79Titulomovimentowwds_23_tftitulomovimentocreatedat_to = AV45TFTituloMovimentoCreatedAt_To;
                              AV80Titulomovimentowwds_24_tftipopagamentonome = AV51TFTipoPagamentoNome;
                              AV81Titulomovimentowwds_25_tftipopagamentonome_sel = AV52TFTipoPagamentoNome_Sel;
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
                                 STRUP4O0( ) ;
                              }
                              nGXsfl_107_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
                              SubsflControlProps_1072( ) ;
                              A270TituloMovimentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloMovimentoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A288TipoPagamentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTipoPagamentoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n288TipoPagamentoId = false;
                              A261TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n261TituloId = false;
                              A271TituloMovimentoValor = context.localUtil.CToN( cgiGet( edtTituloMovimentoValor_Internalname), ",", ".");
                              n271TituloMovimentoValor = false;
                              cmbTituloMovimentoTipo.Name = cmbTituloMovimentoTipo_Internalname;
                              cmbTituloMovimentoTipo.CurrentValue = cgiGet( cmbTituloMovimentoTipo_Internalname);
                              A272TituloMovimentoTipo = cgiGet( cmbTituloMovimentoTipo_Internalname);
                              n272TituloMovimentoTipo = false;
                              A274TituloMovimentoSoma = StringUtil.StrToBool( cgiGet( chkTituloMovimentoSoma_Internalname));
                              n274TituloMovimentoSoma = false;
                              A279TituloMovimentoDataCredito = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTituloMovimentoDataCredito_Internalname), 0));
                              n279TituloMovimentoDataCredito = false;
                              A280TituloMovimentoCreatedAt = context.localUtil.CToT( cgiGet( edtTituloMovimentoCreatedAt_Internalname), 0);
                              n280TituloMovimentoCreatedAt = false;
                              A281TituloMovimentoUpdatedAt = context.localUtil.CToT( cgiGet( edtTituloMovimentoUpdatedAt_Internalname), 0);
                              n281TituloMovimentoUpdatedAt = false;
                              A289TipoPagamentoNome = cgiGet( edtTipoPagamentoNome_Internalname);
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
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E214O2 ();
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
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E224O2 ();
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
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E234O2 ();
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
                                             /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV17DynamicFiltersOperator1 )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Titulomovimentovalor1 Changed */
                                             if ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vTITULOMOVIMENTOVALOR1"), ",", ".") != AV18TituloMovimentoValor1 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Tipopagamentonome1 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vTIPOPAGAMENTONOME1"), AV54TipoPagamentoNome1) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersselector2 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2"), AV20DynamicFiltersSelector2) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV21DynamicFiltersOperator2 )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Titulomovimentovalor2 Changed */
                                             if ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vTITULOMOVIMENTOVALOR2"), ",", ".") != AV22TituloMovimentoValor2 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Tipopagamentonome2 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vTIPOPAGAMENTONOME2"), AV55TipoPagamentoNome2) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersselector3 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3"), AV24DynamicFiltersSelector3) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV25DynamicFiltersOperator3 )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Titulomovimentovalor3 Changed */
                                             if ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vTITULOMOVIMENTOVALOR3"), ",", ".") != AV26TituloMovimentoValor3 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Tipopagamentonome3 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vTIPOPAGAMENTONOME3"), AV56TipoPagamentoNome3) != 0 )
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
                                       STRUP4O0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
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

      protected void WE4O2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4O2( ) ;
            }
         }
      }

      protected void PA4O2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "titulomovimentoww")), "titulomovimentoww") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "titulomovimentoww")))) ;
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
                     gxfirstwebparm = GetFirstPar( "TituloId");
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
                                       decimal AV18TituloMovimentoValor1 ,
                                       string AV54TipoPagamentoNome1 ,
                                       string AV20DynamicFiltersSelector2 ,
                                       short AV21DynamicFiltersOperator2 ,
                                       decimal AV22TituloMovimentoValor2 ,
                                       string AV55TipoPagamentoNome2 ,
                                       string AV24DynamicFiltersSelector3 ,
                                       short AV25DynamicFiltersOperator3 ,
                                       decimal AV26TituloMovimentoValor3 ,
                                       string AV56TipoPagamentoNome3 ,
                                       short AV32ManageFiltersExecutionStep ,
                                       bool AV19DynamicFiltersEnabled2 ,
                                       bool AV23DynamicFiltersEnabled3 ,
                                       int AV53TituloId ,
                                       decimal AV35TFTituloMovimentoValor ,
                                       decimal AV36TFTituloMovimentoValor_To ,
                                       GxSimpleCollection<string> AV38TFTituloMovimentoTipo_Sels ,
                                       DateTime AV39TFTituloMovimentoDataCredito ,
                                       DateTime AV40TFTituloMovimentoDataCredito_To ,
                                       DateTime AV44TFTituloMovimentoCreatedAt ,
                                       DateTime AV45TFTituloMovimentoCreatedAt_To ,
                                       string AV51TFTipoPagamentoNome ,
                                       string AV52TFTipoPagamentoNome_Sel ,
                                       string AV82Pgmname ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV28DynamicFiltersIgnoreFirst ,
                                       bool AV27DynamicFiltersRemoving ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF4O2( ) ;
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
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV20DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV20DynamicFiltersSelector2);
            AssignAttri(sPrefix, false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV24DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV24DynamicFiltersSelector3);
            AssignAttri(sPrefix, false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV82Pgmname = "TituloMovimentoWW";
      }

      protected void RF4O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 107;
         /* Execute user event: Refresh */
         E224O2 ();
         nGXsfl_107_idx = 1;
         sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
         SubsflControlProps_1072( ) ;
         bGXsfl_107_Refreshing = true;
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
            SubsflControlProps_1072( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A272TituloMovimentoTipo ,
                                                 AV75Titulomovimentowwds_19_tftitulomovimentotipo_sels ,
                                                 AV58Titulomovimentowwds_2_filterfulltext ,
                                                 AV59Titulomovimentowwds_3_dynamicfiltersselector1 ,
                                                 AV60Titulomovimentowwds_4_dynamicfiltersoperator1 ,
                                                 AV61Titulomovimentowwds_5_titulomovimentovalor1 ,
                                                 AV62Titulomovimentowwds_6_tipopagamentonome1 ,
                                                 AV63Titulomovimentowwds_7_dynamicfiltersenabled2 ,
                                                 AV64Titulomovimentowwds_8_dynamicfiltersselector2 ,
                                                 AV65Titulomovimentowwds_9_dynamicfiltersoperator2 ,
                                                 AV66Titulomovimentowwds_10_titulomovimentovalor2 ,
                                                 AV67Titulomovimentowwds_11_tipopagamentonome2 ,
                                                 AV68Titulomovimentowwds_12_dynamicfiltersenabled3 ,
                                                 AV69Titulomovimentowwds_13_dynamicfiltersselector3 ,
                                                 AV70Titulomovimentowwds_14_dynamicfiltersoperator3 ,
                                                 AV71Titulomovimentowwds_15_titulomovimentovalor3 ,
                                                 AV72Titulomovimentowwds_16_tipopagamentonome3 ,
                                                 AV73Titulomovimentowwds_17_tftitulomovimentovalor ,
                                                 AV74Titulomovimentowwds_18_tftitulomovimentovalor_to ,
                                                 AV75Titulomovimentowwds_19_tftitulomovimentotipo_sels.Count ,
                                                 AV76Titulomovimentowwds_20_tftitulomovimentodatacredito ,
                                                 AV77Titulomovimentowwds_21_tftitulomovimentodatacredito_to ,
                                                 AV78Titulomovimentowwds_22_tftitulomovimentocreatedat ,
                                                 AV79Titulomovimentowwds_23_tftitulomovimentocreatedat_to ,
                                                 AV81Titulomovimentowwds_25_tftipopagamentonome_sel ,
                                                 AV80Titulomovimentowwds_24_tftipopagamentonome ,
                                                 A271TituloMovimentoValor ,
                                                 A289TipoPagamentoNome ,
                                                 A279TituloMovimentoDataCredito ,
                                                 A280TituloMovimentoCreatedAt ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 A261TituloId ,
                                                 AV57Titulomovimentowwds_1_tituloid } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                                 TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                                 TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV58Titulomovimentowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Titulomovimentowwds_2_filterfulltext), "%", "");
            lV58Titulomovimentowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Titulomovimentowwds_2_filterfulltext), "%", "");
            lV58Titulomovimentowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Titulomovimentowwds_2_filterfulltext), "%", "");
            lV58Titulomovimentowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Titulomovimentowwds_2_filterfulltext), "%", "");
            lV58Titulomovimentowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Titulomovimentowwds_2_filterfulltext), "%", "");
            lV58Titulomovimentowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Titulomovimentowwds_2_filterfulltext), "%", "");
            lV62Titulomovimentowwds_6_tipopagamentonome1 = StringUtil.Concat( StringUtil.RTrim( AV62Titulomovimentowwds_6_tipopagamentonome1), "%", "");
            lV62Titulomovimentowwds_6_tipopagamentonome1 = StringUtil.Concat( StringUtil.RTrim( AV62Titulomovimentowwds_6_tipopagamentonome1), "%", "");
            lV67Titulomovimentowwds_11_tipopagamentonome2 = StringUtil.Concat( StringUtil.RTrim( AV67Titulomovimentowwds_11_tipopagamentonome2), "%", "");
            lV67Titulomovimentowwds_11_tipopagamentonome2 = StringUtil.Concat( StringUtil.RTrim( AV67Titulomovimentowwds_11_tipopagamentonome2), "%", "");
            lV72Titulomovimentowwds_16_tipopagamentonome3 = StringUtil.Concat( StringUtil.RTrim( AV72Titulomovimentowwds_16_tipopagamentonome3), "%", "");
            lV72Titulomovimentowwds_16_tipopagamentonome3 = StringUtil.Concat( StringUtil.RTrim( AV72Titulomovimentowwds_16_tipopagamentonome3), "%", "");
            lV80Titulomovimentowwds_24_tftipopagamentonome = StringUtil.Concat( StringUtil.RTrim( AV80Titulomovimentowwds_24_tftipopagamentonome), "%", "");
            /* Using cursor H004O2 */
            pr_default.execute(0, new Object[] {AV57Titulomovimentowwds_1_tituloid, lV58Titulomovimentowwds_2_filterfulltext, lV58Titulomovimentowwds_2_filterfulltext, lV58Titulomovimentowwds_2_filterfulltext, lV58Titulomovimentowwds_2_filterfulltext, lV58Titulomovimentowwds_2_filterfulltext, lV58Titulomovimentowwds_2_filterfulltext, AV61Titulomovimentowwds_5_titulomovimentovalor1, AV61Titulomovimentowwds_5_titulomovimentovalor1, AV61Titulomovimentowwds_5_titulomovimentovalor1, lV62Titulomovimentowwds_6_tipopagamentonome1, lV62Titulomovimentowwds_6_tipopagamentonome1, AV66Titulomovimentowwds_10_titulomovimentovalor2, AV66Titulomovimentowwds_10_titulomovimentovalor2, AV66Titulomovimentowwds_10_titulomovimentovalor2, lV67Titulomovimentowwds_11_tipopagamentonome2, lV67Titulomovimentowwds_11_tipopagamentonome2, AV71Titulomovimentowwds_15_titulomovimentovalor3, AV71Titulomovimentowwds_15_titulomovimentovalor3, AV71Titulomovimentowwds_15_titulomovimentovalor3, lV72Titulomovimentowwds_16_tipopagamentonome3, lV72Titulomovimentowwds_16_tipopagamentonome3, AV73Titulomovimentowwds_17_tftitulomovimentovalor, AV74Titulomovimentowwds_18_tftitulomovimentovalor_to, AV76Titulomovimentowwds_20_tftitulomovimentodatacredito, AV77Titulomovimentowwds_21_tftitulomovimentodatacredito_to, AV78Titulomovimentowwds_22_tftitulomovimentocreatedat, AV79Titulomovimentowwds_23_tftitulomovimentocreatedat_to, lV80Titulomovimentowwds_24_tftipopagamentonome, AV81Titulomovimentowwds_25_tftipopagamentonome_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_107_idx = 1;
            sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
            SubsflControlProps_1072( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A289TipoPagamentoNome = H004O2_A289TipoPagamentoNome[0];
               A281TituloMovimentoUpdatedAt = H004O2_A281TituloMovimentoUpdatedAt[0];
               n281TituloMovimentoUpdatedAt = H004O2_n281TituloMovimentoUpdatedAt[0];
               A280TituloMovimentoCreatedAt = H004O2_A280TituloMovimentoCreatedAt[0];
               n280TituloMovimentoCreatedAt = H004O2_n280TituloMovimentoCreatedAt[0];
               A279TituloMovimentoDataCredito = H004O2_A279TituloMovimentoDataCredito[0];
               n279TituloMovimentoDataCredito = H004O2_n279TituloMovimentoDataCredito[0];
               A274TituloMovimentoSoma = H004O2_A274TituloMovimentoSoma[0];
               n274TituloMovimentoSoma = H004O2_n274TituloMovimentoSoma[0];
               A272TituloMovimentoTipo = H004O2_A272TituloMovimentoTipo[0];
               n272TituloMovimentoTipo = H004O2_n272TituloMovimentoTipo[0];
               A271TituloMovimentoValor = H004O2_A271TituloMovimentoValor[0];
               n271TituloMovimentoValor = H004O2_n271TituloMovimentoValor[0];
               A261TituloId = H004O2_A261TituloId[0];
               n261TituloId = H004O2_n261TituloId[0];
               A288TipoPagamentoId = H004O2_A288TipoPagamentoId[0];
               n288TipoPagamentoId = H004O2_n288TipoPagamentoId[0];
               A270TituloMovimentoId = H004O2_A270TituloMovimentoId[0];
               A289TipoPagamentoNome = H004O2_A289TipoPagamentoNome[0];
               /* Execute user event: Grid.Load */
               E234O2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 107;
            WB4O0( ) ;
         }
         bGXsfl_107_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4O2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV82Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV82Pgmname, "")), context));
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
         AV57Titulomovimentowwds_1_tituloid = AV53TituloId;
         AV58Titulomovimentowwds_2_filterfulltext = AV15FilterFullText;
         AV59Titulomovimentowwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV60Titulomovimentowwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV61Titulomovimentowwds_5_titulomovimentovalor1 = AV18TituloMovimentoValor1;
         AV62Titulomovimentowwds_6_tipopagamentonome1 = AV54TipoPagamentoNome1;
         AV63Titulomovimentowwds_7_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV64Titulomovimentowwds_8_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV65Titulomovimentowwds_9_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV66Titulomovimentowwds_10_titulomovimentovalor2 = AV22TituloMovimentoValor2;
         AV67Titulomovimentowwds_11_tipopagamentonome2 = AV55TipoPagamentoNome2;
         AV68Titulomovimentowwds_12_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV69Titulomovimentowwds_13_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV70Titulomovimentowwds_14_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV71Titulomovimentowwds_15_titulomovimentovalor3 = AV26TituloMovimentoValor3;
         AV72Titulomovimentowwds_16_tipopagamentonome3 = AV56TipoPagamentoNome3;
         AV73Titulomovimentowwds_17_tftitulomovimentovalor = AV35TFTituloMovimentoValor;
         AV74Titulomovimentowwds_18_tftitulomovimentovalor_to = AV36TFTituloMovimentoValor_To;
         AV75Titulomovimentowwds_19_tftitulomovimentotipo_sels = AV38TFTituloMovimentoTipo_Sels;
         AV76Titulomovimentowwds_20_tftitulomovimentodatacredito = AV39TFTituloMovimentoDataCredito;
         AV77Titulomovimentowwds_21_tftitulomovimentodatacredito_to = AV40TFTituloMovimentoDataCredito_To;
         AV78Titulomovimentowwds_22_tftitulomovimentocreatedat = AV44TFTituloMovimentoCreatedAt;
         AV79Titulomovimentowwds_23_tftitulomovimentocreatedat_to = AV45TFTituloMovimentoCreatedAt_To;
         AV80Titulomovimentowwds_24_tftipopagamentonome = AV51TFTipoPagamentoNome;
         AV81Titulomovimentowwds_25_tftipopagamentonome_sel = AV52TFTipoPagamentoNome_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A272TituloMovimentoTipo ,
                                              AV75Titulomovimentowwds_19_tftitulomovimentotipo_sels ,
                                              AV58Titulomovimentowwds_2_filterfulltext ,
                                              AV59Titulomovimentowwds_3_dynamicfiltersselector1 ,
                                              AV60Titulomovimentowwds_4_dynamicfiltersoperator1 ,
                                              AV61Titulomovimentowwds_5_titulomovimentovalor1 ,
                                              AV62Titulomovimentowwds_6_tipopagamentonome1 ,
                                              AV63Titulomovimentowwds_7_dynamicfiltersenabled2 ,
                                              AV64Titulomovimentowwds_8_dynamicfiltersselector2 ,
                                              AV65Titulomovimentowwds_9_dynamicfiltersoperator2 ,
                                              AV66Titulomovimentowwds_10_titulomovimentovalor2 ,
                                              AV67Titulomovimentowwds_11_tipopagamentonome2 ,
                                              AV68Titulomovimentowwds_12_dynamicfiltersenabled3 ,
                                              AV69Titulomovimentowwds_13_dynamicfiltersselector3 ,
                                              AV70Titulomovimentowwds_14_dynamicfiltersoperator3 ,
                                              AV71Titulomovimentowwds_15_titulomovimentovalor3 ,
                                              AV72Titulomovimentowwds_16_tipopagamentonome3 ,
                                              AV73Titulomovimentowwds_17_tftitulomovimentovalor ,
                                              AV74Titulomovimentowwds_18_tftitulomovimentovalor_to ,
                                              AV75Titulomovimentowwds_19_tftitulomovimentotipo_sels.Count ,
                                              AV76Titulomovimentowwds_20_tftitulomovimentodatacredito ,
                                              AV77Titulomovimentowwds_21_tftitulomovimentodatacredito_to ,
                                              AV78Titulomovimentowwds_22_tftitulomovimentocreatedat ,
                                              AV79Titulomovimentowwds_23_tftitulomovimentocreatedat_to ,
                                              AV81Titulomovimentowwds_25_tftipopagamentonome_sel ,
                                              AV80Titulomovimentowwds_24_tftipopagamentonome ,
                                              A271TituloMovimentoValor ,
                                              A289TipoPagamentoNome ,
                                              A279TituloMovimentoDataCredito ,
                                              A280TituloMovimentoCreatedAt ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              A261TituloId ,
                                              AV57Titulomovimentowwds_1_tituloid } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV58Titulomovimentowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Titulomovimentowwds_2_filterfulltext), "%", "");
         lV58Titulomovimentowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Titulomovimentowwds_2_filterfulltext), "%", "");
         lV58Titulomovimentowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Titulomovimentowwds_2_filterfulltext), "%", "");
         lV58Titulomovimentowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Titulomovimentowwds_2_filterfulltext), "%", "");
         lV58Titulomovimentowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Titulomovimentowwds_2_filterfulltext), "%", "");
         lV58Titulomovimentowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Titulomovimentowwds_2_filterfulltext), "%", "");
         lV62Titulomovimentowwds_6_tipopagamentonome1 = StringUtil.Concat( StringUtil.RTrim( AV62Titulomovimentowwds_6_tipopagamentonome1), "%", "");
         lV62Titulomovimentowwds_6_tipopagamentonome1 = StringUtil.Concat( StringUtil.RTrim( AV62Titulomovimentowwds_6_tipopagamentonome1), "%", "");
         lV67Titulomovimentowwds_11_tipopagamentonome2 = StringUtil.Concat( StringUtil.RTrim( AV67Titulomovimentowwds_11_tipopagamentonome2), "%", "");
         lV67Titulomovimentowwds_11_tipopagamentonome2 = StringUtil.Concat( StringUtil.RTrim( AV67Titulomovimentowwds_11_tipopagamentonome2), "%", "");
         lV72Titulomovimentowwds_16_tipopagamentonome3 = StringUtil.Concat( StringUtil.RTrim( AV72Titulomovimentowwds_16_tipopagamentonome3), "%", "");
         lV72Titulomovimentowwds_16_tipopagamentonome3 = StringUtil.Concat( StringUtil.RTrim( AV72Titulomovimentowwds_16_tipopagamentonome3), "%", "");
         lV80Titulomovimentowwds_24_tftipopagamentonome = StringUtil.Concat( StringUtil.RTrim( AV80Titulomovimentowwds_24_tftipopagamentonome), "%", "");
         /* Using cursor H004O3 */
         pr_default.execute(1, new Object[] {AV57Titulomovimentowwds_1_tituloid, lV58Titulomovimentowwds_2_filterfulltext, lV58Titulomovimentowwds_2_filterfulltext, lV58Titulomovimentowwds_2_filterfulltext, lV58Titulomovimentowwds_2_filterfulltext, lV58Titulomovimentowwds_2_filterfulltext, lV58Titulomovimentowwds_2_filterfulltext, AV61Titulomovimentowwds_5_titulomovimentovalor1, AV61Titulomovimentowwds_5_titulomovimentovalor1, AV61Titulomovimentowwds_5_titulomovimentovalor1, lV62Titulomovimentowwds_6_tipopagamentonome1, lV62Titulomovimentowwds_6_tipopagamentonome1, AV66Titulomovimentowwds_10_titulomovimentovalor2, AV66Titulomovimentowwds_10_titulomovimentovalor2, AV66Titulomovimentowwds_10_titulomovimentovalor2, lV67Titulomovimentowwds_11_tipopagamentonome2, lV67Titulomovimentowwds_11_tipopagamentonome2, AV71Titulomovimentowwds_15_titulomovimentovalor3, AV71Titulomovimentowwds_15_titulomovimentovalor3, AV71Titulomovimentowwds_15_titulomovimentovalor3, lV72Titulomovimentowwds_16_tipopagamentonome3, lV72Titulomovimentowwds_16_tipopagamentonome3, AV73Titulomovimentowwds_17_tftitulomovimentovalor, AV74Titulomovimentowwds_18_tftitulomovimentovalor_to, AV76Titulomovimentowwds_20_tftitulomovimentodatacredito, AV77Titulomovimentowwds_21_tftitulomovimentodatacredito_to, AV78Titulomovimentowwds_22_tftitulomovimentocreatedat, AV79Titulomovimentowwds_23_tftitulomovimentocreatedat_to, lV80Titulomovimentowwds_24_tftipopagamentonome, AV81Titulomovimentowwds_25_tftipopagamentonome_sel});
         GRID_nRecordCount = H004O3_AGRID_nRecordCount[0];
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
         AV57Titulomovimentowwds_1_tituloid = AV53TituloId;
         AV58Titulomovimentowwds_2_filterfulltext = AV15FilterFullText;
         AV59Titulomovimentowwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV60Titulomovimentowwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV61Titulomovimentowwds_5_titulomovimentovalor1 = AV18TituloMovimentoValor1;
         AV62Titulomovimentowwds_6_tipopagamentonome1 = AV54TipoPagamentoNome1;
         AV63Titulomovimentowwds_7_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV64Titulomovimentowwds_8_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV65Titulomovimentowwds_9_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV66Titulomovimentowwds_10_titulomovimentovalor2 = AV22TituloMovimentoValor2;
         AV67Titulomovimentowwds_11_tipopagamentonome2 = AV55TipoPagamentoNome2;
         AV68Titulomovimentowwds_12_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV69Titulomovimentowwds_13_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV70Titulomovimentowwds_14_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV71Titulomovimentowwds_15_titulomovimentovalor3 = AV26TituloMovimentoValor3;
         AV72Titulomovimentowwds_16_tipopagamentonome3 = AV56TipoPagamentoNome3;
         AV73Titulomovimentowwds_17_tftitulomovimentovalor = AV35TFTituloMovimentoValor;
         AV74Titulomovimentowwds_18_tftitulomovimentovalor_to = AV36TFTituloMovimentoValor_To;
         AV75Titulomovimentowwds_19_tftitulomovimentotipo_sels = AV38TFTituloMovimentoTipo_Sels;
         AV76Titulomovimentowwds_20_tftitulomovimentodatacredito = AV39TFTituloMovimentoDataCredito;
         AV77Titulomovimentowwds_21_tftitulomovimentodatacredito_to = AV40TFTituloMovimentoDataCredito_To;
         AV78Titulomovimentowwds_22_tftitulomovimentocreatedat = AV44TFTituloMovimentoCreatedAt;
         AV79Titulomovimentowwds_23_tftitulomovimentocreatedat_to = AV45TFTituloMovimentoCreatedAt_To;
         AV80Titulomovimentowwds_24_tftipopagamentonome = AV51TFTipoPagamentoNome;
         AV81Titulomovimentowwds_25_tftipopagamentonome_sel = AV52TFTipoPagamentoNome_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TituloMovimentoValor1, AV54TipoPagamentoNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TituloMovimentoValor2, AV55TipoPagamentoNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26TituloMovimentoValor3, AV56TipoPagamentoNome3, AV32ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV53TituloId, AV35TFTituloMovimentoValor, AV36TFTituloMovimentoValor_To, AV38TFTituloMovimentoTipo_Sels, AV39TFTituloMovimentoDataCredito, AV40TFTituloMovimentoDataCredito_To, AV44TFTituloMovimentoCreatedAt, AV45TFTituloMovimentoCreatedAt_To, AV51TFTipoPagamentoNome, AV52TFTipoPagamentoNome_Sel, AV82Pgmname, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV57Titulomovimentowwds_1_tituloid = AV53TituloId;
         AV58Titulomovimentowwds_2_filterfulltext = AV15FilterFullText;
         AV59Titulomovimentowwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV60Titulomovimentowwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV61Titulomovimentowwds_5_titulomovimentovalor1 = AV18TituloMovimentoValor1;
         AV62Titulomovimentowwds_6_tipopagamentonome1 = AV54TipoPagamentoNome1;
         AV63Titulomovimentowwds_7_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV64Titulomovimentowwds_8_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV65Titulomovimentowwds_9_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV66Titulomovimentowwds_10_titulomovimentovalor2 = AV22TituloMovimentoValor2;
         AV67Titulomovimentowwds_11_tipopagamentonome2 = AV55TipoPagamentoNome2;
         AV68Titulomovimentowwds_12_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV69Titulomovimentowwds_13_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV70Titulomovimentowwds_14_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV71Titulomovimentowwds_15_titulomovimentovalor3 = AV26TituloMovimentoValor3;
         AV72Titulomovimentowwds_16_tipopagamentonome3 = AV56TipoPagamentoNome3;
         AV73Titulomovimentowwds_17_tftitulomovimentovalor = AV35TFTituloMovimentoValor;
         AV74Titulomovimentowwds_18_tftitulomovimentovalor_to = AV36TFTituloMovimentoValor_To;
         AV75Titulomovimentowwds_19_tftitulomovimentotipo_sels = AV38TFTituloMovimentoTipo_Sels;
         AV76Titulomovimentowwds_20_tftitulomovimentodatacredito = AV39TFTituloMovimentoDataCredito;
         AV77Titulomovimentowwds_21_tftitulomovimentodatacredito_to = AV40TFTituloMovimentoDataCredito_To;
         AV78Titulomovimentowwds_22_tftitulomovimentocreatedat = AV44TFTituloMovimentoCreatedAt;
         AV79Titulomovimentowwds_23_tftitulomovimentocreatedat_to = AV45TFTituloMovimentoCreatedAt_To;
         AV80Titulomovimentowwds_24_tftipopagamentonome = AV51TFTipoPagamentoNome;
         AV81Titulomovimentowwds_25_tftipopagamentonome_sel = AV52TFTipoPagamentoNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TituloMovimentoValor1, AV54TipoPagamentoNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TituloMovimentoValor2, AV55TipoPagamentoNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26TituloMovimentoValor3, AV56TipoPagamentoNome3, AV32ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV53TituloId, AV35TFTituloMovimentoValor, AV36TFTituloMovimentoValor_To, AV38TFTituloMovimentoTipo_Sels, AV39TFTituloMovimentoDataCredito, AV40TFTituloMovimentoDataCredito_To, AV44TFTituloMovimentoCreatedAt, AV45TFTituloMovimentoCreatedAt_To, AV51TFTipoPagamentoNome, AV52TFTipoPagamentoNome_Sel, AV82Pgmname, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV57Titulomovimentowwds_1_tituloid = AV53TituloId;
         AV58Titulomovimentowwds_2_filterfulltext = AV15FilterFullText;
         AV59Titulomovimentowwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV60Titulomovimentowwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV61Titulomovimentowwds_5_titulomovimentovalor1 = AV18TituloMovimentoValor1;
         AV62Titulomovimentowwds_6_tipopagamentonome1 = AV54TipoPagamentoNome1;
         AV63Titulomovimentowwds_7_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV64Titulomovimentowwds_8_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV65Titulomovimentowwds_9_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV66Titulomovimentowwds_10_titulomovimentovalor2 = AV22TituloMovimentoValor2;
         AV67Titulomovimentowwds_11_tipopagamentonome2 = AV55TipoPagamentoNome2;
         AV68Titulomovimentowwds_12_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV69Titulomovimentowwds_13_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV70Titulomovimentowwds_14_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV71Titulomovimentowwds_15_titulomovimentovalor3 = AV26TituloMovimentoValor3;
         AV72Titulomovimentowwds_16_tipopagamentonome3 = AV56TipoPagamentoNome3;
         AV73Titulomovimentowwds_17_tftitulomovimentovalor = AV35TFTituloMovimentoValor;
         AV74Titulomovimentowwds_18_tftitulomovimentovalor_to = AV36TFTituloMovimentoValor_To;
         AV75Titulomovimentowwds_19_tftitulomovimentotipo_sels = AV38TFTituloMovimentoTipo_Sels;
         AV76Titulomovimentowwds_20_tftitulomovimentodatacredito = AV39TFTituloMovimentoDataCredito;
         AV77Titulomovimentowwds_21_tftitulomovimentodatacredito_to = AV40TFTituloMovimentoDataCredito_To;
         AV78Titulomovimentowwds_22_tftitulomovimentocreatedat = AV44TFTituloMovimentoCreatedAt;
         AV79Titulomovimentowwds_23_tftitulomovimentocreatedat_to = AV45TFTituloMovimentoCreatedAt_To;
         AV80Titulomovimentowwds_24_tftipopagamentonome = AV51TFTipoPagamentoNome;
         AV81Titulomovimentowwds_25_tftipopagamentonome_sel = AV52TFTipoPagamentoNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TituloMovimentoValor1, AV54TipoPagamentoNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TituloMovimentoValor2, AV55TipoPagamentoNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26TituloMovimentoValor3, AV56TipoPagamentoNome3, AV32ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV53TituloId, AV35TFTituloMovimentoValor, AV36TFTituloMovimentoValor_To, AV38TFTituloMovimentoTipo_Sels, AV39TFTituloMovimentoDataCredito, AV40TFTituloMovimentoDataCredito_To, AV44TFTituloMovimentoCreatedAt, AV45TFTituloMovimentoCreatedAt_To, AV51TFTipoPagamentoNome, AV52TFTipoPagamentoNome_Sel, AV82Pgmname, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV57Titulomovimentowwds_1_tituloid = AV53TituloId;
         AV58Titulomovimentowwds_2_filterfulltext = AV15FilterFullText;
         AV59Titulomovimentowwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV60Titulomovimentowwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV61Titulomovimentowwds_5_titulomovimentovalor1 = AV18TituloMovimentoValor1;
         AV62Titulomovimentowwds_6_tipopagamentonome1 = AV54TipoPagamentoNome1;
         AV63Titulomovimentowwds_7_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV64Titulomovimentowwds_8_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV65Titulomovimentowwds_9_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV66Titulomovimentowwds_10_titulomovimentovalor2 = AV22TituloMovimentoValor2;
         AV67Titulomovimentowwds_11_tipopagamentonome2 = AV55TipoPagamentoNome2;
         AV68Titulomovimentowwds_12_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV69Titulomovimentowwds_13_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV70Titulomovimentowwds_14_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV71Titulomovimentowwds_15_titulomovimentovalor3 = AV26TituloMovimentoValor3;
         AV72Titulomovimentowwds_16_tipopagamentonome3 = AV56TipoPagamentoNome3;
         AV73Titulomovimentowwds_17_tftitulomovimentovalor = AV35TFTituloMovimentoValor;
         AV74Titulomovimentowwds_18_tftitulomovimentovalor_to = AV36TFTituloMovimentoValor_To;
         AV75Titulomovimentowwds_19_tftitulomovimentotipo_sels = AV38TFTituloMovimentoTipo_Sels;
         AV76Titulomovimentowwds_20_tftitulomovimentodatacredito = AV39TFTituloMovimentoDataCredito;
         AV77Titulomovimentowwds_21_tftitulomovimentodatacredito_to = AV40TFTituloMovimentoDataCredito_To;
         AV78Titulomovimentowwds_22_tftitulomovimentocreatedat = AV44TFTituloMovimentoCreatedAt;
         AV79Titulomovimentowwds_23_tftitulomovimentocreatedat_to = AV45TFTituloMovimentoCreatedAt_To;
         AV80Titulomovimentowwds_24_tftipopagamentonome = AV51TFTipoPagamentoNome;
         AV81Titulomovimentowwds_25_tftipopagamentonome_sel = AV52TFTipoPagamentoNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TituloMovimentoValor1, AV54TipoPagamentoNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TituloMovimentoValor2, AV55TipoPagamentoNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26TituloMovimentoValor3, AV56TipoPagamentoNome3, AV32ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV53TituloId, AV35TFTituloMovimentoValor, AV36TFTituloMovimentoValor_To, AV38TFTituloMovimentoTipo_Sels, AV39TFTituloMovimentoDataCredito, AV40TFTituloMovimentoDataCredito_To, AV44TFTituloMovimentoCreatedAt, AV45TFTituloMovimentoCreatedAt_To, AV51TFTipoPagamentoNome, AV52TFTipoPagamentoNome_Sel, AV82Pgmname, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV57Titulomovimentowwds_1_tituloid = AV53TituloId;
         AV58Titulomovimentowwds_2_filterfulltext = AV15FilterFullText;
         AV59Titulomovimentowwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV60Titulomovimentowwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV61Titulomovimentowwds_5_titulomovimentovalor1 = AV18TituloMovimentoValor1;
         AV62Titulomovimentowwds_6_tipopagamentonome1 = AV54TipoPagamentoNome1;
         AV63Titulomovimentowwds_7_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV64Titulomovimentowwds_8_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV65Titulomovimentowwds_9_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV66Titulomovimentowwds_10_titulomovimentovalor2 = AV22TituloMovimentoValor2;
         AV67Titulomovimentowwds_11_tipopagamentonome2 = AV55TipoPagamentoNome2;
         AV68Titulomovimentowwds_12_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV69Titulomovimentowwds_13_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV70Titulomovimentowwds_14_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV71Titulomovimentowwds_15_titulomovimentovalor3 = AV26TituloMovimentoValor3;
         AV72Titulomovimentowwds_16_tipopagamentonome3 = AV56TipoPagamentoNome3;
         AV73Titulomovimentowwds_17_tftitulomovimentovalor = AV35TFTituloMovimentoValor;
         AV74Titulomovimentowwds_18_tftitulomovimentovalor_to = AV36TFTituloMovimentoValor_To;
         AV75Titulomovimentowwds_19_tftitulomovimentotipo_sels = AV38TFTituloMovimentoTipo_Sels;
         AV76Titulomovimentowwds_20_tftitulomovimentodatacredito = AV39TFTituloMovimentoDataCredito;
         AV77Titulomovimentowwds_21_tftitulomovimentodatacredito_to = AV40TFTituloMovimentoDataCredito_To;
         AV78Titulomovimentowwds_22_tftitulomovimentocreatedat = AV44TFTituloMovimentoCreatedAt;
         AV79Titulomovimentowwds_23_tftitulomovimentocreatedat_to = AV45TFTituloMovimentoCreatedAt_To;
         AV80Titulomovimentowwds_24_tftipopagamentonome = AV51TFTipoPagamentoNome;
         AV81Titulomovimentowwds_25_tftipopagamentonome_sel = AV52TFTipoPagamentoNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TituloMovimentoValor1, AV54TipoPagamentoNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TituloMovimentoValor2, AV55TipoPagamentoNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26TituloMovimentoValor3, AV56TipoPagamentoNome3, AV32ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV53TituloId, AV35TFTituloMovimentoValor, AV36TFTituloMovimentoValor_To, AV38TFTituloMovimentoTipo_Sels, AV39TFTituloMovimentoDataCredito, AV40TFTituloMovimentoDataCredito_To, AV44TFTituloMovimentoCreatedAt, AV45TFTituloMovimentoCreatedAt_To, AV51TFTipoPagamentoNome, AV52TFTipoPagamentoNome_Sel, AV82Pgmname, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV82Pgmname = "TituloMovimentoWW";
         edtTituloMovimentoId_Enabled = 0;
         edtTipoPagamentoId_Enabled = 0;
         edtTituloId_Enabled = 0;
         edtTituloMovimentoValor_Enabled = 0;
         cmbTituloMovimentoTipo.Enabled = 0;
         chkTituloMovimentoSoma.Enabled = 0;
         edtTituloMovimentoDataCredito_Enabled = 0;
         edtTituloMovimentoCreatedAt_Enabled = 0;
         edtTituloMovimentoUpdatedAt_Enabled = 0;
         edtTipoPagamentoNome_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E214O2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV30ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV49DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_107 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_107"), ",", "."), 18, MidpointRounding.ToEven));
            AV41DDO_TituloMovimentoDataCreditoAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_TITULOMOVIMENTODATACREDITOAUXDATE"), 0);
            AV42DDO_TituloMovimentoDataCreditoAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_TITULOMOVIMENTODATACREDITOAUXDATETO"), 0);
            AV46DDO_TituloMovimentoCreatedAtAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_TITULOMOVIMENTOCREATEDATAUXDATE"), 0);
            AssignAttri(sPrefix, false, "AV46DDO_TituloMovimentoCreatedAtAuxDate", context.localUtil.Format(AV46DDO_TituloMovimentoCreatedAtAuxDate, "99/99/9999"));
            AV47DDO_TituloMovimentoCreatedAtAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_TITULOMOVIMENTOCREATEDATAUXDATETO"), 0);
            AssignAttri(sPrefix, false, "AV47DDO_TituloMovimentoCreatedAtAuxDateTo", context.localUtil.Format(AV47DDO_TituloMovimentoCreatedAtAuxDateTo, "99/99/9999"));
            wcpOAV53TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV53TituloId"), ",", "."), 18, MidpointRounding.ToEven));
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
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_get");
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
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTitulomovimentovalor1_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTitulomovimentovalor1_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTITULOMOVIMENTOVALOR1");
               GX_FocusControl = edtavTitulomovimentovalor1_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18TituloMovimentoValor1 = 0;
               AssignAttri(sPrefix, false, "AV18TituloMovimentoValor1", StringUtil.LTrimStr( AV18TituloMovimentoValor1, 18, 2));
            }
            else
            {
               AV18TituloMovimentoValor1 = context.localUtil.CToN( cgiGet( edtavTitulomovimentovalor1_Internalname), ",", ".");
               AssignAttri(sPrefix, false, "AV18TituloMovimentoValor1", StringUtil.LTrimStr( AV18TituloMovimentoValor1, 18, 2));
            }
            AV54TipoPagamentoNome1 = cgiGet( edtavTipopagamentonome1_Internalname);
            AssignAttri(sPrefix, false, "AV54TipoPagamentoNome1", AV54TipoPagamentoNome1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV20DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri(sPrefix, false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTitulomovimentovalor2_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTitulomovimentovalor2_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTITULOMOVIMENTOVALOR2");
               GX_FocusControl = edtavTitulomovimentovalor2_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV22TituloMovimentoValor2 = 0;
               AssignAttri(sPrefix, false, "AV22TituloMovimentoValor2", StringUtil.LTrimStr( AV22TituloMovimentoValor2, 18, 2));
            }
            else
            {
               AV22TituloMovimentoValor2 = context.localUtil.CToN( cgiGet( edtavTitulomovimentovalor2_Internalname), ",", ".");
               AssignAttri(sPrefix, false, "AV22TituloMovimentoValor2", StringUtil.LTrimStr( AV22TituloMovimentoValor2, 18, 2));
            }
            AV55TipoPagamentoNome2 = cgiGet( edtavTipopagamentonome2_Internalname);
            AssignAttri(sPrefix, false, "AV55TipoPagamentoNome2", AV55TipoPagamentoNome2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV24DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri(sPrefix, false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTitulomovimentovalor3_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTitulomovimentovalor3_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTITULOMOVIMENTOVALOR3");
               GX_FocusControl = edtavTitulomovimentovalor3_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV26TituloMovimentoValor3 = 0;
               AssignAttri(sPrefix, false, "AV26TituloMovimentoValor3", StringUtil.LTrimStr( AV26TituloMovimentoValor3, 18, 2));
            }
            else
            {
               AV26TituloMovimentoValor3 = context.localUtil.CToN( cgiGet( edtavTitulomovimentovalor3_Internalname), ",", ".");
               AssignAttri(sPrefix, false, "AV26TituloMovimentoValor3", StringUtil.LTrimStr( AV26TituloMovimentoValor3, 18, 2));
            }
            AV56TipoPagamentoNome3 = cgiGet( edtavTipopagamentonome3_Internalname);
            AssignAttri(sPrefix, false, "AV56TipoPagamentoNome3", AV56TipoPagamentoNome3);
            AV43DDO_TituloMovimentoDataCreditoAuxDateText = cgiGet( edtavDdo_titulomovimentodatacreditoauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV43DDO_TituloMovimentoDataCreditoAuxDateText", AV43DDO_TituloMovimentoDataCreditoAuxDateText);
            AV48DDO_TituloMovimentoCreatedAtAuxDateText = cgiGet( edtavDdo_titulomovimentocreatedatauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV48DDO_TituloMovimentoCreatedAtAuxDateText", AV48DDO_TituloMovimentoCreatedAtAuxDateText);
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
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV17DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vTITULOMOVIMENTOVALOR1"), ",", ".") != AV18TituloMovimentoValor1 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vTIPOPAGAMENTONOME1"), AV54TipoPagamentoNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2"), AV20DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV21DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vTITULOMOVIMENTOVALOR2"), ",", ".") != AV22TituloMovimentoValor2 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vTIPOPAGAMENTONOME2"), AV55TipoPagamentoNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3"), AV24DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV25DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vTITULOMOVIMENTOVALOR3"), ",", ".") != AV26TituloMovimentoValor3 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vTIPOPAGAMENTONOME3"), AV56TipoPagamentoNome3) != 0 )
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
         E214O2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E214O2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod(sPrefix, false, "TFTITULOMOVIMENTOCREATEDAT_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_titulomovimentocreatedatauxdatetext_Internalname});
         this.executeUsercontrolMethod(sPrefix, false, "TFTITULOMOVIMENTODATACREDITO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_titulomovimentodatacreditoauxdatetext_Internalname});
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
         AV16DynamicFiltersSelector1 = "TITULOMOVIMENTOVALOR";
         AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20DynamicFiltersSelector2 = "TITULOMOVIMENTOVALOR";
         AssignAttri(sPrefix, false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV24DynamicFiltersSelector3 = "TITULOMOVIMENTOVALOR";
         AssignAttri(sPrefix, false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV49DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV49DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
      }

      protected void E224O2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV32ManageFiltersExecutionStep == 1 )
         {
            AV32ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV32ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV32ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV32ManageFiltersExecutionStep == 2 )
         {
            AV32ManageFiltersExecutionStep = 0;
            AssignAttri(sPrefix, false, "AV32ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV32ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "TITULOMOVIMENTOVALOR") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "<", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
            cmbavDynamicfiltersoperator1.addItem("2", ">", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "TIPOPAGAMENTONOME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         if ( AV19DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "TITULOMOVIMENTOVALOR") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
               cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "TIPOPAGAMENTONOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            if ( AV23DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "TITULOMOVIMENTOVALOR") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
                  cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "TIPOPAGAMENTONOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
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
         AV57Titulomovimentowwds_1_tituloid = AV53TituloId;
         AV58Titulomovimentowwds_2_filterfulltext = AV15FilterFullText;
         AV59Titulomovimentowwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV60Titulomovimentowwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV61Titulomovimentowwds_5_titulomovimentovalor1 = AV18TituloMovimentoValor1;
         AV62Titulomovimentowwds_6_tipopagamentonome1 = AV54TipoPagamentoNome1;
         AV63Titulomovimentowwds_7_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV64Titulomovimentowwds_8_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV65Titulomovimentowwds_9_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV66Titulomovimentowwds_10_titulomovimentovalor2 = AV22TituloMovimentoValor2;
         AV67Titulomovimentowwds_11_tipopagamentonome2 = AV55TipoPagamentoNome2;
         AV68Titulomovimentowwds_12_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV69Titulomovimentowwds_13_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV70Titulomovimentowwds_14_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV71Titulomovimentowwds_15_titulomovimentovalor3 = AV26TituloMovimentoValor3;
         AV72Titulomovimentowwds_16_tipopagamentonome3 = AV56TipoPagamentoNome3;
         AV73Titulomovimentowwds_17_tftitulomovimentovalor = AV35TFTituloMovimentoValor;
         AV74Titulomovimentowwds_18_tftitulomovimentovalor_to = AV36TFTituloMovimentoValor_To;
         AV75Titulomovimentowwds_19_tftitulomovimentotipo_sels = AV38TFTituloMovimentoTipo_Sels;
         AV76Titulomovimentowwds_20_tftitulomovimentodatacredito = AV39TFTituloMovimentoDataCredito;
         AV77Titulomovimentowwds_21_tftitulomovimentodatacredito_to = AV40TFTituloMovimentoDataCredito_To;
         AV78Titulomovimentowwds_22_tftitulomovimentocreatedat = AV44TFTituloMovimentoCreatedAt;
         AV79Titulomovimentowwds_23_tftitulomovimentocreatedat_to = AV45TFTituloMovimentoCreatedAt_To;
         AV80Titulomovimentowwds_24_tftipopagamentonome = AV51TFTipoPagamentoNome;
         AV81Titulomovimentowwds_25_tftipopagamentonome_sel = AV52TFTipoPagamentoNome_Sel;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30ManageFiltersData", AV30ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E124O2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloMovimentoValor") == 0 )
            {
               AV35TFTituloMovimentoValor = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV35TFTituloMovimentoValor", StringUtil.LTrimStr( AV35TFTituloMovimentoValor, 18, 2));
               AV36TFTituloMovimentoValor_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV36TFTituloMovimentoValor_To", StringUtil.LTrimStr( AV36TFTituloMovimentoValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloMovimentoTipo") == 0 )
            {
               AV37TFTituloMovimentoTipo_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV37TFTituloMovimentoTipo_SelsJson", AV37TFTituloMovimentoTipo_SelsJson);
               AV38TFTituloMovimentoTipo_Sels.FromJSonString(AV37TFTituloMovimentoTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloMovimentoDataCredito") == 0 )
            {
               AV39TFTituloMovimentoDataCredito = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 4);
               AssignAttri(sPrefix, false, "AV39TFTituloMovimentoDataCredito", context.localUtil.Format(AV39TFTituloMovimentoDataCredito, "99/99/9999"));
               AV40TFTituloMovimentoDataCredito_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri(sPrefix, false, "AV40TFTituloMovimentoDataCredito_To", context.localUtil.Format(AV40TFTituloMovimentoDataCredito_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloMovimentoCreatedAt") == 0 )
            {
               AV44TFTituloMovimentoCreatedAt = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri(sPrefix, false, "AV44TFTituloMovimentoCreatedAt", context.localUtil.TToC( AV44TFTituloMovimentoCreatedAt, 10, 8, 0, 3, "/", ":", " "));
               AV45TFTituloMovimentoCreatedAt_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri(sPrefix, false, "AV45TFTituloMovimentoCreatedAt_To", context.localUtil.TToC( AV45TFTituloMovimentoCreatedAt_To, 10, 8, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV45TFTituloMovimentoCreatedAt_To) )
               {
                  AV45TFTituloMovimentoCreatedAt_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV45TFTituloMovimentoCreatedAt_To)), (short)(DateTimeUtil.Month( AV45TFTituloMovimentoCreatedAt_To)), (short)(DateTimeUtil.Day( AV45TFTituloMovimentoCreatedAt_To)), 23, 59, 59);
                  AssignAttri(sPrefix, false, "AV45TFTituloMovimentoCreatedAt_To", context.localUtil.TToC( AV45TFTituloMovimentoCreatedAt_To, 10, 8, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipoPagamentoNome") == 0 )
            {
               AV51TFTipoPagamentoNome = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV51TFTipoPagamentoNome", AV51TFTipoPagamentoNome);
               AV52TFTipoPagamentoNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV52TFTipoPagamentoNome_Sel", AV52TFTipoPagamentoNome_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV38TFTituloMovimentoTipo_Sels", AV38TFTituloMovimentoTipo_Sels);
      }

      private void E234O2( )
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
         GXEncryptionTmp = "titulomovimento"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A270TituloMovimentoId,9,0));
         edtTituloMovimentoValor_Link = formatLink("titulomovimento") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "tipopagamento"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A288TipoPagamentoId,9,0));
         edtTipoPagamentoNome_Link = formatLink("tipopagamento") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
      }

      protected void E164O2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = true;
         AssignAttri(sPrefix, false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp(sPrefix, false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp(sPrefix, false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TituloMovimentoValor1, AV54TipoPagamentoNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TituloMovimentoValor2, AV55TipoPagamentoNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26TituloMovimentoValor3, AV56TipoPagamentoNome3, AV32ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV53TituloId, AV35TFTituloMovimentoValor, AV36TFTituloMovimentoValor_To, AV38TFTituloMovimentoTipo_Sels, AV39TFTituloMovimentoDataCredito, AV40TFTituloMovimentoDataCredito_To, AV44TFTituloMovimentoCreatedAt, AV45TFTituloMovimentoCreatedAt_To, AV51TFTipoPagamentoNome, AV52TFTipoPagamentoNome_Sel, AV82Pgmname, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30ManageFiltersData", AV30ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E134O2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV28DynamicFiltersIgnoreFirst = true;
         AssignAttri(sPrefix, false, "AV28DynamicFiltersIgnoreFirst", AV28DynamicFiltersIgnoreFirst);
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
         AssignAttri(sPrefix, false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV28DynamicFiltersIgnoreFirst = false;
         AssignAttri(sPrefix, false, "AV28DynamicFiltersIgnoreFirst", AV28DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TituloMovimentoValor1, AV54TipoPagamentoNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TituloMovimentoValor2, AV55TipoPagamentoNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26TituloMovimentoValor3, AV56TipoPagamentoNome3, AV32ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV53TituloId, AV35TFTituloMovimentoValor, AV36TFTituloMovimentoValor_To, AV38TFTituloMovimentoTipo_Sels, AV39TFTituloMovimentoDataCredito, AV40TFTituloMovimentoDataCredito_To, AV44TFTituloMovimentoCreatedAt, AV45TFTituloMovimentoCreatedAt_To, AV51TFTipoPagamentoNome, AV52TFTipoPagamentoNome_Sel, AV82Pgmname, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30ManageFiltersData", AV30ManageFiltersData);
      }

      protected void E174O2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E184O2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV23DynamicFiltersEnabled3 = true;
         AssignAttri(sPrefix, false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TituloMovimentoValor1, AV54TipoPagamentoNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TituloMovimentoValor2, AV55TipoPagamentoNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26TituloMovimentoValor3, AV56TipoPagamentoNome3, AV32ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV53TituloId, AV35TFTituloMovimentoValor, AV36TFTituloMovimentoValor_To, AV38TFTituloMovimentoTipo_Sels, AV39TFTituloMovimentoDataCredito, AV40TFTituloMovimentoDataCredito_To, AV44TFTituloMovimentoCreatedAt, AV45TFTituloMovimentoCreatedAt_To, AV51TFTipoPagamentoNome, AV52TFTipoPagamentoNome_Sel, AV82Pgmname, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30ManageFiltersData", AV30ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E144O2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV19DynamicFiltersEnabled2 = false;
         AssignAttri(sPrefix, false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
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
         AssignAttri(sPrefix, false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TituloMovimentoValor1, AV54TipoPagamentoNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TituloMovimentoValor2, AV55TipoPagamentoNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26TituloMovimentoValor3, AV56TipoPagamentoNome3, AV32ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV53TituloId, AV35TFTituloMovimentoValor, AV36TFTituloMovimentoValor_To, AV38TFTituloMovimentoTipo_Sels, AV39TFTituloMovimentoDataCredito, AV40TFTituloMovimentoDataCredito_To, AV44TFTituloMovimentoCreatedAt, AV45TFTituloMovimentoCreatedAt_To, AV51TFTipoPagamentoNome, AV52TFTipoPagamentoNome_Sel, AV82Pgmname, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30ManageFiltersData", AV30ManageFiltersData);
      }

      protected void E194O2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV21DynamicFiltersOperator2 = 0;
         AssignAttri(sPrefix, false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E154O2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri(sPrefix, false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
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
         AssignAttri(sPrefix, false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TituloMovimentoValor1, AV54TipoPagamentoNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TituloMovimentoValor2, AV55TipoPagamentoNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26TituloMovimentoValor3, AV56TipoPagamentoNome3, AV32ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV53TituloId, AV35TFTituloMovimentoValor, AV36TFTituloMovimentoValor_To, AV38TFTituloMovimentoTipo_Sels, AV39TFTituloMovimentoDataCredito, AV40TFTituloMovimentoDataCredito_To, AV44TFTituloMovimentoCreatedAt, AV45TFTituloMovimentoCreatedAt_To, AV51TFTipoPagamentoNome, AV52TFTipoPagamentoNome_Sel, AV82Pgmname, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30ManageFiltersData", AV30ManageFiltersData);
      }

      protected void E204O2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV25DynamicFiltersOperator3 = 0;
         AssignAttri(sPrefix, false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E114O2( )
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("TituloMovimentoWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV82Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV32ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV32ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV32ManageFiltersExecutionStep), 1, 0));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("TituloMovimentoWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV32ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV32ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV32ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char2 = AV31ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "TituloMovimentoWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV31ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV31ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV82Pgmname+"GridState",  AV31ManageFiltersXml) ;
               AV10GridState.FromXml(AV31ManageFiltersXml, null, "", "");
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV38TFTituloMovimentoTipo_Sels", AV38TFTituloMovimentoTipo_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30ManageFiltersData", AV30ManageFiltersData);
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavTitulomovimentovalor1_Visible = 0;
         AssignProp(sPrefix, false, edtavTitulomovimentovalor1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTitulomovimentovalor1_Visible), 5, 0), true);
         edtavTipopagamentonome1_Visible = 0;
         AssignProp(sPrefix, false, edtavTipopagamentonome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipopagamentonome1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "TITULOMOVIMENTOVALOR") == 0 )
         {
            edtavTitulomovimentovalor1_Visible = 1;
            AssignProp(sPrefix, false, edtavTitulomovimentovalor1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTitulomovimentovalor1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "TIPOPAGAMENTONOME") == 0 )
         {
            edtavTipopagamentonome1_Visible = 1;
            AssignProp(sPrefix, false, edtavTipopagamentonome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipopagamentonome1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavTitulomovimentovalor2_Visible = 0;
         AssignProp(sPrefix, false, edtavTitulomovimentovalor2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTitulomovimentovalor2_Visible), 5, 0), true);
         edtavTipopagamentonome2_Visible = 0;
         AssignProp(sPrefix, false, edtavTipopagamentonome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipopagamentonome2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "TITULOMOVIMENTOVALOR") == 0 )
         {
            edtavTitulomovimentovalor2_Visible = 1;
            AssignProp(sPrefix, false, edtavTitulomovimentovalor2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTitulomovimentovalor2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "TIPOPAGAMENTONOME") == 0 )
         {
            edtavTipopagamentonome2_Visible = 1;
            AssignProp(sPrefix, false, edtavTipopagamentonome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipopagamentonome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavTitulomovimentovalor3_Visible = 0;
         AssignProp(sPrefix, false, edtavTitulomovimentovalor3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTitulomovimentovalor3_Visible), 5, 0), true);
         edtavTipopagamentonome3_Visible = 0;
         AssignProp(sPrefix, false, edtavTipopagamentonome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipopagamentonome3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "TITULOMOVIMENTOVALOR") == 0 )
         {
            edtavTitulomovimentovalor3_Visible = 1;
            AssignProp(sPrefix, false, edtavTitulomovimentovalor3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTitulomovimentovalor3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "TIPOPAGAMENTONOME") == 0 )
         {
            edtavTipopagamentonome3_Visible = 1;
            AssignProp(sPrefix, false, edtavTipopagamentonome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipopagamentonome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = false;
         AssignAttri(sPrefix, false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         AV20DynamicFiltersSelector2 = "TITULOMOVIMENTOVALOR";
         AssignAttri(sPrefix, false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         AV21DynamicFiltersOperator2 = 0;
         AssignAttri(sPrefix, false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AV22TituloMovimentoValor2 = 0;
         AssignAttri(sPrefix, false, "AV22TituloMovimentoValor2", StringUtil.LTrimStr( AV22TituloMovimentoValor2, 18, 2));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri(sPrefix, false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         AV24DynamicFiltersSelector3 = "TITULOMOVIMENTOVALOR";
         AssignAttri(sPrefix, false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         AV25DynamicFiltersOperator3 = 0;
         AssignAttri(sPrefix, false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AV26TituloMovimentoValor3 = 0;
         AssignAttri(sPrefix, false, "AV26TituloMovimentoValor3", StringUtil.LTrimStr( AV26TituloMovimentoValor3, 18, 2));
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV30ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "TituloMovimentoWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV30ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
         AV35TFTituloMovimentoValor = 0;
         AssignAttri(sPrefix, false, "AV35TFTituloMovimentoValor", StringUtil.LTrimStr( AV35TFTituloMovimentoValor, 18, 2));
         AV36TFTituloMovimentoValor_To = 0;
         AssignAttri(sPrefix, false, "AV36TFTituloMovimentoValor_To", StringUtil.LTrimStr( AV36TFTituloMovimentoValor_To, 18, 2));
         AV38TFTituloMovimentoTipo_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV39TFTituloMovimentoDataCredito = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV39TFTituloMovimentoDataCredito", context.localUtil.Format(AV39TFTituloMovimentoDataCredito, "99/99/9999"));
         AV40TFTituloMovimentoDataCredito_To = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV40TFTituloMovimentoDataCredito_To", context.localUtil.Format(AV40TFTituloMovimentoDataCredito_To, "99/99/9999"));
         AV44TFTituloMovimentoCreatedAt = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV44TFTituloMovimentoCreatedAt", context.localUtil.TToC( AV44TFTituloMovimentoCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         AV45TFTituloMovimentoCreatedAt_To = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV45TFTituloMovimentoCreatedAt_To", context.localUtil.TToC( AV45TFTituloMovimentoCreatedAt_To, 10, 8, 0, 3, "/", ":", " "));
         AV51TFTipoPagamentoNome = "";
         AssignAttri(sPrefix, false, "AV51TFTipoPagamentoNome", AV51TFTipoPagamentoNome);
         AV52TFTipoPagamentoNome_Sel = "";
         AssignAttri(sPrefix, false, "AV52TFTipoPagamentoNome_Sel", AV52TFTipoPagamentoNome_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV16DynamicFiltersSelector1 = "TITULOMOVIMENTOVALOR";
         AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AV18TituloMovimentoValor1 = 0;
         AssignAttri(sPrefix, false, "AV18TituloMovimentoValor1", StringUtil.LTrimStr( AV18TituloMovimentoValor1, 18, 2));
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

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV29Session.Get(AV82Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV82Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV29Session.Get(AV82Pgmname+"GridState"), null, "", "");
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
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S232( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV83GXV1 = 1;
         while ( AV83GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV83GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTITULOMOVIMENTOVALOR") == 0 )
            {
               AV35TFTituloMovimentoValor = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV35TFTituloMovimentoValor", StringUtil.LTrimStr( AV35TFTituloMovimentoValor, 18, 2));
               AV36TFTituloMovimentoValor_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV36TFTituloMovimentoValor_To", StringUtil.LTrimStr( AV36TFTituloMovimentoValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTITULOMOVIMENTOTIPO_SEL") == 0 )
            {
               AV37TFTituloMovimentoTipo_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV37TFTituloMovimentoTipo_SelsJson", AV37TFTituloMovimentoTipo_SelsJson);
               AV38TFTituloMovimentoTipo_Sels.FromJSonString(AV37TFTituloMovimentoTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTITULOMOVIMENTODATACREDITO") == 0 )
            {
               AV39TFTituloMovimentoDataCredito = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri(sPrefix, false, "AV39TFTituloMovimentoDataCredito", context.localUtil.Format(AV39TFTituloMovimentoDataCredito, "99/99/9999"));
               AV40TFTituloMovimentoDataCredito_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri(sPrefix, false, "AV40TFTituloMovimentoDataCredito_To", context.localUtil.Format(AV40TFTituloMovimentoDataCredito_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTITULOMOVIMENTOCREATEDAT") == 0 )
            {
               AV44TFTituloMovimentoCreatedAt = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri(sPrefix, false, "AV44TFTituloMovimentoCreatedAt", context.localUtil.TToC( AV44TFTituloMovimentoCreatedAt, 10, 8, 0, 3, "/", ":", " "));
               AV45TFTituloMovimentoCreatedAt_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri(sPrefix, false, "AV45TFTituloMovimentoCreatedAt_To", context.localUtil.TToC( AV45TFTituloMovimentoCreatedAt_To, 10, 8, 0, 3, "/", ":", " "));
               AV46DDO_TituloMovimentoCreatedAtAuxDate = DateTimeUtil.ResetTime(AV44TFTituloMovimentoCreatedAt);
               AssignAttri(sPrefix, false, "AV46DDO_TituloMovimentoCreatedAtAuxDate", context.localUtil.Format(AV46DDO_TituloMovimentoCreatedAtAuxDate, "99/99/9999"));
               AV47DDO_TituloMovimentoCreatedAtAuxDateTo = DateTimeUtil.ResetTime(AV45TFTituloMovimentoCreatedAt_To);
               AssignAttri(sPrefix, false, "AV47DDO_TituloMovimentoCreatedAtAuxDateTo", context.localUtil.Format(AV47DDO_TituloMovimentoCreatedAtAuxDateTo, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPOPAGAMENTONOME") == 0 )
            {
               AV51TFTipoPagamentoNome = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV51TFTipoPagamentoNome", AV51TFTipoPagamentoNome);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPOPAGAMENTONOME_SEL") == 0 )
            {
               AV52TFTipoPagamentoNome_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV52TFTipoPagamentoNome_Sel", AV52TFTipoPagamentoNome_Sel);
            }
            AV83GXV1 = (int)(AV83GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV38TFTituloMovimentoTipo_Sels.Count==0),  AV37TFTituloMovimentoTipo_SelsJson, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV52TFTipoPagamentoNome_Sel)),  AV52TFTipoPagamentoNome_Sel, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char2+"|||"+GXt_char4;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFTipoPagamentoNome)),  AV51TFTipoPagamentoNome, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = ((Convert.ToDecimal(0)==AV35TFTituloMovimentoValor) ? "" : StringUtil.Str( AV35TFTituloMovimentoValor, 18, 2))+"||"+((DateTime.MinValue==AV39TFTituloMovimentoDataCredito) ? "" : context.localUtil.DToC( AV39TFTituloMovimentoDataCredito, 4, "/"))+"|"+((DateTime.MinValue==AV44TFTituloMovimentoCreatedAt) ? "" : context.localUtil.DToC( AV46DDO_TituloMovimentoCreatedAtAuxDate, 4, "/"))+"|"+GXt_char4;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((Convert.ToDecimal(0)==AV36TFTituloMovimentoValor_To) ? "" : StringUtil.Str( AV36TFTituloMovimentoValor_To, 18, 2))+"||"+((DateTime.MinValue==AV40TFTituloMovimentoDataCredito_To) ? "" : context.localUtil.DToC( AV40TFTituloMovimentoDataCredito_To, 4, "/"))+"|"+((DateTime.MinValue==AV45TFTituloMovimentoCreatedAt_To) ? "" : context.localUtil.DToC( AV47DDO_TituloMovimentoCreatedAtAuxDateTo, 4, "/"))+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S212( )
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
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "TITULOMOVIMENTOVALOR") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV18TituloMovimentoValor1 = NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV18TituloMovimentoValor1", StringUtil.LTrimStr( AV18TituloMovimentoValor1, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "TIPOPAGAMENTONOME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV54TipoPagamentoNome1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV54TipoPagamentoNome1", AV54TipoPagamentoNome1);
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
               AV19DynamicFiltersEnabled2 = true;
               AssignAttri(sPrefix, false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri(sPrefix, false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "TITULOMOVIMENTOVALOR") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri(sPrefix, false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV22TituloMovimentoValor2 = NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, ".");
                  AssignAttri(sPrefix, false, "AV22TituloMovimentoValor2", StringUtil.LTrimStr( AV22TituloMovimentoValor2, 18, 2));
               }
               else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "TIPOPAGAMENTONOME") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri(sPrefix, false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV55TipoPagamentoNome2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri(sPrefix, false, "AV55TipoPagamentoNome2", AV55TipoPagamentoNome2);
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
                  AV23DynamicFiltersEnabled3 = true;
                  AssignAttri(sPrefix, false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri(sPrefix, false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "TITULOMOVIMENTOVALOR") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri(sPrefix, false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
                     AV26TituloMovimentoValor3 = NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, ".");
                     AssignAttri(sPrefix, false, "AV26TituloMovimentoValor3", StringUtil.LTrimStr( AV26TituloMovimentoValor3, 18, 2));
                  }
                  else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "TIPOPAGAMENTONOME") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri(sPrefix, false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
                     AV56TipoPagamentoNome3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri(sPrefix, false, "AV56TipoPagamentoNome3", AV56TipoPagamentoNome3);
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
         if ( AV27DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV29Session.Get(AV82Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTITULOMOVIMENTOVALOR",  "",  !((Convert.ToDecimal(0)==AV35TFTituloMovimentoValor)&&(Convert.ToDecimal(0)==AV36TFTituloMovimentoValor_To)),  0,  StringUtil.Trim( StringUtil.Str( AV35TFTituloMovimentoValor, 18, 2)),  ((Convert.ToDecimal(0)==AV35TFTituloMovimentoValor) ? "" : StringUtil.Trim( context.localUtil.Format( AV35TFTituloMovimentoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV36TFTituloMovimentoValor_To, 18, 2)),  ((Convert.ToDecimal(0)==AV36TFTituloMovimentoValor_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV36TFTituloMovimentoValor_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         AV50AuxText = ((AV38TFTituloMovimentoTipo_Sels.Count==1) ? "["+((string)AV38TFTituloMovimentoTipo_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTITULOMOVIMENTOTIPO_SEL",  "",  !(AV38TFTituloMovimentoTipo_Sels.Count==0),  0,  AV38TFTituloMovimentoTipo_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV50AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV50AuxText, "[Baixa]", "Baixa"), "[Juros]", "Juros"), "[Taxa]", "Taxa"), "[Multa]", "Multa")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTITULOMOVIMENTODATACREDITO",  "",  !((DateTime.MinValue==AV39TFTituloMovimentoDataCredito)&&(DateTime.MinValue==AV40TFTituloMovimentoDataCredito_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV39TFTituloMovimentoDataCredito, 4, "/")),  ((DateTime.MinValue==AV39TFTituloMovimentoDataCredito) ? "" : StringUtil.Trim( context.localUtil.Format( AV39TFTituloMovimentoDataCredito, "99/99/9999"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV40TFTituloMovimentoDataCredito_To, 4, "/")),  ((DateTime.MinValue==AV40TFTituloMovimentoDataCredito_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV40TFTituloMovimentoDataCredito_To, "99/99/9999")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTITULOMOVIMENTOCREATEDAT",  "",  !((DateTime.MinValue==AV44TFTituloMovimentoCreatedAt)&&(DateTime.MinValue==AV45TFTituloMovimentoCreatedAt_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV44TFTituloMovimentoCreatedAt, 10, 8, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV44TFTituloMovimentoCreatedAt) ? "" : StringUtil.Trim( context.localUtil.Format( AV44TFTituloMovimentoCreatedAt, "99/99/9999 99:99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV45TFTituloMovimentoCreatedAt_To, 10, 8, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV45TFTituloMovimentoCreatedAt_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV45TFTituloMovimentoCreatedAt_To, "99/99/9999 99:99:99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFTIPOPAGAMENTONOME",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFTipoPagamentoNome)),  0,  AV51TFTipoPagamentoNome,  AV51TFTipoPagamentoNome,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV52TFTipoPagamentoNome_Sel)),  AV52TFTipoPagamentoNome_Sel,  AV52TFTipoPagamentoNome_Sel) ;
         if ( ! (0==AV53TituloId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&TITULOID";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV53TituloId), 9, 0);
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
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV82Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
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
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "TITULOMOVIMENTOVALOR") == 0 ) && ! (Convert.ToDecimal(0)==AV18TituloMovimentoValor1) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Valor movimento",  AV17DynamicFiltersOperator1,  StringUtil.Trim( StringUtil.Str( AV18TituloMovimentoValor1, 18, 2)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( AV18TituloMovimentoValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "="+" "+StringUtil.Trim( context.localUtil.Format( AV18TituloMovimentoValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99")), ">"+" "+StringUtil.Trim( context.localUtil.Format( AV18TituloMovimentoValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "TIPOPAGAMENTONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV54TipoPagamentoNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Tipo Pagamento Nome",  AV17DynamicFiltersOperator1,  AV54TipoPagamentoNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV54TipoPagamentoNome1, "Contém"+" "+AV54TipoPagamentoNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "TITULOMOVIMENTOVALOR") == 0 ) && ! (Convert.ToDecimal(0)==AV22TituloMovimentoValor2) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Valor movimento",  AV21DynamicFiltersOperator2,  StringUtil.Trim( StringUtil.Str( AV22TituloMovimentoValor2, 18, 2)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( AV22TituloMovimentoValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "="+" "+StringUtil.Trim( context.localUtil.Format( AV22TituloMovimentoValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99")), ">"+" "+StringUtil.Trim( context.localUtil.Format( AV22TituloMovimentoValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "TIPOPAGAMENTONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV55TipoPagamentoNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Tipo Pagamento Nome",  AV21DynamicFiltersOperator2,  AV55TipoPagamentoNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV55TipoPagamentoNome2, "Contém"+" "+AV55TipoPagamentoNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "TITULOMOVIMENTOVALOR") == 0 ) && ! (Convert.ToDecimal(0)==AV26TituloMovimentoValor3) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Valor movimento",  AV25DynamicFiltersOperator3,  StringUtil.Trim( StringUtil.Str( AV26TituloMovimentoValor3, 18, 2)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( AV26TituloMovimentoValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "="+" "+StringUtil.Trim( context.localUtil.Format( AV26TituloMovimentoValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99")), ">"+" "+StringUtil.Trim( context.localUtil.Format( AV26TituloMovimentoValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "TIPOPAGAMENTONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV56TipoPagamentoNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Tipo Pagamento Nome",  AV25DynamicFiltersOperator3,  AV56TipoPagamentoNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV56TipoPagamentoNome3, "Contém"+" "+AV56TipoPagamentoNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
         AV8TrnContext.gxTpr_Callerobject = AV82Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "TituloMovimento";
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "TituloId";
         AV9TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV53TituloId), 9, 0);
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV29Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_89_4O2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "", true, 0, "HLP_TituloMovimentoWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_titulomovimentovalor3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitulomovimentovalor3_Internalname, "Titulo Movimento Valor3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitulomovimentovalor3_Internalname, StringUtil.LTrim( StringUtil.NToC( AV26TituloMovimentoValor3, 18, 2, ",", "")), StringUtil.LTrim( ((edtavTitulomovimentovalor3_Enabled!=0) ? context.localUtil.Format( AV26TituloMovimentoValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV26TituloMovimentoValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,96);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitulomovimentovalor3_Jsonclick, 0, "Attribute", "", "", "", "", edtavTitulomovimentovalor3_Visible, edtavTitulomovimentovalor3_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TituloMovimentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipopagamentonome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipopagamentonome3_Internalname, "Tipo Pagamento Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipopagamentonome3_Internalname, AV56TipoPagamentoNome3, StringUtil.RTrim( context.localUtil.Format( AV56TipoPagamentoNome3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipopagamentonome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipopagamentonome3_Visible, edtavTipopagamentonome3_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TituloMovimentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TituloMovimentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_89_4O2e( true) ;
         }
         else
         {
            wb_table3_89_4O2e( false) ;
         }
      }

      protected void wb_table2_64_4O2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "", true, 0, "HLP_TituloMovimentoWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_titulomovimentovalor2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitulomovimentovalor2_Internalname, "Titulo Movimento Valor2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitulomovimentovalor2_Internalname, StringUtil.LTrim( StringUtil.NToC( AV22TituloMovimentoValor2, 18, 2, ",", "")), StringUtil.LTrim( ((edtavTitulomovimentovalor2_Enabled!=0) ? context.localUtil.Format( AV22TituloMovimentoValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV22TituloMovimentoValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,71);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitulomovimentovalor2_Jsonclick, 0, "Attribute", "", "", "", "", edtavTitulomovimentovalor2_Visible, edtavTitulomovimentovalor2_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TituloMovimentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipopagamentonome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipopagamentonome2_Internalname, "Tipo Pagamento Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipopagamentonome2_Internalname, AV55TipoPagamentoNome2, StringUtil.RTrim( context.localUtil.Format( AV55TipoPagamentoNome2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipopagamentonome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipopagamentonome2_Visible, edtavTipopagamentonome2_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TituloMovimentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TituloMovimentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TituloMovimentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_64_4O2e( true) ;
         }
         else
         {
            wb_table2_64_4O2e( false) ;
         }
      }

      protected void wb_table1_39_4O2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 0, "HLP_TituloMovimentoWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_titulomovimentovalor1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitulomovimentovalor1_Internalname, "Titulo Movimento Valor1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitulomovimentovalor1_Internalname, StringUtil.LTrim( StringUtil.NToC( AV18TituloMovimentoValor1, 18, 2, ",", "")), StringUtil.LTrim( ((edtavTitulomovimentovalor1_Enabled!=0) ? context.localUtil.Format( AV18TituloMovimentoValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV18TituloMovimentoValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,46);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitulomovimentovalor1_Jsonclick, 0, "Attribute", "", "", "", "", edtavTitulomovimentovalor1_Visible, edtavTitulomovimentovalor1_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TituloMovimentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipopagamentonome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipopagamentonome1_Internalname, "Tipo Pagamento Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipopagamentonome1_Internalname, AV54TipoPagamentoNome1, StringUtil.RTrim( context.localUtil.Format( AV54TipoPagamentoNome1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipopagamentonome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipopagamentonome1_Visible, edtavTipopagamentonome1_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TituloMovimentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TituloMovimentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TituloMovimentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_39_4O2e( true) ;
         }
         else
         {
            wb_table1_39_4O2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV53TituloId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV53TituloId", StringUtil.LTrimStr( (decimal)(AV53TituloId), 9, 0));
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
         PA4O2( ) ;
         WS4O2( ) ;
         WE4O2( ) ;
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
         sCtrlAV53TituloId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA4O2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "titulomovimentoww", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA4O2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV53TituloId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV53TituloId", StringUtil.LTrimStr( (decimal)(AV53TituloId), 9, 0));
         }
         wcpOAV53TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV53TituloId"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV53TituloId != wcpOAV53TituloId ) ) )
         {
            setjustcreated();
         }
         wcpOAV53TituloId = AV53TituloId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV53TituloId = cgiGet( sPrefix+"AV53TituloId_CTRL");
         if ( StringUtil.Len( sCtrlAV53TituloId) > 0 )
         {
            AV53TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV53TituloId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV53TituloId", StringUtil.LTrimStr( (decimal)(AV53TituloId), 9, 0));
         }
         else
         {
            AV53TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV53TituloId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
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
         PA4O2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS4O2( ) ;
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
         WS4O2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV53TituloId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV53TituloId), 9, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV53TituloId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV53TituloId_CTRL", StringUtil.RTrim( sCtrlAV53TituloId));
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
         WE4O2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019145890", true, true);
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
         context.AddJavascriptSource("titulomovimentoww.js", "?202561019145891", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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

      protected void SubsflControlProps_1072( )
      {
         edtTituloMovimentoId_Internalname = sPrefix+"TITULOMOVIMENTOID_"+sGXsfl_107_idx;
         edtTipoPagamentoId_Internalname = sPrefix+"TIPOPAGAMENTOID_"+sGXsfl_107_idx;
         edtTituloId_Internalname = sPrefix+"TITULOID_"+sGXsfl_107_idx;
         edtTituloMovimentoValor_Internalname = sPrefix+"TITULOMOVIMENTOVALOR_"+sGXsfl_107_idx;
         cmbTituloMovimentoTipo_Internalname = sPrefix+"TITULOMOVIMENTOTIPO_"+sGXsfl_107_idx;
         chkTituloMovimentoSoma_Internalname = sPrefix+"TITULOMOVIMENTOSOMA_"+sGXsfl_107_idx;
         edtTituloMovimentoDataCredito_Internalname = sPrefix+"TITULOMOVIMENTODATACREDITO_"+sGXsfl_107_idx;
         edtTituloMovimentoCreatedAt_Internalname = sPrefix+"TITULOMOVIMENTOCREATEDAT_"+sGXsfl_107_idx;
         edtTituloMovimentoUpdatedAt_Internalname = sPrefix+"TITULOMOVIMENTOUPDATEDAT_"+sGXsfl_107_idx;
         edtTipoPagamentoNome_Internalname = sPrefix+"TIPOPAGAMENTONOME_"+sGXsfl_107_idx;
      }

      protected void SubsflControlProps_fel_1072( )
      {
         edtTituloMovimentoId_Internalname = sPrefix+"TITULOMOVIMENTOID_"+sGXsfl_107_fel_idx;
         edtTipoPagamentoId_Internalname = sPrefix+"TIPOPAGAMENTOID_"+sGXsfl_107_fel_idx;
         edtTituloId_Internalname = sPrefix+"TITULOID_"+sGXsfl_107_fel_idx;
         edtTituloMovimentoValor_Internalname = sPrefix+"TITULOMOVIMENTOVALOR_"+sGXsfl_107_fel_idx;
         cmbTituloMovimentoTipo_Internalname = sPrefix+"TITULOMOVIMENTOTIPO_"+sGXsfl_107_fel_idx;
         chkTituloMovimentoSoma_Internalname = sPrefix+"TITULOMOVIMENTOSOMA_"+sGXsfl_107_fel_idx;
         edtTituloMovimentoDataCredito_Internalname = sPrefix+"TITULOMOVIMENTODATACREDITO_"+sGXsfl_107_fel_idx;
         edtTituloMovimentoCreatedAt_Internalname = sPrefix+"TITULOMOVIMENTOCREATEDAT_"+sGXsfl_107_fel_idx;
         edtTituloMovimentoUpdatedAt_Internalname = sPrefix+"TITULOMOVIMENTOUPDATEDAT_"+sGXsfl_107_fel_idx;
         edtTipoPagamentoNome_Internalname = sPrefix+"TIPOPAGAMENTONOME_"+sGXsfl_107_fel_idx;
      }

      protected void sendrow_1072( )
      {
         sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
         SubsflControlProps_1072( ) ;
         WB4O0( ) ;
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
               context.WriteHtmlText( " class=\""+"GridWithBorderColor WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_107_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloMovimentoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A270TituloMovimentoId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A270TituloMovimentoId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloMovimentoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoPagamentoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A288TipoPagamentoId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoPagamentoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A261TituloId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloMovimentoValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A271TituloMovimentoValor, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A271TituloMovimentoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtTituloMovimentoValor_Link,(string)"",(string)"",(string)"",(string)edtTituloMovimentoValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbTituloMovimentoTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "TITULOMOVIMENTOTIPO_" + sGXsfl_107_idx;
               cmbTituloMovimentoTipo.Name = GXCCtl;
               cmbTituloMovimentoTipo.WebTags = "";
               cmbTituloMovimentoTipo.addItem("Baixa", "Baixa", 0);
               cmbTituloMovimentoTipo.addItem("Juros", "Juros", 0);
               cmbTituloMovimentoTipo.addItem("Taxa", "Taxa", 0);
               cmbTituloMovimentoTipo.addItem("Multa", "Multa", 0);
               if ( cmbTituloMovimentoTipo.ItemCount > 0 )
               {
                  A272TituloMovimentoTipo = cmbTituloMovimentoTipo.getValidValue(A272TituloMovimentoTipo);
                  n272TituloMovimentoTipo = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbTituloMovimentoTipo,(string)cmbTituloMovimentoTipo_Internalname,StringUtil.RTrim( A272TituloMovimentoTipo),(short)1,(string)cmbTituloMovimentoTipo_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbTituloMovimentoTipo.CurrentValue = StringUtil.RTrim( A272TituloMovimentoTipo);
            AssignProp(sPrefix, false, cmbTituloMovimentoTipo_Internalname, "Values", (string)(cmbTituloMovimentoTipo.ToJavascriptSource()), !bGXsfl_107_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "TITULOMOVIMENTOSOMA_" + sGXsfl_107_idx;
            chkTituloMovimentoSoma.Name = GXCCtl;
            chkTituloMovimentoSoma.WebTags = "";
            chkTituloMovimentoSoma.Caption = "";
            AssignProp(sPrefix, false, chkTituloMovimentoSoma_Internalname, "TitleCaption", chkTituloMovimentoSoma.Caption, !bGXsfl_107_Refreshing);
            chkTituloMovimentoSoma.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTituloMovimentoSoma_Internalname,StringUtil.BoolToStr( A274TituloMovimentoSoma),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloMovimentoDataCredito_Internalname,context.localUtil.Format(A279TituloMovimentoDataCredito, "99/99/9999"),context.localUtil.Format( A279TituloMovimentoDataCredito, "99/99/9999"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloMovimentoDataCredito_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloMovimentoCreatedAt_Internalname,context.localUtil.TToC( A280TituloMovimentoCreatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A280TituloMovimentoCreatedAt, "99/99/9999 99:99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloMovimentoCreatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)19,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloMovimentoUpdatedAt_Internalname,context.localUtil.TToC( A281TituloMovimentoUpdatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A281TituloMovimentoUpdatedAt, "99/99/9999 99:99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloMovimentoUpdatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)19,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoPagamentoNome_Internalname,(string)A289TipoPagamentoNome,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtTipoPagamentoNome_Link,(string)"",(string)"",(string)"",(string)edtTipoPagamentoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes4O2( ) ;
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
         cmbavDynamicfiltersselector1.addItem("TITULOMOVIMENTOVALOR", "Valor movimento", 0);
         cmbavDynamicfiltersselector1.addItem("TIPOPAGAMENTONOME", "Tipo Pagamento Nome", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator1.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("TITULOMOVIMENTOVALOR", "Valor movimento", 0);
         cmbavDynamicfiltersselector2.addItem("TIPOPAGAMENTONOME", "Tipo Pagamento Nome", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("TITULOMOVIMENTOVALOR", "Valor movimento", 0);
         cmbavDynamicfiltersselector3.addItem("TIPOPAGAMENTONOME", "Tipo Pagamento Nome", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
         }
         GXCCtl = "TITULOMOVIMENTOTIPO_" + sGXsfl_107_idx;
         cmbTituloMovimentoTipo.Name = GXCCtl;
         cmbTituloMovimentoTipo.WebTags = "";
         cmbTituloMovimentoTipo.addItem("Baixa", "Baixa", 0);
         cmbTituloMovimentoTipo.addItem("Juros", "Juros", 0);
         cmbTituloMovimentoTipo.addItem("Taxa", "Taxa", 0);
         cmbTituloMovimentoTipo.addItem("Multa", "Multa", 0);
         if ( cmbTituloMovimentoTipo.ItemCount > 0 )
         {
         }
         GXCCtl = "TITULOMOVIMENTOSOMA_" + sGXsfl_107_idx;
         chkTituloMovimentoSoma.Name = GXCCtl;
         chkTituloMovimentoSoma.WebTags = "";
         chkTituloMovimentoSoma.Caption = "";
         AssignProp(sPrefix, false, chkTituloMovimentoSoma_Internalname, "TitleCaption", chkTituloMovimentoSoma.Caption, !bGXsfl_107_Refreshing);
         chkTituloMovimentoSoma.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl107( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"107\">") ;
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
            context.SendWebValue( "Movimento Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Pagamento Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Título") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Valor") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Movimento Soma") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Data de crédito") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Data efetivação") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Atualizado em") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo de pagamento") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A270TituloMovimentoId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A271TituloMovimentoValor, 18, 2, ".", ""))));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtTituloMovimentoValor_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A272TituloMovimentoTipo));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A274TituloMovimentoSoma)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A279TituloMovimentoDataCredito, "99/99/9999")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A280TituloMovimentoCreatedAt, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A281TituloMovimentoUpdatedAt, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A289TipoPagamentoNome));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtTipoPagamentoNome_Link));
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
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         Ddo_managefilters_Internalname = sPrefix+"DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = sPrefix+"vFILTERFULLTEXT";
         divTablefilters_Internalname = sPrefix+"TABLEFILTERS";
         divTablerightheader_Internalname = sPrefix+"TABLERIGHTHEADER";
         divTableheadercontent_Internalname = sPrefix+"TABLEHEADERCONTENT";
         lblDynamicfiltersprefix1_Internalname = sPrefix+"DYNAMICFILTERSPREFIX1";
         cmbavDynamicfiltersselector1_Internalname = sPrefix+"vDYNAMICFILTERSSELECTOR1";
         lblDynamicfiltersmiddle1_Internalname = sPrefix+"DYNAMICFILTERSMIDDLE1";
         cmbavDynamicfiltersoperator1_Internalname = sPrefix+"vDYNAMICFILTERSOPERATOR1";
         edtavTitulomovimentovalor1_Internalname = sPrefix+"vTITULOMOVIMENTOVALOR1";
         cellFilter_titulomovimentovalor1_cell_Internalname = sPrefix+"FILTER_TITULOMOVIMENTOVALOR1_CELL";
         edtavTipopagamentonome1_Internalname = sPrefix+"vTIPOPAGAMENTONOME1";
         cellFilter_tipopagamentonome1_cell_Internalname = sPrefix+"FILTER_TIPOPAGAMENTONOME1_CELL";
         imgAdddynamicfilters1_Internalname = sPrefix+"ADDDYNAMICFILTERS1";
         cellDynamicfilters_addfilter1_cell_Internalname = sPrefix+"DYNAMICFILTERS_ADDFILTER1_CELL";
         imgRemovedynamicfilters1_Internalname = sPrefix+"REMOVEDYNAMICFILTERS1";
         cellDynamicfilters_removefilter1_cell_Internalname = sPrefix+"DYNAMICFILTERS_REMOVEFILTER1_CELL";
         tblTablemergeddynamicfilters1_Internalname = sPrefix+"TABLEMERGEDDYNAMICFILTERS1";
         divTabledynamicfiltersrow1_Internalname = sPrefix+"TABLEDYNAMICFILTERSROW1";
         lblDynamicfiltersprefix2_Internalname = sPrefix+"DYNAMICFILTERSPREFIX2";
         cmbavDynamicfiltersselector2_Internalname = sPrefix+"vDYNAMICFILTERSSELECTOR2";
         lblDynamicfiltersmiddle2_Internalname = sPrefix+"DYNAMICFILTERSMIDDLE2";
         cmbavDynamicfiltersoperator2_Internalname = sPrefix+"vDYNAMICFILTERSOPERATOR2";
         edtavTitulomovimentovalor2_Internalname = sPrefix+"vTITULOMOVIMENTOVALOR2";
         cellFilter_titulomovimentovalor2_cell_Internalname = sPrefix+"FILTER_TITULOMOVIMENTOVALOR2_CELL";
         edtavTipopagamentonome2_Internalname = sPrefix+"vTIPOPAGAMENTONOME2";
         cellFilter_tipopagamentonome2_cell_Internalname = sPrefix+"FILTER_TIPOPAGAMENTONOME2_CELL";
         imgAdddynamicfilters2_Internalname = sPrefix+"ADDDYNAMICFILTERS2";
         cellDynamicfilters_addfilter2_cell_Internalname = sPrefix+"DYNAMICFILTERS_ADDFILTER2_CELL";
         imgRemovedynamicfilters2_Internalname = sPrefix+"REMOVEDYNAMICFILTERS2";
         cellDynamicfilters_removefilter2_cell_Internalname = sPrefix+"DYNAMICFILTERS_REMOVEFILTER2_CELL";
         tblTablemergeddynamicfilters2_Internalname = sPrefix+"TABLEMERGEDDYNAMICFILTERS2";
         divTabledynamicfiltersrow2_Internalname = sPrefix+"TABLEDYNAMICFILTERSROW2";
         lblDynamicfiltersprefix3_Internalname = sPrefix+"DYNAMICFILTERSPREFIX3";
         cmbavDynamicfiltersselector3_Internalname = sPrefix+"vDYNAMICFILTERSSELECTOR3";
         lblDynamicfiltersmiddle3_Internalname = sPrefix+"DYNAMICFILTERSMIDDLE3";
         cmbavDynamicfiltersoperator3_Internalname = sPrefix+"vDYNAMICFILTERSOPERATOR3";
         edtavTitulomovimentovalor3_Internalname = sPrefix+"vTITULOMOVIMENTOVALOR3";
         cellFilter_titulomovimentovalor3_cell_Internalname = sPrefix+"FILTER_TITULOMOVIMENTOVALOR3_CELL";
         edtavTipopagamentonome3_Internalname = sPrefix+"vTIPOPAGAMENTONOME3";
         cellFilter_tipopagamentonome3_cell_Internalname = sPrefix+"FILTER_TIPOPAGAMENTONOME3_CELL";
         imgRemovedynamicfilters3_Internalname = sPrefix+"REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = sPrefix+"DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = sPrefix+"TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = sPrefix+"TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = sPrefix+"TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = sPrefix+"ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         Dvpanel_tableheader_Internalname = sPrefix+"DVPANEL_TABLEHEADER";
         edtTituloMovimentoId_Internalname = sPrefix+"TITULOMOVIMENTOID";
         edtTipoPagamentoId_Internalname = sPrefix+"TIPOPAGAMENTOID";
         edtTituloId_Internalname = sPrefix+"TITULOID";
         edtTituloMovimentoValor_Internalname = sPrefix+"TITULOMOVIMENTOVALOR";
         cmbTituloMovimentoTipo_Internalname = sPrefix+"TITULOMOVIMENTOTIPO";
         chkTituloMovimentoSoma_Internalname = sPrefix+"TITULOMOVIMENTOSOMA";
         edtTituloMovimentoDataCredito_Internalname = sPrefix+"TITULOMOVIMENTODATACREDITO";
         edtTituloMovimentoCreatedAt_Internalname = sPrefix+"TITULOMOVIMENTOCREATEDAT";
         edtTituloMovimentoUpdatedAt_Internalname = sPrefix+"TITULOMOVIMENTOUPDATEDAT";
         edtTipoPagamentoNome_Internalname = sPrefix+"TIPOPAGAMENTONOME";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         lblJsdynamicfilters_Internalname = sPrefix+"JSDYNAMICFILTERS";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         edtavDdo_titulomovimentodatacreditoauxdatetext_Internalname = sPrefix+"vDDO_TITULOMOVIMENTODATACREDITOAUXDATETEXT";
         Tftitulomovimentodatacredito_rangepicker_Internalname = sPrefix+"TFTITULOMOVIMENTODATACREDITO_RANGEPICKER";
         divDdo_titulomovimentodatacreditoauxdates_Internalname = sPrefix+"DDO_TITULOMOVIMENTODATACREDITOAUXDATES";
         edtavDdo_titulomovimentocreatedatauxdatetext_Internalname = sPrefix+"vDDO_TITULOMOVIMENTOCREATEDATAUXDATETEXT";
         Tftitulomovimentocreatedat_rangepicker_Internalname = sPrefix+"TFTITULOMOVIMENTOCREATEDAT_RANGEPICKER";
         divDdo_titulomovimentocreatedatauxdates_Internalname = sPrefix+"DDO_TITULOMOVIMENTOCREATEDATAUXDATES";
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
         edtTipoPagamentoNome_Jsonclick = "";
         edtTipoPagamentoNome_Link = "";
         edtTituloMovimentoUpdatedAt_Jsonclick = "";
         edtTituloMovimentoCreatedAt_Jsonclick = "";
         edtTituloMovimentoDataCredito_Jsonclick = "";
         chkTituloMovimentoSoma.Caption = "";
         cmbTituloMovimentoTipo_Jsonclick = "";
         edtTituloMovimentoValor_Jsonclick = "";
         edtTituloMovimentoValor_Link = "";
         edtTituloId_Jsonclick = "";
         edtTipoPagamentoId_Jsonclick = "";
         edtTituloMovimentoId_Jsonclick = "";
         subGrid_Class = "GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavTipopagamentonome1_Jsonclick = "";
         edtavTipopagamentonome1_Enabled = 1;
         edtavTitulomovimentovalor1_Jsonclick = "";
         edtavTitulomovimentovalor1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavTipopagamentonome2_Jsonclick = "";
         edtavTipopagamentonome2_Enabled = 1;
         edtavTitulomovimentovalor2_Jsonclick = "";
         edtavTitulomovimentovalor2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavTipopagamentonome3_Jsonclick = "";
         edtavTipopagamentonome3_Enabled = 1;
         edtavTitulomovimentovalor3_Jsonclick = "";
         edtavTitulomovimentovalor3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavTipopagamentonome3_Visible = 1;
         edtavTitulomovimentovalor3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavTipopagamentonome2_Visible = 1;
         edtavTitulomovimentovalor2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavTipopagamentonome1_Visible = 1;
         edtavTitulomovimentovalor1_Visible = 1;
         edtTipoPagamentoNome_Enabled = 0;
         edtTituloMovimentoUpdatedAt_Enabled = 0;
         edtTituloMovimentoCreatedAt_Enabled = 0;
         edtTituloMovimentoDataCredito_Enabled = 0;
         chkTituloMovimentoSoma.Enabled = 0;
         cmbTituloMovimentoTipo.Enabled = 0;
         edtTituloMovimentoValor_Enabled = 0;
         edtTituloId_Enabled = 0;
         edtTipoPagamentoId_Enabled = 0;
         edtTituloMovimentoId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_titulomovimentocreatedatauxdatetext_Jsonclick = "";
         edtavDdo_titulomovimentodatacreditoauxdatetext_Jsonclick = "";
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
         Ddo_grid_Format = "18.2||||";
         Ddo_grid_Datalistproc = "TituloMovimentoWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|Baixa:Baixa,Juros:Juros,Taxa:Taxa,Multa:Multa|||";
         Ddo_grid_Allowmultipleselection = "|T|||";
         Ddo_grid_Datalisttype = "|FixedValues|||Dynamic";
         Ddo_grid_Includedatalist = "|T|||T";
         Ddo_grid_Filterisrange = "T||P|P|";
         Ddo_grid_Filtertype = "Numeric||Date|Date|Character";
         Ddo_grid_Includefilter = "T||T|T|T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|5|6";
         Ddo_grid_Columnids = "3:TituloMovimentoValor|4:TituloMovimentoTipo|6:TituloMovimentoDataCredito|7:TituloMovimentoCreatedAt|9:TipoPagamentoNome";
         Ddo_grid_Gridinternalname = "";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"AV53TituloId","fld":"vTITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloMovimentoValor1","fld":"vTITULOMOVIMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV54TipoPagamentoNome1","fld":"vTIPOPAGAMENTONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TituloMovimentoValor2","fld":"vTITULOMOVIMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV55TipoPagamentoNome2","fld":"vTIPOPAGAMENTONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TituloMovimentoValor3","fld":"vTITULOMOVIMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV56TipoPagamentoNome3","fld":"vTIPOPAGAMENTONOME3","type":"svchar"},{"av":"AV35TFTituloMovimentoValor","fld":"vTFTITULOMOVIMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFTituloMovimentoValor_To","fld":"vTFTITULOMOVIMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV38TFTituloMovimentoTipo_Sels","fld":"vTFTITULOMOVIMENTOTIPO_SELS","type":""},{"av":"AV39TFTituloMovimentoDataCredito","fld":"vTFTITULOMOVIMENTODATACREDITO","type":"date"},{"av":"AV40TFTituloMovimentoDataCredito_To","fld":"vTFTITULOMOVIMENTODATACREDITO_TO","type":"date"},{"av":"AV44TFTituloMovimentoCreatedAt","fld":"vTFTITULOMOVIMENTOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV45TFTituloMovimentoCreatedAt_To","fld":"vTFTITULOMOVIMENTOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV51TFTipoPagamentoNome","fld":"vTFTIPOPAGAMENTONOME","type":"svchar"},{"av":"AV52TFTipoPagamentoNome_Sel","fld":"vTFTIPOPAGAMENTONOME_SEL","type":"svchar"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV82Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E124O2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloMovimentoValor1","fld":"vTITULOMOVIMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV54TipoPagamentoNome1","fld":"vTIPOPAGAMENTONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TituloMovimentoValor2","fld":"vTITULOMOVIMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV55TipoPagamentoNome2","fld":"vTIPOPAGAMENTONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TituloMovimentoValor3","fld":"vTITULOMOVIMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV56TipoPagamentoNome3","fld":"vTIPOPAGAMENTONOME3","type":"svchar"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV53TituloId","fld":"vTITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35TFTituloMovimentoValor","fld":"vTFTITULOMOVIMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFTituloMovimentoValor_To","fld":"vTFTITULOMOVIMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV38TFTituloMovimentoTipo_Sels","fld":"vTFTITULOMOVIMENTOTIPO_SELS","type":""},{"av":"AV39TFTituloMovimentoDataCredito","fld":"vTFTITULOMOVIMENTODATACREDITO","type":"date"},{"av":"AV40TFTituloMovimentoDataCredito_To","fld":"vTFTITULOMOVIMENTODATACREDITO_TO","type":"date"},{"av":"AV44TFTituloMovimentoCreatedAt","fld":"vTFTITULOMOVIMENTOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV45TFTituloMovimentoCreatedAt_To","fld":"vTFTITULOMOVIMENTOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV51TFTipoPagamentoNome","fld":"vTFTIPOPAGAMENTONOME","type":"svchar"},{"av":"AV52TFTipoPagamentoNome_Sel","fld":"vTFTIPOPAGAMENTONOME_SEL","type":"svchar"},{"av":"AV82Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV35TFTituloMovimentoValor","fld":"vTFTITULOMOVIMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFTituloMovimentoValor_To","fld":"vTFTITULOMOVIMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV37TFTituloMovimentoTipo_SelsJson","fld":"vTFTITULOMOVIMENTOTIPO_SELSJSON","type":"vchar"},{"av":"AV38TFTituloMovimentoTipo_Sels","fld":"vTFTITULOMOVIMENTOTIPO_SELS","type":""},{"av":"AV39TFTituloMovimentoDataCredito","fld":"vTFTITULOMOVIMENTODATACREDITO","type":"date"},{"av":"AV40TFTituloMovimentoDataCredito_To","fld":"vTFTITULOMOVIMENTODATACREDITO_TO","type":"date"},{"av":"AV44TFTituloMovimentoCreatedAt","fld":"vTFTITULOMOVIMENTOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV45TFTituloMovimentoCreatedAt_To","fld":"vTFTITULOMOVIMENTOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV51TFTipoPagamentoNome","fld":"vTFTIPOPAGAMENTONOME","type":"svchar"},{"av":"AV52TFTipoPagamentoNome_Sel","fld":"vTFTIPOPAGAMENTONOME_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E234O2","iparms":[{"av":"A270TituloMovimentoId","fld":"TITULOMOVIMENTOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A288TipoPagamentoId","fld":"TIPOPAGAMENTOID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"edtTituloMovimentoValor_Link","ctrl":"TITULOMOVIMENTOVALOR","prop":"Link"},{"av":"edtTipoPagamentoNome_Link","ctrl":"TIPOPAGAMENTONOME","prop":"Link"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E164O2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloMovimentoValor1","fld":"vTITULOMOVIMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV54TipoPagamentoNome1","fld":"vTIPOPAGAMENTONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TituloMovimentoValor2","fld":"vTITULOMOVIMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV55TipoPagamentoNome2","fld":"vTIPOPAGAMENTONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TituloMovimentoValor3","fld":"vTITULOMOVIMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV56TipoPagamentoNome3","fld":"vTIPOPAGAMENTONOME3","type":"svchar"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV53TituloId","fld":"vTITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35TFTituloMovimentoValor","fld":"vTFTITULOMOVIMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFTituloMovimentoValor_To","fld":"vTFTITULOMOVIMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV38TFTituloMovimentoTipo_Sels","fld":"vTFTITULOMOVIMENTOTIPO_SELS","type":""},{"av":"AV39TFTituloMovimentoDataCredito","fld":"vTFTITULOMOVIMENTODATACREDITO","type":"date"},{"av":"AV40TFTituloMovimentoDataCredito_To","fld":"vTFTITULOMOVIMENTODATACREDITO_TO","type":"date"},{"av":"AV44TFTituloMovimentoCreatedAt","fld":"vTFTITULOMOVIMENTOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV45TFTituloMovimentoCreatedAt_To","fld":"vTFTITULOMOVIMENTOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV51TFTipoPagamentoNome","fld":"vTFTIPOPAGAMENTONOME","type":"svchar"},{"av":"AV52TFTipoPagamentoNome_Sel","fld":"vTFTIPOPAGAMENTONOME_SEL","type":"svchar"},{"av":"AV82Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E134O2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloMovimentoValor1","fld":"vTITULOMOVIMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV54TipoPagamentoNome1","fld":"vTIPOPAGAMENTONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TituloMovimentoValor2","fld":"vTITULOMOVIMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV55TipoPagamentoNome2","fld":"vTIPOPAGAMENTONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TituloMovimentoValor3","fld":"vTITULOMOVIMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV56TipoPagamentoNome3","fld":"vTIPOPAGAMENTONOME3","type":"svchar"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV53TituloId","fld":"vTITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35TFTituloMovimentoValor","fld":"vTFTITULOMOVIMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFTituloMovimentoValor_To","fld":"vTFTITULOMOVIMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV38TFTituloMovimentoTipo_Sels","fld":"vTFTITULOMOVIMENTOTIPO_SELS","type":""},{"av":"AV39TFTituloMovimentoDataCredito","fld":"vTFTITULOMOVIMENTODATACREDITO","type":"date"},{"av":"AV40TFTituloMovimentoDataCredito_To","fld":"vTFTITULOMOVIMENTODATACREDITO_TO","type":"date"},{"av":"AV44TFTituloMovimentoCreatedAt","fld":"vTFTITULOMOVIMENTOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV45TFTituloMovimentoCreatedAt_To","fld":"vTFTITULOMOVIMENTOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV51TFTipoPagamentoNome","fld":"vTFTIPOPAGAMENTONOME","type":"svchar"},{"av":"AV52TFTipoPagamentoNome_Sel","fld":"vTFTIPOPAGAMENTONOME_SEL","type":"svchar"},{"av":"AV82Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TituloMovimentoValor2","fld":"vTITULOMOVIMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TituloMovimentoValor3","fld":"vTITULOMOVIMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloMovimentoValor1","fld":"vTITULOMOVIMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV54TipoPagamentoNome1","fld":"vTIPOPAGAMENTONOME1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV55TipoPagamentoNome2","fld":"vTIPOPAGAMENTONOME2","type":"svchar"},{"av":"AV56TipoPagamentoNome3","fld":"vTIPOPAGAMENTONOME3","type":"svchar"},{"av":"edtavTitulomovimentovalor2_Visible","ctrl":"vTITULOMOVIMENTOVALOR2","prop":"Visible"},{"av":"edtavTipopagamentonome2_Visible","ctrl":"vTIPOPAGAMENTONOME2","prop":"Visible"},{"av":"edtavTitulomovimentovalor3_Visible","ctrl":"vTITULOMOVIMENTOVALOR3","prop":"Visible"},{"av":"edtavTipopagamentonome3_Visible","ctrl":"vTIPOPAGAMENTONOME3","prop":"Visible"},{"av":"edtavTitulomovimentovalor1_Visible","ctrl":"vTITULOMOVIMENTOVALOR1","prop":"Visible"},{"av":"edtavTipopagamentonome1_Visible","ctrl":"vTIPOPAGAMENTONOME1","prop":"Visible"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E174O2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"edtavTitulomovimentovalor1_Visible","ctrl":"vTITULOMOVIMENTOVALOR1","prop":"Visible"},{"av":"edtavTipopagamentonome1_Visible","ctrl":"vTIPOPAGAMENTONOME1","prop":"Visible"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E184O2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloMovimentoValor1","fld":"vTITULOMOVIMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV54TipoPagamentoNome1","fld":"vTIPOPAGAMENTONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TituloMovimentoValor2","fld":"vTITULOMOVIMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV55TipoPagamentoNome2","fld":"vTIPOPAGAMENTONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TituloMovimentoValor3","fld":"vTITULOMOVIMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV56TipoPagamentoNome3","fld":"vTIPOPAGAMENTONOME3","type":"svchar"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV53TituloId","fld":"vTITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35TFTituloMovimentoValor","fld":"vTFTITULOMOVIMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFTituloMovimentoValor_To","fld":"vTFTITULOMOVIMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV38TFTituloMovimentoTipo_Sels","fld":"vTFTITULOMOVIMENTOTIPO_SELS","type":""},{"av":"AV39TFTituloMovimentoDataCredito","fld":"vTFTITULOMOVIMENTODATACREDITO","type":"date"},{"av":"AV40TFTituloMovimentoDataCredito_To","fld":"vTFTITULOMOVIMENTODATACREDITO_TO","type":"date"},{"av":"AV44TFTituloMovimentoCreatedAt","fld":"vTFTITULOMOVIMENTOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV45TFTituloMovimentoCreatedAt_To","fld":"vTFTITULOMOVIMENTOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV51TFTipoPagamentoNome","fld":"vTFTIPOPAGAMENTONOME","type":"svchar"},{"av":"AV52TFTipoPagamentoNome_Sel","fld":"vTFTIPOPAGAMENTONOME_SEL","type":"svchar"},{"av":"AV82Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E144O2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloMovimentoValor1","fld":"vTITULOMOVIMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV54TipoPagamentoNome1","fld":"vTIPOPAGAMENTONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TituloMovimentoValor2","fld":"vTITULOMOVIMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV55TipoPagamentoNome2","fld":"vTIPOPAGAMENTONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TituloMovimentoValor3","fld":"vTITULOMOVIMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV56TipoPagamentoNome3","fld":"vTIPOPAGAMENTONOME3","type":"svchar"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV53TituloId","fld":"vTITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35TFTituloMovimentoValor","fld":"vTFTITULOMOVIMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFTituloMovimentoValor_To","fld":"vTFTITULOMOVIMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV38TFTituloMovimentoTipo_Sels","fld":"vTFTITULOMOVIMENTOTIPO_SELS","type":""},{"av":"AV39TFTituloMovimentoDataCredito","fld":"vTFTITULOMOVIMENTODATACREDITO","type":"date"},{"av":"AV40TFTituloMovimentoDataCredito_To","fld":"vTFTITULOMOVIMENTODATACREDITO_TO","type":"date"},{"av":"AV44TFTituloMovimentoCreatedAt","fld":"vTFTITULOMOVIMENTOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV45TFTituloMovimentoCreatedAt_To","fld":"vTFTITULOMOVIMENTOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV51TFTipoPagamentoNome","fld":"vTFTIPOPAGAMENTONOME","type":"svchar"},{"av":"AV52TFTipoPagamentoNome_Sel","fld":"vTFTIPOPAGAMENTONOME_SEL","type":"svchar"},{"av":"AV82Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TituloMovimentoValor2","fld":"vTITULOMOVIMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TituloMovimentoValor3","fld":"vTITULOMOVIMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloMovimentoValor1","fld":"vTITULOMOVIMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV54TipoPagamentoNome1","fld":"vTIPOPAGAMENTONOME1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV55TipoPagamentoNome2","fld":"vTIPOPAGAMENTONOME2","type":"svchar"},{"av":"AV56TipoPagamentoNome3","fld":"vTIPOPAGAMENTONOME3","type":"svchar"},{"av":"edtavTitulomovimentovalor2_Visible","ctrl":"vTITULOMOVIMENTOVALOR2","prop":"Visible"},{"av":"edtavTipopagamentonome2_Visible","ctrl":"vTIPOPAGAMENTONOME2","prop":"Visible"},{"av":"edtavTitulomovimentovalor3_Visible","ctrl":"vTITULOMOVIMENTOVALOR3","prop":"Visible"},{"av":"edtavTipopagamentonome3_Visible","ctrl":"vTIPOPAGAMENTONOME3","prop":"Visible"},{"av":"edtavTitulomovimentovalor1_Visible","ctrl":"vTITULOMOVIMENTOVALOR1","prop":"Visible"},{"av":"edtavTipopagamentonome1_Visible","ctrl":"vTIPOPAGAMENTONOME1","prop":"Visible"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E194O2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"edtavTitulomovimentovalor2_Visible","ctrl":"vTITULOMOVIMENTOVALOR2","prop":"Visible"},{"av":"edtavTipopagamentonome2_Visible","ctrl":"vTIPOPAGAMENTONOME2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E154O2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloMovimentoValor1","fld":"vTITULOMOVIMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV54TipoPagamentoNome1","fld":"vTIPOPAGAMENTONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TituloMovimentoValor2","fld":"vTITULOMOVIMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV55TipoPagamentoNome2","fld":"vTIPOPAGAMENTONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TituloMovimentoValor3","fld":"vTITULOMOVIMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV56TipoPagamentoNome3","fld":"vTIPOPAGAMENTONOME3","type":"svchar"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV53TituloId","fld":"vTITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35TFTituloMovimentoValor","fld":"vTFTITULOMOVIMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFTituloMovimentoValor_To","fld":"vTFTITULOMOVIMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV38TFTituloMovimentoTipo_Sels","fld":"vTFTITULOMOVIMENTOTIPO_SELS","type":""},{"av":"AV39TFTituloMovimentoDataCredito","fld":"vTFTITULOMOVIMENTODATACREDITO","type":"date"},{"av":"AV40TFTituloMovimentoDataCredito_To","fld":"vTFTITULOMOVIMENTODATACREDITO_TO","type":"date"},{"av":"AV44TFTituloMovimentoCreatedAt","fld":"vTFTITULOMOVIMENTOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV45TFTituloMovimentoCreatedAt_To","fld":"vTFTITULOMOVIMENTOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV51TFTipoPagamentoNome","fld":"vTFTIPOPAGAMENTONOME","type":"svchar"},{"av":"AV52TFTipoPagamentoNome_Sel","fld":"vTFTIPOPAGAMENTONOME_SEL","type":"svchar"},{"av":"AV82Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TituloMovimentoValor2","fld":"vTITULOMOVIMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TituloMovimentoValor3","fld":"vTITULOMOVIMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloMovimentoValor1","fld":"vTITULOMOVIMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV54TipoPagamentoNome1","fld":"vTIPOPAGAMENTONOME1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV55TipoPagamentoNome2","fld":"vTIPOPAGAMENTONOME2","type":"svchar"},{"av":"AV56TipoPagamentoNome3","fld":"vTIPOPAGAMENTONOME3","type":"svchar"},{"av":"edtavTitulomovimentovalor2_Visible","ctrl":"vTITULOMOVIMENTOVALOR2","prop":"Visible"},{"av":"edtavTipopagamentonome2_Visible","ctrl":"vTIPOPAGAMENTONOME2","prop":"Visible"},{"av":"edtavTitulomovimentovalor3_Visible","ctrl":"vTITULOMOVIMENTOVALOR3","prop":"Visible"},{"av":"edtavTipopagamentonome3_Visible","ctrl":"vTIPOPAGAMENTONOME3","prop":"Visible"},{"av":"edtavTitulomovimentovalor1_Visible","ctrl":"vTITULOMOVIMENTOVALOR1","prop":"Visible"},{"av":"edtavTipopagamentonome1_Visible","ctrl":"vTIPOPAGAMENTONOME1","prop":"Visible"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E204O2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"edtavTitulomovimentovalor3_Visible","ctrl":"vTITULOMOVIMENTOVALOR3","prop":"Visible"},{"av":"edtavTipopagamentonome3_Visible","ctrl":"vTIPOPAGAMENTONOME3","prop":"Visible"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E114O2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloMovimentoValor1","fld":"vTITULOMOVIMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV54TipoPagamentoNome1","fld":"vTIPOPAGAMENTONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TituloMovimentoValor2","fld":"vTITULOMOVIMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV55TipoPagamentoNome2","fld":"vTIPOPAGAMENTONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TituloMovimentoValor3","fld":"vTITULOMOVIMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV56TipoPagamentoNome3","fld":"vTIPOPAGAMENTONOME3","type":"svchar"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV53TituloId","fld":"vTITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35TFTituloMovimentoValor","fld":"vTFTITULOMOVIMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFTituloMovimentoValor_To","fld":"vTFTITULOMOVIMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV38TFTituloMovimentoTipo_Sels","fld":"vTFTITULOMOVIMENTOTIPO_SELS","type":""},{"av":"AV39TFTituloMovimentoDataCredito","fld":"vTFTITULOMOVIMENTODATACREDITO","type":"date"},{"av":"AV40TFTituloMovimentoDataCredito_To","fld":"vTFTITULOMOVIMENTODATACREDITO_TO","type":"date"},{"av":"AV44TFTituloMovimentoCreatedAt","fld":"vTFTITULOMOVIMENTOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV45TFTituloMovimentoCreatedAt_To","fld":"vTFTITULOMOVIMENTOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV51TFTipoPagamentoNome","fld":"vTFTIPOPAGAMENTONOME","type":"svchar"},{"av":"AV52TFTipoPagamentoNome_Sel","fld":"vTFTIPOPAGAMENTONOME_SEL","type":"svchar"},{"av":"AV82Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV37TFTituloMovimentoTipo_SelsJson","fld":"vTFTITULOMOVIMENTOTIPO_SELSJSON","type":"vchar"},{"av":"AV46DDO_TituloMovimentoCreatedAtAuxDate","fld":"vDDO_TITULOMOVIMENTOCREATEDATAUXDATE","type":"date"},{"av":"AV47DDO_TituloMovimentoCreatedAtAuxDateTo","fld":"vDDO_TITULOMOVIMENTOCREATEDATAUXDATETO","type":"date"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV35TFTituloMovimentoValor","fld":"vTFTITULOMOVIMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFTituloMovimentoValor_To","fld":"vTFTITULOMOVIMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV38TFTituloMovimentoTipo_Sels","fld":"vTFTITULOMOVIMENTOTIPO_SELS","type":""},{"av":"AV39TFTituloMovimentoDataCredito","fld":"vTFTITULOMOVIMENTODATACREDITO","type":"date"},{"av":"AV40TFTituloMovimentoDataCredito_To","fld":"vTFTITULOMOVIMENTODATACREDITO_TO","type":"date"},{"av":"AV44TFTituloMovimentoCreatedAt","fld":"vTFTITULOMOVIMENTOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV45TFTituloMovimentoCreatedAt_To","fld":"vTFTITULOMOVIMENTOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV51TFTipoPagamentoNome","fld":"vTFTIPOPAGAMENTONOME","type":"svchar"},{"av":"AV52TFTipoPagamentoNome_Sel","fld":"vTFTIPOPAGAMENTONOME_SEL","type":"svchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloMovimentoValor1","fld":"vTITULOMOVIMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV46DDO_TituloMovimentoCreatedAtAuxDate","fld":"vDDO_TITULOMOVIMENTOCREATEDATAUXDATE","type":"date"},{"av":"AV47DDO_TituloMovimentoCreatedAtAuxDateTo","fld":"vDDO_TITULOMOVIMENTOCREATEDATAUXDATETO","type":"date"},{"av":"AV37TFTituloMovimentoTipo_SelsJson","fld":"vTFTITULOMOVIMENTOTIPO_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV54TipoPagamentoNome1","fld":"vTIPOPAGAMENTONOME1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TituloMovimentoValor2","fld":"vTITULOMOVIMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV55TipoPagamentoNome2","fld":"vTIPOPAGAMENTONOME2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TituloMovimentoValor3","fld":"vTITULOMOVIMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV56TipoPagamentoNome3","fld":"vTIPOPAGAMENTONOME3","type":"svchar"},{"av":"edtavTitulomovimentovalor1_Visible","ctrl":"vTITULOMOVIMENTOVALOR1","prop":"Visible"},{"av":"edtavTipopagamentonome1_Visible","ctrl":"vTIPOPAGAMENTONOME1","prop":"Visible"},{"av":"edtavTitulomovimentovalor2_Visible","ctrl":"vTITULOMOVIMENTOVALOR2","prop":"Visible"},{"av":"edtavTipopagamentonome2_Visible","ctrl":"vTIPOPAGAMENTONOME2","prop":"Visible"},{"av":"edtavTitulomovimentovalor3_Visible","ctrl":"vTITULOMOVIMENTOVALOR3","prop":"Visible"},{"av":"edtavTipopagamentonome3_Visible","ctrl":"vTIPOPAGAMENTONOME3","prop":"Visible"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"AV53TituloId","fld":"vTITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloMovimentoValor1","fld":"vTITULOMOVIMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV54TipoPagamentoNome1","fld":"vTIPOPAGAMENTONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TituloMovimentoValor2","fld":"vTITULOMOVIMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV55TipoPagamentoNome2","fld":"vTIPOPAGAMENTONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TituloMovimentoValor3","fld":"vTITULOMOVIMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV56TipoPagamentoNome3","fld":"vTIPOPAGAMENTONOME3","type":"svchar"},{"av":"AV35TFTituloMovimentoValor","fld":"vTFTITULOMOVIMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFTituloMovimentoValor_To","fld":"vTFTITULOMOVIMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV38TFTituloMovimentoTipo_Sels","fld":"vTFTITULOMOVIMENTOTIPO_SELS","type":""},{"av":"AV39TFTituloMovimentoDataCredito","fld":"vTFTITULOMOVIMENTODATACREDITO","type":"date"},{"av":"AV40TFTituloMovimentoDataCredito_To","fld":"vTFTITULOMOVIMENTODATACREDITO_TO","type":"date"},{"av":"AV44TFTituloMovimentoCreatedAt","fld":"vTFTITULOMOVIMENTOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV45TFTituloMovimentoCreatedAt_To","fld":"vTFTITULOMOVIMENTOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV51TFTipoPagamentoNome","fld":"vTFTIPOPAGAMENTONOME","type":"svchar"},{"av":"AV52TFTipoPagamentoNome_Sel","fld":"vTFTIPOPAGAMENTONOME_SEL","type":"svchar"},{"av":"AV82Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("GRID_FIRSTPAGE",""","oparms":[{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"AV53TituloId","fld":"vTITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloMovimentoValor1","fld":"vTITULOMOVIMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV54TipoPagamentoNome1","fld":"vTIPOPAGAMENTONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TituloMovimentoValor2","fld":"vTITULOMOVIMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV55TipoPagamentoNome2","fld":"vTIPOPAGAMENTONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TituloMovimentoValor3","fld":"vTITULOMOVIMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV56TipoPagamentoNome3","fld":"vTIPOPAGAMENTONOME3","type":"svchar"},{"av":"AV35TFTituloMovimentoValor","fld":"vTFTITULOMOVIMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFTituloMovimentoValor_To","fld":"vTFTITULOMOVIMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV38TFTituloMovimentoTipo_Sels","fld":"vTFTITULOMOVIMENTOTIPO_SELS","type":""},{"av":"AV39TFTituloMovimentoDataCredito","fld":"vTFTITULOMOVIMENTODATACREDITO","type":"date"},{"av":"AV40TFTituloMovimentoDataCredito_To","fld":"vTFTITULOMOVIMENTODATACREDITO_TO","type":"date"},{"av":"AV44TFTituloMovimentoCreatedAt","fld":"vTFTITULOMOVIMENTOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV45TFTituloMovimentoCreatedAt_To","fld":"vTFTITULOMOVIMENTOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV51TFTipoPagamentoNome","fld":"vTFTIPOPAGAMENTONOME","type":"svchar"},{"av":"AV52TFTipoPagamentoNome_Sel","fld":"vTFTIPOPAGAMENTONOME_SEL","type":"svchar"},{"av":"AV82Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("GRID_PREVPAGE",""","oparms":[{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"AV53TituloId","fld":"vTITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloMovimentoValor1","fld":"vTITULOMOVIMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV54TipoPagamentoNome1","fld":"vTIPOPAGAMENTONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TituloMovimentoValor2","fld":"vTITULOMOVIMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV55TipoPagamentoNome2","fld":"vTIPOPAGAMENTONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TituloMovimentoValor3","fld":"vTITULOMOVIMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV56TipoPagamentoNome3","fld":"vTIPOPAGAMENTONOME3","type":"svchar"},{"av":"AV35TFTituloMovimentoValor","fld":"vTFTITULOMOVIMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFTituloMovimentoValor_To","fld":"vTFTITULOMOVIMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV38TFTituloMovimentoTipo_Sels","fld":"vTFTITULOMOVIMENTOTIPO_SELS","type":""},{"av":"AV39TFTituloMovimentoDataCredito","fld":"vTFTITULOMOVIMENTODATACREDITO","type":"date"},{"av":"AV40TFTituloMovimentoDataCredito_To","fld":"vTFTITULOMOVIMENTODATACREDITO_TO","type":"date"},{"av":"AV44TFTituloMovimentoCreatedAt","fld":"vTFTITULOMOVIMENTOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV45TFTituloMovimentoCreatedAt_To","fld":"vTFTITULOMOVIMENTOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV51TFTipoPagamentoNome","fld":"vTFTIPOPAGAMENTONOME","type":"svchar"},{"av":"AV52TFTipoPagamentoNome_Sel","fld":"vTFTIPOPAGAMENTONOME_SEL","type":"svchar"},{"av":"AV82Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("GRID_NEXTPAGE",""","oparms":[{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"AV53TituloId","fld":"vTITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TituloMovimentoValor1","fld":"vTITULOMOVIMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV54TipoPagamentoNome1","fld":"vTIPOPAGAMENTONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TituloMovimentoValor2","fld":"vTITULOMOVIMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV55TipoPagamentoNome2","fld":"vTIPOPAGAMENTONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TituloMovimentoValor3","fld":"vTITULOMOVIMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV56TipoPagamentoNome3","fld":"vTIPOPAGAMENTONOME3","type":"svchar"},{"av":"AV35TFTituloMovimentoValor","fld":"vTFTITULOMOVIMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFTituloMovimentoValor_To","fld":"vTFTITULOMOVIMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV38TFTituloMovimentoTipo_Sels","fld":"vTFTITULOMOVIMENTOTIPO_SELS","type":""},{"av":"AV39TFTituloMovimentoDataCredito","fld":"vTFTITULOMOVIMENTODATACREDITO","type":"date"},{"av":"AV40TFTituloMovimentoDataCredito_To","fld":"vTFTITULOMOVIMENTODATACREDITO_TO","type":"date"},{"av":"AV44TFTituloMovimentoCreatedAt","fld":"vTFTITULOMOVIMENTOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV45TFTituloMovimentoCreatedAt_To","fld":"vTFTITULOMOVIMENTOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV51TFTipoPagamentoNome","fld":"vTFTIPOPAGAMENTONOME","type":"svchar"},{"av":"AV52TFTipoPagamentoNome_Sel","fld":"vTFTIPOPAGAMENTONOME_SEL","type":"svchar"},{"av":"AV82Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("GRID_LASTPAGE",""","oparms":[{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("VALID_TIPOPAGAMENTOID","""{"handler":"Valid_Tipopagamentoid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Tipopagamentonome","iparms":[]}""");
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
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV15FilterFullText = "";
         AV16DynamicFiltersSelector1 = "";
         AV54TipoPagamentoNome1 = "";
         AV20DynamicFiltersSelector2 = "";
         AV55TipoPagamentoNome2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV56TipoPagamentoNome3 = "";
         AV38TFTituloMovimentoTipo_Sels = new GxSimpleCollection<string>();
         AV39TFTituloMovimentoDataCredito = DateTime.MinValue;
         AV40TFTituloMovimentoDataCredito_To = DateTime.MinValue;
         AV44TFTituloMovimentoCreatedAt = (DateTime)(DateTime.MinValue);
         AV45TFTituloMovimentoCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV51TFTipoPagamentoNome = "";
         AV52TFTipoPagamentoNome_Sel = "";
         AV82Pgmname = "";
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV30ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV49DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV41DDO_TituloMovimentoDataCreditoAuxDate = DateTime.MinValue;
         AV42DDO_TituloMovimentoDataCreditoAuxDateTo = DateTime.MinValue;
         AV46DDO_TituloMovimentoCreatedAtAuxDate = DateTime.MinValue;
         AV47DDO_TituloMovimentoCreatedAtAuxDateTo = DateTime.MinValue;
         AV37TFTituloMovimentoTipo_SelsJson = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ucDvpanel_tableheader = new GXUserControl();
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         TempTags = "";
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
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV43DDO_TituloMovimentoDataCreditoAuxDateText = "";
         ucTftitulomovimentodatacredito_rangepicker = new GXUserControl();
         AV48DDO_TituloMovimentoCreatedAtAuxDateText = "";
         ucTftitulomovimentocreatedat_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV58Titulomovimentowwds_2_filterfulltext = "";
         AV59Titulomovimentowwds_3_dynamicfiltersselector1 = "";
         AV62Titulomovimentowwds_6_tipopagamentonome1 = "";
         AV64Titulomovimentowwds_8_dynamicfiltersselector2 = "";
         AV67Titulomovimentowwds_11_tipopagamentonome2 = "";
         AV69Titulomovimentowwds_13_dynamicfiltersselector3 = "";
         AV72Titulomovimentowwds_16_tipopagamentonome3 = "";
         AV75Titulomovimentowwds_19_tftitulomovimentotipo_sels = new GxSimpleCollection<string>();
         AV76Titulomovimentowwds_20_tftitulomovimentodatacredito = DateTime.MinValue;
         AV77Titulomovimentowwds_21_tftitulomovimentodatacredito_to = DateTime.MinValue;
         AV78Titulomovimentowwds_22_tftitulomovimentocreatedat = (DateTime)(DateTime.MinValue);
         AV79Titulomovimentowwds_23_tftitulomovimentocreatedat_to = (DateTime)(DateTime.MinValue);
         AV80Titulomovimentowwds_24_tftipopagamentonome = "";
         AV81Titulomovimentowwds_25_tftipopagamentonome_sel = "";
         A272TituloMovimentoTipo = "";
         A279TituloMovimentoDataCredito = DateTime.MinValue;
         A280TituloMovimentoCreatedAt = (DateTime)(DateTime.MinValue);
         A281TituloMovimentoUpdatedAt = (DateTime)(DateTime.MinValue);
         A289TipoPagamentoNome = "";
         GXDecQS = "";
         lV58Titulomovimentowwds_2_filterfulltext = "";
         lV62Titulomovimentowwds_6_tipopagamentonome1 = "";
         lV67Titulomovimentowwds_11_tipopagamentonome2 = "";
         lV72Titulomovimentowwds_16_tipopagamentonome3 = "";
         lV80Titulomovimentowwds_24_tftipopagamentonome = "";
         H004O2_A289TipoPagamentoNome = new string[] {""} ;
         H004O2_A281TituloMovimentoUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         H004O2_n281TituloMovimentoUpdatedAt = new bool[] {false} ;
         H004O2_A280TituloMovimentoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H004O2_n280TituloMovimentoCreatedAt = new bool[] {false} ;
         H004O2_A279TituloMovimentoDataCredito = new DateTime[] {DateTime.MinValue} ;
         H004O2_n279TituloMovimentoDataCredito = new bool[] {false} ;
         H004O2_A274TituloMovimentoSoma = new bool[] {false} ;
         H004O2_n274TituloMovimentoSoma = new bool[] {false} ;
         H004O2_A272TituloMovimentoTipo = new string[] {""} ;
         H004O2_n272TituloMovimentoTipo = new bool[] {false} ;
         H004O2_A271TituloMovimentoValor = new decimal[1] ;
         H004O2_n271TituloMovimentoValor = new bool[] {false} ;
         H004O2_A261TituloId = new int[1] ;
         H004O2_n261TituloId = new bool[] {false} ;
         H004O2_A288TipoPagamentoId = new int[1] ;
         H004O2_n288TipoPagamentoId = new bool[] {false} ;
         H004O2_A270TituloMovimentoId = new int[1] ;
         H004O3_AGRID_nRecordCount = new long[1] ;
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV31ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV29Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char4 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV50AuxText = "";
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
         sCtrlAV53TituloId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.titulomovimentoww__default(),
            new Object[][] {
                new Object[] {
               H004O2_A289TipoPagamentoNome, H004O2_A281TituloMovimentoUpdatedAt, H004O2_n281TituloMovimentoUpdatedAt, H004O2_A280TituloMovimentoCreatedAt, H004O2_n280TituloMovimentoCreatedAt, H004O2_A279TituloMovimentoDataCredito, H004O2_n279TituloMovimentoDataCredito, H004O2_A274TituloMovimentoSoma, H004O2_n274TituloMovimentoSoma, H004O2_A272TituloMovimentoTipo,
               H004O2_n272TituloMovimentoTipo, H004O2_A271TituloMovimentoValor, H004O2_n271TituloMovimentoValor, H004O2_A261TituloId, H004O2_n261TituloId, H004O2_A288TipoPagamentoId, H004O2_n288TipoPagamentoId, H004O2_A270TituloMovimentoId
               }
               , new Object[] {
               H004O3_AGRID_nRecordCount
               }
            }
         );
         AV82Pgmname = "TituloMovimentoWW";
         /* GeneXus formulas. */
         AV82Pgmname = "TituloMovimentoWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV32ManageFiltersExecutionStep ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV60Titulomovimentowwds_4_dynamicfiltersoperator1 ;
      private short AV65Titulomovimentowwds_9_dynamicfiltersoperator2 ;
      private short AV70Titulomovimentowwds_14_dynamicfiltersoperator3 ;
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
      private int AV53TituloId ;
      private int wcpOAV53TituloId ;
      private int subGrid_Rows ;
      private int nRC_GXsfl_107 ;
      private int nGXsfl_107_idx=1 ;
      private int edtavFilterfulltext_Enabled ;
      private int AV57Titulomovimentowwds_1_tituloid ;
      private int A270TituloMovimentoId ;
      private int A288TipoPagamentoId ;
      private int A261TituloId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV75Titulomovimentowwds_19_tftitulomovimentotipo_sels_Count ;
      private int edtTituloMovimentoId_Enabled ;
      private int edtTipoPagamentoId_Enabled ;
      private int edtTituloId_Enabled ;
      private int edtTituloMovimentoValor_Enabled ;
      private int edtTituloMovimentoDataCredito_Enabled ;
      private int edtTituloMovimentoCreatedAt_Enabled ;
      private int edtTituloMovimentoUpdatedAt_Enabled ;
      private int edtTipoPagamentoNome_Enabled ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavTitulomovimentovalor1_Visible ;
      private int edtavTipopagamentonome1_Visible ;
      private int edtavTitulomovimentovalor2_Visible ;
      private int edtavTipopagamentonome2_Visible ;
      private int edtavTitulomovimentovalor3_Visible ;
      private int edtavTipopagamentonome3_Visible ;
      private int AV83GXV1 ;
      private int edtavTitulomovimentovalor3_Enabled ;
      private int edtavTipopagamentonome3_Enabled ;
      private int edtavTitulomovimentovalor2_Enabled ;
      private int edtavTipopagamentonome2_Enabled ;
      private int edtavTitulomovimentovalor1_Enabled ;
      private int edtavTipopagamentonome1_Enabled ;
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
      private decimal AV18TituloMovimentoValor1 ;
      private decimal AV22TituloMovimentoValor2 ;
      private decimal AV26TituloMovimentoValor3 ;
      private decimal AV35TFTituloMovimentoValor ;
      private decimal AV36TFTituloMovimentoValor_To ;
      private decimal AV61Titulomovimentowwds_5_titulomovimentovalor1 ;
      private decimal AV66Titulomovimentowwds_10_titulomovimentovalor2 ;
      private decimal AV71Titulomovimentowwds_15_titulomovimentovalor3 ;
      private decimal AV73Titulomovimentowwds_17_tftitulomovimentovalor ;
      private decimal AV74Titulomovimentowwds_18_tftitulomovimentovalor_to ;
      private decimal A271TituloMovimentoValor ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_107_idx="0001" ;
      private string AV82Pgmname ;
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
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tableheader_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string TempTags ;
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
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_titulomovimentodatacreditoauxdates_Internalname ;
      private string edtavDdo_titulomovimentodatacreditoauxdatetext_Internalname ;
      private string edtavDdo_titulomovimentodatacreditoauxdatetext_Jsonclick ;
      private string Tftitulomovimentodatacredito_rangepicker_Internalname ;
      private string divDdo_titulomovimentocreatedatauxdates_Internalname ;
      private string edtavDdo_titulomovimentocreatedatauxdatetext_Internalname ;
      private string edtavDdo_titulomovimentocreatedatauxdatetext_Jsonclick ;
      private string Tftitulomovimentocreatedat_rangepicker_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtTituloMovimentoId_Internalname ;
      private string edtTipoPagamentoId_Internalname ;
      private string edtTituloId_Internalname ;
      private string edtTituloMovimentoValor_Internalname ;
      private string cmbTituloMovimentoTipo_Internalname ;
      private string chkTituloMovimentoSoma_Internalname ;
      private string edtTituloMovimentoDataCredito_Internalname ;
      private string edtTituloMovimentoCreatedAt_Internalname ;
      private string edtTituloMovimentoUpdatedAt_Internalname ;
      private string edtTipoPagamentoNome_Internalname ;
      private string GXDecQS ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavTitulomovimentovalor1_Internalname ;
      private string edtavTipopagamentonome1_Internalname ;
      private string edtavTitulomovimentovalor2_Internalname ;
      private string edtavTipopagamentonome2_Internalname ;
      private string edtavTitulomovimentovalor3_Internalname ;
      private string edtavTipopagamentonome3_Internalname ;
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
      private string edtTituloMovimentoValor_Link ;
      private string edtTipoPagamentoNome_Link ;
      private string GXt_char2 ;
      private string GXt_char4 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_titulomovimentovalor3_cell_Internalname ;
      private string edtavTitulomovimentovalor3_Jsonclick ;
      private string cellFilter_tipopagamentonome3_cell_Internalname ;
      private string edtavTipopagamentonome3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_titulomovimentovalor2_cell_Internalname ;
      private string edtavTitulomovimentovalor2_Jsonclick ;
      private string cellFilter_tipopagamentonome2_cell_Internalname ;
      private string edtavTipopagamentonome2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_titulomovimentovalor1_cell_Internalname ;
      private string edtavTitulomovimentovalor1_Jsonclick ;
      private string cellFilter_tipopagamentonome1_cell_Internalname ;
      private string edtavTipopagamentonome1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sCtrlAV53TituloId ;
      private string sGXsfl_107_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtTituloMovimentoId_Jsonclick ;
      private string edtTipoPagamentoId_Jsonclick ;
      private string edtTituloId_Jsonclick ;
      private string edtTituloMovimentoValor_Jsonclick ;
      private string GXCCtl ;
      private string cmbTituloMovimentoTipo_Jsonclick ;
      private string edtTituloMovimentoDataCredito_Jsonclick ;
      private string edtTituloMovimentoCreatedAt_Jsonclick ;
      private string edtTituloMovimentoUpdatedAt_Jsonclick ;
      private string edtTipoPagamentoNome_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV44TFTituloMovimentoCreatedAt ;
      private DateTime AV45TFTituloMovimentoCreatedAt_To ;
      private DateTime AV78Titulomovimentowwds_22_tftitulomovimentocreatedat ;
      private DateTime AV79Titulomovimentowwds_23_tftitulomovimentocreatedat_to ;
      private DateTime A280TituloMovimentoCreatedAt ;
      private DateTime A281TituloMovimentoUpdatedAt ;
      private DateTime AV39TFTituloMovimentoDataCredito ;
      private DateTime AV40TFTituloMovimentoDataCredito_To ;
      private DateTime AV41DDO_TituloMovimentoDataCreditoAuxDate ;
      private DateTime AV42DDO_TituloMovimentoDataCreditoAuxDateTo ;
      private DateTime AV46DDO_TituloMovimentoCreatedAtAuxDate ;
      private DateTime AV47DDO_TituloMovimentoCreatedAtAuxDateTo ;
      private DateTime AV76Titulomovimentowwds_20_tftitulomovimentodatacredito ;
      private DateTime AV77Titulomovimentowwds_21_tftitulomovimentodatacredito_to ;
      private DateTime A279TituloMovimentoDataCredito ;
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
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV63Titulomovimentowwds_7_dynamicfiltersenabled2 ;
      private bool AV68Titulomovimentowwds_12_dynamicfiltersenabled3 ;
      private bool n288TipoPagamentoId ;
      private bool n261TituloId ;
      private bool n271TituloMovimentoValor ;
      private bool n272TituloMovimentoTipo ;
      private bool A274TituloMovimentoSoma ;
      private bool n274TituloMovimentoSoma ;
      private bool n279TituloMovimentoDataCredito ;
      private bool n280TituloMovimentoCreatedAt ;
      private bool n281TituloMovimentoUpdatedAt ;
      private bool bGXsfl_107_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV37TFTituloMovimentoTipo_SelsJson ;
      private string AV31ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV54TipoPagamentoNome1 ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV55TipoPagamentoNome2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV56TipoPagamentoNome3 ;
      private string AV51TFTipoPagamentoNome ;
      private string AV52TFTipoPagamentoNome_Sel ;
      private string AV43DDO_TituloMovimentoDataCreditoAuxDateText ;
      private string AV48DDO_TituloMovimentoCreatedAtAuxDateText ;
      private string AV58Titulomovimentowwds_2_filterfulltext ;
      private string AV59Titulomovimentowwds_3_dynamicfiltersselector1 ;
      private string AV62Titulomovimentowwds_6_tipopagamentonome1 ;
      private string AV64Titulomovimentowwds_8_dynamicfiltersselector2 ;
      private string AV67Titulomovimentowwds_11_tipopagamentonome2 ;
      private string AV69Titulomovimentowwds_13_dynamicfiltersselector3 ;
      private string AV72Titulomovimentowwds_16_tipopagamentonome3 ;
      private string AV80Titulomovimentowwds_24_tftipopagamentonome ;
      private string AV81Titulomovimentowwds_25_tftipopagamentonome_sel ;
      private string A272TituloMovimentoTipo ;
      private string A289TipoPagamentoNome ;
      private string lV58Titulomovimentowwds_2_filterfulltext ;
      private string lV62Titulomovimentowwds_6_tipopagamentonome1 ;
      private string lV67Titulomovimentowwds_11_tipopagamentonome2 ;
      private string lV72Titulomovimentowwds_16_tipopagamentonome3 ;
      private string lV80Titulomovimentowwds_24_tftipopagamentonome ;
      private string AV50AuxText ;
      private IGxSession AV29Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTftitulomovimentodatacredito_rangepicker ;
      private GXUserControl ucTftitulomovimentocreatedat_rangepicker ;
      private GXWebForm Form ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbTituloMovimentoTipo ;
      private GXCheckbox chkTituloMovimentoSoma ;
      private GxSimpleCollection<string> AV38TFTituloMovimentoTipo_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV30ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV49DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV75Titulomovimentowwds_19_tftitulomovimentotipo_sels ;
      private IDataStoreProvider pr_default ;
      private string[] H004O2_A289TipoPagamentoNome ;
      private DateTime[] H004O2_A281TituloMovimentoUpdatedAt ;
      private bool[] H004O2_n281TituloMovimentoUpdatedAt ;
      private DateTime[] H004O2_A280TituloMovimentoCreatedAt ;
      private bool[] H004O2_n280TituloMovimentoCreatedAt ;
      private DateTime[] H004O2_A279TituloMovimentoDataCredito ;
      private bool[] H004O2_n279TituloMovimentoDataCredito ;
      private bool[] H004O2_A274TituloMovimentoSoma ;
      private bool[] H004O2_n274TituloMovimentoSoma ;
      private string[] H004O2_A272TituloMovimentoTipo ;
      private bool[] H004O2_n272TituloMovimentoTipo ;
      private decimal[] H004O2_A271TituloMovimentoValor ;
      private bool[] H004O2_n271TituloMovimentoValor ;
      private int[] H004O2_A261TituloId ;
      private bool[] H004O2_n261TituloId ;
      private int[] H004O2_A288TipoPagamentoId ;
      private bool[] H004O2_n288TipoPagamentoId ;
      private int[] H004O2_A270TituloMovimentoId ;
      private long[] H004O3_AGRID_nRecordCount ;
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

   public class titulomovimentoww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004O2( IGxContext context ,
                                             string A272TituloMovimentoTipo ,
                                             GxSimpleCollection<string> AV75Titulomovimentowwds_19_tftitulomovimentotipo_sels ,
                                             string AV58Titulomovimentowwds_2_filterfulltext ,
                                             string AV59Titulomovimentowwds_3_dynamicfiltersselector1 ,
                                             short AV60Titulomovimentowwds_4_dynamicfiltersoperator1 ,
                                             decimal AV61Titulomovimentowwds_5_titulomovimentovalor1 ,
                                             string AV62Titulomovimentowwds_6_tipopagamentonome1 ,
                                             bool AV63Titulomovimentowwds_7_dynamicfiltersenabled2 ,
                                             string AV64Titulomovimentowwds_8_dynamicfiltersselector2 ,
                                             short AV65Titulomovimentowwds_9_dynamicfiltersoperator2 ,
                                             decimal AV66Titulomovimentowwds_10_titulomovimentovalor2 ,
                                             string AV67Titulomovimentowwds_11_tipopagamentonome2 ,
                                             bool AV68Titulomovimentowwds_12_dynamicfiltersenabled3 ,
                                             string AV69Titulomovimentowwds_13_dynamicfiltersselector3 ,
                                             short AV70Titulomovimentowwds_14_dynamicfiltersoperator3 ,
                                             decimal AV71Titulomovimentowwds_15_titulomovimentovalor3 ,
                                             string AV72Titulomovimentowwds_16_tipopagamentonome3 ,
                                             decimal AV73Titulomovimentowwds_17_tftitulomovimentovalor ,
                                             decimal AV74Titulomovimentowwds_18_tftitulomovimentovalor_to ,
                                             int AV75Titulomovimentowwds_19_tftitulomovimentotipo_sels_Count ,
                                             DateTime AV76Titulomovimentowwds_20_tftitulomovimentodatacredito ,
                                             DateTime AV77Titulomovimentowwds_21_tftitulomovimentodatacredito_to ,
                                             DateTime AV78Titulomovimentowwds_22_tftitulomovimentocreatedat ,
                                             DateTime AV79Titulomovimentowwds_23_tftitulomovimentocreatedat_to ,
                                             string AV81Titulomovimentowwds_25_tftipopagamentonome_sel ,
                                             string AV80Titulomovimentowwds_24_tftipopagamentonome ,
                                             decimal A271TituloMovimentoValor ,
                                             string A289TipoPagamentoNome ,
                                             DateTime A279TituloMovimentoDataCredito ,
                                             DateTime A280TituloMovimentoCreatedAt ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             int A261TituloId ,
                                             int AV57Titulomovimentowwds_1_tituloid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[33];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T2.TipoPagamentoNome, T1.TituloMovimentoUpdatedAt, T1.TituloMovimentoCreatedAt, T1.TituloMovimentoDataCredito, T1.TituloMovimentoSoma, T1.TituloMovimentoTipo, T1.TituloMovimentoValor, T1.TituloId, T1.TipoPagamentoId, T1.TituloMovimentoId";
         sFromString = " FROM (TituloMovimento T1 LEFT JOIN TipoPagamento T2 ON T2.TipoPagamentoId = T1.TipoPagamentoId)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.TituloId = :AV57Titulomovimentowwds_1_tituloid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Titulomovimentowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.TituloMovimentoValor,'999999999999990.99'), 2) like '%' || :lV58Titulomovimentowwds_2_filterfulltext) or ( 'baixa' like '%' || LOWER(:lV58Titulomovimentowwds_2_filterfulltext) and T1.TituloMovimentoTipo = ( 'Baixa')) or ( 'juros' like '%' || LOWER(:lV58Titulomovimentowwds_2_filterfulltext) and T1.TituloMovimentoTipo = ( 'Juros')) or ( 'taxa' like '%' || LOWER(:lV58Titulomovimentowwds_2_filterfulltext) and T1.TituloMovimentoTipo = ( 'Taxa')) or ( 'multa' like '%' || LOWER(:lV58Titulomovimentowwds_2_filterfulltext) and T1.TituloMovimentoTipo = ( 'Multa')) or ( T2.TipoPagamentoNome like '%' || :lV58Titulomovimentowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Titulomovimentowwds_3_dynamicfiltersselector1, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV60Titulomovimentowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV61Titulomovimentowwds_5_titulomovimentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor < :AV61Titulomovimentowwds_5_titulomovimentovalor1)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Titulomovimentowwds_3_dynamicfiltersselector1, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV60Titulomovimentowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV61Titulomovimentowwds_5_titulomovimentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor = :AV61Titulomovimentowwds_5_titulomovimentovalor1)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Titulomovimentowwds_3_dynamicfiltersselector1, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV60Titulomovimentowwds_4_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV61Titulomovimentowwds_5_titulomovimentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor > :AV61Titulomovimentowwds_5_titulomovimentovalor1)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Titulomovimentowwds_3_dynamicfiltersselector1, "TIPOPAGAMENTONOME") == 0 ) && ( AV60Titulomovimentowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Titulomovimentowwds_6_tipopagamentonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome like :lV62Titulomovimentowwds_6_tipopagamentonome1)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Titulomovimentowwds_3_dynamicfiltersselector1, "TIPOPAGAMENTONOME") == 0 ) && ( AV60Titulomovimentowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Titulomovimentowwds_6_tipopagamentonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome like '%' || :lV62Titulomovimentowwds_6_tipopagamentonome1)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV63Titulomovimentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Titulomovimentowwds_8_dynamicfiltersselector2, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV65Titulomovimentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV66Titulomovimentowwds_10_titulomovimentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor < :AV66Titulomovimentowwds_10_titulomovimentovalor2)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV63Titulomovimentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Titulomovimentowwds_8_dynamicfiltersselector2, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV65Titulomovimentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV66Titulomovimentowwds_10_titulomovimentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor = :AV66Titulomovimentowwds_10_titulomovimentovalor2)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV63Titulomovimentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Titulomovimentowwds_8_dynamicfiltersselector2, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV65Titulomovimentowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV66Titulomovimentowwds_10_titulomovimentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor > :AV66Titulomovimentowwds_10_titulomovimentovalor2)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV63Titulomovimentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Titulomovimentowwds_8_dynamicfiltersselector2, "TIPOPAGAMENTONOME") == 0 ) && ( AV65Titulomovimentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Titulomovimentowwds_11_tipopagamentonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome like :lV67Titulomovimentowwds_11_tipopagamentonome2)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV63Titulomovimentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Titulomovimentowwds_8_dynamicfiltersselector2, "TIPOPAGAMENTONOME") == 0 ) && ( AV65Titulomovimentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Titulomovimentowwds_11_tipopagamentonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome like '%' || :lV67Titulomovimentowwds_11_tipopagamentonome2)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV68Titulomovimentowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Titulomovimentowwds_13_dynamicfiltersselector3, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV70Titulomovimentowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV71Titulomovimentowwds_15_titulomovimentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor < :AV71Titulomovimentowwds_15_titulomovimentovalor3)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( AV68Titulomovimentowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Titulomovimentowwds_13_dynamicfiltersselector3, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV70Titulomovimentowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV71Titulomovimentowwds_15_titulomovimentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor = :AV71Titulomovimentowwds_15_titulomovimentovalor3)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( AV68Titulomovimentowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Titulomovimentowwds_13_dynamicfiltersselector3, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV70Titulomovimentowwds_14_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV71Titulomovimentowwds_15_titulomovimentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor > :AV71Titulomovimentowwds_15_titulomovimentovalor3)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( AV68Titulomovimentowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Titulomovimentowwds_13_dynamicfiltersselector3, "TIPOPAGAMENTONOME") == 0 ) && ( AV70Titulomovimentowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Titulomovimentowwds_16_tipopagamentonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome like :lV72Titulomovimentowwds_16_tipopagamentonome3)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( AV68Titulomovimentowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Titulomovimentowwds_13_dynamicfiltersselector3, "TIPOPAGAMENTONOME") == 0 ) && ( AV70Titulomovimentowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Titulomovimentowwds_16_tipopagamentonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome like '%' || :lV72Titulomovimentowwds_16_tipopagamentonome3)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV73Titulomovimentowwds_17_tftitulomovimentovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor >= :AV73Titulomovimentowwds_17_tftitulomovimentovalor)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV74Titulomovimentowwds_18_tftitulomovimentovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor <= :AV74Titulomovimentowwds_18_tftitulomovimentovalor_to)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( AV75Titulomovimentowwds_19_tftitulomovimentotipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV75Titulomovimentowwds_19_tftitulomovimentotipo_sels, "T1.TituloMovimentoTipo IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV76Titulomovimentowwds_20_tftitulomovimentodatacredito) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoDataCredito >= :AV76Titulomovimentowwds_20_tftitulomovimentodatacredito)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV77Titulomovimentowwds_21_tftitulomovimentodatacredito_to) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoDataCredito <= :AV77Titulomovimentowwds_21_tftitulomovimentodatacredito_to)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV78Titulomovimentowwds_22_tftitulomovimentocreatedat) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoCreatedAt >= :AV78Titulomovimentowwds_22_tftitulomovimentocreatedat)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV79Titulomovimentowwds_23_tftitulomovimentocreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoCreatedAt <= :AV79Titulomovimentowwds_23_tftitulomovimentocreatedat_to)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Titulomovimentowwds_25_tftipopagamentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Titulomovimentowwds_24_tftipopagamentonome)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome like :lV80Titulomovimentowwds_24_tftipopagamentonome)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Titulomovimentowwds_25_tftipopagamentonome_sel)) && ! ( StringUtil.StrCmp(AV81Titulomovimentowwds_25_tftipopagamentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome = ( :AV81Titulomovimentowwds_25_tftipopagamentonome_sel))");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( StringUtil.StrCmp(AV81Titulomovimentowwds_25_tftipopagamentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome IS NULL or (char_length(trim(trailing ' ' from T2.TipoPagamentoNome))=0))");
         }
         if ( AV13OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.TituloId, T1.TituloMovimentoId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.TituloId, T1.TituloMovimentoValor, T1.TituloMovimentoId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.TituloId DESC, T1.TituloMovimentoValor DESC, T1.TituloMovimentoId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.TituloId, T1.TituloMovimentoTipo, T1.TituloMovimentoId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.TituloId DESC, T1.TituloMovimentoTipo DESC, T1.TituloMovimentoId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.TituloId, T1.TituloMovimentoDataCredito, T1.TituloMovimentoId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.TituloId DESC, T1.TituloMovimentoDataCredito DESC, T1.TituloMovimentoId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.TituloId, T1.TituloMovimentoCreatedAt, T1.TituloMovimentoId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.TituloId DESC, T1.TituloMovimentoCreatedAt DESC, T1.TituloMovimentoId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.TituloId, T2.TipoPagamentoNome, T1.TituloMovimentoId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.TituloId DESC, T2.TipoPagamentoNome DESC, T1.TituloMovimentoId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.TituloMovimentoId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H004O3( IGxContext context ,
                                             string A272TituloMovimentoTipo ,
                                             GxSimpleCollection<string> AV75Titulomovimentowwds_19_tftitulomovimentotipo_sels ,
                                             string AV58Titulomovimentowwds_2_filterfulltext ,
                                             string AV59Titulomovimentowwds_3_dynamicfiltersselector1 ,
                                             short AV60Titulomovimentowwds_4_dynamicfiltersoperator1 ,
                                             decimal AV61Titulomovimentowwds_5_titulomovimentovalor1 ,
                                             string AV62Titulomovimentowwds_6_tipopagamentonome1 ,
                                             bool AV63Titulomovimentowwds_7_dynamicfiltersenabled2 ,
                                             string AV64Titulomovimentowwds_8_dynamicfiltersselector2 ,
                                             short AV65Titulomovimentowwds_9_dynamicfiltersoperator2 ,
                                             decimal AV66Titulomovimentowwds_10_titulomovimentovalor2 ,
                                             string AV67Titulomovimentowwds_11_tipopagamentonome2 ,
                                             bool AV68Titulomovimentowwds_12_dynamicfiltersenabled3 ,
                                             string AV69Titulomovimentowwds_13_dynamicfiltersselector3 ,
                                             short AV70Titulomovimentowwds_14_dynamicfiltersoperator3 ,
                                             decimal AV71Titulomovimentowwds_15_titulomovimentovalor3 ,
                                             string AV72Titulomovimentowwds_16_tipopagamentonome3 ,
                                             decimal AV73Titulomovimentowwds_17_tftitulomovimentovalor ,
                                             decimal AV74Titulomovimentowwds_18_tftitulomovimentovalor_to ,
                                             int AV75Titulomovimentowwds_19_tftitulomovimentotipo_sels_Count ,
                                             DateTime AV76Titulomovimentowwds_20_tftitulomovimentodatacredito ,
                                             DateTime AV77Titulomovimentowwds_21_tftitulomovimentodatacredito_to ,
                                             DateTime AV78Titulomovimentowwds_22_tftitulomovimentocreatedat ,
                                             DateTime AV79Titulomovimentowwds_23_tftitulomovimentocreatedat_to ,
                                             string AV81Titulomovimentowwds_25_tftipopagamentonome_sel ,
                                             string AV80Titulomovimentowwds_24_tftipopagamentonome ,
                                             decimal A271TituloMovimentoValor ,
                                             string A289TipoPagamentoNome ,
                                             DateTime A279TituloMovimentoDataCredito ,
                                             DateTime A280TituloMovimentoCreatedAt ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             int A261TituloId ,
                                             int AV57Titulomovimentowwds_1_tituloid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[30];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (TituloMovimento T1 LEFT JOIN TipoPagamento T2 ON T2.TipoPagamentoId = T1.TipoPagamentoId)";
         AddWhere(sWhereString, "(T1.TituloId = :AV57Titulomovimentowwds_1_tituloid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Titulomovimentowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.TituloMovimentoValor,'999999999999990.99'), 2) like '%' || :lV58Titulomovimentowwds_2_filterfulltext) or ( 'baixa' like '%' || LOWER(:lV58Titulomovimentowwds_2_filterfulltext) and T1.TituloMovimentoTipo = ( 'Baixa')) or ( 'juros' like '%' || LOWER(:lV58Titulomovimentowwds_2_filterfulltext) and T1.TituloMovimentoTipo = ( 'Juros')) or ( 'taxa' like '%' || LOWER(:lV58Titulomovimentowwds_2_filterfulltext) and T1.TituloMovimentoTipo = ( 'Taxa')) or ( 'multa' like '%' || LOWER(:lV58Titulomovimentowwds_2_filterfulltext) and T1.TituloMovimentoTipo = ( 'Multa')) or ( T2.TipoPagamentoNome like '%' || :lV58Titulomovimentowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Titulomovimentowwds_3_dynamicfiltersselector1, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV60Titulomovimentowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV61Titulomovimentowwds_5_titulomovimentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor < :AV61Titulomovimentowwds_5_titulomovimentovalor1)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Titulomovimentowwds_3_dynamicfiltersselector1, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV60Titulomovimentowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV61Titulomovimentowwds_5_titulomovimentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor = :AV61Titulomovimentowwds_5_titulomovimentovalor1)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Titulomovimentowwds_3_dynamicfiltersselector1, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV60Titulomovimentowwds_4_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV61Titulomovimentowwds_5_titulomovimentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor > :AV61Titulomovimentowwds_5_titulomovimentovalor1)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Titulomovimentowwds_3_dynamicfiltersselector1, "TIPOPAGAMENTONOME") == 0 ) && ( AV60Titulomovimentowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Titulomovimentowwds_6_tipopagamentonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome like :lV62Titulomovimentowwds_6_tipopagamentonome1)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Titulomovimentowwds_3_dynamicfiltersselector1, "TIPOPAGAMENTONOME") == 0 ) && ( AV60Titulomovimentowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Titulomovimentowwds_6_tipopagamentonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome like '%' || :lV62Titulomovimentowwds_6_tipopagamentonome1)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( AV63Titulomovimentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Titulomovimentowwds_8_dynamicfiltersselector2, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV65Titulomovimentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV66Titulomovimentowwds_10_titulomovimentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor < :AV66Titulomovimentowwds_10_titulomovimentovalor2)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( AV63Titulomovimentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Titulomovimentowwds_8_dynamicfiltersselector2, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV65Titulomovimentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV66Titulomovimentowwds_10_titulomovimentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor = :AV66Titulomovimentowwds_10_titulomovimentovalor2)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( AV63Titulomovimentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Titulomovimentowwds_8_dynamicfiltersselector2, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV65Titulomovimentowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV66Titulomovimentowwds_10_titulomovimentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor > :AV66Titulomovimentowwds_10_titulomovimentovalor2)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( AV63Titulomovimentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Titulomovimentowwds_8_dynamicfiltersselector2, "TIPOPAGAMENTONOME") == 0 ) && ( AV65Titulomovimentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Titulomovimentowwds_11_tipopagamentonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome like :lV67Titulomovimentowwds_11_tipopagamentonome2)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( AV63Titulomovimentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Titulomovimentowwds_8_dynamicfiltersselector2, "TIPOPAGAMENTONOME") == 0 ) && ( AV65Titulomovimentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Titulomovimentowwds_11_tipopagamentonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome like '%' || :lV67Titulomovimentowwds_11_tipopagamentonome2)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( AV68Titulomovimentowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Titulomovimentowwds_13_dynamicfiltersselector3, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV70Titulomovimentowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV71Titulomovimentowwds_15_titulomovimentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor < :AV71Titulomovimentowwds_15_titulomovimentovalor3)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( AV68Titulomovimentowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Titulomovimentowwds_13_dynamicfiltersselector3, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV70Titulomovimentowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV71Titulomovimentowwds_15_titulomovimentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor = :AV71Titulomovimentowwds_15_titulomovimentovalor3)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( AV68Titulomovimentowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Titulomovimentowwds_13_dynamicfiltersselector3, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV70Titulomovimentowwds_14_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV71Titulomovimentowwds_15_titulomovimentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor > :AV71Titulomovimentowwds_15_titulomovimentovalor3)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( AV68Titulomovimentowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Titulomovimentowwds_13_dynamicfiltersselector3, "TIPOPAGAMENTONOME") == 0 ) && ( AV70Titulomovimentowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Titulomovimentowwds_16_tipopagamentonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome like :lV72Titulomovimentowwds_16_tipopagamentonome3)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( AV68Titulomovimentowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Titulomovimentowwds_13_dynamicfiltersselector3, "TIPOPAGAMENTONOME") == 0 ) && ( AV70Titulomovimentowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Titulomovimentowwds_16_tipopagamentonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome like '%' || :lV72Titulomovimentowwds_16_tipopagamentonome3)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV73Titulomovimentowwds_17_tftitulomovimentovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor >= :AV73Titulomovimentowwds_17_tftitulomovimentovalor)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV74Titulomovimentowwds_18_tftitulomovimentovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor <= :AV74Titulomovimentowwds_18_tftitulomovimentovalor_to)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( AV75Titulomovimentowwds_19_tftitulomovimentotipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV75Titulomovimentowwds_19_tftitulomovimentotipo_sels, "T1.TituloMovimentoTipo IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV76Titulomovimentowwds_20_tftitulomovimentodatacredito) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoDataCredito >= :AV76Titulomovimentowwds_20_tftitulomovimentodatacredito)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV77Titulomovimentowwds_21_tftitulomovimentodatacredito_to) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoDataCredito <= :AV77Titulomovimentowwds_21_tftitulomovimentodatacredito_to)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV78Titulomovimentowwds_22_tftitulomovimentocreatedat) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoCreatedAt >= :AV78Titulomovimentowwds_22_tftitulomovimentocreatedat)");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV79Titulomovimentowwds_23_tftitulomovimentocreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoCreatedAt <= :AV79Titulomovimentowwds_23_tftitulomovimentocreatedat_to)");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Titulomovimentowwds_25_tftipopagamentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Titulomovimentowwds_24_tftipopagamentonome)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome like :lV80Titulomovimentowwds_24_tftipopagamentonome)");
         }
         else
         {
            GXv_int7[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Titulomovimentowwds_25_tftipopagamentonome_sel)) && ! ( StringUtil.StrCmp(AV81Titulomovimentowwds_25_tftipopagamentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome = ( :AV81Titulomovimentowwds_25_tftipopagamentonome_sel))");
         }
         else
         {
            GXv_int7[29] = 1;
         }
         if ( StringUtil.StrCmp(AV81Titulomovimentowwds_25_tftipopagamentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome IS NULL or (char_length(trim(trailing ' ' from T2.TipoPagamentoNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( AV13OrderedBy == 1 )
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
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H004O2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (decimal)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (decimal)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (decimal)dynConstraints[17] , (decimal)dynConstraints[18] , (int)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (decimal)dynConstraints[26] , (string)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (short)dynConstraints[30] , (bool)dynConstraints[31] , (int)dynConstraints[32] , (int)dynConstraints[33] );
               case 1 :
                     return conditional_H004O3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (decimal)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (decimal)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (decimal)dynConstraints[17] , (decimal)dynConstraints[18] , (int)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (decimal)dynConstraints[26] , (string)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (short)dynConstraints[30] , (bool)dynConstraints[31] , (int)dynConstraints[32] , (int)dynConstraints[33] );
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
          Object[] prmH004O2;
          prmH004O2 = new Object[] {
          new ParDef("AV57Titulomovimentowwds_1_tituloid",GXType.Int32,9,0) ,
          new ParDef("lV58Titulomovimentowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Titulomovimentowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Titulomovimentowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Titulomovimentowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Titulomovimentowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Titulomovimentowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV61Titulomovimentowwds_5_titulomovimentovalor1",GXType.Number,18,2) ,
          new ParDef("AV61Titulomovimentowwds_5_titulomovimentovalor1",GXType.Number,18,2) ,
          new ParDef("AV61Titulomovimentowwds_5_titulomovimentovalor1",GXType.Number,18,2) ,
          new ParDef("lV62Titulomovimentowwds_6_tipopagamentonome1",GXType.VarChar,60,0) ,
          new ParDef("lV62Titulomovimentowwds_6_tipopagamentonome1",GXType.VarChar,60,0) ,
          new ParDef("AV66Titulomovimentowwds_10_titulomovimentovalor2",GXType.Number,18,2) ,
          new ParDef("AV66Titulomovimentowwds_10_titulomovimentovalor2",GXType.Number,18,2) ,
          new ParDef("AV66Titulomovimentowwds_10_titulomovimentovalor2",GXType.Number,18,2) ,
          new ParDef("lV67Titulomovimentowwds_11_tipopagamentonome2",GXType.VarChar,60,0) ,
          new ParDef("lV67Titulomovimentowwds_11_tipopagamentonome2",GXType.VarChar,60,0) ,
          new ParDef("AV71Titulomovimentowwds_15_titulomovimentovalor3",GXType.Number,18,2) ,
          new ParDef("AV71Titulomovimentowwds_15_titulomovimentovalor3",GXType.Number,18,2) ,
          new ParDef("AV71Titulomovimentowwds_15_titulomovimentovalor3",GXType.Number,18,2) ,
          new ParDef("lV72Titulomovimentowwds_16_tipopagamentonome3",GXType.VarChar,60,0) ,
          new ParDef("lV72Titulomovimentowwds_16_tipopagamentonome3",GXType.VarChar,60,0) ,
          new ParDef("AV73Titulomovimentowwds_17_tftitulomovimentovalor",GXType.Number,18,2) ,
          new ParDef("AV74Titulomovimentowwds_18_tftitulomovimentovalor_to",GXType.Number,18,2) ,
          new ParDef("AV76Titulomovimentowwds_20_tftitulomovimentodatacredito",GXType.Date,8,0) ,
          new ParDef("AV77Titulomovimentowwds_21_tftitulomovimentodatacredito_to",GXType.Date,8,0) ,
          new ParDef("AV78Titulomovimentowwds_22_tftitulomovimentocreatedat",GXType.DateTime,10,8) ,
          new ParDef("AV79Titulomovimentowwds_23_tftitulomovimentocreatedat_to",GXType.DateTime,10,8) ,
          new ParDef("lV80Titulomovimentowwds_24_tftipopagamentonome",GXType.VarChar,60,0) ,
          new ParDef("AV81Titulomovimentowwds_25_tftipopagamentonome_sel",GXType.VarChar,60,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH004O3;
          prmH004O3 = new Object[] {
          new ParDef("AV57Titulomovimentowwds_1_tituloid",GXType.Int32,9,0) ,
          new ParDef("lV58Titulomovimentowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Titulomovimentowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Titulomovimentowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Titulomovimentowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Titulomovimentowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Titulomovimentowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV61Titulomovimentowwds_5_titulomovimentovalor1",GXType.Number,18,2) ,
          new ParDef("AV61Titulomovimentowwds_5_titulomovimentovalor1",GXType.Number,18,2) ,
          new ParDef("AV61Titulomovimentowwds_5_titulomovimentovalor1",GXType.Number,18,2) ,
          new ParDef("lV62Titulomovimentowwds_6_tipopagamentonome1",GXType.VarChar,60,0) ,
          new ParDef("lV62Titulomovimentowwds_6_tipopagamentonome1",GXType.VarChar,60,0) ,
          new ParDef("AV66Titulomovimentowwds_10_titulomovimentovalor2",GXType.Number,18,2) ,
          new ParDef("AV66Titulomovimentowwds_10_titulomovimentovalor2",GXType.Number,18,2) ,
          new ParDef("AV66Titulomovimentowwds_10_titulomovimentovalor2",GXType.Number,18,2) ,
          new ParDef("lV67Titulomovimentowwds_11_tipopagamentonome2",GXType.VarChar,60,0) ,
          new ParDef("lV67Titulomovimentowwds_11_tipopagamentonome2",GXType.VarChar,60,0) ,
          new ParDef("AV71Titulomovimentowwds_15_titulomovimentovalor3",GXType.Number,18,2) ,
          new ParDef("AV71Titulomovimentowwds_15_titulomovimentovalor3",GXType.Number,18,2) ,
          new ParDef("AV71Titulomovimentowwds_15_titulomovimentovalor3",GXType.Number,18,2) ,
          new ParDef("lV72Titulomovimentowwds_16_tipopagamentonome3",GXType.VarChar,60,0) ,
          new ParDef("lV72Titulomovimentowwds_16_tipopagamentonome3",GXType.VarChar,60,0) ,
          new ParDef("AV73Titulomovimentowwds_17_tftitulomovimentovalor",GXType.Number,18,2) ,
          new ParDef("AV74Titulomovimentowwds_18_tftitulomovimentovalor_to",GXType.Number,18,2) ,
          new ParDef("AV76Titulomovimentowwds_20_tftitulomovimentodatacredito",GXType.Date,8,0) ,
          new ParDef("AV77Titulomovimentowwds_21_tftitulomovimentodatacredito_to",GXType.Date,8,0) ,
          new ParDef("AV78Titulomovimentowwds_22_tftitulomovimentocreatedat",GXType.DateTime,10,8) ,
          new ParDef("AV79Titulomovimentowwds_23_tftitulomovimentocreatedat_to",GXType.DateTime,10,8) ,
          new ParDef("lV80Titulomovimentowwds_24_tftipopagamentonome",GXType.VarChar,60,0) ,
          new ParDef("AV81Titulomovimentowwds_25_tftipopagamentonome_sel",GXType.VarChar,60,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004O2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004O3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004O3,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((int[]) buf[17])[0] = rslt.getInt(10);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
