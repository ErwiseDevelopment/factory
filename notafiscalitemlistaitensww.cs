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
   public class notafiscalitemlistaitensww : GXWebComponent
   {
      public notafiscalitemlistaitensww( )
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

      public notafiscalitemlistaitensww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PropostaId )
      {
         this.AV28PropostaId = aP0_PropostaId;
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
               gxfirstwebparm = GetFirstPar( "PropostaId");
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
                  AV28PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV28PropostaId", StringUtil.LTrimStr( (decimal)(AV28PropostaId), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)AV28PropostaId});
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
                  gxfirstwebparm = GetFirstPar( "PropostaId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "PropostaId");
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
         AV28PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
         AV15TFNotaFiscalNumero = GetPar( "TFNotaFiscalNumero");
         AV16TFNotaFiscalNumero_Sel = GetPar( "TFNotaFiscalNumero_Sel");
         AV17TFNotaFiscalItemCodigo = GetPar( "TFNotaFiscalItemCodigo");
         AV18TFNotaFiscalItemCodigo_Sel = GetPar( "TFNotaFiscalItemCodigo_Sel");
         AV19TFNotaFiscalItemDescricao = GetPar( "TFNotaFiscalItemDescricao");
         AV20TFNotaFiscalItemDescricao_Sel = GetPar( "TFNotaFiscalItemDescricao_Sel");
         AV21TFNotaFiscalItemQuantidade = NumberUtil.Val( GetPar( "TFNotaFiscalItemQuantidade"), ".");
         AV22TFNotaFiscalItemQuantidade_To = NumberUtil.Val( GetPar( "TFNotaFiscalItemQuantidade_To"), ".");
         AV23TFNotaFiscalItemValorUnitario = NumberUtil.Val( GetPar( "TFNotaFiscalItemValorUnitario"), ".");
         AV24TFNotaFiscalItemValorUnitario_To = NumberUtil.Val( GetPar( "TFNotaFiscalItemValorUnitario_To"), ".");
         AV25TFNotaFiscalItemValorTotal = NumberUtil.Val( GetPar( "TFNotaFiscalItemValorTotal"), ".");
         AV26TFNotaFiscalItemValorTotal_To = NumberUtil.Val( GetPar( "TFNotaFiscalItemValorTotal_To"), ".");
         AV42Pgmname = GetPar( "Pgmname");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV28PropostaId, AV15TFNotaFiscalNumero, AV16TFNotaFiscalNumero_Sel, AV17TFNotaFiscalItemCodigo, AV18TFNotaFiscalItemCodigo_Sel, AV19TFNotaFiscalItemDescricao, AV20TFNotaFiscalItemDescricao_Sel, AV21TFNotaFiscalItemQuantidade, AV22TFNotaFiscalItemQuantidade_To, AV23TFNotaFiscalItemValorUnitario, AV24TFNotaFiscalItemValorUnitario_To, AV25TFNotaFiscalItemValorTotal, AV26TFNotaFiscalItemValorTotal_To, AV42Pgmname, sPrefix) ;
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
            PA9D2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV42Pgmname = "NotaFiscalItemListaItensWW";
               WS9D2( ) ;
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
            GXEncryptionTmp = "notafiscalitemlistaitensww"+UrlEncode(StringUtil.LTrimStr(AV28PropostaId,9,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("notafiscalitemlistaitensww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV42Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV42Pgmname, "")), context));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV27DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV27DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV28PropostaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV28PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALNUMERO", AV15TFNotaFiscalNumero);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALNUMERO_SEL", AV16TFNotaFiscalNumero_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALITEMCODIGO", AV17TFNotaFiscalItemCodigo);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALITEMCODIGO_SEL", AV18TFNotaFiscalItemCodigo_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALITEMDESCRICAO", AV19TFNotaFiscalItemDescricao);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALITEMDESCRICAO_SEL", AV20TFNotaFiscalItemDescricao_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALITEMQUANTIDADE", StringUtil.LTrim( StringUtil.NToC( AV21TFNotaFiscalItemQuantidade, 18, 6, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALITEMQUANTIDADE_TO", StringUtil.LTrim( StringUtil.NToC( AV22TFNotaFiscalItemQuantidade_To, 18, 6, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALITEMVALORUNITARIO", StringUtil.LTrim( StringUtil.NToC( AV23TFNotaFiscalItemValorUnitario, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALITEMVALORUNITARIO_TO", StringUtil.LTrim( StringUtil.NToC( AV24TFNotaFiscalItemValorUnitario_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALITEMVALORTOTAL", StringUtil.LTrim( StringUtil.NToC( AV25TFNotaFiscalItemValorTotal, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFNOTAFISCALITEMVALORTOTAL_TO", StringUtil.LTrim( StringUtil.NToC( AV26TFNotaFiscalItemValorTotal_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV42Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV42Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV13OrderedDsc);
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

      protected void RenderHtmlCloseForm9D2( )
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
         return "NotaFiscalItemListaItensWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Nota Fiscal Item" ;
      }

      protected void WB9D0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "notafiscalitemlistaitensww");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV27DDO_TitleSettingsIcons);
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

      protected void START9D2( )
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
               STRUP9D0( ) ;
            }
         }
      }

      protected void WS9D2( )
      {
         START9D2( ) ;
         EVT9D2( ) ;
      }

      protected void EVT9D2( )
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
                                 STRUP9D0( ) ;
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
                                 STRUP9D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E119D2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP9D0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP9D0( ) ;
                              }
                              AV29Notafiscalitemlistaitenswwds_1_propostaid = AV28PropostaId;
                              AV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero = AV15TFNotaFiscalNumero;
                              AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel = AV16TFNotaFiscalNumero_Sel;
                              AV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo = AV17TFNotaFiscalItemCodigo;
                              AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel = AV18TFNotaFiscalItemCodigo_Sel;
                              AV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao = AV19TFNotaFiscalItemDescricao;
                              AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel = AV20TFNotaFiscalItemDescricao_Sel;
                              AV36Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade = AV21TFNotaFiscalItemQuantidade;
                              AV37Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to = AV22TFNotaFiscalItemQuantidade_To;
                              AV38Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario = AV23TFNotaFiscalItemValorUnitario;
                              AV39Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to = AV24TFNotaFiscalItemValorUnitario_To;
                              AV40Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal = AV25TFNotaFiscalItemValorTotal;
                              AV41Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to = AV26TFNotaFiscalItemValorTotal_To;
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
                                 STRUP9D0( ) ;
                              }
                              nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
                              SubsflControlProps_122( ) ;
                              A830NotaFiscalItemId = StringUtil.StrToGuid( cgiGet( edtNotaFiscalItemId_Internalname));
                              A323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n323PropostaId = false;
                              A794NotaFiscalId = StringUtil.StrToGuid( cgiGet( edtNotaFiscalId_Internalname));
                              n794NotaFiscalId = false;
                              A799NotaFiscalNumero = cgiGet( edtNotaFiscalNumero_Internalname);
                              n799NotaFiscalNumero = false;
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
                                          /* Execute user event: Start */
                                          E129D2 ();
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
                                          /* Execute user event: Refresh */
                                          E139D2 ();
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
                                          /* Execute user event: Grid.Load */
                                          E149D2 ();
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
                                       STRUP9D0( ) ;
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

      protected void WE9D2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm9D2( ) ;
            }
         }
      }

      protected void PA9D2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "notafiscalitemlistaitensww")), "notafiscalitemlistaitensww") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "notafiscalitemlistaitensww")))) ;
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
                     gxfirstwebparm = GetFirstPar( "PropostaId");
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
                                       int AV28PropostaId ,
                                       string AV15TFNotaFiscalNumero ,
                                       string AV16TFNotaFiscalNumero_Sel ,
                                       string AV17TFNotaFiscalItemCodigo ,
                                       string AV18TFNotaFiscalItemCodigo_Sel ,
                                       string AV19TFNotaFiscalItemDescricao ,
                                       string AV20TFNotaFiscalItemDescricao_Sel ,
                                       decimal AV21TFNotaFiscalItemQuantidade ,
                                       decimal AV22TFNotaFiscalItemQuantidade_To ,
                                       decimal AV23TFNotaFiscalItemValorUnitario ,
                                       decimal AV24TFNotaFiscalItemValorUnitario_To ,
                                       decimal AV25TFNotaFiscalItemValorTotal ,
                                       decimal AV26TFNotaFiscalItemValorTotal_To ,
                                       string AV42Pgmname ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF9D2( ) ;
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
         RF9D2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV42Pgmname = "NotaFiscalItemListaItensWW";
      }

      protected void RF9D2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 12;
         /* Execute user event: Refresh */
         E139D2 ();
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
                                                 AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel ,
                                                 AV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero ,
                                                 AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel ,
                                                 AV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo ,
                                                 AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel ,
                                                 AV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao ,
                                                 AV36Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade ,
                                                 AV37Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to ,
                                                 AV38Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario ,
                                                 AV39Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to ,
                                                 AV40Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal ,
                                                 AV41Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to ,
                                                 A799NotaFiscalNumero ,
                                                 A831NotaFiscalItemCodigo ,
                                                 A833NotaFiscalItemDescricao ,
                                                 A837NotaFiscalItemQuantidade ,
                                                 A838NotaFiscalItemValorUnitario ,
                                                 A839NotaFiscalItemValorTotal ,
                                                 AV12OrderedBy ,
                                                 AV13OrderedDsc ,
                                                 A323PropostaId ,
                                                 AV29Notafiscalitemlistaitenswwds_1_propostaid } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                                 TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero), "%", "");
            lV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo = StringUtil.Concat( StringUtil.RTrim( AV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo), "%", "");
            lV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao = StringUtil.Concat( StringUtil.RTrim( AV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao), "%", "");
            /* Using cursor H009D2 */
            pr_default.execute(0, new Object[] {AV29Notafiscalitemlistaitenswwds_1_propostaid, lV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero, AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel, lV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo, AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel, lV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao, AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel, AV36Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade, AV37Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to, AV38Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario, AV39Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to, AV40Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal, AV41Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_12_idx = 1;
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A839NotaFiscalItemValorTotal = H009D2_A839NotaFiscalItemValorTotal[0];
               n839NotaFiscalItemValorTotal = H009D2_n839NotaFiscalItemValorTotal[0];
               A838NotaFiscalItemValorUnitario = H009D2_A838NotaFiscalItemValorUnitario[0];
               n838NotaFiscalItemValorUnitario = H009D2_n838NotaFiscalItemValorUnitario[0];
               A837NotaFiscalItemQuantidade = H009D2_A837NotaFiscalItemQuantidade[0];
               n837NotaFiscalItemQuantidade = H009D2_n837NotaFiscalItemQuantidade[0];
               A833NotaFiscalItemDescricao = H009D2_A833NotaFiscalItemDescricao[0];
               n833NotaFiscalItemDescricao = H009D2_n833NotaFiscalItemDescricao[0];
               A832NotaFiscalItemCFOP = H009D2_A832NotaFiscalItemCFOP[0];
               n832NotaFiscalItemCFOP = H009D2_n832NotaFiscalItemCFOP[0];
               A831NotaFiscalItemCodigo = H009D2_A831NotaFiscalItemCodigo[0];
               n831NotaFiscalItemCodigo = H009D2_n831NotaFiscalItemCodigo[0];
               A799NotaFiscalNumero = H009D2_A799NotaFiscalNumero[0];
               n799NotaFiscalNumero = H009D2_n799NotaFiscalNumero[0];
               A794NotaFiscalId = H009D2_A794NotaFiscalId[0];
               n794NotaFiscalId = H009D2_n794NotaFiscalId[0];
               A323PropostaId = H009D2_A323PropostaId[0];
               n323PropostaId = H009D2_n323PropostaId[0];
               A830NotaFiscalItemId = H009D2_A830NotaFiscalItemId[0];
               A799NotaFiscalNumero = H009D2_A799NotaFiscalNumero[0];
               n799NotaFiscalNumero = H009D2_n799NotaFiscalNumero[0];
               /* Execute user event: Grid.Load */
               E149D2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 12;
            WB9D0( ) ;
         }
         bGXsfl_12_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9D2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV42Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV42Pgmname, "")), context));
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
         AV29Notafiscalitemlistaitenswwds_1_propostaid = AV28PropostaId;
         AV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero = AV15TFNotaFiscalNumero;
         AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel = AV16TFNotaFiscalNumero_Sel;
         AV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo = AV17TFNotaFiscalItemCodigo;
         AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel = AV18TFNotaFiscalItemCodigo_Sel;
         AV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao = AV19TFNotaFiscalItemDescricao;
         AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel = AV20TFNotaFiscalItemDescricao_Sel;
         AV36Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade = AV21TFNotaFiscalItemQuantidade;
         AV37Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to = AV22TFNotaFiscalItemQuantidade_To;
         AV38Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario = AV23TFNotaFiscalItemValorUnitario;
         AV39Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to = AV24TFNotaFiscalItemValorUnitario_To;
         AV40Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal = AV25TFNotaFiscalItemValorTotal;
         AV41Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to = AV26TFNotaFiscalItemValorTotal_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel ,
                                              AV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero ,
                                              AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel ,
                                              AV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo ,
                                              AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel ,
                                              AV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao ,
                                              AV36Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade ,
                                              AV37Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to ,
                                              AV38Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario ,
                                              AV39Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to ,
                                              AV40Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal ,
                                              AV41Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to ,
                                              A799NotaFiscalNumero ,
                                              A831NotaFiscalItemCodigo ,
                                              A833NotaFiscalItemDescricao ,
                                              A837NotaFiscalItemQuantidade ,
                                              A838NotaFiscalItemValorUnitario ,
                                              A839NotaFiscalItemValorTotal ,
                                              AV12OrderedBy ,
                                              AV13OrderedDsc ,
                                              A323PropostaId ,
                                              AV29Notafiscalitemlistaitenswwds_1_propostaid } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero), "%", "");
         lV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo = StringUtil.Concat( StringUtil.RTrim( AV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo), "%", "");
         lV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao = StringUtil.Concat( StringUtil.RTrim( AV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao), "%", "");
         /* Using cursor H009D3 */
         pr_default.execute(1, new Object[] {AV29Notafiscalitemlistaitenswwds_1_propostaid, lV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero, AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel, lV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo, AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel, lV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao, AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel, AV36Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade, AV37Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to, AV38Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario, AV39Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to, AV40Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal, AV41Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to});
         GRID_nRecordCount = H009D3_AGRID_nRecordCount[0];
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
         AV29Notafiscalitemlistaitenswwds_1_propostaid = AV28PropostaId;
         AV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero = AV15TFNotaFiscalNumero;
         AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel = AV16TFNotaFiscalNumero_Sel;
         AV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo = AV17TFNotaFiscalItemCodigo;
         AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel = AV18TFNotaFiscalItemCodigo_Sel;
         AV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao = AV19TFNotaFiscalItemDescricao;
         AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel = AV20TFNotaFiscalItemDescricao_Sel;
         AV36Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade = AV21TFNotaFiscalItemQuantidade;
         AV37Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to = AV22TFNotaFiscalItemQuantidade_To;
         AV38Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario = AV23TFNotaFiscalItemValorUnitario;
         AV39Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to = AV24TFNotaFiscalItemValorUnitario_To;
         AV40Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal = AV25TFNotaFiscalItemValorTotal;
         AV41Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to = AV26TFNotaFiscalItemValorTotal_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV28PropostaId, AV15TFNotaFiscalNumero, AV16TFNotaFiscalNumero_Sel, AV17TFNotaFiscalItemCodigo, AV18TFNotaFiscalItemCodigo_Sel, AV19TFNotaFiscalItemDescricao, AV20TFNotaFiscalItemDescricao_Sel, AV21TFNotaFiscalItemQuantidade, AV22TFNotaFiscalItemQuantidade_To, AV23TFNotaFiscalItemValorUnitario, AV24TFNotaFiscalItemValorUnitario_To, AV25TFNotaFiscalItemValorTotal, AV26TFNotaFiscalItemValorTotal_To, AV42Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV29Notafiscalitemlistaitenswwds_1_propostaid = AV28PropostaId;
         AV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero = AV15TFNotaFiscalNumero;
         AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel = AV16TFNotaFiscalNumero_Sel;
         AV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo = AV17TFNotaFiscalItemCodigo;
         AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel = AV18TFNotaFiscalItemCodigo_Sel;
         AV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao = AV19TFNotaFiscalItemDescricao;
         AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel = AV20TFNotaFiscalItemDescricao_Sel;
         AV36Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade = AV21TFNotaFiscalItemQuantidade;
         AV37Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to = AV22TFNotaFiscalItemQuantidade_To;
         AV38Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario = AV23TFNotaFiscalItemValorUnitario;
         AV39Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to = AV24TFNotaFiscalItemValorUnitario_To;
         AV40Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal = AV25TFNotaFiscalItemValorTotal;
         AV41Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to = AV26TFNotaFiscalItemValorTotal_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV28PropostaId, AV15TFNotaFiscalNumero, AV16TFNotaFiscalNumero_Sel, AV17TFNotaFiscalItemCodigo, AV18TFNotaFiscalItemCodigo_Sel, AV19TFNotaFiscalItemDescricao, AV20TFNotaFiscalItemDescricao_Sel, AV21TFNotaFiscalItemQuantidade, AV22TFNotaFiscalItemQuantidade_To, AV23TFNotaFiscalItemValorUnitario, AV24TFNotaFiscalItemValorUnitario_To, AV25TFNotaFiscalItemValorTotal, AV26TFNotaFiscalItemValorTotal_To, AV42Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV29Notafiscalitemlistaitenswwds_1_propostaid = AV28PropostaId;
         AV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero = AV15TFNotaFiscalNumero;
         AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel = AV16TFNotaFiscalNumero_Sel;
         AV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo = AV17TFNotaFiscalItemCodigo;
         AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel = AV18TFNotaFiscalItemCodigo_Sel;
         AV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao = AV19TFNotaFiscalItemDescricao;
         AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel = AV20TFNotaFiscalItemDescricao_Sel;
         AV36Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade = AV21TFNotaFiscalItemQuantidade;
         AV37Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to = AV22TFNotaFiscalItemQuantidade_To;
         AV38Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario = AV23TFNotaFiscalItemValorUnitario;
         AV39Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to = AV24TFNotaFiscalItemValorUnitario_To;
         AV40Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal = AV25TFNotaFiscalItemValorTotal;
         AV41Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to = AV26TFNotaFiscalItemValorTotal_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV28PropostaId, AV15TFNotaFiscalNumero, AV16TFNotaFiscalNumero_Sel, AV17TFNotaFiscalItemCodigo, AV18TFNotaFiscalItemCodigo_Sel, AV19TFNotaFiscalItemDescricao, AV20TFNotaFiscalItemDescricao_Sel, AV21TFNotaFiscalItemQuantidade, AV22TFNotaFiscalItemQuantidade_To, AV23TFNotaFiscalItemValorUnitario, AV24TFNotaFiscalItemValorUnitario_To, AV25TFNotaFiscalItemValorTotal, AV26TFNotaFiscalItemValorTotal_To, AV42Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV29Notafiscalitemlistaitenswwds_1_propostaid = AV28PropostaId;
         AV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero = AV15TFNotaFiscalNumero;
         AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel = AV16TFNotaFiscalNumero_Sel;
         AV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo = AV17TFNotaFiscalItemCodigo;
         AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel = AV18TFNotaFiscalItemCodigo_Sel;
         AV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao = AV19TFNotaFiscalItemDescricao;
         AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel = AV20TFNotaFiscalItemDescricao_Sel;
         AV36Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade = AV21TFNotaFiscalItemQuantidade;
         AV37Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to = AV22TFNotaFiscalItemQuantidade_To;
         AV38Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario = AV23TFNotaFiscalItemValorUnitario;
         AV39Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to = AV24TFNotaFiscalItemValorUnitario_To;
         AV40Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal = AV25TFNotaFiscalItemValorTotal;
         AV41Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to = AV26TFNotaFiscalItemValorTotal_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV28PropostaId, AV15TFNotaFiscalNumero, AV16TFNotaFiscalNumero_Sel, AV17TFNotaFiscalItemCodigo, AV18TFNotaFiscalItemCodigo_Sel, AV19TFNotaFiscalItemDescricao, AV20TFNotaFiscalItemDescricao_Sel, AV21TFNotaFiscalItemQuantidade, AV22TFNotaFiscalItemQuantidade_To, AV23TFNotaFiscalItemValorUnitario, AV24TFNotaFiscalItemValorUnitario_To, AV25TFNotaFiscalItemValorTotal, AV26TFNotaFiscalItemValorTotal_To, AV42Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV29Notafiscalitemlistaitenswwds_1_propostaid = AV28PropostaId;
         AV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero = AV15TFNotaFiscalNumero;
         AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel = AV16TFNotaFiscalNumero_Sel;
         AV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo = AV17TFNotaFiscalItemCodigo;
         AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel = AV18TFNotaFiscalItemCodigo_Sel;
         AV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao = AV19TFNotaFiscalItemDescricao;
         AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel = AV20TFNotaFiscalItemDescricao_Sel;
         AV36Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade = AV21TFNotaFiscalItemQuantidade;
         AV37Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to = AV22TFNotaFiscalItemQuantidade_To;
         AV38Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario = AV23TFNotaFiscalItemValorUnitario;
         AV39Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to = AV24TFNotaFiscalItemValorUnitario_To;
         AV40Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal = AV25TFNotaFiscalItemValorTotal;
         AV41Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to = AV26TFNotaFiscalItemValorTotal_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV28PropostaId, AV15TFNotaFiscalNumero, AV16TFNotaFiscalNumero_Sel, AV17TFNotaFiscalItemCodigo, AV18TFNotaFiscalItemCodigo_Sel, AV19TFNotaFiscalItemDescricao, AV20TFNotaFiscalItemDescricao_Sel, AV21TFNotaFiscalItemQuantidade, AV22TFNotaFiscalItemQuantidade_To, AV23TFNotaFiscalItemValorUnitario, AV24TFNotaFiscalItemValorUnitario_To, AV25TFNotaFiscalItemValorTotal, AV26TFNotaFiscalItemValorTotal_To, AV42Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV42Pgmname = "NotaFiscalItemListaItensWW";
         edtNotaFiscalItemId_Enabled = 0;
         edtPropostaId_Enabled = 0;
         edtNotaFiscalId_Enabled = 0;
         edtNotaFiscalNumero_Enabled = 0;
         edtNotaFiscalItemCodigo_Enabled = 0;
         edtNotaFiscalItemCFOP_Enabled = 0;
         edtNotaFiscalItemDescricao_Enabled = 0;
         edtNotaFiscalItemQuantidade_Enabled = 0;
         edtNotaFiscalItemValorUnitario_Enabled = 0;
         edtNotaFiscalItemValorTotal_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9D0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E129D2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV27DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_12 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_12"), ",", "."), 18, MidpointRounding.ToEven));
            wcpOAV28PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV28PropostaId"), ",", "."), 18, MidpointRounding.ToEven));
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
         E129D2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E129D2( )
      {
         /* Start Routine */
         returnInSub = false;
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV27DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV27DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
      }

      protected void E139D2( )
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
         AV29Notafiscalitemlistaitenswwds_1_propostaid = AV28PropostaId;
         AV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero = AV15TFNotaFiscalNumero;
         AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel = AV16TFNotaFiscalNumero_Sel;
         AV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo = AV17TFNotaFiscalItemCodigo;
         AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel = AV18TFNotaFiscalItemCodigo_Sel;
         AV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao = AV19TFNotaFiscalItemDescricao;
         AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel = AV20TFNotaFiscalItemDescricao_Sel;
         AV36Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade = AV21TFNotaFiscalItemQuantidade;
         AV37Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to = AV22TFNotaFiscalItemQuantidade_To;
         AV38Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario = AV23TFNotaFiscalItemValorUnitario;
         AV39Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to = AV24TFNotaFiscalItemValorUnitario_To;
         AV40Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal = AV25TFNotaFiscalItemValorTotal;
         AV41Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to = AV26TFNotaFiscalItemValorTotal_To;
      }

      protected void E119D2( )
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
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalItemCodigo") == 0 )
            {
               AV17TFNotaFiscalItemCodigo = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV17TFNotaFiscalItemCodigo", AV17TFNotaFiscalItemCodigo);
               AV18TFNotaFiscalItemCodigo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV18TFNotaFiscalItemCodigo_Sel", AV18TFNotaFiscalItemCodigo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalItemDescricao") == 0 )
            {
               AV19TFNotaFiscalItemDescricao = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV19TFNotaFiscalItemDescricao", AV19TFNotaFiscalItemDescricao);
               AV20TFNotaFiscalItemDescricao_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV20TFNotaFiscalItemDescricao_Sel", AV20TFNotaFiscalItemDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalItemQuantidade") == 0 )
            {
               AV21TFNotaFiscalItemQuantidade = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV21TFNotaFiscalItemQuantidade", StringUtil.LTrimStr( AV21TFNotaFiscalItemQuantidade, 18, 6));
               AV22TFNotaFiscalItemQuantidade_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV22TFNotaFiscalItemQuantidade_To", StringUtil.LTrimStr( AV22TFNotaFiscalItemQuantidade_To, 18, 6));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalItemValorUnitario") == 0 )
            {
               AV23TFNotaFiscalItemValorUnitario = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV23TFNotaFiscalItemValorUnitario", StringUtil.LTrimStr( AV23TFNotaFiscalItemValorUnitario, 18, 2));
               AV24TFNotaFiscalItemValorUnitario_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV24TFNotaFiscalItemValorUnitario_To", StringUtil.LTrimStr( AV24TFNotaFiscalItemValorUnitario_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotaFiscalItemValorTotal") == 0 )
            {
               AV25TFNotaFiscalItemValorTotal = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV25TFNotaFiscalItemValorTotal", StringUtil.LTrimStr( AV25TFNotaFiscalItemValorTotal, 18, 2));
               AV26TFNotaFiscalItemValorTotal_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV26TFNotaFiscalItemValorTotal_To", StringUtil.LTrimStr( AV26TFNotaFiscalItemValorTotal_To, 18, 2));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E149D2( )
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
         if ( StringUtil.StrCmp(AV14Session.Get(AV42Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV42Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV14Session.Get(AV42Pgmname+"GridState"), null, "", "");
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
         AV43GXV1 = 1;
         while ( AV43GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV43GXV1));
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
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMCODIGO") == 0 )
            {
               AV17TFNotaFiscalItemCodigo = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV17TFNotaFiscalItemCodigo", AV17TFNotaFiscalItemCodigo);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMCODIGO_SEL") == 0 )
            {
               AV18TFNotaFiscalItemCodigo_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV18TFNotaFiscalItemCodigo_Sel", AV18TFNotaFiscalItemCodigo_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMDESCRICAO") == 0 )
            {
               AV19TFNotaFiscalItemDescricao = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV19TFNotaFiscalItemDescricao", AV19TFNotaFiscalItemDescricao);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMDESCRICAO_SEL") == 0 )
            {
               AV20TFNotaFiscalItemDescricao_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV20TFNotaFiscalItemDescricao_Sel", AV20TFNotaFiscalItemDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMQUANTIDADE") == 0 )
            {
               AV21TFNotaFiscalItemQuantidade = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV21TFNotaFiscalItemQuantidade", StringUtil.LTrimStr( AV21TFNotaFiscalItemQuantidade, 18, 6));
               AV22TFNotaFiscalItemQuantidade_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV22TFNotaFiscalItemQuantidade_To", StringUtil.LTrimStr( AV22TFNotaFiscalItemQuantidade_To, 18, 6));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMVALORUNITARIO") == 0 )
            {
               AV23TFNotaFiscalItemValorUnitario = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV23TFNotaFiscalItemValorUnitario", StringUtil.LTrimStr( AV23TFNotaFiscalItemValorUnitario, 18, 2));
               AV24TFNotaFiscalItemValorUnitario_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV24TFNotaFiscalItemValorUnitario_To", StringUtil.LTrimStr( AV24TFNotaFiscalItemValorUnitario_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMVALORTOTAL") == 0 )
            {
               AV25TFNotaFiscalItemValorTotal = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV25TFNotaFiscalItemValorTotal", StringUtil.LTrimStr( AV25TFNotaFiscalItemValorTotal, 18, 2));
               AV26TFNotaFiscalItemValorTotal_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV26TFNotaFiscalItemValorTotal_To", StringUtil.LTrimStr( AV26TFNotaFiscalItemValorTotal_To, 18, 2));
            }
            AV43GXV1 = (int)(AV43GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV16TFNotaFiscalNumero_Sel)),  AV16TFNotaFiscalNumero_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV18TFNotaFiscalItemCodigo_Sel)),  AV18TFNotaFiscalItemCodigo_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV20TFNotaFiscalItemDescricao_Sel)),  AV20TFNotaFiscalItemDescricao_Sel, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char3+"|"+GXt_char4+"|||";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV15TFNotaFiscalNumero)),  AV15TFNotaFiscalNumero, out  GXt_char4) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV17TFNotaFiscalItemCodigo)),  AV17TFNotaFiscalItemCodigo, out  GXt_char3) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV19TFNotaFiscalItemDescricao)),  AV19TFNotaFiscalItemDescricao, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char4+"|"+GXt_char3+"|"+GXt_char2+"|"+((Convert.ToDecimal(0)==AV21TFNotaFiscalItemQuantidade) ? "" : StringUtil.Str( AV21TFNotaFiscalItemQuantidade, 18, 6))+"|"+((Convert.ToDecimal(0)==AV23TFNotaFiscalItemValorUnitario) ? "" : StringUtil.Str( AV23TFNotaFiscalItemValorUnitario, 18, 2))+"|"+((Convert.ToDecimal(0)==AV25TFNotaFiscalItemValorTotal) ? "" : StringUtil.Str( AV25TFNotaFiscalItemValorTotal, 18, 2));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|||"+((Convert.ToDecimal(0)==AV22TFNotaFiscalItemQuantidade_To) ? "" : StringUtil.Str( AV22TFNotaFiscalItemQuantidade_To, 18, 6))+"|"+((Convert.ToDecimal(0)==AV24TFNotaFiscalItemValorUnitario_To) ? "" : StringUtil.Str( AV24TFNotaFiscalItemValorUnitario_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV26TFNotaFiscalItemValorTotal_To) ? "" : StringUtil.Str( AV26TFNotaFiscalItemValorTotal_To, 18, 2));
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
         AV10GridState.FromXml(AV14Session.Get(AV42Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV12OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFNOTAFISCALNUMERO",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15TFNotaFiscalNumero)),  0,  AV15TFNotaFiscalNumero,  AV15TFNotaFiscalNumero,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV16TFNotaFiscalNumero_Sel)),  AV16TFNotaFiscalNumero_Sel,  AV16TFNotaFiscalNumero_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFNOTAFISCALITEMCODIGO",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV17TFNotaFiscalItemCodigo)),  0,  AV17TFNotaFiscalItemCodigo,  AV17TFNotaFiscalItemCodigo,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV18TFNotaFiscalItemCodigo_Sel)),  AV18TFNotaFiscalItemCodigo_Sel,  AV18TFNotaFiscalItemCodigo_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFNOTAFISCALITEMDESCRICAO",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV19TFNotaFiscalItemDescricao)),  0,  AV19TFNotaFiscalItemDescricao,  AV19TFNotaFiscalItemDescricao,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV20TFNotaFiscalItemDescricao_Sel)),  AV20TFNotaFiscalItemDescricao_Sel,  AV20TFNotaFiscalItemDescricao_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFNOTAFISCALITEMQUANTIDADE",  "",  !((Convert.ToDecimal(0)==AV21TFNotaFiscalItemQuantidade)&&(Convert.ToDecimal(0)==AV22TFNotaFiscalItemQuantidade_To)),  0,  StringUtil.Trim( StringUtil.Str( AV21TFNotaFiscalItemQuantidade, 18, 6)),  ((Convert.ToDecimal(0)==AV21TFNotaFiscalItemQuantidade) ? "" : StringUtil.Trim( context.localUtil.Format( AV21TFNotaFiscalItemQuantidade, "ZZZZZZZZZZ9.999999"))),  true,  StringUtil.Trim( StringUtil.Str( AV22TFNotaFiscalItemQuantidade_To, 18, 6)),  ((Convert.ToDecimal(0)==AV22TFNotaFiscalItemQuantidade_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV22TFNotaFiscalItemQuantidade_To, "ZZZZZZZZZZ9.999999")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFNOTAFISCALITEMVALORUNITARIO",  "",  !((Convert.ToDecimal(0)==AV23TFNotaFiscalItemValorUnitario)&&(Convert.ToDecimal(0)==AV24TFNotaFiscalItemValorUnitario_To)),  0,  StringUtil.Trim( StringUtil.Str( AV23TFNotaFiscalItemValorUnitario, 18, 2)),  ((Convert.ToDecimal(0)==AV23TFNotaFiscalItemValorUnitario) ? "" : StringUtil.Trim( context.localUtil.Format( AV23TFNotaFiscalItemValorUnitario, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV24TFNotaFiscalItemValorUnitario_To, 18, 2)),  ((Convert.ToDecimal(0)==AV24TFNotaFiscalItemValorUnitario_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV24TFNotaFiscalItemValorUnitario_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFNOTAFISCALITEMVALORTOTAL",  "",  !((Convert.ToDecimal(0)==AV25TFNotaFiscalItemValorTotal)&&(Convert.ToDecimal(0)==AV26TFNotaFiscalItemValorTotal_To)),  0,  StringUtil.Trim( StringUtil.Str( AV25TFNotaFiscalItemValorTotal, 18, 2)),  ((Convert.ToDecimal(0)==AV25TFNotaFiscalItemValorTotal) ? "" : StringUtil.Trim( context.localUtil.Format( AV25TFNotaFiscalItemValorTotal, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV26TFNotaFiscalItemValorTotal_To, 18, 2)),  ((Convert.ToDecimal(0)==AV26TFNotaFiscalItemValorTotal_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV26TFNotaFiscalItemValorTotal_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         if ( ! (0==AV28PropostaId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&PROPOSTAID";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV28PropostaId), 9, 0);
            AV10GridState.gxTpr_Filtervalues.Add(AV11GridStateFilterValue, 0);
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV42Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV42Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "NotaFiscalItem";
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "PropostaId";
         AV9TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV28PropostaId), 9, 0);
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV14Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV28PropostaId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV28PropostaId", StringUtil.LTrimStr( (decimal)(AV28PropostaId), 9, 0));
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
         PA9D2( ) ;
         WS9D2( ) ;
         WE9D2( ) ;
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
         sCtrlAV28PropostaId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA9D2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "notafiscalitemlistaitensww", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA9D2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV28PropostaId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV28PropostaId", StringUtil.LTrimStr( (decimal)(AV28PropostaId), 9, 0));
         }
         wcpOAV28PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV28PropostaId"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV28PropostaId != wcpOAV28PropostaId ) ) )
         {
            setjustcreated();
         }
         wcpOAV28PropostaId = AV28PropostaId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV28PropostaId = cgiGet( sPrefix+"AV28PropostaId_CTRL");
         if ( StringUtil.Len( sCtrlAV28PropostaId) > 0 )
         {
            AV28PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV28PropostaId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV28PropostaId", StringUtil.LTrimStr( (decimal)(AV28PropostaId), 9, 0));
         }
         else
         {
            AV28PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV28PropostaId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
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
         PA9D2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS9D2( ) ;
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
         WS9D2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV28PropostaId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28PropostaId), 9, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV28PropostaId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV28PropostaId_CTRL", StringUtil.RTrim( sCtrlAV28PropostaId));
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
         WE9D2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019211176", true, true);
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
         context.AddJavascriptSource("notafiscalitemlistaitensww.js", "?202561019211176", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_122( )
      {
         edtNotaFiscalItemId_Internalname = sPrefix+"NOTAFISCALITEMID_"+sGXsfl_12_idx;
         edtPropostaId_Internalname = sPrefix+"PROPOSTAID_"+sGXsfl_12_idx;
         edtNotaFiscalId_Internalname = sPrefix+"NOTAFISCALID_"+sGXsfl_12_idx;
         edtNotaFiscalNumero_Internalname = sPrefix+"NOTAFISCALNUMERO_"+sGXsfl_12_idx;
         edtNotaFiscalItemCodigo_Internalname = sPrefix+"NOTAFISCALITEMCODIGO_"+sGXsfl_12_idx;
         edtNotaFiscalItemCFOP_Internalname = sPrefix+"NOTAFISCALITEMCFOP_"+sGXsfl_12_idx;
         edtNotaFiscalItemDescricao_Internalname = sPrefix+"NOTAFISCALITEMDESCRICAO_"+sGXsfl_12_idx;
         edtNotaFiscalItemQuantidade_Internalname = sPrefix+"NOTAFISCALITEMQUANTIDADE_"+sGXsfl_12_idx;
         edtNotaFiscalItemValorUnitario_Internalname = sPrefix+"NOTAFISCALITEMVALORUNITARIO_"+sGXsfl_12_idx;
         edtNotaFiscalItemValorTotal_Internalname = sPrefix+"NOTAFISCALITEMVALORTOTAL_"+sGXsfl_12_idx;
      }

      protected void SubsflControlProps_fel_122( )
      {
         edtNotaFiscalItemId_Internalname = sPrefix+"NOTAFISCALITEMID_"+sGXsfl_12_fel_idx;
         edtPropostaId_Internalname = sPrefix+"PROPOSTAID_"+sGXsfl_12_fel_idx;
         edtNotaFiscalId_Internalname = sPrefix+"NOTAFISCALID_"+sGXsfl_12_fel_idx;
         edtNotaFiscalNumero_Internalname = sPrefix+"NOTAFISCALNUMERO_"+sGXsfl_12_fel_idx;
         edtNotaFiscalItemCodigo_Internalname = sPrefix+"NOTAFISCALITEMCODIGO_"+sGXsfl_12_fel_idx;
         edtNotaFiscalItemCFOP_Internalname = sPrefix+"NOTAFISCALITEMCFOP_"+sGXsfl_12_fel_idx;
         edtNotaFiscalItemDescricao_Internalname = sPrefix+"NOTAFISCALITEMDESCRICAO_"+sGXsfl_12_fel_idx;
         edtNotaFiscalItemQuantidade_Internalname = sPrefix+"NOTAFISCALITEMQUANTIDADE_"+sGXsfl_12_fel_idx;
         edtNotaFiscalItemValorUnitario_Internalname = sPrefix+"NOTAFISCALITEMVALORUNITARIO_"+sGXsfl_12_fel_idx;
         edtNotaFiscalItemValorTotal_Internalname = sPrefix+"NOTAFISCALITEMVALORTOTAL_"+sGXsfl_12_fel_idx;
      }

      protected void sendrow_122( )
      {
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         WB9D0( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalItemId_Internalname,A830NotaFiscalItemId.ToString(),A830NotaFiscalItemId.ToString(),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalItemId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)12,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalItemCodigo_Internalname,(string)A831NotaFiscalItemCodigo,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalItemCodigo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalItemCFOP_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A832NotaFiscalItemCFOP), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A832NotaFiscalItemCFOP), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalItemCFOP_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalItemDescricao_Internalname,(string)A833NotaFiscalItemDescricao,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalItemDescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)255,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalItemQuantidade_Internalname,StringUtil.LTrim( StringUtil.NToC( A837NotaFiscalItemQuantidade, 18, 6, ",", "")),StringUtil.LTrim( context.localUtil.Format( A837NotaFiscalItemQuantidade, "ZZZZZZZZZZ9.999999")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalItemQuantidade_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalItemValorUnitario_Internalname,StringUtil.LTrim( StringUtil.NToC( A838NotaFiscalItemValorUnitario, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A838NotaFiscalItemValorUnitario, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalItemValorUnitario_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotaFiscalItemValorTotal_Internalname,StringUtil.LTrim( StringUtil.NToC( A839NotaFiscalItemValorTotal, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A839NotaFiscalItemValorTotal, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotaFiscalItemValorTotal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes9D2( ) ;
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
            context.SendWebValue( "Item Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Fiscal Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nota") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A830NotaFiscalItemId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A794NotaFiscalId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A799NotaFiscalNumero));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A831NotaFiscalItemCodigo));
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
         edtNotaFiscalItemId_Internalname = sPrefix+"NOTAFISCALITEMID";
         edtPropostaId_Internalname = sPrefix+"PROPOSTAID";
         edtNotaFiscalId_Internalname = sPrefix+"NOTAFISCALID";
         edtNotaFiscalNumero_Internalname = sPrefix+"NOTAFISCALNUMERO";
         edtNotaFiscalItemCodigo_Internalname = sPrefix+"NOTAFISCALITEMCODIGO";
         edtNotaFiscalItemCFOP_Internalname = sPrefix+"NOTAFISCALITEMCFOP";
         edtNotaFiscalItemDescricao_Internalname = sPrefix+"NOTAFISCALITEMDESCRICAO";
         edtNotaFiscalItemQuantidade_Internalname = sPrefix+"NOTAFISCALITEMQUANTIDADE";
         edtNotaFiscalItemValorUnitario_Internalname = sPrefix+"NOTAFISCALITEMVALORUNITARIO";
         edtNotaFiscalItemValorTotal_Internalname = sPrefix+"NOTAFISCALITEMVALORTOTAL";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
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
         edtNotaFiscalItemValorTotal_Jsonclick = "";
         edtNotaFiscalItemValorUnitario_Jsonclick = "";
         edtNotaFiscalItemQuantidade_Jsonclick = "";
         edtNotaFiscalItemDescricao_Jsonclick = "";
         edtNotaFiscalItemCFOP_Jsonclick = "";
         edtNotaFiscalItemCodigo_Jsonclick = "";
         edtNotaFiscalNumero_Jsonclick = "";
         edtNotaFiscalId_Jsonclick = "";
         edtPropostaId_Jsonclick = "";
         edtNotaFiscalItemId_Jsonclick = "";
         subGrid_Class = "GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         edtNotaFiscalItemValorTotal_Enabled = 0;
         edtNotaFiscalItemValorUnitario_Enabled = 0;
         edtNotaFiscalItemQuantidade_Enabled = 0;
         edtNotaFiscalItemDescricao_Enabled = 0;
         edtNotaFiscalItemCFOP_Enabled = 0;
         edtNotaFiscalItemCodigo_Enabled = 0;
         edtNotaFiscalNumero_Enabled = 0;
         edtNotaFiscalId_Enabled = 0;
         edtPropostaId_Enabled = 0;
         edtNotaFiscalItemId_Enabled = 0;
         subGrid_Sortable = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "|||18.6|18.2|18.2";
         Ddo_grid_Datalistproc = "NotaFiscalItemListaItensWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|||";
         Ddo_grid_Includedatalist = "T|T|T|||";
         Ddo_grid_Filterisrange = "|||T|T|T";
         Ddo_grid_Filtertype = "Character|Character|Character|Numeric|Numeric|Numeric";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6";
         Ddo_grid_Columnids = "3:NotaFiscalNumero|4:NotaFiscalItemCodigo|6:NotaFiscalItemDescricao|7:NotaFiscalItemQuantidade|8:NotaFiscalItemValorUnitario|9:NotaFiscalItemValorTotal";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV28PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV16TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV17TFNotaFiscalItemCodigo","fld":"vTFNOTAFISCALITEMCODIGO","type":"svchar"},{"av":"AV18TFNotaFiscalItemCodigo_Sel","fld":"vTFNOTAFISCALITEMCODIGO_SEL","type":"svchar"},{"av":"AV19TFNotaFiscalItemDescricao","fld":"vTFNOTAFISCALITEMDESCRICAO","type":"svchar"},{"av":"AV20TFNotaFiscalItemDescricao_Sel","fld":"vTFNOTAFISCALITEMDESCRICAO_SEL","type":"svchar"},{"av":"AV21TFNotaFiscalItemQuantidade","fld":"vTFNOTAFISCALITEMQUANTIDADE","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV22TFNotaFiscalItemQuantidade_To","fld":"vTFNOTAFISCALITEMQUANTIDADE_TO","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV23TFNotaFiscalItemValorUnitario","fld":"vTFNOTAFISCALITEMVALORUNITARIO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24TFNotaFiscalItemValorUnitario_To","fld":"vTFNOTAFISCALITEMVALORUNITARIO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25TFNotaFiscalItemValorTotal","fld":"vTFNOTAFISCALITEMVALORTOTAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV26TFNotaFiscalItemValorTotal_To","fld":"vTFNOTAFISCALITEMVALORTOTAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV42Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E119D2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV28PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV16TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV17TFNotaFiscalItemCodigo","fld":"vTFNOTAFISCALITEMCODIGO","type":"svchar"},{"av":"AV18TFNotaFiscalItemCodigo_Sel","fld":"vTFNOTAFISCALITEMCODIGO_SEL","type":"svchar"},{"av":"AV19TFNotaFiscalItemDescricao","fld":"vTFNOTAFISCALITEMDESCRICAO","type":"svchar"},{"av":"AV20TFNotaFiscalItemDescricao_Sel","fld":"vTFNOTAFISCALITEMDESCRICAO_SEL","type":"svchar"},{"av":"AV21TFNotaFiscalItemQuantidade","fld":"vTFNOTAFISCALITEMQUANTIDADE","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV22TFNotaFiscalItemQuantidade_To","fld":"vTFNOTAFISCALITEMQUANTIDADE_TO","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV23TFNotaFiscalItemValorUnitario","fld":"vTFNOTAFISCALITEMVALORUNITARIO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24TFNotaFiscalItemValorUnitario_To","fld":"vTFNOTAFISCALITEMVALORUNITARIO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25TFNotaFiscalItemValorTotal","fld":"vTFNOTAFISCALITEMVALORTOTAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV26TFNotaFiscalItemValorTotal_To","fld":"vTFNOTAFISCALITEMVALORTOTAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV25TFNotaFiscalItemValorTotal","fld":"vTFNOTAFISCALITEMVALORTOTAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV26TFNotaFiscalItemValorTotal_To","fld":"vTFNOTAFISCALITEMVALORTOTAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV23TFNotaFiscalItemValorUnitario","fld":"vTFNOTAFISCALITEMVALORUNITARIO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24TFNotaFiscalItemValorUnitario_To","fld":"vTFNOTAFISCALITEMVALORUNITARIO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV21TFNotaFiscalItemQuantidade","fld":"vTFNOTAFISCALITEMQUANTIDADE","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV22TFNotaFiscalItemQuantidade_To","fld":"vTFNOTAFISCALITEMQUANTIDADE_TO","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV19TFNotaFiscalItemDescricao","fld":"vTFNOTAFISCALITEMDESCRICAO","type":"svchar"},{"av":"AV20TFNotaFiscalItemDescricao_Sel","fld":"vTFNOTAFISCALITEMDESCRICAO_SEL","type":"svchar"},{"av":"AV17TFNotaFiscalItemCodigo","fld":"vTFNOTAFISCALITEMCODIGO","type":"svchar"},{"av":"AV18TFNotaFiscalItemCodigo_Sel","fld":"vTFNOTAFISCALITEMCODIGO_SEL","type":"svchar"},{"av":"AV15TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV16TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E149D2","iparms":[]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV28PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV16TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV17TFNotaFiscalItemCodigo","fld":"vTFNOTAFISCALITEMCODIGO","type":"svchar"},{"av":"AV18TFNotaFiscalItemCodigo_Sel","fld":"vTFNOTAFISCALITEMCODIGO_SEL","type":"svchar"},{"av":"AV19TFNotaFiscalItemDescricao","fld":"vTFNOTAFISCALITEMDESCRICAO","type":"svchar"},{"av":"AV20TFNotaFiscalItemDescricao_Sel","fld":"vTFNOTAFISCALITEMDESCRICAO_SEL","type":"svchar"},{"av":"AV21TFNotaFiscalItemQuantidade","fld":"vTFNOTAFISCALITEMQUANTIDADE","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV22TFNotaFiscalItemQuantidade_To","fld":"vTFNOTAFISCALITEMQUANTIDADE_TO","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV23TFNotaFiscalItemValorUnitario","fld":"vTFNOTAFISCALITEMVALORUNITARIO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24TFNotaFiscalItemValorUnitario_To","fld":"vTFNOTAFISCALITEMVALORUNITARIO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25TFNotaFiscalItemValorTotal","fld":"vTFNOTAFISCALITEMVALORTOTAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV26TFNotaFiscalItemValorTotal_To","fld":"vTFNOTAFISCALITEMVALORTOTAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV28PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV16TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV17TFNotaFiscalItemCodigo","fld":"vTFNOTAFISCALITEMCODIGO","type":"svchar"},{"av":"AV18TFNotaFiscalItemCodigo_Sel","fld":"vTFNOTAFISCALITEMCODIGO_SEL","type":"svchar"},{"av":"AV19TFNotaFiscalItemDescricao","fld":"vTFNOTAFISCALITEMDESCRICAO","type":"svchar"},{"av":"AV20TFNotaFiscalItemDescricao_Sel","fld":"vTFNOTAFISCALITEMDESCRICAO_SEL","type":"svchar"},{"av":"AV21TFNotaFiscalItemQuantidade","fld":"vTFNOTAFISCALITEMQUANTIDADE","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV22TFNotaFiscalItemQuantidade_To","fld":"vTFNOTAFISCALITEMQUANTIDADE_TO","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV23TFNotaFiscalItemValorUnitario","fld":"vTFNOTAFISCALITEMVALORUNITARIO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24TFNotaFiscalItemValorUnitario_To","fld":"vTFNOTAFISCALITEMVALORUNITARIO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25TFNotaFiscalItemValorTotal","fld":"vTFNOTAFISCALITEMVALORTOTAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV26TFNotaFiscalItemValorTotal_To","fld":"vTFNOTAFISCALITEMVALORTOTAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV28PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV16TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV17TFNotaFiscalItemCodigo","fld":"vTFNOTAFISCALITEMCODIGO","type":"svchar"},{"av":"AV18TFNotaFiscalItemCodigo_Sel","fld":"vTFNOTAFISCALITEMCODIGO_SEL","type":"svchar"},{"av":"AV19TFNotaFiscalItemDescricao","fld":"vTFNOTAFISCALITEMDESCRICAO","type":"svchar"},{"av":"AV20TFNotaFiscalItemDescricao_Sel","fld":"vTFNOTAFISCALITEMDESCRICAO_SEL","type":"svchar"},{"av":"AV21TFNotaFiscalItemQuantidade","fld":"vTFNOTAFISCALITEMQUANTIDADE","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV22TFNotaFiscalItemQuantidade_To","fld":"vTFNOTAFISCALITEMQUANTIDADE_TO","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV23TFNotaFiscalItemValorUnitario","fld":"vTFNOTAFISCALITEMVALORUNITARIO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24TFNotaFiscalItemValorUnitario_To","fld":"vTFNOTAFISCALITEMVALORUNITARIO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25TFNotaFiscalItemValorTotal","fld":"vTFNOTAFISCALITEMVALORTOTAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV26TFNotaFiscalItemValorTotal_To","fld":"vTFNOTAFISCALITEMVALORTOTAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV28PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFNotaFiscalNumero","fld":"vTFNOTAFISCALNUMERO","type":"svchar"},{"av":"AV16TFNotaFiscalNumero_Sel","fld":"vTFNOTAFISCALNUMERO_SEL","type":"svchar"},{"av":"AV17TFNotaFiscalItemCodigo","fld":"vTFNOTAFISCALITEMCODIGO","type":"svchar"},{"av":"AV18TFNotaFiscalItemCodigo_Sel","fld":"vTFNOTAFISCALITEMCODIGO_SEL","type":"svchar"},{"av":"AV19TFNotaFiscalItemDescricao","fld":"vTFNOTAFISCALITEMDESCRICAO","type":"svchar"},{"av":"AV20TFNotaFiscalItemDescricao_Sel","fld":"vTFNOTAFISCALITEMDESCRICAO_SEL","type":"svchar"},{"av":"AV21TFNotaFiscalItemQuantidade","fld":"vTFNOTAFISCALITEMQUANTIDADE","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV22TFNotaFiscalItemQuantidade_To","fld":"vTFNOTAFISCALITEMQUANTIDADE_TO","pic":"ZZZZZZZZZZ9.999999","type":"decimal"},{"av":"AV23TFNotaFiscalItemValorUnitario","fld":"vTFNOTAFISCALITEMVALORUNITARIO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24TFNotaFiscalItemValorUnitario_To","fld":"vTFNOTAFISCALITEMVALORUNITARIO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25TFNotaFiscalItemValorTotal","fld":"vTFNOTAFISCALITEMVALORTOTAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV26TFNotaFiscalItemValorTotal_To","fld":"vTFNOTAFISCALITEMVALORTOTAL_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("VALID_NOTAFISCALID","""{"handler":"Valid_Notafiscalid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Notafiscalitemvalortotal","iparms":[]}""");
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
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV15TFNotaFiscalNumero = "";
         AV16TFNotaFiscalNumero_Sel = "";
         AV17TFNotaFiscalItemCodigo = "";
         AV18TFNotaFiscalItemCodigo_Sel = "";
         AV19TFNotaFiscalItemDescricao = "";
         AV20TFNotaFiscalItemDescricao_Sel = "";
         AV42Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV27DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
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
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero = "";
         AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel = "";
         AV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo = "";
         AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel = "";
         AV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao = "";
         AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel = "";
         A830NotaFiscalItemId = Guid.Empty;
         A794NotaFiscalId = Guid.Empty;
         A799NotaFiscalNumero = "";
         A831NotaFiscalItemCodigo = "";
         A833NotaFiscalItemDescricao = "";
         GXDecQS = "";
         lV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero = "";
         lV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo = "";
         lV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao = "";
         H009D2_A839NotaFiscalItemValorTotal = new decimal[1] ;
         H009D2_n839NotaFiscalItemValorTotal = new bool[] {false} ;
         H009D2_A838NotaFiscalItemValorUnitario = new decimal[1] ;
         H009D2_n838NotaFiscalItemValorUnitario = new bool[] {false} ;
         H009D2_A837NotaFiscalItemQuantidade = new decimal[1] ;
         H009D2_n837NotaFiscalItemQuantidade = new bool[] {false} ;
         H009D2_A833NotaFiscalItemDescricao = new string[] {""} ;
         H009D2_n833NotaFiscalItemDescricao = new bool[] {false} ;
         H009D2_A832NotaFiscalItemCFOP = new short[1] ;
         H009D2_n832NotaFiscalItemCFOP = new bool[] {false} ;
         H009D2_A831NotaFiscalItemCodigo = new string[] {""} ;
         H009D2_n831NotaFiscalItemCodigo = new bool[] {false} ;
         H009D2_A799NotaFiscalNumero = new string[] {""} ;
         H009D2_n799NotaFiscalNumero = new bool[] {false} ;
         H009D2_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         H009D2_n794NotaFiscalId = new bool[] {false} ;
         H009D2_A323PropostaId = new int[1] ;
         H009D2_n323PropostaId = new bool[] {false} ;
         H009D2_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         H009D3_AGRID_nRecordCount = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV14Session = context.GetSession();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char4 = "";
         GXt_char3 = "";
         GXt_char2 = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV28PropostaId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.notafiscalitemlistaitensww__default(),
            new Object[][] {
                new Object[] {
               H009D2_A839NotaFiscalItemValorTotal, H009D2_n839NotaFiscalItemValorTotal, H009D2_A838NotaFiscalItemValorUnitario, H009D2_n838NotaFiscalItemValorUnitario, H009D2_A837NotaFiscalItemQuantidade, H009D2_n837NotaFiscalItemQuantidade, H009D2_A833NotaFiscalItemDescricao, H009D2_n833NotaFiscalItemDescricao, H009D2_A832NotaFiscalItemCFOP, H009D2_n832NotaFiscalItemCFOP,
               H009D2_A831NotaFiscalItemCodigo, H009D2_n831NotaFiscalItemCodigo, H009D2_A799NotaFiscalNumero, H009D2_n799NotaFiscalNumero, H009D2_A794NotaFiscalId, H009D2_n794NotaFiscalId, H009D2_A323PropostaId, H009D2_n323PropostaId, H009D2_A830NotaFiscalItemId
               }
               , new Object[] {
               H009D3_AGRID_nRecordCount
               }
            }
         );
         AV42Pgmname = "NotaFiscalItemListaItensWW";
         /* GeneXus formulas. */
         AV42Pgmname = "NotaFiscalItemListaItensWW";
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
      private short A832NotaFiscalItemCFOP ;
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
      private int AV28PropostaId ;
      private int wcpOAV28PropostaId ;
      private int subGrid_Rows ;
      private int nRC_GXsfl_12 ;
      private int nGXsfl_12_idx=1 ;
      private int AV29Notafiscalitemlistaitenswwds_1_propostaid ;
      private int A323PropostaId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtNotaFiscalItemId_Enabled ;
      private int edtPropostaId_Enabled ;
      private int edtNotaFiscalId_Enabled ;
      private int edtNotaFiscalNumero_Enabled ;
      private int edtNotaFiscalItemCodigo_Enabled ;
      private int edtNotaFiscalItemCFOP_Enabled ;
      private int edtNotaFiscalItemDescricao_Enabled ;
      private int edtNotaFiscalItemQuantidade_Enabled ;
      private int edtNotaFiscalItemValorUnitario_Enabled ;
      private int edtNotaFiscalItemValorTotal_Enabled ;
      private int AV43GXV1 ;
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
      private decimal AV21TFNotaFiscalItemQuantidade ;
      private decimal AV22TFNotaFiscalItemQuantidade_To ;
      private decimal AV23TFNotaFiscalItemValorUnitario ;
      private decimal AV24TFNotaFiscalItemValorUnitario_To ;
      private decimal AV25TFNotaFiscalItemValorTotal ;
      private decimal AV26TFNotaFiscalItemValorTotal_To ;
      private decimal AV36Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade ;
      private decimal AV37Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to ;
      private decimal AV38Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario ;
      private decimal AV39Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to ;
      private decimal AV40Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal ;
      private decimal AV41Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to ;
      private decimal A837NotaFiscalItemQuantidade ;
      private decimal A838NotaFiscalItemValorUnitario ;
      private decimal A839NotaFiscalItemValorTotal ;
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
      private string AV42Pgmname ;
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
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtNotaFiscalItemId_Internalname ;
      private string edtPropostaId_Internalname ;
      private string edtNotaFiscalId_Internalname ;
      private string edtNotaFiscalNumero_Internalname ;
      private string edtNotaFiscalItemCodigo_Internalname ;
      private string edtNotaFiscalItemCFOP_Internalname ;
      private string edtNotaFiscalItemDescricao_Internalname ;
      private string edtNotaFiscalItemQuantidade_Internalname ;
      private string edtNotaFiscalItemValorUnitario_Internalname ;
      private string edtNotaFiscalItemValorTotal_Internalname ;
      private string GXDecQS ;
      private string GXt_char4 ;
      private string GXt_char3 ;
      private string GXt_char2 ;
      private string sCtrlAV28PropostaId ;
      private string sGXsfl_12_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtNotaFiscalItemId_Jsonclick ;
      private string edtPropostaId_Jsonclick ;
      private string edtNotaFiscalId_Jsonclick ;
      private string edtNotaFiscalNumero_Jsonclick ;
      private string edtNotaFiscalItemCodigo_Jsonclick ;
      private string edtNotaFiscalItemCFOP_Jsonclick ;
      private string edtNotaFiscalItemDescricao_Jsonclick ;
      private string edtNotaFiscalItemQuantidade_Jsonclick ;
      private string edtNotaFiscalItemValorUnitario_Jsonclick ;
      private string edtNotaFiscalItemValorTotal_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n323PropostaId ;
      private bool n794NotaFiscalId ;
      private bool n799NotaFiscalNumero ;
      private bool n831NotaFiscalItemCodigo ;
      private bool n832NotaFiscalItemCFOP ;
      private bool n833NotaFiscalItemDescricao ;
      private bool n837NotaFiscalItemQuantidade ;
      private bool n838NotaFiscalItemValorUnitario ;
      private bool n839NotaFiscalItemValorTotal ;
      private bool bGXsfl_12_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV15TFNotaFiscalNumero ;
      private string AV16TFNotaFiscalNumero_Sel ;
      private string AV17TFNotaFiscalItemCodigo ;
      private string AV18TFNotaFiscalItemCodigo_Sel ;
      private string AV19TFNotaFiscalItemDescricao ;
      private string AV20TFNotaFiscalItemDescricao_Sel ;
      private string AV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero ;
      private string AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel ;
      private string AV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo ;
      private string AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel ;
      private string AV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao ;
      private string AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel ;
      private string A799NotaFiscalNumero ;
      private string A831NotaFiscalItemCodigo ;
      private string A833NotaFiscalItemDescricao ;
      private string lV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero ;
      private string lV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo ;
      private string lV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao ;
      private Guid A830NotaFiscalItemId ;
      private Guid A794NotaFiscalId ;
      private IGxSession AV14Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV27DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private decimal[] H009D2_A839NotaFiscalItemValorTotal ;
      private bool[] H009D2_n839NotaFiscalItemValorTotal ;
      private decimal[] H009D2_A838NotaFiscalItemValorUnitario ;
      private bool[] H009D2_n838NotaFiscalItemValorUnitario ;
      private decimal[] H009D2_A837NotaFiscalItemQuantidade ;
      private bool[] H009D2_n837NotaFiscalItemQuantidade ;
      private string[] H009D2_A833NotaFiscalItemDescricao ;
      private bool[] H009D2_n833NotaFiscalItemDescricao ;
      private short[] H009D2_A832NotaFiscalItemCFOP ;
      private bool[] H009D2_n832NotaFiscalItemCFOP ;
      private string[] H009D2_A831NotaFiscalItemCodigo ;
      private bool[] H009D2_n831NotaFiscalItemCodigo ;
      private string[] H009D2_A799NotaFiscalNumero ;
      private bool[] H009D2_n799NotaFiscalNumero ;
      private Guid[] H009D2_A794NotaFiscalId ;
      private bool[] H009D2_n794NotaFiscalId ;
      private int[] H009D2_A323PropostaId ;
      private bool[] H009D2_n323PropostaId ;
      private Guid[] H009D2_A830NotaFiscalItemId ;
      private long[] H009D3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV9TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class notafiscalitemlistaitensww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009D2( IGxContext context ,
                                             string AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel ,
                                             string AV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero ,
                                             string AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel ,
                                             string AV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo ,
                                             string AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel ,
                                             string AV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao ,
                                             decimal AV36Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade ,
                                             decimal AV37Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to ,
                                             decimal AV38Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario ,
                                             decimal AV39Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to ,
                                             decimal AV40Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal ,
                                             decimal AV41Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to ,
                                             string A799NotaFiscalNumero ,
                                             string A831NotaFiscalItemCodigo ,
                                             string A833NotaFiscalItemDescricao ,
                                             decimal A837NotaFiscalItemQuantidade ,
                                             decimal A838NotaFiscalItemValorUnitario ,
                                             decimal A839NotaFiscalItemValorTotal ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             int A323PropostaId ,
                                             int AV29Notafiscalitemlistaitenswwds_1_propostaid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[16];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.NotaFiscalItemValorTotal, T1.NotaFiscalItemValorUnitario, T1.NotaFiscalItemQuantidade, T1.NotaFiscalItemDescricao, T1.NotaFiscalItemCFOP, T1.NotaFiscalItemCodigo, T2.NotaFiscalNumero, T1.NotaFiscalId, T1.PropostaId, T1.NotaFiscalItemId";
         sFromString = " FROM (NotaFiscalItem T1 LEFT JOIN NotaFiscal T2 ON T2.NotaFiscalId = T1.NotaFiscalId)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.PropostaId = :AV29Notafiscalitemlistaitenswwds_1_propostaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(T2.NotaFiscalNumero like :lV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.NotaFiscalNumero = ( :AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( StringUtil.StrCmp(AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.NotaFiscalNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel)) && ! ( StringUtil.StrCmp(AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo = ( :AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel))");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( StringUtil.StrCmp(AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalItemCodigo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao like :lV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel)) && ! ( StringUtil.StrCmp(AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao = ( :AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_se))");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalItemDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV36Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemQuantidade >= :AV36Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV37Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemQuantidade <= :AV37Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_t)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV38Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorUnitario >= :AV38Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitar)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV39Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorUnitario <= :AV39Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitar)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV40Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorTotal >= :AV40Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV41Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorTotal <= :AV41Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.PropostaId, T2.NotaFiscalNumero, T1.NotaFiscalItemId";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.PropostaId DESC, T2.NotaFiscalNumero DESC, T1.NotaFiscalItemId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.PropostaId, T1.NotaFiscalItemCodigo, T1.NotaFiscalItemId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.PropostaId DESC, T1.NotaFiscalItemCodigo DESC, T1.NotaFiscalItemId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.PropostaId, T1.NotaFiscalItemDescricao, T1.NotaFiscalItemId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.PropostaId DESC, T1.NotaFiscalItemDescricao DESC, T1.NotaFiscalItemId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.PropostaId, T1.NotaFiscalItemQuantidade, T1.NotaFiscalItemId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.PropostaId DESC, T1.NotaFiscalItemQuantidade DESC, T1.NotaFiscalItemId";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.PropostaId, T1.NotaFiscalItemValorUnitario, T1.NotaFiscalItemId";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.PropostaId DESC, T1.NotaFiscalItemValorUnitario DESC, T1.NotaFiscalItemId";
         }
         else if ( ( AV12OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.PropostaId, T1.NotaFiscalItemValorTotal, T1.NotaFiscalItemId";
         }
         else if ( ( AV12OrderedBy == 6 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.PropostaId DESC, T1.NotaFiscalItemValorTotal DESC, T1.NotaFiscalItemId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.NotaFiscalItemId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H009D3( IGxContext context ,
                                             string AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel ,
                                             string AV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero ,
                                             string AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel ,
                                             string AV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo ,
                                             string AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel ,
                                             string AV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao ,
                                             decimal AV36Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade ,
                                             decimal AV37Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to ,
                                             decimal AV38Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario ,
                                             decimal AV39Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to ,
                                             decimal AV40Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal ,
                                             decimal AV41Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to ,
                                             string A799NotaFiscalNumero ,
                                             string A831NotaFiscalItemCodigo ,
                                             string A833NotaFiscalItemDescricao ,
                                             decimal A837NotaFiscalItemQuantidade ,
                                             decimal A838NotaFiscalItemValorUnitario ,
                                             decimal A839NotaFiscalItemValorTotal ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             int A323PropostaId ,
                                             int AV29Notafiscalitemlistaitenswwds_1_propostaid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[13];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (NotaFiscalItem T1 LEFT JOIN NotaFiscal T2 ON T2.NotaFiscalId = T1.NotaFiscalId)";
         AddWhere(sWhereString, "(T1.PropostaId = :AV29Notafiscalitemlistaitenswwds_1_propostaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(T2.NotaFiscalNumero like :lV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.NotaFiscalNumero = ( :AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( StringUtil.StrCmp(AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.NotaFiscalNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel)) && ! ( StringUtil.StrCmp(AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo = ( :AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel))");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( StringUtil.StrCmp(AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalItemCodigo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao like :lV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel)) && ! ( StringUtil.StrCmp(AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao = ( :AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_se))");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( StringUtil.StrCmp(AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalItemDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV36Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemQuantidade >= :AV36Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV37Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemQuantidade <= :AV37Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_t)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV38Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorUnitario >= :AV38Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitar)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV39Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorUnitario <= :AV39Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitar)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV40Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorTotal >= :AV40Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV41Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorTotal <= :AV41Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_)");
         }
         else
         {
            GXv_int7[12] = 1;
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
                     return conditional_H009D2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] );
               case 1 :
                     return conditional_H009D3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] );
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
          Object[] prmH009D2;
          prmH009D2 = new Object[] {
          new ParDef("AV29Notafiscalitemlistaitenswwds_1_propostaid",GXType.Int32,9,0) ,
          new ParDef("lV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel",GXType.VarChar,40,0) ,
          new ParDef("lV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo",GXType.VarChar,60,0) ,
          new ParDef("AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel",GXType.VarChar,60,0) ,
          new ParDef("lV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao",GXType.VarChar,255,0) ,
          new ParDef("AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_se",GXType.VarChar,255,0) ,
          new ParDef("AV36Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade",GXType.Number,18,6) ,
          new ParDef("AV37Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_t",GXType.Number,18,6) ,
          new ParDef("AV38Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitar",GXType.Number,18,2) ,
          new ParDef("AV39Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitar",GXType.Number,18,2) ,
          new ParDef("AV40Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal",GXType.Number,18,2) ,
          new ParDef("AV41Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_",GXType.Number,18,2) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH009D3;
          prmH009D3 = new Object[] {
          new ParDef("AV29Notafiscalitemlistaitenswwds_1_propostaid",GXType.Int32,9,0) ,
          new ParDef("lV30Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV31Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel",GXType.VarChar,40,0) ,
          new ParDef("lV32Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo",GXType.VarChar,60,0) ,
          new ParDef("AV33Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel",GXType.VarChar,60,0) ,
          new ParDef("lV34Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao",GXType.VarChar,255,0) ,
          new ParDef("AV35Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_se",GXType.VarChar,255,0) ,
          new ParDef("AV36Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade",GXType.Number,18,6) ,
          new ParDef("AV37Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_t",GXType.Number,18,6) ,
          new ParDef("AV38Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitar",GXType.Number,18,2) ,
          new ParDef("AV39Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitar",GXType.Number,18,2) ,
          new ParDef("AV40Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal",GXType.Number,18,2) ,
          new ParDef("AV41Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_",GXType.Number,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("H009D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009D2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H009D3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009D3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((short[]) buf[8])[0] = rslt.getShort(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((Guid[]) buf[14])[0] = rslt.getGuid(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((Guid[]) buf[18])[0] = rslt.getGuid(10);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
