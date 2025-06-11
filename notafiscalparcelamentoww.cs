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
   public class notafiscalparcelamentoww : GXWebComponent
   {
      public notafiscalparcelamentoww( )
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

      public notafiscalparcelamentoww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_JSON )
      {
         this.AV27JSON = aP0_JSON;
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
               gxfirstwebparm = GetFirstPar( "JSON");
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
                  AV27JSON = GetPar( "JSON");
                  AssignAttri(sPrefix, false, "AV27JSON", AV27JSON);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV27JSON});
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
                  gxfirstwebparm = GetFirstPar( "JSON");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "JSON");
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
         ajax_req_read_hidden_sdt(GetNextPar( ), AV29array_NotaFiscalId);
         AV15TFNotaFiscalNumero = GetPar( "TFNotaFiscalNumero");
         AV16TFNotaFiscalNumero_Sel = GetPar( "TFNotaFiscalNumero_Sel");
         AV17TFNotaFiscalParcelamentoNumero = GetPar( "TFNotaFiscalParcelamentoNumero");
         AV18TFNotaFiscalParcelamentoNumero_Sel = GetPar( "TFNotaFiscalParcelamentoNumero_Sel");
         AV21TFNotaFiscalParcelamentoVencimento = context.localUtil.ParseDateParm( GetPar( "TFNotaFiscalParcelamentoVencimento"));
         AV22TFNotaFiscalParcelamentoVencimento_To = context.localUtil.ParseDateParm( GetPar( "TFNotaFiscalParcelamentoVencimento_To"));
         AV19TFNotaFiscalParcelamentoValor = NumberUtil.Val( GetPar( "TFNotaFiscalParcelamentoValor"), ".");
         AV20TFNotaFiscalParcelamentoValor_To = NumberUtil.Val( GetPar( "TFNotaFiscalParcelamentoValor_To"), ".");
         AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa = NumberUtil.Val( GetPar( "TFNotaFiscalParcelamentoValorTaxaAdministrativa"), ".");
         AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To = NumberUtil.Val( GetPar( "TFNotaFiscalParcelamentoValorTaxaAdministrativa_To"), ".");
         AV32TFNotaFiscalParcelamentoValorTaxaAnual = NumberUtil.Val( GetPar( "TFNotaFiscalParcelamentoValorTaxaAnual"), ".");
         AV33TFNotaFiscalParcelamentoValorTaxaAnual_To = NumberUtil.Val( GetPar( "TFNotaFiscalParcelamentoValorTaxaAnual_To"), ".");
         AV34TFNotaFiscalParcelamentoLiquido = NumberUtil.Val( GetPar( "TFNotaFiscalParcelamentoLiquido"), ".");
         AV35TFNotaFiscalParcelamentoLiquido_To = NumberUtil.Val( GetPar( "TFNotaFiscalParcelamentoLiquido_To"), ".");
         AV50Pgmname = GetPar( "Pgmname");
         AV27JSON = GetPar( "JSON");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV29array_NotaFiscalId, AV15TFNotaFiscalNumero, AV16TFNotaFiscalNumero_Sel, AV17TFNotaFiscalParcelamentoNumero, AV18TFNotaFiscalParcelamentoNumero_Sel, AV21TFNotaFiscalParcelamentoVencimento, AV22TFNotaFiscalParcelamentoVencimento_To, AV19TFNotaFiscalParcelamentoValor, AV20TFNotaFiscalParcelamentoValor_To, AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa, AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To, AV32TFNotaFiscalParcelamentoValorTaxaAnual, AV33TFNotaFiscalParcelamentoValorTaxaAnual_To, AV34TFNotaFiscalParcelamentoLiquido, AV35TFNotaFiscalParcelamentoLiquido_To, AV50Pgmname, AV27JSON, sPrefix) ;
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
            PA9E2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV50Pgmname = "NotaFiscalParcelamentoWW";
               WS9E2( ) ;
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
            context.SendWebValue( " Nota Fiscal Parcelamento") ;
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
            GXEncryptionTmp = "notafiscalparcelamentoww"+UrlEncode(StringUtil.RTrim(AV27JSON));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("notafiscalparcelamentoww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV50Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV50Pgmname, "")), context));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_NOTAFISCALPARCELAMENTOVENCIMENTOAUXDATE", context.localUtil.DToC( AV23DDO_NotaFiscalParcelamentoVencimentoAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_NOTAFISCALPARCELAMENTOVENCIMENTOAUXDATETO", context.localUtil.DToC( AV24DDO_NotaFiscalParcelamentoVencimentoAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV27JSON", wcpOAV27JSON);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALNUMERO", AV15TFNotaFiscalNumero);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALNUMERO_SEL", AV16TFNotaFiscalNumero_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALPARCELAMENTONUMERO", AV17TFNotaFiscalParcelamentoNumero);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALPARCELAMENTONUMERO_SEL", AV18TFNotaFiscalParcelamentoNumero_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALPARCELAMENTOVENCIMENTO", context.localUtil.DToC( AV21TFNotaFiscalParcelamentoVencimento, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALPARCELAMENTOVENCIMENTO_TO", context.localUtil.DToC( AV22TFNotaFiscalParcelamentoVencimento_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALPARCELAMENTOVALOR", StringUtil.LTrim( StringUtil.NToC( AV19TFNotaFiscalParcelamentoValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALPARCELAMENTOVALOR_TO", StringUtil.LTrim( StringUtil.NToC( AV20TFNotaFiscalParcelamentoValor_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA", StringUtil.LTrim( StringUtil.NToC( AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA_TO", StringUtil.LTrim( StringUtil.NToC( AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALPARCELAMENTOVALORTAXAANUAL", StringUtil.LTrim( StringUtil.NToC( AV32TFNotaFiscalParcelamentoValorTaxaAnual, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALPARCELAMENTOVALORTAXAANUAL_TO", StringUtil.LTrim( StringUtil.NToC( AV33TFNotaFiscalParcelamentoValorTaxaAnual_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALPARCELAMENTOLIQUIDO", StringUtil.LTrim( StringUtil.NToC( AV34TFNotaFiscalParcelamentoLiquido, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALPARCELAMENTOLIQUIDO_TO", StringUtil.LTrim( StringUtil.NToC( AV35TFNotaFiscalParcelamentoLiquido_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV50Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV50Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV13OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vJSON", AV27JSON);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vARRAY_NOTAFISCALID", AV29array_NotaFiscalId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vARRAY_NOTAFISCALID", AV29array_NotaFiscalId);
         }
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

      protected void RenderHtmlCloseForm9E2( )
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
         return "NotaFiscalParcelamentoWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Nota Fiscal Parcelamento" ;
      }

      protected void WB9E0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "notafiscalparcelamentoww");
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
            GxWebStd.gx_div_start( context, divDdo_notafiscalparcelamentovencimentoauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'" + sGXsfl_12_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_notafiscalparcelamentovencimentoauxdatetext_Internalname, AV25DDO_NotaFiscalParcelamentoVencimentoAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV25DDO_NotaFiscalParcelamentoVencimentoAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_notafiscalparcelamentovencimentoauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscalParcelamentoWW.htm");
            /* User Defined Control */
            ucTfnotafiscalparcelamentovencimento_rangepicker.SetProperty("Start Date", AV23DDO_NotaFiscalParcelamentoVencimentoAuxDate);
            ucTfnotafiscalparcelamentovencimento_rangepicker.SetProperty("End Date", AV24DDO_NotaFiscalParcelamentoVencimentoAuxDateTo);
            ucTfnotafiscalparcelamentovencimento_rangepicker.Render(context, "wwp.daterangepicker", Tfnotafiscalparcelamentovencimento_rangepicker_Internalname, sPrefix+"TFNOTAFISCALPARCELAMENTOVENCIMENTO_RANGEPICKERContainer");
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

      protected void START9E2( )
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
            Form.Meta.addItem("description", " Nota Fiscal Parcelamento", 0) ;
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
               STRUP9E0( ) ;
            }
         }
      }

      protected void WS9E2( )
      {
         START9E2( ) ;
         EVT9E2( ) ;
      }

      protected void EVT9E2( )
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
                                 STRUP9E0( ) ;
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
                                 STRUP9E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E119E2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP9E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavDdo_notafiscalparcelamentovencimentoauxdatetext_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP9E0( ) ;
                              }
                              AV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero = AV15TFNotaFiscalNumero;
                              AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel = AV16TFNotaFiscalNumero_Sel;
                              AV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero = AV17TFNotaFiscalParcelamentoNumero;
                              AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel = AV18TFNotaFiscalParcelamentoNumero_Sel;
                              AV40Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento = AV21TFNotaFiscalParcelamentoVencimento;
                              AV41Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to = AV22TFNotaFiscalParcelamentoVencimento_To;
                              AV42Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor = AV19TFNotaFiscalParcelamentoValor;
                              AV43Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to = AV20TFNotaFiscalParcelamentoValor_To;
                              AV44Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa = AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa;
                              AV45Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to = AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To;
                              AV46Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual = AV32TFNotaFiscalParcelamentoValorTaxaAnual;
                              AV47Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to = AV33TFNotaFiscalParcelamentoValorTaxaAnual_To;
                              AV48Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido = AV34TFNotaFiscalParcelamentoLiquido;
                              AV49Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to = AV35TFNotaFiscalParcelamentoLiquido_To;
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
                                 STRUP9E0( ) ;
                              }
                              nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
                              SubsflControlProps_122( ) ;
                              A890NotaFiscalParcelamentoID = StringUtil.StrToGuid( cgiGet( edtNotaFiscalParcelamentoID_Internalname));
                              A794NotaFiscalId = StringUtil.StrToGuid( cgiGet( edtNotaFiscalId_Internalname));
                              n794NotaFiscalId = false;
                              A799NotaFiscalNumero = cgiGet( edtNotaFiscalNumero_Internalname);
                              n799NotaFiscalNumero = false;
                              A891NotaFiscalParcelamentoNumero = cgiGet( edtNotaFiscalParcelamentoNumero_Internalname);
                              n891NotaFiscalParcelamentoNumero = false;
                              A893NotaFiscalParcelamentoVencimento = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtNotaFiscalParcelamentoVencimento_Internalname), 0));
                              n893NotaFiscalParcelamentoVencimento = false;
                              A892NotaFiscalParcelamentoValor = context.localUtil.CToN( cgiGet( edtNotaFiscalParcelamentoValor_Internalname), ",", ".");
                              n892NotaFiscalParcelamentoValor = false;
                              A895NotaFiscalParcelamentoValorTaxaAdministrativa = context.localUtil.CToN( cgiGet( edtNotaFiscalParcelamentoValorTaxaAdministrativa_Internalname), ",", ".");
                              n895NotaFiscalParcelamentoValorTaxaAdministrativa = false;
                              A896NotaFiscalParcelamentoValorTaxaAnual = context.localUtil.CToN( cgiGet( edtNotaFiscalParcelamentoValorTaxaAnual_Internalname), ",", ".");
                              n896NotaFiscalParcelamentoValorTaxaAnual = false;
                              A897NotaFiscalParcelamentoLiquido = context.localUtil.CToN( cgiGet( edtNotaFiscalParcelamentoLiquido_Internalname), ",", ".");
                              n897NotaFiscalParcelamentoLiquido = false;
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
                                          GX_FocusControl = edtavDdo_notafiscalparcelamentovencimentoauxdatetext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E129E2 ();
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
                                          GX_FocusControl = edtavDdo_notafiscalparcelamentovencimentoauxdatetext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E139E2 ();
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
                                          GX_FocusControl = edtavDdo_notafiscalparcelamentovencimentoauxdatetext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E149E2 ();
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
                                       STRUP9E0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDdo_notafiscalparcelamentovencimentoauxdatetext_Internalname;
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

      protected void WE9E2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm9E2( ) ;
            }
         }
      }

      protected void PA9E2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "notafiscalparcelamentoww")), "notafiscalparcelamentoww") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "notafiscalparcelamentoww")))) ;
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
                     gxfirstwebparm = GetFirstPar( "JSON");
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
               GX_FocusControl = edtavDdo_notafiscalparcelamentovencimentoauxdatetext_Internalname;
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
                                       GxSimpleCollection<Guid> AV29array_NotaFiscalId ,
                                       string AV15TFNotaFiscalNumero ,
                                       string AV16TFNotaFiscalNumero_Sel ,
                                       string AV17TFNotaFiscalParcelamentoNumero ,
                                       string AV18TFNotaFiscalParcelamentoNumero_Sel ,
                                       DateTime AV21TFNotaFiscalParcelamentoVencimento ,
                                       DateTime AV22TFNotaFiscalParcelamentoVencimento_To ,
                                       decimal AV19TFNotaFiscalParcelamentoValor ,
                                       decimal AV20TFNotaFiscalParcelamentoValor_To ,
                                       decimal AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa ,
                                       decimal AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To ,
                                       decimal AV32TFNotaFiscalParcelamentoValorTaxaAnual ,
                                       decimal AV33TFNotaFiscalParcelamentoValorTaxaAnual_To ,
                                       decimal AV34TFNotaFiscalParcelamentoLiquido ,
                                       decimal AV35TFNotaFiscalParcelamentoLiquido_To ,
                                       string AV50Pgmname ,
                                       string AV27JSON ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF9E2( ) ;
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
         RF9E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV50Pgmname = "NotaFiscalParcelamentoWW";
      }

      protected void RF9E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 12;
         /* Execute user event: Refresh */
         E139E2 ();
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
                                                 A794NotaFiscalId ,
                                                 AV29array_NotaFiscalId ,
                                                 AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel ,
                                                 AV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero ,
                                                 AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel ,
                                                 AV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero ,
                                                 AV40Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento ,
                                                 AV41Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to ,
                                                 AV42Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor ,
                                                 AV43Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to ,
                                                 AV44Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa ,
                                                 AV45Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to ,
                                                 AV46Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual ,
                                                 AV47Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to ,
                                                 AV48Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido ,
                                                 AV49Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to ,
                                                 A799NotaFiscalNumero ,
                                                 A891NotaFiscalParcelamentoNumero ,
                                                 A893NotaFiscalParcelamentoVencimento ,
                                                 A892NotaFiscalParcelamentoValor ,
                                                 A895NotaFiscalParcelamentoValorTaxaAdministrativa ,
                                                 A896NotaFiscalParcelamentoValorTaxaAnual ,
                                                 A897NotaFiscalParcelamentoLiquido ,
                                                 AV12OrderedBy ,
                                                 AV13OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                                 TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                                 TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero), "%", "");
            lV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero = StringUtil.Concat( StringUtil.RTrim( AV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero), "%", "");
            /* Using cursor H009E2 */
            pr_default.execute(0, new Object[] {lV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero, AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel, lV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero, AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel, AV40Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento, AV41Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to, AV42Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor, AV43Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to, AV44Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa, AV45Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to, AV46Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual, AV47Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to, AV48Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido, AV49Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_12_idx = 1;
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A897NotaFiscalParcelamentoLiquido = H009E2_A897NotaFiscalParcelamentoLiquido[0];
               n897NotaFiscalParcelamentoLiquido = H009E2_n897NotaFiscalParcelamentoLiquido[0];
               A896NotaFiscalParcelamentoValorTaxaAnual = H009E2_A896NotaFiscalParcelamentoValorTaxaAnual[0];
               n896NotaFiscalParcelamentoValorTaxaAnual = H009E2_n896NotaFiscalParcelamentoValorTaxaAnual[0];
               A895NotaFiscalParcelamentoValorTaxaAdministrativa = H009E2_A895NotaFiscalParcelamentoValorTaxaAdministrativa[0];
               n895NotaFiscalParcelamentoValorTaxaAdministrativa = H009E2_n895NotaFiscalParcelamentoValorTaxaAdministrativa[0];
               A892NotaFiscalParcelamentoValor = H009E2_A892NotaFiscalParcelamentoValor[0];
               n892NotaFiscalParcelamentoValor = H009E2_n892NotaFiscalParcelamentoValor[0];
               A893NotaFiscalParcelamentoVencimento = H009E2_A893NotaFiscalParcelamentoVencimento[0];
               n893NotaFiscalParcelamentoVencimento = H009E2_n893NotaFiscalParcelamentoVencimento[0];
               A891NotaFiscalParcelamentoNumero = H009E2_A891NotaFiscalParcelamentoNumero[0];
               n891NotaFiscalParcelamentoNumero = H009E2_n891NotaFiscalParcelamentoNumero[0];
               A799NotaFiscalNumero = H009E2_A799NotaFiscalNumero[0];
               n799NotaFiscalNumero = H009E2_n799NotaFiscalNumero[0];
               A794NotaFiscalId = H009E2_A794NotaFiscalId[0];
               n794NotaFiscalId = H009E2_n794NotaFiscalId[0];
               A890NotaFiscalParcelamentoID = H009E2_A890NotaFiscalParcelamentoID[0];
               A799NotaFiscalNumero = H009E2_A799NotaFiscalNumero[0];
               n799NotaFiscalNumero = H009E2_n799NotaFiscalNumero[0];
               /* Execute user event: Grid.Load */
               E149E2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 12;
            WB9E0( ) ;
         }
         bGXsfl_12_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9E2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV50Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV50Pgmname, "")), context));
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
         AV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero = AV15TFNotaFiscalNumero;
         AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel = AV16TFNotaFiscalNumero_Sel;
         AV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero = AV17TFNotaFiscalParcelamentoNumero;
         AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel = AV18TFNotaFiscalParcelamentoNumero_Sel;
         AV40Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento = AV21TFNotaFiscalParcelamentoVencimento;
         AV41Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to = AV22TFNotaFiscalParcelamentoVencimento_To;
         AV42Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor = AV19TFNotaFiscalParcelamentoValor;
         AV43Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to = AV20TFNotaFiscalParcelamentoValor_To;
         AV44Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa = AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa;
         AV45Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to = AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To;
         AV46Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual = AV32TFNotaFiscalParcelamentoValorTaxaAnual;
         AV47Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to = AV33TFNotaFiscalParcelamentoValorTaxaAnual_To;
         AV48Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido = AV34TFNotaFiscalParcelamentoLiquido;
         AV49Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to = AV35TFNotaFiscalParcelamentoLiquido_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A794NotaFiscalId ,
                                              AV29array_NotaFiscalId ,
                                              AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel ,
                                              AV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero ,
                                              AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel ,
                                              AV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero ,
                                              AV40Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento ,
                                              AV41Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to ,
                                              AV42Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor ,
                                              AV43Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to ,
                                              AV44Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa ,
                                              AV45Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to ,
                                              AV46Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual ,
                                              AV47Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to ,
                                              AV48Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido ,
                                              AV49Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to ,
                                              A799NotaFiscalNumero ,
                                              A891NotaFiscalParcelamentoNumero ,
                                              A893NotaFiscalParcelamentoVencimento ,
                                              A892NotaFiscalParcelamentoValor ,
                                              A895NotaFiscalParcelamentoValorTaxaAdministrativa ,
                                              A896NotaFiscalParcelamentoValorTaxaAnual ,
                                              A897NotaFiscalParcelamentoLiquido ,
                                              AV12OrderedBy ,
                                              AV13OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero), "%", "");
         lV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero = StringUtil.Concat( StringUtil.RTrim( AV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero), "%", "");
         /* Using cursor H009E3 */
         pr_default.execute(1, new Object[] {lV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero, AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel, lV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero, AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel, AV40Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento, AV41Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to, AV42Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor, AV43Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to, AV44Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa, AV45Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to, AV46Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual, AV47Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to, AV48Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido, AV49Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to});
         GRID_nRecordCount = H009E3_AGRID_nRecordCount[0];
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
         AV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero = AV15TFNotaFiscalNumero;
         AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel = AV16TFNotaFiscalNumero_Sel;
         AV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero = AV17TFNotaFiscalParcelamentoNumero;
         AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel = AV18TFNotaFiscalParcelamentoNumero_Sel;
         AV40Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento = AV21TFNotaFiscalParcelamentoVencimento;
         AV41Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to = AV22TFNotaFiscalParcelamentoVencimento_To;
         AV42Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor = AV19TFNotaFiscalParcelamentoValor;
         AV43Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to = AV20TFNotaFiscalParcelamentoValor_To;
         AV44Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa = AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa;
         AV45Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to = AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To;
         AV46Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual = AV32TFNotaFiscalParcelamentoValorTaxaAnual;
         AV47Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to = AV33TFNotaFiscalParcelamentoValorTaxaAnual_To;
         AV48Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido = AV34TFNotaFiscalParcelamentoLiquido;
         AV49Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to = AV35TFNotaFiscalParcelamentoLiquido_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV29array_NotaFiscalId, AV15TFNotaFiscalNumero, AV16TFNotaFiscalNumero_Sel, AV17TFNotaFiscalParcelamentoNumero, AV18TFNotaFiscalParcelamentoNumero_Sel, AV21TFNotaFiscalParcelamentoVencimento, AV22TFNotaFiscalParcelamentoVencimento_To, AV19TFNotaFiscalParcelamentoValor, AV20TFNotaFiscalParcelamentoValor_To, AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa, AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To, AV32TFNotaFiscalParcelamentoValorTaxaAnual, AV33TFNotaFiscalParcelamentoValorTaxaAnual_To, AV34TFNotaFiscalParcelamentoLiquido, AV35TFNotaFiscalParcelamentoLiquido_To, AV50Pgmname, AV27JSON, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero = AV15TFNotaFiscalNumero;
         AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel = AV16TFNotaFiscalNumero_Sel;
         AV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero = AV17TFNotaFiscalParcelamentoNumero;
         AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel = AV18TFNotaFiscalParcelamentoNumero_Sel;
         AV40Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento = AV21TFNotaFiscalParcelamentoVencimento;
         AV41Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to = AV22TFNotaFiscalParcelamentoVencimento_To;
         AV42Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor = AV19TFNotaFiscalParcelamentoValor;
         AV43Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to = AV20TFNotaFiscalParcelamentoValor_To;
         AV44Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa = AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa;
         AV45Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to = AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To;
         AV46Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual = AV32TFNotaFiscalParcelamentoValorTaxaAnual;
         AV47Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to = AV33TFNotaFiscalParcelamentoValorTaxaAnual_To;
         AV48Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido = AV34TFNotaFiscalParcelamentoLiquido;
         AV49Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to = AV35TFNotaFiscalParcelamentoLiquido_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV29array_NotaFiscalId, AV15TFNotaFiscalNumero, AV16TFNotaFiscalNumero_Sel, AV17TFNotaFiscalParcelamentoNumero, AV18TFNotaFiscalParcelamentoNumero_Sel, AV21TFNotaFiscalParcelamentoVencimento, AV22TFNotaFiscalParcelamentoVencimento_To, AV19TFNotaFiscalParcelamentoValor, AV20TFNotaFiscalParcelamentoValor_To, AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa, AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To, AV32TFNotaFiscalParcelamentoValorTaxaAnual, AV33TFNotaFiscalParcelamentoValorTaxaAnual_To, AV34TFNotaFiscalParcelamentoLiquido, AV35TFNotaFiscalParcelamentoLiquido_To, AV50Pgmname, AV27JSON, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero = AV15TFNotaFiscalNumero;
         AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel = AV16TFNotaFiscalNumero_Sel;
         AV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero = AV17TFNotaFiscalParcelamentoNumero;
         AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel = AV18TFNotaFiscalParcelamentoNumero_Sel;
         AV40Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento = AV21TFNotaFiscalParcelamentoVencimento;
         AV41Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to = AV22TFNotaFiscalParcelamentoVencimento_To;
         AV42Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor = AV19TFNotaFiscalParcelamentoValor;
         AV43Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to = AV20TFNotaFiscalParcelamentoValor_To;
         AV44Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa = AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa;
         AV45Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to = AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To;
         AV46Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual = AV32TFNotaFiscalParcelamentoValorTaxaAnual;
         AV47Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to = AV33TFNotaFiscalParcelamentoValorTaxaAnual_To;
         AV48Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido = AV34TFNotaFiscalParcelamentoLiquido;
         AV49Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to = AV35TFNotaFiscalParcelamentoLiquido_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV29array_NotaFiscalId, AV15TFNotaFiscalNumero, AV16TFNotaFiscalNumero_Sel, AV17TFNotaFiscalParcelamentoNumero, AV18TFNotaFiscalParcelamentoNumero_Sel, AV21TFNotaFiscalParcelamentoVencimento, AV22TFNotaFiscalParcelamentoVencimento_To, AV19TFNotaFiscalParcelamentoValor, AV20TFNotaFiscalParcelamentoValor_To, AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa, AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To, AV32TFNotaFiscalParcelamentoValorTaxaAnual, AV33TFNotaFiscalParcelamentoValorTaxaAnual_To, AV34TFNotaFiscalParcelamentoLiquido, AV35TFNotaFiscalParcelamentoLiquido_To, AV50Pgmname, AV27JSON, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero = AV15TFNotaFiscalNumero;
         AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel = AV16TFNotaFiscalNumero_Sel;
         AV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero = AV17TFNotaFiscalParcelamentoNumero;
         AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel = AV18TFNotaFiscalParcelamentoNumero_Sel;
         AV40Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento = AV21TFNotaFiscalParcelamentoVencimento;
         AV41Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to = AV22TFNotaFiscalParcelamentoVencimento_To;
         AV42Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor = AV19TFNotaFiscalParcelamentoValor;
         AV43Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to = AV20TFNotaFiscalParcelamentoValor_To;
         AV44Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa = AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa;
         AV45Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to = AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To;
         AV46Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual = AV32TFNotaFiscalParcelamentoValorTaxaAnual;
         AV47Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to = AV33TFNotaFiscalParcelamentoValorTaxaAnual_To;
         AV48Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido = AV34TFNotaFiscalParcelamentoLiquido;
         AV49Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to = AV35TFNotaFiscalParcelamentoLiquido_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV29array_NotaFiscalId, AV15TFNotaFiscalNumero, AV16TFNotaFiscalNumero_Sel, AV17TFNotaFiscalParcelamentoNumero, AV18TFNotaFiscalParcelamentoNumero_Sel, AV21TFNotaFiscalParcelamentoVencimento, AV22TFNotaFiscalParcelamentoVencimento_To, AV19TFNotaFiscalParcelamentoValor, AV20TFNotaFiscalParcelamentoValor_To, AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa, AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To, AV32TFNotaFiscalParcelamentoValorTaxaAnual, AV33TFNotaFiscalParcelamentoValorTaxaAnual_To, AV34TFNotaFiscalParcelamentoLiquido, AV35TFNotaFiscalParcelamentoLiquido_To, AV50Pgmname, AV27JSON, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero = AV15TFNotaFiscalNumero;
         AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel = AV16TFNotaFiscalNumero_Sel;
         AV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero = AV17TFNotaFiscalParcelamentoNumero;
         AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel = AV18TFNotaFiscalParcelamentoNumero_Sel;
         AV40Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento = AV21TFNotaFiscalParcelamentoVencimento;
         AV41Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to = AV22TFNotaFiscalParcelamentoVencimento_To;
         AV42Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor = AV19TFNotaFiscalParcelamentoValor;
         AV43Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to = AV20TFNotaFiscalParcelamentoValor_To;
         AV44Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa = AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa;
         AV45Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to = AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To;
         AV46Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual = AV32TFNotaFiscalParcelamentoValorTaxaAnual;
         AV47Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to = AV33TFNotaFiscalParcelamentoValorTaxaAnual_To;
         AV48Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido = AV34TFNotaFiscalParcelamentoLiquido;
         AV49Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to = AV35TFNotaFiscalParcelamentoLiquido_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV29array_NotaFiscalId, AV15TFNotaFiscalNumero, AV16TFNotaFiscalNumero_Sel, AV17TFNotaFiscalParcelamentoNumero, AV18TFNotaFiscalParcelamentoNumero_Sel, AV21TFNotaFiscalParcelamentoVencimento, AV22TFNotaFiscalParcelamentoVencimento_To, AV19TFNotaFiscalParcelamentoValor, AV20TFNotaFiscalParcelamentoValor_To, AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa, AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To, AV32TFNotaFiscalParcelamentoValorTaxaAnual, AV33TFNotaFiscalParcelamentoValorTaxaAnual_To, AV34TFNotaFiscalParcelamentoLiquido, AV35TFNotaFiscalParcelamentoLiquido_To, AV50Pgmname, AV27JSON, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV50Pgmname = "NotaFiscalParcelamentoWW";
         edtNotaFiscalParcelamentoID_Enabled = 0;
         edtNotaFiscalId_Enabled = 0;
         edtNotaFiscalNumero_Enabled = 0;
         edtNotaFiscalParcelamentoNumero_Enabled = 0;
         edtNotaFiscalParcelamentoVencimento_Enabled = 0;
         edtNotaFiscalParcelamentoValor_Enabled = 0;
         edtNotaFiscalParcelamentoValorTaxaAdministrativa_Enabled = 0;
         edtNotaFiscalParcelamentoValorTaxaAnual_Enabled = 0;
         edtNotaFiscalParcelamentoLiquido_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E129E2 ();
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
            AV23DDO_NotaFiscalParcelamentoVencimentoAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_NOTAFISCALPARCELAMENTOVENCIMENTOAUXDATE"), 0);
            AV24DDO_NotaFiscalParcelamentoVencimentoAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_NOTAFISCALPARCELAMENTOVENCIMENTOAUXDATETO"), 0);
            wcpOAV27JSON = cgiGet( sPrefix+"wcpOAV27JSON");
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
            AV25DDO_NotaFiscalParcelamentoVencimentoAuxDateText = cgiGet( edtavDdo_notafiscalparcelamentovencimentoauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV25DDO_NotaFiscalParcelamentoVencimentoAuxDateText", AV25DDO_NotaFiscalParcelamentoVencimentoAuxDateText);
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
         E129E2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E129E2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV29array_NotaFiscalId = (GxSimpleCollection<Guid>)(new GxSimpleCollection<Guid>());
         AV29array_NotaFiscalId.FromJSonString(AV27JSON, null);
         this.executeUsercontrolMethod(sPrefix, false, "TFNOTAFISCALPARCELAMENTOVENCIMENTO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_notafiscalparcelamentovencimentoauxdatetext_Internalname});
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

      protected void E139E2( )
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
         AV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero = AV15TFNotaFiscalNumero;
         AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel = AV16TFNotaFiscalNumero_Sel;
         AV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero = AV17TFNotaFiscalParcelamentoNumero;
         AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel = AV18TFNotaFiscalParcelamentoNumero_Sel;
         AV40Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento = AV21TFNotaFiscalParcelamentoVencimento;
         AV41Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to = AV22TFNotaFiscalParcelamentoVencimento_To;
         AV42Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor = AV19TFNotaFiscalParcelamentoValor;
         AV43Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to = AV20TFNotaFiscalParcelamentoValor_To;
         AV44Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa = AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa;
         AV45Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to = AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To;
         AV46Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual = AV32TFNotaFiscalParcelamentoValorTaxaAnual;
         AV47Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to = AV33TFNotaFiscalParcelamentoValorTaxaAnual_To;
         AV48Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido = AV34TFNotaFiscalParcelamentoLiquido;
         AV49Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to = AV35TFNotaFiscalParcelamentoLiquido_To;
      }

      protected void E119E2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalNumero") == 0 )
            {
               AV15TFNotaFiscalNumero = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV15TFNotaFiscalNumero", AV15TFNotaFiscalNumero);
               AV16TFNotaFiscalNumero_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV16TFNotaFiscalNumero_Sel", AV16TFNotaFiscalNumero_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalParcelamentoNumero") == 0 )
            {
               AV17TFNotaFiscalParcelamentoNumero = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV17TFNotaFiscalParcelamentoNumero", AV17TFNotaFiscalParcelamentoNumero);
               AV18TFNotaFiscalParcelamentoNumero_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV18TFNotaFiscalParcelamentoNumero_Sel", AV18TFNotaFiscalParcelamentoNumero_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalParcelamentoVencimento") == 0 )
            {
               AV21TFNotaFiscalParcelamentoVencimento = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 4);
               AssignAttri(sPrefix, false, "AV21TFNotaFiscalParcelamentoVencimento", context.localUtil.Format(AV21TFNotaFiscalParcelamentoVencimento, "99/99/9999"));
               AV22TFNotaFiscalParcelamentoVencimento_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri(sPrefix, false, "AV22TFNotaFiscalParcelamentoVencimento_To", context.localUtil.Format(AV22TFNotaFiscalParcelamentoVencimento_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalParcelamentoValor") == 0 )
            {
               AV19TFNotaFiscalParcelamentoValor = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV19TFNotaFiscalParcelamentoValor", StringUtil.LTrimStr( AV19TFNotaFiscalParcelamentoValor, 18, 2));
               AV20TFNotaFiscalParcelamentoValor_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV20TFNotaFiscalParcelamentoValor_To", StringUtil.LTrimStr( AV20TFNotaFiscalParcelamentoValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalParcelamentoValorTaxaAdministrativa") == 0 )
            {
               AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa", StringUtil.LTrimStr( AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa, 18, 2));
               AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To", StringUtil.LTrimStr( AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalParcelamentoValorTaxaAnual") == 0 )
            {
               AV32TFNotaFiscalParcelamentoValorTaxaAnual = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV32TFNotaFiscalParcelamentoValorTaxaAnual", StringUtil.LTrimStr( AV32TFNotaFiscalParcelamentoValorTaxaAnual, 18, 2));
               AV33TFNotaFiscalParcelamentoValorTaxaAnual_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV33TFNotaFiscalParcelamentoValorTaxaAnual_To", StringUtil.LTrimStr( AV33TFNotaFiscalParcelamentoValorTaxaAnual_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalParcelamentoLiquido") == 0 )
            {
               AV34TFNotaFiscalParcelamentoLiquido = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV34TFNotaFiscalParcelamentoLiquido", StringUtil.LTrimStr( AV34TFNotaFiscalParcelamentoLiquido, 18, 2));
               AV35TFNotaFiscalParcelamentoLiquido_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV35TFNotaFiscalParcelamentoLiquido_To", StringUtil.LTrimStr( AV35TFNotaFiscalParcelamentoLiquido_To, 18, 2));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E149E2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
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
         if ( StringUtil.StrCmp(AV14Session.Get(AV50Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV50Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV14Session.Get(AV50Pgmname+"GridState"), null, "", "");
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
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV51GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO") == 0 )
            {
               AV15TFNotaFiscalNumero = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV15TFNotaFiscalNumero", AV15TFNotaFiscalNumero);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO_SEL") == 0 )
            {
               AV16TFNotaFiscalNumero_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV16TFNotaFiscalNumero_Sel", AV16TFNotaFiscalNumero_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALPARCELAMENTONUMERO") == 0 )
            {
               AV17TFNotaFiscalParcelamentoNumero = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV17TFNotaFiscalParcelamentoNumero", AV17TFNotaFiscalParcelamentoNumero);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALPARCELAMENTONUMERO_SEL") == 0 )
            {
               AV18TFNotaFiscalParcelamentoNumero_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV18TFNotaFiscalParcelamentoNumero_Sel", AV18TFNotaFiscalParcelamentoNumero_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALPARCELAMENTOVENCIMENTO") == 0 )
            {
               AV21TFNotaFiscalParcelamentoVencimento = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri(sPrefix, false, "AV21TFNotaFiscalParcelamentoVencimento", context.localUtil.Format(AV21TFNotaFiscalParcelamentoVencimento, "99/99/9999"));
               AV22TFNotaFiscalParcelamentoVencimento_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri(sPrefix, false, "AV22TFNotaFiscalParcelamentoVencimento_To", context.localUtil.Format(AV22TFNotaFiscalParcelamentoVencimento_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALPARCELAMENTOVALOR") == 0 )
            {
               AV19TFNotaFiscalParcelamentoValor = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV19TFNotaFiscalParcelamentoValor", StringUtil.LTrimStr( AV19TFNotaFiscalParcelamentoValor, 18, 2));
               AV20TFNotaFiscalParcelamentoValor_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV20TFNotaFiscalParcelamentoValor_To", StringUtil.LTrimStr( AV20TFNotaFiscalParcelamentoValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA") == 0 )
            {
               AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa", StringUtil.LTrimStr( AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa, 18, 2));
               AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To", StringUtil.LTrimStr( AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALPARCELAMENTOVALORTAXAANUAL") == 0 )
            {
               AV32TFNotaFiscalParcelamentoValorTaxaAnual = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV32TFNotaFiscalParcelamentoValorTaxaAnual", StringUtil.LTrimStr( AV32TFNotaFiscalParcelamentoValorTaxaAnual, 18, 2));
               AV33TFNotaFiscalParcelamentoValorTaxaAnual_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV33TFNotaFiscalParcelamentoValorTaxaAnual_To", StringUtil.LTrimStr( AV33TFNotaFiscalParcelamentoValorTaxaAnual_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALPARCELAMENTOLIQUIDO") == 0 )
            {
               AV34TFNotaFiscalParcelamentoLiquido = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV34TFNotaFiscalParcelamentoLiquido", StringUtil.LTrimStr( AV34TFNotaFiscalParcelamentoLiquido, 18, 2));
               AV35TFNotaFiscalParcelamentoLiquido_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV35TFNotaFiscalParcelamentoLiquido_To", StringUtil.LTrimStr( AV35TFNotaFiscalParcelamentoLiquido_To, 18, 2));
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV16TFNotaFiscalNumero_Sel)),  AV16TFNotaFiscalNumero_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV18TFNotaFiscalParcelamentoNumero_Sel)),  AV18TFNotaFiscalParcelamentoNumero_Sel, out  GXt_char3) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char3+"|||||";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV15TFNotaFiscalNumero)),  AV15TFNotaFiscalNumero, out  GXt_char3) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV17TFNotaFiscalParcelamentoNumero)),  AV17TFNotaFiscalParcelamentoNumero, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char3+"|"+GXt_char2+"|"+((DateTime.MinValue==AV21TFNotaFiscalParcelamentoVencimento) ? "" : context.localUtil.DToC( AV21TFNotaFiscalParcelamentoVencimento, 4, "/"))+"|"+((Convert.ToDecimal(0)==AV19TFNotaFiscalParcelamentoValor) ? "" : StringUtil.Str( AV19TFNotaFiscalParcelamentoValor, 18, 2))+"|"+((Convert.ToDecimal(0)==AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa) ? "" : StringUtil.Str( AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa, 18, 2))+"|"+((Convert.ToDecimal(0)==AV32TFNotaFiscalParcelamentoValorTaxaAnual) ? "" : StringUtil.Str( AV32TFNotaFiscalParcelamentoValorTaxaAnual, 18, 2))+"|"+((Convert.ToDecimal(0)==AV34TFNotaFiscalParcelamentoLiquido) ? "" : StringUtil.Str( AV34TFNotaFiscalParcelamentoLiquido, 18, 2));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((DateTime.MinValue==AV22TFNotaFiscalParcelamentoVencimento_To) ? "" : context.localUtil.DToC( AV22TFNotaFiscalParcelamentoVencimento_To, 4, "/"))+"|"+((Convert.ToDecimal(0)==AV20TFNotaFiscalParcelamentoValor_To) ? "" : StringUtil.Str( AV20TFNotaFiscalParcelamentoValor_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To) ? "" : StringUtil.Str( AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV33TFNotaFiscalParcelamentoValorTaxaAnual_To) ? "" : StringUtil.Str( AV33TFNotaFiscalParcelamentoValorTaxaAnual_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV35TFNotaFiscalParcelamentoLiquido_To) ? "" : StringUtil.Str( AV35TFNotaFiscalParcelamentoLiquido_To, 18, 2));
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
         AV10GridState.FromXml(AV14Session.Get(AV50Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV12OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFNOTAFISCALNUMERO",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15TFNotaFiscalNumero)),  0,  AV15TFNotaFiscalNumero,  AV15TFNotaFiscalNumero,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV16TFNotaFiscalNumero_Sel)),  AV16TFNotaFiscalNumero_Sel,  AV16TFNotaFiscalNumero_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFNOTAFISCALPARCELAMENTONUMERO",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV17TFNotaFiscalParcelamentoNumero)),  0,  AV17TFNotaFiscalParcelamentoNumero,  AV17TFNotaFiscalParcelamentoNumero,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV18TFNotaFiscalParcelamentoNumero_Sel)),  AV18TFNotaFiscalParcelamentoNumero_Sel,  AV18TFNotaFiscalParcelamentoNumero_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFNOTAFISCALPARCELAMENTOVENCIMENTO",  "",  !((DateTime.MinValue==AV21TFNotaFiscalParcelamentoVencimento)&&(DateTime.MinValue==AV22TFNotaFiscalParcelamentoVencimento_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV21TFNotaFiscalParcelamentoVencimento, 4, "/")),  ((DateTime.MinValue==AV21TFNotaFiscalParcelamentoVencimento) ? "" : StringUtil.Trim( context.localUtil.Format( AV21TFNotaFiscalParcelamentoVencimento, "99/99/9999"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV22TFNotaFiscalParcelamentoVencimento_To, 4, "/")),  ((DateTime.MinValue==AV22TFNotaFiscalParcelamentoVencimento_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV22TFNotaFiscalParcelamentoVencimento_To, "99/99/9999")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFNOTAFISCALPARCELAMENTOVALOR",  "",  !((Convert.ToDecimal(0)==AV19TFNotaFiscalParcelamentoValor)&&(Convert.ToDecimal(0)==AV20TFNotaFiscalParcelamentoValor_To)),  0,  StringUtil.Trim( StringUtil.Str( AV19TFNotaFiscalParcelamentoValor, 18, 2)),  ((Convert.ToDecimal(0)==AV19TFNotaFiscalParcelamentoValor) ? "" : StringUtil.Trim( context.localUtil.Format( AV19TFNotaFiscalParcelamentoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV20TFNotaFiscalParcelamentoValor_To, 18, 2)),  ((Convert.ToDecimal(0)==AV20TFNotaFiscalParcelamentoValor_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV20TFNotaFiscalParcelamentoValor_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFNOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA",  "",  !((Convert.ToDecimal(0)==AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa)&&(Convert.ToDecimal(0)==AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To)),  0,  StringUtil.Trim( StringUtil.Str( AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa, 18, 2)),  ((Convert.ToDecimal(0)==AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa) ? "" : StringUtil.Trim( context.localUtil.Format( AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To, 18, 2)),  ((Convert.ToDecimal(0)==AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFNOTAFISCALPARCELAMENTOVALORTAXAANUAL",  "",  !((Convert.ToDecimal(0)==AV32TFNotaFiscalParcelamentoValorTaxaAnual)&&(Convert.ToDecimal(0)==AV33TFNotaFiscalParcelamentoValorTaxaAnual_To)),  0,  StringUtil.Trim( StringUtil.Str( AV32TFNotaFiscalParcelamentoValorTaxaAnual, 18, 2)),  ((Convert.ToDecimal(0)==AV32TFNotaFiscalParcelamentoValorTaxaAnual) ? "" : StringUtil.Trim( context.localUtil.Format( AV32TFNotaFiscalParcelamentoValorTaxaAnual, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV33TFNotaFiscalParcelamentoValorTaxaAnual_To, 18, 2)),  ((Convert.ToDecimal(0)==AV33TFNotaFiscalParcelamentoValorTaxaAnual_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV33TFNotaFiscalParcelamentoValorTaxaAnual_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFNOTAFISCALPARCELAMENTOLIQUIDO",  "",  !((Convert.ToDecimal(0)==AV34TFNotaFiscalParcelamentoLiquido)&&(Convert.ToDecimal(0)==AV35TFNotaFiscalParcelamentoLiquido_To)),  0,  StringUtil.Trim( StringUtil.Str( AV34TFNotaFiscalParcelamentoLiquido, 18, 2)),  ((Convert.ToDecimal(0)==AV34TFNotaFiscalParcelamentoLiquido) ? "" : StringUtil.Trim( context.localUtil.Format( AV34TFNotaFiscalParcelamentoLiquido, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV35TFNotaFiscalParcelamentoLiquido_To, 18, 2)),  ((Convert.ToDecimal(0)==AV35TFNotaFiscalParcelamentoLiquido_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV35TFNotaFiscalParcelamentoLiquido_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27JSON)) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&JSON";
            AV11GridStateFilterValue.gxTpr_Value = AV27JSON;
            AV10GridState.gxTpr_Filtervalues.Add(AV11GridStateFilterValue, 0);
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV50Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV50Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "NotaFiscalParcelamento";
         AV14Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV27JSON = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV27JSON", AV27JSON);
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
         PA9E2( ) ;
         WS9E2( ) ;
         WE9E2( ) ;
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
         sCtrlAV27JSON = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA9E2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "notafiscalparcelamentoww", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA9E2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV27JSON = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV27JSON", AV27JSON);
         }
         wcpOAV27JSON = cgiGet( sPrefix+"wcpOAV27JSON");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV27JSON, wcpOAV27JSON) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV27JSON = AV27JSON;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV27JSON = cgiGet( sPrefix+"AV27JSON_CTRL");
         if ( StringUtil.Len( sCtrlAV27JSON) > 0 )
         {
            AV27JSON = cgiGet( sCtrlAV27JSON);
            AssignAttri(sPrefix, false, "AV27JSON", AV27JSON);
         }
         else
         {
            AV27JSON = cgiGet( sPrefix+"AV27JSON_PARM");
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
         PA9E2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS9E2( ) ;
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
         WS9E2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV27JSON_PARM", AV27JSON);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV27JSON)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV27JSON_CTRL", StringUtil.RTrim( sCtrlAV27JSON));
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
         WE9E2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019214467", true, true);
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
         context.AddJavascriptSource("notafiscalparcelamentoww.js", "?202561019214468", false, true);
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
         edtNotaFiscalParcelamentoID_Internalname = sPrefix+"NOTAFISCALPARCELAMENTOID_"+sGXsfl_12_idx;
         edtNotaFiscalId_Internalname = sPrefix+"NOTAFISCALID_"+sGXsfl_12_idx;
         edtNotaFiscalNumero_Internalname = sPrefix+"NOTAFISCALNUMERO_"+sGXsfl_12_idx;
         edtNotaFiscalParcelamentoNumero_Internalname = sPrefix+"NOTAFISCALPARCELAMENTONUMERO_"+sGXsfl_12_idx;
         edtNotaFiscalParcelamentoVencimento_Internalname = sPrefix+"NOTAFISCALPARCELAMENTOVENCIMENTO_"+sGXsfl_12_idx;
         edtNotaFiscalParcelamentoValor_Internalname = sPrefix+"NOTAFISCALPARCELAMENTOVALOR_"+sGXsfl_12_idx;
         edtNotaFiscalParcelamentoValorTaxaAdministrativa_Internalname = sPrefix+"NOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA_"+sGXsfl_12_idx;
         edtNotaFiscalParcelamentoValorTaxaAnual_Internalname = sPrefix+"NOTAFISCALPARCELAMENTOVALORTAXAANUAL_"+sGXsfl_12_idx;
         edtNotaFiscalParcelamentoLiquido_Internalname = sPrefix+"NOTAFISCALPARCELAMENTOLIQUIDO_"+sGXsfl_12_idx;
      }

      protected void SubsflControlProps_fel_122( )
      {
         edtNotaFiscalParcelamentoID_Internalname = sPrefix+"NOTAFISCALPARCELAMENTOID_"+sGXsfl_12_fel_idx;
         edtNotaFiscalId_Internalname = sPrefix+"NOTAFISCALID_"+sGXsfl_12_fel_idx;
         edtNotaFiscalNumero_Internalname = sPrefix+"NOTAFISCALNUMERO_"+sGXsfl_12_fel_idx;
         edtNotaFiscalParcelamentoNumero_Internalname = sPrefix+"NOTAFISCALPARCELAMENTONUMERO_"+sGXsfl_12_fel_idx;
         edtNotaFiscalParcelamentoVencimento_Internalname = sPrefix+"NOTAFISCALPARCELAMENTOVENCIMENTO_"+sGXsfl_12_fel_idx;
         edtNotaFiscalParcelamentoValor_Internalname = sPrefix+"NOTAFISCALPARCELAMENTOVALOR_"+sGXsfl_12_fel_idx;
         edtNotaFiscalParcelamentoValorTaxaAdministrativa_Internalname = sPrefix+"NOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA_"+sGXsfl_12_fel_idx;
         edtNotaFiscalParcelamentoValorTaxaAnual_Internalname = sPrefix+"NOTAFISCALPARCELAMENTOVALORTAXAANUAL_"+sGXsfl_12_fel_idx;
         edtNotaFiscalParcelamentoLiquido_Internalname = sPrefix+"NOTAFISCALPARCELAMENTOLIQUIDO_"+sGXsfl_12_fel_idx;
      }

      protected void sendrow_122( )
      {
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         WB9E0( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalParcelamentoID_Internalname,A890NotaFiscalParcelamentoID.ToString(),A890NotaFiscalParcelamentoID.ToString(),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalParcelamentoID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)12,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalId_Internalname,A794NotaFiscalId.ToString(),A794NotaFiscalId.ToString(),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)12,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalNumero_Internalname,(string)A799NotaFiscalNumero,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalNumero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalParcelamentoNumero_Internalname,(string)A891NotaFiscalParcelamentoNumero,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalParcelamentoNumero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalParcelamentoVencimento_Internalname,context.localUtil.Format(A893NotaFiscalParcelamentoVencimento, "99/99/9999"),context.localUtil.Format( A893NotaFiscalParcelamentoVencimento, "99/99/9999"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalParcelamentoVencimento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalParcelamentoValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A892NotaFiscalParcelamentoValor, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A892NotaFiscalParcelamentoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalParcelamentoValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalParcelamentoValorTaxaAdministrativa_Internalname,StringUtil.LTrim( StringUtil.NToC( A895NotaFiscalParcelamentoValorTaxaAdministrativa, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A895NotaFiscalParcelamentoValorTaxaAdministrativa, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalParcelamentoValorTaxaAdministrativa_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalParcelamentoValorTaxaAnual_Internalname,StringUtil.LTrim( StringUtil.NToC( A896NotaFiscalParcelamentoValorTaxaAnual, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A896NotaFiscalParcelamentoValorTaxaAnual, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalParcelamentoValorTaxaAnual_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalParcelamentoLiquido_Internalname,StringUtil.LTrim( StringUtil.NToC( A897NotaFiscalParcelamentoLiquido, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A897NotaFiscalParcelamentoLiquido, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalParcelamentoLiquido_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes9E2( ) ;
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Parcelamento ID") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Fiscal Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nota") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Número") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Vencimento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Valor") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Taxa Administrativa") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Taxa Anual") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Valor Liquido") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A890NotaFiscalParcelamentoID.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A794NotaFiscalId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A799NotaFiscalNumero));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A891NotaFiscalParcelamentoNumero));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A893NotaFiscalParcelamentoVencimento, "99/99/9999")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A892NotaFiscalParcelamentoValor, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A895NotaFiscalParcelamentoValorTaxaAdministrativa, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A896NotaFiscalParcelamentoValorTaxaAnual, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A897NotaFiscalParcelamentoLiquido, 18, 2, ".", ""))));
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
         edtNotaFiscalParcelamentoID_Internalname = sPrefix+"NOTAFISCALPARCELAMENTOID";
         edtNotaFiscalId_Internalname = sPrefix+"NOTAFISCALID";
         edtNotaFiscalNumero_Internalname = sPrefix+"NOTAFISCALNUMERO";
         edtNotaFiscalParcelamentoNumero_Internalname = sPrefix+"NOTAFISCALPARCELAMENTONUMERO";
         edtNotaFiscalParcelamentoVencimento_Internalname = sPrefix+"NOTAFISCALPARCELAMENTOVENCIMENTO";
         edtNotaFiscalParcelamentoValor_Internalname = sPrefix+"NOTAFISCALPARCELAMENTOVALOR";
         edtNotaFiscalParcelamentoValorTaxaAdministrativa_Internalname = sPrefix+"NOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA";
         edtNotaFiscalParcelamentoValorTaxaAnual_Internalname = sPrefix+"NOTAFISCALPARCELAMENTOVALORTAXAANUAL";
         edtNotaFiscalParcelamentoLiquido_Internalname = sPrefix+"NOTAFISCALPARCELAMENTOLIQUIDO";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         edtavDdo_notafiscalparcelamentovencimentoauxdatetext_Internalname = sPrefix+"vDDO_NOTAFISCALPARCELAMENTOVENCIMENTOAUXDATETEXT";
         Tfnotafiscalparcelamentovencimento_rangepicker_Internalname = sPrefix+"TFNOTAFISCALPARCELAMENTOVENCIMENTO_RANGEPICKER";
         divDdo_notafiscalparcelamentovencimentoauxdates_Internalname = sPrefix+"DDO_NOTAFISCALPARCELAMENTOVENCIMENTOAUXDATES";
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
         edtNotaFiscalParcelamentoLiquido_Jsonclick = "";
         edtNotaFiscalParcelamentoValorTaxaAnual_Jsonclick = "";
         edtNotaFiscalParcelamentoValorTaxaAdministrativa_Jsonclick = "";
         edtNotaFiscalParcelamentoValor_Jsonclick = "";
         edtNotaFiscalParcelamentoVencimento_Jsonclick = "";
         edtNotaFiscalParcelamentoNumero_Jsonclick = "";
         edtNotaFiscalNumero_Jsonclick = "";
         edtNotaFiscalId_Jsonclick = "";
         edtNotaFiscalParcelamentoID_Jsonclick = "";
         subGrid_Class = "GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         edtNotaFiscalParcelamentoLiquido_Enabled = 0;
         edtNotaFiscalParcelamentoValorTaxaAnual_Enabled = 0;
         edtNotaFiscalParcelamentoValorTaxaAdministrativa_Enabled = 0;
         edtNotaFiscalParcelamentoValor_Enabled = 0;
         edtNotaFiscalParcelamentoVencimento_Enabled = 0;
         edtNotaFiscalParcelamentoNumero_Enabled = 0;
         edtNotaFiscalNumero_Enabled = 0;
         edtNotaFiscalId_Enabled = 0;
         edtNotaFiscalParcelamentoID_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_notafiscalparcelamentovencimentoauxdatetext_Jsonclick = "";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "|||18.2|18.2|18.2|18.2";
         Ddo_grid_Datalistproc = "NotaFiscalParcelamentoWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|||||";
         Ddo_grid_Includedatalist = "T|T|||||";
         Ddo_grid_Filterisrange = "||P|T|T|T|T";
         Ddo_grid_Filtertype = "Character|Character|Date|Numeric|Numeric|Numeric|Numeric";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|1|4|5|6|7";
         Ddo_grid_Columnids = "2:NotaFiscalNumero|3:NotaFiscalParcelamentoNumero|4:NotaFiscalParcelamentoVencimento|5:NotaFiscalParcelamentoValor|6:NotaFiscalParcelamentoValorTaxaAdministrativa|7:NotaFiscalParcelamentoValorTaxaAnual|8:NotaFiscalParcelamentoLiquido";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV29array_NotaFiscalId","fld":"vARRAY_NOTAFISCALID","type":""},{"av":"sPrefix","type":"char"},{"av":"AV15TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV16TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV17TFNotaFiscalParcelamentoNumero","fld":"vTFNOTAFISCALPARCELAMENTONUMERO","type":"svchar"},{"av":"AV18TFNotaFiscalParcelamentoNumero_Sel","fld":"vTFNOTAFISCALPARCELAMENTONUMERO_SEL","type":"svchar"},{"av":"AV21TFNotaFiscalParcelamentoVencimento","fld":"vTFNOTAFISCALPARCELAMENTOVENCIMENTO","type":"date"},{"av":"AV22TFNotaFiscalParcelamentoVencimento_To","fld":"vTFNOTAFISCALPARCELAMENTOVENCIMENTO_TO","type":"date"},{"av":"AV19TFNotaFiscalParcelamentoValor","fld":"vTFNOTAFISCALPARCELAMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV20TFNotaFiscalParcelamentoValor_To","fld":"vTFNOTAFISCALPARCELAMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV32TFNotaFiscalParcelamentoValorTaxaAnual","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAANUAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV33TFNotaFiscalParcelamentoValorTaxaAnual_To","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAANUAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV34TFNotaFiscalParcelamentoLiquido","fld":"vTFNOTAFISCALPARCELAMENTOLIQUIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV35TFNotaFiscalParcelamentoLiquido_To","fld":"vTFNOTAFISCALPARCELAMENTOLIQUIDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV27JSON","fld":"vJSON","type":"vchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV50Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E119E2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV29array_NotaFiscalId","fld":"vARRAY_NOTAFISCALID","type":""},{"av":"AV15TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV16TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV17TFNotaFiscalParcelamentoNumero","fld":"vTFNOTAFISCALPARCELAMENTONUMERO","type":"svchar"},{"av":"AV18TFNotaFiscalParcelamentoNumero_Sel","fld":"vTFNOTAFISCALPARCELAMENTONUMERO_SEL","type":"svchar"},{"av":"AV21TFNotaFiscalParcelamentoVencimento","fld":"vTFNOTAFISCALPARCELAMENTOVENCIMENTO","type":"date"},{"av":"AV22TFNotaFiscalParcelamentoVencimento_To","fld":"vTFNOTAFISCALPARCELAMENTOVENCIMENTO_TO","type":"date"},{"av":"AV19TFNotaFiscalParcelamentoValor","fld":"vTFNOTAFISCALPARCELAMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV20TFNotaFiscalParcelamentoValor_To","fld":"vTFNOTAFISCALPARCELAMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV32TFNotaFiscalParcelamentoValorTaxaAnual","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAANUAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV33TFNotaFiscalParcelamentoValorTaxaAnual_To","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAANUAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV34TFNotaFiscalParcelamentoLiquido","fld":"vTFNOTAFISCALPARCELAMENTOLIQUIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV35TFNotaFiscalParcelamentoLiquido_To","fld":"vTFNOTAFISCALPARCELAMENTOLIQUIDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV50Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV27JSON","fld":"vJSON","type":"vchar"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV34TFNotaFiscalParcelamentoLiquido","fld":"vTFNOTAFISCALPARCELAMENTOLIQUIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV35TFNotaFiscalParcelamentoLiquido_To","fld":"vTFNOTAFISCALPARCELAMENTOLIQUIDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV32TFNotaFiscalParcelamentoValorTaxaAnual","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAANUAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV33TFNotaFiscalParcelamentoValorTaxaAnual_To","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAANUAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19TFNotaFiscalParcelamentoValor","fld":"vTFNOTAFISCALPARCELAMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV20TFNotaFiscalParcelamentoValor_To","fld":"vTFNOTAFISCALPARCELAMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV21TFNotaFiscalParcelamentoVencimento","fld":"vTFNOTAFISCALPARCELAMENTOVENCIMENTO","type":"date"},{"av":"AV22TFNotaFiscalParcelamentoVencimento_To","fld":"vTFNOTAFISCALPARCELAMENTOVENCIMENTO_TO","type":"date"},{"av":"AV17TFNotaFiscalParcelamentoNumero","fld":"vTFNOTAFISCALPARCELAMENTONUMERO","type":"svchar"},{"av":"AV18TFNotaFiscalParcelamentoNumero_Sel","fld":"vTFNOTAFISCALPARCELAMENTONUMERO_SEL","type":"svchar"},{"av":"AV15TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV16TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E149E2","iparms":[]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV29array_NotaFiscalId","fld":"vARRAY_NOTAFISCALID","type":""},{"av":"sPrefix","type":"char"},{"av":"AV15TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV16TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV17TFNotaFiscalParcelamentoNumero","fld":"vTFNOTAFISCALPARCELAMENTONUMERO","type":"svchar"},{"av":"AV18TFNotaFiscalParcelamentoNumero_Sel","fld":"vTFNOTAFISCALPARCELAMENTONUMERO_SEL","type":"svchar"},{"av":"AV21TFNotaFiscalParcelamentoVencimento","fld":"vTFNOTAFISCALPARCELAMENTOVENCIMENTO","type":"date"},{"av":"AV22TFNotaFiscalParcelamentoVencimento_To","fld":"vTFNOTAFISCALPARCELAMENTOVENCIMENTO_TO","type":"date"},{"av":"AV19TFNotaFiscalParcelamentoValor","fld":"vTFNOTAFISCALPARCELAMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV20TFNotaFiscalParcelamentoValor_To","fld":"vTFNOTAFISCALPARCELAMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV32TFNotaFiscalParcelamentoValorTaxaAnual","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAANUAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV33TFNotaFiscalParcelamentoValorTaxaAnual_To","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAANUAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV34TFNotaFiscalParcelamentoLiquido","fld":"vTFNOTAFISCALPARCELAMENTOLIQUIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV35TFNotaFiscalParcelamentoLiquido_To","fld":"vTFNOTAFISCALPARCELAMENTOLIQUIDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV50Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV27JSON","fld":"vJSON","type":"vchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV29array_NotaFiscalId","fld":"vARRAY_NOTAFISCALID","type":""},{"av":"sPrefix","type":"char"},{"av":"AV15TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV16TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV17TFNotaFiscalParcelamentoNumero","fld":"vTFNOTAFISCALPARCELAMENTONUMERO","type":"svchar"},{"av":"AV18TFNotaFiscalParcelamentoNumero_Sel","fld":"vTFNOTAFISCALPARCELAMENTONUMERO_SEL","type":"svchar"},{"av":"AV21TFNotaFiscalParcelamentoVencimento","fld":"vTFNOTAFISCALPARCELAMENTOVENCIMENTO","type":"date"},{"av":"AV22TFNotaFiscalParcelamentoVencimento_To","fld":"vTFNOTAFISCALPARCELAMENTOVENCIMENTO_TO","type":"date"},{"av":"AV19TFNotaFiscalParcelamentoValor","fld":"vTFNOTAFISCALPARCELAMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV20TFNotaFiscalParcelamentoValor_To","fld":"vTFNOTAFISCALPARCELAMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV32TFNotaFiscalParcelamentoValorTaxaAnual","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAANUAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV33TFNotaFiscalParcelamentoValorTaxaAnual_To","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAANUAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV34TFNotaFiscalParcelamentoLiquido","fld":"vTFNOTAFISCALPARCELAMENTOLIQUIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV35TFNotaFiscalParcelamentoLiquido_To","fld":"vTFNOTAFISCALPARCELAMENTOLIQUIDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV50Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV27JSON","fld":"vJSON","type":"vchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV29array_NotaFiscalId","fld":"vARRAY_NOTAFISCALID","type":""},{"av":"sPrefix","type":"char"},{"av":"AV15TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV16TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV17TFNotaFiscalParcelamentoNumero","fld":"vTFNOTAFISCALPARCELAMENTONUMERO","type":"svchar"},{"av":"AV18TFNotaFiscalParcelamentoNumero_Sel","fld":"vTFNOTAFISCALPARCELAMENTONUMERO_SEL","type":"svchar"},{"av":"AV21TFNotaFiscalParcelamentoVencimento","fld":"vTFNOTAFISCALPARCELAMENTOVENCIMENTO","type":"date"},{"av":"AV22TFNotaFiscalParcelamentoVencimento_To","fld":"vTFNOTAFISCALPARCELAMENTOVENCIMENTO_TO","type":"date"},{"av":"AV19TFNotaFiscalParcelamentoValor","fld":"vTFNOTAFISCALPARCELAMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV20TFNotaFiscalParcelamentoValor_To","fld":"vTFNOTAFISCALPARCELAMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV32TFNotaFiscalParcelamentoValorTaxaAnual","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAANUAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV33TFNotaFiscalParcelamentoValorTaxaAnual_To","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAANUAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV34TFNotaFiscalParcelamentoLiquido","fld":"vTFNOTAFISCALPARCELAMENTOLIQUIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV35TFNotaFiscalParcelamentoLiquido_To","fld":"vTFNOTAFISCALPARCELAMENTOLIQUIDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV50Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV27JSON","fld":"vJSON","type":"vchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV29array_NotaFiscalId","fld":"vARRAY_NOTAFISCALID","type":""},{"av":"sPrefix","type":"char"},{"av":"AV15TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV16TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV17TFNotaFiscalParcelamentoNumero","fld":"vTFNOTAFISCALPARCELAMENTONUMERO","type":"svchar"},{"av":"AV18TFNotaFiscalParcelamentoNumero_Sel","fld":"vTFNOTAFISCALPARCELAMENTONUMERO_SEL","type":"svchar"},{"av":"AV21TFNotaFiscalParcelamentoVencimento","fld":"vTFNOTAFISCALPARCELAMENTOVENCIMENTO","type":"date"},{"av":"AV22TFNotaFiscalParcelamentoVencimento_To","fld":"vTFNOTAFISCALPARCELAMENTOVENCIMENTO_TO","type":"date"},{"av":"AV19TFNotaFiscalParcelamentoValor","fld":"vTFNOTAFISCALPARCELAMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV20TFNotaFiscalParcelamentoValor_To","fld":"vTFNOTAFISCALPARCELAMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV32TFNotaFiscalParcelamentoValorTaxaAnual","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAANUAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV33TFNotaFiscalParcelamentoValorTaxaAnual_To","fld":"vTFNOTAFISCALPARCELAMENTOVALORTAXAANUAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV34TFNotaFiscalParcelamentoLiquido","fld":"vTFNOTAFISCALPARCELAMENTOLIQUIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV35TFNotaFiscalParcelamentoLiquido_To","fld":"vTFNOTAFISCALPARCELAMENTOLIQUIDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV50Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV27JSON","fld":"vJSON","type":"vchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("VALID_NOTAFISCALID","""{"handler":"Valid_Notafiscalid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Notafiscalparcelamentoliquido","iparms":[]}""");
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
         wcpOAV27JSON = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV29array_NotaFiscalId = new GxSimpleCollection<Guid>();
         AV15TFNotaFiscalNumero = "";
         AV16TFNotaFiscalNumero_Sel = "";
         AV17TFNotaFiscalParcelamentoNumero = "";
         AV18TFNotaFiscalParcelamentoNumero_Sel = "";
         AV21TFNotaFiscalParcelamentoVencimento = DateTime.MinValue;
         AV22TFNotaFiscalParcelamentoVencimento_To = DateTime.MinValue;
         AV50Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV26DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV23DDO_NotaFiscalParcelamentoVencimentoAuxDate = DateTime.MinValue;
         AV24DDO_NotaFiscalParcelamentoVencimentoAuxDateTo = DateTime.MinValue;
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
         AV25DDO_NotaFiscalParcelamentoVencimentoAuxDateText = "";
         ucTfnotafiscalparcelamentovencimento_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero = "";
         AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel = "";
         AV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero = "";
         AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel = "";
         AV40Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento = DateTime.MinValue;
         AV41Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to = DateTime.MinValue;
         A890NotaFiscalParcelamentoID = Guid.Empty;
         A794NotaFiscalId = Guid.Empty;
         A799NotaFiscalNumero = "";
         A891NotaFiscalParcelamentoNumero = "";
         A893NotaFiscalParcelamentoVencimento = DateTime.MinValue;
         GXDecQS = "";
         lV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero = "";
         lV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero = "";
         H009E2_A897NotaFiscalParcelamentoLiquido = new decimal[1] ;
         H009E2_n897NotaFiscalParcelamentoLiquido = new bool[] {false} ;
         H009E2_A896NotaFiscalParcelamentoValorTaxaAnual = new decimal[1] ;
         H009E2_n896NotaFiscalParcelamentoValorTaxaAnual = new bool[] {false} ;
         H009E2_A895NotaFiscalParcelamentoValorTaxaAdministrativa = new decimal[1] ;
         H009E2_n895NotaFiscalParcelamentoValorTaxaAdministrativa = new bool[] {false} ;
         H009E2_A892NotaFiscalParcelamentoValor = new decimal[1] ;
         H009E2_n892NotaFiscalParcelamentoValor = new bool[] {false} ;
         H009E2_A893NotaFiscalParcelamentoVencimento = new DateTime[] {DateTime.MinValue} ;
         H009E2_n893NotaFiscalParcelamentoVencimento = new bool[] {false} ;
         H009E2_A891NotaFiscalParcelamentoNumero = new string[] {""} ;
         H009E2_n891NotaFiscalParcelamentoNumero = new bool[] {false} ;
         H009E2_A799NotaFiscalNumero = new string[] {""} ;
         H009E2_n799NotaFiscalNumero = new bool[] {false} ;
         H009E2_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         H009E2_n794NotaFiscalId = new bool[] {false} ;
         H009E2_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         H009E3_AGRID_nRecordCount = new long[1] ;
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
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV27JSON = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.notafiscalparcelamentoww__default(),
            new Object[][] {
                new Object[] {
               H009E2_A897NotaFiscalParcelamentoLiquido, H009E2_n897NotaFiscalParcelamentoLiquido, H009E2_A896NotaFiscalParcelamentoValorTaxaAnual, H009E2_n896NotaFiscalParcelamentoValorTaxaAnual, H009E2_A895NotaFiscalParcelamentoValorTaxaAdministrativa, H009E2_n895NotaFiscalParcelamentoValorTaxaAdministrativa, H009E2_A892NotaFiscalParcelamentoValor, H009E2_n892NotaFiscalParcelamentoValor, H009E2_A893NotaFiscalParcelamentoVencimento, H009E2_n893NotaFiscalParcelamentoVencimento,
               H009E2_A891NotaFiscalParcelamentoNumero, H009E2_n891NotaFiscalParcelamentoNumero, H009E2_A799NotaFiscalNumero, H009E2_n799NotaFiscalNumero, H009E2_A794NotaFiscalId, H009E2_n794NotaFiscalId, H009E2_A890NotaFiscalParcelamentoID
               }
               , new Object[] {
               H009E3_AGRID_nRecordCount
               }
            }
         );
         AV50Pgmname = "NotaFiscalParcelamentoWW";
         /* GeneXus formulas. */
         AV50Pgmname = "NotaFiscalParcelamentoWW";
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
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int nRC_GXsfl_12 ;
      private int nGXsfl_12_idx=1 ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtNotaFiscalParcelamentoID_Enabled ;
      private int edtNotaFiscalId_Enabled ;
      private int edtNotaFiscalNumero_Enabled ;
      private int edtNotaFiscalParcelamentoNumero_Enabled ;
      private int edtNotaFiscalParcelamentoVencimento_Enabled ;
      private int edtNotaFiscalParcelamentoValor_Enabled ;
      private int edtNotaFiscalParcelamentoValorTaxaAdministrativa_Enabled ;
      private int edtNotaFiscalParcelamentoValorTaxaAnual_Enabled ;
      private int edtNotaFiscalParcelamentoLiquido_Enabled ;
      private int AV51GXV1 ;
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
      private decimal AV19TFNotaFiscalParcelamentoValor ;
      private decimal AV20TFNotaFiscalParcelamentoValor_To ;
      private decimal AV30TFNotaFiscalParcelamentoValorTaxaAdministrativa ;
      private decimal AV31TFNotaFiscalParcelamentoValorTaxaAdministrativa_To ;
      private decimal AV32TFNotaFiscalParcelamentoValorTaxaAnual ;
      private decimal AV33TFNotaFiscalParcelamentoValorTaxaAnual_To ;
      private decimal AV34TFNotaFiscalParcelamentoLiquido ;
      private decimal AV35TFNotaFiscalParcelamentoLiquido_To ;
      private decimal AV42Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor ;
      private decimal AV43Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to ;
      private decimal AV44Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa ;
      private decimal AV45Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to ;
      private decimal AV46Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual ;
      private decimal AV47Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to ;
      private decimal AV48Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido ;
      private decimal AV49Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to ;
      private decimal A892NotaFiscalParcelamentoValor ;
      private decimal A895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private decimal A896NotaFiscalParcelamentoValorTaxaAnual ;
      private decimal A897NotaFiscalParcelamentoLiquido ;
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
      private string AV50Pgmname ;
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
      private string divDdo_notafiscalparcelamentovencimentoauxdates_Internalname ;
      private string TempTags ;
      private string edtavDdo_notafiscalparcelamentovencimentoauxdatetext_Internalname ;
      private string edtavDdo_notafiscalparcelamentovencimentoauxdatetext_Jsonclick ;
      private string Tfnotafiscalparcelamentovencimento_rangepicker_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtNotaFiscalParcelamentoID_Internalname ;
      private string edtNotaFiscalId_Internalname ;
      private string edtNotaFiscalNumero_Internalname ;
      private string edtNotaFiscalParcelamentoNumero_Internalname ;
      private string edtNotaFiscalParcelamentoVencimento_Internalname ;
      private string edtNotaFiscalParcelamentoValor_Internalname ;
      private string edtNotaFiscalParcelamentoValorTaxaAdministrativa_Internalname ;
      private string edtNotaFiscalParcelamentoValorTaxaAnual_Internalname ;
      private string edtNotaFiscalParcelamentoLiquido_Internalname ;
      private string GXDecQS ;
      private string GXt_char3 ;
      private string GXt_char2 ;
      private string sCtrlAV27JSON ;
      private string sGXsfl_12_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtNotaFiscalParcelamentoID_Jsonclick ;
      private string edtNotaFiscalId_Jsonclick ;
      private string edtNotaFiscalNumero_Jsonclick ;
      private string edtNotaFiscalParcelamentoNumero_Jsonclick ;
      private string edtNotaFiscalParcelamentoVencimento_Jsonclick ;
      private string edtNotaFiscalParcelamentoValor_Jsonclick ;
      private string edtNotaFiscalParcelamentoValorTaxaAdministrativa_Jsonclick ;
      private string edtNotaFiscalParcelamentoValorTaxaAnual_Jsonclick ;
      private string edtNotaFiscalParcelamentoLiquido_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV21TFNotaFiscalParcelamentoVencimento ;
      private DateTime AV22TFNotaFiscalParcelamentoVencimento_To ;
      private DateTime AV23DDO_NotaFiscalParcelamentoVencimentoAuxDate ;
      private DateTime AV24DDO_NotaFiscalParcelamentoVencimentoAuxDateTo ;
      private DateTime AV40Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento ;
      private DateTime AV41Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to ;
      private DateTime A893NotaFiscalParcelamentoVencimento ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n794NotaFiscalId ;
      private bool n799NotaFiscalNumero ;
      private bool n891NotaFiscalParcelamentoNumero ;
      private bool n893NotaFiscalParcelamentoVencimento ;
      private bool n892NotaFiscalParcelamentoValor ;
      private bool n895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private bool n896NotaFiscalParcelamentoValorTaxaAnual ;
      private bool n897NotaFiscalParcelamentoLiquido ;
      private bool bGXsfl_12_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV27JSON ;
      private string wcpOAV27JSON ;
      private string AV15TFNotaFiscalNumero ;
      private string AV16TFNotaFiscalNumero_Sel ;
      private string AV17TFNotaFiscalParcelamentoNumero ;
      private string AV18TFNotaFiscalParcelamentoNumero_Sel ;
      private string AV25DDO_NotaFiscalParcelamentoVencimentoAuxDateText ;
      private string AV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero ;
      private string AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel ;
      private string AV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero ;
      private string AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel ;
      private string A799NotaFiscalNumero ;
      private string A891NotaFiscalParcelamentoNumero ;
      private string lV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero ;
      private string lV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero ;
      private Guid A890NotaFiscalParcelamentoID ;
      private Guid A794NotaFiscalId ;
      private IGxSession AV14Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfnotafiscalparcelamentovencimento_rangepicker ;
      private GXWebForm Form ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<Guid> AV29array_NotaFiscalId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV26DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private decimal[] H009E2_A897NotaFiscalParcelamentoLiquido ;
      private bool[] H009E2_n897NotaFiscalParcelamentoLiquido ;
      private decimal[] H009E2_A896NotaFiscalParcelamentoValorTaxaAnual ;
      private bool[] H009E2_n896NotaFiscalParcelamentoValorTaxaAnual ;
      private decimal[] H009E2_A895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private bool[] H009E2_n895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private decimal[] H009E2_A892NotaFiscalParcelamentoValor ;
      private bool[] H009E2_n892NotaFiscalParcelamentoValor ;
      private DateTime[] H009E2_A893NotaFiscalParcelamentoVencimento ;
      private bool[] H009E2_n893NotaFiscalParcelamentoVencimento ;
      private string[] H009E2_A891NotaFiscalParcelamentoNumero ;
      private bool[] H009E2_n891NotaFiscalParcelamentoNumero ;
      private string[] H009E2_A799NotaFiscalNumero ;
      private bool[] H009E2_n799NotaFiscalNumero ;
      private Guid[] H009E2_A794NotaFiscalId ;
      private bool[] H009E2_n794NotaFiscalId ;
      private Guid[] H009E2_A890NotaFiscalParcelamentoID ;
      private long[] H009E3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class notafiscalparcelamentoww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009E2( IGxContext context ,
                                             Guid A794NotaFiscalId ,
                                             GxSimpleCollection<Guid> AV29array_NotaFiscalId ,
                                             string AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel ,
                                             string AV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero ,
                                             string AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel ,
                                             string AV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero ,
                                             DateTime AV40Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento ,
                                             DateTime AV41Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to ,
                                             decimal AV42Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor ,
                                             decimal AV43Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to ,
                                             decimal AV44Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa ,
                                             decimal AV45Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to ,
                                             decimal AV46Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual ,
                                             decimal AV47Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to ,
                                             decimal AV48Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido ,
                                             decimal AV49Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to ,
                                             string A799NotaFiscalNumero ,
                                             string A891NotaFiscalParcelamentoNumero ,
                                             DateTime A893NotaFiscalParcelamentoVencimento ,
                                             decimal A892NotaFiscalParcelamentoValor ,
                                             decimal A895NotaFiscalParcelamentoValorTaxaAdministrativa ,
                                             decimal A896NotaFiscalParcelamentoValorTaxaAnual ,
                                             decimal A897NotaFiscalParcelamentoLiquido ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[17];
         Object[] GXv_Object5 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.NotaFiscalParcelamentoLiquido, T1.NotaFiscalParcelamentoValorTaxaAnual, T1.NotaFiscalParcelamentoValorTaxaAdministrativa, T1.NotaFiscalParcelamentoValor, T1.NotaFiscalParcelamentoVencimento, T1.NotaFiscalParcelamentoNumero, T2.NotaFiscalNumero, T1.NotaFiscalId, T1.NotaFiscalParcelamentoID";
         sFromString = " FROM (NotaFiscalParcelamento T1 LEFT JOIN NotaFiscal T2 ON T2.NotaFiscalId = T1.NotaFiscalId)";
         sOrderString = "";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV29array_NotaFiscalId, "T1.NotaFiscalId IN (", ")")+")");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(T2.NotaFiscalNumero like :lV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.NotaFiscalNumero = ( :AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( StringUtil.StrCmp(AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T2.NotaFiscalNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoNumero like :lV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel)) && ! ( StringUtil.StrCmp(AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoNumero = ( :AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( StringUtil.StrCmp(AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoNumero IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalParcelamentoNumero))=0))");
         }
         if ( ! (DateTime.MinValue==AV40Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoVencimento >= :AV40Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencim)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV41Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoVencimento <= :AV41Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencim)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV42Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoValor >= :AV42Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV43Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoValor <= :AV43Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV44Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoValorTaxaAdministrativa >= :AV44Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalort)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV45Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoValorTaxaAdministrativa <= :AV45Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalor)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV46Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoValorTaxaAnual >= :AV46Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalor)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV47Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoValorTaxaAnual <= :AV47Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalor)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV48Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoLiquido >= :AV48Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliqui)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV49Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoLiquido <= :AV49Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliqui)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NotaFiscalParcelamentoVencimento, T1.NotaFiscalParcelamentoID";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NotaFiscalParcelamentoVencimento DESC, T1.NotaFiscalParcelamentoID";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T2.NotaFiscalNumero, T1.NotaFiscalParcelamentoID";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.NotaFiscalNumero DESC, T1.NotaFiscalParcelamentoID";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NotaFiscalParcelamentoNumero, T1.NotaFiscalParcelamentoID";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NotaFiscalParcelamentoNumero DESC, T1.NotaFiscalParcelamentoID";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NotaFiscalParcelamentoValor, T1.NotaFiscalParcelamentoID";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NotaFiscalParcelamentoValor DESC, T1.NotaFiscalParcelamentoID";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NotaFiscalParcelamentoValorTaxaAdministrativa, T1.NotaFiscalParcelamentoID";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NotaFiscalParcelamentoValorTaxaAdministrativa DESC, T1.NotaFiscalParcelamentoID";
         }
         else if ( ( AV12OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NotaFiscalParcelamentoValorTaxaAnual, T1.NotaFiscalParcelamentoID";
         }
         else if ( ( AV12OrderedBy == 6 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NotaFiscalParcelamentoValorTaxaAnual DESC, T1.NotaFiscalParcelamentoID";
         }
         else if ( ( AV12OrderedBy == 7 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NotaFiscalParcelamentoLiquido, T1.NotaFiscalParcelamentoID";
         }
         else if ( ( AV12OrderedBy == 7 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NotaFiscalParcelamentoLiquido DESC, T1.NotaFiscalParcelamentoID";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.NotaFiscalParcelamentoID";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_H009E3( IGxContext context ,
                                             Guid A794NotaFiscalId ,
                                             GxSimpleCollection<Guid> AV29array_NotaFiscalId ,
                                             string AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel ,
                                             string AV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero ,
                                             string AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel ,
                                             string AV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero ,
                                             DateTime AV40Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento ,
                                             DateTime AV41Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to ,
                                             decimal AV42Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor ,
                                             decimal AV43Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to ,
                                             decimal AV44Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa ,
                                             decimal AV45Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to ,
                                             decimal AV46Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual ,
                                             decimal AV47Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to ,
                                             decimal AV48Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido ,
                                             decimal AV49Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to ,
                                             string A799NotaFiscalNumero ,
                                             string A891NotaFiscalParcelamentoNumero ,
                                             DateTime A893NotaFiscalParcelamentoVencimento ,
                                             decimal A892NotaFiscalParcelamentoValor ,
                                             decimal A895NotaFiscalParcelamentoValorTaxaAdministrativa ,
                                             decimal A896NotaFiscalParcelamentoValorTaxaAnual ,
                                             decimal A897NotaFiscalParcelamentoLiquido ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[14];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (NotaFiscalParcelamento T1 LEFT JOIN NotaFiscal T2 ON T2.NotaFiscalId = T1.NotaFiscalId)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV29array_NotaFiscalId, "T1.NotaFiscalId IN (", ")")+")");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(T2.NotaFiscalNumero like :lV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.NotaFiscalNumero = ( :AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( StringUtil.StrCmp(AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T2.NotaFiscalNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoNumero like :lV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel)) && ! ( StringUtil.StrCmp(AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoNumero = ( :AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero))");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( StringUtil.StrCmp(AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoNumero IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalParcelamentoNumero))=0))");
         }
         if ( ! (DateTime.MinValue==AV40Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoVencimento >= :AV40Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencim)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV41Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoVencimento <= :AV41Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencim)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV42Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoValor >= :AV42Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV43Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoValor <= :AV43Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV44Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoValorTaxaAdministrativa >= :AV44Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalort)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV45Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoValorTaxaAdministrativa <= :AV45Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalor)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV46Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoValorTaxaAnual >= :AV46Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalor)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV47Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoValorTaxaAnual <= :AV47Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalor)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV48Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoLiquido >= :AV48Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliqui)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV49Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoLiquido <= :AV49Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliqui)");
         }
         else
         {
            GXv_int6[13] = 1;
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
                     return conditional_H009E2(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (DateTime)dynConstraints[18] , (decimal)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
               case 1 :
                     return conditional_H009E3(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (DateTime)dynConstraints[18] , (decimal)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmH009E2;
          prmH009E2 = new Object[] {
          new ParDef("lV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel",GXType.VarChar,40,0) ,
          new ParDef("lV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero",GXType.VarChar,100,0) ,
          new ParDef("AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero",GXType.VarChar,100,0) ,
          new ParDef("AV40Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencim",GXType.Date,8,0) ,
          new ParDef("AV41Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencim",GXType.Date,8,0) ,
          new ParDef("AV42Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor",GXType.Number,18,2) ,
          new ParDef("AV43Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_",GXType.Number,18,2) ,
          new ParDef("AV44Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalort",GXType.Number,18,2) ,
          new ParDef("AV45Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalor",GXType.Number,18,2) ,
          new ParDef("AV46Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalor",GXType.Number,18,2) ,
          new ParDef("AV47Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalor",GXType.Number,18,2) ,
          new ParDef("AV48Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliqui",GXType.Number,18,2) ,
          new ParDef("AV49Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliqui",GXType.Number,18,2) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH009E3;
          prmH009E3 = new Object[] {
          new ParDef("lV36Notafiscalparcelamentowwds_1_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV37Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel",GXType.VarChar,40,0) ,
          new ParDef("lV38Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero",GXType.VarChar,100,0) ,
          new ParDef("AV39Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero",GXType.VarChar,100,0) ,
          new ParDef("AV40Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencim",GXType.Date,8,0) ,
          new ParDef("AV41Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencim",GXType.Date,8,0) ,
          new ParDef("AV42Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor",GXType.Number,18,2) ,
          new ParDef("AV43Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_",GXType.Number,18,2) ,
          new ParDef("AV44Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalort",GXType.Number,18,2) ,
          new ParDef("AV45Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalor",GXType.Number,18,2) ,
          new ParDef("AV46Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalor",GXType.Number,18,2) ,
          new ParDef("AV47Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalor",GXType.Number,18,2) ,
          new ParDef("AV48Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliqui",GXType.Number,18,2) ,
          new ParDef("AV49Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliqui",GXType.Number,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("H009E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009E2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H009E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009E3,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((Guid[]) buf[14])[0] = rslt.getGuid(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((Guid[]) buf[16])[0] = rslt.getGuid(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
