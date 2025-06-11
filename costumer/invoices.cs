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
namespace GeneXus.Programs.costumer {
   public class invoices : GXDataArea
   {
      public invoices( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public invoices( IGxContext context )
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
         cmbavNotafiscaluf1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavNotafiscaluf2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavNotafiscaluf3 = new GXCombobox();
         cmbNotaFiscalStatus = new GXCombobox();
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
         nRC_GXsfl_98 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_98"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_98_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_98_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_98_idx = GetPar( "sGXsfl_98_idx");
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
         cmbavNotafiscaluf1.FromJSonString( GetNextPar( ));
         AV17NotaFiscalUF1 = (short)(Math.Round(NumberUtil.Val( GetPar( "NotaFiscalUF1"), "."), 18, MidpointRounding.ToEven));
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV19DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavNotafiscaluf2.FromJSonString( GetNextPar( ));
         AV20NotaFiscalUF2 = (short)(Math.Round(NumberUtil.Val( GetPar( "NotaFiscalUF2"), "."), 18, MidpointRounding.ToEven));
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavNotafiscaluf3.FromJSonString( GetNextPar( ));
         AV23NotaFiscalUF3 = (short)(Math.Round(NumberUtil.Val( GetPar( "NotaFiscalUF3"), "."), 18, MidpointRounding.ToEven));
         AV31ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV51Pgmname = GetPar( "Pgmname");
         AV32TFNotaFiscalNumero = GetPar( "TFNotaFiscalNumero");
         AV33TFNotaFiscalNumero_Sel = GetPar( "TFNotaFiscalNumero_Sel");
         AV34TFNotaFiscalQuantidadeResumo_F = GetPar( "TFNotaFiscalQuantidadeResumo_F");
         AV35TFNotaFiscalQuantidadeResumo_F_Sel = GetPar( "TFNotaFiscalQuantidadeResumo_F_Sel");
         AV36TFNotaFiscalValorFormatado_F = GetPar( "TFNotaFiscalValorFormatado_F");
         AV37TFNotaFiscalValorFormatado_F_Sel = GetPar( "TFNotaFiscalValorFormatado_F_Sel");
         AV38TFNotaFiscalValorVendidoFormatado_F = GetPar( "TFNotaFiscalValorVendidoFormatado_F");
         AV39TFNotaFiscalValorVendidoFormatado_F_Sel = GetPar( "TFNotaFiscalValorVendidoFormatado_F_Sel");
         AV40TFNotaFiscalSaldoFormatado_F = GetPar( "TFNotaFiscalSaldoFormatado_F");
         AV41TFNotaFiscalSaldoFormatado_F_Sel = GetPar( "TFNotaFiscalSaldoFormatado_F_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV43TFNotaFiscalStatus_Sels);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV25DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV24DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV18DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV21DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17NotaFiscalUF1, AV19DynamicFiltersSelector2, AV20NotaFiscalUF2, AV22DynamicFiltersSelector3, AV23NotaFiscalUF3, AV31ManageFiltersExecutionStep, AV51Pgmname, AV32TFNotaFiscalNumero, AV33TFNotaFiscalNumero_Sel, AV34TFNotaFiscalQuantidadeResumo_F, AV35TFNotaFiscalQuantidadeResumo_F_Sel, AV36TFNotaFiscalValorFormatado_F, AV37TFNotaFiscalValorFormatado_F_Sel, AV38TFNotaFiscalValorVendidoFormatado_F, AV39TFNotaFiscalValorVendidoFormatado_F_Sel, AV40TFNotaFiscalSaldoFormatado_F, AV41TFNotaFiscalSaldoFormatado_F_Sel, AV43TFNotaFiscalStatus_Sels, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3) ;
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.masterpagepfpj", "GeneXus.Programs.wwpbaseobjects.masterpagepfpj", new Object[] {context});
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
         PA8V2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START8V2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("costumer.invoices") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV51Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV51Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV15FilterFullText);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV16DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vNOTAFISCALUF1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17NotaFiscalUF1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV19DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vNOTAFISCALUF2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20NotaFiscalUF2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV22DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vNOTAFISCALUF3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23NotaFiscalUF3), 4, 0, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_98", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_98), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV29ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV29ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV48GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV44DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV44DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV51Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV51Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vTFNOTAFISCALNUMERO", AV32TFNotaFiscalNumero);
         GxWebStd.gx_hidden_field( context, "vTFNOTAFISCALNUMERO_SEL", AV33TFNotaFiscalNumero_Sel);
         GxWebStd.gx_hidden_field( context, "vTFNOTAFISCALQUANTIDADERESUMO_F", AV34TFNotaFiscalQuantidadeResumo_F);
         GxWebStd.gx_hidden_field( context, "vTFNOTAFISCALQUANTIDADERESUMO_F_SEL", AV35TFNotaFiscalQuantidadeResumo_F_Sel);
         GxWebStd.gx_hidden_field( context, "vTFNOTAFISCALVALORFORMATADO_F", AV36TFNotaFiscalValorFormatado_F);
         GxWebStd.gx_hidden_field( context, "vTFNOTAFISCALVALORFORMATADO_F_SEL", AV37TFNotaFiscalValorFormatado_F_Sel);
         GxWebStd.gx_hidden_field( context, "vTFNOTAFISCALVALORVENDIDOFORMATADO_F", AV38TFNotaFiscalValorVendidoFormatado_F);
         GxWebStd.gx_hidden_field( context, "vTFNOTAFISCALVALORVENDIDOFORMATADO_F_SEL", AV39TFNotaFiscalValorVendidoFormatado_F_Sel);
         GxWebStd.gx_hidden_field( context, "vTFNOTAFISCALSALDOFORMATADO_F", AV40TFNotaFiscalSaldoFormatado_F);
         GxWebStd.gx_hidden_field( context, "vTFNOTAFISCALSALDOFORMATADO_F_SEL", AV41TFNotaFiscalSaldoFormatado_F_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFNOTAFISCALSTATUS_SELS", AV43TFNotaFiscalStatus_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFNOTAFISCALSTATUS_SELS", AV43TFNotaFiscalStatus_Sels);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV25DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV24DynamicFiltersRemoving);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV18DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV21DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFNOTAFISCALSTATUS_SELSJSON", AV42TFNotaFiscalStatus_SelsJson);
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
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
            WE8V2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT8V2( ) ;
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
         return formatLink("costumer.invoices")  ;
      }

      public override string GetPgmname( )
      {
         return "Costumer.invoices" ;
      }

      public override string GetPgmdesc( )
      {
         return " Nota Fiscal" ;
      }

      protected void WB8V0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(98), 2, 0)+","+"null"+");", "Importar nova nota", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Costumer/invoices.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(98), 2, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Costumer/invoices.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_98_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_Costumer/invoices.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Costumer/invoices.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_98_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_Costumer/invoices.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Costumer/invoices.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_45_8V2( true) ;
         }
         else
         {
            wb_table1_45_8V2( false) ;
         }
         return  ;
      }

      protected void wb_table1_45_8V2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Costumer/invoices.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_98_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV19DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "", true, 0, "HLP_Costumer/invoices.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Costumer/invoices.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_64_8V2( true) ;
         }
         else
         {
            wb_table2_64_8V2( false) ;
         }
         return  ;
      }

      protected void wb_table2_64_8V2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Costumer/invoices.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_98_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV22DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 0, "HLP_Costumer/invoices.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Costumer/invoices.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_83_8V2( true) ;
         }
         else
         {
            wb_table3_83_8V2( false) ;
         }
         return  ;
      }

      protected void wb_table3_83_8V2e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV46GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV47GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV48GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_Costumer/invoices.htm");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV44DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
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

      protected void START8V2( )
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
         Form.Meta.addItem("description", " Nota Fiscal", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP8V0( ) ;
      }

      protected void WS8V2( )
      {
         START8V2( ) ;
         EVT8V2( ) ;
      }

      protected void EVT8V2( )
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
                              E118V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E128V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E138V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E148V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E158V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E168V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E178V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E188V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E198V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E208V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E218V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E228V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E238V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E248V2 ();
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
                              nGXsfl_98_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
                              SubsflControlProps_982( ) ;
                              AV50Nota = cgiGet( edtavNota_Internalname);
                              AssignAttri("", false, edtavNota_Internalname, AV50Nota);
                              A794NotaFiscalId = StringUtil.StrToGuid( cgiGet( edtNotaFiscalId_Internalname));
                              n794NotaFiscalId = false;
                              A799NotaFiscalNumero = cgiGet( edtNotaFiscalNumero_Internalname);
                              n799NotaFiscalNumero = false;
                              A874NotaFiscalValorTotal_F = context.localUtil.CToN( cgiGet( edtNotaFiscalValorTotal_F_Internalname), ",", ".");
                              A875NotaFiscalValorTotalVendido_F = context.localUtil.CToN( cgiGet( edtNotaFiscalValorTotalVendido_F_Internalname), ",", ".");
                              A876NotaFiscalSaldo_F = context.localUtil.CToN( cgiGet( edtNotaFiscalSaldo_F_Internalname), ",", ".");
                              A877NotaFiscalQuantidadeDeItens_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtNotaFiscalQuantidadeDeItens_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n877NotaFiscalQuantidadeDeItens_F = false;
                              A878NotaFiscalQuantidadeDeItensVendidos_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtNotaFiscalQuantidadeDeItensVendidos_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n878NotaFiscalQuantidadeDeItensVendidos_F = false;
                              A879NotaFiscalQuantidadeResumo_F = cgiGet( edtNotaFiscalQuantidadeResumo_F_Internalname);
                              A881NotaFiscalValorFormatado_F = cgiGet( edtNotaFiscalValorFormatado_F_Internalname);
                              A882NotaFiscalValorVendidoFormatado_F = cgiGet( edtNotaFiscalValorVendidoFormatado_F_Internalname);
                              A883NotaFiscalSaldoFormatado_F = cgiGet( edtNotaFiscalSaldoFormatado_F_Internalname);
                              cmbNotaFiscalStatus.Name = cmbNotaFiscalStatus_Internalname;
                              cmbNotaFiscalStatus.CurrentValue = cgiGet( cmbNotaFiscalStatus_Internalname);
                              A880NotaFiscalStatus = cgiGet( cmbNotaFiscalStatus_Internalname);
                              n880NotaFiscalStatus = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E258V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E268V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E278V2 ();
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
                                       /* Set Refresh If Notafiscaluf1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vNOTAFISCALUF1"), ",", ".") != Convert.ToDecimal( AV17NotaFiscalUF1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV19DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Notafiscaluf2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vNOTAFISCALUF2"), ",", ".") != Convert.ToDecimal( AV20NotaFiscalUF2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV22DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Notafiscaluf3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vNOTAFISCALUF3"), ",", ".") != Convert.ToDecimal( AV23NotaFiscalUF3 )) )
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

      protected void WE8V2( )
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

      protected void PA8V2( )
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
                                       short AV17NotaFiscalUF1 ,
                                       string AV19DynamicFiltersSelector2 ,
                                       short AV20NotaFiscalUF2 ,
                                       string AV22DynamicFiltersSelector3 ,
                                       short AV23NotaFiscalUF3 ,
                                       short AV31ManageFiltersExecutionStep ,
                                       string AV51Pgmname ,
                                       string AV32TFNotaFiscalNumero ,
                                       string AV33TFNotaFiscalNumero_Sel ,
                                       string AV34TFNotaFiscalQuantidadeResumo_F ,
                                       string AV35TFNotaFiscalQuantidadeResumo_F_Sel ,
                                       string AV36TFNotaFiscalValorFormatado_F ,
                                       string AV37TFNotaFiscalValorFormatado_F_Sel ,
                                       string AV38TFNotaFiscalValorVendidoFormatado_F ,
                                       string AV39TFNotaFiscalValorVendidoFormatado_F_Sel ,
                                       string AV40TFNotaFiscalSaldoFormatado_F ,
                                       string AV41TFNotaFiscalSaldoFormatado_F_Sel ,
                                       GxSimpleCollection<string> AV43TFNotaFiscalStatus_Sels ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV25DynamicFiltersIgnoreFirst ,
                                       bool AV24DynamicFiltersRemoving ,
                                       bool AV18DynamicFiltersEnabled2 ,
                                       bool AV21DynamicFiltersEnabled3 )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF8V2( ) ;
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
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavNotafiscaluf1.ItemCount > 0 )
         {
            AV17NotaFiscalUF1 = (short)(Math.Round(NumberUtil.Val( cmbavNotafiscaluf1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17NotaFiscalUF1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17NotaFiscalUF1", StringUtil.LTrimStr( (decimal)(AV17NotaFiscalUF1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavNotafiscaluf1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17NotaFiscalUF1), 4, 0));
            AssignProp("", false, cmbavNotafiscaluf1_Internalname, "Values", cmbavNotafiscaluf1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV19DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV19DynamicFiltersSelector2);
            AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavNotafiscaluf2.ItemCount > 0 )
         {
            AV20NotaFiscalUF2 = (short)(Math.Round(NumberUtil.Val( cmbavNotafiscaluf2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV20NotaFiscalUF2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV20NotaFiscalUF2", StringUtil.LTrimStr( (decimal)(AV20NotaFiscalUF2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavNotafiscaluf2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20NotaFiscalUF2), 4, 0));
            AssignProp("", false, cmbavNotafiscaluf2_Internalname, "Values", cmbavNotafiscaluf2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV22DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV22DynamicFiltersSelector3);
            AssignAttri("", false, "AV22DynamicFiltersSelector3", AV22DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavNotafiscaluf3.ItemCount > 0 )
         {
            AV23NotaFiscalUF3 = (short)(Math.Round(NumberUtil.Val( cmbavNotafiscaluf3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23NotaFiscalUF3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23NotaFiscalUF3", StringUtil.LTrimStr( (decimal)(AV23NotaFiscalUF3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavNotafiscaluf3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23NotaFiscalUF3), 4, 0));
            AssignProp("", false, cmbavNotafiscaluf3_Internalname, "Values", cmbavNotafiscaluf3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF8V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV51Pgmname = "Costumer.invoices";
         edtavNota_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A880NotaFiscalStatus ,
                                              AV43TFNotaFiscalStatus_Sels ,
                                              AV16DynamicFiltersSelector1 ,
                                              AV17NotaFiscalUF1 ,
                                              AV18DynamicFiltersEnabled2 ,
                                              AV19DynamicFiltersSelector2 ,
                                              AV20NotaFiscalUF2 ,
                                              AV21DynamicFiltersEnabled3 ,
                                              AV22DynamicFiltersSelector3 ,
                                              AV23NotaFiscalUF3 ,
                                              AV33TFNotaFiscalNumero_Sel ,
                                              AV32TFNotaFiscalNumero ,
                                              A795NotaFiscalUF ,
                                              A799NotaFiscalNumero ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              AV15FilterFullText ,
                                              A879NotaFiscalQuantidadeResumo_F ,
                                              A881NotaFiscalValorFormatado_F ,
                                              A882NotaFiscalValorVendidoFormatado_F ,
                                              A883NotaFiscalSaldoFormatado_F ,
                                              AV35TFNotaFiscalQuantidadeResumo_F_Sel ,
                                              AV34TFNotaFiscalQuantidadeResumo_F ,
                                              AV37TFNotaFiscalValorFormatado_F_Sel ,
                                              AV36TFNotaFiscalValorFormatado_F ,
                                              AV39TFNotaFiscalValorVendidoFormatado_F_Sel ,
                                              AV38TFNotaFiscalValorVendidoFormatado_F ,
                                              AV41TFNotaFiscalSaldoFormatado_F_Sel ,
                                              AV40TFNotaFiscalSaldoFormatado_F ,
                                              AV43TFNotaFiscalStatus_Sels.Count } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV32TFNotaFiscalNumero = StringUtil.Concat( StringUtil.RTrim( AV32TFNotaFiscalNumero), "%", "");
         /* Using cursor H008V7 */
         pr_default.execute(0, new Object[] {AV43TFNotaFiscalStatus_Sels.Count, AV17NotaFiscalUF1, AV20NotaFiscalUF2, AV23NotaFiscalUF3, lV32TFNotaFiscalNumero, AV33TFNotaFiscalNumero_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A795NotaFiscalUF = H008V7_A795NotaFiscalUF[0];
            n795NotaFiscalUF = H008V7_n795NotaFiscalUF[0];
            A799NotaFiscalNumero = H008V7_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = H008V7_n799NotaFiscalNumero[0];
            A794NotaFiscalId = H008V7_A794NotaFiscalId[0];
            n794NotaFiscalId = H008V7_n794NotaFiscalId[0];
            A880NotaFiscalStatus = H008V7_A880NotaFiscalStatus[0];
            n880NotaFiscalStatus = H008V7_n880NotaFiscalStatus[0];
            A877NotaFiscalQuantidadeDeItens_F = H008V7_A877NotaFiscalQuantidadeDeItens_F[0];
            n877NotaFiscalQuantidadeDeItens_F = H008V7_n877NotaFiscalQuantidadeDeItens_F[0];
            A878NotaFiscalQuantidadeDeItensVendidos_F = H008V7_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
            n878NotaFiscalQuantidadeDeItensVendidos_F = H008V7_n878NotaFiscalQuantidadeDeItensVendidos_F[0];
            A875NotaFiscalValorTotalVendido_F = H008V7_A875NotaFiscalValorTotalVendido_F[0];
            A874NotaFiscalValorTotal_F = H008V7_A874NotaFiscalValorTotal_F[0];
            A880NotaFiscalStatus = H008V7_A880NotaFiscalStatus[0];
            n880NotaFiscalStatus = H008V7_n880NotaFiscalStatus[0];
            A877NotaFiscalQuantidadeDeItens_F = H008V7_A877NotaFiscalQuantidadeDeItens_F[0];
            n877NotaFiscalQuantidadeDeItens_F = H008V7_n877NotaFiscalQuantidadeDeItens_F[0];
            A874NotaFiscalValorTotal_F = H008V7_A874NotaFiscalValorTotal_F[0];
            A878NotaFiscalQuantidadeDeItensVendidos_F = H008V7_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
            n878NotaFiscalQuantidadeDeItensVendidos_F = H008V7_n878NotaFiscalQuantidadeDeItensVendidos_F[0];
            A875NotaFiscalValorTotalVendido_F = H008V7_A875NotaFiscalValorTotalVendido_F[0];
            A879NotaFiscalQuantidadeResumo_F = StringUtil.Format( "%1/%2", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0), StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0), "", "", "", "", "", "", "");
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFNotaFiscalQuantidadeResumo_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFNotaFiscalQuantidadeResumo_F)) ) ) || ( StringUtil.Like( A879NotaFiscalQuantidadeResumo_F , StringUtil.PadR( AV34TFNotaFiscalQuantidadeResumo_F , 40 , "%"),  ' ' ) ) )
            {
               if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFNotaFiscalQuantidadeResumo_F_Sel)) && ! ( StringUtil.StrCmp(AV35TFNotaFiscalQuantidadeResumo_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A879NotaFiscalQuantidadeResumo_F, AV35TFNotaFiscalQuantidadeResumo_F_Sel) == 0 ) ) )
               {
                  if ( ( StringUtil.StrCmp(AV35TFNotaFiscalQuantidadeResumo_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A879NotaFiscalQuantidadeResumo_F)) ) )
                  {
                     A881NotaFiscalValorFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2), "", "", "", "", "", "", "", "");
                     if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFNotaFiscalValorFormatado_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFNotaFiscalValorFormatado_F)) ) ) || ( StringUtil.Like( A881NotaFiscalValorFormatado_F , StringUtil.PadR( AV36TFNotaFiscalValorFormatado_F , 40 , "%"),  ' ' ) ) )
                     {
                        if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFNotaFiscalValorFormatado_F_Sel)) && ! ( StringUtil.StrCmp(AV37TFNotaFiscalValorFormatado_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A881NotaFiscalValorFormatado_F, AV37TFNotaFiscalValorFormatado_F_Sel) == 0 ) ) )
                        {
                           if ( ( StringUtil.StrCmp(AV37TFNotaFiscalValorFormatado_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A881NotaFiscalValorFormatado_F)) ) )
                           {
                              A876NotaFiscalSaldo_F = (decimal)(A874NotaFiscalValorTotal_F-A875NotaFiscalValorTotalVendido_F);
                              A883NotaFiscalSaldoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A876NotaFiscalSaldo_F, 18, 2), "", "", "", "", "", "", "", "");
                              if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFNotaFiscalSaldoFormatado_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFNotaFiscalSaldoFormatado_F)) ) ) || ( StringUtil.Like( A883NotaFiscalSaldoFormatado_F , StringUtil.PadR( AV40TFNotaFiscalSaldoFormatado_F , 40 , "%"),  ' ' ) ) )
                              {
                                 if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFNotaFiscalSaldoFormatado_F_Sel)) && ! ( StringUtil.StrCmp(AV41TFNotaFiscalSaldoFormatado_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A883NotaFiscalSaldoFormatado_F, AV41TFNotaFiscalSaldoFormatado_F_Sel) == 0 ) ) )
                                 {
                                    if ( ( StringUtil.StrCmp(AV41TFNotaFiscalSaldoFormatado_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A883NotaFiscalSaldoFormatado_F)) ) )
                                    {
                                       A882NotaFiscalValorVendidoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2), "", "", "", "", "", "", "", "");
                                       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)) || ( ( StringUtil.Like( A799NotaFiscalNumero , StringUtil.PadR( "%" + AV15FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A879NotaFiscalQuantidadeResumo_F , StringUtil.PadR( "%" + AV15FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A881NotaFiscalValorFormatado_F , StringUtil.PadR( "%" + AV15FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A882NotaFiscalValorVendidoFormatado_F , StringUtil.PadR( "%" + AV15FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A883NotaFiscalSaldoFormatado_F , StringUtil.PadR( "%" + AV15FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "parcial" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A880NotaFiscalStatus, "Parcial") == 0 ) ) || ( StringUtil.Like( "completo" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A880NotaFiscalStatus, "Completo") == 0 ) ) ) )
                                       {
                                          if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFNotaFiscalValorVendidoFormatado_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFNotaFiscalValorVendidoFormatado_F)) ) ) || ( StringUtil.Like( A882NotaFiscalValorVendidoFormatado_F , StringUtil.PadR( AV38TFNotaFiscalValorVendidoFormatado_F , 40 , "%"),  ' ' ) ) )
                                          {
                                             if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFNotaFiscalValorVendidoFormatado_F_Sel)) && ! ( StringUtil.StrCmp(AV39TFNotaFiscalValorVendidoFormatado_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A882NotaFiscalValorVendidoFormatado_F, AV39TFNotaFiscalValorVendidoFormatado_F_Sel) == 0 ) ) )
                                             {
                                                if ( ( StringUtil.StrCmp(AV39TFNotaFiscalValorVendidoFormatado_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A882NotaFiscalValorVendidoFormatado_F)) ) )
                                                {
                                                   GRID_nRecordCount = (long)(GRID_nRecordCount+1);
                                                }
                                             }
                                          }
                                       }
                                    }
                                 }
                              }
                           }
                        }
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

      protected void RF8V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 98;
         /* Execute user event: Refresh */
         E268V2 ();
         nGXsfl_98_idx = 1;
         sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
         SubsflControlProps_982( ) ;
         bGXsfl_98_Refreshing = true;
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
            SubsflControlProps_982( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A880NotaFiscalStatus ,
                                                 AV43TFNotaFiscalStatus_Sels ,
                                                 AV16DynamicFiltersSelector1 ,
                                                 AV17NotaFiscalUF1 ,
                                                 AV18DynamicFiltersEnabled2 ,
                                                 AV19DynamicFiltersSelector2 ,
                                                 AV20NotaFiscalUF2 ,
                                                 AV21DynamicFiltersEnabled3 ,
                                                 AV22DynamicFiltersSelector3 ,
                                                 AV23NotaFiscalUF3 ,
                                                 AV33TFNotaFiscalNumero_Sel ,
                                                 AV32TFNotaFiscalNumero ,
                                                 A795NotaFiscalUF ,
                                                 A799NotaFiscalNumero ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 AV15FilterFullText ,
                                                 A879NotaFiscalQuantidadeResumo_F ,
                                                 A881NotaFiscalValorFormatado_F ,
                                                 A882NotaFiscalValorVendidoFormatado_F ,
                                                 A883NotaFiscalSaldoFormatado_F ,
                                                 AV35TFNotaFiscalQuantidadeResumo_F_Sel ,
                                                 AV34TFNotaFiscalQuantidadeResumo_F ,
                                                 AV37TFNotaFiscalValorFormatado_F_Sel ,
                                                 AV36TFNotaFiscalValorFormatado_F ,
                                                 AV39TFNotaFiscalValorVendidoFormatado_F_Sel ,
                                                 AV38TFNotaFiscalValorVendidoFormatado_F ,
                                                 AV41TFNotaFiscalSaldoFormatado_F_Sel ,
                                                 AV40TFNotaFiscalSaldoFormatado_F ,
                                                 AV43TFNotaFiscalStatus_Sels.Count } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                                 TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV32TFNotaFiscalNumero = StringUtil.Concat( StringUtil.RTrim( AV32TFNotaFiscalNumero), "%", "");
            /* Using cursor H008V13 */
            pr_default.execute(1, new Object[] {AV43TFNotaFiscalStatus_Sels.Count, AV17NotaFiscalUF1, AV20NotaFiscalUF2, AV23NotaFiscalUF3, lV32TFNotaFiscalNumero, AV33TFNotaFiscalNumero_Sel});
            nGXsfl_98_idx = 1;
            sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
            SubsflControlProps_982( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A795NotaFiscalUF = H008V13_A795NotaFiscalUF[0];
               n795NotaFiscalUF = H008V13_n795NotaFiscalUF[0];
               A799NotaFiscalNumero = H008V13_A799NotaFiscalNumero[0];
               n799NotaFiscalNumero = H008V13_n799NotaFiscalNumero[0];
               A794NotaFiscalId = H008V13_A794NotaFiscalId[0];
               n794NotaFiscalId = H008V13_n794NotaFiscalId[0];
               A880NotaFiscalStatus = H008V13_A880NotaFiscalStatus[0];
               n880NotaFiscalStatus = H008V13_n880NotaFiscalStatus[0];
               A877NotaFiscalQuantidadeDeItens_F = H008V13_A877NotaFiscalQuantidadeDeItens_F[0];
               n877NotaFiscalQuantidadeDeItens_F = H008V13_n877NotaFiscalQuantidadeDeItens_F[0];
               A878NotaFiscalQuantidadeDeItensVendidos_F = H008V13_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
               n878NotaFiscalQuantidadeDeItensVendidos_F = H008V13_n878NotaFiscalQuantidadeDeItensVendidos_F[0];
               A875NotaFiscalValorTotalVendido_F = H008V13_A875NotaFiscalValorTotalVendido_F[0];
               A874NotaFiscalValorTotal_F = H008V13_A874NotaFiscalValorTotal_F[0];
               A880NotaFiscalStatus = H008V13_A880NotaFiscalStatus[0];
               n880NotaFiscalStatus = H008V13_n880NotaFiscalStatus[0];
               A877NotaFiscalQuantidadeDeItens_F = H008V13_A877NotaFiscalQuantidadeDeItens_F[0];
               n877NotaFiscalQuantidadeDeItens_F = H008V13_n877NotaFiscalQuantidadeDeItens_F[0];
               A874NotaFiscalValorTotal_F = H008V13_A874NotaFiscalValorTotal_F[0];
               A878NotaFiscalQuantidadeDeItensVendidos_F = H008V13_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
               n878NotaFiscalQuantidadeDeItensVendidos_F = H008V13_n878NotaFiscalQuantidadeDeItensVendidos_F[0];
               A875NotaFiscalValorTotalVendido_F = H008V13_A875NotaFiscalValorTotalVendido_F[0];
               A879NotaFiscalQuantidadeResumo_F = StringUtil.Format( "%1/%2", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0), StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0), "", "", "", "", "", "", "");
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFNotaFiscalQuantidadeResumo_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFNotaFiscalQuantidadeResumo_F)) ) ) || ( StringUtil.Like( A879NotaFiscalQuantidadeResumo_F , StringUtil.PadR( AV34TFNotaFiscalQuantidadeResumo_F , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFNotaFiscalQuantidadeResumo_F_Sel)) && ! ( StringUtil.StrCmp(AV35TFNotaFiscalQuantidadeResumo_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A879NotaFiscalQuantidadeResumo_F, AV35TFNotaFiscalQuantidadeResumo_F_Sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV35TFNotaFiscalQuantidadeResumo_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A879NotaFiscalQuantidadeResumo_F)) ) )
                     {
                        A881NotaFiscalValorFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2), "", "", "", "", "", "", "", "");
                        if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFNotaFiscalValorFormatado_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFNotaFiscalValorFormatado_F)) ) ) || ( StringUtil.Like( A881NotaFiscalValorFormatado_F , StringUtil.PadR( AV36TFNotaFiscalValorFormatado_F , 40 , "%"),  ' ' ) ) )
                        {
                           if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFNotaFiscalValorFormatado_F_Sel)) && ! ( StringUtil.StrCmp(AV37TFNotaFiscalValorFormatado_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A881NotaFiscalValorFormatado_F, AV37TFNotaFiscalValorFormatado_F_Sel) == 0 ) ) )
                           {
                              if ( ( StringUtil.StrCmp(AV37TFNotaFiscalValorFormatado_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A881NotaFiscalValorFormatado_F)) ) )
                              {
                                 A876NotaFiscalSaldo_F = (decimal)(A874NotaFiscalValorTotal_F-A875NotaFiscalValorTotalVendido_F);
                                 A883NotaFiscalSaldoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A876NotaFiscalSaldo_F, 18, 2), "", "", "", "", "", "", "", "");
                                 if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFNotaFiscalSaldoFormatado_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFNotaFiscalSaldoFormatado_F)) ) ) || ( StringUtil.Like( A883NotaFiscalSaldoFormatado_F , StringUtil.PadR( AV40TFNotaFiscalSaldoFormatado_F , 40 , "%"),  ' ' ) ) )
                                 {
                                    if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFNotaFiscalSaldoFormatado_F_Sel)) && ! ( StringUtil.StrCmp(AV41TFNotaFiscalSaldoFormatado_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A883NotaFiscalSaldoFormatado_F, AV41TFNotaFiscalSaldoFormatado_F_Sel) == 0 ) ) )
                                    {
                                       if ( ( StringUtil.StrCmp(AV41TFNotaFiscalSaldoFormatado_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A883NotaFiscalSaldoFormatado_F)) ) )
                                       {
                                          A882NotaFiscalValorVendidoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2), "", "", "", "", "", "", "", "");
                                          if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)) || ( ( StringUtil.Like( A799NotaFiscalNumero , StringUtil.PadR( "%" + AV15FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A879NotaFiscalQuantidadeResumo_F , StringUtil.PadR( "%" + AV15FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A881NotaFiscalValorFormatado_F , StringUtil.PadR( "%" + AV15FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A882NotaFiscalValorVendidoFormatado_F , StringUtil.PadR( "%" + AV15FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A883NotaFiscalSaldoFormatado_F , StringUtil.PadR( "%" + AV15FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "parcial" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A880NotaFiscalStatus, "Parcial") == 0 ) ) || ( StringUtil.Like( "completo" , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A880NotaFiscalStatus, "Completo") == 0 ) ) ) )
                                          {
                                             if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFNotaFiscalValorVendidoFormatado_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFNotaFiscalValorVendidoFormatado_F)) ) ) || ( StringUtil.Like( A882NotaFiscalValorVendidoFormatado_F , StringUtil.PadR( AV38TFNotaFiscalValorVendidoFormatado_F , 40 , "%"),  ' ' ) ) )
                                             {
                                                if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFNotaFiscalValorVendidoFormatado_F_Sel)) && ! ( StringUtil.StrCmp(AV39TFNotaFiscalValorVendidoFormatado_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A882NotaFiscalValorVendidoFormatado_F, AV39TFNotaFiscalValorVendidoFormatado_F_Sel) == 0 ) ) )
                                                {
                                                   if ( ( StringUtil.StrCmp(AV39TFNotaFiscalValorVendidoFormatado_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A882NotaFiscalValorVendidoFormatado_F)) ) )
                                                   {
                                                      /* Execute user event: Grid.Load */
                                                      E278V2 ();
                                                   }
                                                }
                                             }
                                          }
                                       }
                                    }
                                 }
                              }
                           }
                        }
                     }
                  }
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 98;
            WB8V0( ) ;
         }
         bGXsfl_98_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes8V2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV51Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV51Pgmname, "")), context));
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
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17NotaFiscalUF1, AV19DynamicFiltersSelector2, AV20NotaFiscalUF2, AV22DynamicFiltersSelector3, AV23NotaFiscalUF3, AV31ManageFiltersExecutionStep, AV51Pgmname, AV32TFNotaFiscalNumero, AV33TFNotaFiscalNumero_Sel, AV34TFNotaFiscalQuantidadeResumo_F, AV35TFNotaFiscalQuantidadeResumo_F_Sel, AV36TFNotaFiscalValorFormatado_F, AV37TFNotaFiscalValorFormatado_F_Sel, AV38TFNotaFiscalValorVendidoFormatado_F, AV39TFNotaFiscalValorVendidoFormatado_F_Sel, AV40TFNotaFiscalSaldoFormatado_F, AV41TFNotaFiscalSaldoFormatado_F_Sel, AV43TFNotaFiscalStatus_Sels, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17NotaFiscalUF1, AV19DynamicFiltersSelector2, AV20NotaFiscalUF2, AV22DynamicFiltersSelector3, AV23NotaFiscalUF3, AV31ManageFiltersExecutionStep, AV51Pgmname, AV32TFNotaFiscalNumero, AV33TFNotaFiscalNumero_Sel, AV34TFNotaFiscalQuantidadeResumo_F, AV35TFNotaFiscalQuantidadeResumo_F_Sel, AV36TFNotaFiscalValorFormatado_F, AV37TFNotaFiscalValorFormatado_F_Sel, AV38TFNotaFiscalValorVendidoFormatado_F, AV39TFNotaFiscalValorVendidoFormatado_F_Sel, AV40TFNotaFiscalSaldoFormatado_F, AV41TFNotaFiscalSaldoFormatado_F_Sel, AV43TFNotaFiscalStatus_Sels, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17NotaFiscalUF1, AV19DynamicFiltersSelector2, AV20NotaFiscalUF2, AV22DynamicFiltersSelector3, AV23NotaFiscalUF3, AV31ManageFiltersExecutionStep, AV51Pgmname, AV32TFNotaFiscalNumero, AV33TFNotaFiscalNumero_Sel, AV34TFNotaFiscalQuantidadeResumo_F, AV35TFNotaFiscalQuantidadeResumo_F_Sel, AV36TFNotaFiscalValorFormatado_F, AV37TFNotaFiscalValorFormatado_F_Sel, AV38TFNotaFiscalValorVendidoFormatado_F, AV39TFNotaFiscalValorVendidoFormatado_F_Sel, AV40TFNotaFiscalSaldoFormatado_F, AV41TFNotaFiscalSaldoFormatado_F_Sel, AV43TFNotaFiscalStatus_Sels, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17NotaFiscalUF1, AV19DynamicFiltersSelector2, AV20NotaFiscalUF2, AV22DynamicFiltersSelector3, AV23NotaFiscalUF3, AV31ManageFiltersExecutionStep, AV51Pgmname, AV32TFNotaFiscalNumero, AV33TFNotaFiscalNumero_Sel, AV34TFNotaFiscalQuantidadeResumo_F, AV35TFNotaFiscalQuantidadeResumo_F_Sel, AV36TFNotaFiscalValorFormatado_F, AV37TFNotaFiscalValorFormatado_F_Sel, AV38TFNotaFiscalValorVendidoFormatado_F, AV39TFNotaFiscalValorVendidoFormatado_F_Sel, AV40TFNotaFiscalSaldoFormatado_F, AV41TFNotaFiscalSaldoFormatado_F_Sel, AV43TFNotaFiscalStatus_Sels, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17NotaFiscalUF1, AV19DynamicFiltersSelector2, AV20NotaFiscalUF2, AV22DynamicFiltersSelector3, AV23NotaFiscalUF3, AV31ManageFiltersExecutionStep, AV51Pgmname, AV32TFNotaFiscalNumero, AV33TFNotaFiscalNumero_Sel, AV34TFNotaFiscalQuantidadeResumo_F, AV35TFNotaFiscalQuantidadeResumo_F_Sel, AV36TFNotaFiscalValorFormatado_F, AV37TFNotaFiscalValorFormatado_F_Sel, AV38TFNotaFiscalValorVendidoFormatado_F, AV39TFNotaFiscalValorVendidoFormatado_F_Sel, AV40TFNotaFiscalSaldoFormatado_F, AV41TFNotaFiscalSaldoFormatado_F_Sel, AV43TFNotaFiscalStatus_Sels, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV51Pgmname = "Costumer.invoices";
         edtavNota_Enabled = 0;
         edtNotaFiscalId_Enabled = 0;
         edtNotaFiscalNumero_Enabled = 0;
         edtNotaFiscalValorTotal_F_Enabled = 0;
         edtNotaFiscalValorTotalVendido_F_Enabled = 0;
         edtNotaFiscalSaldo_F_Enabled = 0;
         edtNotaFiscalQuantidadeDeItens_F_Enabled = 0;
         edtNotaFiscalQuantidadeDeItensVendidos_F_Enabled = 0;
         edtNotaFiscalQuantidadeResumo_F_Enabled = 0;
         edtNotaFiscalValorFormatado_F_Enabled = 0;
         edtNotaFiscalValorVendidoFormatado_F_Enabled = 0;
         edtNotaFiscalSaldoFormatado_F_Enabled = 0;
         cmbNotaFiscalStatus.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP8V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E258V2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV29ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV44DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_98 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_98"), ",", "."), 18, MidpointRounding.ToEven));
            AV46GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV47GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV48GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
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
            cmbavNotafiscaluf1.Name = cmbavNotafiscaluf1_Internalname;
            cmbavNotafiscaluf1.CurrentValue = cgiGet( cmbavNotafiscaluf1_Internalname);
            AV17NotaFiscalUF1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavNotafiscaluf1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17NotaFiscalUF1", StringUtil.LTrimStr( (decimal)(AV17NotaFiscalUF1), 4, 0));
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV19DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
            cmbavNotafiscaluf2.Name = cmbavNotafiscaluf2_Internalname;
            cmbavNotafiscaluf2.CurrentValue = cgiGet( cmbavNotafiscaluf2_Internalname);
            AV20NotaFiscalUF2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavNotafiscaluf2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV20NotaFiscalUF2", StringUtil.LTrimStr( (decimal)(AV20NotaFiscalUF2), 4, 0));
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV22DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV22DynamicFiltersSelector3", AV22DynamicFiltersSelector3);
            cmbavNotafiscaluf3.Name = cmbavNotafiscaluf3_Internalname;
            cmbavNotafiscaluf3.CurrentValue = cgiGet( cmbavNotafiscaluf3_Internalname);
            AV23NotaFiscalUF3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavNotafiscaluf3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23NotaFiscalUF3", StringUtil.LTrimStr( (decimal)(AV23NotaFiscalUF3), 4, 0));
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
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vNOTAFISCALUF1"), ",", ".") != Convert.ToDecimal( AV17NotaFiscalUF1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV19DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vNOTAFISCALUF2"), ",", ".") != Convert.ToDecimal( AV20NotaFiscalUF2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV22DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vNOTAFISCALUF3"), ",", ".") != Convert.ToDecimal( AV23NotaFiscalUF3 )) )
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
         E258V2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E258V2( )
      {
         /* Start Routine */
         returnInSub = false;
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
         AV17NotaFiscalUF1 = 0;
         AssignAttri("", false, "AV17NotaFiscalUF1", StringUtil.LTrimStr( (decimal)(AV17NotaFiscalUF1), 4, 0));
         AV16DynamicFiltersSelector1 = "NOTAFISCALUF";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20NotaFiscalUF2 = 0;
         AssignAttri("", false, "AV20NotaFiscalUF2", StringUtil.LTrimStr( (decimal)(AV20NotaFiscalUF2), 4, 0));
         AV19DynamicFiltersSelector2 = "NOTAFISCALUF";
         AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23NotaFiscalUF3 = 0;
         AssignAttri("", false, "AV23NotaFiscalUF3", StringUtil.LTrimStr( (decimal)(AV23NotaFiscalUF3), 4, 0));
         AV22DynamicFiltersSelector3 = "NOTAFISCALUF";
         AssignAttri("", false, "AV22DynamicFiltersSelector3", AV22DynamicFiltersSelector3);
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
         Form.Caption = " Nota Fiscal";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV44DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV44DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E268V2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV31ManageFiltersExecutionStep == 1 )
         {
            AV31ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV31ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV31ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV31ManageFiltersExecutionStep == 2 )
         {
            AV31ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV31ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV31ManageFiltersExecutionStep), 1, 0));
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
         AV46GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV46GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV46GridCurrentPage), 10, 0));
         AV47GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV47GridPageCount", StringUtil.LTrimStr( (decimal)(AV47GridPageCount), 10, 0));
         GXt_char2 = AV48GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV51Pgmname, out  GXt_char2) ;
         AV48GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV48GridAppliedFilters", AV48GridAppliedFilters);
         cmbNotaFiscalStatus_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbNotaFiscalStatus_Internalname, "Columnheaderclass", cmbNotaFiscalStatus_Columnheaderclass, !bGXsfl_98_Refreshing);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29ManageFiltersData", AV29ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E128V2( )
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
            AV45PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV45PageToGo) ;
         }
      }

      protected void E138V2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E148V2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalNumero") == 0 )
            {
               AV32TFNotaFiscalNumero = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV32TFNotaFiscalNumero", AV32TFNotaFiscalNumero);
               AV33TFNotaFiscalNumero_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV33TFNotaFiscalNumero_Sel", AV33TFNotaFiscalNumero_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalQuantidadeResumo_F") == 0 )
            {
               AV34TFNotaFiscalQuantidadeResumo_F = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV34TFNotaFiscalQuantidadeResumo_F", AV34TFNotaFiscalQuantidadeResumo_F);
               AV35TFNotaFiscalQuantidadeResumo_F_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV35TFNotaFiscalQuantidadeResumo_F_Sel", AV35TFNotaFiscalQuantidadeResumo_F_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalValorFormatado_F") == 0 )
            {
               AV36TFNotaFiscalValorFormatado_F = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV36TFNotaFiscalValorFormatado_F", AV36TFNotaFiscalValorFormatado_F);
               AV37TFNotaFiscalValorFormatado_F_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV37TFNotaFiscalValorFormatado_F_Sel", AV37TFNotaFiscalValorFormatado_F_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalValorVendidoFormatado_F") == 0 )
            {
               AV38TFNotaFiscalValorVendidoFormatado_F = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV38TFNotaFiscalValorVendidoFormatado_F", AV38TFNotaFiscalValorVendidoFormatado_F);
               AV39TFNotaFiscalValorVendidoFormatado_F_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV39TFNotaFiscalValorVendidoFormatado_F_Sel", AV39TFNotaFiscalValorVendidoFormatado_F_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalSaldoFormatado_F") == 0 )
            {
               AV40TFNotaFiscalSaldoFormatado_F = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV40TFNotaFiscalSaldoFormatado_F", AV40TFNotaFiscalSaldoFormatado_F);
               AV41TFNotaFiscalSaldoFormatado_F_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV41TFNotaFiscalSaldoFormatado_F_Sel", AV41TFNotaFiscalSaldoFormatado_F_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalStatus") == 0 )
            {
               AV42TFNotaFiscalStatus_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV42TFNotaFiscalStatus_SelsJson", AV42TFNotaFiscalStatus_SelsJson);
               AV43TFNotaFiscalStatus_Sels.FromJSonString(AV42TFNotaFiscalStatus_SelsJson, null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43TFNotaFiscalStatus_Sels", AV43TFNotaFiscalStatus_Sels);
      }

      private void E278V2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            AV50Nota = "<i class=\"fas fa-file-invoice\"></i>";
            AssignAttri("", false, edtavNota_Internalname, AV50Nota);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "costumer.invoice"+UrlEncode(A794NotaFiscalId.ToString());
            edtavNota_Link = formatLink("costumer.invoice") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            if ( StringUtil.StrCmp(A880NotaFiscalStatus, "Parcial") == 0 )
            {
               cmbNotaFiscalStatus_Columnclass = "WWColumn WWColumnGray WWColumnGraySingleCell";
            }
            else if ( StringUtil.StrCmp(A880NotaFiscalStatus, "Completo") == 0 )
            {
               cmbNotaFiscalStatus_Columnclass = "WWColumn WWColumnSuccess WWColumnSuccessSingleCell";
            }
            else
            {
               cmbNotaFiscalStatus_Columnclass = "WWColumn";
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 98;
            }
            sendrow_982( ) ;
         }
         GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_98_Refreshing )
         {
            DoAjaxLoad(98, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E208V2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV18DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E158V2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV24DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV24DynamicFiltersRemoving", AV24DynamicFiltersRemoving);
         AV25DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV25DynamicFiltersIgnoreFirst", AV25DynamicFiltersIgnoreFirst);
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
         AV24DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV24DynamicFiltersRemoving", AV24DynamicFiltersRemoving);
         AV25DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV25DynamicFiltersIgnoreFirst", AV25DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17NotaFiscalUF1, AV19DynamicFiltersSelector2, AV20NotaFiscalUF2, AV22DynamicFiltersSelector3, AV23NotaFiscalUF3, AV31ManageFiltersExecutionStep, AV51Pgmname, AV32TFNotaFiscalNumero, AV33TFNotaFiscalNumero_Sel, AV34TFNotaFiscalQuantidadeResumo_F, AV35TFNotaFiscalQuantidadeResumo_F_Sel, AV36TFNotaFiscalValorFormatado_F, AV37TFNotaFiscalValorFormatado_F_Sel, AV38TFNotaFiscalValorVendidoFormatado_F, AV39TFNotaFiscalValorVendidoFormatado_F_Sel, AV40TFNotaFiscalSaldoFormatado_F, AV41TFNotaFiscalSaldoFormatado_F_Sel, AV43TFNotaFiscalStatus_Sels, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavNotafiscaluf2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20NotaFiscalUF2), 4, 0));
         AssignProp("", false, cmbavNotafiscaluf2_Internalname, "Values", cmbavNotafiscaluf2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavNotafiscaluf3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23NotaFiscalUF3), 4, 0));
         AssignProp("", false, cmbavNotafiscaluf3_Internalname, "Values", cmbavNotafiscaluf3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavNotafiscaluf1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17NotaFiscalUF1), 4, 0));
         AssignProp("", false, cmbavNotafiscaluf1_Internalname, "Values", cmbavNotafiscaluf1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29ManageFiltersData", AV29ManageFiltersData);
      }

      protected void E218V2( )
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

      protected void E228V2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV21DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV21DynamicFiltersEnabled3", AV21DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E168V2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV24DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV24DynamicFiltersRemoving", AV24DynamicFiltersRemoving);
         AV18DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
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
         AV24DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV24DynamicFiltersRemoving", AV24DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17NotaFiscalUF1, AV19DynamicFiltersSelector2, AV20NotaFiscalUF2, AV22DynamicFiltersSelector3, AV23NotaFiscalUF3, AV31ManageFiltersExecutionStep, AV51Pgmname, AV32TFNotaFiscalNumero, AV33TFNotaFiscalNumero_Sel, AV34TFNotaFiscalQuantidadeResumo_F, AV35TFNotaFiscalQuantidadeResumo_F_Sel, AV36TFNotaFiscalValorFormatado_F, AV37TFNotaFiscalValorFormatado_F_Sel, AV38TFNotaFiscalValorVendidoFormatado_F, AV39TFNotaFiscalValorVendidoFormatado_F_Sel, AV40TFNotaFiscalSaldoFormatado_F, AV41TFNotaFiscalSaldoFormatado_F_Sel, AV43TFNotaFiscalStatus_Sels, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavNotafiscaluf2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20NotaFiscalUF2), 4, 0));
         AssignProp("", false, cmbavNotafiscaluf2_Internalname, "Values", cmbavNotafiscaluf2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavNotafiscaluf3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23NotaFiscalUF3), 4, 0));
         AssignProp("", false, cmbavNotafiscaluf3_Internalname, "Values", cmbavNotafiscaluf3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavNotafiscaluf1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17NotaFiscalUF1), 4, 0));
         AssignProp("", false, cmbavNotafiscaluf1_Internalname, "Values", cmbavNotafiscaluf1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29ManageFiltersData", AV29ManageFiltersData);
      }

      protected void E238V2( )
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

      protected void E178V2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV24DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV24DynamicFiltersRemoving", AV24DynamicFiltersRemoving);
         AV21DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV21DynamicFiltersEnabled3", AV21DynamicFiltersEnabled3);
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
         AV24DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV24DynamicFiltersRemoving", AV24DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17NotaFiscalUF1, AV19DynamicFiltersSelector2, AV20NotaFiscalUF2, AV22DynamicFiltersSelector3, AV23NotaFiscalUF3, AV31ManageFiltersExecutionStep, AV51Pgmname, AV32TFNotaFiscalNumero, AV33TFNotaFiscalNumero_Sel, AV34TFNotaFiscalQuantidadeResumo_F, AV35TFNotaFiscalQuantidadeResumo_F_Sel, AV36TFNotaFiscalValorFormatado_F, AV37TFNotaFiscalValorFormatado_F_Sel, AV38TFNotaFiscalValorVendidoFormatado_F, AV39TFNotaFiscalValorVendidoFormatado_F_Sel, AV40TFNotaFiscalSaldoFormatado_F, AV41TFNotaFiscalSaldoFormatado_F_Sel, AV43TFNotaFiscalStatus_Sels, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavNotafiscaluf2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20NotaFiscalUF2), 4, 0));
         AssignProp("", false, cmbavNotafiscaluf2_Internalname, "Values", cmbavNotafiscaluf2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavNotafiscaluf3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23NotaFiscalUF3), 4, 0));
         AssignProp("", false, cmbavNotafiscaluf3_Internalname, "Values", cmbavNotafiscaluf3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavNotafiscaluf1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17NotaFiscalUF1), 4, 0));
         AssignProp("", false, cmbavNotafiscaluf1_Internalname, "Values", cmbavNotafiscaluf1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29ManageFiltersData", AV29ManageFiltersData);
      }

      protected void E248V2( )
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

      protected void E118V2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("Costumer.invoicesFilters")) + "," + UrlEncode(StringUtil.RTrim(AV51Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV31ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV31ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV31ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("Costumer.invoicesFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV31ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV31ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV31ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV30ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "Costumer.invoicesFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV30ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV51Pgmname+"GridState",  AV30ManageFiltersXml) ;
               AV10GridState.FromXml(AV30ManageFiltersXml, null, "", "");
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43TFNotaFiscalStatus_Sels", AV43TFNotaFiscalStatus_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavNotafiscaluf1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17NotaFiscalUF1), 4, 0));
         AssignProp("", false, cmbavNotafiscaluf1_Internalname, "Values", cmbavNotafiscaluf1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavNotafiscaluf2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20NotaFiscalUF2), 4, 0));
         AssignProp("", false, cmbavNotafiscaluf2_Internalname, "Values", cmbavNotafiscaluf2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavNotafiscaluf3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23NotaFiscalUF3), 4, 0));
         AssignProp("", false, cmbavNotafiscaluf3_Internalname, "Values", cmbavNotafiscaluf3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29ManageFiltersData", AV29ManageFiltersData);
      }

      protected void E188V2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wcimpnotafiscal"+UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wcimpnotafiscal") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E198V2( )
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
         new GeneXus.Programs.costumer.invoicesexport(context ).execute( out  AV26ExcelFilename, out  AV27ErrorMessage) ;
         if ( StringUtil.StrCmp(AV26ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV26ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV27ErrorMessage);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43TFNotaFiscalStatus_Sels", AV43TFNotaFiscalStatus_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavNotafiscaluf1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17NotaFiscalUF1), 4, 0));
         AssignProp("", false, cmbavNotafiscaluf1_Internalname, "Values", cmbavNotafiscaluf1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavNotafiscaluf2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20NotaFiscalUF2), 4, 0));
         AssignProp("", false, cmbavNotafiscaluf2_Internalname, "Values", cmbavNotafiscaluf2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavNotafiscaluf3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23NotaFiscalUF3), 4, 0));
         AssignProp("", false, cmbavNotafiscaluf3_Internalname, "Values", cmbavNotafiscaluf3.ToJavascriptSource(), true);
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
         cmbavNotafiscaluf1.Visible = 0;
         AssignProp("", false, cmbavNotafiscaluf1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavNotafiscaluf1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "NOTAFISCALUF") == 0 )
         {
            cmbavNotafiscaluf1.Visible = 1;
            AssignProp("", false, cmbavNotafiscaluf1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavNotafiscaluf1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         cmbavNotafiscaluf2.Visible = 0;
         AssignProp("", false, cmbavNotafiscaluf2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavNotafiscaluf2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "NOTAFISCALUF") == 0 )
         {
            cmbavNotafiscaluf2.Visible = 1;
            AssignProp("", false, cmbavNotafiscaluf2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavNotafiscaluf2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         cmbavNotafiscaluf3.Visible = 0;
         AssignProp("", false, cmbavNotafiscaluf3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavNotafiscaluf3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "NOTAFISCALUF") == 0 )
         {
            cmbavNotafiscaluf3.Visible = 1;
            AssignProp("", false, cmbavNotafiscaluf3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavNotafiscaluf3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV18DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
         AV19DynamicFiltersSelector2 = "NOTAFISCALUF";
         AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         AV20NotaFiscalUF2 = 0;
         AssignAttri("", false, "AV20NotaFiscalUF2", StringUtil.LTrimStr( (decimal)(AV20NotaFiscalUF2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV21DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV21DynamicFiltersEnabled3", AV21DynamicFiltersEnabled3);
         AV22DynamicFiltersSelector3 = "NOTAFISCALUF";
         AssignAttri("", false, "AV22DynamicFiltersSelector3", AV22DynamicFiltersSelector3);
         AV23NotaFiscalUF3 = 0;
         AssignAttri("", false, "AV23NotaFiscalUF3", StringUtil.LTrimStr( (decimal)(AV23NotaFiscalUF3), 4, 0));
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "Costumer.invoicesFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV29ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV32TFNotaFiscalNumero = "";
         AssignAttri("", false, "AV32TFNotaFiscalNumero", AV32TFNotaFiscalNumero);
         AV33TFNotaFiscalNumero_Sel = "";
         AssignAttri("", false, "AV33TFNotaFiscalNumero_Sel", AV33TFNotaFiscalNumero_Sel);
         AV34TFNotaFiscalQuantidadeResumo_F = "";
         AssignAttri("", false, "AV34TFNotaFiscalQuantidadeResumo_F", AV34TFNotaFiscalQuantidadeResumo_F);
         AV35TFNotaFiscalQuantidadeResumo_F_Sel = "";
         AssignAttri("", false, "AV35TFNotaFiscalQuantidadeResumo_F_Sel", AV35TFNotaFiscalQuantidadeResumo_F_Sel);
         AV36TFNotaFiscalValorFormatado_F = "";
         AssignAttri("", false, "AV36TFNotaFiscalValorFormatado_F", AV36TFNotaFiscalValorFormatado_F);
         AV37TFNotaFiscalValorFormatado_F_Sel = "";
         AssignAttri("", false, "AV37TFNotaFiscalValorFormatado_F_Sel", AV37TFNotaFiscalValorFormatado_F_Sel);
         AV38TFNotaFiscalValorVendidoFormatado_F = "";
         AssignAttri("", false, "AV38TFNotaFiscalValorVendidoFormatado_F", AV38TFNotaFiscalValorVendidoFormatado_F);
         AV39TFNotaFiscalValorVendidoFormatado_F_Sel = "";
         AssignAttri("", false, "AV39TFNotaFiscalValorVendidoFormatado_F_Sel", AV39TFNotaFiscalValorVendidoFormatado_F_Sel);
         AV40TFNotaFiscalSaldoFormatado_F = "";
         AssignAttri("", false, "AV40TFNotaFiscalSaldoFormatado_F", AV40TFNotaFiscalSaldoFormatado_F);
         AV41TFNotaFiscalSaldoFormatado_F_Sel = "";
         AssignAttri("", false, "AV41TFNotaFiscalSaldoFormatado_F_Sel", AV41TFNotaFiscalSaldoFormatado_F_Sel);
         AV43TFNotaFiscalStatus_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         AV16DynamicFiltersSelector1 = "NOTAFISCALUF";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV17NotaFiscalUF1 = 0;
         AssignAttri("", false, "AV17NotaFiscalUF1", StringUtil.LTrimStr( (decimal)(AV17NotaFiscalUF1), 4, 0));
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
         if ( StringUtil.StrCmp(AV28Session.Get(AV51Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV51Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV28Session.Get(AV51Pgmname+"GridState"), null, "", "");
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
         AV52GXV1 = 1;
         while ( AV52GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV52GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO") == 0 )
            {
               AV32TFNotaFiscalNumero = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV32TFNotaFiscalNumero", AV32TFNotaFiscalNumero);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO_SEL") == 0 )
            {
               AV33TFNotaFiscalNumero_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFNotaFiscalNumero_Sel", AV33TFNotaFiscalNumero_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALQUANTIDADERESUMO_F") == 0 )
            {
               AV34TFNotaFiscalQuantidadeResumo_F = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFNotaFiscalQuantidadeResumo_F", AV34TFNotaFiscalQuantidadeResumo_F);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALQUANTIDADERESUMO_F_SEL") == 0 )
            {
               AV35TFNotaFiscalQuantidadeResumo_F_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFNotaFiscalQuantidadeResumo_F_Sel", AV35TFNotaFiscalQuantidadeResumo_F_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALVALORFORMATADO_F") == 0 )
            {
               AV36TFNotaFiscalValorFormatado_F = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFNotaFiscalValorFormatado_F", AV36TFNotaFiscalValorFormatado_F);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALVALORFORMATADO_F_SEL") == 0 )
            {
               AV37TFNotaFiscalValorFormatado_F_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFNotaFiscalValorFormatado_F_Sel", AV37TFNotaFiscalValorFormatado_F_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALVALORVENDIDOFORMATADO_F") == 0 )
            {
               AV38TFNotaFiscalValorVendidoFormatado_F = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFNotaFiscalValorVendidoFormatado_F", AV38TFNotaFiscalValorVendidoFormatado_F);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALVALORVENDIDOFORMATADO_F_SEL") == 0 )
            {
               AV39TFNotaFiscalValorVendidoFormatado_F_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39TFNotaFiscalValorVendidoFormatado_F_Sel", AV39TFNotaFiscalValorVendidoFormatado_F_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALSALDOFORMATADO_F") == 0 )
            {
               AV40TFNotaFiscalSaldoFormatado_F = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFNotaFiscalSaldoFormatado_F", AV40TFNotaFiscalSaldoFormatado_F);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALSALDOFORMATADO_F_SEL") == 0 )
            {
               AV41TFNotaFiscalSaldoFormatado_F_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFNotaFiscalSaldoFormatado_F_Sel", AV41TFNotaFiscalSaldoFormatado_F_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALSTATUS_SEL") == 0 )
            {
               AV42TFNotaFiscalStatus_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFNotaFiscalStatus_SelsJson", AV42TFNotaFiscalStatus_SelsJson);
               AV43TFNotaFiscalStatus_Sels.FromJSonString(AV42TFNotaFiscalStatus_SelsJson, null);
            }
            AV52GXV1 = (int)(AV52GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFNotaFiscalNumero_Sel)),  AV33TFNotaFiscalNumero_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFNotaFiscalQuantidadeResumo_F_Sel)),  AV35TFNotaFiscalQuantidadeResumo_F_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFNotaFiscalValorFormatado_F_Sel)),  AV37TFNotaFiscalValorFormatado_F_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFNotaFiscalValorVendidoFormatado_F_Sel)),  AV39TFNotaFiscalValorVendidoFormatado_F_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFNotaFiscalSaldoFormatado_F_Sel)),  AV41TFNotaFiscalSaldoFormatado_F_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV43TFNotaFiscalStatus_Sels.Count==0),  AV42TFNotaFiscalStatus_SelsJson, out  GXt_char8) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFNotaFiscalNumero)),  AV32TFNotaFiscalNumero, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFNotaFiscalQuantidadeResumo_F)),  AV34TFNotaFiscalQuantidadeResumo_F, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFNotaFiscalValorFormatado_F)),  AV36TFNotaFiscalValorFormatado_F, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFNotaFiscalValorVendidoFormatado_F)),  AV38TFNotaFiscalValorVendidoFormatado_F, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFNotaFiscalSaldoFormatado_F)),  AV40TFNotaFiscalSaldoFormatado_F, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char4+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
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
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "NOTAFISCALUF") == 0 )
            {
               AV17NotaFiscalUF1 = (short)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV17NotaFiscalUF1", StringUtil.LTrimStr( (decimal)(AV17NotaFiscalUF1), 4, 0));
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
               AV18DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "NOTAFISCALUF") == 0 )
               {
                  AV20NotaFiscalUF2 = (short)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV20NotaFiscalUF2", StringUtil.LTrimStr( (decimal)(AV20NotaFiscalUF2), 4, 0));
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
                  AV21DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV21DynamicFiltersEnabled3", AV21DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV22DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV22DynamicFiltersSelector3", AV22DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "NOTAFISCALUF") == 0 )
                  {
                     AV23NotaFiscalUF3 = (short)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV23NotaFiscalUF3", StringUtil.LTrimStr( (decimal)(AV23NotaFiscalUF3), 4, 0));
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
         if ( AV24DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV28Session.Get(AV51Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFNOTAFISCALNUMERO",  "Número",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFNotaFiscalNumero)),  0,  AV32TFNotaFiscalNumero,  AV32TFNotaFiscalNumero,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFNotaFiscalNumero_Sel)),  AV33TFNotaFiscalNumero_Sel,  AV33TFNotaFiscalNumero_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFNOTAFISCALQUANTIDADERESUMO_F",  "Itens",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFNotaFiscalQuantidadeResumo_F)),  0,  AV34TFNotaFiscalQuantidadeResumo_F,  AV34TFNotaFiscalQuantidadeResumo_F,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFNotaFiscalQuantidadeResumo_F_Sel)),  AV35TFNotaFiscalQuantidadeResumo_F_Sel,  AV35TFNotaFiscalQuantidadeResumo_F_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFNOTAFISCALVALORFORMATADO_F",  "Valor",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFNotaFiscalValorFormatado_F)),  0,  AV36TFNotaFiscalValorFormatado_F,  AV36TFNotaFiscalValorFormatado_F,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFNotaFiscalValorFormatado_F_Sel)),  AV37TFNotaFiscalValorFormatado_F_Sel,  AV37TFNotaFiscalValorFormatado_F_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFNOTAFISCALVALORVENDIDOFORMATADO_F",  "Vendido",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFNotaFiscalValorVendidoFormatado_F)),  0,  AV38TFNotaFiscalValorVendidoFormatado_F,  AV38TFNotaFiscalValorVendidoFormatado_F,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFNotaFiscalValorVendidoFormatado_F_Sel)),  AV39TFNotaFiscalValorVendidoFormatado_F_Sel,  AV39TFNotaFiscalValorVendidoFormatado_F_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFNOTAFISCALSALDOFORMATADO_F",  "Saldo",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFNotaFiscalSaldoFormatado_F)),  0,  AV40TFNotaFiscalSaldoFormatado_F,  AV40TFNotaFiscalSaldoFormatado_F,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFNotaFiscalSaldoFormatado_F_Sel)),  AV41TFNotaFiscalSaldoFormatado_F_Sel,  AV41TFNotaFiscalSaldoFormatado_F_Sel) ;
         AV49AuxText = ((AV43TFNotaFiscalStatus_Sels.Count==1) ? "["+((string)AV43TFNotaFiscalStatus_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFNOTAFISCALSTATUS_SEL",  "Status",  !(AV43TFNotaFiscalStatus_Sels.Count==0),  0,  AV43TFNotaFiscalStatus_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV49AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( AV49AuxText, "[Parcial]", "Parcial"), "[Completo]", "Completo")),  false,  "",  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV51Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV25DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV16DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "NOTAFISCALUF") == 0 ) && ! (0==AV17NotaFiscalUF1) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Fiscal UF",  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV17NotaFiscalUF1), 4, 0)),  StringUtil.Trim( gxdomaindmufcod.getDescription(context,AV17NotaFiscalUF1)),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "NOTAFISCALUF") == 0 ) && ! (0==AV20NotaFiscalUF2) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Fiscal UF",  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV20NotaFiscalUF2), 4, 0)),  StringUtil.Trim( gxdomaindmufcod.getDescription(context,AV20NotaFiscalUF2)),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "NOTAFISCALUF") == 0 ) && ! (0==AV23NotaFiscalUF3) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Fiscal UF",  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV23NotaFiscalUF3), 4, 0)),  StringUtil.Trim( gxdomaindmufcod.getDescription(context,AV23NotaFiscalUF3)),  false,  "",  "") ;
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
         AV8TrnContext.gxTpr_Callerobject = AV51Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "NotaFiscal";
         AV28Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_83_8V2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtabledynamicfilters_3_Internalname, tblUnnamedtabledynamicfilters_3_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_notafiscaluf3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavNotafiscaluf3_Internalname, "Nota Fiscal UF3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_98_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavNotafiscaluf3, cmbavNotafiscaluf3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV23NotaFiscalUF3), 4, 0)), 1, cmbavNotafiscaluf3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavNotafiscaluf3.Visible, cmbavNotafiscaluf3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "", true, 0, "HLP_Costumer/invoices.htm");
            cmbavNotafiscaluf3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23NotaFiscalUF3), 4, 0));
            AssignProp("", false, cmbavNotafiscaluf3_Internalname, "Values", (string)(cmbavNotafiscaluf3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Costumer/invoices.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_83_8V2e( true) ;
         }
         else
         {
            wb_table3_83_8V2e( false) ;
         }
      }

      protected void wb_table2_64_8V2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtabledynamicfilters_2_Internalname, tblUnnamedtabledynamicfilters_2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_notafiscaluf2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavNotafiscaluf2_Internalname, "Nota Fiscal UF2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_98_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavNotafiscaluf2, cmbavNotafiscaluf2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV20NotaFiscalUF2), 4, 0)), 1, cmbavNotafiscaluf2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavNotafiscaluf2.Visible, cmbavNotafiscaluf2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "", true, 0, "HLP_Costumer/invoices.htm");
            cmbavNotafiscaluf2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20NotaFiscalUF2), 4, 0));
            AssignProp("", false, cmbavNotafiscaluf2_Internalname, "Values", (string)(cmbavNotafiscaluf2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Costumer/invoices.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Costumer/invoices.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_64_8V2e( true) ;
         }
         else
         {
            wb_table2_64_8V2e( false) ;
         }
      }

      protected void wb_table1_45_8V2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtabledynamicfilters_1_Internalname, tblUnnamedtabledynamicfilters_1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_notafiscaluf1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavNotafiscaluf1_Internalname, "Nota Fiscal UF1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_98_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavNotafiscaluf1, cmbavNotafiscaluf1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17NotaFiscalUF1), 4, 0)), 1, cmbavNotafiscaluf1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavNotafiscaluf1.Visible, cmbavNotafiscaluf1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_Costumer/invoices.htm");
            cmbavNotafiscaluf1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17NotaFiscalUF1), 4, 0));
            AssignProp("", false, cmbavNotafiscaluf1_Internalname, "Values", (string)(cmbavNotafiscaluf1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Costumer/invoices.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Costumer/invoices.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_45_8V2e( true) ;
         }
         else
         {
            wb_table1_45_8V2e( false) ;
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
         PA8V2( ) ;
         WS8V2( ) ;
         WE8V2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101928123", true, true);
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
         context.AddJavascriptSource("costumer/invoices.js", "?20256101928124", false, true);
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
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_982( )
      {
         edtavNota_Internalname = "vNOTA_"+sGXsfl_98_idx;
         edtNotaFiscalId_Internalname = "NOTAFISCALID_"+sGXsfl_98_idx;
         edtNotaFiscalNumero_Internalname = "NOTAFISCALNUMERO_"+sGXsfl_98_idx;
         edtNotaFiscalValorTotal_F_Internalname = "NOTAFISCALVALORTOTAL_F_"+sGXsfl_98_idx;
         edtNotaFiscalValorTotalVendido_F_Internalname = "NOTAFISCALVALORTOTALVENDIDO_F_"+sGXsfl_98_idx;
         edtNotaFiscalSaldo_F_Internalname = "NOTAFISCALSALDO_F_"+sGXsfl_98_idx;
         edtNotaFiscalQuantidadeDeItens_F_Internalname = "NOTAFISCALQUANTIDADEDEITENS_F_"+sGXsfl_98_idx;
         edtNotaFiscalQuantidadeDeItensVendidos_F_Internalname = "NOTAFISCALQUANTIDADEDEITENSVENDIDOS_F_"+sGXsfl_98_idx;
         edtNotaFiscalQuantidadeResumo_F_Internalname = "NOTAFISCALQUANTIDADERESUMO_F_"+sGXsfl_98_idx;
         edtNotaFiscalValorFormatado_F_Internalname = "NOTAFISCALVALORFORMATADO_F_"+sGXsfl_98_idx;
         edtNotaFiscalValorVendidoFormatado_F_Internalname = "NOTAFISCALVALORVENDIDOFORMATADO_F_"+sGXsfl_98_idx;
         edtNotaFiscalSaldoFormatado_F_Internalname = "NOTAFISCALSALDOFORMATADO_F_"+sGXsfl_98_idx;
         cmbNotaFiscalStatus_Internalname = "NOTAFISCALSTATUS_"+sGXsfl_98_idx;
      }

      protected void SubsflControlProps_fel_982( )
      {
         edtavNota_Internalname = "vNOTA_"+sGXsfl_98_fel_idx;
         edtNotaFiscalId_Internalname = "NOTAFISCALID_"+sGXsfl_98_fel_idx;
         edtNotaFiscalNumero_Internalname = "NOTAFISCALNUMERO_"+sGXsfl_98_fel_idx;
         edtNotaFiscalValorTotal_F_Internalname = "NOTAFISCALVALORTOTAL_F_"+sGXsfl_98_fel_idx;
         edtNotaFiscalValorTotalVendido_F_Internalname = "NOTAFISCALVALORTOTALVENDIDO_F_"+sGXsfl_98_fel_idx;
         edtNotaFiscalSaldo_F_Internalname = "NOTAFISCALSALDO_F_"+sGXsfl_98_fel_idx;
         edtNotaFiscalQuantidadeDeItens_F_Internalname = "NOTAFISCALQUANTIDADEDEITENS_F_"+sGXsfl_98_fel_idx;
         edtNotaFiscalQuantidadeDeItensVendidos_F_Internalname = "NOTAFISCALQUANTIDADEDEITENSVENDIDOS_F_"+sGXsfl_98_fel_idx;
         edtNotaFiscalQuantidadeResumo_F_Internalname = "NOTAFISCALQUANTIDADERESUMO_F_"+sGXsfl_98_fel_idx;
         edtNotaFiscalValorFormatado_F_Internalname = "NOTAFISCALVALORFORMATADO_F_"+sGXsfl_98_fel_idx;
         edtNotaFiscalValorVendidoFormatado_F_Internalname = "NOTAFISCALVALORVENDIDOFORMATADO_F_"+sGXsfl_98_fel_idx;
         edtNotaFiscalSaldoFormatado_F_Internalname = "NOTAFISCALSALDOFORMATADO_F_"+sGXsfl_98_fel_idx;
         cmbNotaFiscalStatus_Internalname = "NOTAFISCALSTATUS_"+sGXsfl_98_fel_idx;
      }

      protected void sendrow_982( )
      {
         sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
         SubsflControlProps_982( ) ;
         WB8V0( ) ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'" + sGXsfl_98_idx + "',98)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNota_Internalname,StringUtil.RTrim( AV50Nota),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavNota_Link,(string)"",(string)"Nota fiscal",(string)"",(string)edtavNota_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavNota_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)98,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalId_Internalname,A794NotaFiscalId.ToString(),A794NotaFiscalId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)98,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalNumero_Internalname,(string)A799NotaFiscalNumero,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalNumero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalValorTotal_F_Internalname,StringUtil.LTrim( StringUtil.NToC( A874NotaFiscalValorTotal_F, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A874NotaFiscalValorTotal_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalValorTotal_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalValorTotalVendido_F_Internalname,StringUtil.LTrim( StringUtil.NToC( A875NotaFiscalValorTotalVendido_F, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A875NotaFiscalValorTotalVendido_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalValorTotalVendido_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalSaldo_F_Internalname,StringUtil.LTrim( StringUtil.NToC( A876NotaFiscalSaldo_F, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A876NotaFiscalSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalSaldo_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalQuantidadeDeItens_F_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A877NotaFiscalQuantidadeDeItens_F), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalQuantidadeDeItens_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalQuantidadeDeItensVendidos_F_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalQuantidadeDeItensVendidos_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalQuantidadeResumo_F_Internalname,(string)A879NotaFiscalQuantidadeResumo_F,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalQuantidadeResumo_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalValorFormatado_F_Internalname,(string)A881NotaFiscalValorFormatado_F,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalValorFormatado_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalValorVendidoFormatado_F_Internalname,(string)A882NotaFiscalValorVendidoFormatado_F,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalValorVendidoFormatado_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalSaldoFormatado_F_Internalname,(string)A883NotaFiscalSaldoFormatado_F,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalSaldoFormatado_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            GXCCtl = "NOTAFISCALSTATUS_" + sGXsfl_98_idx;
            cmbNotaFiscalStatus.Name = GXCCtl;
            cmbNotaFiscalStatus.WebTags = "";
            cmbNotaFiscalStatus.addItem("Parcial", "Parcial", 0);
            cmbNotaFiscalStatus.addItem("Completo", "Completo", 0);
            if ( cmbNotaFiscalStatus.ItemCount > 0 )
            {
               A880NotaFiscalStatus = cmbNotaFiscalStatus.getValidValue(A880NotaFiscalStatus);
               n880NotaFiscalStatus = false;
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbNotaFiscalStatus,(string)cmbNotaFiscalStatus_Internalname,StringUtil.RTrim( A880NotaFiscalStatus),(short)1,(string)cmbNotaFiscalStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbNotaFiscalStatus_Columnclass,(string)cmbNotaFiscalStatus_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbNotaFiscalStatus.CurrentValue = StringUtil.RTrim( A880NotaFiscalStatus);
            AssignProp("", false, cmbNotaFiscalStatus_Internalname, "Values", (string)(cmbNotaFiscalStatus.ToJavascriptSource()), !bGXsfl_98_Refreshing);
            send_integrity_lvl_hashes8V2( ) ;
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
         cmbavDynamicfiltersselector1.addItem("NOTAFISCALUF", "Fiscal UF", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV16DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV16DynamicFiltersSelector1);
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         }
         cmbavNotafiscaluf1.Name = "vNOTAFISCALUF1";
         cmbavNotafiscaluf1.WebTags = "";
         cmbavNotafiscaluf1.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 4, 0)), "Todos", 0);
         cmbavNotafiscaluf1.addItem("11", "Rondônia (RO)", 0);
         cmbavNotafiscaluf1.addItem("12", "Acre (AC)", 0);
         cmbavNotafiscaluf1.addItem("13", "Amazonas (AM)", 0);
         cmbavNotafiscaluf1.addItem("14", "Roraima (RR)", 0);
         cmbavNotafiscaluf1.addItem("15", "Pará (PA)", 0);
         cmbavNotafiscaluf1.addItem("16", "Amapá (AP)", 0);
         cmbavNotafiscaluf1.addItem("17", "Tocantins (TO)", 0);
         cmbavNotafiscaluf1.addItem("21", "Maranhão (MA)", 0);
         cmbavNotafiscaluf1.addItem("22", "Piauí (PI)", 0);
         cmbavNotafiscaluf1.addItem("23", "Ceará (CE)", 0);
         cmbavNotafiscaluf1.addItem("24", "Rio Grande do Norte (RN)", 0);
         cmbavNotafiscaluf1.addItem("25", "Paraíba (PB)", 0);
         cmbavNotafiscaluf1.addItem("26", "Pernambuco (PE)", 0);
         cmbavNotafiscaluf1.addItem("27", "Alagoas (AL)", 0);
         cmbavNotafiscaluf1.addItem("28", "Sergipe (SE)", 0);
         cmbavNotafiscaluf1.addItem("29", "Bahia (BA)", 0);
         cmbavNotafiscaluf1.addItem("31", "Minas Gerais (MG)", 0);
         cmbavNotafiscaluf1.addItem("32", "Espírito Santo (ES)", 0);
         cmbavNotafiscaluf1.addItem("33", "Rio de Janeiro (RJ)", 0);
         cmbavNotafiscaluf1.addItem("35", "São Paulo (SP)", 0);
         cmbavNotafiscaluf1.addItem("41", "Paraná (PR)", 0);
         cmbavNotafiscaluf1.addItem("42", "Santa Catarina (SC)", 0);
         cmbavNotafiscaluf1.addItem("43", "Rio Grande do Sul (RS)", 0);
         cmbavNotafiscaluf1.addItem("50", "Mato Grosso do Sul (MS)", 0);
         cmbavNotafiscaluf1.addItem("51", "Mato Grosso (MT)", 0);
         cmbavNotafiscaluf1.addItem("52", "Goiás (GO)", 0);
         cmbavNotafiscaluf1.addItem("53", "Distrito Federal (DF)", 0);
         if ( cmbavNotafiscaluf1.ItemCount > 0 )
         {
            AV17NotaFiscalUF1 = (short)(Math.Round(NumberUtil.Val( cmbavNotafiscaluf1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17NotaFiscalUF1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17NotaFiscalUF1", StringUtil.LTrimStr( (decimal)(AV17NotaFiscalUF1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("NOTAFISCALUF", "Fiscal UF", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV19DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV19DynamicFiltersSelector2);
            AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         }
         cmbavNotafiscaluf2.Name = "vNOTAFISCALUF2";
         cmbavNotafiscaluf2.WebTags = "";
         cmbavNotafiscaluf2.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 4, 0)), "Todos", 0);
         cmbavNotafiscaluf2.addItem("11", "Rondônia (RO)", 0);
         cmbavNotafiscaluf2.addItem("12", "Acre (AC)", 0);
         cmbavNotafiscaluf2.addItem("13", "Amazonas (AM)", 0);
         cmbavNotafiscaluf2.addItem("14", "Roraima (RR)", 0);
         cmbavNotafiscaluf2.addItem("15", "Pará (PA)", 0);
         cmbavNotafiscaluf2.addItem("16", "Amapá (AP)", 0);
         cmbavNotafiscaluf2.addItem("17", "Tocantins (TO)", 0);
         cmbavNotafiscaluf2.addItem("21", "Maranhão (MA)", 0);
         cmbavNotafiscaluf2.addItem("22", "Piauí (PI)", 0);
         cmbavNotafiscaluf2.addItem("23", "Ceará (CE)", 0);
         cmbavNotafiscaluf2.addItem("24", "Rio Grande do Norte (RN)", 0);
         cmbavNotafiscaluf2.addItem("25", "Paraíba (PB)", 0);
         cmbavNotafiscaluf2.addItem("26", "Pernambuco (PE)", 0);
         cmbavNotafiscaluf2.addItem("27", "Alagoas (AL)", 0);
         cmbavNotafiscaluf2.addItem("28", "Sergipe (SE)", 0);
         cmbavNotafiscaluf2.addItem("29", "Bahia (BA)", 0);
         cmbavNotafiscaluf2.addItem("31", "Minas Gerais (MG)", 0);
         cmbavNotafiscaluf2.addItem("32", "Espírito Santo (ES)", 0);
         cmbavNotafiscaluf2.addItem("33", "Rio de Janeiro (RJ)", 0);
         cmbavNotafiscaluf2.addItem("35", "São Paulo (SP)", 0);
         cmbavNotafiscaluf2.addItem("41", "Paraná (PR)", 0);
         cmbavNotafiscaluf2.addItem("42", "Santa Catarina (SC)", 0);
         cmbavNotafiscaluf2.addItem("43", "Rio Grande do Sul (RS)", 0);
         cmbavNotafiscaluf2.addItem("50", "Mato Grosso do Sul (MS)", 0);
         cmbavNotafiscaluf2.addItem("51", "Mato Grosso (MT)", 0);
         cmbavNotafiscaluf2.addItem("52", "Goiás (GO)", 0);
         cmbavNotafiscaluf2.addItem("53", "Distrito Federal (DF)", 0);
         if ( cmbavNotafiscaluf2.ItemCount > 0 )
         {
            AV20NotaFiscalUF2 = (short)(Math.Round(NumberUtil.Val( cmbavNotafiscaluf2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV20NotaFiscalUF2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV20NotaFiscalUF2", StringUtil.LTrimStr( (decimal)(AV20NotaFiscalUF2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("NOTAFISCALUF", "Fiscal UF", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV22DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV22DynamicFiltersSelector3);
            AssignAttri("", false, "AV22DynamicFiltersSelector3", AV22DynamicFiltersSelector3);
         }
         cmbavNotafiscaluf3.Name = "vNOTAFISCALUF3";
         cmbavNotafiscaluf3.WebTags = "";
         cmbavNotafiscaluf3.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 4, 0)), "Todos", 0);
         cmbavNotafiscaluf3.addItem("11", "Rondônia (RO)", 0);
         cmbavNotafiscaluf3.addItem("12", "Acre (AC)", 0);
         cmbavNotafiscaluf3.addItem("13", "Amazonas (AM)", 0);
         cmbavNotafiscaluf3.addItem("14", "Roraima (RR)", 0);
         cmbavNotafiscaluf3.addItem("15", "Pará (PA)", 0);
         cmbavNotafiscaluf3.addItem("16", "Amapá (AP)", 0);
         cmbavNotafiscaluf3.addItem("17", "Tocantins (TO)", 0);
         cmbavNotafiscaluf3.addItem("21", "Maranhão (MA)", 0);
         cmbavNotafiscaluf3.addItem("22", "Piauí (PI)", 0);
         cmbavNotafiscaluf3.addItem("23", "Ceará (CE)", 0);
         cmbavNotafiscaluf3.addItem("24", "Rio Grande do Norte (RN)", 0);
         cmbavNotafiscaluf3.addItem("25", "Paraíba (PB)", 0);
         cmbavNotafiscaluf3.addItem("26", "Pernambuco (PE)", 0);
         cmbavNotafiscaluf3.addItem("27", "Alagoas (AL)", 0);
         cmbavNotafiscaluf3.addItem("28", "Sergipe (SE)", 0);
         cmbavNotafiscaluf3.addItem("29", "Bahia (BA)", 0);
         cmbavNotafiscaluf3.addItem("31", "Minas Gerais (MG)", 0);
         cmbavNotafiscaluf3.addItem("32", "Espírito Santo (ES)", 0);
         cmbavNotafiscaluf3.addItem("33", "Rio de Janeiro (RJ)", 0);
         cmbavNotafiscaluf3.addItem("35", "São Paulo (SP)", 0);
         cmbavNotafiscaluf3.addItem("41", "Paraná (PR)", 0);
         cmbavNotafiscaluf3.addItem("42", "Santa Catarina (SC)", 0);
         cmbavNotafiscaluf3.addItem("43", "Rio Grande do Sul (RS)", 0);
         cmbavNotafiscaluf3.addItem("50", "Mato Grosso do Sul (MS)", 0);
         cmbavNotafiscaluf3.addItem("51", "Mato Grosso (MT)", 0);
         cmbavNotafiscaluf3.addItem("52", "Goiás (GO)", 0);
         cmbavNotafiscaluf3.addItem("53", "Distrito Federal (DF)", 0);
         if ( cmbavNotafiscaluf3.ItemCount > 0 )
         {
            AV23NotaFiscalUF3 = (short)(Math.Round(NumberUtil.Val( cmbavNotafiscaluf3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23NotaFiscalUF3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23NotaFiscalUF3", StringUtil.LTrimStr( (decimal)(AV23NotaFiscalUF3), 4, 0));
         }
         GXCCtl = "NOTAFISCALSTATUS_" + sGXsfl_98_idx;
         cmbNotaFiscalStatus.Name = GXCCtl;
         cmbNotaFiscalStatus.WebTags = "";
         cmbNotaFiscalStatus.addItem("Parcial", "Parcial", 0);
         cmbNotaFiscalStatus.addItem("Completo", "Completo", 0);
         if ( cmbNotaFiscalStatus.ItemCount > 0 )
         {
            A880NotaFiscalStatus = cmbNotaFiscalStatus.getValidValue(A880NotaFiscalStatus);
            n880NotaFiscalStatus = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl98( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"98\">") ;
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Fiscal Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Número") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Valor Total") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Vendido") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Saldo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Qtd Itens") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Itens Vendidos_F") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Itens") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Valor") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Vendido") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Saldo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV50Nota)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNota_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavNota_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A794NotaFiscalId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A799NotaFiscalNumero));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A874NotaFiscalValorTotal_F, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A875NotaFiscalValorTotalVendido_F, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A876NotaFiscalSaldo_F, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A879NotaFiscalQuantidadeResumo_F));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A881NotaFiscalValorFormatado_F));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A882NotaFiscalValorVendidoFormatado_F));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A883NotaFiscalSaldoFormatado_F));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A880NotaFiscalStatus));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbNotaFiscalStatus_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbNotaFiscalStatus_Columnheaderclass));
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
         cmbavNotafiscaluf1_Internalname = "vNOTAFISCALUF1";
         cellFilter_notafiscaluf1_cell_Internalname = "FILTER_NOTAFISCALUF1_CELL";
         imgAdddynamicfilters1_Internalname = "ADDDYNAMICFILTERS1";
         cellDynamicfilters_addfilter1_cell_Internalname = "DYNAMICFILTERS_ADDFILTER1_CELL";
         imgRemovedynamicfilters1_Internalname = "REMOVEDYNAMICFILTERS1";
         cellDynamicfilters_removefilter1_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER1_CELL";
         tblUnnamedtabledynamicfilters_1_Internalname = "UNNAMEDTABLEDYNAMICFILTERS_1";
         divTabledynamicfiltersrow1_Internalname = "TABLEDYNAMICFILTERSROW1";
         lblDynamicfiltersprefix2_Internalname = "DYNAMICFILTERSPREFIX2";
         cmbavDynamicfiltersselector2_Internalname = "vDYNAMICFILTERSSELECTOR2";
         lblDynamicfiltersmiddle2_Internalname = "DYNAMICFILTERSMIDDLE2";
         cmbavNotafiscaluf2_Internalname = "vNOTAFISCALUF2";
         cellFilter_notafiscaluf2_cell_Internalname = "FILTER_NOTAFISCALUF2_CELL";
         imgAdddynamicfilters2_Internalname = "ADDDYNAMICFILTERS2";
         cellDynamicfilters_addfilter2_cell_Internalname = "DYNAMICFILTERS_ADDFILTER2_CELL";
         imgRemovedynamicfilters2_Internalname = "REMOVEDYNAMICFILTERS2";
         cellDynamicfilters_removefilter2_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER2_CELL";
         tblUnnamedtabledynamicfilters_2_Internalname = "UNNAMEDTABLEDYNAMICFILTERS_2";
         divTabledynamicfiltersrow2_Internalname = "TABLEDYNAMICFILTERSROW2";
         lblDynamicfiltersprefix3_Internalname = "DYNAMICFILTERSPREFIX3";
         cmbavDynamicfiltersselector3_Internalname = "vDYNAMICFILTERSSELECTOR3";
         lblDynamicfiltersmiddle3_Internalname = "DYNAMICFILTERSMIDDLE3";
         cmbavNotafiscaluf3_Internalname = "vNOTAFISCALUF3";
         cellFilter_notafiscaluf3_cell_Internalname = "FILTER_NOTAFISCALUF3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblUnnamedtabledynamicfilters_3_Internalname = "UNNAMEDTABLEDYNAMICFILTERS_3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         edtavNota_Internalname = "vNOTA";
         edtNotaFiscalId_Internalname = "NOTAFISCALID";
         edtNotaFiscalNumero_Internalname = "NOTAFISCALNUMERO";
         edtNotaFiscalValorTotal_F_Internalname = "NOTAFISCALVALORTOTAL_F";
         edtNotaFiscalValorTotalVendido_F_Internalname = "NOTAFISCALVALORTOTALVENDIDO_F";
         edtNotaFiscalSaldo_F_Internalname = "NOTAFISCALSALDO_F";
         edtNotaFiscalQuantidadeDeItens_F_Internalname = "NOTAFISCALQUANTIDADEDEITENS_F";
         edtNotaFiscalQuantidadeDeItensVendidos_F_Internalname = "NOTAFISCALQUANTIDADEDEITENSVENDIDOS_F";
         edtNotaFiscalQuantidadeResumo_F_Internalname = "NOTAFISCALQUANTIDADERESUMO_F";
         edtNotaFiscalValorFormatado_F_Internalname = "NOTAFISCALVALORFORMATADO_F";
         edtNotaFiscalValorVendidoFormatado_F_Internalname = "NOTAFISCALVALORVENDIDOFORMATADO_F";
         edtNotaFiscalSaldoFormatado_F_Internalname = "NOTAFISCALSALDOFORMATADO_F";
         cmbNotaFiscalStatus_Internalname = "NOTAFISCALSTATUS";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
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
         cmbNotaFiscalStatus_Jsonclick = "";
         cmbNotaFiscalStatus_Columnclass = "WWColumn";
         edtNotaFiscalSaldoFormatado_F_Jsonclick = "";
         edtNotaFiscalValorVendidoFormatado_F_Jsonclick = "";
         edtNotaFiscalValorFormatado_F_Jsonclick = "";
         edtNotaFiscalQuantidadeResumo_F_Jsonclick = "";
         edtNotaFiscalQuantidadeDeItensVendidos_F_Jsonclick = "";
         edtNotaFiscalQuantidadeDeItens_F_Jsonclick = "";
         edtNotaFiscalSaldo_F_Jsonclick = "";
         edtNotaFiscalValorTotalVendido_F_Jsonclick = "";
         edtNotaFiscalValorTotal_F_Jsonclick = "";
         edtNotaFiscalNumero_Jsonclick = "";
         edtNotaFiscalId_Jsonclick = "";
         edtavNota_Jsonclick = "";
         edtavNota_Link = "";
         edtavNota_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         cmbavNotafiscaluf1_Jsonclick = "";
         cmbavNotafiscaluf1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         cmbavNotafiscaluf2_Jsonclick = "";
         cmbavNotafiscaluf2.Enabled = 1;
         cmbavNotafiscaluf3_Jsonclick = "";
         cmbavNotafiscaluf3.Enabled = 1;
         cmbavNotafiscaluf3.Visible = 1;
         cmbavNotafiscaluf2.Visible = 1;
         cmbavNotafiscaluf1.Visible = 1;
         cmbNotaFiscalStatus_Columnheaderclass = "";
         cmbNotaFiscalStatus.Enabled = 0;
         edtNotaFiscalSaldoFormatado_F_Enabled = 0;
         edtNotaFiscalValorVendidoFormatado_F_Enabled = 0;
         edtNotaFiscalValorFormatado_F_Enabled = 0;
         edtNotaFiscalQuantidadeResumo_F_Enabled = 0;
         edtNotaFiscalQuantidadeDeItensVendidos_F_Enabled = 0;
         edtNotaFiscalQuantidadeDeItens_F_Enabled = 0;
         edtNotaFiscalSaldo_F_Enabled = 0;
         edtNotaFiscalValorTotalVendido_F_Enabled = 0;
         edtNotaFiscalValorTotal_F_Enabled = 0;
         edtNotaFiscalNumero_Enabled = 0;
         edtNotaFiscalId_Enabled = 0;
         subGrid_Sortable = 0;
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
         Ddo_grid_Datalistproc = "Costumer.invoicesGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||||Parcial:Parcial,Completo:Completo";
         Ddo_grid_Allowmultipleselection = "|||||T";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|FixedValues";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character|Character|Character|";
         Ddo_grid_Includefilter = "T|T|T|T|T|";
         Ddo_grid_Includesortasc = "T|||||";
         Ddo_grid_Columnssortvalues = "2|||||";
         Ddo_grid_Columnids = "2:NotaFiscalNumero|8:NotaFiscalQuantidadeResumo_F|9:NotaFiscalValorFormatado_F|10:NotaFiscalValorVendidoFormatado_F|11:NotaFiscalSaldoFormatado_F|12:NotaFiscalStatus";
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
         Form.Caption = " Nota Fiscal";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavNotafiscaluf1"},{"av":"AV17NotaFiscalUF1","fld":"vNOTAFISCALUF1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavNotafiscaluf2"},{"av":"AV20NotaFiscalUF2","fld":"vNOTAFISCALUF2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavNotafiscaluf3"},{"av":"AV23NotaFiscalUF3","fld":"vNOTAFISCALUF3","pic":"ZZZ9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV32TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV33TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV34TFNotaFiscalQuantidadeResumo_F","fld":"vTFNOTAFISCALQUANTIDADERESUMO_F","type":"svchar"},{"av":"AV35TFNotaFiscalQuantidadeResumo_F_Sel","fld":"vTFNOTAFISCALQUANTIDADERESUMO_F_SEL","type":"svchar"},{"av":"AV36TFNotaFiscalValorFormatado_F","fld":"vTFNOTAFISCALVALORFORMATADO_F","type":"svchar"},{"av":"AV37TFNotaFiscalValorFormatado_F_Sel","fld":"vTFNOTAFISCALVALORFORMATADO_F_SEL","type":"svchar"},{"av":"AV38TFNotaFiscalValorVendidoFormatado_F","fld":"vTFNOTAFISCALVALORVENDIDOFORMATADO_F","type":"svchar"},{"av":"AV39TFNotaFiscalValorVendidoFormatado_F_Sel","fld":"vTFNOTAFISCALVALORVENDIDOFORMATADO_F_SEL","type":"svchar"},{"av":"AV40TFNotaFiscalSaldoFormatado_F","fld":"vTFNOTAFISCALSALDOFORMATADO_F","type":"svchar"},{"av":"AV41TFNotaFiscalSaldoFormatado_F_Sel","fld":"vTFNOTAFISCALSALDOFORMATADO_F_SEL","type":"svchar"},{"av":"AV43TFNotaFiscalStatus_Sels","fld":"vTFNOTAFISCALSTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV46GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV47GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV48GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbNotaFiscalStatus"},{"av":"AV29ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E128V2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavNotafiscaluf1"},{"av":"AV17NotaFiscalUF1","fld":"vNOTAFISCALUF1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavNotafiscaluf2"},{"av":"AV20NotaFiscalUF2","fld":"vNOTAFISCALUF2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavNotafiscaluf3"},{"av":"AV23NotaFiscalUF3","fld":"vNOTAFISCALUF3","pic":"ZZZ9","type":"int"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV32TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV33TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV34TFNotaFiscalQuantidadeResumo_F","fld":"vTFNOTAFISCALQUANTIDADERESUMO_F","type":"svchar"},{"av":"AV35TFNotaFiscalQuantidadeResumo_F_Sel","fld":"vTFNOTAFISCALQUANTIDADERESUMO_F_SEL","type":"svchar"},{"av":"AV36TFNotaFiscalValorFormatado_F","fld":"vTFNOTAFISCALVALORFORMATADO_F","type":"svchar"},{"av":"AV37TFNotaFiscalValorFormatado_F_Sel","fld":"vTFNOTAFISCALVALORFORMATADO_F_SEL","type":"svchar"},{"av":"AV38TFNotaFiscalValorVendidoFormatado_F","fld":"vTFNOTAFISCALVALORVENDIDOFORMATADO_F","type":"svchar"},{"av":"AV39TFNotaFiscalValorVendidoFormatado_F_Sel","fld":"vTFNOTAFISCALVALORVENDIDOFORMATADO_F_SEL","type":"svchar"},{"av":"AV40TFNotaFiscalSaldoFormatado_F","fld":"vTFNOTAFISCALSALDOFORMATADO_F","type":"svchar"},{"av":"AV41TFNotaFiscalSaldoFormatado_F_Sel","fld":"vTFNOTAFISCALSALDOFORMATADO_F_SEL","type":"svchar"},{"av":"AV43TFNotaFiscalStatus_Sels","fld":"vTFNOTAFISCALSTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E138V2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavNotafiscaluf1"},{"av":"AV17NotaFiscalUF1","fld":"vNOTAFISCALUF1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavNotafiscaluf2"},{"av":"AV20NotaFiscalUF2","fld":"vNOTAFISCALUF2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavNotafiscaluf3"},{"av":"AV23NotaFiscalUF3","fld":"vNOTAFISCALUF3","pic":"ZZZ9","type":"int"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV32TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV33TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV34TFNotaFiscalQuantidadeResumo_F","fld":"vTFNOTAFISCALQUANTIDADERESUMO_F","type":"svchar"},{"av":"AV35TFNotaFiscalQuantidadeResumo_F_Sel","fld":"vTFNOTAFISCALQUANTIDADERESUMO_F_SEL","type":"svchar"},{"av":"AV36TFNotaFiscalValorFormatado_F","fld":"vTFNOTAFISCALVALORFORMATADO_F","type":"svchar"},{"av":"AV37TFNotaFiscalValorFormatado_F_Sel","fld":"vTFNOTAFISCALVALORFORMATADO_F_SEL","type":"svchar"},{"av":"AV38TFNotaFiscalValorVendidoFormatado_F","fld":"vTFNOTAFISCALVALORVENDIDOFORMATADO_F","type":"svchar"},{"av":"AV39TFNotaFiscalValorVendidoFormatado_F_Sel","fld":"vTFNOTAFISCALVALORVENDIDOFORMATADO_F_SEL","type":"svchar"},{"av":"AV40TFNotaFiscalSaldoFormatado_F","fld":"vTFNOTAFISCALSALDOFORMATADO_F","type":"svchar"},{"av":"AV41TFNotaFiscalSaldoFormatado_F_Sel","fld":"vTFNOTAFISCALSALDOFORMATADO_F_SEL","type":"svchar"},{"av":"AV43TFNotaFiscalStatus_Sels","fld":"vTFNOTAFISCALSTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E148V2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavNotafiscaluf1"},{"av":"AV17NotaFiscalUF1","fld":"vNOTAFISCALUF1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavNotafiscaluf2"},{"av":"AV20NotaFiscalUF2","fld":"vNOTAFISCALUF2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavNotafiscaluf3"},{"av":"AV23NotaFiscalUF3","fld":"vNOTAFISCALUF3","pic":"ZZZ9","type":"int"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV32TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV33TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV34TFNotaFiscalQuantidadeResumo_F","fld":"vTFNOTAFISCALQUANTIDADERESUMO_F","type":"svchar"},{"av":"AV35TFNotaFiscalQuantidadeResumo_F_Sel","fld":"vTFNOTAFISCALQUANTIDADERESUMO_F_SEL","type":"svchar"},{"av":"AV36TFNotaFiscalValorFormatado_F","fld":"vTFNOTAFISCALVALORFORMATADO_F","type":"svchar"},{"av":"AV37TFNotaFiscalValorFormatado_F_Sel","fld":"vTFNOTAFISCALVALORFORMATADO_F_SEL","type":"svchar"},{"av":"AV38TFNotaFiscalValorVendidoFormatado_F","fld":"vTFNOTAFISCALVALORVENDIDOFORMATADO_F","type":"svchar"},{"av":"AV39TFNotaFiscalValorVendidoFormatado_F_Sel","fld":"vTFNOTAFISCALVALORVENDIDOFORMATADO_F_SEL","type":"svchar"},{"av":"AV40TFNotaFiscalSaldoFormatado_F","fld":"vTFNOTAFISCALSALDOFORMATADO_F","type":"svchar"},{"av":"AV41TFNotaFiscalSaldoFormatado_F_Sel","fld":"vTFNOTAFISCALSALDOFORMATADO_F_SEL","type":"svchar"},{"av":"AV43TFNotaFiscalStatus_Sels","fld":"vTFNOTAFISCALSTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV42TFNotaFiscalStatus_SelsJson","fld":"vTFNOTAFISCALSTATUS_SELSJSON","type":"vchar"},{"av":"AV43TFNotaFiscalStatus_Sels","fld":"vTFNOTAFISCALSTATUS_SELS","type":""},{"av":"AV40TFNotaFiscalSaldoFormatado_F","fld":"vTFNOTAFISCALSALDOFORMATADO_F","type":"svchar"},{"av":"AV41TFNotaFiscalSaldoFormatado_F_Sel","fld":"vTFNOTAFISCALSALDOFORMATADO_F_SEL","type":"svchar"},{"av":"AV38TFNotaFiscalValorVendidoFormatado_F","fld":"vTFNOTAFISCALVALORVENDIDOFORMATADO_F","type":"svchar"},{"av":"AV39TFNotaFiscalValorVendidoFormatado_F_Sel","fld":"vTFNOTAFISCALVALORVENDIDOFORMATADO_F_SEL","type":"svchar"},{"av":"AV36TFNotaFiscalValorFormatado_F","fld":"vTFNOTAFISCALVALORFORMATADO_F","type":"svchar"},{"av":"AV37TFNotaFiscalValorFormatado_F_Sel","fld":"vTFNOTAFISCALVALORFORMATADO_F_SEL","type":"svchar"},{"av":"AV34TFNotaFiscalQuantidadeResumo_F","fld":"vTFNOTAFISCALQUANTIDADERESUMO_F","type":"svchar"},{"av":"AV35TFNotaFiscalQuantidadeResumo_F_Sel","fld":"vTFNOTAFISCALQUANTIDADERESUMO_F_SEL","type":"svchar"},{"av":"AV32TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV33TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E278V2","iparms":[{"av":"A794NotaFiscalId","fld":"NOTAFISCALID","type":"guid"},{"av":"cmbNotaFiscalStatus"},{"av":"A880NotaFiscalStatus","fld":"NOTAFISCALSTATUS","type":"svchar"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV50Nota","fld":"vNOTA","type":"char"},{"av":"edtavNota_Link","ctrl":"vNOTA","prop":"Link"},{"av":"cmbNotaFiscalStatus"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E208V2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E158V2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavNotafiscaluf1"},{"av":"AV17NotaFiscalUF1","fld":"vNOTAFISCALUF1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavNotafiscaluf2"},{"av":"AV20NotaFiscalUF2","fld":"vNOTAFISCALUF2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavNotafiscaluf3"},{"av":"AV23NotaFiscalUF3","fld":"vNOTAFISCALUF3","pic":"ZZZ9","type":"int"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV32TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV33TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV34TFNotaFiscalQuantidadeResumo_F","fld":"vTFNOTAFISCALQUANTIDADERESUMO_F","type":"svchar"},{"av":"AV35TFNotaFiscalQuantidadeResumo_F_Sel","fld":"vTFNOTAFISCALQUANTIDADERESUMO_F_SEL","type":"svchar"},{"av":"AV36TFNotaFiscalValorFormatado_F","fld":"vTFNOTAFISCALVALORFORMATADO_F","type":"svchar"},{"av":"AV37TFNotaFiscalValorFormatado_F_Sel","fld":"vTFNOTAFISCALVALORFORMATADO_F_SEL","type":"svchar"},{"av":"AV38TFNotaFiscalValorVendidoFormatado_F","fld":"vTFNOTAFISCALVALORVENDIDOFORMATADO_F","type":"svchar"},{"av":"AV39TFNotaFiscalValorVendidoFormatado_F_Sel","fld":"vTFNOTAFISCALVALORVENDIDOFORMATADO_F_SEL","type":"svchar"},{"av":"AV40TFNotaFiscalSaldoFormatado_F","fld":"vTFNOTAFISCALSALDOFORMATADO_F","type":"svchar"},{"av":"AV41TFNotaFiscalSaldoFormatado_F_Sel","fld":"vTFNOTAFISCALSALDOFORMATADO_F_SEL","type":"svchar"},{"av":"AV43TFNotaFiscalStatus_Sels","fld":"vTFNOTAFISCALSTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavNotafiscaluf2"},{"av":"AV20NotaFiscalUF2","fld":"vNOTAFISCALUF2","pic":"ZZZ9","type":"int"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavNotafiscaluf3"},{"av":"AV23NotaFiscalUF3","fld":"vNOTAFISCALUF3","pic":"ZZZ9","type":"int"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavNotafiscaluf1"},{"av":"AV17NotaFiscalUF1","fld":"vNOTAFISCALUF1","pic":"ZZZ9","type":"int"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV46GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV47GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV48GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbNotaFiscalStatus"},{"av":"AV29ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E218V2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavNotafiscaluf1"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E228V2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E168V2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavNotafiscaluf1"},{"av":"AV17NotaFiscalUF1","fld":"vNOTAFISCALUF1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavNotafiscaluf2"},{"av":"AV20NotaFiscalUF2","fld":"vNOTAFISCALUF2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavNotafiscaluf3"},{"av":"AV23NotaFiscalUF3","fld":"vNOTAFISCALUF3","pic":"ZZZ9","type":"int"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV32TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV33TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV34TFNotaFiscalQuantidadeResumo_F","fld":"vTFNOTAFISCALQUANTIDADERESUMO_F","type":"svchar"},{"av":"AV35TFNotaFiscalQuantidadeResumo_F_Sel","fld":"vTFNOTAFISCALQUANTIDADERESUMO_F_SEL","type":"svchar"},{"av":"AV36TFNotaFiscalValorFormatado_F","fld":"vTFNOTAFISCALVALORFORMATADO_F","type":"svchar"},{"av":"AV37TFNotaFiscalValorFormatado_F_Sel","fld":"vTFNOTAFISCALVALORFORMATADO_F_SEL","type":"svchar"},{"av":"AV38TFNotaFiscalValorVendidoFormatado_F","fld":"vTFNOTAFISCALVALORVENDIDOFORMATADO_F","type":"svchar"},{"av":"AV39TFNotaFiscalValorVendidoFormatado_F_Sel","fld":"vTFNOTAFISCALVALORVENDIDOFORMATADO_F_SEL","type":"svchar"},{"av":"AV40TFNotaFiscalSaldoFormatado_F","fld":"vTFNOTAFISCALSALDOFORMATADO_F","type":"svchar"},{"av":"AV41TFNotaFiscalSaldoFormatado_F_Sel","fld":"vTFNOTAFISCALSALDOFORMATADO_F_SEL","type":"svchar"},{"av":"AV43TFNotaFiscalStatus_Sels","fld":"vTFNOTAFISCALSTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavNotafiscaluf2"},{"av":"AV20NotaFiscalUF2","fld":"vNOTAFISCALUF2","pic":"ZZZ9","type":"int"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavNotafiscaluf3"},{"av":"AV23NotaFiscalUF3","fld":"vNOTAFISCALUF3","pic":"ZZZ9","type":"int"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavNotafiscaluf1"},{"av":"AV17NotaFiscalUF1","fld":"vNOTAFISCALUF1","pic":"ZZZ9","type":"int"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV46GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV47GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV48GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbNotaFiscalStatus"},{"av":"AV29ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E238V2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavNotafiscaluf2"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E178V2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavNotafiscaluf1"},{"av":"AV17NotaFiscalUF1","fld":"vNOTAFISCALUF1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavNotafiscaluf2"},{"av":"AV20NotaFiscalUF2","fld":"vNOTAFISCALUF2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavNotafiscaluf3"},{"av":"AV23NotaFiscalUF3","fld":"vNOTAFISCALUF3","pic":"ZZZ9","type":"int"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV32TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV33TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV34TFNotaFiscalQuantidadeResumo_F","fld":"vTFNOTAFISCALQUANTIDADERESUMO_F","type":"svchar"},{"av":"AV35TFNotaFiscalQuantidadeResumo_F_Sel","fld":"vTFNOTAFISCALQUANTIDADERESUMO_F_SEL","type":"svchar"},{"av":"AV36TFNotaFiscalValorFormatado_F","fld":"vTFNOTAFISCALVALORFORMATADO_F","type":"svchar"},{"av":"AV37TFNotaFiscalValorFormatado_F_Sel","fld":"vTFNOTAFISCALVALORFORMATADO_F_SEL","type":"svchar"},{"av":"AV38TFNotaFiscalValorVendidoFormatado_F","fld":"vTFNOTAFISCALVALORVENDIDOFORMATADO_F","type":"svchar"},{"av":"AV39TFNotaFiscalValorVendidoFormatado_F_Sel","fld":"vTFNOTAFISCALVALORVENDIDOFORMATADO_F_SEL","type":"svchar"},{"av":"AV40TFNotaFiscalSaldoFormatado_F","fld":"vTFNOTAFISCALSALDOFORMATADO_F","type":"svchar"},{"av":"AV41TFNotaFiscalSaldoFormatado_F_Sel","fld":"vTFNOTAFISCALSALDOFORMATADO_F_SEL","type":"svchar"},{"av":"AV43TFNotaFiscalStatus_Sels","fld":"vTFNOTAFISCALSTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavNotafiscaluf2"},{"av":"AV20NotaFiscalUF2","fld":"vNOTAFISCALUF2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavNotafiscaluf3"},{"av":"AV23NotaFiscalUF3","fld":"vNOTAFISCALUF3","pic":"ZZZ9","type":"int"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavNotafiscaluf1"},{"av":"AV17NotaFiscalUF1","fld":"vNOTAFISCALUF1","pic":"ZZZ9","type":"int"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV46GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV47GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV48GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbNotaFiscalStatus"},{"av":"AV29ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E248V2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavNotafiscaluf3"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E118V2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavNotafiscaluf1"},{"av":"AV17NotaFiscalUF1","fld":"vNOTAFISCALUF1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavNotafiscaluf2"},{"av":"AV20NotaFiscalUF2","fld":"vNOTAFISCALUF2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavNotafiscaluf3"},{"av":"AV23NotaFiscalUF3","fld":"vNOTAFISCALUF3","pic":"ZZZ9","type":"int"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV32TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV33TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV34TFNotaFiscalQuantidadeResumo_F","fld":"vTFNOTAFISCALQUANTIDADERESUMO_F","type":"svchar"},{"av":"AV35TFNotaFiscalQuantidadeResumo_F_Sel","fld":"vTFNOTAFISCALQUANTIDADERESUMO_F_SEL","type":"svchar"},{"av":"AV36TFNotaFiscalValorFormatado_F","fld":"vTFNOTAFISCALVALORFORMATADO_F","type":"svchar"},{"av":"AV37TFNotaFiscalValorFormatado_F_Sel","fld":"vTFNOTAFISCALVALORFORMATADO_F_SEL","type":"svchar"},{"av":"AV38TFNotaFiscalValorVendidoFormatado_F","fld":"vTFNOTAFISCALVALORVENDIDOFORMATADO_F","type":"svchar"},{"av":"AV39TFNotaFiscalValorVendidoFormatado_F_Sel","fld":"vTFNOTAFISCALVALORVENDIDOFORMATADO_F_SEL","type":"svchar"},{"av":"AV40TFNotaFiscalSaldoFormatado_F","fld":"vTFNOTAFISCALSALDOFORMATADO_F","type":"svchar"},{"av":"AV41TFNotaFiscalSaldoFormatado_F_Sel","fld":"vTFNOTAFISCALSALDOFORMATADO_F_SEL","type":"svchar"},{"av":"AV43TFNotaFiscalStatus_Sels","fld":"vTFNOTAFISCALSTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV42TFNotaFiscalStatus_SelsJson","fld":"vTFNOTAFISCALSTATUS_SELSJSON","type":"vchar"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV32TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV33TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV34TFNotaFiscalQuantidadeResumo_F","fld":"vTFNOTAFISCALQUANTIDADERESUMO_F","type":"svchar"},{"av":"AV35TFNotaFiscalQuantidadeResumo_F_Sel","fld":"vTFNOTAFISCALQUANTIDADERESUMO_F_SEL","type":"svchar"},{"av":"AV36TFNotaFiscalValorFormatado_F","fld":"vTFNOTAFISCALVALORFORMATADO_F","type":"svchar"},{"av":"AV37TFNotaFiscalValorFormatado_F_Sel","fld":"vTFNOTAFISCALVALORFORMATADO_F_SEL","type":"svchar"},{"av":"AV38TFNotaFiscalValorVendidoFormatado_F","fld":"vTFNOTAFISCALVALORVENDIDOFORMATADO_F","type":"svchar"},{"av":"AV39TFNotaFiscalValorVendidoFormatado_F_Sel","fld":"vTFNOTAFISCALVALORVENDIDOFORMATADO_F_SEL","type":"svchar"},{"av":"AV40TFNotaFiscalSaldoFormatado_F","fld":"vTFNOTAFISCALSALDOFORMATADO_F","type":"svchar"},{"av":"AV41TFNotaFiscalSaldoFormatado_F_Sel","fld":"vTFNOTAFISCALSALDOFORMATADO_F_SEL","type":"svchar"},{"av":"AV43TFNotaFiscalStatus_Sels","fld":"vTFNOTAFISCALSTATUS_SELS","type":""},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavNotafiscaluf1"},{"av":"AV17NotaFiscalUF1","fld":"vNOTAFISCALUF1","pic":"ZZZ9","type":"int"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV42TFNotaFiscalStatus_SelsJson","fld":"vTFNOTAFISCALSTATUS_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavNotafiscaluf2"},{"av":"AV20NotaFiscalUF2","fld":"vNOTAFISCALUF2","pic":"ZZZ9","type":"int"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavNotafiscaluf3"},{"av":"AV23NotaFiscalUF3","fld":"vNOTAFISCALUF3","pic":"ZZZ9","type":"int"},{"av":"AV46GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV47GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV48GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbNotaFiscalStatus"},{"av":"AV29ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E188V2","iparms":[]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E198V2","iparms":[{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV33TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV35TFNotaFiscalQuantidadeResumo_F_Sel","fld":"vTFNOTAFISCALQUANTIDADERESUMO_F_SEL","type":"svchar"},{"av":"AV37TFNotaFiscalValorFormatado_F_Sel","fld":"vTFNOTAFISCALVALORFORMATADO_F_SEL","type":"svchar"},{"av":"AV39TFNotaFiscalValorVendidoFormatado_F_Sel","fld":"vTFNOTAFISCALVALORVENDIDOFORMATADO_F_SEL","type":"svchar"},{"av":"AV41TFNotaFiscalSaldoFormatado_F_Sel","fld":"vTFNOTAFISCALSALDOFORMATADO_F_SEL","type":"svchar"},{"av":"AV43TFNotaFiscalStatus_Sels","fld":"vTFNOTAFISCALSTATUS_SELS","type":""},{"av":"AV42TFNotaFiscalStatus_SelsJson","fld":"vTFNOTAFISCALSTATUS_SELSJSON","type":"vchar"},{"av":"AV32TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV34TFNotaFiscalQuantidadeResumo_F","fld":"vTFNOTAFISCALQUANTIDADERESUMO_F","type":"svchar"},{"av":"AV36TFNotaFiscalValorFormatado_F","fld":"vTFNOTAFISCALVALORFORMATADO_F","type":"svchar"},{"av":"AV38TFNotaFiscalValorVendidoFormatado_F","fld":"vTFNOTAFISCALVALORVENDIDOFORMATADO_F","type":"svchar"},{"av":"AV40TFNotaFiscalSaldoFormatado_F","fld":"vTFNOTAFISCALSALDOFORMATADO_F","type":"svchar"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORT'",""","oparms":[{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavNotafiscaluf1"},{"av":"AV17NotaFiscalUF1","fld":"vNOTAFISCALUF1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavNotafiscaluf2"},{"av":"AV20NotaFiscalUF2","fld":"vNOTAFISCALUF2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavNotafiscaluf3"},{"av":"AV23NotaFiscalUF3","fld":"vNOTAFISCALUF3","pic":"ZZZ9","type":"int"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV32TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV33TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV34TFNotaFiscalQuantidadeResumo_F","fld":"vTFNOTAFISCALQUANTIDADERESUMO_F","type":"svchar"},{"av":"AV35TFNotaFiscalQuantidadeResumo_F_Sel","fld":"vTFNOTAFISCALQUANTIDADERESUMO_F_SEL","type":"svchar"},{"av":"AV36TFNotaFiscalValorFormatado_F","fld":"vTFNOTAFISCALVALORFORMATADO_F","type":"svchar"},{"av":"AV37TFNotaFiscalValorFormatado_F_Sel","fld":"vTFNOTAFISCALVALORFORMATADO_F_SEL","type":"svchar"},{"av":"AV38TFNotaFiscalValorVendidoFormatado_F","fld":"vTFNOTAFISCALVALORVENDIDOFORMATADO_F","type":"svchar"},{"av":"AV39TFNotaFiscalValorVendidoFormatado_F_Sel","fld":"vTFNOTAFISCALVALORVENDIDOFORMATADO_F_SEL","type":"svchar"},{"av":"AV40TFNotaFiscalSaldoFormatado_F","fld":"vTFNOTAFISCALSALDOFORMATADO_F","type":"svchar"},{"av":"AV41TFNotaFiscalSaldoFormatado_F_Sel","fld":"vTFNOTAFISCALSALDOFORMATADO_F_SEL","type":"svchar"},{"av":"AV43TFNotaFiscalStatus_Sels","fld":"vTFNOTAFISCALSTATUS_SELS","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV42TFNotaFiscalStatus_SelsJson","fld":"vTFNOTAFISCALSTATUS_SELSJSON","type":"vchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"}]}""");
         setEventMetadata("VALIDV_NOTAFISCALUF1","""{"handler":"Validv_Notafiscaluf1","iparms":[]}""");
         setEventMetadata("VALIDV_NOTAFISCALUF2","""{"handler":"Validv_Notafiscaluf2","iparms":[]}""");
         setEventMetadata("VALIDV_NOTAFISCALUF3","""{"handler":"Validv_Notafiscaluf3","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALID","""{"handler":"Valid_Notafiscalid","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALNUMERO","""{"handler":"Valid_Notafiscalnumero","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALVALORTOTAL_F","""{"handler":"Valid_Notafiscalvalortotal_f","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALVALORTOTALVENDIDO_F","""{"handler":"Valid_Notafiscalvalortotalvendido_f","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALSALDO_F","""{"handler":"Valid_Notafiscalsaldo_f","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALQUANTIDADEDEITENS_F","""{"handler":"Valid_Notafiscalquantidadedeitens_f","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALQUANTIDADEDEITENSVENDIDOS_F","""{"handler":"Valid_Notafiscalquantidadedeitensvendidos_f","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALQUANTIDADERESUMO_F","""{"handler":"Valid_Notafiscalquantidaderesumo_f","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALVALORFORMATADO_F","""{"handler":"Valid_Notafiscalvalorformatado_f","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALVALORVENDIDOFORMATADO_F","""{"handler":"Valid_Notafiscalvalorvendidoformatado_f","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALSALDOFORMATADO_F","""{"handler":"Valid_Notafiscalsaldoformatado_f","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALSTATUS","""{"handler":"Valid_Notafiscalstatus","iparms":[]}""");
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
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV15FilterFullText = "";
         AV16DynamicFiltersSelector1 = "";
         AV19DynamicFiltersSelector2 = "";
         AV22DynamicFiltersSelector3 = "";
         AV51Pgmname = "";
         AV32TFNotaFiscalNumero = "";
         AV33TFNotaFiscalNumero_Sel = "";
         AV34TFNotaFiscalQuantidadeResumo_F = "";
         AV35TFNotaFiscalQuantidadeResumo_F_Sel = "";
         AV36TFNotaFiscalValorFormatado_F = "";
         AV37TFNotaFiscalValorFormatado_F_Sel = "";
         AV38TFNotaFiscalValorVendidoFormatado_F = "";
         AV39TFNotaFiscalValorVendidoFormatado_F_Sel = "";
         AV40TFNotaFiscalSaldoFormatado_F = "";
         AV41TFNotaFiscalSaldoFormatado_F_Sel = "";
         AV43TFNotaFiscalStatus_Sels = new GxSimpleCollection<string>();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV29ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV48GridAppliedFilters = "";
         AV44DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV42TFNotaFiscalStatus_SelsJson = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
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
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV50Nota = "";
         A794NotaFiscalId = Guid.Empty;
         A799NotaFiscalNumero = "";
         A879NotaFiscalQuantidadeResumo_F = "";
         A881NotaFiscalValorFormatado_F = "";
         A882NotaFiscalValorVendidoFormatado_F = "";
         A883NotaFiscalSaldoFormatado_F = "";
         A880NotaFiscalStatus = "";
         lV15FilterFullText = "";
         lV32TFNotaFiscalNumero = "";
         H008V7_A795NotaFiscalUF = new short[1] ;
         H008V7_n795NotaFiscalUF = new bool[] {false} ;
         H008V7_A799NotaFiscalNumero = new string[] {""} ;
         H008V7_n799NotaFiscalNumero = new bool[] {false} ;
         H008V7_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         H008V7_n794NotaFiscalId = new bool[] {false} ;
         H008V7_A880NotaFiscalStatus = new string[] {""} ;
         H008V7_n880NotaFiscalStatus = new bool[] {false} ;
         H008V7_A877NotaFiscalQuantidadeDeItens_F = new short[1] ;
         H008V7_n877NotaFiscalQuantidadeDeItens_F = new bool[] {false} ;
         H008V7_A878NotaFiscalQuantidadeDeItensVendidos_F = new short[1] ;
         H008V7_n878NotaFiscalQuantidadeDeItensVendidos_F = new bool[] {false} ;
         H008V7_A875NotaFiscalValorTotalVendido_F = new decimal[1] ;
         H008V7_A874NotaFiscalValorTotal_F = new decimal[1] ;
         H008V13_A795NotaFiscalUF = new short[1] ;
         H008V13_n795NotaFiscalUF = new bool[] {false} ;
         H008V13_A799NotaFiscalNumero = new string[] {""} ;
         H008V13_n799NotaFiscalNumero = new bool[] {false} ;
         H008V13_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         H008V13_n794NotaFiscalId = new bool[] {false} ;
         H008V13_A880NotaFiscalStatus = new string[] {""} ;
         H008V13_n880NotaFiscalStatus = new bool[] {false} ;
         H008V13_A877NotaFiscalQuantidadeDeItens_F = new short[1] ;
         H008V13_n877NotaFiscalQuantidadeDeItens_F = new bool[] {false} ;
         H008V13_A878NotaFiscalQuantidadeDeItensVendidos_F = new short[1] ;
         H008V13_n878NotaFiscalQuantidadeDeItensVendidos_F = new bool[] {false} ;
         H008V13_A875NotaFiscalValorTotalVendido_F = new decimal[1] ;
         H008V13_A874NotaFiscalValorTotal_F = new decimal[1] ;
         AV7HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV30ManageFiltersXml = "";
         AV26ExcelFilename = "";
         AV27ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV28Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV49AuxText = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.costumer.invoices__default(),
            new Object[][] {
                new Object[] {
               H008V7_A795NotaFiscalUF, H008V7_n795NotaFiscalUF, H008V7_A799NotaFiscalNumero, H008V7_n799NotaFiscalNumero, H008V7_A794NotaFiscalId, H008V7_A880NotaFiscalStatus, H008V7_n880NotaFiscalStatus, H008V7_A877NotaFiscalQuantidadeDeItens_F, H008V7_n877NotaFiscalQuantidadeDeItens_F, H008V7_A878NotaFiscalQuantidadeDeItensVendidos_F,
               H008V7_n878NotaFiscalQuantidadeDeItensVendidos_F, H008V7_A875NotaFiscalValorTotalVendido_F, H008V7_A874NotaFiscalValorTotal_F
               }
               , new Object[] {
               H008V13_A795NotaFiscalUF, H008V13_n795NotaFiscalUF, H008V13_A799NotaFiscalNumero, H008V13_n799NotaFiscalNumero, H008V13_A794NotaFiscalId, H008V13_A880NotaFiscalStatus, H008V13_n880NotaFiscalStatus, H008V13_A877NotaFiscalQuantidadeDeItens_F, H008V13_n877NotaFiscalQuantidadeDeItens_F, H008V13_A878NotaFiscalQuantidadeDeItensVendidos_F,
               H008V13_n878NotaFiscalQuantidadeDeItensVendidos_F, H008V13_A875NotaFiscalValorTotalVendido_F, H008V13_A874NotaFiscalValorTotal_F
               }
            }
         );
         AV51Pgmname = "Costumer.invoices";
         /* GeneXus formulas. */
         AV51Pgmname = "Costumer.invoices";
         edtavNota_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV17NotaFiscalUF1 ;
      private short AV20NotaFiscalUF2 ;
      private short AV23NotaFiscalUF3 ;
      private short AV31ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A877NotaFiscalQuantidadeDeItens_F ;
      private short A878NotaFiscalQuantidadeDeItensVendidos_F ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short A795NotaFiscalUF ;
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
      private int nRC_GXsfl_98 ;
      private int nGXsfl_98_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavNota_Enabled ;
      private int AV43TFNotaFiscalStatus_Sels_Count ;
      private int edtNotaFiscalId_Enabled ;
      private int edtNotaFiscalNumero_Enabled ;
      private int edtNotaFiscalValorTotal_F_Enabled ;
      private int edtNotaFiscalValorTotalVendido_F_Enabled ;
      private int edtNotaFiscalSaldo_F_Enabled ;
      private int edtNotaFiscalQuantidadeDeItens_F_Enabled ;
      private int edtNotaFiscalQuantidadeDeItensVendidos_F_Enabled ;
      private int edtNotaFiscalQuantidadeResumo_F_Enabled ;
      private int edtNotaFiscalValorFormatado_F_Enabled ;
      private int edtNotaFiscalValorVendidoFormatado_F_Enabled ;
      private int edtNotaFiscalSaldoFormatado_F_Enabled ;
      private int AV45PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int AV52GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV46GridCurrentPage ;
      private long AV47GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal A874NotaFiscalValorTotal_F ;
      private decimal A875NotaFiscalValorTotalVendido_F ;
      private decimal A876NotaFiscalSaldo_F ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_98_idx="0001" ;
      private string AV51Pgmname ;
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
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Allowmultipleselection ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
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
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV50Nota ;
      private string edtavNota_Internalname ;
      private string edtNotaFiscalId_Internalname ;
      private string edtNotaFiscalNumero_Internalname ;
      private string edtNotaFiscalValorTotal_F_Internalname ;
      private string edtNotaFiscalValorTotalVendido_F_Internalname ;
      private string edtNotaFiscalSaldo_F_Internalname ;
      private string edtNotaFiscalQuantidadeDeItens_F_Internalname ;
      private string edtNotaFiscalQuantidadeDeItensVendidos_F_Internalname ;
      private string edtNotaFiscalQuantidadeResumo_F_Internalname ;
      private string edtNotaFiscalValorFormatado_F_Internalname ;
      private string edtNotaFiscalValorVendidoFormatado_F_Internalname ;
      private string edtNotaFiscalSaldoFormatado_F_Internalname ;
      private string cmbNotaFiscalStatus_Internalname ;
      private string cmbavNotafiscaluf1_Internalname ;
      private string cmbavNotafiscaluf2_Internalname ;
      private string cmbavNotafiscaluf3_Internalname ;
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
      private string cmbNotaFiscalStatus_Columnheaderclass ;
      private string edtavNota_Link ;
      private string GXEncryptionTmp ;
      private string cmbNotaFiscalStatus_Columnclass ;
      private string GXt_char2 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string tblUnnamedtabledynamicfilters_3_Internalname ;
      private string cellFilter_notafiscaluf3_cell_Internalname ;
      private string cmbavNotafiscaluf3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblUnnamedtabledynamicfilters_2_Internalname ;
      private string cellFilter_notafiscaluf2_cell_Internalname ;
      private string cmbavNotafiscaluf2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblUnnamedtabledynamicfilters_1_Internalname ;
      private string cellFilter_notafiscaluf1_cell_Internalname ;
      private string cmbavNotafiscaluf1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_98_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavNota_Jsonclick ;
      private string edtNotaFiscalId_Jsonclick ;
      private string edtNotaFiscalNumero_Jsonclick ;
      private string edtNotaFiscalValorTotal_F_Jsonclick ;
      private string edtNotaFiscalValorTotalVendido_F_Jsonclick ;
      private string edtNotaFiscalSaldo_F_Jsonclick ;
      private string edtNotaFiscalQuantidadeDeItens_F_Jsonclick ;
      private string edtNotaFiscalQuantidadeDeItensVendidos_F_Jsonclick ;
      private string edtNotaFiscalQuantidadeResumo_F_Jsonclick ;
      private string edtNotaFiscalValorFormatado_F_Jsonclick ;
      private string edtNotaFiscalValorVendidoFormatado_F_Jsonclick ;
      private string edtNotaFiscalSaldoFormatado_F_Jsonclick ;
      private string GXCCtl ;
      private string cmbNotaFiscalStatus_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV25DynamicFiltersIgnoreFirst ;
      private bool AV24DynamicFiltersRemoving ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV21DynamicFiltersEnabled3 ;
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
      private bool n794NotaFiscalId ;
      private bool n799NotaFiscalNumero ;
      private bool n877NotaFiscalQuantidadeDeItens_F ;
      private bool n878NotaFiscalQuantidadeDeItensVendidos_F ;
      private bool n880NotaFiscalStatus ;
      private bool n795NotaFiscalUF ;
      private bool bGXsfl_98_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV42TFNotaFiscalStatus_SelsJson ;
      private string AV30ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV22DynamicFiltersSelector3 ;
      private string AV32TFNotaFiscalNumero ;
      private string AV33TFNotaFiscalNumero_Sel ;
      private string AV34TFNotaFiscalQuantidadeResumo_F ;
      private string AV35TFNotaFiscalQuantidadeResumo_F_Sel ;
      private string AV36TFNotaFiscalValorFormatado_F ;
      private string AV37TFNotaFiscalValorFormatado_F_Sel ;
      private string AV38TFNotaFiscalValorVendidoFormatado_F ;
      private string AV39TFNotaFiscalValorVendidoFormatado_F_Sel ;
      private string AV40TFNotaFiscalSaldoFormatado_F ;
      private string AV41TFNotaFiscalSaldoFormatado_F_Sel ;
      private string AV48GridAppliedFilters ;
      private string A799NotaFiscalNumero ;
      private string A879NotaFiscalQuantidadeResumo_F ;
      private string A881NotaFiscalValorFormatado_F ;
      private string A882NotaFiscalValorVendidoFormatado_F ;
      private string A883NotaFiscalSaldoFormatado_F ;
      private string A880NotaFiscalStatus ;
      private string lV15FilterFullText ;
      private string lV32TFNotaFiscalNumero ;
      private string AV26ExcelFilename ;
      private string AV27ErrorMessage ;
      private string AV49AuxText ;
      private Guid A794NotaFiscalId ;
      private IGxSession AV28Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavNotafiscaluf1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavNotafiscaluf2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavNotafiscaluf3 ;
      private GXCombobox cmbNotaFiscalStatus ;
      private GxSimpleCollection<string> AV43TFNotaFiscalStatus_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV29ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV44DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private short[] H008V7_A795NotaFiscalUF ;
      private bool[] H008V7_n795NotaFiscalUF ;
      private string[] H008V7_A799NotaFiscalNumero ;
      private bool[] H008V7_n799NotaFiscalNumero ;
      private Guid[] H008V7_A794NotaFiscalId ;
      private bool[] H008V7_n794NotaFiscalId ;
      private string[] H008V7_A880NotaFiscalStatus ;
      private bool[] H008V7_n880NotaFiscalStatus ;
      private short[] H008V7_A877NotaFiscalQuantidadeDeItens_F ;
      private bool[] H008V7_n877NotaFiscalQuantidadeDeItens_F ;
      private short[] H008V7_A878NotaFiscalQuantidadeDeItensVendidos_F ;
      private bool[] H008V7_n878NotaFiscalQuantidadeDeItensVendidos_F ;
      private decimal[] H008V7_A875NotaFiscalValorTotalVendido_F ;
      private decimal[] H008V7_A874NotaFiscalValorTotal_F ;
      private short[] H008V13_A795NotaFiscalUF ;
      private bool[] H008V13_n795NotaFiscalUF ;
      private string[] H008V13_A799NotaFiscalNumero ;
      private bool[] H008V13_n799NotaFiscalNumero ;
      private Guid[] H008V13_A794NotaFiscalId ;
      private bool[] H008V13_n794NotaFiscalId ;
      private string[] H008V13_A880NotaFiscalStatus ;
      private bool[] H008V13_n880NotaFiscalStatus ;
      private short[] H008V13_A877NotaFiscalQuantidadeDeItens_F ;
      private bool[] H008V13_n877NotaFiscalQuantidadeDeItens_F ;
      private short[] H008V13_A878NotaFiscalQuantidadeDeItensVendidos_F ;
      private bool[] H008V13_n878NotaFiscalQuantidadeDeItensVendidos_F ;
      private decimal[] H008V13_A875NotaFiscalValorTotalVendido_F ;
      private decimal[] H008V13_A874NotaFiscalValorTotal_F ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class invoices__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H008V7( IGxContext context ,
                                             string A880NotaFiscalStatus ,
                                             GxSimpleCollection<string> AV43TFNotaFiscalStatus_Sels ,
                                             string AV16DynamicFiltersSelector1 ,
                                             short AV17NotaFiscalUF1 ,
                                             bool AV18DynamicFiltersEnabled2 ,
                                             string AV19DynamicFiltersSelector2 ,
                                             short AV20NotaFiscalUF2 ,
                                             bool AV21DynamicFiltersEnabled3 ,
                                             string AV22DynamicFiltersSelector3 ,
                                             short AV23NotaFiscalUF3 ,
                                             string AV33TFNotaFiscalNumero_Sel ,
                                             string AV32TFNotaFiscalNumero ,
                                             short A795NotaFiscalUF ,
                                             string A799NotaFiscalNumero ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV15FilterFullText ,
                                             string A879NotaFiscalQuantidadeResumo_F ,
                                             string A881NotaFiscalValorFormatado_F ,
                                             string A882NotaFiscalValorVendidoFormatado_F ,
                                             string A883NotaFiscalSaldoFormatado_F ,
                                             string AV35TFNotaFiscalQuantidadeResumo_F_Sel ,
                                             string AV34TFNotaFiscalQuantidadeResumo_F ,
                                             string AV37TFNotaFiscalValorFormatado_F_Sel ,
                                             string AV36TFNotaFiscalValorFormatado_F ,
                                             string AV39TFNotaFiscalValorVendidoFormatado_F_Sel ,
                                             string AV38TFNotaFiscalValorVendidoFormatado_F ,
                                             string AV41TFNotaFiscalSaldoFormatado_F_Sel ,
                                             string AV40TFNotaFiscalSaldoFormatado_F ,
                                             int AV43TFNotaFiscalStatus_Sels_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[6];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalUF, T1.NotaFiscalNumero, T1.NotaFiscalId, COALESCE( T2.NotaFiscalStatus, '') AS NotaFiscalStatus, COALESCE( T3.NotaFiscalQuantidadeDeItensVendidos_F, 0) AS NotaFiscalQuantidadeDeItens_F, COALESCE( T4.NotaFiscalQuantidadeDeItensVendidos_F, 0) AS NotaFiscalQuantidadeDeItensVendidos_F, COALESCE( T4.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotalVendido_F, COALESCE( T3.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotal_F FROM (((NotaFiscal T1 LEFT JOIN (SELECT CASE  WHEN COALESCE( T6.NotaFiscalQuantidadeDeItensVendidos_F, 0) = COALESCE( T7.NotaFiscalQuantidadeDeItensVendidos_F, 0) THEN 'Completo' ELSE 'Parcial' END AS NotaFiscalStatus, T5.NotaFiscalId FROM ((NotaFiscal T5 LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE (T5.NotaFiscalId = NotaFiscalId) AND (NotaFiscalItemVendido = ( 'VENDIDO')) GROUP BY NotaFiscalId ) T6 ON T6.NotaFiscalId = T5.NotaFiscalId) LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE T5.NotaFiscalId = NotaFiscalId GROUP BY NotaFiscalId ) T7 ON T7.NotaFiscalId = T5.NotaFiscalId) ) T2 ON T2.NotaFiscalId = T1.NotaFiscalId) LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE T1.NotaFiscalId = NotaFiscalId GROUP BY NotaFiscalId ) T3 ON T3.NotaFiscalId = T1.NotaFiscalId) LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE (T1.NotaFiscalId = NotaFiscalId)";
         scmdbuf += " AND (NotaFiscalItemVendido = ( 'VENDIDO')) GROUP BY NotaFiscalId ) T4 ON T4.NotaFiscalId = T1.NotaFiscalId)";
         AddWhere(sWhereString, "(:AV43TFNoCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV43TFNotaFiscalStatus_Sels, "COALESCE( T2.NotaFiscalStatus, '') IN (", ")")+"))");
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "NOTAFISCALUF") == 0 ) && ( ! (0==AV17NotaFiscalUF1) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalUF = :AV17NotaFiscalUF1)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( AV18DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "NOTAFISCALUF") == 0 ) && ( ! (0==AV20NotaFiscalUF2) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalUF = :AV20NotaFiscalUF2)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( AV21DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "NOTAFISCALUF") == 0 ) && ( ! (0==AV23NotaFiscalUF3) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalUF = :AV23NotaFiscalUF3)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV33TFNotaFiscalNumero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFNotaFiscalNumero)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalNumero like :lV32TFNotaFiscalNumero)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFNotaFiscalNumero_Sel)) && ! ( StringUtil.StrCmp(AV33TFNotaFiscalNumero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalNumero = ( :AV33TFNotaFiscalNumero_Sel))");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( StringUtil.StrCmp(AV33TFNotaFiscalNumero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         if ( AV13OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.NotaFiscalUF, T1.NotaFiscalId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NotaFiscalNumero, T1.NotaFiscalId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NotaFiscalNumero DESC, T1.NotaFiscalId";
         }
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H008V13( IGxContext context ,
                                              string A880NotaFiscalStatus ,
                                              GxSimpleCollection<string> AV43TFNotaFiscalStatus_Sels ,
                                              string AV16DynamicFiltersSelector1 ,
                                              short AV17NotaFiscalUF1 ,
                                              bool AV18DynamicFiltersEnabled2 ,
                                              string AV19DynamicFiltersSelector2 ,
                                              short AV20NotaFiscalUF2 ,
                                              bool AV21DynamicFiltersEnabled3 ,
                                              string AV22DynamicFiltersSelector3 ,
                                              short AV23NotaFiscalUF3 ,
                                              string AV33TFNotaFiscalNumero_Sel ,
                                              string AV32TFNotaFiscalNumero ,
                                              short A795NotaFiscalUF ,
                                              string A799NotaFiscalNumero ,
                                              short AV13OrderedBy ,
                                              bool AV14OrderedDsc ,
                                              string AV15FilterFullText ,
                                              string A879NotaFiscalQuantidadeResumo_F ,
                                              string A881NotaFiscalValorFormatado_F ,
                                              string A882NotaFiscalValorVendidoFormatado_F ,
                                              string A883NotaFiscalSaldoFormatado_F ,
                                              string AV35TFNotaFiscalQuantidadeResumo_F_Sel ,
                                              string AV34TFNotaFiscalQuantidadeResumo_F ,
                                              string AV37TFNotaFiscalValorFormatado_F_Sel ,
                                              string AV36TFNotaFiscalValorFormatado_F ,
                                              string AV39TFNotaFiscalValorVendidoFormatado_F_Sel ,
                                              string AV38TFNotaFiscalValorVendidoFormatado_F ,
                                              string AV41TFNotaFiscalSaldoFormatado_F_Sel ,
                                              string AV40TFNotaFiscalSaldoFormatado_F ,
                                              int AV43TFNotaFiscalStatus_Sels_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[6];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalUF, T1.NotaFiscalNumero, T1.NotaFiscalId, COALESCE( T2.NotaFiscalStatus, '') AS NotaFiscalStatus, COALESCE( T3.NotaFiscalQuantidadeDeItensVendidos_F, 0) AS NotaFiscalQuantidadeDeItens_F, COALESCE( T4.NotaFiscalQuantidadeDeItensVendidos_F, 0) AS NotaFiscalQuantidadeDeItensVendidos_F, COALESCE( T4.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotalVendido_F, COALESCE( T3.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotal_F FROM (((NotaFiscal T1 LEFT JOIN (SELECT CASE  WHEN COALESCE( T6.NotaFiscalQuantidadeDeItensVendidos_F, 0) = COALESCE( T7.NotaFiscalQuantidadeDeItensVendidos_F, 0) THEN 'Completo' ELSE 'Parcial' END AS NotaFiscalStatus, T5.NotaFiscalId FROM ((NotaFiscal T5 LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE (T5.NotaFiscalId = NotaFiscalId) AND (NotaFiscalItemVendido = ( 'VENDIDO')) GROUP BY NotaFiscalId ) T6 ON T6.NotaFiscalId = T5.NotaFiscalId) LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE T5.NotaFiscalId = NotaFiscalId GROUP BY NotaFiscalId ) T7 ON T7.NotaFiscalId = T5.NotaFiscalId) ) T2 ON T2.NotaFiscalId = T1.NotaFiscalId) LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE T1.NotaFiscalId = NotaFiscalId GROUP BY NotaFiscalId ) T3 ON T3.NotaFiscalId = T1.NotaFiscalId) LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE (T1.NotaFiscalId = NotaFiscalId)";
         scmdbuf += " AND (NotaFiscalItemVendido = ( 'VENDIDO')) GROUP BY NotaFiscalId ) T4 ON T4.NotaFiscalId = T1.NotaFiscalId)";
         AddWhere(sWhereString, "(:AV43TFNoCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV43TFNotaFiscalStatus_Sels, "COALESCE( T2.NotaFiscalStatus, '') IN (", ")")+"))");
         if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "NOTAFISCALUF") == 0 ) && ( ! (0==AV17NotaFiscalUF1) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalUF = :AV17NotaFiscalUF1)");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( AV18DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "NOTAFISCALUF") == 0 ) && ( ! (0==AV20NotaFiscalUF2) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalUF = :AV20NotaFiscalUF2)");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( AV21DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "NOTAFISCALUF") == 0 ) && ( ! (0==AV23NotaFiscalUF3) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalUF = :AV23NotaFiscalUF3)");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV33TFNotaFiscalNumero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFNotaFiscalNumero)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalNumero like :lV32TFNotaFiscalNumero)");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFNotaFiscalNumero_Sel)) && ! ( StringUtil.StrCmp(AV33TFNotaFiscalNumero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalNumero = ( :AV33TFNotaFiscalNumero_Sel))");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( StringUtil.StrCmp(AV33TFNotaFiscalNumero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         if ( AV13OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.NotaFiscalUF, T1.NotaFiscalId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NotaFiscalNumero, T1.NotaFiscalId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NotaFiscalNumero DESC, T1.NotaFiscalId";
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
                     return conditional_H008V7(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] );
               case 1 :
                     return conditional_H008V13(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] );
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
          Object[] prmH008V7;
          prmH008V7 = new Object[] {
          new ParDef("AV43TFNoCount",GXType.Int32,9,0) ,
          new ParDef("AV17NotaFiscalUF1",GXType.Int16,4,0) ,
          new ParDef("AV20NotaFiscalUF2",GXType.Int16,4,0) ,
          new ParDef("AV23NotaFiscalUF3",GXType.Int16,4,0) ,
          new ParDef("lV32TFNotaFiscalNumero",GXType.VarChar,40,0) ,
          new ParDef("AV33TFNotaFiscalNumero_Sel",GXType.VarChar,40,0)
          };
          Object[] prmH008V13;
          prmH008V13 = new Object[] {
          new ParDef("AV43TFNoCount",GXType.Int32,9,0) ,
          new ParDef("AV17NotaFiscalUF1",GXType.Int16,4,0) ,
          new ParDef("AV20NotaFiscalUF2",GXType.Int16,4,0) ,
          new ParDef("AV23NotaFiscalUF3",GXType.Int16,4,0) ,
          new ParDef("lV32TFNotaFiscalNumero",GXType.VarChar,40,0) ,
          new ParDef("AV33TFNotaFiscalNumero_Sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H008V7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008V7,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H008V13", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008V13,11, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(8);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(8);
                return;
       }
    }

 }

}
