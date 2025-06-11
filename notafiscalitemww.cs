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
   public class notafiscalitemww : GXWebComponent
   {
      public notafiscalitemww( )
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

      public notafiscalitemww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_NotaFiscalId ,
                           string aP1_NotaFiscalStatus )
      {
         this.AV55NotaFiscalId = aP0_NotaFiscalId;
         this.AV56NotaFiscalStatus = aP1_NotaFiscalStatus;
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
         cmbNotaFiscalItemVendido = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "NotaFiscalId");
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
                  AV55NotaFiscalId = StringUtil.StrToGuid( GetPar( "NotaFiscalId"));
                  AssignAttri(sPrefix, false, "AV55NotaFiscalId", AV55NotaFiscalId.ToString());
                  AV56NotaFiscalStatus = GetPar( "NotaFiscalStatus");
                  AssignAttri(sPrefix, false, "AV56NotaFiscalStatus", AV56NotaFiscalStatus);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)AV55NotaFiscalId,(string)AV56NotaFiscalStatus});
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
                  gxfirstwebparm = GetFirstPar( "NotaFiscalId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "NotaFiscalId");
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
         AV18NotaFiscalItemCodigo1 = GetPar( "NotaFiscalItemCodigo1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV20DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV22NotaFiscalItemCodigo2 = GetPar( "NotaFiscalItemCodigo2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV26NotaFiscalItemCodigo3 = GetPar( "NotaFiscalItemCodigo3");
         AV34ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV57Pgmname = GetPar( "Pgmname");
         AV55NotaFiscalId = StringUtil.StrToGuid( GetPar( "NotaFiscalId"));
         AV19DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV23DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV35TFPropostaDescricao = GetPar( "TFPropostaDescricao");
         AV36TFPropostaDescricao_Sel = GetPar( "TFPropostaDescricao_Sel");
         AV37TFNotaFiscalItemCodigo = GetPar( "TFNotaFiscalItemCodigo");
         AV38TFNotaFiscalItemCodigo_Sel = GetPar( "TFNotaFiscalItemCodigo_Sel");
         AV39TFNotaFiscalItemDescricao = GetPar( "TFNotaFiscalItemDescricao");
         AV40TFNotaFiscalItemDescricao_Sel = GetPar( "TFNotaFiscalItemDescricao_Sel");
         AV41TFNotaFiscalItemQuantidade = NumberUtil.Val( GetPar( "TFNotaFiscalItemQuantidade"), ".");
         AV42TFNotaFiscalItemQuantidade_To = NumberUtil.Val( GetPar( "TFNotaFiscalItemQuantidade_To"), ".");
         AV43TFNotaFiscalItemValorUnitario = NumberUtil.Val( GetPar( "TFNotaFiscalItemValorUnitario"), ".");
         AV44TFNotaFiscalItemValorUnitario_To = NumberUtil.Val( GetPar( "TFNotaFiscalItemValorUnitario_To"), ".");
         AV45TFNotaFiscalItemValorTotal = NumberUtil.Val( GetPar( "TFNotaFiscalItemValorTotal"), ".");
         AV46TFNotaFiscalItemValorTotal_To = NumberUtil.Val( GetPar( "TFNotaFiscalItemValorTotal_To"), ".");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV48TFNotaFiscalItemVendido_Sels);
         AV56NotaFiscalStatus = GetPar( "NotaFiscalStatus");
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18NotaFiscalItemCodigo1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22NotaFiscalItemCodigo2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26NotaFiscalItemCodigo3, AV34ManageFiltersExecutionStep, AV57Pgmname, AV55NotaFiscalId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFPropostaDescricao, AV36TFPropostaDescricao_Sel, AV37TFNotaFiscalItemCodigo, AV38TFNotaFiscalItemCodigo_Sel, AV39TFNotaFiscalItemDescricao, AV40TFNotaFiscalItemDescricao_Sel, AV41TFNotaFiscalItemQuantidade, AV42TFNotaFiscalItemQuantidade_To, AV43TFNotaFiscalItemValorUnitario, AV44TFNotaFiscalItemValorUnitario_To, AV45TFNotaFiscalItemValorTotal, AV46TFNotaFiscalItemValorTotal_To, AV48TFNotaFiscalItemVendido_Sels, AV56NotaFiscalStatus, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
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
            PA932( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV57Pgmname = "NotaFiscalItemWW";
               WS932( ) ;
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
            context.SendWebValue( " Nota Fiscal Item") ;
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
            GXEncryptionTmp = "notafiscalitemww"+UrlEncode(AV55NotaFiscalId.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV56NotaFiscalStatus));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("notafiscalitemww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV57Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV57Pgmname, "")), context));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vNOTAFISCALITEMCODIGO1", AV18NotaFiscalItemCodigo1);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2", AV20DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vNOTAFISCALITEMCODIGO2", AV22NotaFiscalItemCodigo2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3", AV24DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vNOTAFISCALITEMCODIGO3", AV26NotaFiscalItemCodigo3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_107", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_107), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV32ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV32ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV53GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV49DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV49DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV55NotaFiscalId", wcpOAV55NotaFiscalId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV56NotaFiscalStatus", wcpOAV56NotaFiscalStatus);
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV57Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV57Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vNOTAFISCALID", AV55NotaFiscalId.ToString());
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED2", AV19DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED3", AV23DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROPOSTADESCRICAO", AV35TFPropostaDescricao);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROPOSTADESCRICAO_SEL", AV36TFPropostaDescricao_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALITEMCODIGO", AV37TFNotaFiscalItemCodigo);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALITEMCODIGO_SEL", AV38TFNotaFiscalItemCodigo_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALITEMDESCRICAO", AV39TFNotaFiscalItemDescricao);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALITEMDESCRICAO_SEL", AV40TFNotaFiscalItemDescricao_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALITEMQUANTIDADE", StringUtil.LTrim( StringUtil.NToC( AV41TFNotaFiscalItemQuantidade, 18, 6, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALITEMQUANTIDADE_TO", StringUtil.LTrim( StringUtil.NToC( AV42TFNotaFiscalItemQuantidade_To, 18, 6, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALITEMVALORUNITARIO", StringUtil.LTrim( StringUtil.NToC( AV43TFNotaFiscalItemValorUnitario, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALITEMVALORUNITARIO_TO", StringUtil.LTrim( StringUtil.NToC( AV44TFNotaFiscalItemValorUnitario_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALITEMVALORTOTAL", StringUtil.LTrim( StringUtil.NToC( AV45TFNotaFiscalItemValorTotal, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALITEMVALORTOTAL_TO", StringUtil.LTrim( StringUtil.NToC( AV46TFNotaFiscalItemValorTotal_To, 18, 2, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTFNOTAFISCALITEMVENDIDO_SELS", AV48TFNotaFiscalItemVendido_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTFNOTAFISCALITEMVENDIDO_SELS", AV48TFNotaFiscalItemVendido_Sels);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vNOTAFISCALSTATUS", AV56NotaFiscalStatus);
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALITEMVENDIDO_SELSJSON", AV47TFNotaFiscalItemVendido_SelsJson);
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

      protected void RenderHtmlCloseForm932( )
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
         return "NotaFiscalItemWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Nota Fiscal Item" ;
      }

      protected void WB930( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "notafiscalitemww");
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
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(107), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotaFiscalItemWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnvenderitens_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(107), 3, 0)+","+"null"+");", "Vender itens", bttBtnvenderitens_Jsonclick, 5, "Vender itens", "", StyleString, ClassString, bttBtnvenderitens_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOVENDERITENS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotaFiscalItemWW.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_NotaFiscalItemWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_NotaFiscalItemWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_NotaFiscalItemWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_NotaFiscalItemWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_45_932( true) ;
         }
         else
         {
            wb_table1_45_932( false) ;
         }
         return  ;
      }

      protected void wb_table1_45_932e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_NotaFiscalItemWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV20DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "", true, 0, "HLP_NotaFiscalItemWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_NotaFiscalItemWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_67_932( true) ;
         }
         else
         {
            wb_table2_67_932( false) ;
         }
         return  ;
      }

      protected void wb_table2_67_932e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_NotaFiscalItemWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV24DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "", true, 0, "HLP_NotaFiscalItemWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_NotaFiscalItemWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_89_932( true) ;
         }
         else
         {
            wb_table3_89_932( false) ;
         }
         return  ;
      }

      protected void wb_table3_89_932e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV51GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV52GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV53GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_NotaFiscalItemWW.htm");
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

      protected void START932( )
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
            Form.Meta.addItem("description", " Nota Fiscal Item", 0) ;
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
               STRUP930( ) ;
            }
         }
      }

      protected void WS932( )
      {
         START932( ) ;
         EVT932( ) ;
      }

      protected void EVT932( )
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
                                 STRUP930( ) ;
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
                                 STRUP930( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E11932 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP930( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E12932 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP930( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E13932 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP930( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E14932 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP930( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters1' */
                                    E15932 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP930( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters2' */
                                    E16932 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP930( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters3' */
                                    E17932 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOVENDERITENS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP930( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoVenderItens' */
                                    E18932 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP930( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoExport' */
                                    E19932 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP930( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'AddDynamicFilters1' */
                                    E20932 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP930( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E21932 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP930( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'AddDynamicFilters2' */
                                    E22932 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP930( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E23932 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP930( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E24932 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP930( ) ;
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
                                 STRUP930( ) ;
                              }
                              nGXsfl_107_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
                              SubsflControlProps_1072( ) ;
                              A830NotaFiscalItemId = StringUtil.StrToGuid( cgiGet( edtNotaFiscalItemId_Internalname));
                              A323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n323PropostaId = false;
                              A794NotaFiscalId = StringUtil.StrToGuid( cgiGet( edtNotaFiscalId_Internalname));
                              n794NotaFiscalId = false;
                              A325PropostaDescricao = cgiGet( edtPropostaDescricao_Internalname);
                              n325PropostaDescricao = false;
                              A831NotaFiscalItemCodigo = cgiGet( edtNotaFiscalItemCodigo_Internalname);
                              n831NotaFiscalItemCodigo = false;
                              A832NotaFiscalItemCFOP = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtNotaFiscalItemCFOP_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n832NotaFiscalItemCFOP = false;
                              A833NotaFiscalItemDescricao = cgiGet( edtNotaFiscalItemDescricao_Internalname);
                              n833NotaFiscalItemDescricao = false;
                              A837NotaFiscalItemQuantidade = context.localUtil.CToN( cgiGet( edtNotaFiscalItemQuantidade_Internalname), ",", ".");
                              n837NotaFiscalItemQuantidade = false;
                              A838NotaFiscalItemValorUnitario = context.localUtil.CToN( cgiGet( edtNotaFiscalItemValorUnitario_Internalname), ",", ".");
                              n838NotaFiscalItemValorUnitario = false;
                              A839NotaFiscalItemValorTotal = context.localUtil.CToN( cgiGet( edtNotaFiscalItemValorTotal_Internalname), ",", ".");
                              n839NotaFiscalItemValorTotal = false;
                              cmbNotaFiscalItemVendido.Name = cmbNotaFiscalItemVendido_Internalname;
                              cmbNotaFiscalItemVendido.CurrentValue = cgiGet( cmbNotaFiscalItemVendido_Internalname);
                              A851NotaFiscalItemVendido = cgiGet( cmbNotaFiscalItemVendido_Internalname);
                              n851NotaFiscalItemVendido = false;
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
                                          E25932 ();
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
                                          E26932 ();
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
                                          E27932 ();
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
                                             /* Set Refresh If Notafiscalitemcodigo1 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vNOTAFISCALITEMCODIGO1"), AV18NotaFiscalItemCodigo1) != 0 )
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
                                             /* Set Refresh If Notafiscalitemcodigo2 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vNOTAFISCALITEMCODIGO2"), AV22NotaFiscalItemCodigo2) != 0 )
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
                                             /* Set Refresh If Notafiscalitemcodigo3 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vNOTAFISCALITEMCODIGO3"), AV26NotaFiscalItemCodigo3) != 0 )
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
                                       STRUP930( ) ;
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

      protected void WE932( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm932( ) ;
            }
         }
      }

      protected void PA932( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "notafiscalitemww")), "notafiscalitemww") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "notafiscalitemww")))) ;
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
                     gxfirstwebparm = GetFirstPar( "NotaFiscalId");
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
                                       string AV18NotaFiscalItemCodigo1 ,
                                       string AV20DynamicFiltersSelector2 ,
                                       short AV21DynamicFiltersOperator2 ,
                                       string AV22NotaFiscalItemCodigo2 ,
                                       string AV24DynamicFiltersSelector3 ,
                                       short AV25DynamicFiltersOperator3 ,
                                       string AV26NotaFiscalItemCodigo3 ,
                                       short AV34ManageFiltersExecutionStep ,
                                       string AV57Pgmname ,
                                       Guid AV55NotaFiscalId ,
                                       bool AV19DynamicFiltersEnabled2 ,
                                       bool AV23DynamicFiltersEnabled3 ,
                                       string AV35TFPropostaDescricao ,
                                       string AV36TFPropostaDescricao_Sel ,
                                       string AV37TFNotaFiscalItemCodigo ,
                                       string AV38TFNotaFiscalItemCodigo_Sel ,
                                       string AV39TFNotaFiscalItemDescricao ,
                                       string AV40TFNotaFiscalItemDescricao_Sel ,
                                       decimal AV41TFNotaFiscalItemQuantidade ,
                                       decimal AV42TFNotaFiscalItemQuantidade_To ,
                                       decimal AV43TFNotaFiscalItemValorUnitario ,
                                       decimal AV44TFNotaFiscalItemValorUnitario_To ,
                                       decimal AV45TFNotaFiscalItemValorTotal ,
                                       decimal AV46TFNotaFiscalItemValorTotal_To ,
                                       GxSimpleCollection<string> AV48TFNotaFiscalItemVendido_Sels ,
                                       string AV56NotaFiscalStatus ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV28DynamicFiltersIgnoreFirst ,
                                       bool AV27DynamicFiltersRemoving ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF932( ) ;
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
         RF932( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV57Pgmname = "NotaFiscalItemWW";
      }

      protected void RF932( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 107;
         /* Execute user event: Refresh */
         E26932 ();
         nGXsfl_107_idx = 1;
         sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
         SubsflControlProps_1072( ) ;
         bGXsfl_107_Refreshing = true;
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
            SubsflControlProps_1072( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A851NotaFiscalItemVendido ,
                                                 AV83Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels ,
                                                 AV59Notafiscalitemwwds_2_filterfulltext ,
                                                 AV60Notafiscalitemwwds_3_dynamicfiltersselector1 ,
                                                 AV61Notafiscalitemwwds_4_dynamicfiltersoperator1 ,
                                                 AV62Notafiscalitemwwds_5_notafiscalitemcodigo1 ,
                                                 AV63Notafiscalitemwwds_6_dynamicfiltersenabled2 ,
                                                 AV64Notafiscalitemwwds_7_dynamicfiltersselector2 ,
                                                 AV65Notafiscalitemwwds_8_dynamicfiltersoperator2 ,
                                                 AV66Notafiscalitemwwds_9_notafiscalitemcodigo2 ,
                                                 AV67Notafiscalitemwwds_10_dynamicfiltersenabled3 ,
                                                 AV68Notafiscalitemwwds_11_dynamicfiltersselector3 ,
                                                 AV69Notafiscalitemwwds_12_dynamicfiltersoperator3 ,
                                                 AV70Notafiscalitemwwds_13_notafiscalitemcodigo3 ,
                                                 AV72Notafiscalitemwwds_15_tfpropostadescricao_sel ,
                                                 AV71Notafiscalitemwwds_14_tfpropostadescricao ,
                                                 AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel ,
                                                 AV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo ,
                                                 AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel ,
                                                 AV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao ,
                                                 AV77Notafiscalitemwwds_20_tfnotafiscalitemquantidade ,
                                                 AV78Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to ,
                                                 AV79Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario ,
                                                 AV80Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to ,
                                                 AV81Notafiscalitemwwds_24_tfnotafiscalitemvalortotal ,
                                                 AV82Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to ,
                                                 AV83Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels.Count ,
                                                 A325PropostaDescricao ,
                                                 A831NotaFiscalItemCodigo ,
                                                 A833NotaFiscalItemDescricao ,
                                                 A837NotaFiscalItemQuantidade ,
                                                 A838NotaFiscalItemValorUnitario ,
                                                 A839NotaFiscalItemValorTotal ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 A794NotaFiscalId ,
                                                 AV58Notafiscalitemwwds_1_notafiscalid } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                                 TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                 }
            });
            lV59Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Notafiscalitemwwds_2_filterfulltext), "%", "");
            lV59Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Notafiscalitemwwds_2_filterfulltext), "%", "");
            lV59Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Notafiscalitemwwds_2_filterfulltext), "%", "");
            lV59Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Notafiscalitemwwds_2_filterfulltext), "%", "");
            lV59Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Notafiscalitemwwds_2_filterfulltext), "%", "");
            lV59Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Notafiscalitemwwds_2_filterfulltext), "%", "");
            lV59Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Notafiscalitemwwds_2_filterfulltext), "%", "");
            lV59Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Notafiscalitemwwds_2_filterfulltext), "%", "");
            lV59Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Notafiscalitemwwds_2_filterfulltext), "%", "");
            lV62Notafiscalitemwwds_5_notafiscalitemcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV62Notafiscalitemwwds_5_notafiscalitemcodigo1), "%", "");
            lV62Notafiscalitemwwds_5_notafiscalitemcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV62Notafiscalitemwwds_5_notafiscalitemcodigo1), "%", "");
            lV66Notafiscalitemwwds_9_notafiscalitemcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV66Notafiscalitemwwds_9_notafiscalitemcodigo2), "%", "");
            lV66Notafiscalitemwwds_9_notafiscalitemcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV66Notafiscalitemwwds_9_notafiscalitemcodigo2), "%", "");
            lV70Notafiscalitemwwds_13_notafiscalitemcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV70Notafiscalitemwwds_13_notafiscalitemcodigo3), "%", "");
            lV70Notafiscalitemwwds_13_notafiscalitemcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV70Notafiscalitemwwds_13_notafiscalitemcodigo3), "%", "");
            lV71Notafiscalitemwwds_14_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV71Notafiscalitemwwds_14_tfpropostadescricao), "%", "");
            lV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo = StringUtil.Concat( StringUtil.RTrim( AV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo), "%", "");
            lV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao = StringUtil.Concat( StringUtil.RTrim( AV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao), "%", "");
            /* Using cursor H00932 */
            pr_default.execute(0, new Object[] {AV58Notafiscalitemwwds_1_notafiscalid, lV59Notafiscalitemwwds_2_filterfulltext, lV59Notafiscalitemwwds_2_filterfulltext, lV59Notafiscalitemwwds_2_filterfulltext, lV59Notafiscalitemwwds_2_filterfulltext, lV59Notafiscalitemwwds_2_filterfulltext, lV59Notafiscalitemwwds_2_filterfulltext, lV59Notafiscalitemwwds_2_filterfulltext, lV59Notafiscalitemwwds_2_filterfulltext, lV59Notafiscalitemwwds_2_filterfulltext, lV62Notafiscalitemwwds_5_notafiscalitemcodigo1, lV62Notafiscalitemwwds_5_notafiscalitemcodigo1, lV66Notafiscalitemwwds_9_notafiscalitemcodigo2, lV66Notafiscalitemwwds_9_notafiscalitemcodigo2, lV70Notafiscalitemwwds_13_notafiscalitemcodigo3, lV70Notafiscalitemwwds_13_notafiscalitemcodigo3, lV71Notafiscalitemwwds_14_tfpropostadescricao, AV72Notafiscalitemwwds_15_tfpropostadescricao_sel, lV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo, AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel, lV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao, AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel, AV77Notafiscalitemwwds_20_tfnotafiscalitemquantidade, AV78Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to, AV79Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario, AV80Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to, AV81Notafiscalitemwwds_24_tfnotafiscalitemvalortotal, AV82Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_107_idx = 1;
            sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
            SubsflControlProps_1072( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A851NotaFiscalItemVendido = H00932_A851NotaFiscalItemVendido[0];
               n851NotaFiscalItemVendido = H00932_n851NotaFiscalItemVendido[0];
               A839NotaFiscalItemValorTotal = H00932_A839NotaFiscalItemValorTotal[0];
               n839NotaFiscalItemValorTotal = H00932_n839NotaFiscalItemValorTotal[0];
               A838NotaFiscalItemValorUnitario = H00932_A838NotaFiscalItemValorUnitario[0];
               n838NotaFiscalItemValorUnitario = H00932_n838NotaFiscalItemValorUnitario[0];
               A837NotaFiscalItemQuantidade = H00932_A837NotaFiscalItemQuantidade[0];
               n837NotaFiscalItemQuantidade = H00932_n837NotaFiscalItemQuantidade[0];
               A833NotaFiscalItemDescricao = H00932_A833NotaFiscalItemDescricao[0];
               n833NotaFiscalItemDescricao = H00932_n833NotaFiscalItemDescricao[0];
               A832NotaFiscalItemCFOP = H00932_A832NotaFiscalItemCFOP[0];
               n832NotaFiscalItemCFOP = H00932_n832NotaFiscalItemCFOP[0];
               A831NotaFiscalItemCodigo = H00932_A831NotaFiscalItemCodigo[0];
               n831NotaFiscalItemCodigo = H00932_n831NotaFiscalItemCodigo[0];
               A325PropostaDescricao = H00932_A325PropostaDescricao[0];
               n325PropostaDescricao = H00932_n325PropostaDescricao[0];
               A794NotaFiscalId = H00932_A794NotaFiscalId[0];
               n794NotaFiscalId = H00932_n794NotaFiscalId[0];
               A323PropostaId = H00932_A323PropostaId[0];
               n323PropostaId = H00932_n323PropostaId[0];
               A830NotaFiscalItemId = H00932_A830NotaFiscalItemId[0];
               A325PropostaDescricao = H00932_A325PropostaDescricao[0];
               n325PropostaDescricao = H00932_n325PropostaDescricao[0];
               /* Execute user event: Grid.Load */
               E27932 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 107;
            WB930( ) ;
         }
         bGXsfl_107_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes932( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV57Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV57Pgmname, "")), context));
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
         AV58Notafiscalitemwwds_1_notafiscalid = AV55NotaFiscalId;
         AV59Notafiscalitemwwds_2_filterfulltext = AV15FilterFullText;
         AV60Notafiscalitemwwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV61Notafiscalitemwwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV62Notafiscalitemwwds_5_notafiscalitemcodigo1 = AV18NotaFiscalItemCodigo1;
         AV63Notafiscalitemwwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV64Notafiscalitemwwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV65Notafiscalitemwwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV66Notafiscalitemwwds_9_notafiscalitemcodigo2 = AV22NotaFiscalItemCodigo2;
         AV67Notafiscalitemwwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV68Notafiscalitemwwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV69Notafiscalitemwwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV70Notafiscalitemwwds_13_notafiscalitemcodigo3 = AV26NotaFiscalItemCodigo3;
         AV71Notafiscalitemwwds_14_tfpropostadescricao = AV35TFPropostaDescricao;
         AV72Notafiscalitemwwds_15_tfpropostadescricao_sel = AV36TFPropostaDescricao_Sel;
         AV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo = AV37TFNotaFiscalItemCodigo;
         AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel = AV38TFNotaFiscalItemCodigo_Sel;
         AV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao = AV39TFNotaFiscalItemDescricao;
         AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel = AV40TFNotaFiscalItemDescricao_Sel;
         AV77Notafiscalitemwwds_20_tfnotafiscalitemquantidade = AV41TFNotaFiscalItemQuantidade;
         AV78Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to = AV42TFNotaFiscalItemQuantidade_To;
         AV79Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario = AV43TFNotaFiscalItemValorUnitario;
         AV80Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to = AV44TFNotaFiscalItemValorUnitario_To;
         AV81Notafiscalitemwwds_24_tfnotafiscalitemvalortotal = AV45TFNotaFiscalItemValorTotal;
         AV82Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to = AV46TFNotaFiscalItemValorTotal_To;
         AV83Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels = AV48TFNotaFiscalItemVendido_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A851NotaFiscalItemVendido ,
                                              AV83Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels ,
                                              AV59Notafiscalitemwwds_2_filterfulltext ,
                                              AV60Notafiscalitemwwds_3_dynamicfiltersselector1 ,
                                              AV61Notafiscalitemwwds_4_dynamicfiltersoperator1 ,
                                              AV62Notafiscalitemwwds_5_notafiscalitemcodigo1 ,
                                              AV63Notafiscalitemwwds_6_dynamicfiltersenabled2 ,
                                              AV64Notafiscalitemwwds_7_dynamicfiltersselector2 ,
                                              AV65Notafiscalitemwwds_8_dynamicfiltersoperator2 ,
                                              AV66Notafiscalitemwwds_9_notafiscalitemcodigo2 ,
                                              AV67Notafiscalitemwwds_10_dynamicfiltersenabled3 ,
                                              AV68Notafiscalitemwwds_11_dynamicfiltersselector3 ,
                                              AV69Notafiscalitemwwds_12_dynamicfiltersoperator3 ,
                                              AV70Notafiscalitemwwds_13_notafiscalitemcodigo3 ,
                                              AV72Notafiscalitemwwds_15_tfpropostadescricao_sel ,
                                              AV71Notafiscalitemwwds_14_tfpropostadescricao ,
                                              AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel ,
                                              AV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo ,
                                              AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel ,
                                              AV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao ,
                                              AV77Notafiscalitemwwds_20_tfnotafiscalitemquantidade ,
                                              AV78Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to ,
                                              AV79Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario ,
                                              AV80Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to ,
                                              AV81Notafiscalitemwwds_24_tfnotafiscalitemvalortotal ,
                                              AV82Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to ,
                                              AV83Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels.Count ,
                                              A325PropostaDescricao ,
                                              A831NotaFiscalItemCodigo ,
                                              A833NotaFiscalItemDescricao ,
                                              A837NotaFiscalItemQuantidade ,
                                              A838NotaFiscalItemValorUnitario ,
                                              A839NotaFiscalItemValorTotal ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              A794NotaFiscalId ,
                                              AV58Notafiscalitemwwds_1_notafiscalid } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV59Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV59Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV59Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV59Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV59Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV59Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV59Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV59Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV59Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV62Notafiscalitemwwds_5_notafiscalitemcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV62Notafiscalitemwwds_5_notafiscalitemcodigo1), "%", "");
         lV62Notafiscalitemwwds_5_notafiscalitemcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV62Notafiscalitemwwds_5_notafiscalitemcodigo1), "%", "");
         lV66Notafiscalitemwwds_9_notafiscalitemcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV66Notafiscalitemwwds_9_notafiscalitemcodigo2), "%", "");
         lV66Notafiscalitemwwds_9_notafiscalitemcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV66Notafiscalitemwwds_9_notafiscalitemcodigo2), "%", "");
         lV70Notafiscalitemwwds_13_notafiscalitemcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV70Notafiscalitemwwds_13_notafiscalitemcodigo3), "%", "");
         lV70Notafiscalitemwwds_13_notafiscalitemcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV70Notafiscalitemwwds_13_notafiscalitemcodigo3), "%", "");
         lV71Notafiscalitemwwds_14_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV71Notafiscalitemwwds_14_tfpropostadescricao), "%", "");
         lV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo = StringUtil.Concat( StringUtil.RTrim( AV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo), "%", "");
         lV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao = StringUtil.Concat( StringUtil.RTrim( AV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao), "%", "");
         /* Using cursor H00933 */
         pr_default.execute(1, new Object[] {AV58Notafiscalitemwwds_1_notafiscalid, lV59Notafiscalitemwwds_2_filterfulltext, lV59Notafiscalitemwwds_2_filterfulltext, lV59Notafiscalitemwwds_2_filterfulltext, lV59Notafiscalitemwwds_2_filterfulltext, lV59Notafiscalitemwwds_2_filterfulltext, lV59Notafiscalitemwwds_2_filterfulltext, lV59Notafiscalitemwwds_2_filterfulltext, lV59Notafiscalitemwwds_2_filterfulltext, lV59Notafiscalitemwwds_2_filterfulltext, lV62Notafiscalitemwwds_5_notafiscalitemcodigo1, lV62Notafiscalitemwwds_5_notafiscalitemcodigo1, lV66Notafiscalitemwwds_9_notafiscalitemcodigo2, lV66Notafiscalitemwwds_9_notafiscalitemcodigo2, lV70Notafiscalitemwwds_13_notafiscalitemcodigo3, lV70Notafiscalitemwwds_13_notafiscalitemcodigo3, lV71Notafiscalitemwwds_14_tfpropostadescricao, AV72Notafiscalitemwwds_15_tfpropostadescricao_sel, lV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo, AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel, lV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao, AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel, AV77Notafiscalitemwwds_20_tfnotafiscalitemquantidade, AV78Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to, AV79Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario, AV80Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to, AV81Notafiscalitemwwds_24_tfnotafiscalitemvalortotal, AV82Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to});
         GRID_nRecordCount = H00933_AGRID_nRecordCount[0];
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
         AV58Notafiscalitemwwds_1_notafiscalid = AV55NotaFiscalId;
         AV59Notafiscalitemwwds_2_filterfulltext = AV15FilterFullText;
         AV60Notafiscalitemwwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV61Notafiscalitemwwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV62Notafiscalitemwwds_5_notafiscalitemcodigo1 = AV18NotaFiscalItemCodigo1;
         AV63Notafiscalitemwwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV64Notafiscalitemwwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV65Notafiscalitemwwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV66Notafiscalitemwwds_9_notafiscalitemcodigo2 = AV22NotaFiscalItemCodigo2;
         AV67Notafiscalitemwwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV68Notafiscalitemwwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV69Notafiscalitemwwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV70Notafiscalitemwwds_13_notafiscalitemcodigo3 = AV26NotaFiscalItemCodigo3;
         AV71Notafiscalitemwwds_14_tfpropostadescricao = AV35TFPropostaDescricao;
         AV72Notafiscalitemwwds_15_tfpropostadescricao_sel = AV36TFPropostaDescricao_Sel;
         AV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo = AV37TFNotaFiscalItemCodigo;
         AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel = AV38TFNotaFiscalItemCodigo_Sel;
         AV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao = AV39TFNotaFiscalItemDescricao;
         AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel = AV40TFNotaFiscalItemDescricao_Sel;
         AV77Notafiscalitemwwds_20_tfnotafiscalitemquantidade = AV41TFNotaFiscalItemQuantidade;
         AV78Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to = AV42TFNotaFiscalItemQuantidade_To;
         AV79Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario = AV43TFNotaFiscalItemValorUnitario;
         AV80Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to = AV44TFNotaFiscalItemValorUnitario_To;
         AV81Notafiscalitemwwds_24_tfnotafiscalitemvalortotal = AV45TFNotaFiscalItemValorTotal;
         AV82Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to = AV46TFNotaFiscalItemValorTotal_To;
         AV83Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels = AV48TFNotaFiscalItemVendido_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18NotaFiscalItemCodigo1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22NotaFiscalItemCodigo2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26NotaFiscalItemCodigo3, AV34ManageFiltersExecutionStep, AV57Pgmname, AV55NotaFiscalId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFPropostaDescricao, AV36TFPropostaDescricao_Sel, AV37TFNotaFiscalItemCodigo, AV38TFNotaFiscalItemCodigo_Sel, AV39TFNotaFiscalItemDescricao, AV40TFNotaFiscalItemDescricao_Sel, AV41TFNotaFiscalItemQuantidade, AV42TFNotaFiscalItemQuantidade_To, AV43TFNotaFiscalItemValorUnitario, AV44TFNotaFiscalItemValorUnitario_To, AV45TFNotaFiscalItemValorTotal, AV46TFNotaFiscalItemValorTotal_To, AV48TFNotaFiscalItemVendido_Sels, AV56NotaFiscalStatus, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV58Notafiscalitemwwds_1_notafiscalid = AV55NotaFiscalId;
         AV59Notafiscalitemwwds_2_filterfulltext = AV15FilterFullText;
         AV60Notafiscalitemwwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV61Notafiscalitemwwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV62Notafiscalitemwwds_5_notafiscalitemcodigo1 = AV18NotaFiscalItemCodigo1;
         AV63Notafiscalitemwwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV64Notafiscalitemwwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV65Notafiscalitemwwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV66Notafiscalitemwwds_9_notafiscalitemcodigo2 = AV22NotaFiscalItemCodigo2;
         AV67Notafiscalitemwwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV68Notafiscalitemwwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV69Notafiscalitemwwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV70Notafiscalitemwwds_13_notafiscalitemcodigo3 = AV26NotaFiscalItemCodigo3;
         AV71Notafiscalitemwwds_14_tfpropostadescricao = AV35TFPropostaDescricao;
         AV72Notafiscalitemwwds_15_tfpropostadescricao_sel = AV36TFPropostaDescricao_Sel;
         AV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo = AV37TFNotaFiscalItemCodigo;
         AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel = AV38TFNotaFiscalItemCodigo_Sel;
         AV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao = AV39TFNotaFiscalItemDescricao;
         AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel = AV40TFNotaFiscalItemDescricao_Sel;
         AV77Notafiscalitemwwds_20_tfnotafiscalitemquantidade = AV41TFNotaFiscalItemQuantidade;
         AV78Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to = AV42TFNotaFiscalItemQuantidade_To;
         AV79Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario = AV43TFNotaFiscalItemValorUnitario;
         AV80Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to = AV44TFNotaFiscalItemValorUnitario_To;
         AV81Notafiscalitemwwds_24_tfnotafiscalitemvalortotal = AV45TFNotaFiscalItemValorTotal;
         AV82Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to = AV46TFNotaFiscalItemValorTotal_To;
         AV83Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels = AV48TFNotaFiscalItemVendido_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18NotaFiscalItemCodigo1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22NotaFiscalItemCodigo2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26NotaFiscalItemCodigo3, AV34ManageFiltersExecutionStep, AV57Pgmname, AV55NotaFiscalId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFPropostaDescricao, AV36TFPropostaDescricao_Sel, AV37TFNotaFiscalItemCodigo, AV38TFNotaFiscalItemCodigo_Sel, AV39TFNotaFiscalItemDescricao, AV40TFNotaFiscalItemDescricao_Sel, AV41TFNotaFiscalItemQuantidade, AV42TFNotaFiscalItemQuantidade_To, AV43TFNotaFiscalItemValorUnitario, AV44TFNotaFiscalItemValorUnitario_To, AV45TFNotaFiscalItemValorTotal, AV46TFNotaFiscalItemValorTotal_To, AV48TFNotaFiscalItemVendido_Sels, AV56NotaFiscalStatus, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV58Notafiscalitemwwds_1_notafiscalid = AV55NotaFiscalId;
         AV59Notafiscalitemwwds_2_filterfulltext = AV15FilterFullText;
         AV60Notafiscalitemwwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV61Notafiscalitemwwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV62Notafiscalitemwwds_5_notafiscalitemcodigo1 = AV18NotaFiscalItemCodigo1;
         AV63Notafiscalitemwwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV64Notafiscalitemwwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV65Notafiscalitemwwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV66Notafiscalitemwwds_9_notafiscalitemcodigo2 = AV22NotaFiscalItemCodigo2;
         AV67Notafiscalitemwwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV68Notafiscalitemwwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV69Notafiscalitemwwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV70Notafiscalitemwwds_13_notafiscalitemcodigo3 = AV26NotaFiscalItemCodigo3;
         AV71Notafiscalitemwwds_14_tfpropostadescricao = AV35TFPropostaDescricao;
         AV72Notafiscalitemwwds_15_tfpropostadescricao_sel = AV36TFPropostaDescricao_Sel;
         AV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo = AV37TFNotaFiscalItemCodigo;
         AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel = AV38TFNotaFiscalItemCodigo_Sel;
         AV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao = AV39TFNotaFiscalItemDescricao;
         AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel = AV40TFNotaFiscalItemDescricao_Sel;
         AV77Notafiscalitemwwds_20_tfnotafiscalitemquantidade = AV41TFNotaFiscalItemQuantidade;
         AV78Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to = AV42TFNotaFiscalItemQuantidade_To;
         AV79Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario = AV43TFNotaFiscalItemValorUnitario;
         AV80Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to = AV44TFNotaFiscalItemValorUnitario_To;
         AV81Notafiscalitemwwds_24_tfnotafiscalitemvalortotal = AV45TFNotaFiscalItemValorTotal;
         AV82Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to = AV46TFNotaFiscalItemValorTotal_To;
         AV83Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels = AV48TFNotaFiscalItemVendido_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18NotaFiscalItemCodigo1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22NotaFiscalItemCodigo2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26NotaFiscalItemCodigo3, AV34ManageFiltersExecutionStep, AV57Pgmname, AV55NotaFiscalId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFPropostaDescricao, AV36TFPropostaDescricao_Sel, AV37TFNotaFiscalItemCodigo, AV38TFNotaFiscalItemCodigo_Sel, AV39TFNotaFiscalItemDescricao, AV40TFNotaFiscalItemDescricao_Sel, AV41TFNotaFiscalItemQuantidade, AV42TFNotaFiscalItemQuantidade_To, AV43TFNotaFiscalItemValorUnitario, AV44TFNotaFiscalItemValorUnitario_To, AV45TFNotaFiscalItemValorTotal, AV46TFNotaFiscalItemValorTotal_To, AV48TFNotaFiscalItemVendido_Sels, AV56NotaFiscalStatus, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV58Notafiscalitemwwds_1_notafiscalid = AV55NotaFiscalId;
         AV59Notafiscalitemwwds_2_filterfulltext = AV15FilterFullText;
         AV60Notafiscalitemwwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV61Notafiscalitemwwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV62Notafiscalitemwwds_5_notafiscalitemcodigo1 = AV18NotaFiscalItemCodigo1;
         AV63Notafiscalitemwwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV64Notafiscalitemwwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV65Notafiscalitemwwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV66Notafiscalitemwwds_9_notafiscalitemcodigo2 = AV22NotaFiscalItemCodigo2;
         AV67Notafiscalitemwwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV68Notafiscalitemwwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV69Notafiscalitemwwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV70Notafiscalitemwwds_13_notafiscalitemcodigo3 = AV26NotaFiscalItemCodigo3;
         AV71Notafiscalitemwwds_14_tfpropostadescricao = AV35TFPropostaDescricao;
         AV72Notafiscalitemwwds_15_tfpropostadescricao_sel = AV36TFPropostaDescricao_Sel;
         AV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo = AV37TFNotaFiscalItemCodigo;
         AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel = AV38TFNotaFiscalItemCodigo_Sel;
         AV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao = AV39TFNotaFiscalItemDescricao;
         AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel = AV40TFNotaFiscalItemDescricao_Sel;
         AV77Notafiscalitemwwds_20_tfnotafiscalitemquantidade = AV41TFNotaFiscalItemQuantidade;
         AV78Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to = AV42TFNotaFiscalItemQuantidade_To;
         AV79Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario = AV43TFNotaFiscalItemValorUnitario;
         AV80Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to = AV44TFNotaFiscalItemValorUnitario_To;
         AV81Notafiscalitemwwds_24_tfnotafiscalitemvalortotal = AV45TFNotaFiscalItemValorTotal;
         AV82Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to = AV46TFNotaFiscalItemValorTotal_To;
         AV83Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels = AV48TFNotaFiscalItemVendido_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18NotaFiscalItemCodigo1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22NotaFiscalItemCodigo2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26NotaFiscalItemCodigo3, AV34ManageFiltersExecutionStep, AV57Pgmname, AV55NotaFiscalId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFPropostaDescricao, AV36TFPropostaDescricao_Sel, AV37TFNotaFiscalItemCodigo, AV38TFNotaFiscalItemCodigo_Sel, AV39TFNotaFiscalItemDescricao, AV40TFNotaFiscalItemDescricao_Sel, AV41TFNotaFiscalItemQuantidade, AV42TFNotaFiscalItemQuantidade_To, AV43TFNotaFiscalItemValorUnitario, AV44TFNotaFiscalItemValorUnitario_To, AV45TFNotaFiscalItemValorTotal, AV46TFNotaFiscalItemValorTotal_To, AV48TFNotaFiscalItemVendido_Sels, AV56NotaFiscalStatus, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV58Notafiscalitemwwds_1_notafiscalid = AV55NotaFiscalId;
         AV59Notafiscalitemwwds_2_filterfulltext = AV15FilterFullText;
         AV60Notafiscalitemwwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV61Notafiscalitemwwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV62Notafiscalitemwwds_5_notafiscalitemcodigo1 = AV18NotaFiscalItemCodigo1;
         AV63Notafiscalitemwwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV64Notafiscalitemwwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV65Notafiscalitemwwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV66Notafiscalitemwwds_9_notafiscalitemcodigo2 = AV22NotaFiscalItemCodigo2;
         AV67Notafiscalitemwwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV68Notafiscalitemwwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV69Notafiscalitemwwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV70Notafiscalitemwwds_13_notafiscalitemcodigo3 = AV26NotaFiscalItemCodigo3;
         AV71Notafiscalitemwwds_14_tfpropostadescricao = AV35TFPropostaDescricao;
         AV72Notafiscalitemwwds_15_tfpropostadescricao_sel = AV36TFPropostaDescricao_Sel;
         AV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo = AV37TFNotaFiscalItemCodigo;
         AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel = AV38TFNotaFiscalItemCodigo_Sel;
         AV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao = AV39TFNotaFiscalItemDescricao;
         AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel = AV40TFNotaFiscalItemDescricao_Sel;
         AV77Notafiscalitemwwds_20_tfnotafiscalitemquantidade = AV41TFNotaFiscalItemQuantidade;
         AV78Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to = AV42TFNotaFiscalItemQuantidade_To;
         AV79Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario = AV43TFNotaFiscalItemValorUnitario;
         AV80Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to = AV44TFNotaFiscalItemValorUnitario_To;
         AV81Notafiscalitemwwds_24_tfnotafiscalitemvalortotal = AV45TFNotaFiscalItemValorTotal;
         AV82Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to = AV46TFNotaFiscalItemValorTotal_To;
         AV83Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels = AV48TFNotaFiscalItemVendido_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18NotaFiscalItemCodigo1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22NotaFiscalItemCodigo2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26NotaFiscalItemCodigo3, AV34ManageFiltersExecutionStep, AV57Pgmname, AV55NotaFiscalId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFPropostaDescricao, AV36TFPropostaDescricao_Sel, AV37TFNotaFiscalItemCodigo, AV38TFNotaFiscalItemCodigo_Sel, AV39TFNotaFiscalItemDescricao, AV40TFNotaFiscalItemDescricao_Sel, AV41TFNotaFiscalItemQuantidade, AV42TFNotaFiscalItemQuantidade_To, AV43TFNotaFiscalItemValorUnitario, AV44TFNotaFiscalItemValorUnitario_To, AV45TFNotaFiscalItemValorTotal, AV46TFNotaFiscalItemValorTotal_To, AV48TFNotaFiscalItemVendido_Sels, AV56NotaFiscalStatus, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV57Pgmname = "NotaFiscalItemWW";
         edtNotaFiscalItemId_Enabled = 0;
         edtPropostaId_Enabled = 0;
         edtNotaFiscalId_Enabled = 0;
         edtPropostaDescricao_Enabled = 0;
         edtNotaFiscalItemCodigo_Enabled = 0;
         edtNotaFiscalItemCFOP_Enabled = 0;
         edtNotaFiscalItemDescricao_Enabled = 0;
         edtNotaFiscalItemQuantidade_Enabled = 0;
         edtNotaFiscalItemValorUnitario_Enabled = 0;
         edtNotaFiscalItemValorTotal_Enabled = 0;
         cmbNotaFiscalItemVendido.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP930( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E25932 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV32ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV49DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_107 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_107"), ",", "."), 18, MidpointRounding.ToEven));
            AV51GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV52GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV53GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            wcpOAV55NotaFiscalId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV55NotaFiscalId"));
            wcpOAV56NotaFiscalStatus = cgiGet( sPrefix+"wcpOAV56NotaFiscalStatus");
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
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AV18NotaFiscalItemCodigo1 = cgiGet( edtavNotafiscalitemcodigo1_Internalname);
            AssignAttri(sPrefix, false, "AV18NotaFiscalItemCodigo1", AV18NotaFiscalItemCodigo1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV20DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri(sPrefix, false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AV22NotaFiscalItemCodigo2 = cgiGet( edtavNotafiscalitemcodigo2_Internalname);
            AssignAttri(sPrefix, false, "AV22NotaFiscalItemCodigo2", AV22NotaFiscalItemCodigo2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV24DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri(sPrefix, false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AV26NotaFiscalItemCodigo3 = cgiGet( edtavNotafiscalitemcodigo3_Internalname);
            AssignAttri(sPrefix, false, "AV26NotaFiscalItemCodigo3", AV26NotaFiscalItemCodigo3);
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
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vNOTAFISCALITEMCODIGO1"), AV18NotaFiscalItemCodigo1) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vNOTAFISCALITEMCODIGO2"), AV22NotaFiscalItemCodigo2) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vNOTAFISCALITEMCODIGO3"), AV26NotaFiscalItemCodigo3) != 0 )
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
         E25932 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E25932( )
      {
         /* Start Routine */
         returnInSub = false;
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
         AV16DynamicFiltersSelector1 = "NOTAFISCALITEMCODIGO";
         AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20DynamicFiltersSelector2 = "NOTAFISCALITEMCODIGO";
         AssignAttri(sPrefix, false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV24DynamicFiltersSelector3 = "NOTAFISCALITEMCODIGO";
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
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E26932( )
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
         if ( AV34ManageFiltersExecutionStep == 1 )
         {
            AV34ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV34ManageFiltersExecutionStep == 2 )
         {
            AV34ManageFiltersExecutionStep = 0;
            AssignAttri(sPrefix, false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
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
         AV51GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV51GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV51GridCurrentPage), 10, 0));
         AV52GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV52GridPageCount", StringUtil.LTrimStr( (decimal)(AV52GridPageCount), 10, 0));
         GXt_char2 = AV53GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV57Pgmname, out  GXt_char2) ;
         AV53GridAppliedFilters = GXt_char2;
         AssignAttri(sPrefix, false, "AV53GridAppliedFilters", AV53GridAppliedFilters);
         AV58Notafiscalitemwwds_1_notafiscalid = AV55NotaFiscalId;
         AV59Notafiscalitemwwds_2_filterfulltext = AV15FilterFullText;
         AV60Notafiscalitemwwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV61Notafiscalitemwwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV62Notafiscalitemwwds_5_notafiscalitemcodigo1 = AV18NotaFiscalItemCodigo1;
         AV63Notafiscalitemwwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV64Notafiscalitemwwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV65Notafiscalitemwwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV66Notafiscalitemwwds_9_notafiscalitemcodigo2 = AV22NotaFiscalItemCodigo2;
         AV67Notafiscalitemwwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV68Notafiscalitemwwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV69Notafiscalitemwwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV70Notafiscalitemwwds_13_notafiscalitemcodigo3 = AV26NotaFiscalItemCodigo3;
         AV71Notafiscalitemwwds_14_tfpropostadescricao = AV35TFPropostaDescricao;
         AV72Notafiscalitemwwds_15_tfpropostadescricao_sel = AV36TFPropostaDescricao_Sel;
         AV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo = AV37TFNotaFiscalItemCodigo;
         AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel = AV38TFNotaFiscalItemCodigo_Sel;
         AV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao = AV39TFNotaFiscalItemDescricao;
         AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel = AV40TFNotaFiscalItemDescricao_Sel;
         AV77Notafiscalitemwwds_20_tfnotafiscalitemquantidade = AV41TFNotaFiscalItemQuantidade;
         AV78Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to = AV42TFNotaFiscalItemQuantidade_To;
         AV79Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario = AV43TFNotaFiscalItemValorUnitario;
         AV80Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to = AV44TFNotaFiscalItemValorUnitario_To;
         AV81Notafiscalitemwwds_24_tfnotafiscalitemvalortotal = AV45TFNotaFiscalItemValorTotal;
         AV82Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to = AV46TFNotaFiscalItemValorTotal_To;
         AV83Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels = AV48TFNotaFiscalItemVendido_Sels;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E12932( )
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
            AV50PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV50PageToGo) ;
         }
      }

      protected void E13932( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14932( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaDescricao") == 0 )
            {
               AV35TFPropostaDescricao = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV35TFPropostaDescricao", AV35TFPropostaDescricao);
               AV36TFPropostaDescricao_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV36TFPropostaDescricao_Sel", AV36TFPropostaDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalItemCodigo") == 0 )
            {
               AV37TFNotaFiscalItemCodigo = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV37TFNotaFiscalItemCodigo", AV37TFNotaFiscalItemCodigo);
               AV38TFNotaFiscalItemCodigo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV38TFNotaFiscalItemCodigo_Sel", AV38TFNotaFiscalItemCodigo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalItemDescricao") == 0 )
            {
               AV39TFNotaFiscalItemDescricao = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV39TFNotaFiscalItemDescricao", AV39TFNotaFiscalItemDescricao);
               AV40TFNotaFiscalItemDescricao_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV40TFNotaFiscalItemDescricao_Sel", AV40TFNotaFiscalItemDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalItemQuantidade") == 0 )
            {
               AV41TFNotaFiscalItemQuantidade = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV41TFNotaFiscalItemQuantidade", StringUtil.LTrimStr( AV41TFNotaFiscalItemQuantidade, 18, 6));
               AV42TFNotaFiscalItemQuantidade_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV42TFNotaFiscalItemQuantidade_To", StringUtil.LTrimStr( AV42TFNotaFiscalItemQuantidade_To, 18, 6));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalItemValorUnitario") == 0 )
            {
               AV43TFNotaFiscalItemValorUnitario = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV43TFNotaFiscalItemValorUnitario", StringUtil.LTrimStr( AV43TFNotaFiscalItemValorUnitario, 18, 2));
               AV44TFNotaFiscalItemValorUnitario_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV44TFNotaFiscalItemValorUnitario_To", StringUtil.LTrimStr( AV44TFNotaFiscalItemValorUnitario_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalItemValorTotal") == 0 )
            {
               AV45TFNotaFiscalItemValorTotal = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV45TFNotaFiscalItemValorTotal", StringUtil.LTrimStr( AV45TFNotaFiscalItemValorTotal, 18, 2));
               AV46TFNotaFiscalItemValorTotal_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV46TFNotaFiscalItemValorTotal_To", StringUtil.LTrimStr( AV46TFNotaFiscalItemValorTotal_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalItemVendido") == 0 )
            {
               AV47TFNotaFiscalItemVendido_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV47TFNotaFiscalItemVendido_SelsJson", AV47TFNotaFiscalItemVendido_SelsJson);
               AV48TFNotaFiscalItemVendido_Sels.FromJSonString(AV47TFNotaFiscalItemVendido_SelsJson, null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV48TFNotaFiscalItemVendido_Sels", AV48TFNotaFiscalItemVendido_Sels);
      }

      private void E27932( )
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
         GXEncryptionTmp = "notafiscalitem"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(A830NotaFiscalItemId.ToString());
         edtNotaFiscalItemCodigo_Link = formatLink("notafiscalitem") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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

      protected void E20932( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = true;
         AssignAttri(sPrefix, false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp(sPrefix, false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp(sPrefix, false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E15932( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV28DynamicFiltersIgnoreFirst = true;
         AssignAttri(sPrefix, false, "AV28DynamicFiltersIgnoreFirst", AV28DynamicFiltersIgnoreFirst);
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
         AV27DynamicFiltersRemoving = false;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV28DynamicFiltersIgnoreFirst = false;
         AssignAttri(sPrefix, false, "AV28DynamicFiltersIgnoreFirst", AV28DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18NotaFiscalItemCodigo1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22NotaFiscalItemCodigo2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26NotaFiscalItemCodigo3, AV34ManageFiltersExecutionStep, AV57Pgmname, AV55NotaFiscalId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFPropostaDescricao, AV36TFPropostaDescricao_Sel, AV37TFNotaFiscalItemCodigo, AV38TFNotaFiscalItemCodigo_Sel, AV39TFNotaFiscalItemDescricao, AV40TFNotaFiscalItemDescricao_Sel, AV41TFNotaFiscalItemQuantidade, AV42TFNotaFiscalItemQuantidade_To, AV43TFNotaFiscalItemValorUnitario, AV44TFNotaFiscalItemValorUnitario_To, AV45TFNotaFiscalItemValorTotal, AV46TFNotaFiscalItemValorTotal_To, AV48TFNotaFiscalItemVendido_Sels, AV56NotaFiscalStatus, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E21932( )
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

      protected void E22932( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV23DynamicFiltersEnabled3 = true;
         AssignAttri(sPrefix, false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E16932( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV19DynamicFiltersEnabled2 = false;
         AssignAttri(sPrefix, false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
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
         AV27DynamicFiltersRemoving = false;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18NotaFiscalItemCodigo1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22NotaFiscalItemCodigo2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26NotaFiscalItemCodigo3, AV34ManageFiltersExecutionStep, AV57Pgmname, AV55NotaFiscalId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFPropostaDescricao, AV36TFPropostaDescricao_Sel, AV37TFNotaFiscalItemCodigo, AV38TFNotaFiscalItemCodigo_Sel, AV39TFNotaFiscalItemDescricao, AV40TFNotaFiscalItemDescricao_Sel, AV41TFNotaFiscalItemQuantidade, AV42TFNotaFiscalItemQuantidade_To, AV43TFNotaFiscalItemValorUnitario, AV44TFNotaFiscalItemValorUnitario_To, AV45TFNotaFiscalItemValorTotal, AV46TFNotaFiscalItemValorTotal_To, AV48TFNotaFiscalItemVendido_Sels, AV56NotaFiscalStatus, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E23932( )
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

      protected void E17932( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri(sPrefix, false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
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
         AV27DynamicFiltersRemoving = false;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18NotaFiscalItemCodigo1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22NotaFiscalItemCodigo2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26NotaFiscalItemCodigo3, AV34ManageFiltersExecutionStep, AV57Pgmname, AV55NotaFiscalId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFPropostaDescricao, AV36TFPropostaDescricao_Sel, AV37TFNotaFiscalItemCodigo, AV38TFNotaFiscalItemCodigo_Sel, AV39TFNotaFiscalItemDescricao, AV40TFNotaFiscalItemDescricao_Sel, AV41TFNotaFiscalItemQuantidade, AV42TFNotaFiscalItemQuantidade_To, AV43TFNotaFiscalItemValorUnitario, AV44TFNotaFiscalItemValorUnitario_To, AV45TFNotaFiscalItemValorTotal, AV46TFNotaFiscalItemValorTotal_To, AV48TFNotaFiscalItemVendido_Sels, AV56NotaFiscalStatus, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E24932( )
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

      protected void E11932( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("NotaFiscalItemWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV57Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV34ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("NotaFiscalItemWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV34ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char2 = AV33ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "NotaFiscalItemWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV33ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV33ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV57Pgmname+"GridState",  AV33ManageFiltersXml) ;
               AV10GridState.FromXml(AV33ManageFiltersXml, null, "", "");
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV48TFNotaFiscalItemVendido_Sels", AV48TFNotaFiscalItemVendido_Sels);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E18932( )
      {
         /* 'DoVenderItens' Routine */
         returnInSub = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wcimpnotafiscal"+UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.BoolToStr(false));
         CallWebObject(formatLink("wcimpnotafiscal") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E19932( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         new notafiscalitemwwexport(context ).execute( out  AV29ExcelFilename, out  AV30ErrorMessage) ;
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
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S182( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV56NotaFiscalStatus, "Parcial") == 0 ) ) )
         {
            bttBtnvenderitens_Visible = 0;
            AssignProp(sPrefix, false, bttBtnvenderitens_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnvenderitens_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavNotafiscalitemcodigo1_Visible = 0;
         AssignProp(sPrefix, false, edtavNotafiscalitemcodigo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNotafiscalitemcodigo1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "NOTAFISCALITEMCODIGO") == 0 )
         {
            edtavNotafiscalitemcodigo1_Visible = 1;
            AssignProp(sPrefix, false, edtavNotafiscalitemcodigo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNotafiscalitemcodigo1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavNotafiscalitemcodigo2_Visible = 0;
         AssignProp(sPrefix, false, edtavNotafiscalitemcodigo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNotafiscalitemcodigo2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "NOTAFISCALITEMCODIGO") == 0 )
         {
            edtavNotafiscalitemcodigo2_Visible = 1;
            AssignProp(sPrefix, false, edtavNotafiscalitemcodigo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNotafiscalitemcodigo2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavNotafiscalitemcodigo3_Visible = 0;
         AssignProp(sPrefix, false, edtavNotafiscalitemcodigo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNotafiscalitemcodigo3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "NOTAFISCALITEMCODIGO") == 0 )
         {
            edtavNotafiscalitemcodigo3_Visible = 1;
            AssignProp(sPrefix, false, edtavNotafiscalitemcodigo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNotafiscalitemcodigo3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S212( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = false;
         AssignAttri(sPrefix, false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         AV20DynamicFiltersSelector2 = "NOTAFISCALITEMCODIGO";
         AssignAttri(sPrefix, false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         AV21DynamicFiltersOperator2 = 0;
         AssignAttri(sPrefix, false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AV22NotaFiscalItemCodigo2 = "";
         AssignAttri(sPrefix, false, "AV22NotaFiscalItemCodigo2", AV22NotaFiscalItemCodigo2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri(sPrefix, false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         AV24DynamicFiltersSelector3 = "NOTAFISCALITEMCODIGO";
         AssignAttri(sPrefix, false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         AV25DynamicFiltersOperator3 = 0;
         AssignAttri(sPrefix, false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AV26NotaFiscalItemCodigo3 = "";
         AssignAttri(sPrefix, false, "AV26NotaFiscalItemCodigo3", AV26NotaFiscalItemCodigo3);
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "NotaFiscalItemWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV32ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S232( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
         AV35TFPropostaDescricao = "";
         AssignAttri(sPrefix, false, "AV35TFPropostaDescricao", AV35TFPropostaDescricao);
         AV36TFPropostaDescricao_Sel = "";
         AssignAttri(sPrefix, false, "AV36TFPropostaDescricao_Sel", AV36TFPropostaDescricao_Sel);
         AV37TFNotaFiscalItemCodigo = "";
         AssignAttri(sPrefix, false, "AV37TFNotaFiscalItemCodigo", AV37TFNotaFiscalItemCodigo);
         AV38TFNotaFiscalItemCodigo_Sel = "";
         AssignAttri(sPrefix, false, "AV38TFNotaFiscalItemCodigo_Sel", AV38TFNotaFiscalItemCodigo_Sel);
         AV39TFNotaFiscalItemDescricao = "";
         AssignAttri(sPrefix, false, "AV39TFNotaFiscalItemDescricao", AV39TFNotaFiscalItemDescricao);
         AV40TFNotaFiscalItemDescricao_Sel = "";
         AssignAttri(sPrefix, false, "AV40TFNotaFiscalItemDescricao_Sel", AV40TFNotaFiscalItemDescricao_Sel);
         AV41TFNotaFiscalItemQuantidade = 0;
         AssignAttri(sPrefix, false, "AV41TFNotaFiscalItemQuantidade", StringUtil.LTrimStr( AV41TFNotaFiscalItemQuantidade, 18, 6));
         AV42TFNotaFiscalItemQuantidade_To = 0;
         AssignAttri(sPrefix, false, "AV42TFNotaFiscalItemQuantidade_To", StringUtil.LTrimStr( AV42TFNotaFiscalItemQuantidade_To, 18, 6));
         AV43TFNotaFiscalItemValorUnitario = 0;
         AssignAttri(sPrefix, false, "AV43TFNotaFiscalItemValorUnitario", StringUtil.LTrimStr( AV43TFNotaFiscalItemValorUnitario, 18, 2));
         AV44TFNotaFiscalItemValorUnitario_To = 0;
         AssignAttri(sPrefix, false, "AV44TFNotaFiscalItemValorUnitario_To", StringUtil.LTrimStr( AV44TFNotaFiscalItemValorUnitario_To, 18, 2));
         AV45TFNotaFiscalItemValorTotal = 0;
         AssignAttri(sPrefix, false, "AV45TFNotaFiscalItemValorTotal", StringUtil.LTrimStr( AV45TFNotaFiscalItemValorTotal, 18, 2));
         AV46TFNotaFiscalItemValorTotal_To = 0;
         AssignAttri(sPrefix, false, "AV46TFNotaFiscalItemValorTotal_To", StringUtil.LTrimStr( AV46TFNotaFiscalItemValorTotal_To, 18, 2));
         AV48TFNotaFiscalItemVendido_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV16DynamicFiltersSelector1 = "NOTAFISCALITEMCODIGO";
         AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AV18NotaFiscalItemCodigo1 = "";
         AssignAttri(sPrefix, false, "AV18NotaFiscalItemCodigo1", AV18NotaFiscalItemCodigo1);
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
         if ( StringUtil.StrCmp(AV31Session.Get(AV57Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV57Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV31Session.Get(AV57Pgmname+"GridState"), null, "", "");
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
         AV84GXV1 = 1;
         while ( AV84GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV84GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTADESCRICAO") == 0 )
            {
               AV35TFPropostaDescricao = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV35TFPropostaDescricao", AV35TFPropostaDescricao);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTADESCRICAO_SEL") == 0 )
            {
               AV36TFPropostaDescricao_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV36TFPropostaDescricao_Sel", AV36TFPropostaDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMCODIGO") == 0 )
            {
               AV37TFNotaFiscalItemCodigo = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV37TFNotaFiscalItemCodigo", AV37TFNotaFiscalItemCodigo);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMCODIGO_SEL") == 0 )
            {
               AV38TFNotaFiscalItemCodigo_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV38TFNotaFiscalItemCodigo_Sel", AV38TFNotaFiscalItemCodigo_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMDESCRICAO") == 0 )
            {
               AV39TFNotaFiscalItemDescricao = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV39TFNotaFiscalItemDescricao", AV39TFNotaFiscalItemDescricao);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMDESCRICAO_SEL") == 0 )
            {
               AV40TFNotaFiscalItemDescricao_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV40TFNotaFiscalItemDescricao_Sel", AV40TFNotaFiscalItemDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMQUANTIDADE") == 0 )
            {
               AV41TFNotaFiscalItemQuantidade = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV41TFNotaFiscalItemQuantidade", StringUtil.LTrimStr( AV41TFNotaFiscalItemQuantidade, 18, 6));
               AV42TFNotaFiscalItemQuantidade_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV42TFNotaFiscalItemQuantidade_To", StringUtil.LTrimStr( AV42TFNotaFiscalItemQuantidade_To, 18, 6));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMVALORUNITARIO") == 0 )
            {
               AV43TFNotaFiscalItemValorUnitario = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV43TFNotaFiscalItemValorUnitario", StringUtil.LTrimStr( AV43TFNotaFiscalItemValorUnitario, 18, 2));
               AV44TFNotaFiscalItemValorUnitario_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV44TFNotaFiscalItemValorUnitario_To", StringUtil.LTrimStr( AV44TFNotaFiscalItemValorUnitario_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMVALORTOTAL") == 0 )
            {
               AV45TFNotaFiscalItemValorTotal = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV45TFNotaFiscalItemValorTotal", StringUtil.LTrimStr( AV45TFNotaFiscalItemValorTotal, 18, 2));
               AV46TFNotaFiscalItemValorTotal_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV46TFNotaFiscalItemValorTotal_To", StringUtil.LTrimStr( AV46TFNotaFiscalItemValorTotal_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMVENDIDO_SEL") == 0 )
            {
               AV47TFNotaFiscalItemVendido_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV47TFNotaFiscalItemVendido_SelsJson", AV47TFNotaFiscalItemVendido_SelsJson);
               AV48TFNotaFiscalItemVendido_Sels.FromJSonString(AV47TFNotaFiscalItemVendido_SelsJson, null);
            }
            AV84GXV1 = (int)(AV84GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPropostaDescricao_Sel)),  AV36TFPropostaDescricao_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFNotaFiscalItemCodigo_Sel)),  AV38TFNotaFiscalItemCodigo_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFNotaFiscalItemDescricao_Sel)),  AV40TFNotaFiscalItemDescricao_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV48TFNotaFiscalItemVendido_Sels.Count==0),  AV47TFNotaFiscalItemVendido_SelsJson, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|"+GXt_char5+"||||"+GXt_char6;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFPropostaDescricao)),  AV35TFPropostaDescricao, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFNotaFiscalItemCodigo)),  AV37TFNotaFiscalItemCodigo, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFNotaFiscalItemDescricao)),  AV39TFNotaFiscalItemDescricao, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = GXt_char6+"|"+GXt_char5+"|"+GXt_char4+"|"+((Convert.ToDecimal(0)==AV41TFNotaFiscalItemQuantidade) ? "" : StringUtil.Str( AV41TFNotaFiscalItemQuantidade, 18, 6))+"|"+((Convert.ToDecimal(0)==AV43TFNotaFiscalItemValorUnitario) ? "" : StringUtil.Str( AV43TFNotaFiscalItemValorUnitario, 18, 2))+"|"+((Convert.ToDecimal(0)==AV45TFNotaFiscalItemValorTotal) ? "" : StringUtil.Str( AV45TFNotaFiscalItemValorTotal, 18, 2))+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|||"+((Convert.ToDecimal(0)==AV42TFNotaFiscalItemQuantidade_To) ? "" : StringUtil.Str( AV42TFNotaFiscalItemQuantidade_To, 18, 6))+"|"+((Convert.ToDecimal(0)==AV44TFNotaFiscalItemValorUnitario_To) ? "" : StringUtil.Str( AV44TFNotaFiscalItemValorUnitario_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV46TFNotaFiscalItemValorTotal_To) ? "" : StringUtil.Str( AV46TFNotaFiscalItemValorTotal_To, 18, 2))+"|";
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
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "NOTAFISCALITEMCODIGO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV18NotaFiscalItemCodigo1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV18NotaFiscalItemCodigo1", AV18NotaFiscalItemCodigo1);
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
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "NOTAFISCALITEMCODIGO") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri(sPrefix, false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV22NotaFiscalItemCodigo2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri(sPrefix, false, "AV22NotaFiscalItemCodigo2", AV22NotaFiscalItemCodigo2);
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
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "NOTAFISCALITEMCODIGO") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri(sPrefix, false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
                     AV26NotaFiscalItemCodigo3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri(sPrefix, false, "AV26NotaFiscalItemCodigo3", AV26NotaFiscalItemCodigo3);
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

      protected void S192( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV31Session.Get(AV57Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPROPOSTADESCRICAO",  "Solicitação",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFPropostaDescricao)),  0,  AV35TFPropostaDescricao,  AV35TFPropostaDescricao,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPropostaDescricao_Sel)),  AV36TFPropostaDescricao_Sel,  AV36TFPropostaDescricao_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFNOTAFISCALITEMCODIGO",  "Código",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFNotaFiscalItemCodigo)),  0,  AV37TFNotaFiscalItemCodigo,  AV37TFNotaFiscalItemCodigo,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFNotaFiscalItemCodigo_Sel)),  AV38TFNotaFiscalItemCodigo_Sel,  AV38TFNotaFiscalItemCodigo_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFNOTAFISCALITEMDESCRICAO",  "Descrição",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFNotaFiscalItemDescricao)),  0,  AV39TFNotaFiscalItemDescricao,  AV39TFNotaFiscalItemDescricao,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFNotaFiscalItemDescricao_Sel)),  AV40TFNotaFiscalItemDescricao_Sel,  AV40TFNotaFiscalItemDescricao_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFNOTAFISCALITEMQUANTIDADE",  "Quantidade",  !((Convert.ToDecimal(0)==AV41TFNotaFiscalItemQuantidade)&&(Convert.ToDecimal(0)==AV42TFNotaFiscalItemQuantidade_To)),  0,  StringUtil.Trim( StringUtil.Str( AV41TFNotaFiscalItemQuantidade, 18, 6)),  ((Convert.ToDecimal(0)==AV41TFNotaFiscalItemQuantidade) ? "" : StringUtil.Trim( context.localUtil.Format( AV41TFNotaFiscalItemQuantidade, "ZZZZZZZZZZ9.999999"))),  true,  StringUtil.Trim( StringUtil.Str( AV42TFNotaFiscalItemQuantidade_To, 18, 6)),  ((Convert.ToDecimal(0)==AV42TFNotaFiscalItemQuantidade_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV42TFNotaFiscalItemQuantidade_To, "ZZZZZZZZZZ9.999999")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFNOTAFISCALITEMVALORUNITARIO",  "Unitário",  !((Convert.ToDecimal(0)==AV43TFNotaFiscalItemValorUnitario)&&(Convert.ToDecimal(0)==AV44TFNotaFiscalItemValorUnitario_To)),  0,  StringUtil.Trim( StringUtil.Str( AV43TFNotaFiscalItemValorUnitario, 18, 2)),  ((Convert.ToDecimal(0)==AV43TFNotaFiscalItemValorUnitario) ? "" : StringUtil.Trim( context.localUtil.Format( AV43TFNotaFiscalItemValorUnitario, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV44TFNotaFiscalItemValorUnitario_To, 18, 2)),  ((Convert.ToDecimal(0)==AV44TFNotaFiscalItemValorUnitario_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV44TFNotaFiscalItemValorUnitario_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFNOTAFISCALITEMVALORTOTAL",  "Total",  !((Convert.ToDecimal(0)==AV45TFNotaFiscalItemValorTotal)&&(Convert.ToDecimal(0)==AV46TFNotaFiscalItemValorTotal_To)),  0,  StringUtil.Trim( StringUtil.Str( AV45TFNotaFiscalItemValorTotal, 18, 2)),  ((Convert.ToDecimal(0)==AV45TFNotaFiscalItemValorTotal) ? "" : StringUtil.Trim( context.localUtil.Format( AV45TFNotaFiscalItemValorTotal, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV46TFNotaFiscalItemValorTotal_To, 18, 2)),  ((Convert.ToDecimal(0)==AV46TFNotaFiscalItemValorTotal_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV46TFNotaFiscalItemValorTotal_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         AV54AuxText = ((AV48TFNotaFiscalItemVendido_Sels.Count==1) ? "["+((string)AV48TFNotaFiscalItemVendido_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFNOTAFISCALITEMVENDIDO_SEL",  "Status",  !(AV48TFNotaFiscalItemVendido_Sels.Count==0),  0,  AV48TFNotaFiscalItemVendido_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV54AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV54AuxText, "[VENDIDO]", "Vendido"), "[ABERTO]", "Aberto"), "[DEVOLVIDO]", "Devolvido")),  false,  "",  "") ;
         if ( ! (Guid.Empty==AV55NotaFiscalId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&NOTAFISCALID";
            AV11GridStateFilterValue.gxTpr_Value = AV55NotaFiscalId.ToString();
            AV10GridState.gxTpr_Filtervalues.Add(AV11GridStateFilterValue, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56NotaFiscalStatus)) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&NOTAFISCALSTATUS";
            AV11GridStateFilterValue.gxTpr_Value = AV56NotaFiscalStatus;
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
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV57Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S202( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV28DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV16DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "NOTAFISCALITEMCODIGO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18NotaFiscalItemCodigo1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Item Codigo",  AV17DynamicFiltersOperator1,  AV18NotaFiscalItemCodigo1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV18NotaFiscalItemCodigo1, "Contém"+" "+AV18NotaFiscalItemCodigo1, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "NOTAFISCALITEMCODIGO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV22NotaFiscalItemCodigo2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Item Codigo",  AV21DynamicFiltersOperator2,  AV22NotaFiscalItemCodigo2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV22NotaFiscalItemCodigo2, "Contém"+" "+AV22NotaFiscalItemCodigo2, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "NOTAFISCALITEMCODIGO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV26NotaFiscalItemCodigo3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Item Codigo",  AV25DynamicFiltersOperator3,  AV26NotaFiscalItemCodigo3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV26NotaFiscalItemCodigo3, "Contém"+" "+AV26NotaFiscalItemCodigo3, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
         AV8TrnContext.gxTpr_Callerobject = AV57Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "NotaFiscalItem";
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "NotaFiscalId";
         AV9TrnContextAtt.gxTpr_Attributevalue = AV55NotaFiscalId.ToString();
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV31Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_89_932( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "", true, 0, "HLP_NotaFiscalItemWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_notafiscalitemcodigo3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNotafiscalitemcodigo3_Internalname, "Nota Fiscal Item Codigo3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNotafiscalitemcodigo3_Internalname, AV26NotaFiscalItemCodigo3, StringUtil.RTrim( context.localUtil.Format( AV26NotaFiscalItemCodigo3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNotafiscalitemcodigo3_Jsonclick, 0, "Attribute", "", "", "", "", edtavNotafiscalitemcodigo3_Visible, edtavNotafiscalitemcodigo3_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscalItemWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_NotaFiscalItemWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_89_932e( true) ;
         }
         else
         {
            wb_table3_89_932e( false) ;
         }
      }

      protected void wb_table2_67_932( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "", true, 0, "HLP_NotaFiscalItemWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_notafiscalitemcodigo2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNotafiscalitemcodigo2_Internalname, "Nota Fiscal Item Codigo2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNotafiscalitemcodigo2_Internalname, AV22NotaFiscalItemCodigo2, StringUtil.RTrim( context.localUtil.Format( AV22NotaFiscalItemCodigo2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNotafiscalitemcodigo2_Jsonclick, 0, "Attribute", "", "", "", "", edtavNotafiscalitemcodigo2_Visible, edtavNotafiscalitemcodigo2_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscalItemWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_NotaFiscalItemWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_NotaFiscalItemWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_67_932e( true) ;
         }
         else
         {
            wb_table2_67_932e( false) ;
         }
      }

      protected void wb_table1_45_932( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_NotaFiscalItemWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_notafiscalitemcodigo1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNotafiscalitemcodigo1_Internalname, "Nota Fiscal Item Codigo1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNotafiscalitemcodigo1_Internalname, AV18NotaFiscalItemCodigo1, StringUtil.RTrim( context.localUtil.Format( AV18NotaFiscalItemCodigo1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNotafiscalitemcodigo1_Jsonclick, 0, "Attribute", "", "", "", "", edtavNotafiscalitemcodigo1_Visible, edtavNotafiscalitemcodigo1_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscalItemWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_NotaFiscalItemWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_NotaFiscalItemWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_45_932e( true) ;
         }
         else
         {
            wb_table1_45_932e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV55NotaFiscalId = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV55NotaFiscalId", AV55NotaFiscalId.ToString());
         AV56NotaFiscalStatus = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV56NotaFiscalStatus", AV56NotaFiscalStatus);
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
         PA932( ) ;
         WS932( ) ;
         WE932( ) ;
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
         sCtrlAV55NotaFiscalId = (string)((string)getParm(obj,0));
         sCtrlAV56NotaFiscalStatus = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA932( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "notafiscalitemww", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA932( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV55NotaFiscalId = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV55NotaFiscalId", AV55NotaFiscalId.ToString());
            AV56NotaFiscalStatus = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV56NotaFiscalStatus", AV56NotaFiscalStatus);
         }
         wcpOAV55NotaFiscalId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV55NotaFiscalId"));
         wcpOAV56NotaFiscalStatus = cgiGet( sPrefix+"wcpOAV56NotaFiscalStatus");
         if ( ! GetJustCreated( ) && ( ( AV55NotaFiscalId != wcpOAV55NotaFiscalId ) || ( StringUtil.StrCmp(AV56NotaFiscalStatus, wcpOAV56NotaFiscalStatus) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV55NotaFiscalId = AV55NotaFiscalId;
         wcpOAV56NotaFiscalStatus = AV56NotaFiscalStatus;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV55NotaFiscalId = cgiGet( sPrefix+"AV55NotaFiscalId_CTRL");
         if ( StringUtil.Len( sCtrlAV55NotaFiscalId) > 0 )
         {
            AV55NotaFiscalId = StringUtil.StrToGuid( cgiGet( sCtrlAV55NotaFiscalId));
            AssignAttri(sPrefix, false, "AV55NotaFiscalId", AV55NotaFiscalId.ToString());
         }
         else
         {
            AV55NotaFiscalId = StringUtil.StrToGuid( cgiGet( sPrefix+"AV55NotaFiscalId_PARM"));
         }
         sCtrlAV56NotaFiscalStatus = cgiGet( sPrefix+"AV56NotaFiscalStatus_CTRL");
         if ( StringUtil.Len( sCtrlAV56NotaFiscalStatus) > 0 )
         {
            AV56NotaFiscalStatus = cgiGet( sCtrlAV56NotaFiscalStatus);
            AssignAttri(sPrefix, false, "AV56NotaFiscalStatus", AV56NotaFiscalStatus);
         }
         else
         {
            AV56NotaFiscalStatus = cgiGet( sPrefix+"AV56NotaFiscalStatus_PARM");
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
         PA932( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS932( ) ;
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
         WS932( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV55NotaFiscalId_PARM", AV55NotaFiscalId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV55NotaFiscalId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV55NotaFiscalId_CTRL", StringUtil.RTrim( sCtrlAV55NotaFiscalId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV56NotaFiscalStatus_PARM", AV56NotaFiscalStatus);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV56NotaFiscalStatus)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV56NotaFiscalStatus_CTRL", StringUtil.RTrim( sCtrlAV56NotaFiscalStatus));
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
         WE932( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019212981", true, true);
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
         context.AddJavascriptSource("notafiscalitemww.js", "?202561019212981", false, true);
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

      protected void SubsflControlProps_1072( )
      {
         edtNotaFiscalItemId_Internalname = sPrefix+"NOTAFISCALITEMID_"+sGXsfl_107_idx;
         edtPropostaId_Internalname = sPrefix+"PROPOSTAID_"+sGXsfl_107_idx;
         edtNotaFiscalId_Internalname = sPrefix+"NOTAFISCALID_"+sGXsfl_107_idx;
         edtPropostaDescricao_Internalname = sPrefix+"PROPOSTADESCRICAO_"+sGXsfl_107_idx;
         edtNotaFiscalItemCodigo_Internalname = sPrefix+"NOTAFISCALITEMCODIGO_"+sGXsfl_107_idx;
         edtNotaFiscalItemCFOP_Internalname = sPrefix+"NOTAFISCALITEMCFOP_"+sGXsfl_107_idx;
         edtNotaFiscalItemDescricao_Internalname = sPrefix+"NOTAFISCALITEMDESCRICAO_"+sGXsfl_107_idx;
         edtNotaFiscalItemQuantidade_Internalname = sPrefix+"NOTAFISCALITEMQUANTIDADE_"+sGXsfl_107_idx;
         edtNotaFiscalItemValorUnitario_Internalname = sPrefix+"NOTAFISCALITEMVALORUNITARIO_"+sGXsfl_107_idx;
         edtNotaFiscalItemValorTotal_Internalname = sPrefix+"NOTAFISCALITEMVALORTOTAL_"+sGXsfl_107_idx;
         cmbNotaFiscalItemVendido_Internalname = sPrefix+"NOTAFISCALITEMVENDIDO_"+sGXsfl_107_idx;
      }

      protected void SubsflControlProps_fel_1072( )
      {
         edtNotaFiscalItemId_Internalname = sPrefix+"NOTAFISCALITEMID_"+sGXsfl_107_fel_idx;
         edtPropostaId_Internalname = sPrefix+"PROPOSTAID_"+sGXsfl_107_fel_idx;
         edtNotaFiscalId_Internalname = sPrefix+"NOTAFISCALID_"+sGXsfl_107_fel_idx;
         edtPropostaDescricao_Internalname = sPrefix+"PROPOSTADESCRICAO_"+sGXsfl_107_fel_idx;
         edtNotaFiscalItemCodigo_Internalname = sPrefix+"NOTAFISCALITEMCODIGO_"+sGXsfl_107_fel_idx;
         edtNotaFiscalItemCFOP_Internalname = sPrefix+"NOTAFISCALITEMCFOP_"+sGXsfl_107_fel_idx;
         edtNotaFiscalItemDescricao_Internalname = sPrefix+"NOTAFISCALITEMDESCRICAO_"+sGXsfl_107_fel_idx;
         edtNotaFiscalItemQuantidade_Internalname = sPrefix+"NOTAFISCALITEMQUANTIDADE_"+sGXsfl_107_fel_idx;
         edtNotaFiscalItemValorUnitario_Internalname = sPrefix+"NOTAFISCALITEMVALORUNITARIO_"+sGXsfl_107_fel_idx;
         edtNotaFiscalItemValorTotal_Internalname = sPrefix+"NOTAFISCALITEMVALORTOTAL_"+sGXsfl_107_fel_idx;
         cmbNotaFiscalItemVendido_Internalname = sPrefix+"NOTAFISCALITEMVENDIDO_"+sGXsfl_107_fel_idx;
      }

      protected void sendrow_1072( )
      {
         sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
         SubsflControlProps_1072( ) ;
         WB930( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalItemId_Internalname,A830NotaFiscalItemId.ToString(),A830NotaFiscalItemId.ToString(),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalItemId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)107,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalId_Internalname,A794NotaFiscalId.ToString(),A794NotaFiscalId.ToString(),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)107,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaDescricao_Internalname,(string)A325PropostaDescricao,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaDescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalItemCodigo_Internalname,(string)A831NotaFiscalItemCodigo,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtNotaFiscalItemCodigo_Link,(string)"",(string)"",(string)"",(string)edtNotaFiscalItemCodigo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalItemCFOP_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A832NotaFiscalItemCFOP), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A832NotaFiscalItemCFOP), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalItemCFOP_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalItemDescricao_Internalname,(string)A833NotaFiscalItemDescricao,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalItemDescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)255,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalItemQuantidade_Internalname,StringUtil.LTrim( StringUtil.NToC( A837NotaFiscalItemQuantidade, 18, 6, ",", "")),StringUtil.LTrim( context.localUtil.Format( A837NotaFiscalItemQuantidade, "ZZZZZZZZZZ9.999999")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalItemQuantidade_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalItemValorUnitario_Internalname,StringUtil.LTrim( StringUtil.NToC( A838NotaFiscalItemValorUnitario, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A838NotaFiscalItemValorUnitario, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalItemValorUnitario_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalItemValorTotal_Internalname,StringUtil.LTrim( StringUtil.NToC( A839NotaFiscalItemValorTotal, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A839NotaFiscalItemValorTotal, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalItemValorTotal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbNotaFiscalItemVendido.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "NOTAFISCALITEMVENDIDO_" + sGXsfl_107_idx;
               cmbNotaFiscalItemVendido.Name = GXCCtl;
               cmbNotaFiscalItemVendido.WebTags = "";
               cmbNotaFiscalItemVendido.addItem("VENDIDO", "Vendido", 0);
               cmbNotaFiscalItemVendido.addItem("ABERTO", "Aberto", 0);
               cmbNotaFiscalItemVendido.addItem("DEVOLVIDO", "Devolvido", 0);
               if ( cmbNotaFiscalItemVendido.ItemCount > 0 )
               {
                  A851NotaFiscalItemVendido = cmbNotaFiscalItemVendido.getValidValue(A851NotaFiscalItemVendido);
                  n851NotaFiscalItemVendido = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbNotaFiscalItemVendido,(string)cmbNotaFiscalItemVendido_Internalname,StringUtil.RTrim( A851NotaFiscalItemVendido),(short)1,(string)cmbNotaFiscalItemVendido_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbNotaFiscalItemVendido.CurrentValue = StringUtil.RTrim( A851NotaFiscalItemVendido);
            AssignProp(sPrefix, false, cmbNotaFiscalItemVendido_Internalname, "Values", (string)(cmbNotaFiscalItemVendido.ToJavascriptSource()), !bGXsfl_107_Refreshing);
            send_integrity_lvl_hashes932( ) ;
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
         cmbavDynamicfiltersselector1.addItem("NOTAFISCALITEMCODIGO", "Item Codigo", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("NOTAFISCALITEMCODIGO", "Item Codigo", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("NOTAFISCALITEMCODIGO", "Item Codigo", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
         }
         GXCCtl = "NOTAFISCALITEMVENDIDO_" + sGXsfl_107_idx;
         cmbNotaFiscalItemVendido.Name = GXCCtl;
         cmbNotaFiscalItemVendido.WebTags = "";
         cmbNotaFiscalItemVendido.addItem("VENDIDO", "Vendido", 0);
         cmbNotaFiscalItemVendido.addItem("ABERTO", "Aberto", 0);
         cmbNotaFiscalItemVendido.addItem("DEVOLVIDO", "Devolvido", 0);
         if ( cmbNotaFiscalItemVendido.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl107( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"107\">") ;
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Item Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Fiscal Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Solicitação") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Código") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Item CFOP") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Descrição") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Quantidade") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Unitário") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Total") ;
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
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A830NotaFiscalItemId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A794NotaFiscalId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A325PropostaDescricao));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A831NotaFiscalItemCodigo));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtNotaFiscalItemCodigo_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A832NotaFiscalItemCFOP), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A833NotaFiscalItemDescricao));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A837NotaFiscalItemQuantidade, 18, 6, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A838NotaFiscalItemValorUnitario, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A839NotaFiscalItemValorTotal, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A851NotaFiscalItemVendido));
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
         bttBtnexport_Internalname = sPrefix+"BTNEXPORT";
         bttBtnvenderitens_Internalname = sPrefix+"BTNVENDERITENS";
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
         edtavNotafiscalitemcodigo1_Internalname = sPrefix+"vNOTAFISCALITEMCODIGO1";
         cellFilter_notafiscalitemcodigo1_cell_Internalname = sPrefix+"FILTER_NOTAFISCALITEMCODIGO1_CELL";
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
         edtavNotafiscalitemcodigo2_Internalname = sPrefix+"vNOTAFISCALITEMCODIGO2";
         cellFilter_notafiscalitemcodigo2_cell_Internalname = sPrefix+"FILTER_NOTAFISCALITEMCODIGO2_CELL";
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
         edtavNotafiscalitemcodigo3_Internalname = sPrefix+"vNOTAFISCALITEMCODIGO3";
         cellFilter_notafiscalitemcodigo3_cell_Internalname = sPrefix+"FILTER_NOTAFISCALITEMCODIGO3_CELL";
         imgRemovedynamicfilters3_Internalname = sPrefix+"REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = sPrefix+"DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = sPrefix+"TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = sPrefix+"TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = sPrefix+"TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = sPrefix+"ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         Dvpanel_tableheader_Internalname = sPrefix+"DVPANEL_TABLEHEADER";
         edtNotaFiscalItemId_Internalname = sPrefix+"NOTAFISCALITEMID";
         edtPropostaId_Internalname = sPrefix+"PROPOSTAID";
         edtNotaFiscalId_Internalname = sPrefix+"NOTAFISCALID";
         edtPropostaDescricao_Internalname = sPrefix+"PROPOSTADESCRICAO";
         edtNotaFiscalItemCodigo_Internalname = sPrefix+"NOTAFISCALITEMCODIGO";
         edtNotaFiscalItemCFOP_Internalname = sPrefix+"NOTAFISCALITEMCFOP";
         edtNotaFiscalItemDescricao_Internalname = sPrefix+"NOTAFISCALITEMDESCRICAO";
         edtNotaFiscalItemQuantidade_Internalname = sPrefix+"NOTAFISCALITEMQUANTIDADE";
         edtNotaFiscalItemValorUnitario_Internalname = sPrefix+"NOTAFISCALITEMVALORUNITARIO";
         edtNotaFiscalItemValorTotal_Internalname = sPrefix+"NOTAFISCALITEMVALORTOTAL";
         cmbNotaFiscalItemVendido_Internalname = sPrefix+"NOTAFISCALITEMVENDIDO";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         lblJsdynamicfilters_Internalname = sPrefix+"JSDYNAMICFILTERS";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
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
         cmbNotaFiscalItemVendido_Jsonclick = "";
         edtNotaFiscalItemValorTotal_Jsonclick = "";
         edtNotaFiscalItemValorUnitario_Jsonclick = "";
         edtNotaFiscalItemQuantidade_Jsonclick = "";
         edtNotaFiscalItemDescricao_Jsonclick = "";
         edtNotaFiscalItemCFOP_Jsonclick = "";
         edtNotaFiscalItemCodigo_Jsonclick = "";
         edtNotaFiscalItemCodigo_Link = "";
         edtPropostaDescricao_Jsonclick = "";
         edtNotaFiscalId_Jsonclick = "";
         edtPropostaId_Jsonclick = "";
         edtNotaFiscalItemId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavNotafiscalitemcodigo1_Jsonclick = "";
         edtavNotafiscalitemcodigo1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavNotafiscalitemcodigo2_Jsonclick = "";
         edtavNotafiscalitemcodigo2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavNotafiscalitemcodigo3_Jsonclick = "";
         edtavNotafiscalitemcodigo3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavNotafiscalitemcodigo3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavNotafiscalitemcodigo2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavNotafiscalitemcodigo1_Visible = 1;
         cmbNotaFiscalItemVendido.Enabled = 0;
         edtNotaFiscalItemValorTotal_Enabled = 0;
         edtNotaFiscalItemValorUnitario_Enabled = 0;
         edtNotaFiscalItemQuantidade_Enabled = 0;
         edtNotaFiscalItemDescricao_Enabled = 0;
         edtNotaFiscalItemCFOP_Enabled = 0;
         edtNotaFiscalItemCodigo_Enabled = 0;
         edtPropostaDescricao_Enabled = 0;
         edtNotaFiscalId_Enabled = 0;
         edtPropostaId_Enabled = 0;
         edtNotaFiscalItemId_Enabled = 0;
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
         bttBtnvenderitens_Visible = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "|||18.6|18.2|18.2|";
         Ddo_grid_Datalistproc = "NotaFiscalItemWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||||||VENDIDO:Vendido,ABERTO:Aberto,DEVOLVIDO:Devolvido";
         Ddo_grid_Allowmultipleselection = "||||||T";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic||||FixedValues";
         Ddo_grid_Includedatalist = "T|T|T||||T";
         Ddo_grid_Filterisrange = "|||T|T|T|";
         Ddo_grid_Filtertype = "Character|Character|Character|Numeric|Numeric|Numeric|";
         Ddo_grid_Includefilter = "T|T|T|T|T|T|";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4|5|6|7";
         Ddo_grid_Columnids = "3:PropostaDescricao|4:NotaFiscalItemCodigo|6:NotaFiscalItemDescricao|7:NotaFiscalItemQuantidade|8:NotaFiscalItemValorUnitario|9:NotaFiscalItemValorTotal|10:NotaFiscalItemVendido";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18NotaFiscalItemCodigo1","fld":"vNOTAFISCALITEMCODIGO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22NotaFiscalItemCodigo2","fld":"vNOTAFISCALITEMCODIGO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26NotaFiscalItemCodigo3","fld":"vNOTAFISCALITEMCODIGO3","type":"svchar"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV55NotaFiscalId","fld":"vNOTAFISCALID","type":"guid"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV36TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV37TFNotaFiscalItemCodigo","fld":"vTFNOTAFISCALITEMCODIGO","type":"svchar"},{"av":"AV38TFNotaFiscalItemCodigo_Sel","fld":"vTFNOTAFISCALITEMCODIGO_SEL","type":"svchar"},{"av":"AV39TFNotaFiscalItemDescricao","fld":"vTFNOTAFISCALITEMDESCRICAO","type":"svchar"},{"av":"AV40TFNotaFiscalItemDescricao_Sel","fld":"vTFNOTAFISCALITEMDESCRICAO_SEL","type":"svchar"},{"av":"AV41TFNotaFiscalItemQuantidade","fld":"vTFNOTAFISCALITEMQUANTIDADE","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV42TFNotaFiscalItemQuantidade_To","fld":"vTFNOTAFISCALITEMQUANTIDADE_TO","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV43TFNotaFiscalItemValorUnitario","fld":"vTFNOTAFISCALITEMVALORUNITARIO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV44TFNotaFiscalItemValorUnitario_To","fld":"vTFNOTAFISCALITEMVALORUNITARIO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFNotaFiscalItemValorTotal","fld":"vTFNOTAFISCALITEMVALORTOTAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFNotaFiscalItemValorTotal_To","fld":"vTFNOTAFISCALITEMVALORTOTAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFNotaFiscalItemVendido_Sels","fld":"vTFNOTAFISCALITEMVENDIDO_SELS","type":""},{"av":"AV56NotaFiscalStatus","fld":"vNOTAFISCALSTATUS","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"ctrl":"BTNVENDERITENS","prop":"Visible"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12932","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18NotaFiscalItemCodigo1","fld":"vNOTAFISCALITEMCODIGO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22NotaFiscalItemCodigo2","fld":"vNOTAFISCALITEMCODIGO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26NotaFiscalItemCodigo3","fld":"vNOTAFISCALITEMCODIGO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV55NotaFiscalId","fld":"vNOTAFISCALID","type":"guid"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV36TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV37TFNotaFiscalItemCodigo","fld":"vTFNOTAFISCALITEMCODIGO","type":"svchar"},{"av":"AV38TFNotaFiscalItemCodigo_Sel","fld":"vTFNOTAFISCALITEMCODIGO_SEL","type":"svchar"},{"av":"AV39TFNotaFiscalItemDescricao","fld":"vTFNOTAFISCALITEMDESCRICAO","type":"svchar"},{"av":"AV40TFNotaFiscalItemDescricao_Sel","fld":"vTFNOTAFISCALITEMDESCRICAO_SEL","type":"svchar"},{"av":"AV41TFNotaFiscalItemQuantidade","fld":"vTFNOTAFISCALITEMQUANTIDADE","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV42TFNotaFiscalItemQuantidade_To","fld":"vTFNOTAFISCALITEMQUANTIDADE_TO","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV43TFNotaFiscalItemValorUnitario","fld":"vTFNOTAFISCALITEMVALORUNITARIO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV44TFNotaFiscalItemValorUnitario_To","fld":"vTFNOTAFISCALITEMVALORUNITARIO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFNotaFiscalItemValorTotal","fld":"vTFNOTAFISCALITEMVALORTOTAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFNotaFiscalItemValorTotal_To","fld":"vTFNOTAFISCALITEMVALORTOTAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFNotaFiscalItemVendido_Sels","fld":"vTFNOTAFISCALITEMVENDIDO_SELS","type":""},{"av":"AV56NotaFiscalStatus","fld":"vNOTAFISCALSTATUS","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13932","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18NotaFiscalItemCodigo1","fld":"vNOTAFISCALITEMCODIGO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22NotaFiscalItemCodigo2","fld":"vNOTAFISCALITEMCODIGO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26NotaFiscalItemCodigo3","fld":"vNOTAFISCALITEMCODIGO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV55NotaFiscalId","fld":"vNOTAFISCALID","type":"guid"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV36TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV37TFNotaFiscalItemCodigo","fld":"vTFNOTAFISCALITEMCODIGO","type":"svchar"},{"av":"AV38TFNotaFiscalItemCodigo_Sel","fld":"vTFNOTAFISCALITEMCODIGO_SEL","type":"svchar"},{"av":"AV39TFNotaFiscalItemDescricao","fld":"vTFNOTAFISCALITEMDESCRICAO","type":"svchar"},{"av":"AV40TFNotaFiscalItemDescricao_Sel","fld":"vTFNOTAFISCALITEMDESCRICAO_SEL","type":"svchar"},{"av":"AV41TFNotaFiscalItemQuantidade","fld":"vTFNOTAFISCALITEMQUANTIDADE","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV42TFNotaFiscalItemQuantidade_To","fld":"vTFNOTAFISCALITEMQUANTIDADE_TO","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV43TFNotaFiscalItemValorUnitario","fld":"vTFNOTAFISCALITEMVALORUNITARIO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV44TFNotaFiscalItemValorUnitario_To","fld":"vTFNOTAFISCALITEMVALORUNITARIO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFNotaFiscalItemValorTotal","fld":"vTFNOTAFISCALITEMVALORTOTAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFNotaFiscalItemValorTotal_To","fld":"vTFNOTAFISCALITEMVALORTOTAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFNotaFiscalItemVendido_Sels","fld":"vTFNOTAFISCALITEMVENDIDO_SELS","type":""},{"av":"AV56NotaFiscalStatus","fld":"vNOTAFISCALSTATUS","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E14932","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18NotaFiscalItemCodigo1","fld":"vNOTAFISCALITEMCODIGO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22NotaFiscalItemCodigo2","fld":"vNOTAFISCALITEMCODIGO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26NotaFiscalItemCodigo3","fld":"vNOTAFISCALITEMCODIGO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV55NotaFiscalId","fld":"vNOTAFISCALID","type":"guid"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV36TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV37TFNotaFiscalItemCodigo","fld":"vTFNOTAFISCALITEMCODIGO","type":"svchar"},{"av":"AV38TFNotaFiscalItemCodigo_Sel","fld":"vTFNOTAFISCALITEMCODIGO_SEL","type":"svchar"},{"av":"AV39TFNotaFiscalItemDescricao","fld":"vTFNOTAFISCALITEMDESCRICAO","type":"svchar"},{"av":"AV40TFNotaFiscalItemDescricao_Sel","fld":"vTFNOTAFISCALITEMDESCRICAO_SEL","type":"svchar"},{"av":"AV41TFNotaFiscalItemQuantidade","fld":"vTFNOTAFISCALITEMQUANTIDADE","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV42TFNotaFiscalItemQuantidade_To","fld":"vTFNOTAFISCALITEMQUANTIDADE_TO","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV43TFNotaFiscalItemValorUnitario","fld":"vTFNOTAFISCALITEMVALORUNITARIO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV44TFNotaFiscalItemValorUnitario_To","fld":"vTFNOTAFISCALITEMVALORUNITARIO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFNotaFiscalItemValorTotal","fld":"vTFNOTAFISCALITEMVALORTOTAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFNotaFiscalItemValorTotal_To","fld":"vTFNOTAFISCALITEMVALORTOTAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFNotaFiscalItemVendido_Sels","fld":"vTFNOTAFISCALITEMVENDIDO_SELS","type":""},{"av":"AV56NotaFiscalStatus","fld":"vNOTAFISCALSTATUS","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV47TFNotaFiscalItemVendido_SelsJson","fld":"vTFNOTAFISCALITEMVENDIDO_SELSJSON","type":"vchar"},{"av":"AV48TFNotaFiscalItemVendido_Sels","fld":"vTFNOTAFISCALITEMVENDIDO_SELS","type":""},{"av":"AV45TFNotaFiscalItemValorTotal","fld":"vTFNOTAFISCALITEMVALORTOTAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFNotaFiscalItemValorTotal_To","fld":"vTFNOTAFISCALITEMVALORTOTAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV43TFNotaFiscalItemValorUnitario","fld":"vTFNOTAFISCALITEMVALORUNITARIO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV44TFNotaFiscalItemValorUnitario_To","fld":"vTFNOTAFISCALITEMVALORUNITARIO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFNotaFiscalItemQuantidade","fld":"vTFNOTAFISCALITEMQUANTIDADE","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV42TFNotaFiscalItemQuantidade_To","fld":"vTFNOTAFISCALITEMQUANTIDADE_TO","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV39TFNotaFiscalItemDescricao","fld":"vTFNOTAFISCALITEMDESCRICAO","type":"svchar"},{"av":"AV40TFNotaFiscalItemDescricao_Sel","fld":"vTFNOTAFISCALITEMDESCRICAO_SEL","type":"svchar"},{"av":"AV37TFNotaFiscalItemCodigo","fld":"vTFNOTAFISCALITEMCODIGO","type":"svchar"},{"av":"AV38TFNotaFiscalItemCodigo_Sel","fld":"vTFNOTAFISCALITEMCODIGO_SEL","type":"svchar"},{"av":"AV35TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV36TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E27932","iparms":[{"av":"A830NotaFiscalItemId","fld":"NOTAFISCALITEMID","type":"guid"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"edtNotaFiscalItemCodigo_Link","ctrl":"NOTAFISCALITEMCODIGO","prop":"Link"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E20932","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E15932","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18NotaFiscalItemCodigo1","fld":"vNOTAFISCALITEMCODIGO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22NotaFiscalItemCodigo2","fld":"vNOTAFISCALITEMCODIGO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26NotaFiscalItemCodigo3","fld":"vNOTAFISCALITEMCODIGO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV55NotaFiscalId","fld":"vNOTAFISCALID","type":"guid"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV36TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV37TFNotaFiscalItemCodigo","fld":"vTFNOTAFISCALITEMCODIGO","type":"svchar"},{"av":"AV38TFNotaFiscalItemCodigo_Sel","fld":"vTFNOTAFISCALITEMCODIGO_SEL","type":"svchar"},{"av":"AV39TFNotaFiscalItemDescricao","fld":"vTFNOTAFISCALITEMDESCRICAO","type":"svchar"},{"av":"AV40TFNotaFiscalItemDescricao_Sel","fld":"vTFNOTAFISCALITEMDESCRICAO_SEL","type":"svchar"},{"av":"AV41TFNotaFiscalItemQuantidade","fld":"vTFNOTAFISCALITEMQUANTIDADE","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV42TFNotaFiscalItemQuantidade_To","fld":"vTFNOTAFISCALITEMQUANTIDADE_TO","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV43TFNotaFiscalItemValorUnitario","fld":"vTFNOTAFISCALITEMVALORUNITARIO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV44TFNotaFiscalItemValorUnitario_To","fld":"vTFNOTAFISCALITEMVALORUNITARIO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFNotaFiscalItemValorTotal","fld":"vTFNOTAFISCALITEMVALORTOTAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFNotaFiscalItemValorTotal_To","fld":"vTFNOTAFISCALITEMVALORTOTAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFNotaFiscalItemVendido_Sels","fld":"vTFNOTAFISCALITEMVENDIDO_SELS","type":""},{"av":"AV56NotaFiscalStatus","fld":"vNOTAFISCALSTATUS","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22NotaFiscalItemCodigo2","fld":"vNOTAFISCALITEMCODIGO2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26NotaFiscalItemCodigo3","fld":"vNOTAFISCALITEMCODIGO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18NotaFiscalItemCodigo1","fld":"vNOTAFISCALITEMCODIGO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavNotafiscalitemcodigo2_Visible","ctrl":"vNOTAFISCALITEMCODIGO2","prop":"Visible"},{"av":"edtavNotafiscalitemcodigo3_Visible","ctrl":"vNOTAFISCALITEMCODIGO3","prop":"Visible"},{"av":"edtavNotafiscalitemcodigo1_Visible","ctrl":"vNOTAFISCALITEMCODIGO1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"ctrl":"BTNVENDERITENS","prop":"Visible"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E21932","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"edtavNotafiscalitemcodigo1_Visible","ctrl":"vNOTAFISCALITEMCODIGO1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E22932","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E16932","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18NotaFiscalItemCodigo1","fld":"vNOTAFISCALITEMCODIGO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22NotaFiscalItemCodigo2","fld":"vNOTAFISCALITEMCODIGO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26NotaFiscalItemCodigo3","fld":"vNOTAFISCALITEMCODIGO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV55NotaFiscalId","fld":"vNOTAFISCALID","type":"guid"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV36TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV37TFNotaFiscalItemCodigo","fld":"vTFNOTAFISCALITEMCODIGO","type":"svchar"},{"av":"AV38TFNotaFiscalItemCodigo_Sel","fld":"vTFNOTAFISCALITEMCODIGO_SEL","type":"svchar"},{"av":"AV39TFNotaFiscalItemDescricao","fld":"vTFNOTAFISCALITEMDESCRICAO","type":"svchar"},{"av":"AV40TFNotaFiscalItemDescricao_Sel","fld":"vTFNOTAFISCALITEMDESCRICAO_SEL","type":"svchar"},{"av":"AV41TFNotaFiscalItemQuantidade","fld":"vTFNOTAFISCALITEMQUANTIDADE","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV42TFNotaFiscalItemQuantidade_To","fld":"vTFNOTAFISCALITEMQUANTIDADE_TO","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV43TFNotaFiscalItemValorUnitario","fld":"vTFNOTAFISCALITEMVALORUNITARIO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV44TFNotaFiscalItemValorUnitario_To","fld":"vTFNOTAFISCALITEMVALORUNITARIO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFNotaFiscalItemValorTotal","fld":"vTFNOTAFISCALITEMVALORTOTAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFNotaFiscalItemValorTotal_To","fld":"vTFNOTAFISCALITEMVALORTOTAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFNotaFiscalItemVendido_Sels","fld":"vTFNOTAFISCALITEMVENDIDO_SELS","type":""},{"av":"AV56NotaFiscalStatus","fld":"vNOTAFISCALSTATUS","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22NotaFiscalItemCodigo2","fld":"vNOTAFISCALITEMCODIGO2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26NotaFiscalItemCodigo3","fld":"vNOTAFISCALITEMCODIGO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18NotaFiscalItemCodigo1","fld":"vNOTAFISCALITEMCODIGO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavNotafiscalitemcodigo2_Visible","ctrl":"vNOTAFISCALITEMCODIGO2","prop":"Visible"},{"av":"edtavNotafiscalitemcodigo3_Visible","ctrl":"vNOTAFISCALITEMCODIGO3","prop":"Visible"},{"av":"edtavNotafiscalitemcodigo1_Visible","ctrl":"vNOTAFISCALITEMCODIGO1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"ctrl":"BTNVENDERITENS","prop":"Visible"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E23932","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"edtavNotafiscalitemcodigo2_Visible","ctrl":"vNOTAFISCALITEMCODIGO2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E17932","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18NotaFiscalItemCodigo1","fld":"vNOTAFISCALITEMCODIGO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22NotaFiscalItemCodigo2","fld":"vNOTAFISCALITEMCODIGO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26NotaFiscalItemCodigo3","fld":"vNOTAFISCALITEMCODIGO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV55NotaFiscalId","fld":"vNOTAFISCALID","type":"guid"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV36TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV37TFNotaFiscalItemCodigo","fld":"vTFNOTAFISCALITEMCODIGO","type":"svchar"},{"av":"AV38TFNotaFiscalItemCodigo_Sel","fld":"vTFNOTAFISCALITEMCODIGO_SEL","type":"svchar"},{"av":"AV39TFNotaFiscalItemDescricao","fld":"vTFNOTAFISCALITEMDESCRICAO","type":"svchar"},{"av":"AV40TFNotaFiscalItemDescricao_Sel","fld":"vTFNOTAFISCALITEMDESCRICAO_SEL","type":"svchar"},{"av":"AV41TFNotaFiscalItemQuantidade","fld":"vTFNOTAFISCALITEMQUANTIDADE","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV42TFNotaFiscalItemQuantidade_To","fld":"vTFNOTAFISCALITEMQUANTIDADE_TO","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV43TFNotaFiscalItemValorUnitario","fld":"vTFNOTAFISCALITEMVALORUNITARIO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV44TFNotaFiscalItemValorUnitario_To","fld":"vTFNOTAFISCALITEMVALORUNITARIO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFNotaFiscalItemValorTotal","fld":"vTFNOTAFISCALITEMVALORTOTAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFNotaFiscalItemValorTotal_To","fld":"vTFNOTAFISCALITEMVALORTOTAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFNotaFiscalItemVendido_Sels","fld":"vTFNOTAFISCALITEMVENDIDO_SELS","type":""},{"av":"AV56NotaFiscalStatus","fld":"vNOTAFISCALSTATUS","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22NotaFiscalItemCodigo2","fld":"vNOTAFISCALITEMCODIGO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26NotaFiscalItemCodigo3","fld":"vNOTAFISCALITEMCODIGO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18NotaFiscalItemCodigo1","fld":"vNOTAFISCALITEMCODIGO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavNotafiscalitemcodigo2_Visible","ctrl":"vNOTAFISCALITEMCODIGO2","prop":"Visible"},{"av":"edtavNotafiscalitemcodigo3_Visible","ctrl":"vNOTAFISCALITEMCODIGO3","prop":"Visible"},{"av":"edtavNotafiscalitemcodigo1_Visible","ctrl":"vNOTAFISCALITEMCODIGO1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"ctrl":"BTNVENDERITENS","prop":"Visible"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E24932","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"edtavNotafiscalitemcodigo3_Visible","ctrl":"vNOTAFISCALITEMCODIGO3","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator3"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11932","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18NotaFiscalItemCodigo1","fld":"vNOTAFISCALITEMCODIGO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22NotaFiscalItemCodigo2","fld":"vNOTAFISCALITEMCODIGO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26NotaFiscalItemCodigo3","fld":"vNOTAFISCALITEMCODIGO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV55NotaFiscalId","fld":"vNOTAFISCALID","type":"guid"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV36TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV37TFNotaFiscalItemCodigo","fld":"vTFNOTAFISCALITEMCODIGO","type":"svchar"},{"av":"AV38TFNotaFiscalItemCodigo_Sel","fld":"vTFNOTAFISCALITEMCODIGO_SEL","type":"svchar"},{"av":"AV39TFNotaFiscalItemDescricao","fld":"vTFNOTAFISCALITEMDESCRICAO","type":"svchar"},{"av":"AV40TFNotaFiscalItemDescricao_Sel","fld":"vTFNOTAFISCALITEMDESCRICAO_SEL","type":"svchar"},{"av":"AV41TFNotaFiscalItemQuantidade","fld":"vTFNOTAFISCALITEMQUANTIDADE","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV42TFNotaFiscalItemQuantidade_To","fld":"vTFNOTAFISCALITEMQUANTIDADE_TO","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV43TFNotaFiscalItemValorUnitario","fld":"vTFNOTAFISCALITEMVALORUNITARIO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV44TFNotaFiscalItemValorUnitario_To","fld":"vTFNOTAFISCALITEMVALORUNITARIO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFNotaFiscalItemValorTotal","fld":"vTFNOTAFISCALITEMVALORTOTAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFNotaFiscalItemValorTotal_To","fld":"vTFNOTAFISCALITEMVALORTOTAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFNotaFiscalItemVendido_Sels","fld":"vTFNOTAFISCALITEMVENDIDO_SELS","type":""},{"av":"AV56NotaFiscalStatus","fld":"vNOTAFISCALSTATUS","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV47TFNotaFiscalItemVendido_SelsJson","fld":"vTFNOTAFISCALITEMVENDIDO_SELSJSON","type":"vchar"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV35TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV36TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV37TFNotaFiscalItemCodigo","fld":"vTFNOTAFISCALITEMCODIGO","type":"svchar"},{"av":"AV38TFNotaFiscalItemCodigo_Sel","fld":"vTFNOTAFISCALITEMCODIGO_SEL","type":"svchar"},{"av":"AV39TFNotaFiscalItemDescricao","fld":"vTFNOTAFISCALITEMDESCRICAO","type":"svchar"},{"av":"AV40TFNotaFiscalItemDescricao_Sel","fld":"vTFNOTAFISCALITEMDESCRICAO_SEL","type":"svchar"},{"av":"AV41TFNotaFiscalItemQuantidade","fld":"vTFNOTAFISCALITEMQUANTIDADE","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV42TFNotaFiscalItemQuantidade_To","fld":"vTFNOTAFISCALITEMQUANTIDADE_TO","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV43TFNotaFiscalItemValorUnitario","fld":"vTFNOTAFISCALITEMVALORUNITARIO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV44TFNotaFiscalItemValorUnitario_To","fld":"vTFNOTAFISCALITEMVALORUNITARIO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFNotaFiscalItemValorTotal","fld":"vTFNOTAFISCALITEMVALORTOTAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFNotaFiscalItemValorTotal_To","fld":"vTFNOTAFISCALITEMVALORTOTAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV48TFNotaFiscalItemVendido_Sels","fld":"vTFNOTAFISCALITEMVENDIDO_SELS","type":""},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18NotaFiscalItemCodigo1","fld":"vNOTAFISCALITEMCODIGO1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV47TFNotaFiscalItemVendido_SelsJson","fld":"vTFNOTAFISCALITEMVENDIDO_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22NotaFiscalItemCodigo2","fld":"vNOTAFISCALITEMCODIGO2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26NotaFiscalItemCodigo3","fld":"vNOTAFISCALITEMCODIGO3","type":"svchar"},{"av":"edtavNotafiscalitemcodigo1_Visible","ctrl":"vNOTAFISCALITEMCODIGO1","prop":"Visible"},{"av":"edtavNotafiscalitemcodigo2_Visible","ctrl":"vNOTAFISCALITEMCODIGO2","prop":"Visible"},{"av":"edtavNotafiscalitemcodigo3_Visible","ctrl":"vNOTAFISCALITEMCODIGO3","prop":"Visible"},{"av":"AV51GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"ctrl":"BTNVENDERITENS","prop":"Visible"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOVENDERITENS'","""{"handler":"E18932","iparms":[]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E19932","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTAID","""{"handler":"Valid_Propostaid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Notafiscalitemvendido","iparms":[]}""");
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
         wcpOAV55NotaFiscalId = Guid.Empty;
         wcpOAV56NotaFiscalStatus = "";
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
         AV18NotaFiscalItemCodigo1 = "";
         AV20DynamicFiltersSelector2 = "";
         AV22NotaFiscalItemCodigo2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26NotaFiscalItemCodigo3 = "";
         AV57Pgmname = "";
         AV35TFPropostaDescricao = "";
         AV36TFPropostaDescricao_Sel = "";
         AV37TFNotaFiscalItemCodigo = "";
         AV38TFNotaFiscalItemCodigo_Sel = "";
         AV39TFNotaFiscalItemDescricao = "";
         AV40TFNotaFiscalItemDescricao_Sel = "";
         AV48TFNotaFiscalItemVendido_Sels = new GxSimpleCollection<string>();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV32ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV53GridAppliedFilters = "";
         AV49DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV47TFNotaFiscalItemVendido_SelsJson = "";
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
         bttBtnexport_Jsonclick = "";
         bttBtnvenderitens_Jsonclick = "";
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
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A830NotaFiscalItemId = Guid.Empty;
         A794NotaFiscalId = Guid.Empty;
         A325PropostaDescricao = "";
         A831NotaFiscalItemCodigo = "";
         A833NotaFiscalItemDescricao = "";
         A851NotaFiscalItemVendido = "";
         GXDecQS = "";
         AV83Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels = new GxSimpleCollection<string>();
         lV59Notafiscalitemwwds_2_filterfulltext = "";
         lV62Notafiscalitemwwds_5_notafiscalitemcodigo1 = "";
         lV66Notafiscalitemwwds_9_notafiscalitemcodigo2 = "";
         lV70Notafiscalitemwwds_13_notafiscalitemcodigo3 = "";
         lV71Notafiscalitemwwds_14_tfpropostadescricao = "";
         lV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo = "";
         lV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao = "";
         AV59Notafiscalitemwwds_2_filterfulltext = "";
         AV60Notafiscalitemwwds_3_dynamicfiltersselector1 = "";
         AV62Notafiscalitemwwds_5_notafiscalitemcodigo1 = "";
         AV64Notafiscalitemwwds_7_dynamicfiltersselector2 = "";
         AV66Notafiscalitemwwds_9_notafiscalitemcodigo2 = "";
         AV68Notafiscalitemwwds_11_dynamicfiltersselector3 = "";
         AV70Notafiscalitemwwds_13_notafiscalitemcodigo3 = "";
         AV72Notafiscalitemwwds_15_tfpropostadescricao_sel = "";
         AV71Notafiscalitemwwds_14_tfpropostadescricao = "";
         AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel = "";
         AV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo = "";
         AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel = "";
         AV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao = "";
         AV58Notafiscalitemwwds_1_notafiscalid = Guid.Empty;
         H00932_A851NotaFiscalItemVendido = new string[] {""} ;
         H00932_n851NotaFiscalItemVendido = new bool[] {false} ;
         H00932_A839NotaFiscalItemValorTotal = new decimal[1] ;
         H00932_n839NotaFiscalItemValorTotal = new bool[] {false} ;
         H00932_A838NotaFiscalItemValorUnitario = new decimal[1] ;
         H00932_n838NotaFiscalItemValorUnitario = new bool[] {false} ;
         H00932_A837NotaFiscalItemQuantidade = new decimal[1] ;
         H00932_n837NotaFiscalItemQuantidade = new bool[] {false} ;
         H00932_A833NotaFiscalItemDescricao = new string[] {""} ;
         H00932_n833NotaFiscalItemDescricao = new bool[] {false} ;
         H00932_A832NotaFiscalItemCFOP = new short[1] ;
         H00932_n832NotaFiscalItemCFOP = new bool[] {false} ;
         H00932_A831NotaFiscalItemCodigo = new string[] {""} ;
         H00932_n831NotaFiscalItemCodigo = new bool[] {false} ;
         H00932_A325PropostaDescricao = new string[] {""} ;
         H00932_n325PropostaDescricao = new bool[] {false} ;
         H00932_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         H00932_n794NotaFiscalId = new bool[] {false} ;
         H00932_A323PropostaId = new int[1] ;
         H00932_n323PropostaId = new bool[] {false} ;
         H00932_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         H00933_AGRID_nRecordCount = new long[1] ;
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
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV54AuxText = "";
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
         sCtrlAV55NotaFiscalId = "";
         sCtrlAV56NotaFiscalStatus = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.notafiscalitemww__default(),
            new Object[][] {
                new Object[] {
               H00932_A851NotaFiscalItemVendido, H00932_n851NotaFiscalItemVendido, H00932_A839NotaFiscalItemValorTotal, H00932_n839NotaFiscalItemValorTotal, H00932_A838NotaFiscalItemValorUnitario, H00932_n838NotaFiscalItemValorUnitario, H00932_A837NotaFiscalItemQuantidade, H00932_n837NotaFiscalItemQuantidade, H00932_A833NotaFiscalItemDescricao, H00932_n833NotaFiscalItemDescricao,
               H00932_A832NotaFiscalItemCFOP, H00932_n832NotaFiscalItemCFOP, H00932_A831NotaFiscalItemCodigo, H00932_n831NotaFiscalItemCodigo, H00932_A325PropostaDescricao, H00932_n325PropostaDescricao, H00932_A794NotaFiscalId, H00932_n794NotaFiscalId, H00932_A323PropostaId, H00932_n323PropostaId,
               H00932_A830NotaFiscalItemId
               }
               , new Object[] {
               H00933_AGRID_nRecordCount
               }
            }
         );
         AV57Pgmname = "NotaFiscalItemWW";
         /* GeneXus formulas. */
         AV57Pgmname = "NotaFiscalItemWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV34ManageFiltersExecutionStep ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short A832NotaFiscalItemCFOP ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV61Notafiscalitemwwds_4_dynamicfiltersoperator1 ;
      private short AV65Notafiscalitemwwds_8_dynamicfiltersoperator2 ;
      private short AV69Notafiscalitemwwds_12_dynamicfiltersoperator3 ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_107 ;
      private int nGXsfl_107_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtnvenderitens_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int A323PropostaId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV83Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels_Count ;
      private int edtNotaFiscalItemId_Enabled ;
      private int edtPropostaId_Enabled ;
      private int edtNotaFiscalId_Enabled ;
      private int edtPropostaDescricao_Enabled ;
      private int edtNotaFiscalItemCodigo_Enabled ;
      private int edtNotaFiscalItemCFOP_Enabled ;
      private int edtNotaFiscalItemDescricao_Enabled ;
      private int edtNotaFiscalItemQuantidade_Enabled ;
      private int edtNotaFiscalItemValorUnitario_Enabled ;
      private int edtNotaFiscalItemValorTotal_Enabled ;
      private int AV50PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavNotafiscalitemcodigo1_Visible ;
      private int edtavNotafiscalitemcodigo2_Visible ;
      private int edtavNotafiscalitemcodigo3_Visible ;
      private int AV84GXV1 ;
      private int edtavNotafiscalitemcodigo3_Enabled ;
      private int edtavNotafiscalitemcodigo2_Enabled ;
      private int edtavNotafiscalitemcodigo1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV51GridCurrentPage ;
      private long AV52GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV41TFNotaFiscalItemQuantidade ;
      private decimal AV42TFNotaFiscalItemQuantidade_To ;
      private decimal AV43TFNotaFiscalItemValorUnitario ;
      private decimal AV44TFNotaFiscalItemValorUnitario_To ;
      private decimal AV45TFNotaFiscalItemValorTotal ;
      private decimal AV46TFNotaFiscalItemValorTotal_To ;
      private decimal A837NotaFiscalItemQuantidade ;
      private decimal A838NotaFiscalItemValorUnitario ;
      private decimal A839NotaFiscalItemValorTotal ;
      private decimal AV77Notafiscalitemwwds_20_tfnotafiscalitemquantidade ;
      private decimal AV78Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to ;
      private decimal AV79Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario ;
      private decimal AV80Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to ;
      private decimal AV81Notafiscalitemwwds_24_tfnotafiscalitemvalortotal ;
      private decimal AV82Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to ;
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
      private string sGXsfl_107_idx="0001" ;
      private string AV57Pgmname ;
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
      private string divLayoutmaintable_Internalname ;
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
      private string bttBtnvenderitens_Internalname ;
      private string bttBtnvenderitens_Jsonclick ;
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
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtNotaFiscalItemId_Internalname ;
      private string edtPropostaId_Internalname ;
      private string edtNotaFiscalId_Internalname ;
      private string edtPropostaDescricao_Internalname ;
      private string edtNotaFiscalItemCodigo_Internalname ;
      private string edtNotaFiscalItemCFOP_Internalname ;
      private string edtNotaFiscalItemDescricao_Internalname ;
      private string edtNotaFiscalItemQuantidade_Internalname ;
      private string edtNotaFiscalItemValorUnitario_Internalname ;
      private string edtNotaFiscalItemValorTotal_Internalname ;
      private string cmbNotaFiscalItemVendido_Internalname ;
      private string GXDecQS ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavNotafiscalitemcodigo1_Internalname ;
      private string edtavNotafiscalitemcodigo2_Internalname ;
      private string edtavNotafiscalitemcodigo3_Internalname ;
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
      private string edtNotaFiscalItemCodigo_Link ;
      private string GXt_char2 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_notafiscalitemcodigo3_cell_Internalname ;
      private string edtavNotafiscalitemcodigo3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_notafiscalitemcodigo2_cell_Internalname ;
      private string edtavNotafiscalitemcodigo2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_notafiscalitemcodigo1_cell_Internalname ;
      private string edtavNotafiscalitemcodigo1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sCtrlAV55NotaFiscalId ;
      private string sCtrlAV56NotaFiscalStatus ;
      private string sGXsfl_107_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtNotaFiscalItemId_Jsonclick ;
      private string edtPropostaId_Jsonclick ;
      private string edtNotaFiscalId_Jsonclick ;
      private string edtPropostaDescricao_Jsonclick ;
      private string edtNotaFiscalItemCodigo_Jsonclick ;
      private string edtNotaFiscalItemCFOP_Jsonclick ;
      private string edtNotaFiscalItemDescricao_Jsonclick ;
      private string edtNotaFiscalItemQuantidade_Jsonclick ;
      private string edtNotaFiscalItemValorUnitario_Jsonclick ;
      private string edtNotaFiscalItemValorTotal_Jsonclick ;
      private string GXCCtl ;
      private string cmbNotaFiscalItemVendido_Jsonclick ;
      private string subGrid_Header ;
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
      private bool n323PropostaId ;
      private bool n794NotaFiscalId ;
      private bool n325PropostaDescricao ;
      private bool n831NotaFiscalItemCodigo ;
      private bool n832NotaFiscalItemCFOP ;
      private bool n833NotaFiscalItemDescricao ;
      private bool n837NotaFiscalItemQuantidade ;
      private bool n838NotaFiscalItemValorUnitario ;
      private bool n839NotaFiscalItemValorTotal ;
      private bool n851NotaFiscalItemVendido ;
      private bool bGXsfl_107_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV63Notafiscalitemwwds_6_dynamicfiltersenabled2 ;
      private bool AV67Notafiscalitemwwds_10_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV47TFNotaFiscalItemVendido_SelsJson ;
      private string AV33ManageFiltersXml ;
      private string AV56NotaFiscalStatus ;
      private string wcpOAV56NotaFiscalStatus ;
      private string AV15FilterFullText ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV18NotaFiscalItemCodigo1 ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV22NotaFiscalItemCodigo2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV26NotaFiscalItemCodigo3 ;
      private string AV35TFPropostaDescricao ;
      private string AV36TFPropostaDescricao_Sel ;
      private string AV37TFNotaFiscalItemCodigo ;
      private string AV38TFNotaFiscalItemCodigo_Sel ;
      private string AV39TFNotaFiscalItemDescricao ;
      private string AV40TFNotaFiscalItemDescricao_Sel ;
      private string AV53GridAppliedFilters ;
      private string A325PropostaDescricao ;
      private string A831NotaFiscalItemCodigo ;
      private string A833NotaFiscalItemDescricao ;
      private string A851NotaFiscalItemVendido ;
      private string lV59Notafiscalitemwwds_2_filterfulltext ;
      private string lV62Notafiscalitemwwds_5_notafiscalitemcodigo1 ;
      private string lV66Notafiscalitemwwds_9_notafiscalitemcodigo2 ;
      private string lV70Notafiscalitemwwds_13_notafiscalitemcodigo3 ;
      private string lV71Notafiscalitemwwds_14_tfpropostadescricao ;
      private string lV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo ;
      private string lV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao ;
      private string AV59Notafiscalitemwwds_2_filterfulltext ;
      private string AV60Notafiscalitemwwds_3_dynamicfiltersselector1 ;
      private string AV62Notafiscalitemwwds_5_notafiscalitemcodigo1 ;
      private string AV64Notafiscalitemwwds_7_dynamicfiltersselector2 ;
      private string AV66Notafiscalitemwwds_9_notafiscalitemcodigo2 ;
      private string AV68Notafiscalitemwwds_11_dynamicfiltersselector3 ;
      private string AV70Notafiscalitemwwds_13_notafiscalitemcodigo3 ;
      private string AV72Notafiscalitemwwds_15_tfpropostadescricao_sel ;
      private string AV71Notafiscalitemwwds_14_tfpropostadescricao ;
      private string AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel ;
      private string AV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo ;
      private string AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel ;
      private string AV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao ;
      private string AV29ExcelFilename ;
      private string AV30ErrorMessage ;
      private string AV54AuxText ;
      private Guid AV55NotaFiscalId ;
      private Guid wcpOAV55NotaFiscalId ;
      private Guid A830NotaFiscalItemId ;
      private Guid A794NotaFiscalId ;
      private Guid AV58Notafiscalitemwwds_1_notafiscalid ;
      private IGxSession AV31Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbNotaFiscalItemVendido ;
      private GxSimpleCollection<string> AV48TFNotaFiscalItemVendido_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV32ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV49DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV83Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels ;
      private IDataStoreProvider pr_default ;
      private string[] H00932_A851NotaFiscalItemVendido ;
      private bool[] H00932_n851NotaFiscalItemVendido ;
      private decimal[] H00932_A839NotaFiscalItemValorTotal ;
      private bool[] H00932_n839NotaFiscalItemValorTotal ;
      private decimal[] H00932_A838NotaFiscalItemValorUnitario ;
      private bool[] H00932_n838NotaFiscalItemValorUnitario ;
      private decimal[] H00932_A837NotaFiscalItemQuantidade ;
      private bool[] H00932_n837NotaFiscalItemQuantidade ;
      private string[] H00932_A833NotaFiscalItemDescricao ;
      private bool[] H00932_n833NotaFiscalItemDescricao ;
      private short[] H00932_A832NotaFiscalItemCFOP ;
      private bool[] H00932_n832NotaFiscalItemCFOP ;
      private string[] H00932_A831NotaFiscalItemCodigo ;
      private bool[] H00932_n831NotaFiscalItemCodigo ;
      private string[] H00932_A325PropostaDescricao ;
      private bool[] H00932_n325PropostaDescricao ;
      private Guid[] H00932_A794NotaFiscalId ;
      private bool[] H00932_n794NotaFiscalId ;
      private int[] H00932_A323PropostaId ;
      private bool[] H00932_n323PropostaId ;
      private Guid[] H00932_A830NotaFiscalItemId ;
      private long[] H00933_AGRID_nRecordCount ;
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

   public class notafiscalitemww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00932( IGxContext context ,
                                             string A851NotaFiscalItemVendido ,
                                             GxSimpleCollection<string> AV83Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels ,
                                             string AV59Notafiscalitemwwds_2_filterfulltext ,
                                             string AV60Notafiscalitemwwds_3_dynamicfiltersselector1 ,
                                             short AV61Notafiscalitemwwds_4_dynamicfiltersoperator1 ,
                                             string AV62Notafiscalitemwwds_5_notafiscalitemcodigo1 ,
                                             bool AV63Notafiscalitemwwds_6_dynamicfiltersenabled2 ,
                                             string AV64Notafiscalitemwwds_7_dynamicfiltersselector2 ,
                                             short AV65Notafiscalitemwwds_8_dynamicfiltersoperator2 ,
                                             string AV66Notafiscalitemwwds_9_notafiscalitemcodigo2 ,
                                             bool AV67Notafiscalitemwwds_10_dynamicfiltersenabled3 ,
                                             string AV68Notafiscalitemwwds_11_dynamicfiltersselector3 ,
                                             short AV69Notafiscalitemwwds_12_dynamicfiltersoperator3 ,
                                             string AV70Notafiscalitemwwds_13_notafiscalitemcodigo3 ,
                                             string AV72Notafiscalitemwwds_15_tfpropostadescricao_sel ,
                                             string AV71Notafiscalitemwwds_14_tfpropostadescricao ,
                                             string AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel ,
                                             string AV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo ,
                                             string AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel ,
                                             string AV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao ,
                                             decimal AV77Notafiscalitemwwds_20_tfnotafiscalitemquantidade ,
                                             decimal AV78Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to ,
                                             decimal AV79Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario ,
                                             decimal AV80Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to ,
                                             decimal AV81Notafiscalitemwwds_24_tfnotafiscalitemvalortotal ,
                                             decimal AV82Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to ,
                                             int AV83Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels_Count ,
                                             string A325PropostaDescricao ,
                                             string A831NotaFiscalItemCodigo ,
                                             string A833NotaFiscalItemDescricao ,
                                             decimal A837NotaFiscalItemQuantidade ,
                                             decimal A838NotaFiscalItemValorUnitario ,
                                             decimal A839NotaFiscalItemValorTotal ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             Guid A794NotaFiscalId ,
                                             Guid AV58Notafiscalitemwwds_1_notafiscalid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[31];
         Object[] GXv_Object8 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.NotaFiscalItemVendido, T1.NotaFiscalItemValorTotal, T1.NotaFiscalItemValorUnitario, T1.NotaFiscalItemQuantidade, T1.NotaFiscalItemDescricao, T1.NotaFiscalItemCFOP, T1.NotaFiscalItemCodigo, T2.PropostaDescricao, T1.NotaFiscalId, T1.PropostaId, T1.NotaFiscalItemId";
         sFromString = " FROM (NotaFiscalItem T1 LEFT JOIN Proposta T2 ON T2.PropostaId = T1.PropostaId)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.NotaFiscalId = :AV58Notafiscalitemwwds_1_notafiscalid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Notafiscalitemwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.PropostaDescricao like '%' || :lV59Notafiscalitemwwds_2_filterfulltext) or ( T1.NotaFiscalItemCodigo like '%' || :lV59Notafiscalitemwwds_2_filterfulltext) or ( T1.NotaFiscalItemDescricao like '%' || :lV59Notafiscalitemwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NotaFiscalItemQuantidade,'99999999990.999999'), 2) like '%' || :lV59Notafiscalitemwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NotaFiscalItemValorUnitario,'999999999999990.99'), 2) like '%' || :lV59Notafiscalitemwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NotaFiscalItemValorTotal,'999999999999990.99'), 2) like '%' || :lV59Notafiscalitemwwds_2_filterfulltext) or ( 'vendido' like '%' || LOWER(:lV59Notafiscalitemwwds_2_filterfulltext) and T1.NotaFiscalItemVendido = ( 'VENDIDO')) or ( 'aberto' like '%' || LOWER(:lV59Notafiscalitemwwds_2_filterfulltext) and T1.NotaFiscalItemVendido = ( 'ABERTO')) or ( 'devolvido' like '%' || LOWER(:lV59Notafiscalitemwwds_2_filterfulltext) and T1.NotaFiscalItemVendido = ( 'DEVOLVIDO')))");
         }
         else
         {
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
            GXv_int7[7] = 1;
            GXv_int7[8] = 1;
            GXv_int7[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Notafiscalitemwwds_3_dynamicfiltersselector1, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV61Notafiscalitemwwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Notafiscalitemwwds_5_notafiscalitemcodigo1)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV62Notafiscalitemwwds_5_notafiscalitemcodigo1)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Notafiscalitemwwds_3_dynamicfiltersselector1, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV61Notafiscalitemwwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Notafiscalitemwwds_5_notafiscalitemcodigo1)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like '%' || :lV62Notafiscalitemwwds_5_notafiscalitemcodigo1)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( AV63Notafiscalitemwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Notafiscalitemwwds_7_dynamicfiltersselector2, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV65Notafiscalitemwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Notafiscalitemwwds_9_notafiscalitemcodigo2)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV66Notafiscalitemwwds_9_notafiscalitemcodigo2)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( AV63Notafiscalitemwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Notafiscalitemwwds_7_dynamicfiltersselector2, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV65Notafiscalitemwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Notafiscalitemwwds_9_notafiscalitemcodigo2)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like '%' || :lV66Notafiscalitemwwds_9_notafiscalitemcodigo2)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( AV67Notafiscalitemwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Notafiscalitemwwds_11_dynamicfiltersselector3, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV69Notafiscalitemwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Notafiscalitemwwds_13_notafiscalitemcodigo3)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV70Notafiscalitemwwds_13_notafiscalitemcodigo3)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( AV67Notafiscalitemwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Notafiscalitemwwds_11_dynamicfiltersselector3, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV69Notafiscalitemwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Notafiscalitemwwds_13_notafiscalitemcodigo3)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like '%' || :lV70Notafiscalitemwwds_13_notafiscalitemcodigo3)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Notafiscalitemwwds_15_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Notafiscalitemwwds_14_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.PropostaDescricao like :lV71Notafiscalitemwwds_14_tfpropostadescricao)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Notafiscalitemwwds_15_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV72Notafiscalitemwwds_15_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.PropostaDescricao = ( :AV72Notafiscalitemwwds_15_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( StringUtil.StrCmp(AV72Notafiscalitemwwds_15_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.PropostaDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel)) && ! ( StringUtil.StrCmp(AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo = ( :AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel))");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( StringUtil.StrCmp(AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalItemCodigo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao like :lV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel)) && ! ( StringUtil.StrCmp(AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao = ( :AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel))");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( StringUtil.StrCmp(AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalItemDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV77Notafiscalitemwwds_20_tfnotafiscalitemquantidade) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemQuantidade >= :AV77Notafiscalitemwwds_20_tfnotafiscalitemquantidade)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV78Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemQuantidade <= :AV78Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV79Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorUnitario >= :AV79Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV80Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorUnitario <= :AV80Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV81Notafiscalitemwwds_24_tfnotafiscalitemvalortotal) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorTotal >= :AV81Notafiscalitemwwds_24_tfnotafiscalitemvalortotal)");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV82Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorTotal <= :AV82Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to)");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         if ( AV83Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV83Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels, "T1.NotaFiscalItemVendido IN (", ")")+")");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NotaFiscalId, T1.NotaFiscalItemCodigo, T1.NotaFiscalItemId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NotaFiscalId DESC, T1.NotaFiscalItemCodigo DESC, T1.NotaFiscalItemId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NotaFiscalId, T2.PropostaDescricao, T1.NotaFiscalItemId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NotaFiscalId DESC, T2.PropostaDescricao DESC, T1.NotaFiscalItemId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NotaFiscalId, T1.NotaFiscalItemDescricao, T1.NotaFiscalItemId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NotaFiscalId DESC, T1.NotaFiscalItemDescricao DESC, T1.NotaFiscalItemId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NotaFiscalId, T1.NotaFiscalItemQuantidade, T1.NotaFiscalItemId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NotaFiscalId DESC, T1.NotaFiscalItemQuantidade DESC, T1.NotaFiscalItemId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NotaFiscalId, T1.NotaFiscalItemValorUnitario, T1.NotaFiscalItemId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NotaFiscalId DESC, T1.NotaFiscalItemValorUnitario DESC, T1.NotaFiscalItemId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NotaFiscalId, T1.NotaFiscalItemValorTotal, T1.NotaFiscalItemId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NotaFiscalId DESC, T1.NotaFiscalItemValorTotal DESC, T1.NotaFiscalItemId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NotaFiscalId, T1.NotaFiscalItemVendido, T1.NotaFiscalItemId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NotaFiscalId DESC, T1.NotaFiscalItemVendido DESC, T1.NotaFiscalItemId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.NotaFiscalItemId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H00933( IGxContext context ,
                                             string A851NotaFiscalItemVendido ,
                                             GxSimpleCollection<string> AV83Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels ,
                                             string AV59Notafiscalitemwwds_2_filterfulltext ,
                                             string AV60Notafiscalitemwwds_3_dynamicfiltersselector1 ,
                                             short AV61Notafiscalitemwwds_4_dynamicfiltersoperator1 ,
                                             string AV62Notafiscalitemwwds_5_notafiscalitemcodigo1 ,
                                             bool AV63Notafiscalitemwwds_6_dynamicfiltersenabled2 ,
                                             string AV64Notafiscalitemwwds_7_dynamicfiltersselector2 ,
                                             short AV65Notafiscalitemwwds_8_dynamicfiltersoperator2 ,
                                             string AV66Notafiscalitemwwds_9_notafiscalitemcodigo2 ,
                                             bool AV67Notafiscalitemwwds_10_dynamicfiltersenabled3 ,
                                             string AV68Notafiscalitemwwds_11_dynamicfiltersselector3 ,
                                             short AV69Notafiscalitemwwds_12_dynamicfiltersoperator3 ,
                                             string AV70Notafiscalitemwwds_13_notafiscalitemcodigo3 ,
                                             string AV72Notafiscalitemwwds_15_tfpropostadescricao_sel ,
                                             string AV71Notafiscalitemwwds_14_tfpropostadescricao ,
                                             string AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel ,
                                             string AV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo ,
                                             string AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel ,
                                             string AV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao ,
                                             decimal AV77Notafiscalitemwwds_20_tfnotafiscalitemquantidade ,
                                             decimal AV78Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to ,
                                             decimal AV79Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario ,
                                             decimal AV80Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to ,
                                             decimal AV81Notafiscalitemwwds_24_tfnotafiscalitemvalortotal ,
                                             decimal AV82Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to ,
                                             int AV83Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels_Count ,
                                             string A325PropostaDescricao ,
                                             string A831NotaFiscalItemCodigo ,
                                             string A833NotaFiscalItemDescricao ,
                                             decimal A837NotaFiscalItemQuantidade ,
                                             decimal A838NotaFiscalItemValorUnitario ,
                                             decimal A839NotaFiscalItemValorTotal ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             Guid A794NotaFiscalId ,
                                             Guid AV58Notafiscalitemwwds_1_notafiscalid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[28];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (NotaFiscalItem T1 LEFT JOIN Proposta T2 ON T2.PropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "(T1.NotaFiscalId = :AV58Notafiscalitemwwds_1_notafiscalid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Notafiscalitemwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.PropostaDescricao like '%' || :lV59Notafiscalitemwwds_2_filterfulltext) or ( T1.NotaFiscalItemCodigo like '%' || :lV59Notafiscalitemwwds_2_filterfulltext) or ( T1.NotaFiscalItemDescricao like '%' || :lV59Notafiscalitemwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NotaFiscalItemQuantidade,'99999999990.999999'), 2) like '%' || :lV59Notafiscalitemwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NotaFiscalItemValorUnitario,'999999999999990.99'), 2) like '%' || :lV59Notafiscalitemwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NotaFiscalItemValorTotal,'999999999999990.99'), 2) like '%' || :lV59Notafiscalitemwwds_2_filterfulltext) or ( 'vendido' like '%' || LOWER(:lV59Notafiscalitemwwds_2_filterfulltext) and T1.NotaFiscalItemVendido = ( 'VENDIDO')) or ( 'aberto' like '%' || LOWER(:lV59Notafiscalitemwwds_2_filterfulltext) and T1.NotaFiscalItemVendido = ( 'ABERTO')) or ( 'devolvido' like '%' || LOWER(:lV59Notafiscalitemwwds_2_filterfulltext) and T1.NotaFiscalItemVendido = ( 'DEVOLVIDO')))");
         }
         else
         {
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
            GXv_int9[5] = 1;
            GXv_int9[6] = 1;
            GXv_int9[7] = 1;
            GXv_int9[8] = 1;
            GXv_int9[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Notafiscalitemwwds_3_dynamicfiltersselector1, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV61Notafiscalitemwwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Notafiscalitemwwds_5_notafiscalitemcodigo1)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV62Notafiscalitemwwds_5_notafiscalitemcodigo1)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Notafiscalitemwwds_3_dynamicfiltersselector1, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV61Notafiscalitemwwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Notafiscalitemwwds_5_notafiscalitemcodigo1)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like '%' || :lV62Notafiscalitemwwds_5_notafiscalitemcodigo1)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( AV63Notafiscalitemwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Notafiscalitemwwds_7_dynamicfiltersselector2, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV65Notafiscalitemwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Notafiscalitemwwds_9_notafiscalitemcodigo2)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV66Notafiscalitemwwds_9_notafiscalitemcodigo2)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( AV63Notafiscalitemwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Notafiscalitemwwds_7_dynamicfiltersselector2, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV65Notafiscalitemwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Notafiscalitemwwds_9_notafiscalitemcodigo2)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like '%' || :lV66Notafiscalitemwwds_9_notafiscalitemcodigo2)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( AV67Notafiscalitemwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Notafiscalitemwwds_11_dynamicfiltersselector3, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV69Notafiscalitemwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Notafiscalitemwwds_13_notafiscalitemcodigo3)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV70Notafiscalitemwwds_13_notafiscalitemcodigo3)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( AV67Notafiscalitemwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Notafiscalitemwwds_11_dynamicfiltersselector3, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV69Notafiscalitemwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Notafiscalitemwwds_13_notafiscalitemcodigo3)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like '%' || :lV70Notafiscalitemwwds_13_notafiscalitemcodigo3)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Notafiscalitemwwds_15_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Notafiscalitemwwds_14_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.PropostaDescricao like :lV71Notafiscalitemwwds_14_tfpropostadescricao)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Notafiscalitemwwds_15_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV72Notafiscalitemwwds_15_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.PropostaDescricao = ( :AV72Notafiscalitemwwds_15_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( StringUtil.StrCmp(AV72Notafiscalitemwwds_15_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.PropostaDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel)) && ! ( StringUtil.StrCmp(AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo = ( :AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel))");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( StringUtil.StrCmp(AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalItemCodigo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao like :lV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel)) && ! ( StringUtil.StrCmp(AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao = ( :AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel))");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( StringUtil.StrCmp(AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalItemDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV77Notafiscalitemwwds_20_tfnotafiscalitemquantidade) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemQuantidade >= :AV77Notafiscalitemwwds_20_tfnotafiscalitemquantidade)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV78Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemQuantidade <= :AV78Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to)");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV79Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorUnitario >= :AV79Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario)");
         }
         else
         {
            GXv_int9[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV80Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorUnitario <= :AV80Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to)");
         }
         else
         {
            GXv_int9[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV81Notafiscalitemwwds_24_tfnotafiscalitemvalortotal) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorTotal >= :AV81Notafiscalitemwwds_24_tfnotafiscalitemvalortotal)");
         }
         else
         {
            GXv_int9[26] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV82Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorTotal <= :AV82Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to)");
         }
         else
         {
            GXv_int9[27] = 1;
         }
         if ( AV83Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV83Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels, "T1.NotaFiscalItemVendido IN (", ")")+")");
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
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00932(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (decimal)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (decimal)dynConstraints[31] , (decimal)dynConstraints[32] , (short)dynConstraints[33] , (bool)dynConstraints[34] , (Guid)dynConstraints[35] , (Guid)dynConstraints[36] );
               case 1 :
                     return conditional_H00933(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (decimal)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (decimal)dynConstraints[31] , (decimal)dynConstraints[32] , (short)dynConstraints[33] , (bool)dynConstraints[34] , (Guid)dynConstraints[35] , (Guid)dynConstraints[36] );
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
          Object[] prmH00932;
          prmH00932 = new Object[] {
          new ParDef("AV58Notafiscalitemwwds_1_notafiscalid",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV59Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Notafiscalitemwwds_5_notafiscalitemcodigo1",GXType.VarChar,60,0) ,
          new ParDef("lV62Notafiscalitemwwds_5_notafiscalitemcodigo1",GXType.VarChar,60,0) ,
          new ParDef("lV66Notafiscalitemwwds_9_notafiscalitemcodigo2",GXType.VarChar,60,0) ,
          new ParDef("lV66Notafiscalitemwwds_9_notafiscalitemcodigo2",GXType.VarChar,60,0) ,
          new ParDef("lV70Notafiscalitemwwds_13_notafiscalitemcodigo3",GXType.VarChar,60,0) ,
          new ParDef("lV70Notafiscalitemwwds_13_notafiscalitemcodigo3",GXType.VarChar,60,0) ,
          new ParDef("lV71Notafiscalitemwwds_14_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV72Notafiscalitemwwds_15_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("lV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo",GXType.VarChar,60,0) ,
          new ParDef("AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel",GXType.VarChar,60,0) ,
          new ParDef("lV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao",GXType.VarChar,255,0) ,
          new ParDef("AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel",GXType.VarChar,255,0) ,
          new ParDef("AV77Notafiscalitemwwds_20_tfnotafiscalitemquantidade",GXType.Number,18,6) ,
          new ParDef("AV78Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to",GXType.Number,18,6) ,
          new ParDef("AV79Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario",GXType.Number,18,2) ,
          new ParDef("AV80Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to",GXType.Number,18,2) ,
          new ParDef("AV81Notafiscalitemwwds_24_tfnotafiscalitemvalortotal",GXType.Number,18,2) ,
          new ParDef("AV82Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to",GXType.Number,18,2) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00933;
          prmH00933 = new Object[] {
          new ParDef("AV58Notafiscalitemwwds_1_notafiscalid",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV59Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Notafiscalitemwwds_5_notafiscalitemcodigo1",GXType.VarChar,60,0) ,
          new ParDef("lV62Notafiscalitemwwds_5_notafiscalitemcodigo1",GXType.VarChar,60,0) ,
          new ParDef("lV66Notafiscalitemwwds_9_notafiscalitemcodigo2",GXType.VarChar,60,0) ,
          new ParDef("lV66Notafiscalitemwwds_9_notafiscalitemcodigo2",GXType.VarChar,60,0) ,
          new ParDef("lV70Notafiscalitemwwds_13_notafiscalitemcodigo3",GXType.VarChar,60,0) ,
          new ParDef("lV70Notafiscalitemwwds_13_notafiscalitemcodigo3",GXType.VarChar,60,0) ,
          new ParDef("lV71Notafiscalitemwwds_14_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV72Notafiscalitemwwds_15_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("lV73Notafiscalitemwwds_16_tfnotafiscalitemcodigo",GXType.VarChar,60,0) ,
          new ParDef("AV74Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel",GXType.VarChar,60,0) ,
          new ParDef("lV75Notafiscalitemwwds_18_tfnotafiscalitemdescricao",GXType.VarChar,255,0) ,
          new ParDef("AV76Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel",GXType.VarChar,255,0) ,
          new ParDef("AV77Notafiscalitemwwds_20_tfnotafiscalitemquantidade",GXType.Number,18,6) ,
          new ParDef("AV78Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to",GXType.Number,18,6) ,
          new ParDef("AV79Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario",GXType.Number,18,2) ,
          new ParDef("AV80Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to",GXType.Number,18,2) ,
          new ParDef("AV81Notafiscalitemwwds_24_tfnotafiscalitemvalortotal",GXType.Number,18,2) ,
          new ParDef("AV82Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to",GXType.Number,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("H00932", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00932,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00933", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00933,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((short[]) buf[10])[0] = rslt.getShort(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((Guid[]) buf[16])[0] = rslt.getGuid(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((Guid[]) buf[20])[0] = rslt.getGuid(11);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
