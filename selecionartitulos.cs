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
   public class selecionartitulos : GXDataArea
   {
      public selecionartitulos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public selecionartitulos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_CarteiraDeCobrancaId )
      {
         this.AV48CarteiraDeCobrancaId = aP0_CarteiraDeCobrancaId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavSelected = new GXCheckbox();
         chkTituloDeleted = new GXCheckbox();
         chkTituloArchived = new GXCheckbox();
         cmbTituloTipo = new GXCombobox();
         cmbTituloPropostaTipo = new GXCombobox();
         chkTitulosEmCarteiraDeCobranca_F = new GXCheckbox();
         chkavSelectall = new GXCheckbox();
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
         nRC_GXsfl_37 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_37"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_37_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_37_idx = GetPar( "sGXsfl_37_idx");
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
         AV12OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV13OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV14FilterFullText = GetPar( "FilterFullText");
         AV18ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV49Pgmname = GetPar( "Pgmname");
         AV44TituloIdJson = GetPar( "TituloIdJson");
         AV19TFTituloCLienteRazaoSocial = GetPar( "TFTituloCLienteRazaoSocial");
         AV20TFTituloCLienteRazaoSocial_Sel = GetPar( "TFTituloCLienteRazaoSocial_Sel");
         AV21TFTituloValor = NumberUtil.Val( GetPar( "TFTituloValor"), ".");
         AV22TFTituloValor_To = NumberUtil.Val( GetPar( "TFTituloValor_To"), ".");
         AV23TFTituloDesconto = NumberUtil.Val( GetPar( "TFTituloDesconto"), ".");
         AV24TFTituloDesconto_To = NumberUtil.Val( GetPar( "TFTituloDesconto_To"), ".");
         AV25TFTituloProrrogacao = context.localUtil.ParseDateParm( GetPar( "TFTituloProrrogacao"));
         AV26TFTituloProrrogacao_To = context.localUtil.ParseDateParm( GetPar( "TFTituloProrrogacao_To"));
         AV30TFTituloPropostaDescricao = GetPar( "TFTituloPropostaDescricao");
         AV31TFTituloPropostaDescricao_Sel = GetPar( "TFTituloPropostaDescricao_Sel");
         AV32TFNotaFiscalNumero = GetPar( "TFNotaFiscalNumero");
         AV33TFNotaFiscalNumero_Sel = GetPar( "TFNotaFiscalNumero_Sel");
         AV48CarteiraDeCobrancaId = (int)(Math.Round(NumberUtil.Val( GetPar( "CarteiraDeCobrancaId"), "."), 18, MidpointRounding.ToEven));
         chkavSelected_Titleformat = (short)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AV42i = (long)(Math.Round(NumberUtil.Val( GetPar( "i"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV43TituloIdCol);
         AV46TituloIdToFind = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloIdToFind"), "."), 18, MidpointRounding.ToEven));
         AV47SelectAll = StringUtil.StrToBool( GetPar( "SelectAll"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV18ManageFiltersExecutionStep, AV49Pgmname, AV44TituloIdJson, AV19TFTituloCLienteRazaoSocial, AV20TFTituloCLienteRazaoSocial_Sel, AV21TFTituloValor, AV22TFTituloValor_To, AV23TFTituloDesconto, AV24TFTituloDesconto_To, AV25TFTituloProrrogacao, AV26TFTituloProrrogacao_To, AV30TFTituloPropostaDescricao, AV31TFTituloPropostaDescricao_Sel, AV32TFNotaFiscalNumero, AV33TFNotaFiscalNumero_Sel, AV48CarteiraDeCobrancaId, AV42i, AV43TituloIdCol, AV46TituloIdToFind, AV47SelectAll) ;
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
         PAA52( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTA52( ) ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "selecionartitulos"+UrlEncode(StringUtil.LTrimStr(AV48CarteiraDeCobrancaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("selecionartitulos") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV49Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV49Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vCARTEIRADECOBRANCAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48CarteiraDeCobrancaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCARTEIRADECOBRANCAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV48CarteiraDeCobrancaId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV13OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV14FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_37", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_37), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV16ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV16ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV38GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV34DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV34DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_TITULOPRORROGACAOAUXDATE", context.localUtil.DToC( AV27DDO_TituloProrrogacaoAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_TITULOPRORROGACAOAUXDATETO", context.localUtil.DToC( AV28DDO_TituloProrrogacaoAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV49Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV49Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTITULOIDJSON", AV44TituloIdJson);
         GxWebStd.gx_hidden_field( context, "vTFTITULOCLIENTERAZAOSOCIAL", AV19TFTituloCLienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "vTFTITULOCLIENTERAZAOSOCIAL_SEL", AV20TFTituloCLienteRazaoSocial_Sel);
         GxWebStd.gx_hidden_field( context, "vTFTITULOVALOR", StringUtil.LTrim( StringUtil.NToC( AV21TFTituloValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTITULOVALOR_TO", StringUtil.LTrim( StringUtil.NToC( AV22TFTituloValor_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTITULODESCONTO", StringUtil.LTrim( StringUtil.NToC( AV23TFTituloDesconto, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTITULODESCONTO_TO", StringUtil.LTrim( StringUtil.NToC( AV24TFTituloDesconto_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTITULOPRORROGACAO", context.localUtil.DToC( AV25TFTituloProrrogacao, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFTITULOPRORROGACAO_TO", context.localUtil.DToC( AV26TFTituloProrrogacao_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFTITULOPROPOSTADESCRICAO", AV30TFTituloPropostaDescricao);
         GxWebStd.gx_hidden_field( context, "vTFTITULOPROPOSTADESCRICAO_SEL", AV31TFTituloPropostaDescricao_Sel);
         GxWebStd.gx_hidden_field( context, "vTFNOTAFISCALNUMERO", AV32TFNotaFiscalNumero);
         GxWebStd.gx_hidden_field( context, "vTFNOTAFISCALNUMERO_SEL", AV33TFNotaFiscalNumero_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV13OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vCARTEIRADECOBRANCAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48CarteiraDeCobrancaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCARTEIRADECOBRANCAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV48CarteiraDeCobrancaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vI", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42i), 10, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTITULOIDCOL", AV43TituloIdCol);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTITULOIDCOL", AV43TituloIdCol);
         }
         GxWebStd.gx_hidden_field( context, "vTITULOIDTOFIND", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46TituloIdToFind), 9, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV10GridState);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSELECTEDROWS", AV40SelectedRows);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSELECTEDROWS", AV40SelectedRows);
         }
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
            WEA52( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTA52( ) ;
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
         GXEncryptionTmp = "selecionartitulos"+UrlEncode(StringUtil.LTrimStr(AV48CarteiraDeCobrancaId,9,0));
         return formatLink("selecionartitulos") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "SelecionarTitulos" ;
      }

      public override string GetPgmdesc( )
      {
         return " Titulo" ;
      }

      protected void WBA50( )
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
            ClassString = "Button WWPBtnNeedMultiRowSelection";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnconfirmar_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "Confirmar Selecionados", bttBtnconfirmar_Jsonclick, 5, "Confirmar Selecionados", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOCONFIRMAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_SelecionarTitulos.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV16ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_37_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV14FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV14FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_SelecionarTitulos.htm");
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
            StartGridControl37( ) ;
         }
         if ( wbEnd == 37 )
         {
            wbEnd = 0;
            nRC_GXsfl_37 = (int)(nGXsfl_37_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV36GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV37GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV38GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV34DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_37_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSelectall_Internalname, StringUtil.BoolToStr( AV47SelectAll), "", "", chkavSelectall.Visible, 1, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,93);\"");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_tituloprorrogacaoauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'" + sGXsfl_37_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_tituloprorrogacaoauxdatetext_Internalname, AV29DDO_TituloProrrogacaoAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV29DDO_TituloProrrogacaoAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_tituloprorrogacaoauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SelecionarTitulos.htm");
            /* User Defined Control */
            ucTftituloprorrogacao_rangepicker.SetProperty("Start Date", AV27DDO_TituloProrrogacaoAuxDate);
            ucTftituloprorrogacao_rangepicker.SetProperty("End Date", AV28DDO_TituloProrrogacaoAuxDateTo);
            ucTftituloprorrogacao_rangepicker.Render(context, "wwp.daterangepicker", Tftituloprorrogacao_rangepicker_Internalname, "TFTITULOPRORROGACAO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 37 )
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

      protected void STARTA52( )
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
         STRUPA50( ) ;
      }

      protected void WSA52( )
      {
         STARTA52( ) ;
         EVTA52( ) ;
      }

      protected void EVTA52( )
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
                              E11A52 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12A52 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13A52 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E14A52 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCONFIRMAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoConfirmar' */
                              E15A52 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSELECTALL.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E16A52 ();
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
                              nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
                              SubsflControlProps_372( ) ;
                              AV39Selected = StringUtil.StrToBool( cgiGet( chkavSelected_Internalname));
                              AssignAttri("", false, chkavSelected_Internalname, AV39Selected);
                              A261TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n261TituloId = false;
                              A420TituloClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n420TituloClienteId = false;
                              A972TituloCLienteRazaoSocial = StringUtil.Upper( cgiGet( edtTituloCLienteRazaoSocial_Internalname));
                              n972TituloCLienteRazaoSocial = false;
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
                              A286TituloCompetenciaAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloCompetenciaAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n286TituloCompetenciaAno = false;
                              A287TituloCompetenciaMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloCompetenciaMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n287TituloCompetenciaMes = false;
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
                              A971TituloPropostaDescricao = cgiGet( edtTituloPropostaDescricao_Internalname);
                              n971TituloPropostaDescricao = false;
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
                              A302TituloSaldoDebito_F = context.localUtil.CToN( cgiGet( edtTituloSaldoDebito_F_Internalname), ",", ".");
                              A303TituloSaldoCredito_F = context.localUtil.CToN( cgiGet( edtTituloSaldoCredito_F_Internalname), ",", ".");
                              A304TituloTotalMovimentoDebito_F = context.localUtil.CToN( cgiGet( edtTituloTotalMovimentoDebito_F_Internalname), ",", ".");
                              n304TituloTotalMovimentoDebito_F = false;
                              A305TituloTotalMovimentoCredito_F = context.localUtil.CToN( cgiGet( edtTituloTotalMovimentoCredito_F_Internalname), ",", ".");
                              n305TituloTotalMovimentoCredito_F = false;
                              A306TituloTotalMultaJurosDebito_F = context.localUtil.CToN( cgiGet( edtTituloTotalMultaJurosDebito_F_Internalname), ",", ".");
                              n306TituloTotalMultaJurosDebito_F = false;
                              A307TituloTotalMultaJurosCredito_F = context.localUtil.CToN( cgiGet( edtTituloTotalMultaJurosCredito_F_Internalname), ",", ".");
                              n307TituloTotalMultaJurosCredito_F = false;
                              cmbTituloPropostaTipo.Name = cmbTituloPropostaTipo_Internalname;
                              cmbTituloPropostaTipo.CurrentValue = cgiGet( cmbTituloPropostaTipo_Internalname);
                              A648TituloPropostaTipo = cgiGet( cmbTituloPropostaTipo_Internalname);
                              n648TituloPropostaTipo = false;
                              A890NotaFiscalParcelamentoID = StringUtil.StrToGuid( cgiGet( edtNotaFiscalParcelamentoID_Internalname));
                              n890NotaFiscalParcelamentoID = false;
                              A799NotaFiscalNumero = cgiGet( edtNotaFiscalNumero_Internalname);
                              n799NotaFiscalNumero = false;
                              A951ContaBancariaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContaBancariaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n951ContaBancariaId = false;
                              A969AgenciaBancoNome = cgiGet( edtAgenciaBancoNome_Internalname);
                              n969AgenciaBancoNome = false;
                              A953ContaBancariaCarteira = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtContaBancariaCarteira_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n953ContaBancariaCarteira = false;
                              A952ContaBancariaNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtContaBancariaNumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n952ContaBancariaNumero = false;
                              A939AgenciaNumero = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAgenciaNumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n939AgenciaNumero = false;
                              A1118TitulosEmCarteiraDeCobranca_F = StringUtil.StrToBool( cgiGet( chkTitulosEmCarteiraDeCobranca_F_Internalname));
                              A1119TitulosCarteiraDeCobranca = cgiGet( edtTitulosCarteiraDeCobranca_Internalname);
                              n1119TitulosCarteiraDeCobranca = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E17A52 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E18A52 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E19A52 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VSELECTED.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E20A52 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV12OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV13OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV14FilterFullText) != 0 )
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

      protected void WEA52( )
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

      protected void PAA52( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "selecionartitulos")), "selecionartitulos") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "selecionartitulos")))) ;
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
                     AV48CarteiraDeCobrancaId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV48CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(AV48CarteiraDeCobrancaId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vCARTEIRADECOBRANCAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV48CarteiraDeCobrancaId), "ZZZZZZZZ9"), context));
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
         SubsflControlProps_372( ) ;
         while ( nGXsfl_37_idx <= nRC_GXsfl_37 )
         {
            sendrow_372( ) ;
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV12OrderedBy ,
                                       bool AV13OrderedDsc ,
                                       string AV14FilterFullText ,
                                       short AV18ManageFiltersExecutionStep ,
                                       string AV49Pgmname ,
                                       string AV44TituloIdJson ,
                                       string AV19TFTituloCLienteRazaoSocial ,
                                       string AV20TFTituloCLienteRazaoSocial_Sel ,
                                       decimal AV21TFTituloValor ,
                                       decimal AV22TFTituloValor_To ,
                                       decimal AV23TFTituloDesconto ,
                                       decimal AV24TFTituloDesconto_To ,
                                       DateTime AV25TFTituloProrrogacao ,
                                       DateTime AV26TFTituloProrrogacao_To ,
                                       string AV30TFTituloPropostaDescricao ,
                                       string AV31TFTituloPropostaDescricao_Sel ,
                                       string AV32TFNotaFiscalNumero ,
                                       string AV33TFNotaFiscalNumero_Sel ,
                                       int AV48CarteiraDeCobrancaId ,
                                       long AV42i ,
                                       GxSimpleCollection<int> AV43TituloIdCol ,
                                       int AV46TituloIdToFind ,
                                       bool AV47SelectAll )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFA52( ) ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOCOMPETENCIAANO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A286TituloCompetenciaAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TITULOCOMPETENCIAANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A286TituloCompetenciaAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOCOMPETENCIAMES", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A287TituloCompetenciaMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TITULOCOMPETENCIAMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(A287TituloCompetenciaMes), 4, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOSALDODEBITO_F", GetSecureSignedToken( "", context.localUtil.Format( A302TituloSaldoDebito_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "TITULOSALDODEBITO_F", StringUtil.LTrim( StringUtil.NToC( A302TituloSaldoDebito_F, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOSALDOCREDITO_F", GetSecureSignedToken( "", context.localUtil.Format( A303TituloSaldoCredito_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "TITULOSALDOCREDITO_F", StringUtil.LTrim( StringUtil.NToC( A303TituloSaldoCredito_F, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOPROPOSTATIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A648TituloPropostaTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "TITULOPROPOSTATIPO", A648TituloPropostaTipo);
         GxWebStd.gx_hidden_field( context, "gxhash_NOTAFISCALPARCELAMENTOID", GetSecureSignedToken( "", A890NotaFiscalParcelamentoID, context));
         GxWebStd.gx_hidden_field( context, "NOTAFISCALPARCELAMENTOID", A890NotaFiscalParcelamentoID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_CONTABANCARIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A951ContaBancariaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CONTABANCARIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOSEMCARTEIRADECOBRANCA_F", GetSecureSignedToken( "", A1118TitulosEmCarteiraDeCobranca_F, context));
         GxWebStd.gx_hidden_field( context, "TITULOSEMCARTEIRADECOBRANCA_F", StringUtil.BoolToStr( A1118TitulosEmCarteiraDeCobranca_F));
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
         AV47SelectAll = StringUtil.StrToBool( StringUtil.BoolToStr( AV47SelectAll));
         AssignAttri("", false, "AV47SelectAll", AV47SelectAll);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFA52( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV49Pgmname = "SelecionarTitulos";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV50Selecionartitulosds_1_filterfulltext = AV14FilterFullText;
         AV51Selecionartitulosds_2_tftituloclienterazaosocial = AV19TFTituloCLienteRazaoSocial;
         AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel = AV20TFTituloCLienteRazaoSocial_Sel;
         AV53Selecionartitulosds_4_tftitulovalor = AV21TFTituloValor;
         AV54Selecionartitulosds_5_tftitulovalor_to = AV22TFTituloValor_To;
         AV55Selecionartitulosds_6_tftitulodesconto = AV23TFTituloDesconto;
         AV56Selecionartitulosds_7_tftitulodesconto_to = AV24TFTituloDesconto_To;
         AV57Selecionartitulosds_8_tftituloprorrogacao = AV25TFTituloProrrogacao;
         AV58Selecionartitulosds_9_tftituloprorrogacao_to = AV26TFTituloProrrogacao_To;
         AV59Selecionartitulosds_10_tftitulopropostadescricao = AV30TFTituloPropostaDescricao;
         AV60Selecionartitulosds_11_tftitulopropostadescricao_sel = AV31TFTituloPropostaDescricao_Sel;
         AV61Selecionartitulosds_12_tfnotafiscalnumero = AV32TFNotaFiscalNumero;
         AV62Selecionartitulosds_13_tfnotafiscalnumero_sel = AV33TFNotaFiscalNumero_Sel;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV50Selecionartitulosds_1_filterfulltext ,
                                              AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel ,
                                              AV51Selecionartitulosds_2_tftituloclienterazaosocial ,
                                              AV53Selecionartitulosds_4_tftitulovalor ,
                                              AV54Selecionartitulosds_5_tftitulovalor_to ,
                                              AV55Selecionartitulosds_6_tftitulodesconto ,
                                              AV56Selecionartitulosds_7_tftitulodesconto_to ,
                                              AV57Selecionartitulosds_8_tftituloprorrogacao ,
                                              AV58Selecionartitulosds_9_tftituloprorrogacao_to ,
                                              AV60Selecionartitulosds_11_tftitulopropostadescricao_sel ,
                                              AV59Selecionartitulosds_10_tftitulopropostadescricao ,
                                              AV62Selecionartitulosds_13_tfnotafiscalnumero_sel ,
                                              AV61Selecionartitulosds_12_tfnotafiscalnumero ,
                                              A972TituloCLienteRazaoSocial ,
                                              A262TituloValor ,
                                              A276TituloDesconto ,
                                              A971TituloPropostaDescricao ,
                                              A799NotaFiscalNumero ,
                                              A264TituloProrrogacao ,
                                              AV12OrderedBy ,
                                              AV13OrderedDsc ,
                                              A1118TitulosEmCarteiraDeCobranca_F ,
                                              A261TituloId } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV50Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Selecionartitulosds_1_filterfulltext), "%", "");
         lV50Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Selecionartitulosds_1_filterfulltext), "%", "");
         lV50Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Selecionartitulosds_1_filterfulltext), "%", "");
         lV50Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Selecionartitulosds_1_filterfulltext), "%", "");
         lV50Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Selecionartitulosds_1_filterfulltext), "%", "");
         lV51Selecionartitulosds_2_tftituloclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV51Selecionartitulosds_2_tftituloclienterazaosocial), "%", "");
         lV59Selecionartitulosds_10_tftitulopropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV59Selecionartitulosds_10_tftitulopropostadescricao), "%", "");
         lV61Selecionartitulosds_12_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV61Selecionartitulosds_12_tfnotafiscalnumero), "%", "");
         /* Using cursor H00A511 */
         pr_default.execute(0, new Object[] {lV50Selecionartitulosds_1_filterfulltext, lV50Selecionartitulosds_1_filterfulltext, lV50Selecionartitulosds_1_filterfulltext, lV50Selecionartitulosds_1_filterfulltext, lV50Selecionartitulosds_1_filterfulltext, lV51Selecionartitulosds_2_tftituloclienterazaosocial, AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel, AV53Selecionartitulosds_4_tftitulovalor, AV54Selecionartitulosds_5_tftitulovalor_to, AV55Selecionartitulosds_6_tftitulodesconto, AV56Selecionartitulosds_7_tftitulodesconto_to, AV57Selecionartitulosds_8_tftituloprorrogacao, AV58Selecionartitulosds_9_tftituloprorrogacao_to, lV59Selecionartitulosds_10_tftitulopropostadescricao, AV60Selecionartitulosds_11_tftitulopropostadescricao_sel, lV61Selecionartitulosds_12_tfnotafiscalnumero, AV62Selecionartitulosds_13_tfnotafiscalnumero_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A794NotaFiscalId = H00A511_A794NotaFiscalId[0];
            n794NotaFiscalId = H00A511_n794NotaFiscalId[0];
            A938AgenciaId = H00A511_A938AgenciaId[0];
            n938AgenciaId = H00A511_n938AgenciaId[0];
            A968AgenciaBancoId = H00A511_A968AgenciaBancoId[0];
            n968AgenciaBancoId = H00A511_n968AgenciaBancoId[0];
            A939AgenciaNumero = H00A511_A939AgenciaNumero[0];
            n939AgenciaNumero = H00A511_n939AgenciaNumero[0];
            A952ContaBancariaNumero = H00A511_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = H00A511_n952ContaBancariaNumero[0];
            A953ContaBancariaCarteira = H00A511_A953ContaBancariaCarteira[0];
            n953ContaBancariaCarteira = H00A511_n953ContaBancariaCarteira[0];
            A969AgenciaBancoNome = H00A511_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = H00A511_n969AgenciaBancoNome[0];
            A951ContaBancariaId = H00A511_A951ContaBancariaId[0];
            n951ContaBancariaId = H00A511_n951ContaBancariaId[0];
            A799NotaFiscalNumero = H00A511_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = H00A511_n799NotaFiscalNumero[0];
            A890NotaFiscalParcelamentoID = H00A511_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = H00A511_n890NotaFiscalParcelamentoID[0];
            A648TituloPropostaTipo = H00A511_A648TituloPropostaTipo[0];
            n648TituloPropostaTipo = H00A511_n648TituloPropostaTipo[0];
            A426CategoriaTituloId = H00A511_A426CategoriaTituloId[0];
            n426CategoriaTituloId = H00A511_n426CategoriaTituloId[0];
            A500TituloCriacao = H00A511_A500TituloCriacao[0];
            n500TituloCriacao = H00A511_n500TituloCriacao[0];
            A422ContaId = H00A511_A422ContaId[0];
            n422ContaId = H00A511_n422ContaId[0];
            A501PropostaTaxaAdministrativa = H00A511_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = H00A511_n501PropostaTaxaAdministrativa[0];
            A971TituloPropostaDescricao = H00A511_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = H00A511_n971TituloPropostaDescricao[0];
            A419TituloPropostaId = H00A511_A419TituloPropostaId[0];
            n419TituloPropostaId = H00A511_n419TituloPropostaId[0];
            A498TituloJurosMora = H00A511_A498TituloJurosMora[0];
            n498TituloJurosMora = H00A511_n498TituloJurosMora[0];
            A269TituloMunicipio = H00A511_A269TituloMunicipio[0];
            n269TituloMunicipio = H00A511_n269TituloMunicipio[0];
            A268TituloBairro = H00A511_A268TituloBairro[0];
            n268TituloBairro = H00A511_n268TituloBairro[0];
            A267TituloComplemento = H00A511_A267TituloComplemento[0];
            n267TituloComplemento = H00A511_n267TituloComplemento[0];
            A294TituloNumeroEndereco = H00A511_A294TituloNumeroEndereco[0];
            n294TituloNumeroEndereco = H00A511_n294TituloNumeroEndereco[0];
            A266TituloLogradouro = H00A511_A266TituloLogradouro[0];
            n266TituloLogradouro = H00A511_n266TituloLogradouro[0];
            A265TituloCEP = H00A511_A265TituloCEP[0];
            n265TituloCEP = H00A511_n265TituloCEP[0];
            A264TituloProrrogacao = H00A511_A264TituloProrrogacao[0];
            n264TituloProrrogacao = H00A511_n264TituloProrrogacao[0];
            A263TituloVencimento = H00A511_A263TituloVencimento[0];
            n263TituloVencimento = H00A511_n263TituloVencimento[0];
            A314TituloArchived = H00A511_A314TituloArchived[0];
            n314TituloArchived = H00A511_n314TituloArchived[0];
            A284TituloDeleted = H00A511_A284TituloDeleted[0];
            n284TituloDeleted = H00A511_n284TituloDeleted[0];
            A972TituloCLienteRazaoSocial = H00A511_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = H00A511_n972TituloCLienteRazaoSocial[0];
            A420TituloClienteId = H00A511_A420TituloClienteId[0];
            n420TituloClienteId = H00A511_n420TituloClienteId[0];
            A261TituloId = H00A511_A261TituloId[0];
            n261TituloId = H00A511_n261TituloId[0];
            A1119TitulosCarteiraDeCobranca = H00A511_A1119TitulosCarteiraDeCobranca[0];
            n1119TitulosCarteiraDeCobranca = H00A511_n1119TitulosCarteiraDeCobranca[0];
            A307TituloTotalMultaJurosCredito_F = H00A511_A307TituloTotalMultaJurosCredito_F[0];
            n307TituloTotalMultaJurosCredito_F = H00A511_n307TituloTotalMultaJurosCredito_F[0];
            A306TituloTotalMultaJurosDebito_F = H00A511_A306TituloTotalMultaJurosDebito_F[0];
            n306TituloTotalMultaJurosDebito_F = H00A511_n306TituloTotalMultaJurosDebito_F[0];
            A305TituloTotalMovimentoCredito_F = H00A511_A305TituloTotalMovimentoCredito_F[0];
            n305TituloTotalMovimentoCredito_F = H00A511_n305TituloTotalMovimentoCredito_F[0];
            A304TituloTotalMovimentoDebito_F = H00A511_A304TituloTotalMovimentoDebito_F[0];
            n304TituloTotalMovimentoDebito_F = H00A511_n304TituloTotalMovimentoDebito_F[0];
            A301TituloTotalMultaJuros_F = H00A511_A301TituloTotalMultaJuros_F[0];
            n301TituloTotalMultaJuros_F = H00A511_n301TituloTotalMultaJuros_F[0];
            A516TituloDataCredito_F = H00A511_A516TituloDataCredito_F[0];
            n516TituloDataCredito_F = H00A511_n516TituloDataCredito_F[0];
            A286TituloCompetenciaAno = H00A511_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = H00A511_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = H00A511_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = H00A511_n287TituloCompetenciaMes[0];
            A273TituloTotalMovimento_F = H00A511_A273TituloTotalMovimento_F[0];
            A276TituloDesconto = H00A511_A276TituloDesconto[0];
            n276TituloDesconto = H00A511_n276TituloDesconto[0];
            A262TituloValor = H00A511_A262TituloValor[0];
            n262TituloValor = H00A511_n262TituloValor[0];
            A283TituloTipo = H00A511_A283TituloTipo[0];
            n283TituloTipo = H00A511_n283TituloTipo[0];
            A938AgenciaId = H00A511_A938AgenciaId[0];
            n938AgenciaId = H00A511_n938AgenciaId[0];
            A952ContaBancariaNumero = H00A511_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = H00A511_n952ContaBancariaNumero[0];
            A953ContaBancariaCarteira = H00A511_A953ContaBancariaCarteira[0];
            n953ContaBancariaCarteira = H00A511_n953ContaBancariaCarteira[0];
            A968AgenciaBancoId = H00A511_A968AgenciaBancoId[0];
            n968AgenciaBancoId = H00A511_n968AgenciaBancoId[0];
            A939AgenciaNumero = H00A511_A939AgenciaNumero[0];
            n939AgenciaNumero = H00A511_n939AgenciaNumero[0];
            A969AgenciaBancoNome = H00A511_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = H00A511_n969AgenciaBancoNome[0];
            A794NotaFiscalId = H00A511_A794NotaFiscalId[0];
            n794NotaFiscalId = H00A511_n794NotaFiscalId[0];
            A799NotaFiscalNumero = H00A511_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = H00A511_n799NotaFiscalNumero[0];
            A501PropostaTaxaAdministrativa = H00A511_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = H00A511_n501PropostaTaxaAdministrativa[0];
            A971TituloPropostaDescricao = H00A511_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = H00A511_n971TituloPropostaDescricao[0];
            A972TituloCLienteRazaoSocial = H00A511_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = H00A511_n972TituloCLienteRazaoSocial[0];
            A1119TitulosCarteiraDeCobranca = H00A511_A1119TitulosCarteiraDeCobranca[0];
            n1119TitulosCarteiraDeCobranca = H00A511_n1119TitulosCarteiraDeCobranca[0];
            A307TituloTotalMultaJurosCredito_F = H00A511_A307TituloTotalMultaJurosCredito_F[0];
            n307TituloTotalMultaJurosCredito_F = H00A511_n307TituloTotalMultaJurosCredito_F[0];
            A306TituloTotalMultaJurosDebito_F = H00A511_A306TituloTotalMultaJurosDebito_F[0];
            n306TituloTotalMultaJurosDebito_F = H00A511_n306TituloTotalMultaJurosDebito_F[0];
            A305TituloTotalMovimentoCredito_F = H00A511_A305TituloTotalMovimentoCredito_F[0];
            n305TituloTotalMovimentoCredito_F = H00A511_n305TituloTotalMovimentoCredito_F[0];
            A304TituloTotalMovimentoDebito_F = H00A511_A304TituloTotalMovimentoDebito_F[0];
            n304TituloTotalMovimentoDebito_F = H00A511_n304TituloTotalMovimentoDebito_F[0];
            A273TituloTotalMovimento_F = H00A511_A273TituloTotalMovimento_F[0];
            A301TituloTotalMultaJuros_F = H00A511_A301TituloTotalMultaJuros_F[0];
            n301TituloTotalMultaJuros_F = H00A511_n301TituloTotalMultaJuros_F[0];
            A516TituloDataCredito_F = H00A511_A516TituloDataCredito_F[0];
            n516TituloDataCredito_F = H00A511_n516TituloDataCredito_F[0];
            A302TituloSaldoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
            A303TituloSaldoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
            A275TituloSaldo_F = (decimal)((A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F);
            A282TituloStatus_F = ((Convert.ToDecimal(0)==A275TituloSaldo_F) ? "Liquidado" : ((A275TituloSaldo_F==A262TituloValor) ? "Aberto" : "Baixado parcialmente"));
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            A1118TitulosEmCarteiraDeCobranca_F = ((GetTitulosEmCarteiraDeCobranca_F0( A261TituloId)==0) ? false : true);
            if ( ! A1118TitulosEmCarteiraDeCobranca_F )
            {
               GRID_nRecordCount = (long)(GRID_nRecordCount+1);
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RFA52( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E18A52 ();
         nGXsfl_37_idx = 1;
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         bGXsfl_37_Refreshing = true;
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
            SubsflControlProps_372( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV50Selecionartitulosds_1_filterfulltext ,
                                                 AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel ,
                                                 AV51Selecionartitulosds_2_tftituloclienterazaosocial ,
                                                 AV53Selecionartitulosds_4_tftitulovalor ,
                                                 AV54Selecionartitulosds_5_tftitulovalor_to ,
                                                 AV55Selecionartitulosds_6_tftitulodesconto ,
                                                 AV56Selecionartitulosds_7_tftitulodesconto_to ,
                                                 AV57Selecionartitulosds_8_tftituloprorrogacao ,
                                                 AV58Selecionartitulosds_9_tftituloprorrogacao_to ,
                                                 AV60Selecionartitulosds_11_tftitulopropostadescricao_sel ,
                                                 AV59Selecionartitulosds_10_tftitulopropostadescricao ,
                                                 AV62Selecionartitulosds_13_tfnotafiscalnumero_sel ,
                                                 AV61Selecionartitulosds_12_tfnotafiscalnumero ,
                                                 A972TituloCLienteRazaoSocial ,
                                                 A262TituloValor ,
                                                 A276TituloDesconto ,
                                                 A971TituloPropostaDescricao ,
                                                 A799NotaFiscalNumero ,
                                                 A264TituloProrrogacao ,
                                                 AV12OrderedBy ,
                                                 AV13OrderedDsc ,
                                                 A1118TitulosEmCarteiraDeCobranca_F ,
                                                 A261TituloId } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                                 }
            });
            lV50Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Selecionartitulosds_1_filterfulltext), "%", "");
            lV50Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Selecionartitulosds_1_filterfulltext), "%", "");
            lV50Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Selecionartitulosds_1_filterfulltext), "%", "");
            lV50Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Selecionartitulosds_1_filterfulltext), "%", "");
            lV50Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Selecionartitulosds_1_filterfulltext), "%", "");
            lV51Selecionartitulosds_2_tftituloclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV51Selecionartitulosds_2_tftituloclienterazaosocial), "%", "");
            lV59Selecionartitulosds_10_tftitulopropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV59Selecionartitulosds_10_tftitulopropostadescricao), "%", "");
            lV61Selecionartitulosds_12_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV61Selecionartitulosds_12_tfnotafiscalnumero), "%", "");
            /* Using cursor H00A521 */
            pr_default.execute(1, new Object[] {lV50Selecionartitulosds_1_filterfulltext, lV50Selecionartitulosds_1_filterfulltext, lV50Selecionartitulosds_1_filterfulltext, lV50Selecionartitulosds_1_filterfulltext, lV50Selecionartitulosds_1_filterfulltext, lV51Selecionartitulosds_2_tftituloclienterazaosocial, AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel, AV53Selecionartitulosds_4_tftitulovalor, AV54Selecionartitulosds_5_tftitulovalor_to, AV55Selecionartitulosds_6_tftitulodesconto, AV56Selecionartitulosds_7_tftitulodesconto_to, AV57Selecionartitulosds_8_tftituloprorrogacao, AV58Selecionartitulosds_9_tftituloprorrogacao_to, lV59Selecionartitulosds_10_tftitulopropostadescricao, AV60Selecionartitulosds_11_tftitulopropostadescricao_sel, lV61Selecionartitulosds_12_tfnotafiscalnumero, AV62Selecionartitulosds_13_tfnotafiscalnumero_sel});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A794NotaFiscalId = H00A521_A794NotaFiscalId[0];
               n794NotaFiscalId = H00A521_n794NotaFiscalId[0];
               A938AgenciaId = H00A521_A938AgenciaId[0];
               n938AgenciaId = H00A521_n938AgenciaId[0];
               A968AgenciaBancoId = H00A521_A968AgenciaBancoId[0];
               n968AgenciaBancoId = H00A521_n968AgenciaBancoId[0];
               A939AgenciaNumero = H00A521_A939AgenciaNumero[0];
               n939AgenciaNumero = H00A521_n939AgenciaNumero[0];
               A952ContaBancariaNumero = H00A521_A952ContaBancariaNumero[0];
               n952ContaBancariaNumero = H00A521_n952ContaBancariaNumero[0];
               A953ContaBancariaCarteira = H00A521_A953ContaBancariaCarteira[0];
               n953ContaBancariaCarteira = H00A521_n953ContaBancariaCarteira[0];
               A969AgenciaBancoNome = H00A521_A969AgenciaBancoNome[0];
               n969AgenciaBancoNome = H00A521_n969AgenciaBancoNome[0];
               A951ContaBancariaId = H00A521_A951ContaBancariaId[0];
               n951ContaBancariaId = H00A521_n951ContaBancariaId[0];
               A799NotaFiscalNumero = H00A521_A799NotaFiscalNumero[0];
               n799NotaFiscalNumero = H00A521_n799NotaFiscalNumero[0];
               A890NotaFiscalParcelamentoID = H00A521_A890NotaFiscalParcelamentoID[0];
               n890NotaFiscalParcelamentoID = H00A521_n890NotaFiscalParcelamentoID[0];
               A648TituloPropostaTipo = H00A521_A648TituloPropostaTipo[0];
               n648TituloPropostaTipo = H00A521_n648TituloPropostaTipo[0];
               A426CategoriaTituloId = H00A521_A426CategoriaTituloId[0];
               n426CategoriaTituloId = H00A521_n426CategoriaTituloId[0];
               A500TituloCriacao = H00A521_A500TituloCriacao[0];
               n500TituloCriacao = H00A521_n500TituloCriacao[0];
               A422ContaId = H00A521_A422ContaId[0];
               n422ContaId = H00A521_n422ContaId[0];
               A501PropostaTaxaAdministrativa = H00A521_A501PropostaTaxaAdministrativa[0];
               n501PropostaTaxaAdministrativa = H00A521_n501PropostaTaxaAdministrativa[0];
               A971TituloPropostaDescricao = H00A521_A971TituloPropostaDescricao[0];
               n971TituloPropostaDescricao = H00A521_n971TituloPropostaDescricao[0];
               A419TituloPropostaId = H00A521_A419TituloPropostaId[0];
               n419TituloPropostaId = H00A521_n419TituloPropostaId[0];
               A498TituloJurosMora = H00A521_A498TituloJurosMora[0];
               n498TituloJurosMora = H00A521_n498TituloJurosMora[0];
               A269TituloMunicipio = H00A521_A269TituloMunicipio[0];
               n269TituloMunicipio = H00A521_n269TituloMunicipio[0];
               A268TituloBairro = H00A521_A268TituloBairro[0];
               n268TituloBairro = H00A521_n268TituloBairro[0];
               A267TituloComplemento = H00A521_A267TituloComplemento[0];
               n267TituloComplemento = H00A521_n267TituloComplemento[0];
               A294TituloNumeroEndereco = H00A521_A294TituloNumeroEndereco[0];
               n294TituloNumeroEndereco = H00A521_n294TituloNumeroEndereco[0];
               A266TituloLogradouro = H00A521_A266TituloLogradouro[0];
               n266TituloLogradouro = H00A521_n266TituloLogradouro[0];
               A265TituloCEP = H00A521_A265TituloCEP[0];
               n265TituloCEP = H00A521_n265TituloCEP[0];
               A264TituloProrrogacao = H00A521_A264TituloProrrogacao[0];
               n264TituloProrrogacao = H00A521_n264TituloProrrogacao[0];
               A263TituloVencimento = H00A521_A263TituloVencimento[0];
               n263TituloVencimento = H00A521_n263TituloVencimento[0];
               A314TituloArchived = H00A521_A314TituloArchived[0];
               n314TituloArchived = H00A521_n314TituloArchived[0];
               A284TituloDeleted = H00A521_A284TituloDeleted[0];
               n284TituloDeleted = H00A521_n284TituloDeleted[0];
               A972TituloCLienteRazaoSocial = H00A521_A972TituloCLienteRazaoSocial[0];
               n972TituloCLienteRazaoSocial = H00A521_n972TituloCLienteRazaoSocial[0];
               A420TituloClienteId = H00A521_A420TituloClienteId[0];
               n420TituloClienteId = H00A521_n420TituloClienteId[0];
               A261TituloId = H00A521_A261TituloId[0];
               n261TituloId = H00A521_n261TituloId[0];
               A1119TitulosCarteiraDeCobranca = H00A521_A1119TitulosCarteiraDeCobranca[0];
               n1119TitulosCarteiraDeCobranca = H00A521_n1119TitulosCarteiraDeCobranca[0];
               A307TituloTotalMultaJurosCredito_F = H00A521_A307TituloTotalMultaJurosCredito_F[0];
               n307TituloTotalMultaJurosCredito_F = H00A521_n307TituloTotalMultaJurosCredito_F[0];
               A306TituloTotalMultaJurosDebito_F = H00A521_A306TituloTotalMultaJurosDebito_F[0];
               n306TituloTotalMultaJurosDebito_F = H00A521_n306TituloTotalMultaJurosDebito_F[0];
               A305TituloTotalMovimentoCredito_F = H00A521_A305TituloTotalMovimentoCredito_F[0];
               n305TituloTotalMovimentoCredito_F = H00A521_n305TituloTotalMovimentoCredito_F[0];
               A304TituloTotalMovimentoDebito_F = H00A521_A304TituloTotalMovimentoDebito_F[0];
               n304TituloTotalMovimentoDebito_F = H00A521_n304TituloTotalMovimentoDebito_F[0];
               A301TituloTotalMultaJuros_F = H00A521_A301TituloTotalMultaJuros_F[0];
               n301TituloTotalMultaJuros_F = H00A521_n301TituloTotalMultaJuros_F[0];
               A516TituloDataCredito_F = H00A521_A516TituloDataCredito_F[0];
               n516TituloDataCredito_F = H00A521_n516TituloDataCredito_F[0];
               A286TituloCompetenciaAno = H00A521_A286TituloCompetenciaAno[0];
               n286TituloCompetenciaAno = H00A521_n286TituloCompetenciaAno[0];
               A287TituloCompetenciaMes = H00A521_A287TituloCompetenciaMes[0];
               n287TituloCompetenciaMes = H00A521_n287TituloCompetenciaMes[0];
               A273TituloTotalMovimento_F = H00A521_A273TituloTotalMovimento_F[0];
               A276TituloDesconto = H00A521_A276TituloDesconto[0];
               n276TituloDesconto = H00A521_n276TituloDesconto[0];
               A262TituloValor = H00A521_A262TituloValor[0];
               n262TituloValor = H00A521_n262TituloValor[0];
               A283TituloTipo = H00A521_A283TituloTipo[0];
               n283TituloTipo = H00A521_n283TituloTipo[0];
               A938AgenciaId = H00A521_A938AgenciaId[0];
               n938AgenciaId = H00A521_n938AgenciaId[0];
               A952ContaBancariaNumero = H00A521_A952ContaBancariaNumero[0];
               n952ContaBancariaNumero = H00A521_n952ContaBancariaNumero[0];
               A953ContaBancariaCarteira = H00A521_A953ContaBancariaCarteira[0];
               n953ContaBancariaCarteira = H00A521_n953ContaBancariaCarteira[0];
               A968AgenciaBancoId = H00A521_A968AgenciaBancoId[0];
               n968AgenciaBancoId = H00A521_n968AgenciaBancoId[0];
               A939AgenciaNumero = H00A521_A939AgenciaNumero[0];
               n939AgenciaNumero = H00A521_n939AgenciaNumero[0];
               A969AgenciaBancoNome = H00A521_A969AgenciaBancoNome[0];
               n969AgenciaBancoNome = H00A521_n969AgenciaBancoNome[0];
               A794NotaFiscalId = H00A521_A794NotaFiscalId[0];
               n794NotaFiscalId = H00A521_n794NotaFiscalId[0];
               A799NotaFiscalNumero = H00A521_A799NotaFiscalNumero[0];
               n799NotaFiscalNumero = H00A521_n799NotaFiscalNumero[0];
               A501PropostaTaxaAdministrativa = H00A521_A501PropostaTaxaAdministrativa[0];
               n501PropostaTaxaAdministrativa = H00A521_n501PropostaTaxaAdministrativa[0];
               A971TituloPropostaDescricao = H00A521_A971TituloPropostaDescricao[0];
               n971TituloPropostaDescricao = H00A521_n971TituloPropostaDescricao[0];
               A972TituloCLienteRazaoSocial = H00A521_A972TituloCLienteRazaoSocial[0];
               n972TituloCLienteRazaoSocial = H00A521_n972TituloCLienteRazaoSocial[0];
               A1119TitulosCarteiraDeCobranca = H00A521_A1119TitulosCarteiraDeCobranca[0];
               n1119TitulosCarteiraDeCobranca = H00A521_n1119TitulosCarteiraDeCobranca[0];
               A307TituloTotalMultaJurosCredito_F = H00A521_A307TituloTotalMultaJurosCredito_F[0];
               n307TituloTotalMultaJurosCredito_F = H00A521_n307TituloTotalMultaJurosCredito_F[0];
               A306TituloTotalMultaJurosDebito_F = H00A521_A306TituloTotalMultaJurosDebito_F[0];
               n306TituloTotalMultaJurosDebito_F = H00A521_n306TituloTotalMultaJurosDebito_F[0];
               A305TituloTotalMovimentoCredito_F = H00A521_A305TituloTotalMovimentoCredito_F[0];
               n305TituloTotalMovimentoCredito_F = H00A521_n305TituloTotalMovimentoCredito_F[0];
               A304TituloTotalMovimentoDebito_F = H00A521_A304TituloTotalMovimentoDebito_F[0];
               n304TituloTotalMovimentoDebito_F = H00A521_n304TituloTotalMovimentoDebito_F[0];
               A273TituloTotalMovimento_F = H00A521_A273TituloTotalMovimento_F[0];
               A301TituloTotalMultaJuros_F = H00A521_A301TituloTotalMultaJuros_F[0];
               n301TituloTotalMultaJuros_F = H00A521_n301TituloTotalMultaJuros_F[0];
               A516TituloDataCredito_F = H00A521_A516TituloDataCredito_F[0];
               n516TituloDataCredito_F = H00A521_n516TituloDataCredito_F[0];
               A302TituloSaldoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
               A303TituloSaldoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
               A275TituloSaldo_F = (decimal)((A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F);
               A282TituloStatus_F = ((Convert.ToDecimal(0)==A275TituloSaldo_F) ? "Liquidado" : ((A275TituloSaldo_F==A262TituloValor) ? "Aberto" : "Baixado parcialmente"));
               A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
               A1118TitulosEmCarteiraDeCobranca_F = ((GetTitulosEmCarteiraDeCobranca_F0( A261TituloId)==0) ? false : true);
               if ( ! A1118TitulosEmCarteiraDeCobranca_F )
               {
                  /* Execute user event: Grid.Load */
                  E19A52 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 37;
            WBA50( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesA52( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV49Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV49Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, context.localUtil.Format( (decimal)(A261TituloId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOCLIENTEID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, context.localUtil.Format( (decimal)(A420TituloClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOVALOR"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, context.localUtil.Format( A262TituloValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULODESCONTO"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, context.localUtil.Format( A276TituloDesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULODELETED"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, A284TituloDeleted, context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOARCHIVED"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, A314TituloArchived, context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOVENCIMENTO"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, A263TituloVencimento, context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOCOMPETENCIAANO"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, context.localUtil.Format( (decimal)(A286TituloCompetenciaAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOCOMPETENCIAMES"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, context.localUtil.Format( (decimal)(A287TituloCompetenciaMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOCOMPETENCIA_F"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, StringUtil.RTrim( context.localUtil.Format( A295TituloCompetencia_F, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOPRORROGACAO"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, A264TituloProrrogacao, context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOCEP"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, StringUtil.RTrim( context.localUtil.Format( A265TituloCEP, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOLOGRADOURO"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, StringUtil.RTrim( context.localUtil.Format( A266TituloLogradouro, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULONUMEROENDERECO"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, StringUtil.RTrim( context.localUtil.Format( A294TituloNumeroEndereco, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOCOMPLEMENTO"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, StringUtil.RTrim( context.localUtil.Format( A267TituloComplemento, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOBAIRRO"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, StringUtil.RTrim( context.localUtil.Format( A268TituloBairro, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOMUNICIPIO"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, StringUtil.RTrim( context.localUtil.Format( A269TituloMunicipio, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOJUROSMORA"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, context.localUtil.Format( A498TituloJurosMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOTIPO"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, StringUtil.RTrim( context.localUtil.Format( A283TituloTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOPROPOSTAID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, context.localUtil.Format( (decimal)(A419TituloPropostaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CONTAID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, context.localUtil.Format( (decimal)(A422ContaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOCRIACAO"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, context.localUtil.Format( A500TituloCriacao, "99/99/99 99:99"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CATEGORIATITULOID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, context.localUtil.Format( (decimal)(A426CategoriaTituloId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOSALDO_F"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, context.localUtil.Format( A275TituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOSTATUS_F"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, StringUtil.RTrim( context.localUtil.Format( A282TituloStatus_F, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOSALDODEBITO_F"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, context.localUtil.Format( A302TituloSaldoDebito_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOSALDOCREDITO_F"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, context.localUtil.Format( A303TituloSaldoCredito_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOPROPOSTATIPO"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, StringUtil.RTrim( context.localUtil.Format( A648TituloPropostaTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_NOTAFISCALPARCELAMENTOID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, A890NotaFiscalParcelamentoID, context));
         GxWebStd.gx_hidden_field( context, "gxhash_CONTABANCARIAID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, context.localUtil.Format( (decimal)(A951ContaBancariaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOSEMCARTEIRADECOBRANCA_F"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, A1118TitulosEmCarteiraDeCobranca_F, context));
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
         AV50Selecionartitulosds_1_filterfulltext = AV14FilterFullText;
         AV51Selecionartitulosds_2_tftituloclienterazaosocial = AV19TFTituloCLienteRazaoSocial;
         AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel = AV20TFTituloCLienteRazaoSocial_Sel;
         AV53Selecionartitulosds_4_tftitulovalor = AV21TFTituloValor;
         AV54Selecionartitulosds_5_tftitulovalor_to = AV22TFTituloValor_To;
         AV55Selecionartitulosds_6_tftitulodesconto = AV23TFTituloDesconto;
         AV56Selecionartitulosds_7_tftitulodesconto_to = AV24TFTituloDesconto_To;
         AV57Selecionartitulosds_8_tftituloprorrogacao = AV25TFTituloProrrogacao;
         AV58Selecionartitulosds_9_tftituloprorrogacao_to = AV26TFTituloProrrogacao_To;
         AV59Selecionartitulosds_10_tftitulopropostadescricao = AV30TFTituloPropostaDescricao;
         AV60Selecionartitulosds_11_tftitulopropostadescricao_sel = AV31TFTituloPropostaDescricao_Sel;
         AV61Selecionartitulosds_12_tfnotafiscalnumero = AV32TFNotaFiscalNumero;
         AV62Selecionartitulosds_13_tfnotafiscalnumero_sel = AV33TFNotaFiscalNumero_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV18ManageFiltersExecutionStep, AV49Pgmname, AV44TituloIdJson, AV19TFTituloCLienteRazaoSocial, AV20TFTituloCLienteRazaoSocial_Sel, AV21TFTituloValor, AV22TFTituloValor_To, AV23TFTituloDesconto, AV24TFTituloDesconto_To, AV25TFTituloProrrogacao, AV26TFTituloProrrogacao_To, AV30TFTituloPropostaDescricao, AV31TFTituloPropostaDescricao_Sel, AV32TFNotaFiscalNumero, AV33TFNotaFiscalNumero_Sel, AV48CarteiraDeCobrancaId, AV42i, AV43TituloIdCol, AV46TituloIdToFind, AV47SelectAll) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV50Selecionartitulosds_1_filterfulltext = AV14FilterFullText;
         AV51Selecionartitulosds_2_tftituloclienterazaosocial = AV19TFTituloCLienteRazaoSocial;
         AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel = AV20TFTituloCLienteRazaoSocial_Sel;
         AV53Selecionartitulosds_4_tftitulovalor = AV21TFTituloValor;
         AV54Selecionartitulosds_5_tftitulovalor_to = AV22TFTituloValor_To;
         AV55Selecionartitulosds_6_tftitulodesconto = AV23TFTituloDesconto;
         AV56Selecionartitulosds_7_tftitulodesconto_to = AV24TFTituloDesconto_To;
         AV57Selecionartitulosds_8_tftituloprorrogacao = AV25TFTituloProrrogacao;
         AV58Selecionartitulosds_9_tftituloprorrogacao_to = AV26TFTituloProrrogacao_To;
         AV59Selecionartitulosds_10_tftitulopropostadescricao = AV30TFTituloPropostaDescricao;
         AV60Selecionartitulosds_11_tftitulopropostadescricao_sel = AV31TFTituloPropostaDescricao_Sel;
         AV61Selecionartitulosds_12_tfnotafiscalnumero = AV32TFNotaFiscalNumero;
         AV62Selecionartitulosds_13_tfnotafiscalnumero_sel = AV33TFNotaFiscalNumero_Sel;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV18ManageFiltersExecutionStep, AV49Pgmname, AV44TituloIdJson, AV19TFTituloCLienteRazaoSocial, AV20TFTituloCLienteRazaoSocial_Sel, AV21TFTituloValor, AV22TFTituloValor_To, AV23TFTituloDesconto, AV24TFTituloDesconto_To, AV25TFTituloProrrogacao, AV26TFTituloProrrogacao_To, AV30TFTituloPropostaDescricao, AV31TFTituloPropostaDescricao_Sel, AV32TFNotaFiscalNumero, AV33TFNotaFiscalNumero_Sel, AV48CarteiraDeCobrancaId, AV42i, AV43TituloIdCol, AV46TituloIdToFind, AV47SelectAll) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV50Selecionartitulosds_1_filterfulltext = AV14FilterFullText;
         AV51Selecionartitulosds_2_tftituloclienterazaosocial = AV19TFTituloCLienteRazaoSocial;
         AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel = AV20TFTituloCLienteRazaoSocial_Sel;
         AV53Selecionartitulosds_4_tftitulovalor = AV21TFTituloValor;
         AV54Selecionartitulosds_5_tftitulovalor_to = AV22TFTituloValor_To;
         AV55Selecionartitulosds_6_tftitulodesconto = AV23TFTituloDesconto;
         AV56Selecionartitulosds_7_tftitulodesconto_to = AV24TFTituloDesconto_To;
         AV57Selecionartitulosds_8_tftituloprorrogacao = AV25TFTituloProrrogacao;
         AV58Selecionartitulosds_9_tftituloprorrogacao_to = AV26TFTituloProrrogacao_To;
         AV59Selecionartitulosds_10_tftitulopropostadescricao = AV30TFTituloPropostaDescricao;
         AV60Selecionartitulosds_11_tftitulopropostadescricao_sel = AV31TFTituloPropostaDescricao_Sel;
         AV61Selecionartitulosds_12_tfnotafiscalnumero = AV32TFNotaFiscalNumero;
         AV62Selecionartitulosds_13_tfnotafiscalnumero_sel = AV33TFNotaFiscalNumero_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV18ManageFiltersExecutionStep, AV49Pgmname, AV44TituloIdJson, AV19TFTituloCLienteRazaoSocial, AV20TFTituloCLienteRazaoSocial_Sel, AV21TFTituloValor, AV22TFTituloValor_To, AV23TFTituloDesconto, AV24TFTituloDesconto_To, AV25TFTituloProrrogacao, AV26TFTituloProrrogacao_To, AV30TFTituloPropostaDescricao, AV31TFTituloPropostaDescricao_Sel, AV32TFNotaFiscalNumero, AV33TFNotaFiscalNumero_Sel, AV48CarteiraDeCobrancaId, AV42i, AV43TituloIdCol, AV46TituloIdToFind, AV47SelectAll) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV50Selecionartitulosds_1_filterfulltext = AV14FilterFullText;
         AV51Selecionartitulosds_2_tftituloclienterazaosocial = AV19TFTituloCLienteRazaoSocial;
         AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel = AV20TFTituloCLienteRazaoSocial_Sel;
         AV53Selecionartitulosds_4_tftitulovalor = AV21TFTituloValor;
         AV54Selecionartitulosds_5_tftitulovalor_to = AV22TFTituloValor_To;
         AV55Selecionartitulosds_6_tftitulodesconto = AV23TFTituloDesconto;
         AV56Selecionartitulosds_7_tftitulodesconto_to = AV24TFTituloDesconto_To;
         AV57Selecionartitulosds_8_tftituloprorrogacao = AV25TFTituloProrrogacao;
         AV58Selecionartitulosds_9_tftituloprorrogacao_to = AV26TFTituloProrrogacao_To;
         AV59Selecionartitulosds_10_tftitulopropostadescricao = AV30TFTituloPropostaDescricao;
         AV60Selecionartitulosds_11_tftitulopropostadescricao_sel = AV31TFTituloPropostaDescricao_Sel;
         AV61Selecionartitulosds_12_tfnotafiscalnumero = AV32TFNotaFiscalNumero;
         AV62Selecionartitulosds_13_tfnotafiscalnumero_sel = AV33TFNotaFiscalNumero_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV18ManageFiltersExecutionStep, AV49Pgmname, AV44TituloIdJson, AV19TFTituloCLienteRazaoSocial, AV20TFTituloCLienteRazaoSocial_Sel, AV21TFTituloValor, AV22TFTituloValor_To, AV23TFTituloDesconto, AV24TFTituloDesconto_To, AV25TFTituloProrrogacao, AV26TFTituloProrrogacao_To, AV30TFTituloPropostaDescricao, AV31TFTituloPropostaDescricao_Sel, AV32TFNotaFiscalNumero, AV33TFNotaFiscalNumero_Sel, AV48CarteiraDeCobrancaId, AV42i, AV43TituloIdCol, AV46TituloIdToFind, AV47SelectAll) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV50Selecionartitulosds_1_filterfulltext = AV14FilterFullText;
         AV51Selecionartitulosds_2_tftituloclienterazaosocial = AV19TFTituloCLienteRazaoSocial;
         AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel = AV20TFTituloCLienteRazaoSocial_Sel;
         AV53Selecionartitulosds_4_tftitulovalor = AV21TFTituloValor;
         AV54Selecionartitulosds_5_tftitulovalor_to = AV22TFTituloValor_To;
         AV55Selecionartitulosds_6_tftitulodesconto = AV23TFTituloDesconto;
         AV56Selecionartitulosds_7_tftitulodesconto_to = AV24TFTituloDesconto_To;
         AV57Selecionartitulosds_8_tftituloprorrogacao = AV25TFTituloProrrogacao;
         AV58Selecionartitulosds_9_tftituloprorrogacao_to = AV26TFTituloProrrogacao_To;
         AV59Selecionartitulosds_10_tftitulopropostadescricao = AV30TFTituloPropostaDescricao;
         AV60Selecionartitulosds_11_tftitulopropostadescricao_sel = AV31TFTituloPropostaDescricao_Sel;
         AV61Selecionartitulosds_12_tfnotafiscalnumero = AV32TFNotaFiscalNumero;
         AV62Selecionartitulosds_13_tfnotafiscalnumero_sel = AV33TFNotaFiscalNumero_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV18ManageFiltersExecutionStep, AV49Pgmname, AV44TituloIdJson, AV19TFTituloCLienteRazaoSocial, AV20TFTituloCLienteRazaoSocial_Sel, AV21TFTituloValor, AV22TFTituloValor_To, AV23TFTituloDesconto, AV24TFTituloDesconto_To, AV25TFTituloProrrogacao, AV26TFTituloProrrogacao_To, AV30TFTituloPropostaDescricao, AV31TFTituloPropostaDescricao_Sel, AV32TFNotaFiscalNumero, AV33TFNotaFiscalNumero_Sel, AV48CarteiraDeCobrancaId, AV42i, AV43TituloIdCol, AV46TituloIdToFind, AV47SelectAll) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV49Pgmname = "SelecionarTitulos";
         edtTituloId_Enabled = 0;
         edtTituloClienteId_Enabled = 0;
         edtTituloCLienteRazaoSocial_Enabled = 0;
         edtTituloValor_Enabled = 0;
         edtTituloDesconto_Enabled = 0;
         chkTituloDeleted.Enabled = 0;
         chkTituloArchived.Enabled = 0;
         edtTituloVencimento_Enabled = 0;
         edtTituloCompetenciaAno_Enabled = 0;
         edtTituloCompetenciaMes_Enabled = 0;
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
         edtTituloPropostaDescricao_Enabled = 0;
         edtPropostaTaxaAdministrativa_Enabled = 0;
         edtContaId_Enabled = 0;
         edtTituloCriacao_Enabled = 0;
         edtCategoriaTituloId_Enabled = 0;
         edtTituloDataCredito_F_Enabled = 0;
         edtTituloTotalMovimento_F_Enabled = 0;
         edtTituloTotalMultaJuros_F_Enabled = 0;
         edtTituloSaldo_F_Enabled = 0;
         edtTituloStatus_F_Enabled = 0;
         edtTituloSaldoDebito_F_Enabled = 0;
         edtTituloSaldoCredito_F_Enabled = 0;
         edtTituloTotalMovimentoDebito_F_Enabled = 0;
         edtTituloTotalMovimentoCredito_F_Enabled = 0;
         edtTituloTotalMultaJurosDebito_F_Enabled = 0;
         edtTituloTotalMultaJurosCredito_F_Enabled = 0;
         cmbTituloPropostaTipo.Enabled = 0;
         edtNotaFiscalParcelamentoID_Enabled = 0;
         edtNotaFiscalNumero_Enabled = 0;
         edtContaBancariaId_Enabled = 0;
         edtAgenciaBancoNome_Enabled = 0;
         edtContaBancariaCarteira_Enabled = 0;
         edtContaBancariaNumero_Enabled = 0;
         edtAgenciaNumero_Enabled = 0;
         chkTitulosEmCarteiraDeCobranca_F.Enabled = 0;
         edtTitulosCarteiraDeCobranca_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPA50( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17A52 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV16ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV34DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_37"), ",", "."), 18, MidpointRounding.ToEven));
            AV36GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV37GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV38GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV27DDO_TituloProrrogacaoAuxDate = context.localUtil.CToD( cgiGet( "vDDO_TITULOPRORROGACAOAUXDATE"), 0);
            AV28DDO_TituloProrrogacaoAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_TITULOPRORROGACAOAUXDATETO"), 0);
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
            AV14FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
            AV47SelectAll = StringUtil.StrToBool( cgiGet( chkavSelectall_Internalname));
            AssignAttri("", false, "AV47SelectAll", AV47SelectAll);
            AV29DDO_TituloProrrogacaoAuxDateText = cgiGet( edtavDdo_tituloprorrogacaoauxdatetext_Internalname);
            AssignAttri("", false, "AV29DDO_TituloProrrogacaoAuxDateText", AV29DDO_TituloProrrogacaoAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV12OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV13OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV14FilterFullText) != 0 )
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
         E17A52 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E17A52( )
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
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = " Titulo";
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
         if ( AV12OrderedBy < 1 )
         {
            AV12OrderedBy = 1;
            AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         chkavSelected_Titleformat = 1;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV34DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV34DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E18A52( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV18ManageFiltersExecutionStep == 1 )
         {
            AV18ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV18ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV18ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV18ManageFiltersExecutionStep == 2 )
         {
            AV18ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV18ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV18ManageFiltersExecutionStep), 1, 0));
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
         chkavSelected.Title.Text = StringUtil.Format( "<input name=\"selectAllCheckbox\" type=\"checkbox\" value=\"Select All\" onchange=\"$(%1).click();\" class=\"AttributeCheckBox\" >", "'#"+chkavSelectall_Internalname+"'", "", "", "", "", "", "", "", "");
         AssignProp("", false, chkavSelected_Internalname, "Title", chkavSelected.Title.Text, !bGXsfl_37_Refreshing);
         AV47SelectAll = false;
         AssignAttri("", false, "AV47SelectAll", AV47SelectAll);
         AV36GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV36GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV36GridCurrentPage), 10, 0));
         AV37GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV37GridPageCount", StringUtil.LTrimStr( (decimal)(AV37GridPageCount), 10, 0));
         GXt_char2 = AV38GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV49Pgmname, out  GXt_char2) ;
         AV38GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV38GridAppliedFilters", AV38GridAppliedFilters);
         AV43TituloIdCol.FromJSonString(AV44TituloIdJson, null);
         AV50Selecionartitulosds_1_filterfulltext = AV14FilterFullText;
         AV51Selecionartitulosds_2_tftituloclienterazaosocial = AV19TFTituloCLienteRazaoSocial;
         AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel = AV20TFTituloCLienteRazaoSocial_Sel;
         AV53Selecionartitulosds_4_tftitulovalor = AV21TFTituloValor;
         AV54Selecionartitulosds_5_tftitulovalor_to = AV22TFTituloValor_To;
         AV55Selecionartitulosds_6_tftitulodesconto = AV23TFTituloDesconto;
         AV56Selecionartitulosds_7_tftitulodesconto_to = AV24TFTituloDesconto_To;
         AV57Selecionartitulosds_8_tftituloprorrogacao = AV25TFTituloProrrogacao;
         AV58Selecionartitulosds_9_tftituloprorrogacao_to = AV26TFTituloProrrogacao_To;
         AV59Selecionartitulosds_10_tftitulopropostadescricao = AV30TFTituloPropostaDescricao;
         AV60Selecionartitulosds_11_tftitulopropostadescricao_sel = AV31TFTituloPropostaDescricao_Sel;
         AV61Selecionartitulosds_12_tfnotafiscalnumero = AV32TFNotaFiscalNumero;
         AV62Selecionartitulosds_13_tfnotafiscalnumero_sel = AV33TFNotaFiscalNumero_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43TituloIdCol", AV43TituloIdCol);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16ManageFiltersData", AV16ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E12A52( )
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
            AV35PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV35PageToGo) ;
         }
      }

      protected void E13A52( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14A52( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV12OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            AV13OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloCLienteRazaoSocial") == 0 )
            {
               AV19TFTituloCLienteRazaoSocial = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV19TFTituloCLienteRazaoSocial", AV19TFTituloCLienteRazaoSocial);
               AV20TFTituloCLienteRazaoSocial_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV20TFTituloCLienteRazaoSocial_Sel", AV20TFTituloCLienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloValor") == 0 )
            {
               AV21TFTituloValor = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV21TFTituloValor", StringUtil.LTrimStr( AV21TFTituloValor, 18, 2));
               AV22TFTituloValor_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV22TFTituloValor_To", StringUtil.LTrimStr( AV22TFTituloValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloDesconto") == 0 )
            {
               AV23TFTituloDesconto = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV23TFTituloDesconto", StringUtil.LTrimStr( AV23TFTituloDesconto, 18, 2));
               AV24TFTituloDesconto_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV24TFTituloDesconto_To", StringUtil.LTrimStr( AV24TFTituloDesconto_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloProrrogacao") == 0 )
            {
               AV25TFTituloProrrogacao = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV25TFTituloProrrogacao", context.localUtil.Format(AV25TFTituloProrrogacao, "99/99/9999"));
               AV26TFTituloProrrogacao_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV26TFTituloProrrogacao_To", context.localUtil.Format(AV26TFTituloProrrogacao_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloPropostaDescricao") == 0 )
            {
               AV30TFTituloPropostaDescricao = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV30TFTituloPropostaDescricao", AV30TFTituloPropostaDescricao);
               AV31TFTituloPropostaDescricao_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV31TFTituloPropostaDescricao_Sel", AV31TFTituloPropostaDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalNumero") == 0 )
            {
               AV32TFNotaFiscalNumero = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV32TFNotaFiscalNumero", AV32TFNotaFiscalNumero);
               AV33TFNotaFiscalNumero_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV33TFNotaFiscalNumero_Sel", AV33TFNotaFiscalNumero_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E19A52( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "titulo"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A261TituloId,9,0));
            edtTituloValor_Link = formatLink("titulo") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AV39Selected = false;
            AssignAttri("", false, chkavSelected_Internalname, AV39Selected);
            AV46TituloIdToFind = A261TituloId;
            AssignAttri("", false, "AV46TituloIdToFind", StringUtil.LTrimStr( (decimal)(AV46TituloIdToFind), 9, 0));
            /* Execute user subroutine: 'GETINDEXOFSELECTEDROW' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV42i > 0 )
            {
               AV39Selected = true;
               AssignAttri("", false, chkavSelected_Internalname, AV39Selected);
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 37;
            }
            sendrow_372( ) ;
         }
         GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_37_Refreshing )
         {
            DoAjaxLoad(37, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E20A52( )
      {
         /* Selected_Click Routine */
         returnInSub = false;
         if ( AV39Selected )
         {
            AV43TituloIdCol.Add(A261TituloId, 0);
         }
         else
         {
            AV46TituloIdToFind = A261TituloId;
            AssignAttri("", false, "AV46TituloIdToFind", StringUtil.LTrimStr( (decimal)(AV46TituloIdToFind), 9, 0));
            /* Execute user subroutine: 'GETINDEXOFSELECTEDROW' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            AV43TituloIdCol.RemoveItem((int)(AV42i));
         }
         AV44TituloIdJson = AV43TituloIdCol.ToJSonString(false);
         AssignAttri("", false, "AV44TituloIdJson", AV44TituloIdJson);
         divLayoutmaintable_Class = "Table TableWithSelectableGrid"+((AV43TituloIdCol.Count>0) ? " WWPMultiRowSelected" : "");
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43TituloIdCol", AV43TituloIdCol);
      }

      protected void E11A52( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S172 ();
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("SelecionarTitulosFilters")) + "," + UrlEncode(StringUtil.RTrim(AV49Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV18ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV18ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV18ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("SelecionarTitulosFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV18ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV18ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV18ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV17ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "SelecionarTitulosFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV17ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado não existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV49Pgmname+"GridState",  AV17ManageFiltersXml) ;
               AV10GridState.FromXml(AV17ManageFiltersXml, null, "", "");
               AV12OrderedBy = AV10GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
               AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S182 ();
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43TituloIdCol", AV43TituloIdCol);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16ManageFiltersData", AV16ManageFiltersData);
      }

      protected void E15A52( )
      {
         /* 'DoConfirmar' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADSELECTEDROWS' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV40SelectedRows.Count == 0 )
         {
            GX_msglist.addItem("Nenhum registro selecionado.");
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40SelectedRows", AV40SelectedRows);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43TituloIdCol", AV43TituloIdCol);
      }

      protected void E16A52( )
      {
         /* Selectall_Click Routine */
         returnInSub = false;
         AV43TituloIdCol = (GxSimpleCollection<int>)(new GxSimpleCollection<int>());
         if ( AV47SelectAll )
         {
            /* Execute user subroutine: 'ADD ALL RECORDS' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Start For Each Line */
         nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_37"), ",", "."), 18, MidpointRounding.ToEven));
         nGXsfl_37_fel_idx = 0;
         while ( nGXsfl_37_fel_idx < nRC_GXsfl_37 )
         {
            nGXsfl_37_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_fel_idx+1);
            sGXsfl_37_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_372( ) ;
            AV39Selected = StringUtil.StrToBool( cgiGet( chkavSelected_Internalname));
            A261TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n261TituloId = false;
            A420TituloClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n420TituloClienteId = false;
            A972TituloCLienteRazaoSocial = StringUtil.Upper( cgiGet( edtTituloCLienteRazaoSocial_Internalname));
            n972TituloCLienteRazaoSocial = false;
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
            A286TituloCompetenciaAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloCompetenciaAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n286TituloCompetenciaAno = false;
            A287TituloCompetenciaMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloCompetenciaMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n287TituloCompetenciaMes = false;
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
            A971TituloPropostaDescricao = cgiGet( edtTituloPropostaDescricao_Internalname);
            n971TituloPropostaDescricao = false;
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
            A302TituloSaldoDebito_F = context.localUtil.CToN( cgiGet( edtTituloSaldoDebito_F_Internalname), ",", ".");
            A303TituloSaldoCredito_F = context.localUtil.CToN( cgiGet( edtTituloSaldoCredito_F_Internalname), ",", ".");
            A304TituloTotalMovimentoDebito_F = context.localUtil.CToN( cgiGet( edtTituloTotalMovimentoDebito_F_Internalname), ",", ".");
            n304TituloTotalMovimentoDebito_F = false;
            A305TituloTotalMovimentoCredito_F = context.localUtil.CToN( cgiGet( edtTituloTotalMovimentoCredito_F_Internalname), ",", ".");
            n305TituloTotalMovimentoCredito_F = false;
            A306TituloTotalMultaJurosDebito_F = context.localUtil.CToN( cgiGet( edtTituloTotalMultaJurosDebito_F_Internalname), ",", ".");
            n306TituloTotalMultaJurosDebito_F = false;
            A307TituloTotalMultaJurosCredito_F = context.localUtil.CToN( cgiGet( edtTituloTotalMultaJurosCredito_F_Internalname), ",", ".");
            n307TituloTotalMultaJurosCredito_F = false;
            cmbTituloPropostaTipo.Name = cmbTituloPropostaTipo_Internalname;
            cmbTituloPropostaTipo.CurrentValue = cgiGet( cmbTituloPropostaTipo_Internalname);
            A648TituloPropostaTipo = cgiGet( cmbTituloPropostaTipo_Internalname);
            n648TituloPropostaTipo = false;
            A890NotaFiscalParcelamentoID = StringUtil.StrToGuid( cgiGet( edtNotaFiscalParcelamentoID_Internalname));
            n890NotaFiscalParcelamentoID = false;
            A799NotaFiscalNumero = cgiGet( edtNotaFiscalNumero_Internalname);
            n799NotaFiscalNumero = false;
            A951ContaBancariaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContaBancariaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n951ContaBancariaId = false;
            A969AgenciaBancoNome = cgiGet( edtAgenciaBancoNome_Internalname);
            n969AgenciaBancoNome = false;
            A953ContaBancariaCarteira = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtContaBancariaCarteira_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n953ContaBancariaCarteira = false;
            A952ContaBancariaNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtContaBancariaNumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n952ContaBancariaNumero = false;
            A939AgenciaNumero = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAgenciaNumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n939AgenciaNumero = false;
            A1118TitulosEmCarteiraDeCobranca_F = StringUtil.StrToBool( cgiGet( chkTitulosEmCarteiraDeCobranca_F_Internalname));
            A1119TitulosCarteiraDeCobranca = cgiGet( edtTitulosCarteiraDeCobranca_Internalname);
            n1119TitulosCarteiraDeCobranca = false;
            AV39Selected = AV47SelectAll;
            AssignAttri("", false, chkavSelected_Internalname, AV39Selected);
            /* End For Each Line */
         }
         if ( nGXsfl_37_fel_idx == 0 )
         {
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         nGXsfl_37_fel_idx = 1;
         AV44TituloIdJson = AV43TituloIdCol.ToJSonString(false);
         AssignAttri("", false, "AV44TituloIdJson", AV44TituloIdJson);
         divLayoutmaintable_Class = "Table TableWithSelectableGrid"+((AV43TituloIdCol.Count>0) ? " WWPMultiRowSelected" : "");
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43TituloIdCol", AV43TituloIdCol);
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV12OrderedBy), 4, 0))+":"+(AV13OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S162( )
      {
         /* 'GETINDEXOFSELECTEDROW' Routine */
         returnInSub = false;
         AV42i = 1;
         AssignAttri("", false, "AV42i", StringUtil.LTrimStr( (decimal)(AV42i), 10, 0));
         AV64GXV1 = 1;
         while ( AV64GXV1 <= AV43TituloIdCol.Count )
         {
            AV45TituloIdColItem = (int)(AV43TituloIdCol.GetNumeric(AV64GXV1));
            AssignAttri("", false, "AV45TituloIdColItem", StringUtil.LTrimStr( (decimal)(AV45TituloIdColItem), 9, 0));
            if ( AV45TituloIdColItem == AV46TituloIdToFind )
            {
               if (true) break;
            }
            AV42i = (long)(AV42i+1);
            AssignAttri("", false, "AV42i", StringUtil.LTrimStr( (decimal)(AV42i), 10, 0));
            AV64GXV1 = (int)(AV64GXV1+1);
         }
         if ( AV42i > AV43TituloIdCol.Count )
         {
            AV42i = 0;
            AssignAttri("", false, "AV42i", StringUtil.LTrimStr( (decimal)(AV42i), 10, 0));
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV16ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "SelecionarTitulosFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV16ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S172( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV14FilterFullText = "";
         AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
         AV19TFTituloCLienteRazaoSocial = "";
         AssignAttri("", false, "AV19TFTituloCLienteRazaoSocial", AV19TFTituloCLienteRazaoSocial);
         AV20TFTituloCLienteRazaoSocial_Sel = "";
         AssignAttri("", false, "AV20TFTituloCLienteRazaoSocial_Sel", AV20TFTituloCLienteRazaoSocial_Sel);
         AV21TFTituloValor = 0;
         AssignAttri("", false, "AV21TFTituloValor", StringUtil.LTrimStr( AV21TFTituloValor, 18, 2));
         AV22TFTituloValor_To = 0;
         AssignAttri("", false, "AV22TFTituloValor_To", StringUtil.LTrimStr( AV22TFTituloValor_To, 18, 2));
         AV23TFTituloDesconto = 0;
         AssignAttri("", false, "AV23TFTituloDesconto", StringUtil.LTrimStr( AV23TFTituloDesconto, 18, 2));
         AV24TFTituloDesconto_To = 0;
         AssignAttri("", false, "AV24TFTituloDesconto_To", StringUtil.LTrimStr( AV24TFTituloDesconto_To, 18, 2));
         AV25TFTituloProrrogacao = DateTime.MinValue;
         AssignAttri("", false, "AV25TFTituloProrrogacao", context.localUtil.Format(AV25TFTituloProrrogacao, "99/99/9999"));
         AV26TFTituloProrrogacao_To = DateTime.MinValue;
         AssignAttri("", false, "AV26TFTituloProrrogacao_To", context.localUtil.Format(AV26TFTituloProrrogacao_To, "99/99/9999"));
         AV30TFTituloPropostaDescricao = "";
         AssignAttri("", false, "AV30TFTituloPropostaDescricao", AV30TFTituloPropostaDescricao);
         AV31TFTituloPropostaDescricao_Sel = "";
         AssignAttri("", false, "AV31TFTituloPropostaDescricao_Sel", AV31TFTituloPropostaDescricao_Sel);
         AV32TFNotaFiscalNumero = "";
         AssignAttri("", false, "AV32TFNotaFiscalNumero", AV32TFNotaFiscalNumero);
         AV33TFNotaFiscalNumero_Sel = "";
         AssignAttri("", false, "AV33TFNotaFiscalNumero_Sel", AV33TFNotaFiscalNumero_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S192( )
      {
         /* 'LOADSELECTEDROWS' Routine */
         returnInSub = false;
         AV40SelectedRows = new GXBaseCollection<SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem>( context, "SelecionarTitulosSDTItem", "Factory21");
         AV43TituloIdCol.FromJSonString(AV44TituloIdJson, null);
         AV65GXV2 = 1;
         while ( AV65GXV2 <= AV43TituloIdCol.Count )
         {
            AV45TituloIdColItem = (int)(AV43TituloIdCol.GetNumeric(AV65GXV2));
            AssignAttri("", false, "AV45TituloIdColItem", StringUtil.LTrimStr( (decimal)(AV45TituloIdColItem), 9, 0));
            AV41SelectedRow = new SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem(context);
            /* Using cursor H00A531 */
            pr_default.execute(2, new Object[] {AV45TituloIdColItem});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A794NotaFiscalId = H00A531_A794NotaFiscalId[0];
               n794NotaFiscalId = H00A531_n794NotaFiscalId[0];
               A938AgenciaId = H00A531_A938AgenciaId[0];
               n938AgenciaId = H00A531_n938AgenciaId[0];
               A968AgenciaBancoId = H00A531_A968AgenciaBancoId[0];
               n968AgenciaBancoId = H00A531_n968AgenciaBancoId[0];
               A261TituloId = H00A531_A261TituloId[0];
               n261TituloId = H00A531_n261TituloId[0];
               A420TituloClienteId = H00A531_A420TituloClienteId[0];
               n420TituloClienteId = H00A531_n420TituloClienteId[0];
               A972TituloCLienteRazaoSocial = H00A531_A972TituloCLienteRazaoSocial[0];
               n972TituloCLienteRazaoSocial = H00A531_n972TituloCLienteRazaoSocial[0];
               A284TituloDeleted = H00A531_A284TituloDeleted[0];
               n284TituloDeleted = H00A531_n284TituloDeleted[0];
               A314TituloArchived = H00A531_A314TituloArchived[0];
               n314TituloArchived = H00A531_n314TituloArchived[0];
               A263TituloVencimento = H00A531_A263TituloVencimento[0];
               n263TituloVencimento = H00A531_n263TituloVencimento[0];
               A264TituloProrrogacao = H00A531_A264TituloProrrogacao[0];
               n264TituloProrrogacao = H00A531_n264TituloProrrogacao[0];
               A265TituloCEP = H00A531_A265TituloCEP[0];
               n265TituloCEP = H00A531_n265TituloCEP[0];
               A266TituloLogradouro = H00A531_A266TituloLogradouro[0];
               n266TituloLogradouro = H00A531_n266TituloLogradouro[0];
               A294TituloNumeroEndereco = H00A531_A294TituloNumeroEndereco[0];
               n294TituloNumeroEndereco = H00A531_n294TituloNumeroEndereco[0];
               A267TituloComplemento = H00A531_A267TituloComplemento[0];
               n267TituloComplemento = H00A531_n267TituloComplemento[0];
               A268TituloBairro = H00A531_A268TituloBairro[0];
               n268TituloBairro = H00A531_n268TituloBairro[0];
               A269TituloMunicipio = H00A531_A269TituloMunicipio[0];
               n269TituloMunicipio = H00A531_n269TituloMunicipio[0];
               A498TituloJurosMora = H00A531_A498TituloJurosMora[0];
               n498TituloJurosMora = H00A531_n498TituloJurosMora[0];
               A419TituloPropostaId = H00A531_A419TituloPropostaId[0];
               n419TituloPropostaId = H00A531_n419TituloPropostaId[0];
               A971TituloPropostaDescricao = H00A531_A971TituloPropostaDescricao[0];
               n971TituloPropostaDescricao = H00A531_n971TituloPropostaDescricao[0];
               A501PropostaTaxaAdministrativa = H00A531_A501PropostaTaxaAdministrativa[0];
               n501PropostaTaxaAdministrativa = H00A531_n501PropostaTaxaAdministrativa[0];
               A422ContaId = H00A531_A422ContaId[0];
               n422ContaId = H00A531_n422ContaId[0];
               A500TituloCriacao = H00A531_A500TituloCriacao[0];
               n500TituloCriacao = H00A531_n500TituloCriacao[0];
               A426CategoriaTituloId = H00A531_A426CategoriaTituloId[0];
               n426CategoriaTituloId = H00A531_n426CategoriaTituloId[0];
               A648TituloPropostaTipo = H00A531_A648TituloPropostaTipo[0];
               n648TituloPropostaTipo = H00A531_n648TituloPropostaTipo[0];
               A890NotaFiscalParcelamentoID = H00A531_A890NotaFiscalParcelamentoID[0];
               n890NotaFiscalParcelamentoID = H00A531_n890NotaFiscalParcelamentoID[0];
               A799NotaFiscalNumero = H00A531_A799NotaFiscalNumero[0];
               n799NotaFiscalNumero = H00A531_n799NotaFiscalNumero[0];
               A951ContaBancariaId = H00A531_A951ContaBancariaId[0];
               n951ContaBancariaId = H00A531_n951ContaBancariaId[0];
               A969AgenciaBancoNome = H00A531_A969AgenciaBancoNome[0];
               n969AgenciaBancoNome = H00A531_n969AgenciaBancoNome[0];
               A953ContaBancariaCarteira = H00A531_A953ContaBancariaCarteira[0];
               n953ContaBancariaCarteira = H00A531_n953ContaBancariaCarteira[0];
               A952ContaBancariaNumero = H00A531_A952ContaBancariaNumero[0];
               n952ContaBancariaNumero = H00A531_n952ContaBancariaNumero[0];
               A939AgenciaNumero = H00A531_A939AgenciaNumero[0];
               n939AgenciaNumero = H00A531_n939AgenciaNumero[0];
               A516TituloDataCredito_F = H00A531_A516TituloDataCredito_F[0];
               n516TituloDataCredito_F = H00A531_n516TituloDataCredito_F[0];
               A301TituloTotalMultaJuros_F = H00A531_A301TituloTotalMultaJuros_F[0];
               n301TituloTotalMultaJuros_F = H00A531_n301TituloTotalMultaJuros_F[0];
               A304TituloTotalMovimentoDebito_F = H00A531_A304TituloTotalMovimentoDebito_F[0];
               n304TituloTotalMovimentoDebito_F = H00A531_n304TituloTotalMovimentoDebito_F[0];
               A305TituloTotalMovimentoCredito_F = H00A531_A305TituloTotalMovimentoCredito_F[0];
               n305TituloTotalMovimentoCredito_F = H00A531_n305TituloTotalMovimentoCredito_F[0];
               A306TituloTotalMultaJurosDebito_F = H00A531_A306TituloTotalMultaJurosDebito_F[0];
               n306TituloTotalMultaJurosDebito_F = H00A531_n306TituloTotalMultaJurosDebito_F[0];
               A307TituloTotalMultaJurosCredito_F = H00A531_A307TituloTotalMultaJurosCredito_F[0];
               n307TituloTotalMultaJurosCredito_F = H00A531_n307TituloTotalMultaJurosCredito_F[0];
               A1119TitulosCarteiraDeCobranca = H00A531_A1119TitulosCarteiraDeCobranca[0];
               n1119TitulosCarteiraDeCobranca = H00A531_n1119TitulosCarteiraDeCobranca[0];
               A283TituloTipo = H00A531_A283TituloTipo[0];
               n283TituloTipo = H00A531_n283TituloTipo[0];
               A273TituloTotalMovimento_F = H00A531_A273TituloTotalMovimento_F[0];
               A276TituloDesconto = H00A531_A276TituloDesconto[0];
               n276TituloDesconto = H00A531_n276TituloDesconto[0];
               A262TituloValor = H00A531_A262TituloValor[0];
               n262TituloValor = H00A531_n262TituloValor[0];
               A286TituloCompetenciaAno = H00A531_A286TituloCompetenciaAno[0];
               n286TituloCompetenciaAno = H00A531_n286TituloCompetenciaAno[0];
               A287TituloCompetenciaMes = H00A531_A287TituloCompetenciaMes[0];
               n287TituloCompetenciaMes = H00A531_n287TituloCompetenciaMes[0];
               A516TituloDataCredito_F = H00A531_A516TituloDataCredito_F[0];
               n516TituloDataCredito_F = H00A531_n516TituloDataCredito_F[0];
               A273TituloTotalMovimento_F = H00A531_A273TituloTotalMovimento_F[0];
               A301TituloTotalMultaJuros_F = H00A531_A301TituloTotalMultaJuros_F[0];
               n301TituloTotalMultaJuros_F = H00A531_n301TituloTotalMultaJuros_F[0];
               A304TituloTotalMovimentoDebito_F = H00A531_A304TituloTotalMovimentoDebito_F[0];
               n304TituloTotalMovimentoDebito_F = H00A531_n304TituloTotalMovimentoDebito_F[0];
               A305TituloTotalMovimentoCredito_F = H00A531_A305TituloTotalMovimentoCredito_F[0];
               n305TituloTotalMovimentoCredito_F = H00A531_n305TituloTotalMovimentoCredito_F[0];
               A306TituloTotalMultaJurosDebito_F = H00A531_A306TituloTotalMultaJurosDebito_F[0];
               n306TituloTotalMultaJurosDebito_F = H00A531_n306TituloTotalMultaJurosDebito_F[0];
               A307TituloTotalMultaJurosCredito_F = H00A531_A307TituloTotalMultaJurosCredito_F[0];
               n307TituloTotalMultaJurosCredito_F = H00A531_n307TituloTotalMultaJurosCredito_F[0];
               A1119TitulosCarteiraDeCobranca = H00A531_A1119TitulosCarteiraDeCobranca[0];
               n1119TitulosCarteiraDeCobranca = H00A531_n1119TitulosCarteiraDeCobranca[0];
               A972TituloCLienteRazaoSocial = H00A531_A972TituloCLienteRazaoSocial[0];
               n972TituloCLienteRazaoSocial = H00A531_n972TituloCLienteRazaoSocial[0];
               A971TituloPropostaDescricao = H00A531_A971TituloPropostaDescricao[0];
               n971TituloPropostaDescricao = H00A531_n971TituloPropostaDescricao[0];
               A501PropostaTaxaAdministrativa = H00A531_A501PropostaTaxaAdministrativa[0];
               n501PropostaTaxaAdministrativa = H00A531_n501PropostaTaxaAdministrativa[0];
               A794NotaFiscalId = H00A531_A794NotaFiscalId[0];
               n794NotaFiscalId = H00A531_n794NotaFiscalId[0];
               A799NotaFiscalNumero = H00A531_A799NotaFiscalNumero[0];
               n799NotaFiscalNumero = H00A531_n799NotaFiscalNumero[0];
               A938AgenciaId = H00A531_A938AgenciaId[0];
               n938AgenciaId = H00A531_n938AgenciaId[0];
               A953ContaBancariaCarteira = H00A531_A953ContaBancariaCarteira[0];
               n953ContaBancariaCarteira = H00A531_n953ContaBancariaCarteira[0];
               A952ContaBancariaNumero = H00A531_A952ContaBancariaNumero[0];
               n952ContaBancariaNumero = H00A531_n952ContaBancariaNumero[0];
               A968AgenciaBancoId = H00A531_A968AgenciaBancoId[0];
               n968AgenciaBancoId = H00A531_n968AgenciaBancoId[0];
               A939AgenciaNumero = H00A531_A939AgenciaNumero[0];
               n939AgenciaNumero = H00A531_n939AgenciaNumero[0];
               A969AgenciaBancoNome = H00A531_A969AgenciaBancoNome[0];
               n969AgenciaBancoNome = H00A531_n969AgenciaBancoNome[0];
               A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
               A303TituloSaldoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
               A302TituloSaldoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
               A275TituloSaldo_F = (decimal)((A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F);
               A282TituloStatus_F = ((Convert.ToDecimal(0)==A275TituloSaldo_F) ? "Liquidado" : ((A275TituloSaldo_F==A262TituloValor) ? "Aberto" : "Baixado parcialmente"));
               A1118TitulosEmCarteiraDeCobranca_F = ((GetTitulosEmCarteiraDeCobranca_F0( A261TituloId)==0) ? false : true);
               AV41SelectedRow.gxTpr_Tituloid = A261TituloId;
               AV41SelectedRow.gxTpr_Tituloclienteid = A420TituloClienteId;
               AV41SelectedRow.gxTpr_Tituloclienterazaosocial = A972TituloCLienteRazaoSocial;
               AV41SelectedRow.gxTpr_Titulovalor = A262TituloValor;
               AV41SelectedRow.gxTpr_Titulodesconto = A276TituloDesconto;
               AV41SelectedRow.gxTpr_Titulodeleted = A284TituloDeleted;
               AV41SelectedRow.gxTpr_Tituloarchived = A314TituloArchived;
               AV41SelectedRow.gxTpr_Titulovencimento = A263TituloVencimento;
               AV41SelectedRow.gxTpr_Titulocompetenciaano = A286TituloCompetenciaAno;
               AV41SelectedRow.gxTpr_Titulocompetenciames = A287TituloCompetenciaMes;
               AV41SelectedRow.gxTpr_Titulocompetencia_f = A295TituloCompetencia_F;
               AV41SelectedRow.gxTpr_Tituloprorrogacao = A264TituloProrrogacao;
               AV41SelectedRow.gxTpr_Titulocep = A265TituloCEP;
               AV41SelectedRow.gxTpr_Titulologradouro = A266TituloLogradouro;
               AV41SelectedRow.gxTpr_Titulonumeroendereco = A294TituloNumeroEndereco;
               AV41SelectedRow.gxTpr_Titulocomplemento = A267TituloComplemento;
               AV41SelectedRow.gxTpr_Titulobairro = A268TituloBairro;
               AV41SelectedRow.gxTpr_Titulomunicipio = A269TituloMunicipio;
               AV41SelectedRow.gxTpr_Titulojurosmora = A498TituloJurosMora;
               AV41SelectedRow.gxTpr_Titulotipo = A283TituloTipo;
               AV41SelectedRow.gxTpr_Titulopropostaid = A419TituloPropostaId;
               AV41SelectedRow.gxTpr_Titulopropostadescricao = A971TituloPropostaDescricao;
               AV41SelectedRow.gxTpr_Propostataxaadministrativa = A501PropostaTaxaAdministrativa;
               AV41SelectedRow.gxTpr_Contaid = A422ContaId;
               AV41SelectedRow.gxTpr_Titulocriacao = A500TituloCriacao;
               AV41SelectedRow.gxTpr_Categoriatituloid = A426CategoriaTituloId;
               AV41SelectedRow.gxTpr_Titulodatacredito_f = A516TituloDataCredito_F;
               AV41SelectedRow.gxTpr_Titulototalmovimento_f = A273TituloTotalMovimento_F;
               AV41SelectedRow.gxTpr_Titulototalmultajuros_f = A301TituloTotalMultaJuros_F;
               AV41SelectedRow.gxTpr_Titulosaldo_f = A275TituloSaldo_F;
               AV41SelectedRow.gxTpr_Titulostatus_f = A282TituloStatus_F;
               AV41SelectedRow.gxTpr_Titulosaldodebito_f = A302TituloSaldoDebito_F;
               AV41SelectedRow.gxTpr_Titulosaldocredito_f = A303TituloSaldoCredito_F;
               AV41SelectedRow.gxTpr_Titulototalmovimentodebito_f = A304TituloTotalMovimentoDebito_F;
               AV41SelectedRow.gxTpr_Titulototalmovimentocredito_f = A305TituloTotalMovimentoCredito_F;
               AV41SelectedRow.gxTpr_Titulototalmultajurosdebito_f = A306TituloTotalMultaJurosDebito_F;
               AV41SelectedRow.gxTpr_Titulototalmultajuroscredito_f = A307TituloTotalMultaJurosCredito_F;
               AV41SelectedRow.gxTpr_Titulopropostatipo = A648TituloPropostaTipo;
               AV41SelectedRow.gxTpr_Notafiscalparcelamentoid = A890NotaFiscalParcelamentoID;
               AV41SelectedRow.gxTpr_Notafiscalnumero = A799NotaFiscalNumero;
               AV41SelectedRow.gxTpr_Contabancariaid = A951ContaBancariaId;
               AV41SelectedRow.gxTpr_Agenciabanconome = A969AgenciaBancoNome;
               AV41SelectedRow.gxTpr_Contabancariacarteira = A953ContaBancariaCarteira;
               AV41SelectedRow.gxTpr_Contabancarianumero = A952ContaBancariaNumero;
               AV41SelectedRow.gxTpr_Agencianumero = A939AgenciaNumero;
               AV41SelectedRow.gxTpr_Titulosemcarteiradecobranca_f = A1118TitulosEmCarteiraDeCobranca_F;
               AV41SelectedRow.gxTpr_Tituloscarteiradecobranca = A1119TitulosCarteiraDeCobranca;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            AV40SelectedRows.Add(AV41SelectedRow, 0);
            AV65GXV2 = (int)(AV65GXV2+1);
         }
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV15Session.Get(AV49Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV49Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV15Session.Get(AV49Pgmname+"GridState"), null, "", "");
         }
         AV12OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
         AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S182 ();
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

      protected void S182( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV67GXV3 = 1;
         while ( AV67GXV3 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV67GXV3));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV14FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTITULOCLIENTERAZAOSOCIAL") == 0 )
            {
               AV19TFTituloCLienteRazaoSocial = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV19TFTituloCLienteRazaoSocial", AV19TFTituloCLienteRazaoSocial);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTITULOCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV20TFTituloCLienteRazaoSocial_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV20TFTituloCLienteRazaoSocial_Sel", AV20TFTituloCLienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTITULOVALOR") == 0 )
            {
               AV21TFTituloValor = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV21TFTituloValor", StringUtil.LTrimStr( AV21TFTituloValor, 18, 2));
               AV22TFTituloValor_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV22TFTituloValor_To", StringUtil.LTrimStr( AV22TFTituloValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTITULODESCONTO") == 0 )
            {
               AV23TFTituloDesconto = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV23TFTituloDesconto", StringUtil.LTrimStr( AV23TFTituloDesconto, 18, 2));
               AV24TFTituloDesconto_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV24TFTituloDesconto_To", StringUtil.LTrimStr( AV24TFTituloDesconto_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTITULOPRORROGACAO") == 0 )
            {
               AV25TFTituloProrrogacao = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV25TFTituloProrrogacao", context.localUtil.Format(AV25TFTituloProrrogacao, "99/99/9999"));
               AV26TFTituloProrrogacao_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV26TFTituloProrrogacao_To", context.localUtil.Format(AV26TFTituloProrrogacao_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTITULOPROPOSTADESCRICAO") == 0 )
            {
               AV30TFTituloPropostaDescricao = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV30TFTituloPropostaDescricao", AV30TFTituloPropostaDescricao);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTITULOPROPOSTADESCRICAO_SEL") == 0 )
            {
               AV31TFTituloPropostaDescricao_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31TFTituloPropostaDescricao_Sel", AV31TFTituloPropostaDescricao_Sel);
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
            AV67GXV3 = (int)(AV67GXV3+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV20TFTituloCLienteRazaoSocial_Sel)),  AV20TFTituloCLienteRazaoSocial_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFTituloPropostaDescricao_Sel)),  AV31TFTituloPropostaDescricao_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFNotaFiscalNumero_Sel)),  AV33TFNotaFiscalNumero_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"||||"+GXt_char4+"|"+GXt_char5;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV19TFTituloCLienteRazaoSocial)),  AV19TFTituloCLienteRazaoSocial, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV30TFTituloPropostaDescricao)),  AV30TFTituloPropostaDescricao, out  GXt_char4) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFNotaFiscalNumero)),  AV32TFNotaFiscalNumero, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char5+"|"+((Convert.ToDecimal(0)==AV21TFTituloValor) ? "" : StringUtil.Str( AV21TFTituloValor, 18, 2))+"|"+((Convert.ToDecimal(0)==AV23TFTituloDesconto) ? "" : StringUtil.Str( AV23TFTituloDesconto, 18, 2))+"|"+((DateTime.MinValue==AV25TFTituloProrrogacao) ? "" : context.localUtil.DToC( AV25TFTituloProrrogacao, 4, "/"))+"|"+GXt_char4+"|"+GXt_char2;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|"+((Convert.ToDecimal(0)==AV22TFTituloValor_To) ? "" : StringUtil.Str( AV22TFTituloValor_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV24TFTituloDesconto_To) ? "" : StringUtil.Str( AV24TFTituloDesconto_To, 18, 2))+"|"+((DateTime.MinValue==AV26TFTituloProrrogacao_To) ? "" : context.localUtil.DToC( AV26TFTituloProrrogacao_To, 4, "/"))+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV15Session.Get(AV49Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV12OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV14FilterFullText)),  0,  AV14FilterFullText,  AV14FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFTITULOCLIENTERAZAOSOCIAL",  "Cliente",  !String.IsNullOrEmpty(StringUtil.RTrim( AV19TFTituloCLienteRazaoSocial)),  0,  AV19TFTituloCLienteRazaoSocial,  AV19TFTituloCLienteRazaoSocial,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV20TFTituloCLienteRazaoSocial_Sel)),  AV20TFTituloCLienteRazaoSocial_Sel,  AV20TFTituloCLienteRazaoSocial_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTITULOVALOR",  "Valor",  !((Convert.ToDecimal(0)==AV21TFTituloValor)&&(Convert.ToDecimal(0)==AV22TFTituloValor_To)),  0,  StringUtil.Trim( StringUtil.Str( AV21TFTituloValor, 18, 2)),  ((Convert.ToDecimal(0)==AV21TFTituloValor) ? "" : StringUtil.Trim( context.localUtil.Format( AV21TFTituloValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV22TFTituloValor_To, 18, 2)),  ((Convert.ToDecimal(0)==AV22TFTituloValor_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV22TFTituloValor_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTITULODESCONTO",  "Desconto",  !((Convert.ToDecimal(0)==AV23TFTituloDesconto)&&(Convert.ToDecimal(0)==AV24TFTituloDesconto_To)),  0,  StringUtil.Trim( StringUtil.Str( AV23TFTituloDesconto, 18, 2)),  ((Convert.ToDecimal(0)==AV23TFTituloDesconto) ? "" : StringUtil.Trim( context.localUtil.Format( AV23TFTituloDesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV24TFTituloDesconto_To, 18, 2)),  ((Convert.ToDecimal(0)==AV24TFTituloDesconto_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV24TFTituloDesconto_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTITULOPRORROGACAO",  "Vencimento",  !((DateTime.MinValue==AV25TFTituloProrrogacao)&&(DateTime.MinValue==AV26TFTituloProrrogacao_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV25TFTituloProrrogacao, 4, "/")),  ((DateTime.MinValue==AV25TFTituloProrrogacao) ? "" : StringUtil.Trim( context.localUtil.Format( AV25TFTituloProrrogacao, "99/99/9999"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV26TFTituloProrrogacao_To, 4, "/")),  ((DateTime.MinValue==AV26TFTituloProrrogacao_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV26TFTituloProrrogacao_To, "99/99/9999")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFTITULOPROPOSTADESCRICAO",  "Proposta",  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFTituloPropostaDescricao)),  0,  AV30TFTituloPropostaDescricao,  AV30TFTituloPropostaDescricao,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFTituloPropostaDescricao_Sel)),  AV31TFTituloPropostaDescricao_Sel,  AV31TFTituloPropostaDescricao_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFNOTAFISCALNUMERO",  "Nota Fiscal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFNotaFiscalNumero)),  0,  AV32TFNotaFiscalNumero,  AV32TFNotaFiscalNumero,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFNotaFiscalNumero_Sel)),  AV33TFNotaFiscalNumero_Sel,  AV33TFNotaFiscalNumero_Sel) ;
         if ( ! (0==AV48CarteiraDeCobrancaId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&CARTEIRADECOBRANCAID";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV48CarteiraDeCobrancaId), 9, 0);
            AV10GridState.gxTpr_Filtervalues.Add(AV11GridStateFilterValue, 0);
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV49Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV49Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Titulo";
         AV15Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void S202( )
      {
         /* 'ADD ALL RECORDS' Routine */
         returnInSub = false;
         AV50Selecionartitulosds_1_filterfulltext = AV14FilterFullText;
         AV51Selecionartitulosds_2_tftituloclienterazaosocial = AV19TFTituloCLienteRazaoSocial;
         AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel = AV20TFTituloCLienteRazaoSocial_Sel;
         AV53Selecionartitulosds_4_tftitulovalor = AV21TFTituloValor;
         AV54Selecionartitulosds_5_tftitulovalor_to = AV22TFTituloValor_To;
         AV55Selecionartitulosds_6_tftitulodesconto = AV23TFTituloDesconto;
         AV56Selecionartitulosds_7_tftitulodesconto_to = AV24TFTituloDesconto_To;
         AV57Selecionartitulosds_8_tftituloprorrogacao = AV25TFTituloProrrogacao;
         AV58Selecionartitulosds_9_tftituloprorrogacao_to = AV26TFTituloProrrogacao_To;
         AV59Selecionartitulosds_10_tftitulopropostadescricao = AV30TFTituloPropostaDescricao;
         AV60Selecionartitulosds_11_tftitulopropostadescricao_sel = AV31TFTituloPropostaDescricao_Sel;
         AV61Selecionartitulosds_12_tfnotafiscalnumero = AV32TFNotaFiscalNumero;
         AV62Selecionartitulosds_13_tfnotafiscalnumero_sel = AV33TFNotaFiscalNumero_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV50Selecionartitulosds_1_filterfulltext ,
                                              AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel ,
                                              AV51Selecionartitulosds_2_tftituloclienterazaosocial ,
                                              AV53Selecionartitulosds_4_tftitulovalor ,
                                              AV54Selecionartitulosds_5_tftitulovalor_to ,
                                              AV55Selecionartitulosds_6_tftitulodesconto ,
                                              AV56Selecionartitulosds_7_tftitulodesconto_to ,
                                              AV57Selecionartitulosds_8_tftituloprorrogacao ,
                                              AV58Selecionartitulosds_9_tftituloprorrogacao_to ,
                                              AV60Selecionartitulosds_11_tftitulopropostadescricao_sel ,
                                              AV59Selecionartitulosds_10_tftitulopropostadescricao ,
                                              AV62Selecionartitulosds_13_tfnotafiscalnumero_sel ,
                                              AV61Selecionartitulosds_12_tfnotafiscalnumero ,
                                              A972TituloCLienteRazaoSocial ,
                                              A262TituloValor ,
                                              A276TituloDesconto ,
                                              A971TituloPropostaDescricao ,
                                              A799NotaFiscalNumero ,
                                              A264TituloProrrogacao ,
                                              A1118TitulosEmCarteiraDeCobranca_F ,
                                              A261TituloId } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV50Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Selecionartitulosds_1_filterfulltext), "%", "");
         lV50Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Selecionartitulosds_1_filterfulltext), "%", "");
         lV50Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Selecionartitulosds_1_filterfulltext), "%", "");
         lV50Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Selecionartitulosds_1_filterfulltext), "%", "");
         lV50Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Selecionartitulosds_1_filterfulltext), "%", "");
         lV51Selecionartitulosds_2_tftituloclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV51Selecionartitulosds_2_tftituloclienterazaosocial), "%", "");
         lV59Selecionartitulosds_10_tftitulopropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV59Selecionartitulosds_10_tftitulopropostadescricao), "%", "");
         lV61Selecionartitulosds_12_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV61Selecionartitulosds_12_tfnotafiscalnumero), "%", "");
         /* Using cursor H00A532 */
         pr_default.execute(3, new Object[] {lV50Selecionartitulosds_1_filterfulltext, lV50Selecionartitulosds_1_filterfulltext, lV50Selecionartitulosds_1_filterfulltext, lV50Selecionartitulosds_1_filterfulltext, lV50Selecionartitulosds_1_filterfulltext, lV51Selecionartitulosds_2_tftituloclienterazaosocial, AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel, AV53Selecionartitulosds_4_tftitulovalor, AV54Selecionartitulosds_5_tftitulovalor_to, AV55Selecionartitulosds_6_tftitulodesconto, AV56Selecionartitulosds_7_tftitulodesconto_to, AV57Selecionartitulosds_8_tftituloprorrogacao, AV58Selecionartitulosds_9_tftituloprorrogacao_to, lV59Selecionartitulosds_10_tftitulopropostadescricao, AV60Selecionartitulosds_11_tftitulopropostadescricao_sel, lV61Selecionartitulosds_12_tfnotafiscalnumero, AV62Selecionartitulosds_13_tfnotafiscalnumero_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A890NotaFiscalParcelamentoID = H00A532_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = H00A532_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = H00A532_A794NotaFiscalId[0];
            n794NotaFiscalId = H00A532_n794NotaFiscalId[0];
            A419TituloPropostaId = H00A532_A419TituloPropostaId[0];
            n419TituloPropostaId = H00A532_n419TituloPropostaId[0];
            A420TituloClienteId = H00A532_A420TituloClienteId[0];
            n420TituloClienteId = H00A532_n420TituloClienteId[0];
            A264TituloProrrogacao = H00A532_A264TituloProrrogacao[0];
            n264TituloProrrogacao = H00A532_n264TituloProrrogacao[0];
            A276TituloDesconto = H00A532_A276TituloDesconto[0];
            n276TituloDesconto = H00A532_n276TituloDesconto[0];
            A262TituloValor = H00A532_A262TituloValor[0];
            n262TituloValor = H00A532_n262TituloValor[0];
            A799NotaFiscalNumero = H00A532_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = H00A532_n799NotaFiscalNumero[0];
            A971TituloPropostaDescricao = H00A532_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = H00A532_n971TituloPropostaDescricao[0];
            A972TituloCLienteRazaoSocial = H00A532_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = H00A532_n972TituloCLienteRazaoSocial[0];
            A261TituloId = H00A532_A261TituloId[0];
            n261TituloId = H00A532_n261TituloId[0];
            A794NotaFiscalId = H00A532_A794NotaFiscalId[0];
            n794NotaFiscalId = H00A532_n794NotaFiscalId[0];
            A799NotaFiscalNumero = H00A532_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = H00A532_n799NotaFiscalNumero[0];
            A971TituloPropostaDescricao = H00A532_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = H00A532_n971TituloPropostaDescricao[0];
            A972TituloCLienteRazaoSocial = H00A532_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = H00A532_n972TituloCLienteRazaoSocial[0];
            A1118TitulosEmCarteiraDeCobranca_F = ((GetTitulosEmCarteiraDeCobranca_F0( A261TituloId)==0) ? false : true);
            if ( ! A1118TitulosEmCarteiraDeCobranca_F )
            {
               AV43TituloIdCol.Add(A261TituloId, 0);
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV48CarteiraDeCobrancaId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV48CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(AV48CarteiraDeCobrancaId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vCARTEIRADECOBRANCAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV48CarteiraDeCobrancaId), "ZZZZZZZZ9"), context));
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
         PAA52( ) ;
         WSA52( ) ;
         WEA52( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019294919", true, true);
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
         context.AddJavascriptSource("selecionartitulos.js", "?202561019294920", false, true);
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

      protected void SubsflControlProps_372( )
      {
         chkavSelected_Internalname = "vSELECTED_"+sGXsfl_37_idx;
         edtTituloId_Internalname = "TITULOID_"+sGXsfl_37_idx;
         edtTituloClienteId_Internalname = "TITULOCLIENTEID_"+sGXsfl_37_idx;
         edtTituloCLienteRazaoSocial_Internalname = "TITULOCLIENTERAZAOSOCIAL_"+sGXsfl_37_idx;
         edtTituloValor_Internalname = "TITULOVALOR_"+sGXsfl_37_idx;
         edtTituloDesconto_Internalname = "TITULODESCONTO_"+sGXsfl_37_idx;
         chkTituloDeleted_Internalname = "TITULODELETED_"+sGXsfl_37_idx;
         chkTituloArchived_Internalname = "TITULOARCHIVED_"+sGXsfl_37_idx;
         edtTituloVencimento_Internalname = "TITULOVENCIMENTO_"+sGXsfl_37_idx;
         edtTituloCompetenciaAno_Internalname = "TITULOCOMPETENCIAANO_"+sGXsfl_37_idx;
         edtTituloCompetenciaMes_Internalname = "TITULOCOMPETENCIAMES_"+sGXsfl_37_idx;
         edtTituloCompetencia_F_Internalname = "TITULOCOMPETENCIA_F_"+sGXsfl_37_idx;
         edtTituloProrrogacao_Internalname = "TITULOPRORROGACAO_"+sGXsfl_37_idx;
         edtTituloCEP_Internalname = "TITULOCEP_"+sGXsfl_37_idx;
         edtTituloLogradouro_Internalname = "TITULOLOGRADOURO_"+sGXsfl_37_idx;
         edtTituloNumeroEndereco_Internalname = "TITULONUMEROENDERECO_"+sGXsfl_37_idx;
         edtTituloComplemento_Internalname = "TITULOCOMPLEMENTO_"+sGXsfl_37_idx;
         edtTituloBairro_Internalname = "TITULOBAIRRO_"+sGXsfl_37_idx;
         edtTituloMunicipio_Internalname = "TITULOMUNICIPIO_"+sGXsfl_37_idx;
         edtTituloJurosMora_Internalname = "TITULOJUROSMORA_"+sGXsfl_37_idx;
         cmbTituloTipo_Internalname = "TITULOTIPO_"+sGXsfl_37_idx;
         edtTituloPropostaId_Internalname = "TITULOPROPOSTAID_"+sGXsfl_37_idx;
         edtTituloPropostaDescricao_Internalname = "TITULOPROPOSTADESCRICAO_"+sGXsfl_37_idx;
         edtPropostaTaxaAdministrativa_Internalname = "PROPOSTATAXAADMINISTRATIVA_"+sGXsfl_37_idx;
         edtContaId_Internalname = "CONTAID_"+sGXsfl_37_idx;
         edtTituloCriacao_Internalname = "TITULOCRIACAO_"+sGXsfl_37_idx;
         edtCategoriaTituloId_Internalname = "CATEGORIATITULOID_"+sGXsfl_37_idx;
         edtTituloDataCredito_F_Internalname = "TITULODATACREDITO_F_"+sGXsfl_37_idx;
         edtTituloTotalMovimento_F_Internalname = "TITULOTOTALMOVIMENTO_F_"+sGXsfl_37_idx;
         edtTituloTotalMultaJuros_F_Internalname = "TITULOTOTALMULTAJUROS_F_"+sGXsfl_37_idx;
         edtTituloSaldo_F_Internalname = "TITULOSALDO_F_"+sGXsfl_37_idx;
         edtTituloStatus_F_Internalname = "TITULOSTATUS_F_"+sGXsfl_37_idx;
         edtTituloSaldoDebito_F_Internalname = "TITULOSALDODEBITO_F_"+sGXsfl_37_idx;
         edtTituloSaldoCredito_F_Internalname = "TITULOSALDOCREDITO_F_"+sGXsfl_37_idx;
         edtTituloTotalMovimentoDebito_F_Internalname = "TITULOTOTALMOVIMENTODEBITO_F_"+sGXsfl_37_idx;
         edtTituloTotalMovimentoCredito_F_Internalname = "TITULOTOTALMOVIMENTOCREDITO_F_"+sGXsfl_37_idx;
         edtTituloTotalMultaJurosDebito_F_Internalname = "TITULOTOTALMULTAJUROSDEBITO_F_"+sGXsfl_37_idx;
         edtTituloTotalMultaJurosCredito_F_Internalname = "TITULOTOTALMULTAJUROSCREDITO_F_"+sGXsfl_37_idx;
         cmbTituloPropostaTipo_Internalname = "TITULOPROPOSTATIPO_"+sGXsfl_37_idx;
         edtNotaFiscalParcelamentoID_Internalname = "NOTAFISCALPARCELAMENTOID_"+sGXsfl_37_idx;
         edtNotaFiscalNumero_Internalname = "NOTAFISCALNUMERO_"+sGXsfl_37_idx;
         edtContaBancariaId_Internalname = "CONTABANCARIAID_"+sGXsfl_37_idx;
         edtAgenciaBancoNome_Internalname = "AGENCIABANCONOME_"+sGXsfl_37_idx;
         edtContaBancariaCarteira_Internalname = "CONTABANCARIACARTEIRA_"+sGXsfl_37_idx;
         edtContaBancariaNumero_Internalname = "CONTABANCARIANUMERO_"+sGXsfl_37_idx;
         edtAgenciaNumero_Internalname = "AGENCIANUMERO_"+sGXsfl_37_idx;
         chkTitulosEmCarteiraDeCobranca_F_Internalname = "TITULOSEMCARTEIRADECOBRANCA_F_"+sGXsfl_37_idx;
         edtTitulosCarteiraDeCobranca_Internalname = "TITULOSCARTEIRADECOBRANCA_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         chkavSelected_Internalname = "vSELECTED_"+sGXsfl_37_fel_idx;
         edtTituloId_Internalname = "TITULOID_"+sGXsfl_37_fel_idx;
         edtTituloClienteId_Internalname = "TITULOCLIENTEID_"+sGXsfl_37_fel_idx;
         edtTituloCLienteRazaoSocial_Internalname = "TITULOCLIENTERAZAOSOCIAL_"+sGXsfl_37_fel_idx;
         edtTituloValor_Internalname = "TITULOVALOR_"+sGXsfl_37_fel_idx;
         edtTituloDesconto_Internalname = "TITULODESCONTO_"+sGXsfl_37_fel_idx;
         chkTituloDeleted_Internalname = "TITULODELETED_"+sGXsfl_37_fel_idx;
         chkTituloArchived_Internalname = "TITULOARCHIVED_"+sGXsfl_37_fel_idx;
         edtTituloVencimento_Internalname = "TITULOVENCIMENTO_"+sGXsfl_37_fel_idx;
         edtTituloCompetenciaAno_Internalname = "TITULOCOMPETENCIAANO_"+sGXsfl_37_fel_idx;
         edtTituloCompetenciaMes_Internalname = "TITULOCOMPETENCIAMES_"+sGXsfl_37_fel_idx;
         edtTituloCompetencia_F_Internalname = "TITULOCOMPETENCIA_F_"+sGXsfl_37_fel_idx;
         edtTituloProrrogacao_Internalname = "TITULOPRORROGACAO_"+sGXsfl_37_fel_idx;
         edtTituloCEP_Internalname = "TITULOCEP_"+sGXsfl_37_fel_idx;
         edtTituloLogradouro_Internalname = "TITULOLOGRADOURO_"+sGXsfl_37_fel_idx;
         edtTituloNumeroEndereco_Internalname = "TITULONUMEROENDERECO_"+sGXsfl_37_fel_idx;
         edtTituloComplemento_Internalname = "TITULOCOMPLEMENTO_"+sGXsfl_37_fel_idx;
         edtTituloBairro_Internalname = "TITULOBAIRRO_"+sGXsfl_37_fel_idx;
         edtTituloMunicipio_Internalname = "TITULOMUNICIPIO_"+sGXsfl_37_fel_idx;
         edtTituloJurosMora_Internalname = "TITULOJUROSMORA_"+sGXsfl_37_fel_idx;
         cmbTituloTipo_Internalname = "TITULOTIPO_"+sGXsfl_37_fel_idx;
         edtTituloPropostaId_Internalname = "TITULOPROPOSTAID_"+sGXsfl_37_fel_idx;
         edtTituloPropostaDescricao_Internalname = "TITULOPROPOSTADESCRICAO_"+sGXsfl_37_fel_idx;
         edtPropostaTaxaAdministrativa_Internalname = "PROPOSTATAXAADMINISTRATIVA_"+sGXsfl_37_fel_idx;
         edtContaId_Internalname = "CONTAID_"+sGXsfl_37_fel_idx;
         edtTituloCriacao_Internalname = "TITULOCRIACAO_"+sGXsfl_37_fel_idx;
         edtCategoriaTituloId_Internalname = "CATEGORIATITULOID_"+sGXsfl_37_fel_idx;
         edtTituloDataCredito_F_Internalname = "TITULODATACREDITO_F_"+sGXsfl_37_fel_idx;
         edtTituloTotalMovimento_F_Internalname = "TITULOTOTALMOVIMENTO_F_"+sGXsfl_37_fel_idx;
         edtTituloTotalMultaJuros_F_Internalname = "TITULOTOTALMULTAJUROS_F_"+sGXsfl_37_fel_idx;
         edtTituloSaldo_F_Internalname = "TITULOSALDO_F_"+sGXsfl_37_fel_idx;
         edtTituloStatus_F_Internalname = "TITULOSTATUS_F_"+sGXsfl_37_fel_idx;
         edtTituloSaldoDebito_F_Internalname = "TITULOSALDODEBITO_F_"+sGXsfl_37_fel_idx;
         edtTituloSaldoCredito_F_Internalname = "TITULOSALDOCREDITO_F_"+sGXsfl_37_fel_idx;
         edtTituloTotalMovimentoDebito_F_Internalname = "TITULOTOTALMOVIMENTODEBITO_F_"+sGXsfl_37_fel_idx;
         edtTituloTotalMovimentoCredito_F_Internalname = "TITULOTOTALMOVIMENTOCREDITO_F_"+sGXsfl_37_fel_idx;
         edtTituloTotalMultaJurosDebito_F_Internalname = "TITULOTOTALMULTAJUROSDEBITO_F_"+sGXsfl_37_fel_idx;
         edtTituloTotalMultaJurosCredito_F_Internalname = "TITULOTOTALMULTAJUROSCREDITO_F_"+sGXsfl_37_fel_idx;
         cmbTituloPropostaTipo_Internalname = "TITULOPROPOSTATIPO_"+sGXsfl_37_fel_idx;
         edtNotaFiscalParcelamentoID_Internalname = "NOTAFISCALPARCELAMENTOID_"+sGXsfl_37_fel_idx;
         edtNotaFiscalNumero_Internalname = "NOTAFISCALNUMERO_"+sGXsfl_37_fel_idx;
         edtContaBancariaId_Internalname = "CONTABANCARIAID_"+sGXsfl_37_fel_idx;
         edtAgenciaBancoNome_Internalname = "AGENCIABANCONOME_"+sGXsfl_37_fel_idx;
         edtContaBancariaCarteira_Internalname = "CONTABANCARIACARTEIRA_"+sGXsfl_37_fel_idx;
         edtContaBancariaNumero_Internalname = "CONTABANCARIANUMERO_"+sGXsfl_37_fel_idx;
         edtAgenciaNumero_Internalname = "AGENCIANUMERO_"+sGXsfl_37_fel_idx;
         chkTitulosEmCarteiraDeCobranca_F_Internalname = "TITULOSEMCARTEIRADECOBRANCA_F_"+sGXsfl_37_fel_idx;
         edtTitulosCarteiraDeCobranca_Internalname = "TITULOSCARTEIRADECOBRANCA_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WBA50( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_37_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_37_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_37_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "vSELECTED_" + sGXsfl_37_idx;
            chkavSelected.Name = GXCCtl;
            chkavSelected.WebTags = "";
            chkavSelected.Caption = "";
            AssignProp("", false, chkavSelected_Internalname, "TitleCaption", chkavSelected.Caption, !bGXsfl_37_Refreshing);
            chkavSelected.CheckedValue = "false";
            AV39Selected = StringUtil.StrToBool( StringUtil.BoolToStr( AV39Selected));
            AssignAttri("", false, chkavSelected_Internalname, AV39Selected);
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavSelected_Internalname,StringUtil.BoolToStr( AV39Selected),(string)"",(string)"",(short)-1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onblur=\""+""+";gx.evt.onblur(this,38);\""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A261TituloId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A420TituloClienteId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A420TituloClienteId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloCLienteRazaoSocial_Internalname,(string)A972TituloCLienteRazaoSocial,StringUtil.RTrim( context.localUtil.Format( A972TituloCLienteRazaoSocial, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloCLienteRazaoSocial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A262TituloValor, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A262TituloValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtTituloValor_Link,(string)"",(string)"",(string)"",(string)edtTituloValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloDesconto_Internalname,StringUtil.LTrim( StringUtil.NToC( A276TituloDesconto, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A276TituloDesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloDesconto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "TITULODELETED_" + sGXsfl_37_idx;
            chkTituloDeleted.Name = GXCCtl;
            chkTituloDeleted.WebTags = "";
            chkTituloDeleted.Caption = "";
            AssignProp("", false, chkTituloDeleted_Internalname, "TitleCaption", chkTituloDeleted.Caption, !bGXsfl_37_Refreshing);
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
            GXCCtl = "TITULOARCHIVED_" + sGXsfl_37_idx;
            chkTituloArchived.Name = GXCCtl;
            chkTituloArchived.WebTags = "";
            chkTituloArchived.Caption = "";
            AssignProp("", false, chkTituloArchived_Internalname, "TitleCaption", chkTituloArchived.Caption, !bGXsfl_37_Refreshing);
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloVencimento_Internalname,context.localUtil.Format(A263TituloVencimento, "99/99/9999"),context.localUtil.Format( A263TituloVencimento, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloVencimento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloCompetenciaAno_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A286TituloCompetenciaAno), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A286TituloCompetenciaAno), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloCompetenciaAno_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloCompetenciaMes_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A287TituloCompetenciaMes), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A287TituloCompetenciaMes), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloCompetenciaMes_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloCompetencia_F_Internalname,(string)A295TituloCompetencia_F,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloCompetencia_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloProrrogacao_Internalname,context.localUtil.Format(A264TituloProrrogacao, "99/99/9999"),context.localUtil.Format( A264TituloProrrogacao, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloProrrogacao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloCEP_Internalname,(string)A265TituloCEP,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloCEP_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloLogradouro_Internalname,(string)A266TituloLogradouro,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloLogradouro_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloNumeroEndereco_Internalname,(string)A294TituloNumeroEndereco,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloNumeroEndereco_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloComplemento_Internalname,(string)A267TituloComplemento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloComplemento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloBairro_Internalname,(string)A268TituloBairro,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloBairro_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloMunicipio_Internalname,(string)A269TituloMunicipio,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloMunicipio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloJurosMora_Internalname,StringUtil.LTrim( StringUtil.NToC( A498TituloJurosMora, 21, 4, ",", "")),StringUtil.LTrim( context.localUtil.Format( A498TituloJurosMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloJurosMora_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentual",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbTituloTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "TITULOTIPO_" + sGXsfl_37_idx;
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
            AssignProp("", false, cmbTituloTipo_Internalname, "Values", (string)(cmbTituloTipo.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloPropostaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A419TituloPropostaId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloPropostaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloPropostaDescricao_Internalname,(string)A971TituloPropostaDescricao,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloPropostaDescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaTaxaAdministrativa_Internalname,StringUtil.LTrim( StringUtil.NToC( A501PropostaTaxaAdministrativa, 21, 4, ",", "")),StringUtil.LTrim( context.localUtil.Format( A501PropostaTaxaAdministrativa, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaTaxaAdministrativa_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentual",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A422ContaId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloCriacao_Internalname,context.localUtil.TToC( A500TituloCriacao, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A500TituloCriacao, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloCriacao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoriaTituloId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A426CategoriaTituloId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCategoriaTituloId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloDataCredito_F_Internalname,context.localUtil.Format(A516TituloDataCredito_F, "99/99/9999"),context.localUtil.Format( A516TituloDataCredito_F, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloDataCredito_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloTotalMovimento_F_Internalname,StringUtil.LTrim( StringUtil.NToC( A273TituloTotalMovimento_F, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A273TituloTotalMovimento_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloTotalMovimento_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloTotalMultaJuros_F_Internalname,StringUtil.LTrim( StringUtil.NToC( A301TituloTotalMultaJuros_F, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A301TituloTotalMultaJuros_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloTotalMultaJuros_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloSaldo_F_Internalname,StringUtil.LTrim( StringUtil.NToC( A275TituloSaldo_F, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A275TituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloSaldo_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloStatus_F_Internalname,(string)A282TituloStatus_F,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloStatus_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloSaldoDebito_F_Internalname,StringUtil.LTrim( StringUtil.NToC( A302TituloSaldoDebito_F, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A302TituloSaldoDebito_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloSaldoDebito_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloSaldoCredito_F_Internalname,StringUtil.LTrim( StringUtil.NToC( A303TituloSaldoCredito_F, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A303TituloSaldoCredito_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloSaldoCredito_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloTotalMovimentoDebito_F_Internalname,StringUtil.LTrim( StringUtil.NToC( A304TituloTotalMovimentoDebito_F, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A304TituloTotalMovimentoDebito_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloTotalMovimentoDebito_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloTotalMovimentoCredito_F_Internalname,StringUtil.LTrim( StringUtil.NToC( A305TituloTotalMovimentoCredito_F, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A305TituloTotalMovimentoCredito_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloTotalMovimentoCredito_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloTotalMultaJurosDebito_F_Internalname,StringUtil.LTrim( StringUtil.NToC( A306TituloTotalMultaJurosDebito_F, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A306TituloTotalMultaJurosDebito_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloTotalMultaJurosDebito_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloTotalMultaJurosCredito_F_Internalname,StringUtil.LTrim( StringUtil.NToC( A307TituloTotalMultaJurosCredito_F, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A307TituloTotalMultaJurosCredito_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloTotalMultaJurosCredito_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbTituloPropostaTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "TITULOPROPOSTATIPO_" + sGXsfl_37_idx;
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
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbTituloPropostaTipo,(string)cmbTituloPropostaTipo_Internalname,StringUtil.RTrim( A648TituloPropostaTipo),(short)1,(string)cmbTituloPropostaTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbTituloPropostaTipo.CurrentValue = StringUtil.RTrim( A648TituloPropostaTipo);
            AssignProp("", false, cmbTituloPropostaTipo_Internalname, "Values", (string)(cmbTituloPropostaTipo.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalParcelamentoID_Internalname,A890NotaFiscalParcelamentoID.ToString(),A890NotaFiscalParcelamentoID.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalParcelamentoID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalNumero_Internalname,(string)A799NotaFiscalNumero,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalNumero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContaBancariaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A951ContaBancariaId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContaBancariaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAgenciaBancoNome_Internalname,(string)A969AgenciaBancoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAgenciaBancoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContaBancariaCarteira_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A953ContaBancariaCarteira), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A953ContaBancariaCarteira), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContaBancariaCarteira_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContaBancariaNumero_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A952ContaBancariaNumero), 18, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A952ContaBancariaNumero), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContaBancariaNumero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAgenciaNumero_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A939AgenciaNumero), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A939AgenciaNumero), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAgenciaNumero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "TITULOSEMCARTEIRADECOBRANCA_F_" + sGXsfl_37_idx;
            chkTitulosEmCarteiraDeCobranca_F.Name = GXCCtl;
            chkTitulosEmCarteiraDeCobranca_F.WebTags = "";
            chkTitulosEmCarteiraDeCobranca_F.Caption = "";
            AssignProp("", false, chkTitulosEmCarteiraDeCobranca_F_Internalname, "TitleCaption", chkTitulosEmCarteiraDeCobranca_F.Caption, !bGXsfl_37_Refreshing);
            chkTitulosEmCarteiraDeCobranca_F.CheckedValue = "false";
            A1118TitulosEmCarteiraDeCobranca_F = StringUtil.StrToBool( StringUtil.BoolToStr( A1118TitulosEmCarteiraDeCobranca_F));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTitulosEmCarteiraDeCobranca_F_Internalname,StringUtil.BoolToStr( A1118TitulosEmCarteiraDeCobranca_F),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTitulosCarteiraDeCobranca_Internalname,(string)A1119TitulosCarteiraDeCobranca,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTitulosCarteiraDeCobranca_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashesA52( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         /* End function sendrow_372 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vSELECTED_" + sGXsfl_37_idx;
         chkavSelected.Name = GXCCtl;
         chkavSelected.WebTags = "";
         chkavSelected.Caption = "";
         AssignProp("", false, chkavSelected_Internalname, "TitleCaption", chkavSelected.Caption, !bGXsfl_37_Refreshing);
         chkavSelected.CheckedValue = "false";
         AV39Selected = StringUtil.StrToBool( StringUtil.BoolToStr( AV39Selected));
         AssignAttri("", false, chkavSelected_Internalname, AV39Selected);
         GXCCtl = "TITULODELETED_" + sGXsfl_37_idx;
         chkTituloDeleted.Name = GXCCtl;
         chkTituloDeleted.WebTags = "";
         chkTituloDeleted.Caption = "";
         AssignProp("", false, chkTituloDeleted_Internalname, "TitleCaption", chkTituloDeleted.Caption, !bGXsfl_37_Refreshing);
         chkTituloDeleted.CheckedValue = "false";
         A284TituloDeleted = StringUtil.StrToBool( StringUtil.BoolToStr( A284TituloDeleted));
         n284TituloDeleted = false;
         GXCCtl = "TITULOARCHIVED_" + sGXsfl_37_idx;
         chkTituloArchived.Name = GXCCtl;
         chkTituloArchived.WebTags = "";
         chkTituloArchived.Caption = "";
         AssignProp("", false, chkTituloArchived_Internalname, "TitleCaption", chkTituloArchived.Caption, !bGXsfl_37_Refreshing);
         chkTituloArchived.CheckedValue = "false";
         A314TituloArchived = StringUtil.StrToBool( StringUtil.BoolToStr( A314TituloArchived));
         n314TituloArchived = false;
         GXCCtl = "TITULOTIPO_" + sGXsfl_37_idx;
         cmbTituloTipo.Name = GXCCtl;
         cmbTituloTipo.WebTags = "";
         cmbTituloTipo.addItem("DEBITO", "Débito", 0);
         cmbTituloTipo.addItem("CREDITO", "Crédito", 0);
         if ( cmbTituloTipo.ItemCount > 0 )
         {
            A283TituloTipo = cmbTituloTipo.getValidValue(A283TituloTipo);
            n283TituloTipo = false;
         }
         GXCCtl = "TITULOPROPOSTATIPO_" + sGXsfl_37_idx;
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
         GXCCtl = "TITULOSEMCARTEIRADECOBRANCA_F_" + sGXsfl_37_idx;
         chkTitulosEmCarteiraDeCobranca_F.Name = GXCCtl;
         chkTitulosEmCarteiraDeCobranca_F.WebTags = "";
         chkTitulosEmCarteiraDeCobranca_F.Caption = "";
         AssignProp("", false, chkTitulosEmCarteiraDeCobranca_F_Internalname, "TitleCaption", chkTitulosEmCarteiraDeCobranca_F.Caption, !bGXsfl_37_Refreshing);
         chkTitulosEmCarteiraDeCobranca_F.CheckedValue = "false";
         A1118TitulosEmCarteiraDeCobranca_F = StringUtil.StrToBool( StringUtil.BoolToStr( A1118TitulosEmCarteiraDeCobranca_F));
         chkavSelectall.Name = "vSELECTALL";
         chkavSelectall.WebTags = "";
         chkavSelectall.Caption = "";
         AssignProp("", false, chkavSelectall_Internalname, "TitleCaption", chkavSelectall.Caption, true);
         chkavSelectall.CheckedValue = "false";
         AV47SelectAll = StringUtil.StrToBool( StringUtil.BoolToStr( AV47SelectAll));
         AssignAttri("", false, "AV47SelectAll", AV47SelectAll);
         /* End function init_web_controls */
      }

      protected void StartGridControl37( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"37\">") ;
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
            context.SendWebValue( "Cliente") ;
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
            context.SendWebValue( "Ano") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Mês") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Juros Mora") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Tipo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Proposta Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Proposta") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Saldo Debito_F") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Saldo Credito_F") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Movimento Debito_F") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Movimento Credito_F") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Juros Debito_F") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Juros Credito_F") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Proposta Tipo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Parcelamento ID") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nota Fiscal") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Bancaria Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Banco Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Carteira") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Número") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Agência") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "De Cobranca_F") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "De Cobranca") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV39Selected)));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A262TituloValor, 18, 2, ".", ""))));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtTituloValor_Link));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A971TituloPropostaDescricao));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A302TituloSaldoDebito_F, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A303TituloSaldoCredito_F, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A304TituloTotalMovimentoDebito_F, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A305TituloTotalMovimentoCredito_F, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A306TituloTotalMultaJurosDebito_F, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A307TituloTotalMultaJurosCredito_F, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A648TituloPropostaTipo));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A890NotaFiscalParcelamentoID.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A799NotaFiscalNumero));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A969AgenciaBancoNome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A953ContaBancariaCarteira), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A952ContaBancariaNumero), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A939AgenciaNumero), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A1118TitulosEmCarteiraDeCobranca_F)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1119TitulosCarteiraDeCobranca));
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
         bttBtnconfirmar_Internalname = "BTNCONFIRMAR";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         chkavSelected_Internalname = "vSELECTED";
         edtTituloId_Internalname = "TITULOID";
         edtTituloClienteId_Internalname = "TITULOCLIENTEID";
         edtTituloCLienteRazaoSocial_Internalname = "TITULOCLIENTERAZAOSOCIAL";
         edtTituloValor_Internalname = "TITULOVALOR";
         edtTituloDesconto_Internalname = "TITULODESCONTO";
         chkTituloDeleted_Internalname = "TITULODELETED";
         chkTituloArchived_Internalname = "TITULOARCHIVED";
         edtTituloVencimento_Internalname = "TITULOVENCIMENTO";
         edtTituloCompetenciaAno_Internalname = "TITULOCOMPETENCIAANO";
         edtTituloCompetenciaMes_Internalname = "TITULOCOMPETENCIAMES";
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
         edtTituloPropostaDescricao_Internalname = "TITULOPROPOSTADESCRICAO";
         edtPropostaTaxaAdministrativa_Internalname = "PROPOSTATAXAADMINISTRATIVA";
         edtContaId_Internalname = "CONTAID";
         edtTituloCriacao_Internalname = "TITULOCRIACAO";
         edtCategoriaTituloId_Internalname = "CATEGORIATITULOID";
         edtTituloDataCredito_F_Internalname = "TITULODATACREDITO_F";
         edtTituloTotalMovimento_F_Internalname = "TITULOTOTALMOVIMENTO_F";
         edtTituloTotalMultaJuros_F_Internalname = "TITULOTOTALMULTAJUROS_F";
         edtTituloSaldo_F_Internalname = "TITULOSALDO_F";
         edtTituloStatus_F_Internalname = "TITULOSTATUS_F";
         edtTituloSaldoDebito_F_Internalname = "TITULOSALDODEBITO_F";
         edtTituloSaldoCredito_F_Internalname = "TITULOSALDOCREDITO_F";
         edtTituloTotalMovimentoDebito_F_Internalname = "TITULOTOTALMOVIMENTODEBITO_F";
         edtTituloTotalMovimentoCredito_F_Internalname = "TITULOTOTALMOVIMENTOCREDITO_F";
         edtTituloTotalMultaJurosDebito_F_Internalname = "TITULOTOTALMULTAJUROSDEBITO_F";
         edtTituloTotalMultaJurosCredito_F_Internalname = "TITULOTOTALMULTAJUROSCREDITO_F";
         cmbTituloPropostaTipo_Internalname = "TITULOPROPOSTATIPO";
         edtNotaFiscalParcelamentoID_Internalname = "NOTAFISCALPARCELAMENTOID";
         edtNotaFiscalNumero_Internalname = "NOTAFISCALNUMERO";
         edtContaBancariaId_Internalname = "CONTABANCARIAID";
         edtAgenciaBancoNome_Internalname = "AGENCIABANCONOME";
         edtContaBancariaCarteira_Internalname = "CONTABANCARIACARTEIRA";
         edtContaBancariaNumero_Internalname = "CONTABANCARIANUMERO";
         edtAgenciaNumero_Internalname = "AGENCIANUMERO";
         chkTitulosEmCarteiraDeCobranca_F_Internalname = "TITULOSEMCARTEIRADECOBRANCA_F";
         edtTitulosCarteiraDeCobranca_Internalname = "TITULOSCARTEIRADECOBRANCA";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
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
         edtTitulosCarteiraDeCobranca_Jsonclick = "";
         chkTitulosEmCarteiraDeCobranca_F.Caption = "";
         edtAgenciaNumero_Jsonclick = "";
         edtContaBancariaNumero_Jsonclick = "";
         edtContaBancariaCarteira_Jsonclick = "";
         edtAgenciaBancoNome_Jsonclick = "";
         edtContaBancariaId_Jsonclick = "";
         edtNotaFiscalNumero_Jsonclick = "";
         edtNotaFiscalParcelamentoID_Jsonclick = "";
         cmbTituloPropostaTipo_Jsonclick = "";
         edtTituloTotalMultaJurosCredito_F_Jsonclick = "";
         edtTituloTotalMultaJurosDebito_F_Jsonclick = "";
         edtTituloTotalMovimentoCredito_F_Jsonclick = "";
         edtTituloTotalMovimentoDebito_F_Jsonclick = "";
         edtTituloSaldoCredito_F_Jsonclick = "";
         edtTituloSaldoDebito_F_Jsonclick = "";
         edtTituloStatus_F_Jsonclick = "";
         edtTituloSaldo_F_Jsonclick = "";
         edtTituloTotalMultaJuros_F_Jsonclick = "";
         edtTituloTotalMovimento_F_Jsonclick = "";
         edtTituloDataCredito_F_Jsonclick = "";
         edtCategoriaTituloId_Jsonclick = "";
         edtTituloCriacao_Jsonclick = "";
         edtContaId_Jsonclick = "";
         edtPropostaTaxaAdministrativa_Jsonclick = "";
         edtTituloPropostaDescricao_Jsonclick = "";
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
         edtTituloCompetenciaMes_Jsonclick = "";
         edtTituloCompetenciaAno_Jsonclick = "";
         edtTituloVencimento_Jsonclick = "";
         chkTituloArchived.Caption = "";
         chkTituloDeleted.Caption = "";
         edtTituloDesconto_Jsonclick = "";
         edtTituloValor_Jsonclick = "";
         edtTituloValor_Link = "";
         edtTituloCLienteRazaoSocial_Jsonclick = "";
         edtTituloClienteId_Jsonclick = "";
         edtTituloId_Jsonclick = "";
         chkavSelected.Caption = "";
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         chkavSelected.Title.Text = "";
         edtTitulosCarteiraDeCobranca_Enabled = 0;
         chkTitulosEmCarteiraDeCobranca_F.Enabled = 0;
         edtAgenciaNumero_Enabled = 0;
         edtContaBancariaNumero_Enabled = 0;
         edtContaBancariaCarteira_Enabled = 0;
         edtAgenciaBancoNome_Enabled = 0;
         edtContaBancariaId_Enabled = 0;
         edtNotaFiscalNumero_Enabled = 0;
         edtNotaFiscalParcelamentoID_Enabled = 0;
         cmbTituloPropostaTipo.Enabled = 0;
         edtTituloTotalMultaJurosCredito_F_Enabled = 0;
         edtTituloTotalMultaJurosDebito_F_Enabled = 0;
         edtTituloTotalMovimentoCredito_F_Enabled = 0;
         edtTituloTotalMovimentoDebito_F_Enabled = 0;
         edtTituloSaldoCredito_F_Enabled = 0;
         edtTituloSaldoDebito_F_Enabled = 0;
         edtTituloStatus_F_Enabled = 0;
         edtTituloSaldo_F_Enabled = 0;
         edtTituloTotalMultaJuros_F_Enabled = 0;
         edtTituloTotalMovimento_F_Enabled = 0;
         edtTituloDataCredito_F_Enabled = 0;
         edtCategoriaTituloId_Enabled = 0;
         edtTituloCriacao_Enabled = 0;
         edtContaId_Enabled = 0;
         edtPropostaTaxaAdministrativa_Enabled = 0;
         edtTituloPropostaDescricao_Enabled = 0;
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
         edtTituloCompetenciaMes_Enabled = 0;
         edtTituloCompetenciaAno_Enabled = 0;
         edtTituloVencimento_Enabled = 0;
         chkTituloArchived.Enabled = 0;
         chkTituloDeleted.Enabled = 0;
         edtTituloDesconto_Enabled = 0;
         edtTituloValor_Enabled = 0;
         edtTituloCLienteRazaoSocial_Enabled = 0;
         edtTituloClienteId_Enabled = 0;
         edtTituloId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_tituloprorrogacaoauxdatetext_Jsonclick = "";
         chkavSelectall.Visible = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         divLayoutmaintable_Class = "Table TableWithSelectableGrid";
         chkavSelected_Titleformat = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "|18.2|18.2|||";
         Ddo_grid_Datalistproc = "SelecionarTitulosGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic||||Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T||||T|T";
         Ddo_grid_Filterisrange = "|T|T|P||";
         Ddo_grid_Filtertype = "Character|Numeric|Numeric|Date|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6";
         Ddo_grid_Columnids = "3:TituloCLienteRazaoSocial|4:TituloValor|5:TituloDesconto|12:TituloProrrogacao|22:TituloPropostaDescricao|40:NotaFiscalNumero";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV42i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV43TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV46TituloIdToFind","fld":"vTITULOIDTOFIND","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV49Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV44TituloIdJson","fld":"vTITULOIDJSON","type":"vchar"},{"av":"AV19TFTituloCLienteRazaoSocial","fld":"vTFTITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV20TFTituloCLienteRazaoSocial_Sel","fld":"vTFTITULOCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV21TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV22TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV23TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV26TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV30TFTituloPropostaDescricao","fld":"vTFTITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"AV31TFTituloPropostaDescricao_Sel","fld":"vTFTITULOPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV32TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV33TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV48CarteiraDeCobrancaId","fld":"vCARTEIRADECOBRANCAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV47SelectAll","fld":"vSELECTALL","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"chkavSelected.Title.Text","ctrl":"vSELECTED","prop":"Title"},{"av":"AV47SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"AV36GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV37GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV38GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV43TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV16ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12A52","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV49Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV44TituloIdJson","fld":"vTITULOIDJSON","type":"vchar"},{"av":"AV19TFTituloCLienteRazaoSocial","fld":"vTFTITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV20TFTituloCLienteRazaoSocial_Sel","fld":"vTFTITULOCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV21TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV22TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV23TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV26TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV30TFTituloPropostaDescricao","fld":"vTFTITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"AV31TFTituloPropostaDescricao_Sel","fld":"vTFTITULOPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV32TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV33TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV48CarteiraDeCobrancaId","fld":"vCARTEIRADECOBRANCAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV42i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV43TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV46TituloIdToFind","fld":"vTITULOIDTOFIND","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV47SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13A52","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV49Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV44TituloIdJson","fld":"vTITULOIDJSON","type":"vchar"},{"av":"AV19TFTituloCLienteRazaoSocial","fld":"vTFTITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV20TFTituloCLienteRazaoSocial_Sel","fld":"vTFTITULOCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV21TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV22TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV23TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV26TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV30TFTituloPropostaDescricao","fld":"vTFTITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"AV31TFTituloPropostaDescricao_Sel","fld":"vTFTITULOPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV32TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV33TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV48CarteiraDeCobrancaId","fld":"vCARTEIRADECOBRANCAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV42i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV43TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV46TituloIdToFind","fld":"vTITULOIDTOFIND","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV47SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E14A52","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV49Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV44TituloIdJson","fld":"vTITULOIDJSON","type":"vchar"},{"av":"AV19TFTituloCLienteRazaoSocial","fld":"vTFTITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV20TFTituloCLienteRazaoSocial_Sel","fld":"vTFTITULOCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV21TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV22TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV23TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV26TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV30TFTituloPropostaDescricao","fld":"vTFTITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"AV31TFTituloPropostaDescricao_Sel","fld":"vTFTITULOPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV32TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV33TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV48CarteiraDeCobrancaId","fld":"vCARTEIRADECOBRANCAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV42i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV43TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV46TituloIdToFind","fld":"vTITULOIDTOFIND","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV47SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV32TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV33TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV30TFTituloPropostaDescricao","fld":"vTFTITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"AV31TFTituloPropostaDescricao_Sel","fld":"vTFTITULOPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV25TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV26TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV23TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV21TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV22TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19TFTituloCLienteRazaoSocial","fld":"vTFTITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV20TFTituloCLienteRazaoSocial_Sel","fld":"vTFTITULOCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E19A52","iparms":[{"av":"A261TituloId","fld":"TITULOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV42i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV43TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV46TituloIdToFind","fld":"vTITULOIDTOFIND","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"edtTituloValor_Link","ctrl":"TITULOVALOR","prop":"Link"},{"av":"AV39Selected","fld":"vSELECTED","type":"boolean"},{"av":"AV46TituloIdToFind","fld":"vTITULOIDTOFIND","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV42i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45TituloIdColItem","fld":"vTITULOIDCOLITEM","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("VSELECTED.CLICK","""{"handler":"E20A52","iparms":[{"av":"AV39Selected","fld":"vSELECTED","type":"boolean"},{"av":"A261TituloId","fld":"TITULOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV43TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV42i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46TituloIdToFind","fld":"vTITULOIDTOFIND","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("VSELECTED.CLICK",""","oparms":[{"av":"AV46TituloIdToFind","fld":"vTITULOIDTOFIND","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV43TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV44TituloIdJson","fld":"vTITULOIDJSON","type":"vchar"},{"av":"divLayoutmaintable_Class","ctrl":"LAYOUTMAINTABLE","prop":"Class"},{"av":"AV42i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45TituloIdColItem","fld":"vTITULOIDCOLITEM","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11A52","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV49Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV44TituloIdJson","fld":"vTITULOIDJSON","type":"vchar"},{"av":"AV19TFTituloCLienteRazaoSocial","fld":"vTFTITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV20TFTituloCLienteRazaoSocial_Sel","fld":"vTFTITULOCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV21TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV22TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV23TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV26TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV30TFTituloPropostaDescricao","fld":"vTFTITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"AV31TFTituloPropostaDescricao_Sel","fld":"vTFTITULOPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV32TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV33TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV48CarteiraDeCobrancaId","fld":"vCARTEIRADECOBRANCAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV42i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV43TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV46TituloIdToFind","fld":"vTITULOIDTOFIND","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV47SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV19TFTituloCLienteRazaoSocial","fld":"vTFTITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV20TFTituloCLienteRazaoSocial_Sel","fld":"vTFTITULOCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV21TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV22TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV23TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV26TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV30TFTituloPropostaDescricao","fld":"vTFTITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"AV31TFTituloPropostaDescricao_Sel","fld":"vTFTITULOPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV32TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV33TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"chkavSelected.Title.Text","ctrl":"vSELECTED","prop":"Title"},{"av":"AV47SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"AV36GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV37GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV38GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV43TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV16ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOCONFIRMAR'","""{"handler":"E15A52","iparms":[{"av":"AV40SelectedRows","fld":"vSELECTEDROWS","type":""},{"av":"AV44TituloIdJson","fld":"vTITULOIDJSON","type":"vchar"},{"av":"A261TituloId","fld":"TITULOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A420TituloClienteId","fld":"TITULOCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A972TituloCLienteRazaoSocial","fld":"TITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"A262TituloValor","fld":"TITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","hsh":true,"type":"decimal"},{"av":"A276TituloDesconto","fld":"TITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","hsh":true,"type":"decimal"},{"av":"A284TituloDeleted","fld":"TITULODELETED","hsh":true,"type":"boolean"},{"av":"A314TituloArchived","fld":"TITULOARCHIVED","hsh":true,"type":"boolean"},{"av":"A263TituloVencimento","fld":"TITULOVENCIMENTO","hsh":true,"type":"date"},{"av":"A286TituloCompetenciaAno","fld":"TITULOCOMPETENCIAANO","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"A287TituloCompetenciaMes","fld":"TITULOCOMPETENCIAMES","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"A295TituloCompetencia_F","fld":"TITULOCOMPETENCIA_F","hsh":true,"type":"svchar"},{"av":"A264TituloProrrogacao","fld":"TITULOPRORROGACAO","hsh":true,"type":"date"},{"av":"A265TituloCEP","fld":"TITULOCEP","hsh":true,"type":"svchar"},{"av":"A266TituloLogradouro","fld":"TITULOLOGRADOURO","hsh":true,"type":"svchar"},{"av":"A294TituloNumeroEndereco","fld":"TITULONUMEROENDERECO","hsh":true,"type":"svchar"},{"av":"A267TituloComplemento","fld":"TITULOCOMPLEMENTO","hsh":true,"type":"svchar"},{"av":"A268TituloBairro","fld":"TITULOBAIRRO","hsh":true,"type":"svchar"},{"av":"A269TituloMunicipio","fld":"TITULOMUNICIPIO","hsh":true,"type":"svchar"},{"av":"A498TituloJurosMora","fld":"TITULOJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","hsh":true,"type":"decimal"},{"av":"cmbTituloTipo"},{"av":"A283TituloTipo","fld":"TITULOTIPO","hsh":true,"type":"svchar"},{"av":"A419TituloPropostaId","fld":"TITULOPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A971TituloPropostaDescricao","fld":"TITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"A501PropostaTaxaAdministrativa","fld":"PROPOSTATAXAADMINISTRATIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"A422ContaId","fld":"CONTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A500TituloCriacao","fld":"TITULOCRIACAO","pic":"99/99/99 99:99","hsh":true,"type":"dtime"},{"av":"A426CategoriaTituloId","fld":"CATEGORIATITULOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A516TituloDataCredito_F","fld":"TITULODATACREDITO_F","type":"date"},{"av":"A273TituloTotalMovimento_F","fld":"TITULOTOTALMOVIMENTO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A301TituloTotalMultaJuros_F","fld":"TITULOTOTALMULTAJUROS_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A275TituloSaldo_F","fld":"TITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","hsh":true,"type":"decimal"},{"av":"A282TituloStatus_F","fld":"TITULOSTATUS_F","hsh":true,"type":"svchar"},{"av":"A302TituloSaldoDebito_F","fld":"TITULOSALDODEBITO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","hsh":true,"type":"decimal"},{"av":"A303TituloSaldoCredito_F","fld":"TITULOSALDOCREDITO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","hsh":true,"type":"decimal"},{"av":"A304TituloTotalMovimentoDebito_F","fld":"TITULOTOTALMOVIMENTODEBITO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A305TituloTotalMovimentoCredito_F","fld":"TITULOTOTALMOVIMENTOCREDITO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A306TituloTotalMultaJurosDebito_F","fld":"TITULOTOTALMULTAJUROSDEBITO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A307TituloTotalMultaJurosCredito_F","fld":"TITULOTOTALMULTAJUROSCREDITO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbTituloPropostaTipo"},{"av":"A648TituloPropostaTipo","fld":"TITULOPROPOSTATIPO","hsh":true,"type":"svchar"},{"av":"A890NotaFiscalParcelamentoID","fld":"NOTAFISCALPARCELAMENTOID","hsh":true,"type":"guid"},{"av":"A799NotaFiscalNumero","fld":"NOTAFISCALNUMERO","type":"svchar"},{"av":"A951ContaBancariaId","fld":"CONTABANCARIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A969AgenciaBancoNome","fld":"AGENCIABANCONOME","type":"svchar"},{"av":"A953ContaBancariaCarteira","fld":"CONTABANCARIACARTEIRA","pic":"ZZZZZZZZZ9","type":"int"},{"av":"A952ContaBancariaNumero","fld":"CONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"A939AgenciaNumero","fld":"AGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"A1118TitulosEmCarteiraDeCobranca_F","fld":"TITULOSEMCARTEIRADECOBRANCA_F","hsh":true,"type":"boolean"},{"av":"A1119TitulosCarteiraDeCobranca","fld":"TITULOSCARTEIRADECOBRANCA","type":"svchar"}]""");
         setEventMetadata("'DOCONFIRMAR'",""","oparms":[{"av":"AV40SelectedRows","fld":"vSELECTEDROWS","type":""},{"av":"AV43TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV45TituloIdColItem","fld":"vTITULOIDCOLITEM","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("VSELECTALL.CLICK","""{"handler":"E16A52","iparms":[{"av":"AV47SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"AV33TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV32TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV31TFTituloPropostaDescricao_Sel","fld":"vTFTITULOPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV30TFTituloPropostaDescricao","fld":"vTFTITULOPROPOSTADESCRICAO","type":"svchar"},{"av":"AV26TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV25TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV24TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV23TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV22TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV21TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV20TFTituloCLienteRazaoSocial_Sel","fld":"vTFTITULOCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV19TFTituloCLienteRazaoSocial","fld":"vTFTITULOCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"A1118TitulosEmCarteiraDeCobranca_F","fld":"TITULOSEMCARTEIRADECOBRANCA_F","grid":37,"hsh":true,"type":"boolean"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"nRC_GXsfl_37","ctrl":"GRID","prop":"GridRC","grid":37,"type":"int"},{"av":"A261TituloId","fld":"TITULOID","grid":37,"pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV43TituloIdCol","fld":"vTITULOIDCOL","type":""}]""");
         setEventMetadata("VSELECTALL.CLICK",""","oparms":[{"av":"AV43TituloIdCol","fld":"vTITULOIDCOL","type":""},{"av":"AV39Selected","fld":"vSELECTED","type":"boolean"},{"av":"AV44TituloIdJson","fld":"vTITULOIDJSON","type":"vchar"},{"av":"divLayoutmaintable_Class","ctrl":"LAYOUTMAINTABLE","prop":"Class"}]}""");
         setEventMetadata("VALID_TITULOID","""{"handler":"Valid_Tituloid","iparms":[]}""");
         setEventMetadata("VALID_TITULOCLIENTEID","""{"handler":"Valid_Tituloclienteid","iparms":[]}""");
         setEventMetadata("VALID_TITULOVALOR","""{"handler":"Valid_Titulovalor","iparms":[]}""");
         setEventMetadata("VALID_TITULODESCONTO","""{"handler":"Valid_Titulodesconto","iparms":[]}""");
         setEventMetadata("VALID_TITULOCOMPETENCIAANO","""{"handler":"Valid_Titulocompetenciaano","iparms":[]}""");
         setEventMetadata("VALID_TITULOCOMPETENCIAMES","""{"handler":"Valid_Titulocompetenciames","iparms":[]}""");
         setEventMetadata("VALID_TITULOTIPO","""{"handler":"Valid_Titulotipo","iparms":[]}""");
         setEventMetadata("VALID_TITULOPROPOSTAID","""{"handler":"Valid_Titulopropostaid","iparms":[]}""");
         setEventMetadata("VALID_TITULOTOTALMOVIMENTO_F","""{"handler":"Valid_Titulototalmovimento_f","iparms":[]}""");
         setEventMetadata("VALID_TITULOSALDO_F","""{"handler":"Valid_Titulosaldo_f","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALPARCELAMENTOID","""{"handler":"Valid_Notafiscalparcelamentoid","iparms":[]}""");
         setEventMetadata("VALID_CONTABANCARIAID","""{"handler":"Valid_Contabancariaid","iparms":[]}""");
         setEventMetadata("VALID_TITULOSEMCARTEIRADECOBRANCA_F","""{"handler":"Valid_Titulosemcarteiradecobranca_f","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Tituloscarteiradecobranca","iparms":[]}""");
         return  ;
      }

      protected int GetTitulosEmCarteiraDeCobranca_F0( int E261TituloId )
      {
         Gx_cnt = 0;
         /* Using cursor H00A533 */
         pr_default.execute(4, new Object[] {nA261TituloId, E261TituloId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            Gx_cnt = H00A533_Gx_cnt[0];
         }
         pr_default.close(4);
         return Gx_cnt ;
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
         AV14FilterFullText = "";
         AV49Pgmname = "";
         AV44TituloIdJson = "";
         AV19TFTituloCLienteRazaoSocial = "";
         AV20TFTituloCLienteRazaoSocial_Sel = "";
         AV25TFTituloProrrogacao = DateTime.MinValue;
         AV26TFTituloProrrogacao_To = DateTime.MinValue;
         AV30TFTituloPropostaDescricao = "";
         AV31TFTituloPropostaDescricao_Sel = "";
         AV32TFNotaFiscalNumero = "";
         AV33TFNotaFiscalNumero_Sel = "";
         AV43TituloIdCol = new GxSimpleCollection<int>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV16ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV38GridAppliedFilters = "";
         AV34DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV27DDO_TituloProrrogacaoAuxDate = DateTime.MinValue;
         AV28DDO_TituloProrrogacaoAuxDateTo = DateTime.MinValue;
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV40SelectedRows = new GXBaseCollection<SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem>( context, "SelecionarTitulosSDTItem", "Factory21");
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
         bttBtnconfirmar_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV29DDO_TituloProrrogacaoAuxDateText = "";
         ucTftituloprorrogacao_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A972TituloCLienteRazaoSocial = "";
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
         A971TituloPropostaDescricao = "";
         A500TituloCriacao = (DateTime)(DateTime.MinValue);
         A516TituloDataCredito_F = DateTime.MinValue;
         A282TituloStatus_F = "";
         A648TituloPropostaTipo = "";
         A890NotaFiscalParcelamentoID = Guid.Empty;
         A799NotaFiscalNumero = "";
         A969AgenciaBancoNome = "";
         A1119TitulosCarteiraDeCobranca = "";
         GXDecQS = "";
         AV50Selecionartitulosds_1_filterfulltext = "";
         AV51Selecionartitulosds_2_tftituloclienterazaosocial = "";
         AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel = "";
         AV57Selecionartitulosds_8_tftituloprorrogacao = DateTime.MinValue;
         AV58Selecionartitulosds_9_tftituloprorrogacao_to = DateTime.MinValue;
         AV59Selecionartitulosds_10_tftitulopropostadescricao = "";
         AV60Selecionartitulosds_11_tftitulopropostadescricao_sel = "";
         AV61Selecionartitulosds_12_tfnotafiscalnumero = "";
         AV62Selecionartitulosds_13_tfnotafiscalnumero_sel = "";
         lV50Selecionartitulosds_1_filterfulltext = "";
         lV51Selecionartitulosds_2_tftituloclienterazaosocial = "";
         lV59Selecionartitulosds_10_tftitulopropostadescricao = "";
         lV61Selecionartitulosds_12_tfnotafiscalnumero = "";
         H00A511_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         H00A511_n794NotaFiscalId = new bool[] {false} ;
         H00A511_A938AgenciaId = new int[1] ;
         H00A511_n938AgenciaId = new bool[] {false} ;
         H00A511_A968AgenciaBancoId = new int[1] ;
         H00A511_n968AgenciaBancoId = new bool[] {false} ;
         H00A511_A939AgenciaNumero = new int[1] ;
         H00A511_n939AgenciaNumero = new bool[] {false} ;
         H00A511_A952ContaBancariaNumero = new long[1] ;
         H00A511_n952ContaBancariaNumero = new bool[] {false} ;
         H00A511_A953ContaBancariaCarteira = new long[1] ;
         H00A511_n953ContaBancariaCarteira = new bool[] {false} ;
         H00A511_A969AgenciaBancoNome = new string[] {""} ;
         H00A511_n969AgenciaBancoNome = new bool[] {false} ;
         H00A511_A951ContaBancariaId = new int[1] ;
         H00A511_n951ContaBancariaId = new bool[] {false} ;
         H00A511_A799NotaFiscalNumero = new string[] {""} ;
         H00A511_n799NotaFiscalNumero = new bool[] {false} ;
         H00A511_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         H00A511_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         H00A511_A648TituloPropostaTipo = new string[] {""} ;
         H00A511_n648TituloPropostaTipo = new bool[] {false} ;
         H00A511_A426CategoriaTituloId = new int[1] ;
         H00A511_n426CategoriaTituloId = new bool[] {false} ;
         H00A511_A500TituloCriacao = new DateTime[] {DateTime.MinValue} ;
         H00A511_n500TituloCriacao = new bool[] {false} ;
         H00A511_A422ContaId = new int[1] ;
         H00A511_n422ContaId = new bool[] {false} ;
         H00A511_A501PropostaTaxaAdministrativa = new decimal[1] ;
         H00A511_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         H00A511_A971TituloPropostaDescricao = new string[] {""} ;
         H00A511_n971TituloPropostaDescricao = new bool[] {false} ;
         H00A511_A419TituloPropostaId = new int[1] ;
         H00A511_n419TituloPropostaId = new bool[] {false} ;
         H00A511_A498TituloJurosMora = new decimal[1] ;
         H00A511_n498TituloJurosMora = new bool[] {false} ;
         H00A511_A269TituloMunicipio = new string[] {""} ;
         H00A511_n269TituloMunicipio = new bool[] {false} ;
         H00A511_A268TituloBairro = new string[] {""} ;
         H00A511_n268TituloBairro = new bool[] {false} ;
         H00A511_A267TituloComplemento = new string[] {""} ;
         H00A511_n267TituloComplemento = new bool[] {false} ;
         H00A511_A294TituloNumeroEndereco = new string[] {""} ;
         H00A511_n294TituloNumeroEndereco = new bool[] {false} ;
         H00A511_A266TituloLogradouro = new string[] {""} ;
         H00A511_n266TituloLogradouro = new bool[] {false} ;
         H00A511_A265TituloCEP = new string[] {""} ;
         H00A511_n265TituloCEP = new bool[] {false} ;
         H00A511_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         H00A511_n264TituloProrrogacao = new bool[] {false} ;
         H00A511_A263TituloVencimento = new DateTime[] {DateTime.MinValue} ;
         H00A511_n263TituloVencimento = new bool[] {false} ;
         H00A511_A314TituloArchived = new bool[] {false} ;
         H00A511_n314TituloArchived = new bool[] {false} ;
         H00A511_A284TituloDeleted = new bool[] {false} ;
         H00A511_n284TituloDeleted = new bool[] {false} ;
         H00A511_A972TituloCLienteRazaoSocial = new string[] {""} ;
         H00A511_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         H00A511_A420TituloClienteId = new int[1] ;
         H00A511_n420TituloClienteId = new bool[] {false} ;
         H00A511_A261TituloId = new int[1] ;
         H00A511_n261TituloId = new bool[] {false} ;
         H00A511_A1119TitulosCarteiraDeCobranca = new string[] {""} ;
         H00A511_n1119TitulosCarteiraDeCobranca = new bool[] {false} ;
         H00A511_A307TituloTotalMultaJurosCredito_F = new decimal[1] ;
         H00A511_n307TituloTotalMultaJurosCredito_F = new bool[] {false} ;
         H00A511_A306TituloTotalMultaJurosDebito_F = new decimal[1] ;
         H00A511_n306TituloTotalMultaJurosDebito_F = new bool[] {false} ;
         H00A511_A305TituloTotalMovimentoCredito_F = new decimal[1] ;
         H00A511_n305TituloTotalMovimentoCredito_F = new bool[] {false} ;
         H00A511_A304TituloTotalMovimentoDebito_F = new decimal[1] ;
         H00A511_n304TituloTotalMovimentoDebito_F = new bool[] {false} ;
         H00A511_A301TituloTotalMultaJuros_F = new decimal[1] ;
         H00A511_n301TituloTotalMultaJuros_F = new bool[] {false} ;
         H00A511_A516TituloDataCredito_F = new DateTime[] {DateTime.MinValue} ;
         H00A511_n516TituloDataCredito_F = new bool[] {false} ;
         H00A511_A286TituloCompetenciaAno = new short[1] ;
         H00A511_n286TituloCompetenciaAno = new bool[] {false} ;
         H00A511_A287TituloCompetenciaMes = new short[1] ;
         H00A511_n287TituloCompetenciaMes = new bool[] {false} ;
         H00A511_A273TituloTotalMovimento_F = new decimal[1] ;
         H00A511_A276TituloDesconto = new decimal[1] ;
         H00A511_n276TituloDesconto = new bool[] {false} ;
         H00A511_A262TituloValor = new decimal[1] ;
         H00A511_n262TituloValor = new bool[] {false} ;
         H00A511_A283TituloTipo = new string[] {""} ;
         H00A511_n283TituloTipo = new bool[] {false} ;
         A794NotaFiscalId = Guid.Empty;
         H00A521_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         H00A521_n794NotaFiscalId = new bool[] {false} ;
         H00A521_A938AgenciaId = new int[1] ;
         H00A521_n938AgenciaId = new bool[] {false} ;
         H00A521_A968AgenciaBancoId = new int[1] ;
         H00A521_n968AgenciaBancoId = new bool[] {false} ;
         H00A521_A939AgenciaNumero = new int[1] ;
         H00A521_n939AgenciaNumero = new bool[] {false} ;
         H00A521_A952ContaBancariaNumero = new long[1] ;
         H00A521_n952ContaBancariaNumero = new bool[] {false} ;
         H00A521_A953ContaBancariaCarteira = new long[1] ;
         H00A521_n953ContaBancariaCarteira = new bool[] {false} ;
         H00A521_A969AgenciaBancoNome = new string[] {""} ;
         H00A521_n969AgenciaBancoNome = new bool[] {false} ;
         H00A521_A951ContaBancariaId = new int[1] ;
         H00A521_n951ContaBancariaId = new bool[] {false} ;
         H00A521_A799NotaFiscalNumero = new string[] {""} ;
         H00A521_n799NotaFiscalNumero = new bool[] {false} ;
         H00A521_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         H00A521_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         H00A521_A648TituloPropostaTipo = new string[] {""} ;
         H00A521_n648TituloPropostaTipo = new bool[] {false} ;
         H00A521_A426CategoriaTituloId = new int[1] ;
         H00A521_n426CategoriaTituloId = new bool[] {false} ;
         H00A521_A500TituloCriacao = new DateTime[] {DateTime.MinValue} ;
         H00A521_n500TituloCriacao = new bool[] {false} ;
         H00A521_A422ContaId = new int[1] ;
         H00A521_n422ContaId = new bool[] {false} ;
         H00A521_A501PropostaTaxaAdministrativa = new decimal[1] ;
         H00A521_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         H00A521_A971TituloPropostaDescricao = new string[] {""} ;
         H00A521_n971TituloPropostaDescricao = new bool[] {false} ;
         H00A521_A419TituloPropostaId = new int[1] ;
         H00A521_n419TituloPropostaId = new bool[] {false} ;
         H00A521_A498TituloJurosMora = new decimal[1] ;
         H00A521_n498TituloJurosMora = new bool[] {false} ;
         H00A521_A269TituloMunicipio = new string[] {""} ;
         H00A521_n269TituloMunicipio = new bool[] {false} ;
         H00A521_A268TituloBairro = new string[] {""} ;
         H00A521_n268TituloBairro = new bool[] {false} ;
         H00A521_A267TituloComplemento = new string[] {""} ;
         H00A521_n267TituloComplemento = new bool[] {false} ;
         H00A521_A294TituloNumeroEndereco = new string[] {""} ;
         H00A521_n294TituloNumeroEndereco = new bool[] {false} ;
         H00A521_A266TituloLogradouro = new string[] {""} ;
         H00A521_n266TituloLogradouro = new bool[] {false} ;
         H00A521_A265TituloCEP = new string[] {""} ;
         H00A521_n265TituloCEP = new bool[] {false} ;
         H00A521_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         H00A521_n264TituloProrrogacao = new bool[] {false} ;
         H00A521_A263TituloVencimento = new DateTime[] {DateTime.MinValue} ;
         H00A521_n263TituloVencimento = new bool[] {false} ;
         H00A521_A314TituloArchived = new bool[] {false} ;
         H00A521_n314TituloArchived = new bool[] {false} ;
         H00A521_A284TituloDeleted = new bool[] {false} ;
         H00A521_n284TituloDeleted = new bool[] {false} ;
         H00A521_A972TituloCLienteRazaoSocial = new string[] {""} ;
         H00A521_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         H00A521_A420TituloClienteId = new int[1] ;
         H00A521_n420TituloClienteId = new bool[] {false} ;
         H00A521_A261TituloId = new int[1] ;
         H00A521_n261TituloId = new bool[] {false} ;
         H00A521_A1119TitulosCarteiraDeCobranca = new string[] {""} ;
         H00A521_n1119TitulosCarteiraDeCobranca = new bool[] {false} ;
         H00A521_A307TituloTotalMultaJurosCredito_F = new decimal[1] ;
         H00A521_n307TituloTotalMultaJurosCredito_F = new bool[] {false} ;
         H00A521_A306TituloTotalMultaJurosDebito_F = new decimal[1] ;
         H00A521_n306TituloTotalMultaJurosDebito_F = new bool[] {false} ;
         H00A521_A305TituloTotalMovimentoCredito_F = new decimal[1] ;
         H00A521_n305TituloTotalMovimentoCredito_F = new bool[] {false} ;
         H00A521_A304TituloTotalMovimentoDebito_F = new decimal[1] ;
         H00A521_n304TituloTotalMovimentoDebito_F = new bool[] {false} ;
         H00A521_A301TituloTotalMultaJuros_F = new decimal[1] ;
         H00A521_n301TituloTotalMultaJuros_F = new bool[] {false} ;
         H00A521_A516TituloDataCredito_F = new DateTime[] {DateTime.MinValue} ;
         H00A521_n516TituloDataCredito_F = new bool[] {false} ;
         H00A521_A286TituloCompetenciaAno = new short[1] ;
         H00A521_n286TituloCompetenciaAno = new bool[] {false} ;
         H00A521_A287TituloCompetenciaMes = new short[1] ;
         H00A521_n287TituloCompetenciaMes = new bool[] {false} ;
         H00A521_A273TituloTotalMovimento_F = new decimal[1] ;
         H00A521_A276TituloDesconto = new decimal[1] ;
         H00A521_n276TituloDesconto = new bool[] {false} ;
         H00A521_A262TituloValor = new decimal[1] ;
         H00A521_n262TituloValor = new bool[] {false} ;
         H00A521_A283TituloTipo = new string[] {""} ;
         H00A521_n283TituloTipo = new bool[] {false} ;
         AV7HTTPRequest = new GxHttpRequest( context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV17ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV41SelectedRow = new SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem(context);
         H00A531_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         H00A531_n794NotaFiscalId = new bool[] {false} ;
         H00A531_A938AgenciaId = new int[1] ;
         H00A531_n938AgenciaId = new bool[] {false} ;
         H00A531_A968AgenciaBancoId = new int[1] ;
         H00A531_n968AgenciaBancoId = new bool[] {false} ;
         H00A531_A261TituloId = new int[1] ;
         H00A531_n261TituloId = new bool[] {false} ;
         H00A531_A420TituloClienteId = new int[1] ;
         H00A531_n420TituloClienteId = new bool[] {false} ;
         H00A531_A972TituloCLienteRazaoSocial = new string[] {""} ;
         H00A531_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         H00A531_A284TituloDeleted = new bool[] {false} ;
         H00A531_n284TituloDeleted = new bool[] {false} ;
         H00A531_A314TituloArchived = new bool[] {false} ;
         H00A531_n314TituloArchived = new bool[] {false} ;
         H00A531_A263TituloVencimento = new DateTime[] {DateTime.MinValue} ;
         H00A531_n263TituloVencimento = new bool[] {false} ;
         H00A531_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         H00A531_n264TituloProrrogacao = new bool[] {false} ;
         H00A531_A265TituloCEP = new string[] {""} ;
         H00A531_n265TituloCEP = new bool[] {false} ;
         H00A531_A266TituloLogradouro = new string[] {""} ;
         H00A531_n266TituloLogradouro = new bool[] {false} ;
         H00A531_A294TituloNumeroEndereco = new string[] {""} ;
         H00A531_n294TituloNumeroEndereco = new bool[] {false} ;
         H00A531_A267TituloComplemento = new string[] {""} ;
         H00A531_n267TituloComplemento = new bool[] {false} ;
         H00A531_A268TituloBairro = new string[] {""} ;
         H00A531_n268TituloBairro = new bool[] {false} ;
         H00A531_A269TituloMunicipio = new string[] {""} ;
         H00A531_n269TituloMunicipio = new bool[] {false} ;
         H00A531_A498TituloJurosMora = new decimal[1] ;
         H00A531_n498TituloJurosMora = new bool[] {false} ;
         H00A531_A419TituloPropostaId = new int[1] ;
         H00A531_n419TituloPropostaId = new bool[] {false} ;
         H00A531_A971TituloPropostaDescricao = new string[] {""} ;
         H00A531_n971TituloPropostaDescricao = new bool[] {false} ;
         H00A531_A501PropostaTaxaAdministrativa = new decimal[1] ;
         H00A531_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         H00A531_A422ContaId = new int[1] ;
         H00A531_n422ContaId = new bool[] {false} ;
         H00A531_A500TituloCriacao = new DateTime[] {DateTime.MinValue} ;
         H00A531_n500TituloCriacao = new bool[] {false} ;
         H00A531_A426CategoriaTituloId = new int[1] ;
         H00A531_n426CategoriaTituloId = new bool[] {false} ;
         H00A531_A648TituloPropostaTipo = new string[] {""} ;
         H00A531_n648TituloPropostaTipo = new bool[] {false} ;
         H00A531_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         H00A531_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         H00A531_A799NotaFiscalNumero = new string[] {""} ;
         H00A531_n799NotaFiscalNumero = new bool[] {false} ;
         H00A531_A951ContaBancariaId = new int[1] ;
         H00A531_n951ContaBancariaId = new bool[] {false} ;
         H00A531_A969AgenciaBancoNome = new string[] {""} ;
         H00A531_n969AgenciaBancoNome = new bool[] {false} ;
         H00A531_A953ContaBancariaCarteira = new long[1] ;
         H00A531_n953ContaBancariaCarteira = new bool[] {false} ;
         H00A531_A952ContaBancariaNumero = new long[1] ;
         H00A531_n952ContaBancariaNumero = new bool[] {false} ;
         H00A531_A939AgenciaNumero = new int[1] ;
         H00A531_n939AgenciaNumero = new bool[] {false} ;
         H00A531_A516TituloDataCredito_F = new DateTime[] {DateTime.MinValue} ;
         H00A531_n516TituloDataCredito_F = new bool[] {false} ;
         H00A531_A301TituloTotalMultaJuros_F = new decimal[1] ;
         H00A531_n301TituloTotalMultaJuros_F = new bool[] {false} ;
         H00A531_A304TituloTotalMovimentoDebito_F = new decimal[1] ;
         H00A531_n304TituloTotalMovimentoDebito_F = new bool[] {false} ;
         H00A531_A305TituloTotalMovimentoCredito_F = new decimal[1] ;
         H00A531_n305TituloTotalMovimentoCredito_F = new bool[] {false} ;
         H00A531_A306TituloTotalMultaJurosDebito_F = new decimal[1] ;
         H00A531_n306TituloTotalMultaJurosDebito_F = new bool[] {false} ;
         H00A531_A307TituloTotalMultaJurosCredito_F = new decimal[1] ;
         H00A531_n307TituloTotalMultaJurosCredito_F = new bool[] {false} ;
         H00A531_A1119TitulosCarteiraDeCobranca = new string[] {""} ;
         H00A531_n1119TitulosCarteiraDeCobranca = new bool[] {false} ;
         H00A531_A283TituloTipo = new string[] {""} ;
         H00A531_n283TituloTipo = new bool[] {false} ;
         H00A531_A273TituloTotalMovimento_F = new decimal[1] ;
         H00A531_A276TituloDesconto = new decimal[1] ;
         H00A531_n276TituloDesconto = new bool[] {false} ;
         H00A531_A262TituloValor = new decimal[1] ;
         H00A531_n262TituloValor = new bool[] {false} ;
         H00A531_A286TituloCompetenciaAno = new short[1] ;
         H00A531_n286TituloCompetenciaAno = new bool[] {false} ;
         H00A531_A287TituloCompetenciaMes = new short[1] ;
         H00A531_n287TituloCompetenciaMes = new bool[] {false} ;
         AV15Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char2 = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         H00A532_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         H00A532_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         H00A532_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         H00A532_n794NotaFiscalId = new bool[] {false} ;
         H00A532_A419TituloPropostaId = new int[1] ;
         H00A532_n419TituloPropostaId = new bool[] {false} ;
         H00A532_A420TituloClienteId = new int[1] ;
         H00A532_n420TituloClienteId = new bool[] {false} ;
         H00A532_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         H00A532_n264TituloProrrogacao = new bool[] {false} ;
         H00A532_A276TituloDesconto = new decimal[1] ;
         H00A532_n276TituloDesconto = new bool[] {false} ;
         H00A532_A262TituloValor = new decimal[1] ;
         H00A532_n262TituloValor = new bool[] {false} ;
         H00A532_A799NotaFiscalNumero = new string[] {""} ;
         H00A532_n799NotaFiscalNumero = new bool[] {false} ;
         H00A532_A971TituloPropostaDescricao = new string[] {""} ;
         H00A532_n971TituloPropostaDescricao = new bool[] {false} ;
         H00A532_A972TituloCLienteRazaoSocial = new string[] {""} ;
         H00A532_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         H00A532_A261TituloId = new int[1] ;
         H00A532_n261TituloId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         H00A533_Gx_cnt = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.selecionartitulos__default(),
            new Object[][] {
                new Object[] {
               H00A511_A794NotaFiscalId, H00A511_n794NotaFiscalId, H00A511_A938AgenciaId, H00A511_n938AgenciaId, H00A511_A968AgenciaBancoId, H00A511_n968AgenciaBancoId, H00A511_A939AgenciaNumero, H00A511_n939AgenciaNumero, H00A511_A952ContaBancariaNumero, H00A511_n952ContaBancariaNumero,
               H00A511_A953ContaBancariaCarteira, H00A511_n953ContaBancariaCarteira, H00A511_A969AgenciaBancoNome, H00A511_n969AgenciaBancoNome, H00A511_A951ContaBancariaId, H00A511_n951ContaBancariaId, H00A511_A799NotaFiscalNumero, H00A511_n799NotaFiscalNumero, H00A511_A890NotaFiscalParcelamentoID, H00A511_n890NotaFiscalParcelamentoID,
               H00A511_A648TituloPropostaTipo, H00A511_n648TituloPropostaTipo, H00A511_A426CategoriaTituloId, H00A511_n426CategoriaTituloId, H00A511_A500TituloCriacao, H00A511_n500TituloCriacao, H00A511_A422ContaId, H00A511_n422ContaId, H00A511_A501PropostaTaxaAdministrativa, H00A511_n501PropostaTaxaAdministrativa,
               H00A511_A971TituloPropostaDescricao, H00A511_n971TituloPropostaDescricao, H00A511_A419TituloPropostaId, H00A511_n419TituloPropostaId, H00A511_A498TituloJurosMora, H00A511_n498TituloJurosMora, H00A511_A269TituloMunicipio, H00A511_n269TituloMunicipio, H00A511_A268TituloBairro, H00A511_n268TituloBairro,
               H00A511_A267TituloComplemento, H00A511_n267TituloComplemento, H00A511_A294TituloNumeroEndereco, H00A511_n294TituloNumeroEndereco, H00A511_A266TituloLogradouro, H00A511_n266TituloLogradouro, H00A511_A265TituloCEP, H00A511_n265TituloCEP, H00A511_A264TituloProrrogacao, H00A511_n264TituloProrrogacao,
               H00A511_A263TituloVencimento, H00A511_n263TituloVencimento, H00A511_A314TituloArchived, H00A511_n314TituloArchived, H00A511_A284TituloDeleted, H00A511_n284TituloDeleted, H00A511_A972TituloCLienteRazaoSocial, H00A511_n972TituloCLienteRazaoSocial, H00A511_A420TituloClienteId, H00A511_n420TituloClienteId,
               H00A511_A261TituloId, H00A511_A1119TitulosCarteiraDeCobranca, H00A511_n1119TitulosCarteiraDeCobranca, H00A511_A307TituloTotalMultaJurosCredito_F, H00A511_n307TituloTotalMultaJurosCredito_F, H00A511_A306TituloTotalMultaJurosDebito_F, H00A511_n306TituloTotalMultaJurosDebito_F, H00A511_A305TituloTotalMovimentoCredito_F, H00A511_n305TituloTotalMovimentoCredito_F, H00A511_A304TituloTotalMovimentoDebito_F,
               H00A511_n304TituloTotalMovimentoDebito_F, H00A511_A301TituloTotalMultaJuros_F, H00A511_n301TituloTotalMultaJuros_F, H00A511_A516TituloDataCredito_F, H00A511_n516TituloDataCredito_F, H00A511_A286TituloCompetenciaAno, H00A511_n286TituloCompetenciaAno, H00A511_A287TituloCompetenciaMes, H00A511_n287TituloCompetenciaMes, H00A511_A273TituloTotalMovimento_F,
               H00A511_A276TituloDesconto, H00A511_n276TituloDesconto, H00A511_A262TituloValor, H00A511_n262TituloValor, H00A511_A283TituloTipo, H00A511_n283TituloTipo
               }
               , new Object[] {
               H00A521_A794NotaFiscalId, H00A521_n794NotaFiscalId, H00A521_A938AgenciaId, H00A521_n938AgenciaId, H00A521_A968AgenciaBancoId, H00A521_n968AgenciaBancoId, H00A521_A939AgenciaNumero, H00A521_n939AgenciaNumero, H00A521_A952ContaBancariaNumero, H00A521_n952ContaBancariaNumero,
               H00A521_A953ContaBancariaCarteira, H00A521_n953ContaBancariaCarteira, H00A521_A969AgenciaBancoNome, H00A521_n969AgenciaBancoNome, H00A521_A951ContaBancariaId, H00A521_n951ContaBancariaId, H00A521_A799NotaFiscalNumero, H00A521_n799NotaFiscalNumero, H00A521_A890NotaFiscalParcelamentoID, H00A521_n890NotaFiscalParcelamentoID,
               H00A521_A648TituloPropostaTipo, H00A521_n648TituloPropostaTipo, H00A521_A426CategoriaTituloId, H00A521_n426CategoriaTituloId, H00A521_A500TituloCriacao, H00A521_n500TituloCriacao, H00A521_A422ContaId, H00A521_n422ContaId, H00A521_A501PropostaTaxaAdministrativa, H00A521_n501PropostaTaxaAdministrativa,
               H00A521_A971TituloPropostaDescricao, H00A521_n971TituloPropostaDescricao, H00A521_A419TituloPropostaId, H00A521_n419TituloPropostaId, H00A521_A498TituloJurosMora, H00A521_n498TituloJurosMora, H00A521_A269TituloMunicipio, H00A521_n269TituloMunicipio, H00A521_A268TituloBairro, H00A521_n268TituloBairro,
               H00A521_A267TituloComplemento, H00A521_n267TituloComplemento, H00A521_A294TituloNumeroEndereco, H00A521_n294TituloNumeroEndereco, H00A521_A266TituloLogradouro, H00A521_n266TituloLogradouro, H00A521_A265TituloCEP, H00A521_n265TituloCEP, H00A521_A264TituloProrrogacao, H00A521_n264TituloProrrogacao,
               H00A521_A263TituloVencimento, H00A521_n263TituloVencimento, H00A521_A314TituloArchived, H00A521_n314TituloArchived, H00A521_A284TituloDeleted, H00A521_n284TituloDeleted, H00A521_A972TituloCLienteRazaoSocial, H00A521_n972TituloCLienteRazaoSocial, H00A521_A420TituloClienteId, H00A521_n420TituloClienteId,
               H00A521_A261TituloId, H00A521_A1119TitulosCarteiraDeCobranca, H00A521_n1119TitulosCarteiraDeCobranca, H00A521_A307TituloTotalMultaJurosCredito_F, H00A521_n307TituloTotalMultaJurosCredito_F, H00A521_A306TituloTotalMultaJurosDebito_F, H00A521_n306TituloTotalMultaJurosDebito_F, H00A521_A305TituloTotalMovimentoCredito_F, H00A521_n305TituloTotalMovimentoCredito_F, H00A521_A304TituloTotalMovimentoDebito_F,
               H00A521_n304TituloTotalMovimentoDebito_F, H00A521_A301TituloTotalMultaJuros_F, H00A521_n301TituloTotalMultaJuros_F, H00A521_A516TituloDataCredito_F, H00A521_n516TituloDataCredito_F, H00A521_A286TituloCompetenciaAno, H00A521_n286TituloCompetenciaAno, H00A521_A287TituloCompetenciaMes, H00A521_n287TituloCompetenciaMes, H00A521_A273TituloTotalMovimento_F,
               H00A521_A276TituloDesconto, H00A521_n276TituloDesconto, H00A521_A262TituloValor, H00A521_n262TituloValor, H00A521_A283TituloTipo, H00A521_n283TituloTipo
               }
               , new Object[] {
               H00A531_A794NotaFiscalId, H00A531_n794NotaFiscalId, H00A531_A938AgenciaId, H00A531_n938AgenciaId, H00A531_A968AgenciaBancoId, H00A531_n968AgenciaBancoId, H00A531_A261TituloId, H00A531_A420TituloClienteId, H00A531_n420TituloClienteId, H00A531_A972TituloCLienteRazaoSocial,
               H00A531_n972TituloCLienteRazaoSocial, H00A531_A284TituloDeleted, H00A531_n284TituloDeleted, H00A531_A314TituloArchived, H00A531_n314TituloArchived, H00A531_A263TituloVencimento, H00A531_n263TituloVencimento, H00A531_A264TituloProrrogacao, H00A531_n264TituloProrrogacao, H00A531_A265TituloCEP,
               H00A531_n265TituloCEP, H00A531_A266TituloLogradouro, H00A531_n266TituloLogradouro, H00A531_A294TituloNumeroEndereco, H00A531_n294TituloNumeroEndereco, H00A531_A267TituloComplemento, H00A531_n267TituloComplemento, H00A531_A268TituloBairro, H00A531_n268TituloBairro, H00A531_A269TituloMunicipio,
               H00A531_n269TituloMunicipio, H00A531_A498TituloJurosMora, H00A531_n498TituloJurosMora, H00A531_A419TituloPropostaId, H00A531_n419TituloPropostaId, H00A531_A971TituloPropostaDescricao, H00A531_n971TituloPropostaDescricao, H00A531_A501PropostaTaxaAdministrativa, H00A531_n501PropostaTaxaAdministrativa, H00A531_A422ContaId,
               H00A531_n422ContaId, H00A531_A500TituloCriacao, H00A531_n500TituloCriacao, H00A531_A426CategoriaTituloId, H00A531_n426CategoriaTituloId, H00A531_A648TituloPropostaTipo, H00A531_n648TituloPropostaTipo, H00A531_A890NotaFiscalParcelamentoID, H00A531_n890NotaFiscalParcelamentoID, H00A531_A799NotaFiscalNumero,
               H00A531_n799NotaFiscalNumero, H00A531_A951ContaBancariaId, H00A531_n951ContaBancariaId, H00A531_A969AgenciaBancoNome, H00A531_n969AgenciaBancoNome, H00A531_A953ContaBancariaCarteira, H00A531_n953ContaBancariaCarteira, H00A531_A952ContaBancariaNumero, H00A531_n952ContaBancariaNumero, H00A531_A939AgenciaNumero,
               H00A531_n939AgenciaNumero, H00A531_A516TituloDataCredito_F, H00A531_n516TituloDataCredito_F, H00A531_A301TituloTotalMultaJuros_F, H00A531_n301TituloTotalMultaJuros_F, H00A531_A304TituloTotalMovimentoDebito_F, H00A531_n304TituloTotalMovimentoDebito_F, H00A531_A305TituloTotalMovimentoCredito_F, H00A531_n305TituloTotalMovimentoCredito_F, H00A531_A306TituloTotalMultaJurosDebito_F,
               H00A531_n306TituloTotalMultaJurosDebito_F, H00A531_A307TituloTotalMultaJurosCredito_F, H00A531_n307TituloTotalMultaJurosCredito_F, H00A531_A1119TitulosCarteiraDeCobranca, H00A531_n1119TitulosCarteiraDeCobranca, H00A531_A283TituloTipo, H00A531_n283TituloTipo, H00A531_A273TituloTotalMovimento_F, H00A531_A276TituloDesconto, H00A531_n276TituloDesconto,
               H00A531_A262TituloValor, H00A531_n262TituloValor, H00A531_A286TituloCompetenciaAno, H00A531_n286TituloCompetenciaAno, H00A531_A287TituloCompetenciaMes, H00A531_n287TituloCompetenciaMes
               }
               , new Object[] {
               H00A532_A890NotaFiscalParcelamentoID, H00A532_n890NotaFiscalParcelamentoID, H00A532_A794NotaFiscalId, H00A532_n794NotaFiscalId, H00A532_A419TituloPropostaId, H00A532_n419TituloPropostaId, H00A532_A420TituloClienteId, H00A532_n420TituloClienteId, H00A532_A264TituloProrrogacao, H00A532_n264TituloProrrogacao,
               H00A532_A276TituloDesconto, H00A532_n276TituloDesconto, H00A532_A262TituloValor, H00A532_n262TituloValor, H00A532_A799NotaFiscalNumero, H00A532_n799NotaFiscalNumero, H00A532_A971TituloPropostaDescricao, H00A532_n971TituloPropostaDescricao, H00A532_A972TituloCLienteRazaoSocial, H00A532_n972TituloCLienteRazaoSocial,
               H00A532_A261TituloId
               }
               , new Object[] {
               H00A533_Gx_cnt
               }
            }
         );
         AV49Pgmname = "SelecionarTitulos";
         /* GeneXus formulas. */
         AV49Pgmname = "SelecionarTitulos";
      }

      private short chkavSelected_Titleformat ;
      private short GRID_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV12OrderedBy ;
      private short AV18ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A286TituloCompetenciaAno ;
      private short A287TituloCompetenciaMes ;
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
      private int AV48CarteiraDeCobrancaId ;
      private int wcpOAV48CarteiraDeCobrancaId ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_37 ;
      private int nGXsfl_37_idx=1 ;
      private int AV46TituloIdToFind ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A261TituloId ;
      private int A420TituloClienteId ;
      private int A419TituloPropostaId ;
      private int A422ContaId ;
      private int A426CategoriaTituloId ;
      private int A951ContaBancariaId ;
      private int A939AgenciaNumero ;
      private int subGrid_Islastpage ;
      private int A938AgenciaId ;
      private int A968AgenciaBancoId ;
      private int edtTituloId_Enabled ;
      private int edtTituloClienteId_Enabled ;
      private int edtTituloCLienteRazaoSocial_Enabled ;
      private int edtTituloValor_Enabled ;
      private int edtTituloDesconto_Enabled ;
      private int edtTituloVencimento_Enabled ;
      private int edtTituloCompetenciaAno_Enabled ;
      private int edtTituloCompetenciaMes_Enabled ;
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
      private int edtTituloPropostaDescricao_Enabled ;
      private int edtPropostaTaxaAdministrativa_Enabled ;
      private int edtContaId_Enabled ;
      private int edtTituloCriacao_Enabled ;
      private int edtCategoriaTituloId_Enabled ;
      private int edtTituloDataCredito_F_Enabled ;
      private int edtTituloTotalMovimento_F_Enabled ;
      private int edtTituloTotalMultaJuros_F_Enabled ;
      private int edtTituloSaldo_F_Enabled ;
      private int edtTituloStatus_F_Enabled ;
      private int edtTituloSaldoDebito_F_Enabled ;
      private int edtTituloSaldoCredito_F_Enabled ;
      private int edtTituloTotalMovimentoDebito_F_Enabled ;
      private int edtTituloTotalMovimentoCredito_F_Enabled ;
      private int edtTituloTotalMultaJurosDebito_F_Enabled ;
      private int edtTituloTotalMultaJurosCredito_F_Enabled ;
      private int edtNotaFiscalParcelamentoID_Enabled ;
      private int edtNotaFiscalNumero_Enabled ;
      private int edtContaBancariaId_Enabled ;
      private int edtAgenciaBancoNome_Enabled ;
      private int edtContaBancariaCarteira_Enabled ;
      private int edtContaBancariaNumero_Enabled ;
      private int edtAgenciaNumero_Enabled ;
      private int edtTitulosCarteiraDeCobranca_Enabled ;
      private int AV35PageToGo ;
      private int nGXsfl_37_fel_idx=1 ;
      private int AV64GXV1 ;
      private int AV45TituloIdColItem ;
      private int AV65GXV2 ;
      private int AV67GXV3 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int Gx_cnt ;
      private int E261TituloId ;
      private long GRID_nFirstRecordOnPage ;
      private long AV42i ;
      private long AV36GridCurrentPage ;
      private long AV37GridPageCount ;
      private long A953ContaBancariaCarteira ;
      private long A952ContaBancariaNumero ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV21TFTituloValor ;
      private decimal AV22TFTituloValor_To ;
      private decimal AV23TFTituloDesconto ;
      private decimal AV24TFTituloDesconto_To ;
      private decimal A262TituloValor ;
      private decimal A276TituloDesconto ;
      private decimal A498TituloJurosMora ;
      private decimal A501PropostaTaxaAdministrativa ;
      private decimal A273TituloTotalMovimento_F ;
      private decimal A301TituloTotalMultaJuros_F ;
      private decimal A275TituloSaldo_F ;
      private decimal A302TituloSaldoDebito_F ;
      private decimal A303TituloSaldoCredito_F ;
      private decimal A304TituloTotalMovimentoDebito_F ;
      private decimal A305TituloTotalMovimentoCredito_F ;
      private decimal A306TituloTotalMultaJurosDebito_F ;
      private decimal A307TituloTotalMultaJurosCredito_F ;
      private decimal AV53Selecionartitulosds_4_tftitulovalor ;
      private decimal AV54Selecionartitulosds_5_tftitulovalor_to ;
      private decimal AV55Selecionartitulosds_6_tftitulodesconto ;
      private decimal AV56Selecionartitulosds_7_tftitulodesconto_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_37_idx="0001" ;
      private string AV49Pgmname ;
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
      private string bttBtnconfirmar_Internalname ;
      private string bttBtnconfirmar_Jsonclick ;
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
      private string edtTituloValor_Internalname ;
      private string edtTituloDesconto_Internalname ;
      private string chkTituloDeleted_Internalname ;
      private string chkTituloArchived_Internalname ;
      private string edtTituloVencimento_Internalname ;
      private string edtTituloCompetenciaAno_Internalname ;
      private string edtTituloCompetenciaMes_Internalname ;
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
      private string edtTituloPropostaDescricao_Internalname ;
      private string edtPropostaTaxaAdministrativa_Internalname ;
      private string edtContaId_Internalname ;
      private string edtTituloCriacao_Internalname ;
      private string edtCategoriaTituloId_Internalname ;
      private string edtTituloDataCredito_F_Internalname ;
      private string edtTituloTotalMovimento_F_Internalname ;
      private string edtTituloTotalMultaJuros_F_Internalname ;
      private string edtTituloSaldo_F_Internalname ;
      private string edtTituloStatus_F_Internalname ;
      private string edtTituloSaldoDebito_F_Internalname ;
      private string edtTituloSaldoCredito_F_Internalname ;
      private string edtTituloTotalMovimentoDebito_F_Internalname ;
      private string edtTituloTotalMovimentoCredito_F_Internalname ;
      private string edtTituloTotalMultaJurosDebito_F_Internalname ;
      private string edtTituloTotalMultaJurosCredito_F_Internalname ;
      private string cmbTituloPropostaTipo_Internalname ;
      private string edtNotaFiscalParcelamentoID_Internalname ;
      private string edtNotaFiscalNumero_Internalname ;
      private string edtContaBancariaId_Internalname ;
      private string edtAgenciaBancoNome_Internalname ;
      private string edtContaBancariaCarteira_Internalname ;
      private string edtContaBancariaNumero_Internalname ;
      private string edtAgenciaNumero_Internalname ;
      private string chkTitulosEmCarteiraDeCobranca_F_Internalname ;
      private string edtTitulosCarteiraDeCobranca_Internalname ;
      private string GXDecQS ;
      private string edtTituloValor_Link ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string ROClassString ;
      private string edtTituloId_Jsonclick ;
      private string edtTituloClienteId_Jsonclick ;
      private string edtTituloCLienteRazaoSocial_Jsonclick ;
      private string edtTituloValor_Jsonclick ;
      private string edtTituloDesconto_Jsonclick ;
      private string edtTituloVencimento_Jsonclick ;
      private string edtTituloCompetenciaAno_Jsonclick ;
      private string edtTituloCompetenciaMes_Jsonclick ;
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
      private string edtTituloPropostaDescricao_Jsonclick ;
      private string edtPropostaTaxaAdministrativa_Jsonclick ;
      private string edtContaId_Jsonclick ;
      private string edtTituloCriacao_Jsonclick ;
      private string edtCategoriaTituloId_Jsonclick ;
      private string edtTituloDataCredito_F_Jsonclick ;
      private string edtTituloTotalMovimento_F_Jsonclick ;
      private string edtTituloTotalMultaJuros_F_Jsonclick ;
      private string edtTituloSaldo_F_Jsonclick ;
      private string edtTituloStatus_F_Jsonclick ;
      private string edtTituloSaldoDebito_F_Jsonclick ;
      private string edtTituloSaldoCredito_F_Jsonclick ;
      private string edtTituloTotalMovimentoDebito_F_Jsonclick ;
      private string edtTituloTotalMovimentoCredito_F_Jsonclick ;
      private string edtTituloTotalMultaJurosDebito_F_Jsonclick ;
      private string edtTituloTotalMultaJurosCredito_F_Jsonclick ;
      private string cmbTituloPropostaTipo_Jsonclick ;
      private string edtNotaFiscalParcelamentoID_Jsonclick ;
      private string edtNotaFiscalNumero_Jsonclick ;
      private string edtContaBancariaId_Jsonclick ;
      private string edtAgenciaBancoNome_Jsonclick ;
      private string edtContaBancariaCarteira_Jsonclick ;
      private string edtContaBancariaNumero_Jsonclick ;
      private string edtAgenciaNumero_Jsonclick ;
      private string edtTitulosCarteiraDeCobranca_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A500TituloCriacao ;
      private DateTime AV25TFTituloProrrogacao ;
      private DateTime AV26TFTituloProrrogacao_To ;
      private DateTime AV27DDO_TituloProrrogacaoAuxDate ;
      private DateTime AV28DDO_TituloProrrogacaoAuxDateTo ;
      private DateTime A263TituloVencimento ;
      private DateTime A264TituloProrrogacao ;
      private DateTime A516TituloDataCredito_F ;
      private DateTime AV57Selecionartitulosds_8_tftituloprorrogacao ;
      private DateTime AV58Selecionartitulosds_9_tftituloprorrogacao_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
      private bool AV47SelectAll ;
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
      private bool AV39Selected ;
      private bool n261TituloId ;
      private bool n420TituloClienteId ;
      private bool n972TituloCLienteRazaoSocial ;
      private bool n262TituloValor ;
      private bool n276TituloDesconto ;
      private bool A284TituloDeleted ;
      private bool n284TituloDeleted ;
      private bool A314TituloArchived ;
      private bool n314TituloArchived ;
      private bool n263TituloVencimento ;
      private bool n286TituloCompetenciaAno ;
      private bool n287TituloCompetenciaMes ;
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
      private bool n971TituloPropostaDescricao ;
      private bool n501PropostaTaxaAdministrativa ;
      private bool n422ContaId ;
      private bool n500TituloCriacao ;
      private bool n426CategoriaTituloId ;
      private bool n516TituloDataCredito_F ;
      private bool n301TituloTotalMultaJuros_F ;
      private bool n304TituloTotalMovimentoDebito_F ;
      private bool n305TituloTotalMovimentoCredito_F ;
      private bool n306TituloTotalMultaJurosDebito_F ;
      private bool n307TituloTotalMultaJurosCredito_F ;
      private bool n648TituloPropostaTipo ;
      private bool n890NotaFiscalParcelamentoID ;
      private bool n799NotaFiscalNumero ;
      private bool n951ContaBancariaId ;
      private bool n969AgenciaBancoNome ;
      private bool n953ContaBancariaCarteira ;
      private bool n952ContaBancariaNumero ;
      private bool n939AgenciaNumero ;
      private bool A1118TitulosEmCarteiraDeCobranca_F ;
      private bool n1119TitulosCarteiraDeCobranca ;
      private bool n794NotaFiscalId ;
      private bool n938AgenciaId ;
      private bool n968AgenciaBancoId ;
      private bool bGXsfl_37_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool nA261TituloId ;
      private string AV44TituloIdJson ;
      private string AV17ManageFiltersXml ;
      private string AV14FilterFullText ;
      private string AV19TFTituloCLienteRazaoSocial ;
      private string AV20TFTituloCLienteRazaoSocial_Sel ;
      private string AV30TFTituloPropostaDescricao ;
      private string AV31TFTituloPropostaDescricao_Sel ;
      private string AV32TFNotaFiscalNumero ;
      private string AV33TFNotaFiscalNumero_Sel ;
      private string AV38GridAppliedFilters ;
      private string AV29DDO_TituloProrrogacaoAuxDateText ;
      private string A972TituloCLienteRazaoSocial ;
      private string A295TituloCompetencia_F ;
      private string A265TituloCEP ;
      private string A266TituloLogradouro ;
      private string A294TituloNumeroEndereco ;
      private string A267TituloComplemento ;
      private string A268TituloBairro ;
      private string A269TituloMunicipio ;
      private string A283TituloTipo ;
      private string A971TituloPropostaDescricao ;
      private string A282TituloStatus_F ;
      private string A648TituloPropostaTipo ;
      private string A799NotaFiscalNumero ;
      private string A969AgenciaBancoNome ;
      private string A1119TitulosCarteiraDeCobranca ;
      private string AV50Selecionartitulosds_1_filterfulltext ;
      private string AV51Selecionartitulosds_2_tftituloclienterazaosocial ;
      private string AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel ;
      private string AV59Selecionartitulosds_10_tftitulopropostadescricao ;
      private string AV60Selecionartitulosds_11_tftitulopropostadescricao_sel ;
      private string AV61Selecionartitulosds_12_tfnotafiscalnumero ;
      private string AV62Selecionartitulosds_13_tfnotafiscalnumero_sel ;
      private string lV50Selecionartitulosds_1_filterfulltext ;
      private string lV51Selecionartitulosds_2_tftituloclienterazaosocial ;
      private string lV59Selecionartitulosds_10_tftitulopropostadescricao ;
      private string lV61Selecionartitulosds_12_tfnotafiscalnumero ;
      private Guid A890NotaFiscalParcelamentoID ;
      private Guid A794NotaFiscalId ;
      private IGxSession AV15Session ;
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
      private GXCheckbox chkavSelected ;
      private GXCheckbox chkTituloDeleted ;
      private GXCheckbox chkTituloArchived ;
      private GXCombobox cmbTituloTipo ;
      private GXCombobox cmbTituloPropostaTipo ;
      private GXCheckbox chkTitulosEmCarteiraDeCobranca_F ;
      private GXCheckbox chkavSelectall ;
      private GxSimpleCollection<int> AV43TituloIdCol ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV16ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV34DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem> AV40SelectedRows ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00A511_A794NotaFiscalId ;
      private bool[] H00A511_n794NotaFiscalId ;
      private int[] H00A511_A938AgenciaId ;
      private bool[] H00A511_n938AgenciaId ;
      private int[] H00A511_A968AgenciaBancoId ;
      private bool[] H00A511_n968AgenciaBancoId ;
      private int[] H00A511_A939AgenciaNumero ;
      private bool[] H00A511_n939AgenciaNumero ;
      private long[] H00A511_A952ContaBancariaNumero ;
      private bool[] H00A511_n952ContaBancariaNumero ;
      private long[] H00A511_A953ContaBancariaCarteira ;
      private bool[] H00A511_n953ContaBancariaCarteira ;
      private string[] H00A511_A969AgenciaBancoNome ;
      private bool[] H00A511_n969AgenciaBancoNome ;
      private int[] H00A511_A951ContaBancariaId ;
      private bool[] H00A511_n951ContaBancariaId ;
      private string[] H00A511_A799NotaFiscalNumero ;
      private bool[] H00A511_n799NotaFiscalNumero ;
      private Guid[] H00A511_A890NotaFiscalParcelamentoID ;
      private bool[] H00A511_n890NotaFiscalParcelamentoID ;
      private string[] H00A511_A648TituloPropostaTipo ;
      private bool[] H00A511_n648TituloPropostaTipo ;
      private int[] H00A511_A426CategoriaTituloId ;
      private bool[] H00A511_n426CategoriaTituloId ;
      private DateTime[] H00A511_A500TituloCriacao ;
      private bool[] H00A511_n500TituloCriacao ;
      private int[] H00A511_A422ContaId ;
      private bool[] H00A511_n422ContaId ;
      private decimal[] H00A511_A501PropostaTaxaAdministrativa ;
      private bool[] H00A511_n501PropostaTaxaAdministrativa ;
      private string[] H00A511_A971TituloPropostaDescricao ;
      private bool[] H00A511_n971TituloPropostaDescricao ;
      private int[] H00A511_A419TituloPropostaId ;
      private bool[] H00A511_n419TituloPropostaId ;
      private decimal[] H00A511_A498TituloJurosMora ;
      private bool[] H00A511_n498TituloJurosMora ;
      private string[] H00A511_A269TituloMunicipio ;
      private bool[] H00A511_n269TituloMunicipio ;
      private string[] H00A511_A268TituloBairro ;
      private bool[] H00A511_n268TituloBairro ;
      private string[] H00A511_A267TituloComplemento ;
      private bool[] H00A511_n267TituloComplemento ;
      private string[] H00A511_A294TituloNumeroEndereco ;
      private bool[] H00A511_n294TituloNumeroEndereco ;
      private string[] H00A511_A266TituloLogradouro ;
      private bool[] H00A511_n266TituloLogradouro ;
      private string[] H00A511_A265TituloCEP ;
      private bool[] H00A511_n265TituloCEP ;
      private DateTime[] H00A511_A264TituloProrrogacao ;
      private bool[] H00A511_n264TituloProrrogacao ;
      private DateTime[] H00A511_A263TituloVencimento ;
      private bool[] H00A511_n263TituloVencimento ;
      private bool[] H00A511_A314TituloArchived ;
      private bool[] H00A511_n314TituloArchived ;
      private bool[] H00A511_A284TituloDeleted ;
      private bool[] H00A511_n284TituloDeleted ;
      private string[] H00A511_A972TituloCLienteRazaoSocial ;
      private bool[] H00A511_n972TituloCLienteRazaoSocial ;
      private int[] H00A511_A420TituloClienteId ;
      private bool[] H00A511_n420TituloClienteId ;
      private int[] H00A511_A261TituloId ;
      private bool[] H00A511_n261TituloId ;
      private string[] H00A511_A1119TitulosCarteiraDeCobranca ;
      private bool[] H00A511_n1119TitulosCarteiraDeCobranca ;
      private decimal[] H00A511_A307TituloTotalMultaJurosCredito_F ;
      private bool[] H00A511_n307TituloTotalMultaJurosCredito_F ;
      private decimal[] H00A511_A306TituloTotalMultaJurosDebito_F ;
      private bool[] H00A511_n306TituloTotalMultaJurosDebito_F ;
      private decimal[] H00A511_A305TituloTotalMovimentoCredito_F ;
      private bool[] H00A511_n305TituloTotalMovimentoCredito_F ;
      private decimal[] H00A511_A304TituloTotalMovimentoDebito_F ;
      private bool[] H00A511_n304TituloTotalMovimentoDebito_F ;
      private decimal[] H00A511_A301TituloTotalMultaJuros_F ;
      private bool[] H00A511_n301TituloTotalMultaJuros_F ;
      private DateTime[] H00A511_A516TituloDataCredito_F ;
      private bool[] H00A511_n516TituloDataCredito_F ;
      private short[] H00A511_A286TituloCompetenciaAno ;
      private bool[] H00A511_n286TituloCompetenciaAno ;
      private short[] H00A511_A287TituloCompetenciaMes ;
      private bool[] H00A511_n287TituloCompetenciaMes ;
      private decimal[] H00A511_A273TituloTotalMovimento_F ;
      private decimal[] H00A511_A276TituloDesconto ;
      private bool[] H00A511_n276TituloDesconto ;
      private decimal[] H00A511_A262TituloValor ;
      private bool[] H00A511_n262TituloValor ;
      private string[] H00A511_A283TituloTipo ;
      private bool[] H00A511_n283TituloTipo ;
      private Guid[] H00A521_A794NotaFiscalId ;
      private bool[] H00A521_n794NotaFiscalId ;
      private int[] H00A521_A938AgenciaId ;
      private bool[] H00A521_n938AgenciaId ;
      private int[] H00A521_A968AgenciaBancoId ;
      private bool[] H00A521_n968AgenciaBancoId ;
      private int[] H00A521_A939AgenciaNumero ;
      private bool[] H00A521_n939AgenciaNumero ;
      private long[] H00A521_A952ContaBancariaNumero ;
      private bool[] H00A521_n952ContaBancariaNumero ;
      private long[] H00A521_A953ContaBancariaCarteira ;
      private bool[] H00A521_n953ContaBancariaCarteira ;
      private string[] H00A521_A969AgenciaBancoNome ;
      private bool[] H00A521_n969AgenciaBancoNome ;
      private int[] H00A521_A951ContaBancariaId ;
      private bool[] H00A521_n951ContaBancariaId ;
      private string[] H00A521_A799NotaFiscalNumero ;
      private bool[] H00A521_n799NotaFiscalNumero ;
      private Guid[] H00A521_A890NotaFiscalParcelamentoID ;
      private bool[] H00A521_n890NotaFiscalParcelamentoID ;
      private string[] H00A521_A648TituloPropostaTipo ;
      private bool[] H00A521_n648TituloPropostaTipo ;
      private int[] H00A521_A426CategoriaTituloId ;
      private bool[] H00A521_n426CategoriaTituloId ;
      private DateTime[] H00A521_A500TituloCriacao ;
      private bool[] H00A521_n500TituloCriacao ;
      private int[] H00A521_A422ContaId ;
      private bool[] H00A521_n422ContaId ;
      private decimal[] H00A521_A501PropostaTaxaAdministrativa ;
      private bool[] H00A521_n501PropostaTaxaAdministrativa ;
      private string[] H00A521_A971TituloPropostaDescricao ;
      private bool[] H00A521_n971TituloPropostaDescricao ;
      private int[] H00A521_A419TituloPropostaId ;
      private bool[] H00A521_n419TituloPropostaId ;
      private decimal[] H00A521_A498TituloJurosMora ;
      private bool[] H00A521_n498TituloJurosMora ;
      private string[] H00A521_A269TituloMunicipio ;
      private bool[] H00A521_n269TituloMunicipio ;
      private string[] H00A521_A268TituloBairro ;
      private bool[] H00A521_n268TituloBairro ;
      private string[] H00A521_A267TituloComplemento ;
      private bool[] H00A521_n267TituloComplemento ;
      private string[] H00A521_A294TituloNumeroEndereco ;
      private bool[] H00A521_n294TituloNumeroEndereco ;
      private string[] H00A521_A266TituloLogradouro ;
      private bool[] H00A521_n266TituloLogradouro ;
      private string[] H00A521_A265TituloCEP ;
      private bool[] H00A521_n265TituloCEP ;
      private DateTime[] H00A521_A264TituloProrrogacao ;
      private bool[] H00A521_n264TituloProrrogacao ;
      private DateTime[] H00A521_A263TituloVencimento ;
      private bool[] H00A521_n263TituloVencimento ;
      private bool[] H00A521_A314TituloArchived ;
      private bool[] H00A521_n314TituloArchived ;
      private bool[] H00A521_A284TituloDeleted ;
      private bool[] H00A521_n284TituloDeleted ;
      private string[] H00A521_A972TituloCLienteRazaoSocial ;
      private bool[] H00A521_n972TituloCLienteRazaoSocial ;
      private int[] H00A521_A420TituloClienteId ;
      private bool[] H00A521_n420TituloClienteId ;
      private int[] H00A521_A261TituloId ;
      private bool[] H00A521_n261TituloId ;
      private string[] H00A521_A1119TitulosCarteiraDeCobranca ;
      private bool[] H00A521_n1119TitulosCarteiraDeCobranca ;
      private decimal[] H00A521_A307TituloTotalMultaJurosCredito_F ;
      private bool[] H00A521_n307TituloTotalMultaJurosCredito_F ;
      private decimal[] H00A521_A306TituloTotalMultaJurosDebito_F ;
      private bool[] H00A521_n306TituloTotalMultaJurosDebito_F ;
      private decimal[] H00A521_A305TituloTotalMovimentoCredito_F ;
      private bool[] H00A521_n305TituloTotalMovimentoCredito_F ;
      private decimal[] H00A521_A304TituloTotalMovimentoDebito_F ;
      private bool[] H00A521_n304TituloTotalMovimentoDebito_F ;
      private decimal[] H00A521_A301TituloTotalMultaJuros_F ;
      private bool[] H00A521_n301TituloTotalMultaJuros_F ;
      private DateTime[] H00A521_A516TituloDataCredito_F ;
      private bool[] H00A521_n516TituloDataCredito_F ;
      private short[] H00A521_A286TituloCompetenciaAno ;
      private bool[] H00A521_n286TituloCompetenciaAno ;
      private short[] H00A521_A287TituloCompetenciaMes ;
      private bool[] H00A521_n287TituloCompetenciaMes ;
      private decimal[] H00A521_A273TituloTotalMovimento_F ;
      private decimal[] H00A521_A276TituloDesconto ;
      private bool[] H00A521_n276TituloDesconto ;
      private decimal[] H00A521_A262TituloValor ;
      private bool[] H00A521_n262TituloValor ;
      private string[] H00A521_A283TituloTipo ;
      private bool[] H00A521_n283TituloTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem AV41SelectedRow ;
      private Guid[] H00A531_A794NotaFiscalId ;
      private bool[] H00A531_n794NotaFiscalId ;
      private int[] H00A531_A938AgenciaId ;
      private bool[] H00A531_n938AgenciaId ;
      private int[] H00A531_A968AgenciaBancoId ;
      private bool[] H00A531_n968AgenciaBancoId ;
      private int[] H00A531_A261TituloId ;
      private bool[] H00A531_n261TituloId ;
      private int[] H00A531_A420TituloClienteId ;
      private bool[] H00A531_n420TituloClienteId ;
      private string[] H00A531_A972TituloCLienteRazaoSocial ;
      private bool[] H00A531_n972TituloCLienteRazaoSocial ;
      private bool[] H00A531_A284TituloDeleted ;
      private bool[] H00A531_n284TituloDeleted ;
      private bool[] H00A531_A314TituloArchived ;
      private bool[] H00A531_n314TituloArchived ;
      private DateTime[] H00A531_A263TituloVencimento ;
      private bool[] H00A531_n263TituloVencimento ;
      private DateTime[] H00A531_A264TituloProrrogacao ;
      private bool[] H00A531_n264TituloProrrogacao ;
      private string[] H00A531_A265TituloCEP ;
      private bool[] H00A531_n265TituloCEP ;
      private string[] H00A531_A266TituloLogradouro ;
      private bool[] H00A531_n266TituloLogradouro ;
      private string[] H00A531_A294TituloNumeroEndereco ;
      private bool[] H00A531_n294TituloNumeroEndereco ;
      private string[] H00A531_A267TituloComplemento ;
      private bool[] H00A531_n267TituloComplemento ;
      private string[] H00A531_A268TituloBairro ;
      private bool[] H00A531_n268TituloBairro ;
      private string[] H00A531_A269TituloMunicipio ;
      private bool[] H00A531_n269TituloMunicipio ;
      private decimal[] H00A531_A498TituloJurosMora ;
      private bool[] H00A531_n498TituloJurosMora ;
      private int[] H00A531_A419TituloPropostaId ;
      private bool[] H00A531_n419TituloPropostaId ;
      private string[] H00A531_A971TituloPropostaDescricao ;
      private bool[] H00A531_n971TituloPropostaDescricao ;
      private decimal[] H00A531_A501PropostaTaxaAdministrativa ;
      private bool[] H00A531_n501PropostaTaxaAdministrativa ;
      private int[] H00A531_A422ContaId ;
      private bool[] H00A531_n422ContaId ;
      private DateTime[] H00A531_A500TituloCriacao ;
      private bool[] H00A531_n500TituloCriacao ;
      private int[] H00A531_A426CategoriaTituloId ;
      private bool[] H00A531_n426CategoriaTituloId ;
      private string[] H00A531_A648TituloPropostaTipo ;
      private bool[] H00A531_n648TituloPropostaTipo ;
      private Guid[] H00A531_A890NotaFiscalParcelamentoID ;
      private bool[] H00A531_n890NotaFiscalParcelamentoID ;
      private string[] H00A531_A799NotaFiscalNumero ;
      private bool[] H00A531_n799NotaFiscalNumero ;
      private int[] H00A531_A951ContaBancariaId ;
      private bool[] H00A531_n951ContaBancariaId ;
      private string[] H00A531_A969AgenciaBancoNome ;
      private bool[] H00A531_n969AgenciaBancoNome ;
      private long[] H00A531_A953ContaBancariaCarteira ;
      private bool[] H00A531_n953ContaBancariaCarteira ;
      private long[] H00A531_A952ContaBancariaNumero ;
      private bool[] H00A531_n952ContaBancariaNumero ;
      private int[] H00A531_A939AgenciaNumero ;
      private bool[] H00A531_n939AgenciaNumero ;
      private DateTime[] H00A531_A516TituloDataCredito_F ;
      private bool[] H00A531_n516TituloDataCredito_F ;
      private decimal[] H00A531_A301TituloTotalMultaJuros_F ;
      private bool[] H00A531_n301TituloTotalMultaJuros_F ;
      private decimal[] H00A531_A304TituloTotalMovimentoDebito_F ;
      private bool[] H00A531_n304TituloTotalMovimentoDebito_F ;
      private decimal[] H00A531_A305TituloTotalMovimentoCredito_F ;
      private bool[] H00A531_n305TituloTotalMovimentoCredito_F ;
      private decimal[] H00A531_A306TituloTotalMultaJurosDebito_F ;
      private bool[] H00A531_n306TituloTotalMultaJurosDebito_F ;
      private decimal[] H00A531_A307TituloTotalMultaJurosCredito_F ;
      private bool[] H00A531_n307TituloTotalMultaJurosCredito_F ;
      private string[] H00A531_A1119TitulosCarteiraDeCobranca ;
      private bool[] H00A531_n1119TitulosCarteiraDeCobranca ;
      private string[] H00A531_A283TituloTipo ;
      private bool[] H00A531_n283TituloTipo ;
      private decimal[] H00A531_A273TituloTotalMovimento_F ;
      private decimal[] H00A531_A276TituloDesconto ;
      private bool[] H00A531_n276TituloDesconto ;
      private decimal[] H00A531_A262TituloValor ;
      private bool[] H00A531_n262TituloValor ;
      private short[] H00A531_A286TituloCompetenciaAno ;
      private bool[] H00A531_n286TituloCompetenciaAno ;
      private short[] H00A531_A287TituloCompetenciaMes ;
      private bool[] H00A531_n287TituloCompetenciaMes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private Guid[] H00A532_A890NotaFiscalParcelamentoID ;
      private bool[] H00A532_n890NotaFiscalParcelamentoID ;
      private Guid[] H00A532_A794NotaFiscalId ;
      private bool[] H00A532_n794NotaFiscalId ;
      private int[] H00A532_A419TituloPropostaId ;
      private bool[] H00A532_n419TituloPropostaId ;
      private int[] H00A532_A420TituloClienteId ;
      private bool[] H00A532_n420TituloClienteId ;
      private DateTime[] H00A532_A264TituloProrrogacao ;
      private bool[] H00A532_n264TituloProrrogacao ;
      private decimal[] H00A532_A276TituloDesconto ;
      private bool[] H00A532_n276TituloDesconto ;
      private decimal[] H00A532_A262TituloValor ;
      private bool[] H00A532_n262TituloValor ;
      private string[] H00A532_A799NotaFiscalNumero ;
      private bool[] H00A532_n799NotaFiscalNumero ;
      private string[] H00A532_A971TituloPropostaDescricao ;
      private bool[] H00A532_n971TituloPropostaDescricao ;
      private string[] H00A532_A972TituloCLienteRazaoSocial ;
      private bool[] H00A532_n972TituloCLienteRazaoSocial ;
      private int[] H00A532_A261TituloId ;
      private bool[] H00A532_n261TituloId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int[] H00A533_Gx_cnt ;
   }

   public class selecionartitulos__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00A511( IGxContext context ,
                                              string AV50Selecionartitulosds_1_filterfulltext ,
                                              string AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel ,
                                              string AV51Selecionartitulosds_2_tftituloclienterazaosocial ,
                                              decimal AV53Selecionartitulosds_4_tftitulovalor ,
                                              decimal AV54Selecionartitulosds_5_tftitulovalor_to ,
                                              decimal AV55Selecionartitulosds_6_tftitulodesconto ,
                                              decimal AV56Selecionartitulosds_7_tftitulodesconto_to ,
                                              DateTime AV57Selecionartitulosds_8_tftituloprorrogacao ,
                                              DateTime AV58Selecionartitulosds_9_tftituloprorrogacao_to ,
                                              string AV60Selecionartitulosds_11_tftitulopropostadescricao_sel ,
                                              string AV59Selecionartitulosds_10_tftitulopropostadescricao ,
                                              string AV62Selecionartitulosds_13_tfnotafiscalnumero_sel ,
                                              string AV61Selecionartitulosds_12_tfnotafiscalnumero ,
                                              string A972TituloCLienteRazaoSocial ,
                                              decimal A262TituloValor ,
                                              decimal A276TituloDesconto ,
                                              string A971TituloPropostaDescricao ,
                                              string A799NotaFiscalNumero ,
                                              DateTime A264TituloProrrogacao ,
                                              short AV12OrderedBy ,
                                              bool AV13OrderedDsc ,
                                              bool A1118TitulosEmCarteiraDeCobranca_F ,
                                              int A261TituloId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[17];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T5.NotaFiscalId, T2.AgenciaId, T3.AgenciaBancoId AS AgenciaBancoId, T3.AgenciaNumero, T2.ContaBancariaNumero, T2.ContaBancariaCarteira, T4.BancoNome AS AgenciaBancoNome, T1.ContaBancariaId, T6.NotaFiscalNumero, T1.NotaFiscalParcelamentoID, T1.TituloPropostaTipo, T1.CategoriaTituloId, T1.TituloCriacao, T1.ContaId, T7.PropostaTaxaAdministrativa, T7.PropostaDescricao AS TituloPropostaDescricao, T1.TituloPropostaId AS TituloPropostaId, T1.TituloJurosMora, T1.TituloMunicipio, T1.TituloBairro, T1.TituloComplemento, T1.TituloNumeroEndereco, T1.TituloLogradouro, T1.TituloCEP, T1.TituloProrrogacao, T1.TituloVencimento, T1.TituloArchived, T1.TituloDeleted, T8.ClienteRazaoSocial AS TituloCLienteRazaoSocial, T1.TituloClienteId AS TituloClienteId, T1.TituloId, COALESCE( T9.TitulosCarteiraDeCobranca, '') AS TitulosCarteiraDeCobranca, COALESCE( T10.TituloTotalMultaJurosCredito_F, 0) AS TituloTotalMultaJurosCredito_F, COALESCE( T10.TituloTotalMultaJurosDebito_F, 0) AS TituloTotalMultaJurosDebito_F, COALESCE( T10.TituloTotalMovimentoCredito_F, 0) AS TituloTotalMovimentoCredito_F, COALESCE( T10.TituloTotalMovimentoDebito_F, 0) AS TituloTotalMovimentoDebito_F, COALESCE( T12.TituloTotalMovimento_F, 0) AS TituloTotalMultaJuros_F, COALESCE( T13.TituloDataCredito_F, DATE '00010101') AS TituloDataCredito_F, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes, COALESCE( T11.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F, T1.TituloDesconto, T1.TituloValor, T1.TituloTipo FROM ((((((((((((Titulo T1 LEFT JOIN ContaBancaria T2 ON T2.ContaBancariaId = T1.ContaBancariaId) LEFT JOIN Agencia T3 ON T3.AgenciaId = T2.AgenciaId) LEFT JOIN Banco T4 ON T4.BancoId = T3.AgenciaBancoId) LEFT JOIN NotaFiscalParcelamento T5 ON T5.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal";
         scmdbuf += " T6 ON T6.NotaFiscalId = T5.NotaFiscalId) LEFT JOIN Proposta T7 ON T7.PropostaId = T1.TituloPropostaId) LEFT JOIN Cliente T8 ON T8.ClienteId = T1.TituloClienteId) LEFT JOIN LATERAL (SELECT MAX(T15.CarteiraDeCobrancaNome) AS TitulosCarteiraDeCobranca, T14.TituloId FROM (Boleto T14 LEFT JOIN CarteiraDeCobranca T15 ON T15.CarteiraDeCobrancaId = T14.CarteiraDeCobrancaId) WHERE T1.TituloId = T14.TituloId GROUP BY T14.TituloId ) T9 ON T9.TituloId = T1.TituloId) LEFT JOIN (SELECT CASE  WHEN COALESCE( T14.TituloTipo, '') = ( 'CREDITO') THEN COALESCE( T15.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloTotalMultaJurosCredito_F, T14.TituloId, CASE  WHEN COALESCE( T14.TituloTipo, '') = ( 'DEBITO') THEN COALESCE( T16.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloTotalMultaJurosDebito_F, CASE  WHEN COALESCE( T14.TituloTipo, '') = ( 'CREDITO') THEN COALESCE( T17.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloTotalMovimentoCredito_F, CASE  WHEN COALESCE( T14.TituloTipo, '') = ( 'DEBITO') THEN COALESCE( T18.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloTotalMovimentoDebito_F FROM ((((Titulo T14 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T14.TituloId = TituloId) AND (Not TituloMovimentoSoma) GROUP BY TituloId ) T15 ON T15.TituloId = T14.TituloId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T14.TituloId = TituloId) AND (Not TituloMovimentoSoma) GROUP BY TituloId ) T16 ON T16.TituloId = T14.TituloId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T14.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T17 ON T17.TituloId = T14.TituloId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor)";
         scmdbuf += " AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T14.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T18 ON T18.TituloId = T14.TituloId) ) T10 ON T10.TituloId = T1.TituloId) LEFT JOIN LATERAL (SELECT TituloId, SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE (T1.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T11 ON T11.TituloId = T1.TituloId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T1.TituloId = TituloId) AND (Not TituloMovimentoSoma) GROUP BY TituloId ) T12 ON T12.TituloId = T1.TituloId) LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE T1.TituloId = TituloId GROUP BY TituloId ) T13 ON T13.TituloId = T1.TituloId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Selecionartitulosds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T8.ClienteRazaoSocial like '%' || :lV50Selecionartitulosds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.TituloValor,'999999999999990.99'), 2) like '%' || :lV50Selecionartitulosds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.TituloDesconto,'999999999999990.99'), 2) like '%' || :lV50Selecionartitulosds_1_filterfulltext) or ( T7.PropostaDescricao like '%' || :lV50Selecionartitulosds_1_filterfulltext) or ( T6.NotaFiscalNumero like '%' || :lV50Selecionartitulosds_1_filterfulltext))");
         }
         else
         {
            GXv_int6[0] = 1;
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
            GXv_int6[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Selecionartitulosds_2_tftituloclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T8.ClienteRazaoSocial like :lV51Selecionartitulosds_2_tftituloclienterazaosocial)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T8.ClienteRazaoSocial = ( :AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel))");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( StringUtil.StrCmp(AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T8.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T8.ClienteRazaoSocial))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV53Selecionartitulosds_4_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV53Selecionartitulosds_4_tftitulovalor)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV54Selecionartitulosds_5_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV54Selecionartitulosds_5_tftitulovalor_to)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV55Selecionartitulosds_6_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV55Selecionartitulosds_6_tftitulodesconto)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV56Selecionartitulosds_7_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV56Selecionartitulosds_7_tftitulodesconto_to)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Selecionartitulosds_8_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV57Selecionartitulosds_8_tftituloprorrogacao)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV58Selecionartitulosds_9_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV58Selecionartitulosds_9_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Selecionartitulosds_11_tftitulopropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Selecionartitulosds_10_tftitulopropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T7.PropostaDescricao like :lV59Selecionartitulosds_10_tftitulopropostadescricao)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Selecionartitulosds_11_tftitulopropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV60Selecionartitulosds_11_tftitulopropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T7.PropostaDescricao = ( :AV60Selecionartitulosds_11_tftitulopropostadescricao_sel))");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( StringUtil.StrCmp(AV60Selecionartitulosds_11_tftitulopropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T7.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T7.PropostaDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Selecionartitulosds_13_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Selecionartitulosds_12_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(T6.NotaFiscalNumero like :lV61Selecionartitulosds_12_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Selecionartitulosds_13_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV62Selecionartitulosds_13_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T6.NotaFiscalNumero = ( :AV62Selecionartitulosds_13_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( StringUtil.StrCmp(AV62Selecionartitulosds_13_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T6.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T6.NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T8.ClienteRazaoSocial, T1.TituloId";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T8.ClienteRazaoSocial DESC, T1.TituloId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloValor, T1.TituloId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloValor DESC, T1.TituloId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloDesconto, T1.TituloId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloDesconto DESC, T1.TituloId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloProrrogacao, T1.TituloId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloProrrogacao DESC, T1.TituloId";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T7.PropostaDescricao, T1.TituloId";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T7.PropostaDescricao DESC, T1.TituloId";
         }
         else if ( ( AV12OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T6.NotaFiscalNumero, T1.TituloId";
         }
         else if ( ( AV12OrderedBy == 6 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T6.NotaFiscalNumero DESC, T1.TituloId";
         }
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H00A521( IGxContext context ,
                                              string AV50Selecionartitulosds_1_filterfulltext ,
                                              string AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel ,
                                              string AV51Selecionartitulosds_2_tftituloclienterazaosocial ,
                                              decimal AV53Selecionartitulosds_4_tftitulovalor ,
                                              decimal AV54Selecionartitulosds_5_tftitulovalor_to ,
                                              decimal AV55Selecionartitulosds_6_tftitulodesconto ,
                                              decimal AV56Selecionartitulosds_7_tftitulodesconto_to ,
                                              DateTime AV57Selecionartitulosds_8_tftituloprorrogacao ,
                                              DateTime AV58Selecionartitulosds_9_tftituloprorrogacao_to ,
                                              string AV60Selecionartitulosds_11_tftitulopropostadescricao_sel ,
                                              string AV59Selecionartitulosds_10_tftitulopropostadescricao ,
                                              string AV62Selecionartitulosds_13_tfnotafiscalnumero_sel ,
                                              string AV61Selecionartitulosds_12_tfnotafiscalnumero ,
                                              string A972TituloCLienteRazaoSocial ,
                                              decimal A262TituloValor ,
                                              decimal A276TituloDesconto ,
                                              string A971TituloPropostaDescricao ,
                                              string A799NotaFiscalNumero ,
                                              DateTime A264TituloProrrogacao ,
                                              short AV12OrderedBy ,
                                              bool AV13OrderedDsc ,
                                              bool A1118TitulosEmCarteiraDeCobranca_F ,
                                              int A261TituloId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[17];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T5.NotaFiscalId, T2.AgenciaId, T3.AgenciaBancoId AS AgenciaBancoId, T3.AgenciaNumero, T2.ContaBancariaNumero, T2.ContaBancariaCarteira, T4.BancoNome AS AgenciaBancoNome, T1.ContaBancariaId, T6.NotaFiscalNumero, T1.NotaFiscalParcelamentoID, T1.TituloPropostaTipo, T1.CategoriaTituloId, T1.TituloCriacao, T1.ContaId, T7.PropostaTaxaAdministrativa, T7.PropostaDescricao AS TituloPropostaDescricao, T1.TituloPropostaId AS TituloPropostaId, T1.TituloJurosMora, T1.TituloMunicipio, T1.TituloBairro, T1.TituloComplemento, T1.TituloNumeroEndereco, T1.TituloLogradouro, T1.TituloCEP, T1.TituloProrrogacao, T1.TituloVencimento, T1.TituloArchived, T1.TituloDeleted, T8.ClienteRazaoSocial AS TituloCLienteRazaoSocial, T1.TituloClienteId AS TituloClienteId, T1.TituloId, COALESCE( T9.TitulosCarteiraDeCobranca, '') AS TitulosCarteiraDeCobranca, COALESCE( T10.TituloTotalMultaJurosCredito_F, 0) AS TituloTotalMultaJurosCredito_F, COALESCE( T10.TituloTotalMultaJurosDebito_F, 0) AS TituloTotalMultaJurosDebito_F, COALESCE( T10.TituloTotalMovimentoCredito_F, 0) AS TituloTotalMovimentoCredito_F, COALESCE( T10.TituloTotalMovimentoDebito_F, 0) AS TituloTotalMovimentoDebito_F, COALESCE( T12.TituloTotalMovimento_F, 0) AS TituloTotalMultaJuros_F, COALESCE( T13.TituloDataCredito_F, DATE '00010101') AS TituloDataCredito_F, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes, COALESCE( T11.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F, T1.TituloDesconto, T1.TituloValor, T1.TituloTipo FROM ((((((((((((Titulo T1 LEFT JOIN ContaBancaria T2 ON T2.ContaBancariaId = T1.ContaBancariaId) LEFT JOIN Agencia T3 ON T3.AgenciaId = T2.AgenciaId) LEFT JOIN Banco T4 ON T4.BancoId = T3.AgenciaBancoId) LEFT JOIN NotaFiscalParcelamento T5 ON T5.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal";
         scmdbuf += " T6 ON T6.NotaFiscalId = T5.NotaFiscalId) LEFT JOIN Proposta T7 ON T7.PropostaId = T1.TituloPropostaId) LEFT JOIN Cliente T8 ON T8.ClienteId = T1.TituloClienteId) LEFT JOIN LATERAL (SELECT MAX(T15.CarteiraDeCobrancaNome) AS TitulosCarteiraDeCobranca, T14.TituloId FROM (Boleto T14 LEFT JOIN CarteiraDeCobranca T15 ON T15.CarteiraDeCobrancaId = T14.CarteiraDeCobrancaId) WHERE T1.TituloId = T14.TituloId GROUP BY T14.TituloId ) T9 ON T9.TituloId = T1.TituloId) LEFT JOIN (SELECT CASE  WHEN COALESCE( T14.TituloTipo, '') = ( 'CREDITO') THEN COALESCE( T15.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloTotalMultaJurosCredito_F, T14.TituloId, CASE  WHEN COALESCE( T14.TituloTipo, '') = ( 'DEBITO') THEN COALESCE( T16.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloTotalMultaJurosDebito_F, CASE  WHEN COALESCE( T14.TituloTipo, '') = ( 'CREDITO') THEN COALESCE( T17.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloTotalMovimentoCredito_F, CASE  WHEN COALESCE( T14.TituloTipo, '') = ( 'DEBITO') THEN COALESCE( T18.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloTotalMovimentoDebito_F FROM ((((Titulo T14 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T14.TituloId = TituloId) AND (Not TituloMovimentoSoma) GROUP BY TituloId ) T15 ON T15.TituloId = T14.TituloId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T14.TituloId = TituloId) AND (Not TituloMovimentoSoma) GROUP BY TituloId ) T16 ON T16.TituloId = T14.TituloId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T14.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T17 ON T17.TituloId = T14.TituloId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor)";
         scmdbuf += " AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T14.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T18 ON T18.TituloId = T14.TituloId) ) T10 ON T10.TituloId = T1.TituloId) LEFT JOIN LATERAL (SELECT TituloId, SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE (T1.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T11 ON T11.TituloId = T1.TituloId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T1.TituloId = TituloId) AND (Not TituloMovimentoSoma) GROUP BY TituloId ) T12 ON T12.TituloId = T1.TituloId) LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE T1.TituloId = TituloId GROUP BY TituloId ) T13 ON T13.TituloId = T1.TituloId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Selecionartitulosds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T8.ClienteRazaoSocial like '%' || :lV50Selecionartitulosds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.TituloValor,'999999999999990.99'), 2) like '%' || :lV50Selecionartitulosds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.TituloDesconto,'999999999999990.99'), 2) like '%' || :lV50Selecionartitulosds_1_filterfulltext) or ( T7.PropostaDescricao like '%' || :lV50Selecionartitulosds_1_filterfulltext) or ( T6.NotaFiscalNumero like '%' || :lV50Selecionartitulosds_1_filterfulltext))");
         }
         else
         {
            GXv_int8[0] = 1;
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
            GXv_int8[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Selecionartitulosds_2_tftituloclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T8.ClienteRazaoSocial like :lV51Selecionartitulosds_2_tftituloclienterazaosocial)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T8.ClienteRazaoSocial = ( :AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel))");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( StringUtil.StrCmp(AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T8.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T8.ClienteRazaoSocial))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV53Selecionartitulosds_4_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV53Selecionartitulosds_4_tftitulovalor)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV54Selecionartitulosds_5_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV54Selecionartitulosds_5_tftitulovalor_to)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV55Selecionartitulosds_6_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV55Selecionartitulosds_6_tftitulodesconto)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV56Selecionartitulosds_7_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV56Selecionartitulosds_7_tftitulodesconto_to)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Selecionartitulosds_8_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV57Selecionartitulosds_8_tftituloprorrogacao)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV58Selecionartitulosds_9_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV58Selecionartitulosds_9_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Selecionartitulosds_11_tftitulopropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Selecionartitulosds_10_tftitulopropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T7.PropostaDescricao like :lV59Selecionartitulosds_10_tftitulopropostadescricao)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Selecionartitulosds_11_tftitulopropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV60Selecionartitulosds_11_tftitulopropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T7.PropostaDescricao = ( :AV60Selecionartitulosds_11_tftitulopropostadescricao_sel))");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( StringUtil.StrCmp(AV60Selecionartitulosds_11_tftitulopropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T7.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T7.PropostaDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Selecionartitulosds_13_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Selecionartitulosds_12_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(T6.NotaFiscalNumero like :lV61Selecionartitulosds_12_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Selecionartitulosds_13_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV62Selecionartitulosds_13_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T6.NotaFiscalNumero = ( :AV62Selecionartitulosds_13_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( StringUtil.StrCmp(AV62Selecionartitulosds_13_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T6.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T6.NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T8.ClienteRazaoSocial, T1.TituloId";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T8.ClienteRazaoSocial DESC, T1.TituloId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloValor, T1.TituloId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloValor DESC, T1.TituloId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloDesconto, T1.TituloId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloDesconto DESC, T1.TituloId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloProrrogacao, T1.TituloId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloProrrogacao DESC, T1.TituloId";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T7.PropostaDescricao, T1.TituloId";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T7.PropostaDescricao DESC, T1.TituloId";
         }
         else if ( ( AV12OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T6.NotaFiscalNumero, T1.TituloId";
         }
         else if ( ( AV12OrderedBy == 6 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T6.NotaFiscalNumero DESC, T1.TituloId";
         }
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H00A532( IGxContext context ,
                                              string AV50Selecionartitulosds_1_filterfulltext ,
                                              string AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel ,
                                              string AV51Selecionartitulosds_2_tftituloclienterazaosocial ,
                                              decimal AV53Selecionartitulosds_4_tftitulovalor ,
                                              decimal AV54Selecionartitulosds_5_tftitulovalor_to ,
                                              decimal AV55Selecionartitulosds_6_tftitulodesconto ,
                                              decimal AV56Selecionartitulosds_7_tftitulodesconto_to ,
                                              DateTime AV57Selecionartitulosds_8_tftituloprorrogacao ,
                                              DateTime AV58Selecionartitulosds_9_tftituloprorrogacao_to ,
                                              string AV60Selecionartitulosds_11_tftitulopropostadescricao_sel ,
                                              string AV59Selecionartitulosds_10_tftitulopropostadescricao ,
                                              string AV62Selecionartitulosds_13_tfnotafiscalnumero_sel ,
                                              string AV61Selecionartitulosds_12_tfnotafiscalnumero ,
                                              string A972TituloCLienteRazaoSocial ,
                                              decimal A262TituloValor ,
                                              decimal A276TituloDesconto ,
                                              string A971TituloPropostaDescricao ,
                                              string A799NotaFiscalNumero ,
                                              DateTime A264TituloProrrogacao ,
                                              bool A1118TitulosEmCarteiraDeCobranca_F ,
                                              int A261TituloId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[17];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalParcelamentoID, T2.NotaFiscalId, T1.TituloPropostaId AS TituloPropostaId, T1.TituloClienteId AS TituloClienteId, T1.TituloProrrogacao, T1.TituloDesconto, T1.TituloValor, T3.NotaFiscalNumero, T4.PropostaDescricao AS TituloPropostaDescricao, T5.ClienteRazaoSocial AS TituloCLienteRazaoSocial, T1.TituloId FROM ((((Titulo T1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) LEFT JOIN Proposta T4 ON T4.PropostaId = T1.TituloPropostaId) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.TituloClienteId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Selecionartitulosds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T5.ClienteRazaoSocial like '%' || :lV50Selecionartitulosds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.TituloValor,'999999999999990.99'), 2) like '%' || :lV50Selecionartitulosds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.TituloDesconto,'999999999999990.99'), 2) like '%' || :lV50Selecionartitulosds_1_filterfulltext) or ( T4.PropostaDescricao like '%' || :lV50Selecionartitulosds_1_filterfulltext) or ( T3.NotaFiscalNumero like '%' || :lV50Selecionartitulosds_1_filterfulltext))");
         }
         else
         {
            GXv_int10[0] = 1;
            GXv_int10[1] = 1;
            GXv_int10[2] = 1;
            GXv_int10[3] = 1;
            GXv_int10[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Selecionartitulosds_2_tftituloclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV51Selecionartitulosds_2_tftituloclienterazaosocial)");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel))");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( StringUtil.StrCmp(AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV53Selecionartitulosds_4_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV53Selecionartitulosds_4_tftitulovalor)");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV54Selecionartitulosds_5_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV54Selecionartitulosds_5_tftitulovalor_to)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV55Selecionartitulosds_6_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV55Selecionartitulosds_6_tftitulodesconto)");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV56Selecionartitulosds_7_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV56Selecionartitulosds_7_tftitulodesconto_to)");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Selecionartitulosds_8_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV57Selecionartitulosds_8_tftituloprorrogacao)");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV58Selecionartitulosds_9_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV58Selecionartitulosds_9_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Selecionartitulosds_11_tftitulopropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Selecionartitulosds_10_tftitulopropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao like :lV59Selecionartitulosds_10_tftitulopropostadescricao)");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Selecionartitulosds_11_tftitulopropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV60Selecionartitulosds_11_tftitulopropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao = ( :AV60Selecionartitulosds_11_tftitulopropostadescricao_sel))");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( StringUtil.StrCmp(AV60Selecionartitulosds_11_tftitulopropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T4.PropostaDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Selecionartitulosds_13_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Selecionartitulosds_12_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero like :lV61Selecionartitulosds_12_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Selecionartitulosds_13_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV62Selecionartitulosds_13_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero = ( :AV62Selecionartitulosds_13_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( StringUtil.StrCmp(AV62Selecionartitulosds_13_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T3.NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.TituloId";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00A511(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (decimal)dynConstraints[3] , (decimal)dynConstraints[4] , (decimal)dynConstraints[5] , (decimal)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (DateTime)dynConstraints[18] , (short)dynConstraints[19] , (bool)dynConstraints[20] , (bool)dynConstraints[21] , (int)dynConstraints[22] );
               case 1 :
                     return conditional_H00A521(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (decimal)dynConstraints[3] , (decimal)dynConstraints[4] , (decimal)dynConstraints[5] , (decimal)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (DateTime)dynConstraints[18] , (short)dynConstraints[19] , (bool)dynConstraints[20] , (bool)dynConstraints[21] , (int)dynConstraints[22] );
               case 3 :
                     return conditional_H00A532(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (decimal)dynConstraints[3] , (decimal)dynConstraints[4] , (decimal)dynConstraints[5] , (decimal)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (DateTime)dynConstraints[18] , (bool)dynConstraints[19] , (int)dynConstraints[20] );
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
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00A531;
          prmH00A531 = new Object[] {
          new ParDef("AV45TituloIdColItem",GXType.Int32,9,0)
          };
          string cmdBufferH00A531;
          cmdBufferH00A531=" SELECT T9.NotaFiscalId, T11.AgenciaId, T12.AgenciaBancoId AS AgenciaBancoId, T1.TituloId, T1.TituloClienteId AS TituloClienteId, T7.ClienteRazaoSocial AS TituloCLienteRazaoSocial, T1.TituloDeleted, T1.TituloArchived, T1.TituloVencimento, T1.TituloProrrogacao, T1.TituloCEP, T1.TituloLogradouro, T1.TituloNumeroEndereco, T1.TituloComplemento, T1.TituloBairro, T1.TituloMunicipio, T1.TituloJurosMora, T1.TituloPropostaId AS TituloPropostaId, T8.PropostaDescricao AS TituloPropostaDescricao, T8.PropostaTaxaAdministrativa, T1.ContaId, T1.TituloCriacao, T1.CategoriaTituloId, T1.TituloPropostaTipo, T1.NotaFiscalParcelamentoID, T10.NotaFiscalNumero, T1.ContaBancariaId, T13.BancoNome AS AgenciaBancoNome, T11.ContaBancariaCarteira, T11.ContaBancariaNumero, T12.AgenciaNumero, COALESCE( T2.TituloDataCredito_F, DATE '00010101') AS TituloDataCredito_F, COALESCE( T4.TituloTotalMovimento_F, 0) AS TituloTotalMultaJuros_F, COALESCE( T5.TituloTotalMovimentoDebito_F, 0) AS TituloTotalMovimentoDebito_F, COALESCE( T5.TituloTotalMovimentoCredito_F, 0) AS TituloTotalMovimentoCredito_F, COALESCE( T5.TituloTotalMultaJurosDebito_F, 0) AS TituloTotalMultaJurosDebito_F, COALESCE( T5.TituloTotalMultaJurosCredito_F, 0) AS TituloTotalMultaJurosCredito_F, COALESCE( T6.TitulosCarteiraDeCobranca, '') AS TitulosCarteiraDeCobranca, T1.TituloTipo, COALESCE( T3.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F, T1.TituloDesconto, T1.TituloValor, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes FROM ((((((((((((Titulo T1 LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE T1.TituloId = TituloId GROUP BY TituloId ) T2 ON T2.TituloId = T1.TituloId) LEFT JOIN LATERAL (SELECT TituloId, SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento "
          + " WHERE (T1.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T3 ON T3.TituloId = T1.TituloId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T1.TituloId = TituloId) AND (Not TituloMovimentoSoma) GROUP BY TituloId ) T4 ON T4.TituloId = T1.TituloId) LEFT JOIN (SELECT CASE  WHEN COALESCE( T14.TituloTipo, '') = ( 'CREDITO') THEN COALESCE( T15.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloTotalMultaJurosCredito_F, T14.TituloId, CASE  WHEN COALESCE( T14.TituloTipo, '') = ( 'DEBITO') THEN COALESCE( T16.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloTotalMultaJurosDebito_F, CASE  WHEN COALESCE( T14.TituloTipo, '') = ( 'CREDITO') THEN COALESCE( T17.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloTotalMovimentoCredito_F, CASE  WHEN COALESCE( T14.TituloTipo, '') = ( 'DEBITO') THEN COALESCE( T18.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloTotalMovimentoDebito_F FROM ((((Titulo T14 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T14.TituloId = TituloId) AND (Not TituloMovimentoSoma) GROUP BY TituloId ) T15 ON T15.TituloId = T14.TituloId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T14.TituloId = TituloId) AND (Not TituloMovimentoSoma) GROUP BY TituloId ) T16 ON T16.TituloId = T14.TituloId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T14.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T17 ON T17.TituloId = T14.TituloId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T14.TituloId = TituloId) AND (TituloMovimentoSoma)"
          + " GROUP BY TituloId ) T18 ON T18.TituloId = T14.TituloId) ) T5 ON T5.TituloId = T1.TituloId) LEFT JOIN LATERAL (SELECT MAX(T15.CarteiraDeCobrancaNome) AS TitulosCarteiraDeCobranca, T14.TituloId FROM (Boleto T14 LEFT JOIN CarteiraDeCobranca T15 ON T15.CarteiraDeCobrancaId = T14.CarteiraDeCobrancaId) WHERE T1.TituloId = T14.TituloId GROUP BY T14.TituloId ) T6 ON T6.TituloId = T1.TituloId) LEFT JOIN Cliente T7 ON T7.ClienteId = T1.TituloClienteId) LEFT JOIN Proposta T8 ON T8.PropostaId = T1.TituloPropostaId) LEFT JOIN NotaFiscalParcelamento T9 ON T9.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T10 ON T10.NotaFiscalId = T9.NotaFiscalId) LEFT JOIN ContaBancaria T11 ON T11.ContaBancariaId = T1.ContaBancariaId) LEFT JOIN Agencia T12 ON T12.AgenciaId = T11.AgenciaId) LEFT JOIN Banco T13 ON T13.BancoId = T12.AgenciaBancoId) WHERE T1.TituloId = :AV45TituloIdColItem ORDER BY T1.TituloId" ;
          Object[] prmH00A533;
          prmH00A533 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmH00A511;
          prmH00A511 = new Object[] {
          new ParDef("lV50Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Selecionartitulosds_2_tftituloclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV53Selecionartitulosds_4_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV54Selecionartitulosds_5_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV55Selecionartitulosds_6_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV56Selecionartitulosds_7_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV57Selecionartitulosds_8_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV58Selecionartitulosds_9_tftituloprorrogacao_to",GXType.Date,8,0) ,
          new ParDef("lV59Selecionartitulosds_10_tftitulopropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV60Selecionartitulosds_11_tftitulopropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("lV61Selecionartitulosds_12_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV62Selecionartitulosds_13_tfnotafiscalnumero_sel",GXType.VarChar,40,0)
          };
          Object[] prmH00A521;
          prmH00A521 = new Object[] {
          new ParDef("lV50Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Selecionartitulosds_2_tftituloclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV53Selecionartitulosds_4_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV54Selecionartitulosds_5_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV55Selecionartitulosds_6_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV56Selecionartitulosds_7_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV57Selecionartitulosds_8_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV58Selecionartitulosds_9_tftituloprorrogacao_to",GXType.Date,8,0) ,
          new ParDef("lV59Selecionartitulosds_10_tftitulopropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV60Selecionartitulosds_11_tftitulopropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("lV61Selecionartitulosds_12_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV62Selecionartitulosds_13_tfnotafiscalnumero_sel",GXType.VarChar,40,0)
          };
          Object[] prmH00A532;
          prmH00A532 = new Object[] {
          new ParDef("lV50Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Selecionartitulosds_2_tftituloclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV52Selecionartitulosds_3_tftituloclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV53Selecionartitulosds_4_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV54Selecionartitulosds_5_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV55Selecionartitulosds_6_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV56Selecionartitulosds_7_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV57Selecionartitulosds_8_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV58Selecionartitulosds_9_tftituloprorrogacao_to",GXType.Date,8,0) ,
          new ParDef("lV59Selecionartitulosds_10_tftitulopropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV60Selecionartitulosds_11_tftitulopropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("lV61Selecionartitulosds_12_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV62Selecionartitulosds_13_tfnotafiscalnumero_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00A511", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A511,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00A521", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A521,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00A531", cmdBufferH00A531,false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A531,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H00A532", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A532,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00A533", "SELECT COUNT(*) FROM Boleto WHERE TituloId = :TituloId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A533,1, GxCacheFrequency.OFF ,true,true )
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
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((long[]) buf[8])[0] = rslt.getLong(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((long[]) buf[10])[0] = rslt.getLong(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((Guid[]) buf[18])[0] = rslt.getGuid(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[24])[0] = rslt.getGXDateTime(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((int[]) buf[26])[0] = rslt.getInt(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((decimal[]) buf[28])[0] = rslt.getDecimal(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((int[]) buf[32])[0] = rslt.getInt(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((decimal[]) buf[34])[0] = rslt.getDecimal(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((string[]) buf[36])[0] = rslt.getVarchar(19);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((string[]) buf[38])[0] = rslt.getVarchar(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((string[]) buf[40])[0] = rslt.getVarchar(21);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((string[]) buf[42])[0] = rslt.getVarchar(22);
                ((bool[]) buf[43])[0] = rslt.wasNull(22);
                ((string[]) buf[44])[0] = rslt.getVarchar(23);
                ((bool[]) buf[45])[0] = rslt.wasNull(23);
                ((string[]) buf[46])[0] = rslt.getVarchar(24);
                ((bool[]) buf[47])[0] = rslt.wasNull(24);
                ((DateTime[]) buf[48])[0] = rslt.getGXDate(25);
                ((bool[]) buf[49])[0] = rslt.wasNull(25);
                ((DateTime[]) buf[50])[0] = rslt.getGXDate(26);
                ((bool[]) buf[51])[0] = rslt.wasNull(26);
                ((bool[]) buf[52])[0] = rslt.getBool(27);
                ((bool[]) buf[53])[0] = rslt.wasNull(27);
                ((bool[]) buf[54])[0] = rslt.getBool(28);
                ((bool[]) buf[55])[0] = rslt.wasNull(28);
                ((string[]) buf[56])[0] = rslt.getVarchar(29);
                ((bool[]) buf[57])[0] = rslt.wasNull(29);
                ((int[]) buf[58])[0] = rslt.getInt(30);
                ((bool[]) buf[59])[0] = rslt.wasNull(30);
                ((int[]) buf[60])[0] = rslt.getInt(31);
                ((string[]) buf[61])[0] = rslt.getVarchar(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((decimal[]) buf[63])[0] = rslt.getDecimal(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((decimal[]) buf[65])[0] = rslt.getDecimal(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((decimal[]) buf[67])[0] = rslt.getDecimal(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((decimal[]) buf[69])[0] = rslt.getDecimal(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((decimal[]) buf[71])[0] = rslt.getDecimal(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((DateTime[]) buf[73])[0] = rslt.getGXDate(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                ((short[]) buf[75])[0] = rslt.getShort(39);
                ((bool[]) buf[76])[0] = rslt.wasNull(39);
                ((short[]) buf[77])[0] = rslt.getShort(40);
                ((bool[]) buf[78])[0] = rslt.wasNull(40);
                ((decimal[]) buf[79])[0] = rslt.getDecimal(41);
                ((decimal[]) buf[80])[0] = rslt.getDecimal(42);
                ((bool[]) buf[81])[0] = rslt.wasNull(42);
                ((decimal[]) buf[82])[0] = rslt.getDecimal(43);
                ((bool[]) buf[83])[0] = rslt.wasNull(43);
                ((string[]) buf[84])[0] = rslt.getVarchar(44);
                ((bool[]) buf[85])[0] = rslt.wasNull(44);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((long[]) buf[8])[0] = rslt.getLong(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((long[]) buf[10])[0] = rslt.getLong(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((Guid[]) buf[18])[0] = rslt.getGuid(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[24])[0] = rslt.getGXDateTime(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((int[]) buf[26])[0] = rslt.getInt(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((decimal[]) buf[28])[0] = rslt.getDecimal(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((int[]) buf[32])[0] = rslt.getInt(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((decimal[]) buf[34])[0] = rslt.getDecimal(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((string[]) buf[36])[0] = rslt.getVarchar(19);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((string[]) buf[38])[0] = rslt.getVarchar(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((string[]) buf[40])[0] = rslt.getVarchar(21);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((string[]) buf[42])[0] = rslt.getVarchar(22);
                ((bool[]) buf[43])[0] = rslt.wasNull(22);
                ((string[]) buf[44])[0] = rslt.getVarchar(23);
                ((bool[]) buf[45])[0] = rslt.wasNull(23);
                ((string[]) buf[46])[0] = rslt.getVarchar(24);
                ((bool[]) buf[47])[0] = rslt.wasNull(24);
                ((DateTime[]) buf[48])[0] = rslt.getGXDate(25);
                ((bool[]) buf[49])[0] = rslt.wasNull(25);
                ((DateTime[]) buf[50])[0] = rslt.getGXDate(26);
                ((bool[]) buf[51])[0] = rslt.wasNull(26);
                ((bool[]) buf[52])[0] = rslt.getBool(27);
                ((bool[]) buf[53])[0] = rslt.wasNull(27);
                ((bool[]) buf[54])[0] = rslt.getBool(28);
                ((bool[]) buf[55])[0] = rslt.wasNull(28);
                ((string[]) buf[56])[0] = rslt.getVarchar(29);
                ((bool[]) buf[57])[0] = rslt.wasNull(29);
                ((int[]) buf[58])[0] = rslt.getInt(30);
                ((bool[]) buf[59])[0] = rslt.wasNull(30);
                ((int[]) buf[60])[0] = rslt.getInt(31);
                ((string[]) buf[61])[0] = rslt.getVarchar(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((decimal[]) buf[63])[0] = rslt.getDecimal(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((decimal[]) buf[65])[0] = rslt.getDecimal(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((decimal[]) buf[67])[0] = rslt.getDecimal(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((decimal[]) buf[69])[0] = rslt.getDecimal(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((decimal[]) buf[71])[0] = rslt.getDecimal(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((DateTime[]) buf[73])[0] = rslt.getGXDate(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                ((short[]) buf[75])[0] = rslt.getShort(39);
                ((bool[]) buf[76])[0] = rslt.wasNull(39);
                ((short[]) buf[77])[0] = rslt.getShort(40);
                ((bool[]) buf[78])[0] = rslt.wasNull(40);
                ((decimal[]) buf[79])[0] = rslt.getDecimal(41);
                ((decimal[]) buf[80])[0] = rslt.getDecimal(42);
                ((bool[]) buf[81])[0] = rslt.wasNull(42);
                ((decimal[]) buf[82])[0] = rslt.getDecimal(43);
                ((bool[]) buf[83])[0] = rslt.wasNull(43);
                ((string[]) buf[84])[0] = rslt.getVarchar(44);
                ((bool[]) buf[85])[0] = rslt.wasNull(44);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
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
                ((int[]) buf[33])[0] = rslt.getInt(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((decimal[]) buf[37])[0] = rslt.getDecimal(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((int[]) buf[39])[0] = rslt.getInt(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((DateTime[]) buf[41])[0] = rslt.getGXDateTime(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((int[]) buf[43])[0] = rslt.getInt(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((Guid[]) buf[47])[0] = rslt.getGuid(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((int[]) buf[51])[0] = rslt.getInt(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((string[]) buf[53])[0] = rslt.getVarchar(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((long[]) buf[55])[0] = rslt.getLong(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((long[]) buf[57])[0] = rslt.getLong(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((int[]) buf[59])[0] = rslt.getInt(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((DateTime[]) buf[61])[0] = rslt.getGXDate(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((decimal[]) buf[63])[0] = rslt.getDecimal(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((decimal[]) buf[65])[0] = rslt.getDecimal(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((decimal[]) buf[67])[0] = rslt.getDecimal(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((decimal[]) buf[69])[0] = rslt.getDecimal(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((decimal[]) buf[71])[0] = rslt.getDecimal(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((string[]) buf[73])[0] = rslt.getVarchar(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                ((string[]) buf[75])[0] = rslt.getVarchar(39);
                ((bool[]) buf[76])[0] = rslt.wasNull(39);
                ((decimal[]) buf[77])[0] = rslt.getDecimal(40);
                ((decimal[]) buf[78])[0] = rslt.getDecimal(41);
                ((bool[]) buf[79])[0] = rslt.wasNull(41);
                ((decimal[]) buf[80])[0] = rslt.getDecimal(42);
                ((bool[]) buf[81])[0] = rslt.wasNull(42);
                ((short[]) buf[82])[0] = rslt.getShort(43);
                ((bool[]) buf[83])[0] = rslt.wasNull(43);
                ((short[]) buf[84])[0] = rslt.getShort(44);
                ((bool[]) buf[85])[0] = rslt.wasNull(44);
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
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((int[]) buf[20])[0] = rslt.getInt(11);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
